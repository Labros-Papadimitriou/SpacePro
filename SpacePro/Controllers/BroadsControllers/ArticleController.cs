using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Entities.BroadClasses;
using SpacePro.Models.Dtos;

namespace SpacePro.Controllers.BroadsControllers
{
    public class ArticleController : Controller
    {
        ApplicationDbContext db;

        public ArticleController()
        {
            db = new ApplicationDbContext();
        }
        [HttpGet]
        public ActionResult ShowArticles()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllArticles()
        {
            var article = db.Articles
                            .Select(x => new {
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
            db.Entry(articleImage).State = EntityState.Added;

            Article article = new Article();
            article.Title = articleDto.Title;
            article.ShortDescription = articleDto.ShortDescription;
            article.FullDescription = articleDto.FullDescription;
            article.AuthorName = articleDto.AuthorName;
            article.PostLikes = 0;
            article.PostDate = DateTime.Now;
            article.ArticleCategoryId = articleDto.ArticleCategoryId;
            article.ArticleImage = articleImage;
            db.Entry(article).State = EntityState.Added;

            db.SaveChanges();

            return RedirectToAction("ShowArticles");
        }

        [HttpDelete]
        public ActionResult DeleteArticle(int? articleId, int? imageId)
        {
            var article = db.Articles.Find(articleId);
            var articleImage = db.ArticleImages.Find(imageId);
            var imageName = articleImage.Name;

            db.Entry(articleImage).State = EntityState.Deleted;
            db.Entry(article).State = EntityState.Deleted;

            db.SaveChanges();

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
        public ActionResult DetailsArticles()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetArticleDetails(int? id)
        {
            var article = db.Articles.Include(x=>x.ArticleCategory).Include(x=>x.ArticleImage).FirstOrDefault(x=>x.ArticleId==id);

            return View(article);
        }



        [HttpGet]
        public JsonResult GiveLike(int? id)
        {
            var article = db.Articles.Find(id);
            article.PostLikes++;
            db.SaveChanges();

            return Json(article.PostLikes, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult RemoveLike(int? id)
        {
            var article = db.Articles.Find(id);
            article.PostLikes--;
            db.SaveChanges();

            return Json(article.PostLikes, JsonRequestBehavior.AllowGet);
        }
    }
}