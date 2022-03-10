using MyDatabase;
using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.BroadsControllers
{
    public class GalleryController : Controller
    {
        UnitOfWork unitOfWork;
        public GalleryController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        // GET: Gallery
        public ActionResult ShowGallery()
        {
            var images = unitOfWork.BodyImages.GetAll();
            return View(images);
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