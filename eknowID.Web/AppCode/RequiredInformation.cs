using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eknowID.AppCode
{
    public class RequiredInformation
    {
        public bool isEducationDetailsRequired
        {
            get;
            set;
        }
        public bool isEmploymentDetailsRequired
        {
            get;
            set;
        }
        public bool isReferenceInformationRequired
        {
            get;
            set;
        }
        public bool isLicenseInformationRequired
        {
            get;
            set;
        }
        public bool isDrugVerificationRequired
        {
            get;
            set;
        }
    }
}