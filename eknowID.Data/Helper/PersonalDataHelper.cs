using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Implementations;

namespace EknowIDData.Helper
{
    public class PersonalDataHelper
    {
        public static User GetUserDetailsByOrderId(int UserId)
        {
            User user = new User();
            Repository<User> referenceInfoRepository = new Repository<User>("UserId");
            user = referenceInfoRepository.SelectByKey(UserId.ToString());
            return user;
        }
    }
}
