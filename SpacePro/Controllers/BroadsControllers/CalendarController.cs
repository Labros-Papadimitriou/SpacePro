using Entities.IdentityUsers;
using Microsoft.AspNet.Identity.Owin;
using MyDatabase;
using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.BroadsControllers
{
    [Authorize(Roles = "Admin")]
    public class CalendarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                if (_userManager == null && HttpContext == null)
                {
                    return new ApplicationUserManager(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(new ApplicationDbContext()));
                }
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public CalendarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public ActionResult ShowCalendar()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetEvents()
        {
            var events = await _unitOfWork.Events.GetAll();
            return Json(new { data = events },JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<ActionResult> GetAuthorOfTheMonth()
        {
            var users = await _unitOfWork.ApplicationUsers.GetAllUsersWithRolesAndPosts();
            var roles = await _unitOfWork.UserRoles.GetAll();
            var winner = HelperClasses.ApplicationUserHelper.GetAuthorOfTheMonth(users, roles);

            if(winner != null)
            {
                var userToModify = users.SingleOrDefault(x=>x.Id.Equals(winner.Id));
                userToModify.IsAuthorOfTheMonth = true;
                _unitOfWork.ApplicationUsers.ModifyEntity(userToModify);
                await _unitOfWork.Complete();
                return Json(new {data= winner }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = "No Authors Found" }, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<ActionResult> GetSubOfTheMonth()
        {
            var users = await _unitOfWork.ApplicationUsers.GetAllUsersWithRolesAndPosts();
            var roles = await _unitOfWork.UserRoles.GetAll();
            var winner = await HelperClasses.ApplicationUserHelper.GetSubOfTheMonth(users,roles,UserManager);
            if (winner != null)
            {
                var userToModify = users.SingleOrDefault(x => x.Id.Equals(winner.Id));
                userToModify.IsWinnerSub = true;
                _unitOfWork.ApplicationUsers.ModifyEntity(userToModify);
                await _unitOfWork.Complete();
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