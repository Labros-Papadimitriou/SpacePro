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
            var users = unitOfWork.ApplicationUsers.GetAllUsersWithRolesAndPosts();
            var roles = unitOfWork.UserRoles.GetAll();
            var winner = HelperClasses.ApplicationUserHelper.GetAuthorOfTheMonth(users, roles);

            if(winner != null)
            {
                var userToModify = users.Where(x => x.Id.Equals(winner.Id)).Single();
                userToModify.IsAuthorOfTheMonth = true;
                unitOfWork.ApplicationUsers.ModifyEntity(userToModify);
                unitOfWork.Complete();
                return Json(new {data= winner }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = "No Authors Found" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetSubOfTheMonth()
        {
            var users = unitOfWork.ApplicationUsers.GetAll();
            var roles = unitOfWork.UserRoles.GetAll();
            var winner = HelperClasses.ApplicationUserHelper.GetSubOfTheMonth(users, roles);

            if (winner != null)
            {
                var userToModify = users.Where(x => x.Id.Equals(winner.Id)).Single();
                userToModify.IsWinnerSub = true;
                unitOfWork.ApplicationUsers.ModifyEntity(userToModify);
                unitOfWork.Complete();
                return Json(new { data = winner }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { data = "No Subscribers Found" }, JsonRequestBehavior.AllowGet);
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