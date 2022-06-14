using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ticariotomasyon.Models.siniflar;

namespace ticariotomasyon.Controllers
{
    public class caripanelController : Controller
    {
        // GET: caripanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["cariMail"];
            var degerler = c.carilers.FirstOrDefault(x=>x.cariMail == mail);
            return View(degerler);
        } 
        public ActionResult siparislerim()
        {
            var mail = (string)Session["cariMail"];
            var id = c.carilers.Where(x=>x.cariMail == mail.ToString()).Select(y=>y.cariid).FirstOrDefault();
            var degerler = c.satisharekets.Where(x => x.cariid == id).ToList();
            return View(degerler);
        }
    }
}