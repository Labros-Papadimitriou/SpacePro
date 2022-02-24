using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.AppUsersContollers
{
    public class AppUserController : Controller
    {
        public ActionResult UserProfile()
        {
            return View();
        }
        public ActionResult EditProfile()
        {
            return View();
        }

    }
}