using MyDatabase;
using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        [HttpDelete]
        public ActionResult DeleteUser(string id)
        {
            var userDeleted = _unitOfWork.ApplicationUsers.DeleteUserWithPostsAndImage(id);

            return Json(userDeleted, JsonRequestBehavior.AllowGet);
        }
    }
}