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
    
    public partial class OrderState
    {
        public int OrderStatusId { get; set; }
        public int OrderId { get; set; }
        public int TazWorksOrderId { get; set; }
        public Nullable<int> TazWorksStatus { get; set; }
        public string URL { get; set; }
        public System.DateTime InsertTime { get; set; }
    
        public virtual Order Order { get; set; }
    }
}