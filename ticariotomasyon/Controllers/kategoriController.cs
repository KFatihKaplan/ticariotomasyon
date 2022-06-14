using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariotomasyon.Models.siniflar;
using PagedList;
using PagedList.Mvc;
namespace ticariotomasyon.Controllers
{
    public class kategoriController : Controller
    {
        // GET: kategori
        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = c.kategoris.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(kategori k)
        {
            c.kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg=c.kategoris.Find(id);
            c.kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.kategoris.Find(id);
            return View("KategoriGetir",kategori);

            
        }
        public ActionResult KategoriGuncelle(kategori k)
        {
            var ktgr = c.kategoris.Find(k.kategoriID);
            ktgr.kategoriAD = k.kategoriAD;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}