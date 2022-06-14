using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariotomasyon.Models.siniflar;
namespace ticariotomasyon.Controllers
{
    public class urunController : Controller
    {
        // GET: urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in c.uruns select x;
            if(!string.IsNullOrEmpty(p))
            {
                urunler=urunler.Where (y=>y.urunAD.Contains (p));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult yeniurun()
        {
            List<SelectListItem> deger1 = (from x in c.kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.kategoriAD,
                                               Value = x.kategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult yeniurun(urun p)
        {
            c.uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult urunsil(int id)
        {
            var deger = c.uruns.Find(id);
            deger.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult urungetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.kategoriAD,
                                               Value = x.kategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger = c.uruns.Find(id);
            return View("urungetir", urundeger);
        }
        public ActionResult urunguncelle(urun p)
        {
            var urn = c.uruns.Find(p.urunID);
            urn.alisfiyat = p.alisfiyat;
            urn.durum = p.durum;
            urn.kategoriid = p.kategoriid; 
            urn.marka = p.marka;
            urn.satisfiyat = p.satisfiyat;  
            urn.stok = p.stok;
            urn.urunAD = p.urunAD;
            urn.urungorsel = p.urungorsel;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult urunlistesi()
        {
            var degerler = c.uruns.ToList();
            return View(degerler);
        }
    }
}