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
    
    public partial class UserLicenseInfo
    {
        public int UserLicenseInfoId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> StateId { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseName { get; set; }
        public string LicensingAgency { get; set; }
    
        public virtual State State { get; set; }
        public virtual User User { get; set; }
    }
}