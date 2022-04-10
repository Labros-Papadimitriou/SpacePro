using MyDatabase;
using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            return RedirectToAction("ShowSocialGeneralUser");
        } 
        [HttpGet]
        public ActionResult ShowSocialGeneralUser()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetUsersTable()
        {
            var users = await _unitOfWork.ApplicationUsers.GetAllUsersWithImagesAndRoles();
            var roles = await _unitOfWork.UserRoles.GetAll();
            if (users != null)
            {
                return Json(new { users, roles }, JsonRequestBehavior.AllowGet);
            }
            return new HttpStatusCodeResult(HttpStatusCode.PreconditionFailed, "No Users Found");
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(string id)
        {
            if (!User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized,"Only Administrators can perform such tasks.");
            }
            var user = (await _unitOfWork.ApplicationUsers.GetAll()).SingleOrDefault(x=>x.Id==id);
            if (user != null)
            {
                await _unitOfWork.NewsListeners.DeleteNewsListener(id);
                var userDeleted = await _unitOfWork.ApplicationUsers.DeleteUserWithPostsAndImage(id);
                await _unitOfWork.Complete();
                return Json(userDeleted, JsonRequestBehavior.AllowGet);
            }
            return  new HttpStatusCodeResult(HttpStatusCode.BadRequest, "The user that you are trying to delete does not exist.");
        }
    }
}