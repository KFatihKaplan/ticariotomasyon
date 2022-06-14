using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ticariotomasyon.Models.siniflar
{
    public class faturakalem
    {
        [Key]
        public int fkalemid { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string acıklama { get; set; }
        public int miktar { get; set; }
        public decimal birimfiyat  { get; set; }
        public decimal tutar  { get; set; }
        public int faturaid { get; set; }
        public virtual faturalar faturalar { get; set; }
    }
} 