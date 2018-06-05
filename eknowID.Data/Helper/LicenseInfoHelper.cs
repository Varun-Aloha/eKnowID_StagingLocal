using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Implementations;

namespace EknowIDData.Helper
{
    public class LicenseInfoHelper
    {
        public static LicenseInfo GetLicenseInfoByOrderId(int OrderId)
        {
            LicenseInfo licenseInfo = new LicenseInfo();
            Repository<LicenseInfo> licenseInfoRepository = new Repository<LicenseInfo>("OrderId");
            licenseInfo = licenseInfoRepository.SelectByKey(OrderId.ToString());
            return licenseInfo;
        }

        //public static string GetRegularExpressionByStateId(int StateId)
        //{
        //    State state = StateHelper.GetStateById(StateId);
        //    int stateLicenseFormatId = state.StateLicenseFormatId;
        //    Repository<StateLicenseFormat> repository = new Repository<StateLicenseFormat>("StateLicenseFormatId");
        //    return repository.SelectByKey(stateLicenseFormatId.ToString()).RegularExpression;            
        //}
    }
}
