using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ticariotomasyon.Models.siniflar
{
    public class departman
    {
        [Key]
        public int departmanid { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string departmanad { get; set; }
        public bool durum { get; set; }
        public ICollection <personel> personels { get; set; }
    }
}