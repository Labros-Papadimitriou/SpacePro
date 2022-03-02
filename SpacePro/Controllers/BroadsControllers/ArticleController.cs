using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.BroadsControllers
{
    public class ArticleController : Controller
    {
        ApplicationDbContext db;

        public ArticleController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Article
        public ActionResult ShowArticles()
        {
            return View();
        }

        public ActionResult CreateArticles()
        {
            return View();
        }
        public ActionResult DetailsArticles()
        {
            return View();
        }

        public ActionResult GetArticle()
        {
            var article = db.Articles
                            .Select(x => new {
                            x.Title,
                            x.Description,
                            x.PostDate,
                            x.PostLikes,
                            Category = x.ArticleCategory.Title,
                            Image = x.ArticleImages.Select(y => new { y.Url, y.AlternativeText })                         
                            });

            return Json(article,JsonRequestBehavior.AllowGet);
        }
    }
}