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
    
    public partial class Company
    {
        public Company()
        {
            this.Users = new HashSet<User>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyTaxId { get; set; }
        public string Description { get; set; }
        public string JobTitle { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public bool IsCreditReportAuditingChargesPaid { get; set; }
        public bool IsEligibleForCreditReportScreening { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
    }
}
