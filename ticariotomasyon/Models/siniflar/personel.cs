using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ticariotomasyon.Models.siniflar
{
    public class personel
    {
        [Key]
        public int personelid { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string personelad { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string personelsoyad { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string personelgorsel { get; set; }
        public ICollection<satishareket> satisharekets { get; set; }
        public int departmanid {get; set; }
        public virtual departman departman { get; set; }
    }
}