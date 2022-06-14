using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariotomasyon.Models.siniflar;

namespace ticariotomasyon.Controllers
{
    public class satisController : Controller
    {
        Context c= new Context();
        // GET: satis
        public ActionResult Index()
        {
            var degerler = c.satisharekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult yenisatis()
        {
            List<SelectListItem> deger1 = (from x in c.uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.urunAD,
                                               Value= x.urunID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.cariad+ " " +x.carisoyad,
                                               Value = x.cariid.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.personelad+" "+x.personelsoyad,
                                               Value = x.personelid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2; 
            ViewBag.dgr3 = deger3; 
            return View();
        }
        [HttpPost]
        public ActionResult yenisatis(satishareket s)
        {
            s.tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            c.satisharekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult satisgetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.urunAD,
                                               Value = x.urunID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.cariad + " " + x.carisoyad,
                                               Value = x.cariid.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.personelad + " " + x.personelsoyad,
                                               Value = x.personelid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.satisharekets.Find(id);
            return View("satisgetir", deger);
            
        }
        public ActionResult satisguncelle(satishareket p)
        {
            var deger = c.satisharekets.Find(p.satisid);
            deger.cariid= p.cariid;
            deger.adet = p.adet;
            deger.fiyat = p.fiyat;
            deger .personelid  = p.personelid;
            deger.tarih = p.tarih;
            deger.ttutar = p.ttutar;
            deger.urunid = p.urunid;
            c.SaveChanges();    
            return RedirectToAction("Index");

        }
        public ActionResult satisdetay(int id)
        {
            var degerler = c.satisharekets.Where(x => x.satisid == id).ToList();
            return View(degerler);
        }
    }
}