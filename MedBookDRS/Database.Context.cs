//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedBookDRS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Med_DrsEntities : DbContext
    {
        public Med_DrsEntities()
            : base("name=Med_DrsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Doctori> Doctoris { get; set; }
        public virtual DbSet<Pacienti> Pacientis { get; set; }
        public virtual DbSet<Programari_Pacienti> Programari_Pacienti { get; set; }
        public virtual DbSet<ServiciiMedicale> ServiciiMedicales { get; set; }
        public virtual DbSet<Specializari> Specializaris { get; set; }
        public virtual DbSet<SpecializariDoctori> SpecializariDoctoris { get; set; }
    }
}
