using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EknowIDModel.UserProfile
{
    public class UserEmploymentDetail
    {
        public int UserEmploymentDetailId
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
        public int? StateId
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
        public virtual User User
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
