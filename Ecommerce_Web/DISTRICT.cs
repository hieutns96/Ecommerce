//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ecommerce_Web
{
    using System;
    using System.Collections.Generic;
    
    public partial class DISTRICT
    {
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
        public virtual ICollection<WARD> WARDs { get; set; }
    }
}
