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
    public class DraftController : Controller
    {
        DraftManager dm = new DraftManager(new EfDraftDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        // GET: Draft
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddDraft()
        {            
            return RedirectToAction("Index");
        }
    }
}