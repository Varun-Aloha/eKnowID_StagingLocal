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
    
    public partial class StateDistrictCourtFee
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string DistrictCourt { get; set; }
        public decimal DistrictCourtFees { get; set; }
        public bool Deleted { get; set; }
    
        public virtual State State { get; set; }
    }
}