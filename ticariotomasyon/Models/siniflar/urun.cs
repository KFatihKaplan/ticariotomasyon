using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ticariotomasyon.Models.siniflar
{
    public class urun
    {
        [Key]
        public int urunID { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(30)]
        public string urunAD { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)] 
        public string marka { get; set; }
        public short stok { get; set; }
        public decimal alisfiyat { get; set; }
        public decimal satisfiyat { get; set; }
        public bool durum { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string urungorsel { get; set; }
        public int kategoriid { get; set; }
        public virtual kategori kategori { get; set; }
        public ICollection<satishareket> satisharekets { get; set; }
    }
}