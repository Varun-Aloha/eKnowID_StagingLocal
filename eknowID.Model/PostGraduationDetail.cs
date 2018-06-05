using System;

namespace EknowIDModel
{
    public class PostGraduationDetail
    {
        public virtual int PostGraduationId
        {
            get;
            set;
        }
        public virtual int EducationalDetailId
        {
            get;
            set;
        }
        public virtual string PostGraduation
        {
            get;
            set;
        }
        public virtual string Specialization
        {
            get;
            set;
        }
        public virtual string University
        {
            get;
            set;
        }
        public virtual string Municipality
        {
            get;
            set;
        }
        public virtual int StateId
        {
            get;
            set;
        }
        public virtual bool IsAttending { get; set;}
        public virtual DateTime StartDate
        {
            get;
            set;
        }
        public virtual DateTime? EndDate
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

        public virtual State State
        {
            get;
            set;
        }

        public virtual EducationalDetail EducationalDetail
        {
            get;
            set;
        }

    }
}
