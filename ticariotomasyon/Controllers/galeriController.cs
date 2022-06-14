using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariotomasyon.Models.siniflar;
namespace ticariotomasyon.Controllers
{
    public class galeriController : Controller
    {
        // GET: galeri
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.uruns.ToList();
            return View(degerler);
        }
    }
}