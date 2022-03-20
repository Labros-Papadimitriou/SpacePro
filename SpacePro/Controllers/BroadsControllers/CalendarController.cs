using MyDatabase;
using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.BroadsControllers
{
    public class CalendarController : Controller
    {
        readonly UnitOfWork unitOfWork;
        public CalendarController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult ShowCalendar()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetEvents()
        {
           var events= unitOfWork.Events.GetAll();
            return Json(new { data = events });
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