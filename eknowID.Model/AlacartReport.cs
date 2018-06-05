
namespace EknowIDModel
{
   public class AlacartReport
    {
       public virtual int AlacartId
        {
            get;
            set;
        }

       public virtual int OrderId
       {
           get;
           set;
       }
        public virtual int Qty {
            get;
            set;
        }

        public virtual string StatesSelected {
            get;
            set;
        }

        public virtual string Couty_DistrictsSelected {
            get;
            set;
        }
        public virtual Order Order
        {
            get;
            set;
        }

        public virtual int ReportId
        {
            get;
            set;
        }

        public virtual Report Report
        {
            get;
            set;
        }
    }
}
