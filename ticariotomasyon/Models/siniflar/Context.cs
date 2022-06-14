using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ticariotomasyon.Models.siniflar
{
    public class Context: DbContext
    {
        public DbSet <Admin> admins  { get; set; }
        public DbSet <cariler> carilers  { get; set; }
        public DbSet <departman> departmans  { get; set; }
        public DbSet <faturakalem> faturakalems  { get; set; }
        public DbSet <faturalar> faturalars  { get; set; }
        public DbSet <gider> giders  { get; set; }
        public DbSet <kategori> kategoris  { get; set; }
        public DbSet <personel> personels  { get; set; }
        public DbSet <satishareket> satisharekets  { get; set; }
        public DbSet <urun> uruns  { get; set; }
        public DbSet <detay> detays { get; set; }
        public DbSet <yapilacak> yapilacaks { get; set; } 
    }
}