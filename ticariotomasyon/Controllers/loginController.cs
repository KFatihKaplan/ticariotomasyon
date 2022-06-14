using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ticariotomasyon.Models.siniflar;

namespace ticariotomasyon.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult partial1(cariler p)
        {
            c.carilers.Add(p);
            c.SaveChanges();
            return PartialView();

        }
        [HttpGet]
        public ActionResult carilogin1()
        {
            
            return View();

        }
        [HttpPost]
        public ActionResult carilogin1(cariler p)
        {
            var bilgiler = c.carilers.FirstOrDefault(x => x.cariMail == p.cariMail && x.sifre == p.sifre);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.cariMail,false);
                Session["cariMail"]=bilgiler.cariMail.ToString();
                return RedirectToAction("Index", "caripanel");
            }
            else
            {
                return RedirectToAction("Index","login");
            }
            
        }
        [HttpGet]
        public ActionResult adminlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adminlogin(Admin p)
        {
            var bilgiler = c.admins.FirstOrDefault(x => x.kullaniciad == p.kullaniciad && x.sifre == p.sifre);
              if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullaniciad, false);
                Session["kullaniciad"] = bilgiler.kullaniciad.ToString();
                return RedirectToAction("Index", "kategori");
            }
              else
            {
                return RedirectToAction("Index", "login");
            }
        }
    }
}