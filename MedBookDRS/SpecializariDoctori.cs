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
    
    public partial class SpecializariDoctori
    {
        public int IdSD { get; set; }
        public int IdDoctor { get; set; }
        public int IdSpecializare { get; set; }
    
        public virtual Doctori Doctori { get; set; }
        public virtual Specializari Specializari { get; set; }
    }
}
