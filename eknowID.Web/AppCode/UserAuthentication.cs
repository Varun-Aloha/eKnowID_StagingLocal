using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EknowIDModel;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;

namespace eknowID.AppCode
{
    public class UserAuthentication
    {
        public static User GetUserByEmailId(string email)
        {
            Repository<User> userRep = new Repository<User>("Email");
            return userRep.SelectByKey(email);
        }

        public static void SaveForgotPassword(User users)
        {
            ForgotPassword forgotPassword = UserAuthentication.GetForgotPasswordByUserID(users.UserId);
            Repository<ForgotPassword> forgotPasswordRep = new Repository<ForgotPassword>();

            if (forgotPassword==null || forgotPassword.IsUsed == true || 24 < DateTime.Now.Subtract(forgotPassword.ForgotDate).TotalHours)
            {
                ForgotPassword forgotPasswordinfo = new ForgotPassword();
                forgotPasswordinfo.UserId = users.UserId;
                forgotPasswordinfo.IsUsed = false;
                forgotPasswordinfo.ForgotDate = DateTime.Now;
                forgotPasswordRep.Add(forgotPasswordinfo);
                forgotPasswordRep.Save();
            }
        }

        public static ForgotPassword GetForgotPasswordByUserID(int userID)
        {
            ISpecification<ForgotPassword> forgotPasswordSpc = new Specification<ForgotPassword>(os => os.UserId == userID);
            IRepository<ForgotPassword> forgotPasswordRep = new Repository<ForgotPassword>();
            ForgotPassword forgotPassword = forgotPasswordRep.SelectAll(forgotPasswordSpc).LastOrDefault();
            return forgotPassword;
        }

        public static ForgotPassword GetForgotPasswordByForgotID(string forgotPasswordId)
        {
            Repository<ForgotPassword> forgotPasswordRep = new Repository<ForgotPassword>("ForgotPasswordId");
            return forgotPasswordRep.SelectByKey(forgotPasswordId);
        }

    }
}