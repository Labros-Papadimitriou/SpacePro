using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Entities.BroadClasses;
using SpacePro.Models.Dtos;
using Persistance_UnitOfWork;
using Entities.IdentityUsers;
using Microsoft.AspNet.Identity;

namespace SpacePro.Controllers.BroadsControllers
{
    public class ArticleController : Controller
    {
        UnitOfWork unitOfWork;

        public ArticleController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        [HttpGet]
        public ActionResult ShowArticles()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllArticles()
        {
            var article = unitOfWork.Articles
                            .GetArticlesFullModel().Select(x => new {
                                x.ArticleId,
                                x.Title,
                                x.ShortDescription,
                                x.PostDate,
                                x.PostLikes,
                                x.AuthorName,
                                Category = x.ArticleCategory.Title,
                                Url = x.ArticleImage.Url,
                                AltText = x.ArticleImage.AlternativeText
                            });

            return Json(article, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CreateArticles()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewArticle(CreateArticleDto articleDto, HttpPostedFileBase image)
        {
            if (image != null)
            {
                image.SaveAs(Server.MapPath("/Content/ArticlesImages/" + image.FileName));
            }

            ArticleImage articleImage = new ArticleImage();
            articleImage.Name = image.FileName;
            articleImage.Url = "/Content/ArticlesImages/" + image.FileName;
            articleImage.AlternativeText = (image.FileName).Split('.')[0];
            unitOfWork.ArticleImages.Add(articleImage);

            Article article = new Article();
            article.Title = articleDto.Title;
            article.ShortDescription = articleDto.ShortDescription;
            article.FullDescription = articleDto.FullDescription;
            article.AuthorName = articleDto.AuthorName;
            article.PostLikes = 0;
            article.PostDate = DateTime.Now;
            article.ArticleCategoryId = articleDto.ArticleCategoryId;
            article.ArticleImage = articleImage;
            unitOfWork.Articles.Add(article);

            unitOfWork.Complete();

            return RedirectToAction("ShowArticles");
        }

        [HttpPost]
        public ActionResult EditArticle(int? articleId, CreateArticleDto articleDto, HttpPostedFileBase image)
        {
            var article = unitOfWork.Articles.GetArticlesWithImage().FirstOrDefault(x => x.ArticleId == articleId);

            if (image != null)
            {
                image.SaveAs(Server.MapPath("/Content/ArticlesImages/" + image.FileName));

                ArticleImage articleImage = new ArticleImage();
                articleImage.Name = image.FileName;
                articleImage.Url = "/Content/ArticlesImages/" + image.FileName;
                articleImage.AlternativeText = (image.FileName).Split('.')[0];
                unitOfWork.ArticleImages.Add(articleImage);
                unitOfWork.ArticleImages.Remove(article.ArticleImage);

                article.ArticleImage = articleImage;
            }

            article.Title = articleDto.Title;
            article.ShortDescription = articleDto.ShortDescription;
            article.FullDescription = articleDto.FullDescription;
            article.AuthorName = articleDto.AuthorName;
            article.PostDate = DateTime.Now;
            article.ArticleCategoryId = articleDto.ArticleCategoryId;

            unitOfWork.Articles.ModifyEntity(article);
            unitOfWork.Complete();

            return RedirectToAction("ShowArticles");
        }

        [HttpDelete]
        public ActionResult DeleteArticle(int? articleId, int? imageId)
        {
            var article = unitOfWork.Articles.Get((int)articleId);
            var articleImage = unitOfWork.ArticleImages.Get((int)imageId);
            var imageName = articleImage.Name;

            unitOfWork.ArticleImages.Remove(articleImage);
            unitOfWork.Articles.Remove(article);

            unitOfWork.Complete();

            DeleteImageFromFolder(imageName);

            return Json("/Article/ShowArticles",JsonRequestBehavior.AllowGet);
        }

        private void DeleteImageFromFolder(string imageName)
        {
            var filePath = Server.MapPath("/Content/ArticlesImages/" + imageName);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        [HttpGet]
        public ActionResult GetArticleDetails(int? id)
        {
            var article = unitOfWork.Articles.GetArticlesFullModel().FirstOrDefault(x=>x.ArticleId==id);
            return View(article);
        }

        [HttpGet]
        public JsonResult GiveLike(int? articleId)
        {   
            var article = unitOfWork.Articles.Get((int)articleId);
            var likedUserId = User.Identity.GetUserId();
            var userNotYetLikedThisArticle = unitOfWork.ArticleLikes.Find(x => x.LikedUser == likedUserId && x.ArticleId == article.ArticleId).Count() == 0;

            if (userNotYetLikedThisArticle)
            {
                ArticleLike articleLike = new ArticleLike();
                articleLike.LikedUser = unitOfWork.ApplicationUsers.Find(x => x.Id == likedUserId).FirstOrDefault().Id;
                articleLike.ArticleId = article.ArticleId;
                unitOfWork.ArticleLikes.Add(articleLike);
                article.ArticleLikes.Add(articleLike);
                article.PostLikes++;
                unitOfWork.Complete();
            }  
            return Json(article.PostLikes, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult RemoveLike(int? articleId)
        {
            var article = unitOfWork.Articles.Get((int)articleId);
            var likedUserId = User.Identity.GetUserId();

            var articleLike = unitOfWork.ArticleLikes.Find(x => x.LikedUser == likedUserId && x.ArticleId == articleId).FirstOrDefault();
            unitOfWork.ArticleLikes.Remove(articleLike);
            article.PostLikes--;
            unitOfWork.Complete();

            return Json(article.PostLikes, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
