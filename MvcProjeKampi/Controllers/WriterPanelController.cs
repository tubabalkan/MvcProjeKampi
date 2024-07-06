using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterValidator writervalidator = new WriterValidator();
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context c = new Context();
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["writerMail"];
           
            id = c.Writers.Where(x => x.writerMail == p).Select(y => y.writerId).FirstOrDefault();
            var writerValue=wm.GetById(id);
         
            return View(writerValue);
        }
      
        [HttpPost]
        public ActionResult WriterProfile(writer p)
        {
            ValidationResult results = writervalidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public ActionResult MyHeading(string p)
        {
          
            p = (string)Session["writerMail"];
            var writeridinfo=c.Writers.Where(x=>x.writerMail==p).Select(y=>y.writerId).FirstOrDefault();
            var values=hm.GetListByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                            ).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.writerId = 1;
            p.HeadinStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                               ).ToList();
          
            var headingvalue = hm.GetById(id);
            ViewBag.vlc = valuecategory;
        
            return View(headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = hm.GetById(id);
            headingvalue.HeadinStatus = false;
            hm.HeadingDelete(headingvalue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int p=1)
        {
            var headingss = hm.GetList().ToPagedList(p, 6);
            return View(headingss);
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}