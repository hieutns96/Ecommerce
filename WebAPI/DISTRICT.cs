//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class DISTRICT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISTRICT()
        {
            this.WARDs = new HashSet<WARD>();
        }
    
        public string DISTRICTID { get; set; }
        public string PROVINCEID { get; set; }
        public string NAME { get; set; }
        public string TYPE { get; set; }
        public string LOCATION { get; set; }
    
        public virtual PROVINCE PROVINCE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WARD> WARDs { get; set; }
    }
}
