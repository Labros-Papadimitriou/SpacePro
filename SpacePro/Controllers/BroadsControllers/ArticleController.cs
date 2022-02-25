using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.BroadsControllers
{
    public class ArticleController : Controller
    {
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
    }
}