using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ticariotomasyon.Models.siniflar
{
    public class gider
    {
        [Key]
        public int giderid { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string aciklama { get; set; }
        public DateTime tarih { get; set; }
        public decimal tutar { get; set; }

    }
}