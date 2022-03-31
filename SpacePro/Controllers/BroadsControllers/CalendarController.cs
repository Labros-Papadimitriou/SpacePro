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
       private readonly IUnitOfWork _unitOfWork;
        public CalendarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult ShowCalendar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetEvents()
        {
           var events= _unitOfWork.Events.GetAll();
            return Json(new { data = events },JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAuthorOfTheMonth()
        {
            var users = _unitOfWork.ApplicationUsers.GetAllUsersWithRolesAndPosts();
            var roles = _unitOfWork.UserRoles.GetAll();
            var winner = HelperClasses.ApplicationUserHelper.GetAuthorOfTheMonth(users, roles);

            if(winner != null)
            {
                var userToModify = users.SingleOrDefault(x=>x.Id.Equals(winner.Id));
                userToModify.IsAuthorOfTheMonth = true;
                _unitOfWork.ApplicationUsers.ModifyEntity(userToModify);
                _unitOfWork.Complete();
                return Json(new {data= winner }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = "No Authors Found" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetSubOfTheMonth()
        {
            var users = _unitOfWork.ApplicationUsers.GetAllUsersWithRolesAndPosts();
            var roles = _unitOfWork.UserRoles.GetAll();
            var winner = HelperClasses.ApplicationUserHelper.GetSubOfTheMonth(users, roles);

            if (winner != null)
            {
                var userToModify = users.SingleOrDefault(x => x.Id.Equals(winner.Id));
                userToModify.IsWinnerSub = true;
                _unitOfWork.ApplicationUsers.ModifyEntity(userToModify);
                _unitOfWork.Complete();
                return Json(new { data = winner }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { data = "No Subscribers Found" }, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}