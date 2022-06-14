using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariotomasyon.Models.siniflar;



namespace ticariotomasyon.Controllers
{
    public class cariController : Controller
    {
        // GET: cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.carilers.Where(x => x.durum == true).ToList();
            return View(degerler);

        }
        [HttpGet]
        public ActionResult yenicari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenicari(cariler p)
        {
            p.durum = true;
            c.carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult carisil(int id)
        {
            var cr = c.carilers.Find(id);
            cr.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult carigetir (int id)
        {
            var cari = c.carilers.Find(id);
            return View("carigetir",cari);
        }
        public ActionResult cariguncelle(cariler p)
        {
            if (!ModelState.IsValid) 
            {
                return View("carigetir"); 
            }
            var cari=c.carilers.Find(p.cariid);
            cari.cariad = p.cariad;
            cari.carisoyad = p.carisoyad;
            cari.carisehir = p.carisehir;
            cari.cariMail = p.cariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult musterisatis(int id)
        {
            var degerler = c.satisharekets.Where(x=>x.cariid == id).ToList();
            var cr = c.carilers.Where(x=>x.cariid==id).Select(y=>y.cariad+""+ y.carisoyad).FirstOrDefault();
            ViewBag.cari= cr;
            return View(degerler);  
        }
    }
}