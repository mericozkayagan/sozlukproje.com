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
    public class AuthorizationController : Controller
    {            
        AdminManager am = new AdminManager(new EfAdminDal());

        [Authorize(Roles = "B")]
        public ActionResult Index()
        {
            var list= am.GetList();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            am.AdminAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> rolevalue = (from x in am.GetList()
                                                group x by x.AdminRole into Roles
                                                   select new SelectListItem
                                                   {
                                                       Text = Roles.Key,
                                                       Value = Roles.Key
                                                   }).ToList();
            ViewBag.role = rolevalue;            
            
            var adminvalue = am.GetByID(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            am.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}