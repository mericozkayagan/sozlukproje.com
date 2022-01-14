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
    public class TalentController : Controller
    {
        TalentManager tm = new TalentManager(new EfTalentDal());
        // GET: Talent
        public ActionResult Index()
        {
            var list = tm.GetList();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddTalent()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(Talent p)
        {
            tm.TalentAdd(p);
            return RedirectToAction("Index");
        }
    
    }
}
