using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EknowIDModel
{
    public class UserLicenseInfo
    {
        public int UserLicenseInfoId
        {
            get;
            set;
        }
        public int UserId
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
        public User User
        {
            get;
            set;
        }
        public int StateId 
        {
            get;
            set;
        }
        public State State
        {
            get;
            set;
        }
    }
}
