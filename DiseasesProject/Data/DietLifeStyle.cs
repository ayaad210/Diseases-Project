//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiseasesProject.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class DietLifeStyle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DietLifeStyle()
        {
            this.DiseaseLifeStyles = new HashSet<DiseaseLifeStyle>();
        }
    
        public int ID { get; set; }
        public string LifeStyle { get; set; }
        public string Diet { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiseaseLifeStyle> DiseaseLifeStyles { get; set; }
    }
}
