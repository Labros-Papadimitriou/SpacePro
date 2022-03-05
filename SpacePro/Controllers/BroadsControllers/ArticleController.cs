using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Entities.BroadClasses;

namespace SpacePro.Controllers.BroadsControllers
{
    public class ArticleController : Controller
    {
        ApplicationDbContext db;

        public ArticleController()
        {
            db = new ApplicationDbContext();
        }
        // ------------------------SHOW START------------------------------- //
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
        // ------------------------SHOW END------------------------------- //



        // ------------------------CREATE START------------------------------- //
        [HttpGet]
        public ActionResult CreateArticles()
        {
            return View();
        }

        [HttpPost]
        public void CreateNewArticle(Article article)
        {
            
        }
        // ------------------------CREATE END------------------------------- //




        // ------------------------DETAILS START------------------------------- //
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
        // ------------------------DETAILS END------------------------------- //



        // ------------------------LIKES START------------------------------- //
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
        // ------------------------LIKES END------------------------------- //
    }
}