using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Implementations;
using EknowIDData.Helper.UserProfileHelper;

namespace EknowIDData.Helper
{
    public class UserLicenseInfoHelper
    {
        //Retrive UserLicenseInfo by UserId
        public static UserLicenseInfo GetUserLicenseInfoByUserId(int UserId)
        {
            Repository<UserLicenseInfo> licenseInfoRepository = new Repository<UserLicenseInfo>("UserId");
            return licenseInfoRepository.SelectByKey(UserId.ToString());
        }

        //Save or Update UserLicenseInfo
        public static UserProfileInfo SaveUserLicenseInfo(UserLicenseInfo userLicenseInfo)
        {
            //bool isAdded = false;
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            try
            {
                Repository<UserLicenseInfo> orderRepository = new Repository<UserLicenseInfo>("UserId");
                UserLicenseInfo licenseInfo = orderRepository.SelectByKey(userLicenseInfo.UserId.ToString());
                if (licenseInfo == null)
                {
                    orderRepository.Add(userLicenseInfo);
                    userProfileInfo.IsFirstRecord = true;
                }
                else
                {
                    licenseInfo.LicenseName = userLicenseInfo.LicenseName;
                    licenseInfo.LicenseNumber = userLicenseInfo.LicenseNumber;
                    //licenseInfo.LicensingAgency = userLicenseInfo.LicensingAgency;
                    licenseInfo.StateId = userLicenseInfo.StateId;
                    userProfileInfo.IsFirstRecord = false;
                }
                orderRepository.Save();
               // isAdded = true;
            }
            catch { }
            return userProfileInfo;
        }
    }
}
