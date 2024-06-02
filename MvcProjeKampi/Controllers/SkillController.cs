using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkillManager sm = new SkillManager(new EfSkillDal());
        public ActionResult SkilList()
        {
            var skilvalues = sm.GetList();
            ViewBag.title = "Tuba BALKAN";
            ViewBag.description = "Karamanoğlu Mehmetbey Üniversitesi - Bilgisayar Mühendisliği";
            return View(skilvalues);
        }
    }
}