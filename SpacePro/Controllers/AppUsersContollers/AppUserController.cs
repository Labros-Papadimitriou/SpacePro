using Entities.IdentityUsers;
using Microsoft.AspNet.Identity;
using MyDatabase;
using SpacePro.Models;
using SpacePro.Models.Dtos;
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
                .Include(u => u.UserImage)
                .FirstOrDefault();


            return View(user);
        }

        [HttpPost]
        public ActionResult AddUserImage(HttpPostedFileBase image)
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Include(x=>x.UserImage).FirstOrDefault(a => a.Id == userId);
            
            if (user.UserImage != null)
            {
                DeleteImageFromFolder(user.UserImage.Name);
            }

            if (image != null)
            {
                
                image.SaveAs(Server.MapPath("/Content/UserImages/" + image.FileName));

                if (user.UserImage != null)
                {
                    db.Entry(user.UserImage).State = EntityState.Deleted;
                }

                UserImage userImage = new UserImage();

                userImage.Name = image.FileName;
                userImage.Url = "/Content/UserImages/" + image.FileName;
                userImage.AlternativeText = (image.FileName).Split('.').First();
                userImage.ApplicationUser = user;
                db.Entry(userImage).State = EntityState.Added;

                user.UserImage = userImage;
                db.Entry(user).State = EntityState.Modified;

                db.SaveChanges();
            }



            return RedirectToAction("UserProfile");

        }

        public ActionResult EditProfile()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserPosts)
                .Include(u => u.UserImage)
                .FirstOrDefault();

            return View(user);
        }
        [HttpPost]
        public ActionResult EditProfile(EditUserDto editUserDto)
        {
            var id = User.Identity.GetUserId();
            var user = db.Users.Find(id);
            user.FirstName = editUserDto.FirstName;
            user.LastName = editUserDto.LastName;
            user.PhoneNumber = editUserDto.PhoneNumber;
            user.Email = editUserDto.Email;
            user.AboutMe = editUserDto.AboutMe;
            user.DateOfBirth = editUserDto.DateOfBirth;
            user.Work = editUserDto.Work;
            user.Education = editUserDto.Education;

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("UserProfile");
        }

        public ActionResult GetUserImage()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Where(x=>x.Id == userId).Select(x => new {x.UserImage.Url,x.UserImage.AlternativeText}).SingleOrDefault();

            return Json( new { data = user },JsonRequestBehavior.AllowGet);
        }

        private void DeleteImageFromFolder(string imageName)
        {
            var filePath = Server.MapPath("/Content/UserImages/" + imageName);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
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