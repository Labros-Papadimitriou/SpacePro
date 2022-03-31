using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Entities;
using MyDatabase;
using Persistance_UnitOfWork;

namespace SpacePro.Controllers
{
    public class ChatMessageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChatMessageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork =unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllChatMessages()
        {
            var chatMessages = await _unitOfWork.ChatMessages.GetAll();

            return Json(chatMessages, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> CreateChatMessage(string newMessage)
        {
            ChatMessage chatMessage = new ChatMessage() { MessageBox = newMessage };
            if (ModelState.IsValid)
            {
                _unitOfWork.ChatMessages.Add(chatMessage);
                await _unitOfWork.Complete();
            }

            return Json(new { chatMessage }, JsonRequestBehavior.AllowGet);
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
