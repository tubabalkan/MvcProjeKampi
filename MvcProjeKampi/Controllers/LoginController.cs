using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Context = DataAccessLayer.Concrete.Context;
using System.Web.UI.WebControls;

namespace MvcProjeKampi.Controllers
{

    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserinfo=c.Admins.FirstOrDefault(x=>x.AdminUserName==p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (adminuserinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"]=adminuserinfo.AdminPassword;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(writer p)
        {
            Context c = new Context();
            var writeruserinfo = c.Writers.FirstOrDefault(x => x.writerMail == p.writerMail && x.writerPassword == p.writerPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.writerMail, false);
                Session["writerMail"] = writeruserinfo.writerMail;
                return RedirectToAction("WriterPanel", "WriterProfile");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
       
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");
        }
    }
}