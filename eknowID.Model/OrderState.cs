using System;

namespace EknowIDModel
{
   public class OrderState
    {
        public int OrderStatusId
        {
            get;
            set;
        }

        public int OrderId
        {
            get;
            set;
        }
        public int TazWorksOrderId
        {
            get;
            set;
        }
        public int TazWorksStatus
        {
            get;
            set;
        }
        public string URL
        {
            get;
            set;
        }
        public DateTime InsertTime
        {
            get;
            set;
        }

        public virtual Order Order
        {
            get;
            set;
        }

        public string xmlRequestStatus
        {
            get;
            set;
        }

    }
}
