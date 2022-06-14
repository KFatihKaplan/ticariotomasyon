using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ticariotomasyon.Models.siniflar
{
    public class satishareket
    {
        [Key]
        public int satisid { get; set; }
        public DateTime tarih { get; set; }
        public int adet { get; set; }
        public decimal fiyat { get; set; }
        public decimal ttutar { get; set; }

        public int urunid { get; set; }
        public int cariid { get; set; }
        public int personelid { get; set; }

        public virtual urun urun { get; set; }
        public virtual cariler cariler { get; set; }
        public virtual personel personel { get; set; }
        
    }
}