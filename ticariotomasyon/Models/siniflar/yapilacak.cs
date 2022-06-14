using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ticariotomasyon.Models.siniflar
{
    public class yapilacak
    {

        [Key]
        public int yapilacakid { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string baslik { get; set; }

        [Column(TypeName = "bit")]
        public bool durum { get; set; }
    }
}