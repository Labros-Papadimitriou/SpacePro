using Microsoft.AspNet.Identity;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.AppUsersContollers
{
    public class AppUserController : Controller
    {
        private ApplicationDbContext db;
        public AppUserController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult UserProfile()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserPosts)
                .Include(u=>u.UserImage)
                .FirstOrDefault();


            return View(user);
        }
        public ActionResult EditProfile()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}