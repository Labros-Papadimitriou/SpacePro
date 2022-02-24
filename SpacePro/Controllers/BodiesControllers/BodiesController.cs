using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.BodiesControllers
{
    public class BodiesController : Controller
    {
        // GET: Bodies
        public ActionResult BodiesTable()
        {
            return View();
        }
    }
}