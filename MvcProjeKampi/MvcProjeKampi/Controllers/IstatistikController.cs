using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var categorylist = cm.GetList();
            var categorycount = categorylist.Count();
            ViewBag.count = categorycount;
            //////
            var soru2 = hm.GetList().Where(x => x.CategoryID == 8).Count();
            ViewBag.yazilim = soru2;
            /////
            string arama = "a";
            var soru3 = from x in wm.GetList()
                        where x.WriterName.ToLowerInvariant().Contains(arama.ToLowerInvariant())
                        select x;
            int writercount = soru3.Count();
            ViewBag.soru3 = writercount;
            /////         

            var query = from category in cm.GetList()
                        join heading in hm.GetList() on category.CategoryID equals heading.CategoryID
                        group category by category.CategoryName into Group
                        orderby Group.Count() descending
                        select new { CategoryName = Group.FirstOrDefault().CategoryName, Sayı = Group.Count() };
           var soru4=  query.FirstOrDefault();
            ViewBag.soru4 = soru4;
            /////
            var query2 = from category in cm.GetList()
                         group category by category.CategoryStatus == true into Group
                         select Group.Count();

            int soru5 = query2.First() - query2.ElementAt(1);          
            

            ViewBag.soru5 = soru5;


            return View();
        }
    }
}