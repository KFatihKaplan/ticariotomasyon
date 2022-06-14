using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ticariotomasyon.Models.siniflar
{
    public class kategori
    {
        [Key]
        public int kategoriID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string kategoriAD { get; set; }
        public ICollection <urun> uruns { get; set; }

    }
}