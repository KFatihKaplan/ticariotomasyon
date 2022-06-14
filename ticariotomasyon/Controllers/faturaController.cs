using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariotomasyon.Models.siniflar;

namespace ticariotomasyon.Controllers
{
    public class faturaController : Controller
    {
        Context c = new Context();
        // GET: fatura
        public ActionResult Index()
        {
            var liste = c.faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult faturaekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult faturaekle(faturalar f)
        {
            c.faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult faturagetir(int id)
        {
            var fatura = c.faturalars.Find(id);
            return View("faturagetir",fatura);
        }
        public ActionResult faturaguncelle(faturalar f)
        {
            var fatura = c.faturalars.Find(f.faturaid);
            fatura.faturaSeriNo = f.faturaSeriNo;
            fatura.faturaSıraNo = f.faturaSıraNo;
            fatura.saat = f.saat;
            fatura.faturatarih = f.faturatarih;
            fatura.teslimEden = f.teslimEden;
            fatura.teslimAlan = f.teslimAlan;
            fatura.vergidairesi = f.vergidairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult faturadetay(int id)
        {
            var degerler = c.faturakalems.Where(x => x.faturaid == id).ToList();
            
            return View(degerler);

        }
        [HttpGet]
        public ActionResult yenikalem()
        {
            return View();

        }
        public ActionResult yenikalem(faturakalem p)
        {
            c.faturakalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}