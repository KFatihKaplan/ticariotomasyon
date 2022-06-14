using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ticariotomasyon.Models.siniflar
{
    public class cariler
    {
        [Key]
        public int cariid { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string cariad { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30),]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]

        public string carisoyad { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(13)]
        public string carisehir { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string cariMail { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string sifre { get; set; }
        public bool durum { get; set; }

        public ICollection<satishareket> satisharekets { get; set; }
    }
}