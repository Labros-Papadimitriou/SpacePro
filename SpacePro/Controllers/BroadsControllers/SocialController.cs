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

        private readonly UnitOfWork unitOfWork;

        public SocialController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        [HttpGet]
        public ActionResult ShowSocial()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUsersTable()
        {
            var users = unitOfWork.ApplicationUsers.GetAllUsersWithImagesAndRoles();

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public ActionResult DeleteUser(string id)
        {
            var userDeleted = unitOfWork.ApplicationUsers.DeleteUserWithPostsAndImage(id);

            return Json(userDeleted, JsonRequestBehavior.AllowGet);
        }
    }
}