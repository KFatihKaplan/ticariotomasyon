using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ticariotomasyon.Models.siniflar
{
    public class Admin
    {
        [Key]
        public int Adminid { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string kullaniciad  { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string sifre  { get; set; }

        [Column(TypeName = "char")]
        [StringLength(1)]
        public string yetki  { get; set; }
    }
}