using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.BroadsControllers
{
    public class GalleryController : Controller
    {
        ApplicationDbContext db;
        public GalleryController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Gallery
        public ActionResult ShowGallery()
        {
            var images = db.BodyImages;
            return View(images);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}