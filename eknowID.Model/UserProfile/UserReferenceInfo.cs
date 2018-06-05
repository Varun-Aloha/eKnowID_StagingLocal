using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EknowIDModel
{
    public class UserReferenceInfo
    {
        public int UserReferenceInfoId
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Relationship
        {
            get;
            set;
        }
        public string MobileNumber
        {
            get;
            set;
        }
        public string YearsKnown
        {
            get;
            set;
        }
        public virtual User User
        {
            get;
            set;
        }
        public virtual int ReferenceTypeId
        {
            get;
            set;
        }

        public virtual ReferenceType ReferenceType
        {
            get;
            set;
        }

    }
}
