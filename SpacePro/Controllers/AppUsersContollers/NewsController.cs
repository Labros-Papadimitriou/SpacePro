using Entities.BroadClasses;
using Entities.IdentityUsers;
using Entities.Observer;
using Microsoft.AspNet.Identity;
using Persistance_UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpacePro.Controllers.AppUsersContollers
{
    [Authorize(Roles = "Admin")]
    public class NewsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public NewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public ActionResult AddNewsletter()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddNewsletter(Newsletter newsletter)
        {
            _unitOfWork.Newsletters.Add(newsletter);
            await _unitOfWork.Complete();

            List<NewsListener> listeners = (List<NewsListener>)await _unitOfWork.NewsListeners.GetAll();

            News news = new News(listeners);

            foreach (var listener in listeners)
            {
                var user = (await _unitOfWork.ApplicationUsers.Find(x => x.Id == listener.UserId)).FirstOrDefault();
                SendEmail(user.Email, newsletter.Title, newsletter.Details);
            }

            return RedirectToAction("Index","Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> AddListener(string addInNews)
        {
            var allListeners = await _unitOfWork.NewsListeners.GetAll();

            if (addInNews == "yes" && !allListeners.Any(li=>li.UserId == User.Identity.GetUserId()))
            {
                NewsListener listener = new NewsListener();
                listener.UserId = User.Identity.GetUserId();

                _unitOfWork.NewsListeners.Add(listener);
                await _unitOfWork.Complete();

                ViewBag.Result = "You have successfully subscribed to our Newsletter!";
                return View();
            }
            else if(addInNews == "no")
            {
                if (allListeners.Any(li => li.UserId == User.Identity.GetUserId()))
                {
                    var listener = allListeners.Where(li => li.UserId == User.Identity.GetUserId()).FirstOrDefault();

                    List<NewsListener> listeners = (List<NewsListener>)await _unitOfWork.NewsListeners.GetAll();
                    News news = new News(listeners);
                    news.DetachListener(listener);

                    _unitOfWork.NewsListeners.Remove(listener);
                    await _unitOfWork.Complete();

                    ViewBag.Result = "Deleted from Newsletter ";
                    return View();
                }
            }

            return View();

        }

        public bool SendEmail(string toEmail, string subject, string emailBody)
        {
            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = Encoding.UTF8;

                client.Send(mailMessage);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}