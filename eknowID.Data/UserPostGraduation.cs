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
    
    public partial class UserPostGraduation
    {
        public int UserPostGraduationId { get; set; }
        public string PostGraduation { get; set; }
        public string Specialization { get; set; }
        public string University { get; set; }
        public string Municipality { get; set; }
        public int StateId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int UserId { get; set; }
        public Nullable<int> StartMonth { get; set; }
        public Nullable<int> StartYear { get; set; }
        public Nullable<int> EndMonth { get; set; }
        public Nullable<int> EndYear { get; set; }
        public Nullable<bool> IsAttending { get; set; }
    
        public virtual User User { get; set; }
    }
}
