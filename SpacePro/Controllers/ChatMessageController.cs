using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities;
using MyDatabase;
using Persistance_UnitOfWork;

namespace SpacePro.Controllers
{
    public class ChatMessageController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public ChatMessageController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        [HttpGet]
        public ActionResult GetAllChatMessages()
        {
            var chatMessages = unitOfWork.ChatMessages.GetAll();

            return Json(chatMessages, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateChatMessage(string newMessage)
        {
            ChatMessage chatMessage = new ChatMessage() { MessageBox = newMessage };
            if (ModelState.IsValid)
            {
                unitOfWork.ChatMessages.Add(chatMessage);
                unitOfWork.Complete();
            }

            return Json(new { chatMessage }, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
