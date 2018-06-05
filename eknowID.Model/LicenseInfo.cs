
namespace EknowIDModel
{
    public class LicenseInfo
    {
        public int LicenseInfoId
        {
            get;
            set;
        }
        public int OrderId
        {
            get;
            set;
        }
        public string LicenseNumber
        {
            get;
            set;
        }
        public string LicenseName
        {
            get;
            set;
        }
        public string LicensingAgency
        {
            get;
            set;
        }

        public virtual Order Order
        {
            get;
            set;
        }

        public virtual int StateId
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
