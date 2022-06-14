using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariotomasyon.Models.siniflar;

namespace ticariotomasyon.Controllers
{
    public class departmanController : Controller
    {
        // GET: departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.departmans.Where(x => x.durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult departmanekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult departmanekle(departman d)
        {
            d.durum = true;
            c.departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult departmansil(int id)
        {
            var dep = c.departmans.Find(id);
            dep.durum = false ;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult departmangetir(int id)
        {
            var dpt = c.departmans.Find(id);
            return View("departmangetir",dpt);
        }
        public ActionResult departmanguncelle(departman p)
        {
            var dept = c.departmans.Find(p.departmanid);
            dept.departmanad = p.departmanad;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult departmandetay(int id)
        {
            var degerler = c.personels.Where(x=> x.departmanid==id).ToList();
            var dpt = c.departmans.Where(x=> x.departmanid==id).Select(y=> y.departmanad).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
        public ActionResult departmanpersonelsatis (int id)
        {
            var degerler = c.satisharekets.Where(x=> x.personelid== id).ToList();
            var per = c.personels.Where(x=>x.personelid == id).Select(y=>y.personelad+" "+y.personelsoyad).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);
        }
    }
}