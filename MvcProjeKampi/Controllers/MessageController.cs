using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager cm = new MessageManager(new EfMessageDal());
        // GET: Message
        public ActionResult Inbox()
        {
            var messageList = cm.GetListInbox();
            
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            var messageList = cm.GetListSendbox();
            return View(messageList);
        }
        [HttpGet]
        public ActionResult NewMessage() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            
            return View();
        }
    }
}