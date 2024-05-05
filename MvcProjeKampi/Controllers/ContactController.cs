using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm=new ContactManager(new EfContactDal());
        ContactValidatior cv = new ContactValidatior();
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetail(int id)
        {
            var contactvalues=cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu() 
        {
            return PartialView();
        }
    }
}