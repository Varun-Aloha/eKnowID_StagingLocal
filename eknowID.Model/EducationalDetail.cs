using System;
using System.Collections.Generic;

namespace EknowIDModel
{
    public class EducationalDetail
    {
        public int EducationalDetailId
        {
            get;
            set;
        }
        public int OrderId
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

        public virtual int StateId
        {
            get;
            set;
        }

        public virtual string Municipality
        {
            get;
            set;
        }
        public string University
        {
            get;
            set;
        }
        public virtual List<PostGraduationDetail> PostGraduationDetails
        {
            get;
            set;
        }
    }
}
