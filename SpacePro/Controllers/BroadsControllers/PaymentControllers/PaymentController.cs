using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.BroadsControllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public ActionResult ShowPaymentMethods()
        {
            return View();
        }
    }
}