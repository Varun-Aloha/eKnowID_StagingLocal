using System.Collections.Generic;

namespace EknowIDModel
{
    public class ReferenceType
    {
        public int ReferenceTypeId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public virtual List<ReferenceInfo> ReferenceInfoes
        {
            get;
            set;
        }
        public virtual List<UserReferenceInfo> UserReferenceInfoes
        {
            get;
            set;
        }
    }
}
