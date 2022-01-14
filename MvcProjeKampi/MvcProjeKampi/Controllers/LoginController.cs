using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Scrypt;
namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager am = new AdminManager(new EfAdminDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());
        ScryptEncoder encoder = new ScryptEncoder();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var adminlist = (from c in am.GetList()
                             where p.AdminUserName==c.AdminUserName                         
                             select c).SingleOrDefault();

            
            bool isValidPassword = encoder.Compare(p.AdminPassword,adminlist.AdminPassword );
            
            if (isValidPassword)
            {
                FormsAuthentication.SetAuthCookie(p.AdminUserName, false);
                Session["AdminUserName"] = adminlist.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.d = "Kullanıcı adı veya şifre yanlış";
                return RedirectToAction("Index");
            }
            
        }

        
        
        public ActionResult Hash()
        {           

            foreach (var item in am.GetList())
            {                
                item.AdminPassword = encoder.Encode(item.AdminPassword);
                am.AdminUpdate(item);
            }           

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //var writerinfo = (from c in wm.GetList()
            //                 where p.WriterMail == c.WriterMail && p.WriterPassword==c.WriterPassword
            //                 select c).FirstOrDefault();            
            var writerinfo = wlm.GetWriter(p.WriterMail,p.WriterPassword);
            if (writerinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(p.WriterMail, false);
                Session["WriterMail"] = writerinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya şifre yanlış";
                return RedirectToAction("WriterLogin");
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }

    }
}