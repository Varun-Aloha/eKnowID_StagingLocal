using System.Collections.Generic;

namespace EknowIDModel
{
   public class OrderType
    {
       public virtual int OrderTypeID { get; set; }
       public virtual string OrderTypeName { get; set; }

       public virtual List<Order> Orders { get; set; }
    }
}
