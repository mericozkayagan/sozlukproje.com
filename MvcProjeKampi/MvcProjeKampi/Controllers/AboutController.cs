using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager am = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalues = am.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            am.AboutAdd(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult ActivateAbout(int id)
        {
            foreach (var item in am.GetList())
            {
                if (item.AboutID==id)
                {
                    item.AboutStatus = true;
                    am.AboutUpdate(item);
                }
                else
                {
                    item.AboutStatus = false;
                    am.AboutUpdate(item);
                }
            }
            return RedirectToAction("Index");            
        }
        public ActionResult DeactivateAbout(int id)
        {
            foreach (var item in am.GetList())
            {
                if (item.AboutID == id)
                {
                    item.AboutStatus = false;
                    am.AboutUpdate(item);
                }
                else
                {
                    item.AboutStatus = true;
                    am.AboutUpdate(item);
                }
            }
            return RedirectToAction("Index");
        }
    }
}