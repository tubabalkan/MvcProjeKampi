using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
            Context c = new Context();
            p = (string)Session["writerMail"];
            var writerIdinfo=c.Writers.Where(x=>x.writerMail==p).Select(y=>y.writerId).FirstOrDefault();
            var contentvalues = cm.GetListByWriter(writerIdinfo);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
           
            string mail = (string)Session["writerMail"];
            var writerIdinfo = c.Writers.Where(x => x.writerMail == mail).Select(y => y.writerId).FirstOrDefault();
            p.ContentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            p.writerId=writerIdinfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return  RedirectToAction("MyContent");
        }
    }
}