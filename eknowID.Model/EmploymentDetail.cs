using System;

namespace EknowIDModel
{
    public class EmploymentDetail
    {
        public int EmploymentDetailId
        {
            get;
            set;
        }
        public int OrderId
        {
            get;
            set;
        }

        public int StateId
        {
            get;
            set;
        }
        public String OrgName
        {
            get;
            set;
        }
        public String City
        {
            get;
            set;
        }
        public String Telephone
        {
            get;
            set;
        }
        public String PositionTitle
        {
            get;
            set;
        }
        public DateTime StartDate
        {
            get;
            set;
        }
        public DateTime? EndDate
        {
            get;
            set;
        }
        public String Description
        {
            get;
            set;
        }

        public virtual int StartMonth
        {
            get;
            set;
        }
        public virtual int StartYear
        {
            get;
            set;
        }
        public virtual int EndMonth
        {
            get;
            set;
        }
        public virtual int EndYear
        {
            get;
            set;
        }
        public virtual bool IsAttending { get; set; }
        public virtual Order Order
        {
            get;
            set;
        }

        public virtual State State
        {
            get;
            set;
        }


    }
}
