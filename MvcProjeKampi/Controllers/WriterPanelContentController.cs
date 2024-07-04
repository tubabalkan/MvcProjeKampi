using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
            Context c = new Context();
            p = (string)Session["writerMail"];
            var writerIdinfo=c.Writers.Where(x=>x.writerMail==p).Select(y=>y.writerId).FirstOrDefault();
            var contentvalues = cm.GetListByWriter(writerIdinfo);
            return View(contentvalues);
        }
    }
}