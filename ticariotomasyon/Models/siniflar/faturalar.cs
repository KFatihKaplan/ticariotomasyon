using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ticariotomasyon.Models.siniflar
{
    public class faturalar
    {
        [Key]
        public int faturaid { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1)]
        public string faturaSeriNo { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string faturaSıraNo { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(60)]
        public string vergidairesi { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string teslimEden { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string teslimAlan { get; set; }
        public DateTime faturatarih { get; set; }
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string saat { get; set; }

        public decimal toplam { get; set; }
        public ICollection <faturakalem> faturakalems{ get; set; }

    }
}