using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using TazWorksCom.XMLClasses;
using EknowIDData.Implementations;
using EknowIDData.Helper;

namespace TazWorksCom.WrapperClasses
{
    public class LicenseWrapper
    {
        private LicenseInfo _licenseInfo;
        public LicenseWrapper(LicenseInfo licenseInfo)
        {
            _licenseInfo = licenseInfo;
        }

        public LicenseScreening GetLicenseXMLNode()
        {
            string region = StateHelper.GetStateById(_licenseInfo.StateId).AlphaCode;

            LicenseScreening licenseScreening = new LicenseScreening();
            licenseScreening.SearchLicense = new SearchLicense();
            licenseScreening.SearchLicense.License = new SearchLicenseLicense();
            licenseScreening.Region = region;
            licenseScreening.SearchLicense.License.LicenseName = _licenseInfo.LicenseName;
            licenseScreening.SearchLicense.License.LicenseNumber = _licenseInfo.LicenseNumber;
            //licenseScreening.SearchLicense.License.LicensingAgency = _licenseInfo.LicensingAgency;
            licenseScreening.SearchLicense.License.LicensingAgency = region;

            return licenseScreening;
        }
    }
}
