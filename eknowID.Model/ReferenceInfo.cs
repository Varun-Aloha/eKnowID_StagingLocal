
namespace EknowIDModel
{
    public class ReferenceInfo
    {
        public int ReferenceInfoId
        {
            get;
            set;
        }
        public int OrderId
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

        public virtual Order Order
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
