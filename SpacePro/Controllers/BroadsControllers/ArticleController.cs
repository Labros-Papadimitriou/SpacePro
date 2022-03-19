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
                            .GetArticlesWithImageAndCategory().Select(x => new {
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
            var article = unitOfWork.Articles.GetArticlesWithImageAndCategory().FirstOrDefault(x=>x.ArticleId==id);
            return View(article);
        }



        [HttpGet]
        public JsonResult GiveLike(int? id)
        {   
            var article = unitOfWork.Articles.Get((int)id);
            article.PostLikes++;
            unitOfWork.Complete();

            return Json(article.PostLikes, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult RemoveLike(int? id)
        {
            var article = unitOfWork.Articles.Get((int)id);
            article.PostLikes--;
            unitOfWork.Complete();

            return Json(article.PostLikes, JsonRequestBehavior.AllowGet);
        }
    }
}