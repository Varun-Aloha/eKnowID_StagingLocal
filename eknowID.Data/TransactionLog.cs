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
    
    public partial class TransactionLog
    {
        public int Id { get; set; }
        public Nullable<int> OrderId { get; set; }
        public string Description { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
