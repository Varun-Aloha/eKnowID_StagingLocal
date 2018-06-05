using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EknowIDModel
{
    public class UserEducationalDetail
    {
        public int UserEducationalDetailId
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
        public string Basic
        {
            get;
            set;
        }
        public string Specialization
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

        public User User
        {
            get;
            set;
        }
        //public virtual Institute Institute
        //{
        //    get;
        //    set;
        //}
        public virtual int? StateId
        {
            get;
            set;
        }
        public virtual State State
        {
            get;
            set;
        }
      
        public string Municipality
        {
            get;
            set;
        }
        public string University
        {
            get;
            set;
        }


    }
}
