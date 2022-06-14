using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariotomasyon.Models.siniflar;
namespace ticariotomasyon.Controllers
{
    public class urundetayController : Controller
    {
        // GET: urundetay
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();

            //var degerler = c.uruns.Where(x => x.urunID == 1).ToList();
            cs.deger1 = c.uruns.Where(x=>x.urunID == 1).ToList();
            cs.deger2 = c.detays.Where(y=>y.detayid == 1).ToList();
            return View(cs);
        }
    }
}