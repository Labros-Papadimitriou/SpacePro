using MyDatabase;
using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.BroadsControllers
{
    public class SocialController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public SocialController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult ShowSocial()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUsersTable()
        {
            var users = _unitOfWork.ApplicationUsers.GetAllUsersWithImagesAndRoles();
            var roles = _unitOfWork.UserRoles.GetAll();
            return Json(new { users,roles }, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete]
        public ActionResult DeleteUser(string id)
        {
            if (!User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized,"Only Administrators can perform such tasks.");
            }
            var user = _unitOfWork.ApplicationUsers.GetAll().SingleOrDefault(x=>x.Id==id);
            if (user != null)
            {
                var userDeleted = _unitOfWork.ApplicationUsers.DeleteUserWithPostsAndImage(id);
                return Json(userDeleted, JsonRequestBehavior.AllowGet);
            }
            return  new HttpStatusCodeResult(HttpStatusCode.BadRequest, "The user that you are trying to delete does not exist.");
        }
    }
}