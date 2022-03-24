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
            return Json(new { data = events },JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetAuthorOfTheMonth()
        {
            var users = unitOfWork.ApplicationUsers.GetAll();
            var roles = unitOfWork.UserRoles.GetAll();
            var winner = HelperClasses.ApplicationUserHelper.GetAuthorOfTheMonth(users, roles);
            return Json(winner, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetSubOfTheMonth()
        {
            var users = unitOfWork.ApplicationUsers.GetAll();
            var roles = unitOfWork.UserRoles.GetAll();
            var winner = HelperClasses.ApplicationUserHelper.GetSubOfTheMonth(users, roles);
            return Json(winner, JsonRequestBehavior.AllowGet);
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