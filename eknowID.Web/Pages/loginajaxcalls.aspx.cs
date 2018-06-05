using eknowID.AppCode;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;
using EknowIDLib;
using EknowIDModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using eknowID.Services;
using EncryptionHelper = eknowID.AppCode.EncryptionHelper;

namespace eknowID.Pages
{
    public partial class loginajaxcalls : BasePage
    {
        public static string LOGIN_FAILED = "LOGIN_FAILED";
        public static string SingupSucessMessage = "User details added successfully.";
        public static string userExist = "Exist";
        public static string userNotExist = "Not Exist";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod()]
        public static LoginResult SignupUser(string FirstName, string MiddleName, string LastName, string EmailAddress, string Password, int? UserType)
        {
            LoginResult loginResult = new LoginResult();
            User user = new User();
            try
            {
                user.FirstName = FirstName.Trim();
                user.MiddleName = MiddleName.Trim();
                user.LastName = LastName.Trim();
                user.Email = EmailAddress.Trim();
                user.Password = EncryptionHelper.Encryptdata(Password);
                user.StateId = 1;
                user.SecQuestionId = 1;
                user.AccountRefId = 1;
                user.UserType = UserType;
                user.CompanyId = SessionWrapper.LoggedUser != null ? SessionWrapper.LoggedUser.CompanyId : null;
                user.IsActive = false;
                user.CreatedDate = DateTime.Now;
                Guid activationCode = CheckIfActivationCodeExist(Guid.NewGuid());
                user.ActivationCode = activationCode;


                Repository<User> userRep = new Repository<User>();
                userRep.Add(user);
                userRep.Save();

                //if (UserType == (int)UserTypeEnum.ADMIN)
                //{
                //    Repository<User> userRepo = new Repository<User>("Email");
                //    SessionWrapper.LoggedUser = userRepo.SelectByKey(EmailAddress);
                //}

                loginResult.Success = false;
                loginResult.Message = "Successfully registered eknowId account for user " + FirstName.Trim() + " " + LastName.Trim() + ", an account activation link sent to email address - " + EmailAddress;

                StringBuilder emailBody = new StringBuilder(ConstructMail.GetMailBody(Constant.REGISTRATION_SUCCESS));
                emailBody = emailBody.Replace(Constant.CONST_FIRSTNAME, user.FirstName);
                emailBody = emailBody.Replace(Constant.CONST_LASTNAME, user.LastName);
                emailBody = emailBody.Replace(Constant.CONST_USEREMAILID, user.Email);
                emailBody = emailBody.Replace(Constant.CONST_USERPASSWORD, Password);
                emailBody = emailBody.Replace("[HOST]", Constant.Host);
                emailBody = emailBody.Replace("[ACTIVATIONCODE]", user.ActivationCode.ToString());

                SendMail.Sendmail(user.Email, Constant.CONST_REGISTRATION_SUBJECT, emailBody.ToString());

                //SendUserActivationEmail(user);
            }
            catch { }
            return loginResult;
        }

        private static void SendUserActivationEmail(User user) {
            StringBuilder emailBody = new StringBuilder(ConstructMail.GetMailBody(Constant.Activate_UserAccount));
            emailBody = emailBody.Replace(Constant.CONST_FIRSTNAME, user.FirstName);
            emailBody = emailBody.Replace(Constant.CONST_LASTNAME, user.LastName);             
            emailBody = emailBody.Replace("[ACTIVATIONCODE]", user.ActivationCode.ToString());
            emailBody = emailBody.Replace("[HOST]", Constant.Host);

            SendMail.Sendmail(user.Email, Constant.CONST_UserActivation_SUBJECT, emailBody.ToString());
        }

        private static Guid CheckIfActivationCodeExist(Guid activationCode) {
            ISpecification<User> useSpc = new Specification<User>(u => u.ActivationCode == activationCode);
            Repository<User> userWithActivation = new Repository<User>();
            IList<User> users = userWithActivation.SelectAll(useSpc);
            if(null != users && 0 < users.Count) {
                CheckIfActivationCodeExist(Guid.NewGuid());
            }
            else {
                return activationCode;
            }
            return activationCode;
        }

        [WebMethod]
        public static LoginResult CheckIfExist(string emailID)
        {
            LoginResult loginResult = new LoginResult();
            ISpecification<User> useSpc = new Specification<User>(u => u.Email == emailID);
            Repository<User> userRep = new Repository<User>();
            IList<User> users = userRep.SelectAll(useSpc);


            if (users == null || users.Count != 1)
            {
                loginResult.Success = false;
                loginResult.Message = userNotExist;
            }
            else
            {
                loginResult.Success = true;
                loginResult.Message = userExist;
            }
            return loginResult;
        }

        [WebMethod]
        public static LoginResult IsUserExistWithProvider(string emailID, string accountType)
        {
            LoginResult loginResult = new LoginResult();
            int accountID = Convert.ToInt32(accountType);
            ISpecification<User> useSpc = new Specification<User>(u => u.Email == emailID && u.AccountRefId == accountID);
            Repository<User> userRep = new Repository<User>();
            IList<User> users = userRep.SelectAll(useSpc);
            if (users == null || users.Count != 1)
            {
                loginResult.Success = false;
                loginResult.Message = userNotExist;
            }
            else
            {
                SessionWrapper.LoggedUser = users[0];
                loginResult.Success = true;
                loginResult.Message = userExist;
            }
            return loginResult;
        }

        [WebMethod]
        public static LoginResult AuthenticateUser(string email, string password)
        {
            ISpecification<User> useSpc = new Specification<User>(u => u.Email == email && u.AccountRefId == 1);
            Repository<User> userRep = new Repository<User>();
            IList<User> users = userRep.SelectAll(useSpc);
            LoginResult logResult = new LoginResult();
            if (users == null || users.Count != 1)
            {
                SessionWrapper.LoggedUser = null;
                logResult.Success = false;
                logResult.Message = "The email and password you entered don't match.";
                return logResult;
            }
            else
            {
                bool isActiveUser = (null == users[0].LastLoginDate || (!(90 < (DateTime.Now - (DateTime)users[0].LastLoginDate).TotalDays)));

                if (isActiveUser)
                {
                    if(!users[0].IsActive ?? true) {
                        logResult.Message = "You have not activated your eKnowId account. Please use the activation link sent to your registered email address OR contact our support team for further help.";
                        logResult.TagData = "Account Disabled";
                        //SendUserActivationEmail(users[0]);
                    }
                    else if (EncryptionHelper.Decryptdata(users[0].Password) == password)
                {
                    SessionWrapper.LoggedUser = users[0];
                    logResult.Success = true;
                        var packageService = new PackageService();

                        packageService.UpdateUserLastLoginDate(users[0].UserId);
                    //Show Linked in or uploaded resume on order details if user sign up. so set null
                    SessionWrapper.LinkedinData = null;
                    SessionWrapper.ResumeParserData = null;

                    return logResult;
                }
                    else
                    {
                        logResult.Message = "Password you entered don't match.";
                    }
                }
                else
                {
                    logResult.Message = "Your account is disabled due to inactivity for 90 or more days. A password reset link has been sent to your email address. Please use the link to reset your password.";
                    logResult.TagData = "Account Disabled";
                    ForgotPassword(email);
                }
                SessionWrapper.LoggedUser = null;
                logResult.Success = false;
                return logResult;
            }
        }

        [WebMethod]
        public static ForgotPasswordInfo ForgotPassword(string email)
        {
            User users = UserAuthentication.GetUserByEmailId(email);
            ForgotPassword forgotPassword;

            ForgotPasswordInfo forgotPasswordInfo = new ForgotPasswordInfo();
            if (users == null)
            {
                forgotPasswordInfo.Success = false;
                forgotPasswordInfo.ErrorMsg = "Email address entered by you is not registered with us. Please enter the valid email address which you use for login.";
                return forgotPasswordInfo;
            }

            UserAuthentication.SaveForgotPassword(users);
            forgotPassword = UserAuthentication.GetForgotPasswordByUserID(users.UserId);
            forgotPasswordInfo.Success = true;
            forgotPasswordInfo.ForgotPasswordId = forgotPassword.ForgotPasswordId;

            StringBuilder emailBody = new StringBuilder(ConstructMail.GetMailBody(Constant.FORGOT_PASSWORD));
            emailBody = emailBody.Replace(Constant.CONST_USERNAME, users.FirstName).Replace(Constant.CONST_FORGOTLINK, forgotPassword.ForgotPasswordId.ToString());
            emailBody = emailBody.Replace(Constant.CONST_FIRSTNAME, users.FirstName);
            emailBody = emailBody.Replace(Constant.CONST_LASTNAME, users.LastName);
            if (!SendMail.Sendmail(email, Constant.CONST_RESETPASSWORD_SUBJECT, emailBody.ToString()))
            {
                forgotPasswordInfo.Success = false;
                forgotPasswordInfo.ErrorMsg = "Error occurred while sending email. Please try again.";
                return forgotPasswordInfo;
            }

            return forgotPasswordInfo;
        }

        [WebMethod]
        public static ForgotPasswordInfo SetForgotPassword(string forgotID, string newPassword)
        {
            ForgotPasswordInfo forgotPasswordInfo = new ForgotPasswordInfo();


            Repository<ForgotPassword> forgotPasswordRep = new Repository<ForgotPassword>("ForgotPasswordId");
            ForgotPassword forgotPassword = forgotPasswordRep.SelectByKey(forgotID.ToString());

            if (forgotPassword.IsUsed == true || 24 < DateTime.Now.Subtract(forgotPassword.ForgotDate).TotalHours)
            {
                forgotPasswordInfo.Success = false;
                return forgotPasswordInfo;
            }

            Repository<User> userRep = new Repository<User>("UserId");
            User users = userRep.SelectByKey(forgotPassword.UserId.ToString());
            if (users != null)
            {
                users.Password = EncryptionHelper.Encryptdata(newPassword);
                users.LastLoginDate = DateTime.Now;
                userRep.Save();

                forgotPassword.IsUsed = true;
                forgotPasswordRep.Save();
            }
            forgotPasswordInfo.Success = true;

            StringBuilder emailBody = new StringBuilder(ConstructMail.GetMailBody(Constant.RESET_PASSWORD));            
            emailBody = emailBody.Replace(Constant.CONST_FIRSTNAME, users.FirstName);
            emailBody = emailBody.Replace(Constant.CONST_LASTNAME, users.LastName);
            emailBody = emailBody.Replace(Constant.CONST_USEREMAILID, users.Email);
            SendMail.Sendmail(users.Email, Constant.CONST_PASSWORD_CHANGE_NOTIFICATION_SUBJECT, emailBody.ToString());
            //sendPasswordChangedNotificationEmail
            return forgotPasswordInfo;
        }

        [WebMethod]
        public static object GetCountyList(int StateId)
        {

            ISpecification<County> specification = new Specification<County>(u => u.StateId == StateId);
            Repository<County> repository = new Repository<County>();
            IList<County> counties = repository.SelectAll(specification);

            var objList = (new[] { new { Text = "Select", Value = 0 } }).ToList();

            foreach (County county in counties)
            {
                objList.Add(new { Text = county.Name, Value = county.CountyId });
            }
            return objList;

        }

        [WebMethod]
        public static object GetDistrictList(int StateId)
        {

            ISpecification<District> specification = new Specification<District>(u => u.StateId == StateId);
            Repository<District> repository = new Repository<District>();
            IList<District> districts = repository.SelectAll(specification);

            var objList = (new[] { new { Text = "Select", Value = 0 } }).ToList();

            foreach (District district in districts)
            {
                objList.Add(new { Text = district.Name, Value = district.DistrictId });
            }
            return objList;
        }

        [WebMethod]
        public static void SendFeebackMail(string emailId, string subject, string message)
        {
            try
            {
                //Send mail to support@eknowid.com
                StringBuilder emailBody = new StringBuilder(ConstructMail.GetMailBody(Constant.FEEDBACK));
                emailBody = emailBody.Replace(Constant.FEEDBACK_USER_MAILID, emailId);
                emailBody = emailBody.Replace(Constant.FEEDBACK_SUBJECT, subject);
                emailBody = emailBody.Replace(Constant.FEEDBACK_COMMENT, message);
                SendMail.Sendmail(Constant.SUPPORT_EKNOWID_MAILID, Constant.FEEDBACK_MAIL_SUBJECT, emailBody.ToString());

                //send mail to user
                emailBody = new StringBuilder(ConstructMail.GetMailBody(Constant.REPLY_TO_FEEDBACK));

                SendMail.Sendmail(emailId, Constant.FEEDBACK_REPLY_MAIL_SUBJECT, emailBody.ToString());
            }
            catch { }

        }

        [WebMethod()]
        public static LoginResult SignupUserWithLinkedIn(string FirstName, string MiddleName, string LastName, string EmailAddress, int accountRefId)
        {
            LoginResult loginResult = new LoginResult();
            loginResult.Success = false;
            try
            {
                User users = UserAuthentication.GetUserByEmailId(EmailAddress);
                if (users == null)
                {
                    User user = new User();
                    user.FirstName = FirstName.Trim();
                    user.MiddleName = MiddleName.Trim();
                    user.LastName = LastName.Trim();
                    user.Email = EmailAddress.Trim();
                    string Password = (Guid.NewGuid().ToString()).Substring(0, 8);
                    user.Password = EncryptionHelper.Encryptdata(Password);
                    //user.StateId = 1;
                    user.SecQuestionId = 1;
                    user.AccountRefId = accountRefId;
                    user.CreatedDate = DateTime.Now;
                    user.IsActive = true;
                    user.UserType = (int)UserTypeEnum.ADMIN;

                    Repository<User> userRep = new Repository<User>();
                    userRep.Add(user);
                    userRep.Save();

                    users = UserAuthentication.GetUserByEmailId(EmailAddress);
                    SessionWrapper.LoggedUser = users;
                    loginResult.Success = true;
                }
                else
                {
                    if (users.AccountRefId == accountRefId)
                    {
                        SessionWrapper.LoggedUser = users;
                        loginResult.Success = true;
                    }
                }

            }
            catch { }

            return loginResult;
        }
    }
}