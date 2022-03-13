using MyDatabase;
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

        private readonly ApplicationDbContext db;

        public SocialController()
        {
            db = new ApplicationDbContext();
        }

        [HttpGet]
        public ActionResult ShowSocial()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUsersTable()
        {
            var users = db.Users.Select(x => new
            {
                x.Id,
                x.UserImage,
                x.UserName,
                x.DateOfBirth,
                Role = x.Roles.FirstOrDefault()
            });

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public ActionResult DeleteUser(string id)
        {
            var user = db.Users.Where(x => x.Id == id).Include(x=>x.UserImage).FirstOrDefault();

            var imgId = user.UserImage.UserImageId;
            var img = db.UserImages.Find(imgId);
            
            db.Entry(img).State = EntityState.Deleted;
            foreach (var post in user.UserPosts)
            {
                db.Entry(post).State = EntityState.Deleted;
                db.SaveChanges();
            }

            db.Entry(user).State = EntityState.Deleted;
            db.SaveChanges();

            return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}