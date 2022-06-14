using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariotomasyon.Models.siniflar;

namespace ticariotomasyon.Controllers
{
    public class istatistikController : Controller
    {
        Context c = new Context();
        // GET: istatistik
        public ActionResult Index()
        {
            var deger1 = c.carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.uruns.Sum(x => x.stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.uruns select x.marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.uruns.Count(x => x.stok <= 20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.uruns orderby x.satisfiyat descending select x.urunAD).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.uruns orderby x.satisfiyat ascending select x.urunAD).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.uruns.Count(x => x.urunAD == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.uruns.Count(x => x.urunAD == "Laptop").ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.uruns.GroupBy(x => x.marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 = c.uruns.Where(u=>u.urunID==(c.satisharekets.GroupBy(x => x.urunid).
            OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).
            Select(k=>k.urunAD).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = c.satisharekets.Sum(x => x.ttutar).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = c.satisharekets.Count(x => x.tarih == bugun).ToString();
            ViewBag.d15 = deger15;
            var deger16 = c.satisharekets.Where(x => x.tarih == bugun).Sum(y => (decimal?)y.ttutar).ToString();
            ViewBag.d16 = deger16;

            return View();
        }
        public ActionResult kolaytablolar()
        {
            var sorgu = from x in c.carilers
                        group x by x.carisehir into g
                        select new sinifgrup
                        {
                            sehir = g.Key,
                            sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult partial1()
        {
            var sorgu2 = from x in c.personels
                         group x by x.departman.departmanad into g
                         select new sinifgrup2
                         {
                             departman=g.Key,
                             sayi=g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu = c.carilers.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult partial3()
        {
            var sorgu = c.uruns.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult partial4()
        {
            var sorgu = from x in c.uruns
                         group x by x.marka into g
                         select new sinifgrup3
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu.ToList());
        }
    }

}