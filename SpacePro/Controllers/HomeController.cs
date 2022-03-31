using Entities.IdentityUsers;
using Microsoft.AspNet.Identity;
using MyDatabase;
using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork =unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Chat()
        {
            var userId = User.Identity.GetUserId();

            var user = await _unitOfWork.ApplicationUsers.GetUserWithImages(userId);

            dynamic myModel = new ExpandoObject();
            myModel.Id = userId;

            if (user.UserImage is null)
            {
                myModel.ImageUrl = "/Template/sash/assets/images/users/7.jpg";
                return View(myModel);
            }
            myModel.ImageUrl = user.UserImage.Url;
            return View(myModel);
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