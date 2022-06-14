using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariotomasyon.Models.siniflar;

namespace ticariotomasyon.Controllers
{
    public class personelController : Controller
    {
        Context c = new Context();
        // GET: personel
        public ActionResult Index()
        {
            var degerler = c.personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult personelekle()
        {
            List<SelectListItem> deger1 = (from x in c.departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.departmanad,
                                               Value = x.departmanid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
           
        }
        [HttpPost] 
        public ActionResult personelekle( personel p)
        {
            if(Request.Files.Count > 0)
            {
                string dosyaadi=Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.personelgorsel = "/image/" + dosyaadi + uzanti; 

            }
            c.personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult personelgetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.departmanad,
                                               Value = x.departmanid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.personels.Find(id);
            return View("personelgetir",prs);
        }
        public ActionResult personelguncelle(personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.personelgorsel = "/image/" + dosyaadi + uzanti;

            }
            var prsn = c.personels.Find(p.personelid);
            prsn.personelad = p.personelad;
            prsn.personelsoyad = p.personelsoyad;
            prsn.personelgorsel = p.personelgorsel;
            prsn.departmanid = p.departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult personelliste()
        {
            var sorgu = c.personels.ToList();
            return View(sorgu);        
        }
    }
}