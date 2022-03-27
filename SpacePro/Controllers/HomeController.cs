using Microsoft.AspNet.Identity;
using MyDatabase;
using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork unitOfWork;
        public HomeController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Chat()
        {
            Task<string> task = new Task<string>(User.Identity.GetUserId);
            task.Start();
            var userId = await task;

            var user = await unitOfWork.ApplicationUsers.GetUserWithImages(userId);
            return View(user);
        }
    }
}