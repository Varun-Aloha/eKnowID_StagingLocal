using System;

namespace EknowIDModel
{
    public class TransactionLog
    {
        public virtual int Id { get; set; }
        public virtual int? OrderId { get; set; }
        public virtual string Description { get; set; }
        public virtual string Request { get; set; }
        public virtual string Response { get; set; }
        public virtual DateTime LogDate { get; set; }  
        public virtual Order Order { get; set; }
    }
}
