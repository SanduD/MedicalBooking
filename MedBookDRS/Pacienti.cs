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
    using System.Collections.Generic;
    
    public partial class Pacienti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pacienti()
        {
            this.Programari_Pacienti = new HashSet<Programari_Pacienti>();
        }
    
        public int IdPacient { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Sex { get; set; }
        public string Telefon { get; set; }
        public System.DateTime DataNastere { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Programari_Pacienti> Programari_Pacienti { get; set; }
    }
}
