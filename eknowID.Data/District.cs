//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eknowID.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class District
    {
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public Nullable<int> StateId { get; set; }
    
        public virtual State State { get; set; }
    }
}
