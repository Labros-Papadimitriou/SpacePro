using Entities.IdentityUsers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyDatabase;
using Persistance_UnitOfWork;
using SpacePro.Controllers.HelperClasses;
using SpacePro.Models;
using SpacePro.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.AppUsersContollers
{
    public class AppUserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppUserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> UserProfile()
        {
            var userId = User.Identity.GetUserId();
            var user = await _unitOfWork.ApplicationUsers.GetUserWithImages(userId);

            return View(user);
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers(string ids)
        {
            var idsArray = ids.Split(',');
            List<ApplicationUser> users = new List<ApplicationUser>();
            foreach (var id in idsArray)
            {
                var user = await _unitOfWork.ApplicationUsers.GetUserWithImages(id);
                
                users.Add(user);
            }

            var filteredUsers = users.AddUserImageIfNull();

            return Json(new { data = filteredUsers }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public async Task<ActionResult> AnyUserProfile(string id)
        {
            var user = await _unitOfWork.ApplicationUsers.GetUserWithImages(id);

            return View("UserProfile",user);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserImage(HttpPostedFileBase image)
        {

            var user = await _unitOfWork.ApplicationUsers.GetUserWithImages(User.Identity.GetUserId());

            if (user.UserImage != null)
            {
                DeleteImageFromFolder(user.UserImage.Name);
            }

            if (image != null)
            {
                image.SaveAs(Server.MapPath("/Content/UserImages/" + image.FileName));

                if (user.UserImage != null)
                {
                    _unitOfWork.UserImages.Remove(user.UserImage);
                }

                UserImage userImage = new UserImage();

                userImage.Name = image.FileName;
                userImage.Url = "/Content/UserImages/" + image.FileName;
                userImage.AlternativeText = (image.FileName).Split('.').First();
                userImage.ApplicationUser = user;
                _unitOfWork.UserImages.Add(userImage);

                user.UserImage = userImage;
                _unitOfWork.ApplicationUsers.ModifyEntity(user);

                await _unitOfWork.Complete();
            }
            return RedirectToAction("UserProfile");
        }

        [HttpGet]
        public async Task<ActionResult> EditProfile()
        {
            var user = await _unitOfWork.ApplicationUsers.GetUser(User.Identity.GetUserId());

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> EditProfile(EditUserDto editUserDto)
        {
            var user = await _unitOfWork.ApplicationUsers.GetUser(User.Identity.GetUserId());

            user.FirstName = editUserDto.FirstName;
            user.LastName = editUserDto.LastName;
            user.PhoneNumber = editUserDto.PhoneNumber;
            user.Email = editUserDto.Email;
            user.AboutMe = editUserDto.AboutMe;
            user.DateOfBirth = editUserDto.DateOfBirth;
            user.Work = editUserDto.Work;
            user.Education = editUserDto.Education;

            _unitOfWork.ApplicationUsers.ModifyEntity(user);
            await _unitOfWork.Complete();

            return RedirectToAction("UserProfile");
        }

        [HttpGet]
        public async Task<ActionResult> GetUserImage()
        {
            var userId = User.Identity.GetUserId();

            if (User.Identity.GetUserId() == null)
            {
                return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
            }

            if ( (await _unitOfWork.ApplicationUsers.GetUserWithImages(userId)).UserImage == null)
            {
                return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
            }

            var imgId = (await _unitOfWork.ApplicationUsers
                .GetUserWithImages(userId)).UserImage.UserImageId;

            var userImg = (await _unitOfWork.UserImages
                .Find(x => x.UserImageId == imgId))
                .Select(x=> new {x.Url,x.AlternativeText})
                .FirstOrDefault();

            return Json( new { data = userImg },JsonRequestBehavior.AllowGet);
        }
    
        private void DeleteImageFromFolder(string imageName)
        {
            var filePath = Server.MapPath("/Content/UserImages/" + imageName);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(string id)
        {
            await _unitOfWork.ApplicationUsers.DeleteUserWithPostsAndImage(id);

            return RedirectToAction("Index", "Home");
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