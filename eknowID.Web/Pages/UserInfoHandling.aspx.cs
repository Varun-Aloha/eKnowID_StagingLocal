using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using EknowIDModel;
using EknowIDModel.UserProfile;
using eknowID.AppCode;
using EknowIDData.Helper;
using EknowIDData.Helper.UserProfileHelper;
using System.Globalization;
using EknowIDLib;

namespace eknowID.Pages
{
    public partial class UserInfoHandling : System.Web.UI.Page
    {      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string AddUserLicenseInfo(string LicenseNumber, string LicenseName, int StateId)
        {
            //bool isAdded = false;string LicensingAgency, 
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            string message = Constant.CONST_LICENSE_INFORMATION_FAILURE;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                UserLicenseInfo userLicenseInfo = new UserLicenseInfo();
                userLicenseInfo.LicenseName = LicenseName.Trim();
                userLicenseInfo.LicenseNumber = LicenseNumber.Trim();
                //userLicenseInfo.LicensingAgency = LicensingAgency.Trim();
                userLicenseInfo.UserId = SessionWrapper.LoggedUser.UserId;
                userLicenseInfo.StateId = StateId;

                userProfileInfo = UserLicenseInfoHelper.SaveUserLicenseInfo(userLicenseInfo);
            }
            catch { }
            if (userProfileInfo.IsFirstRecord)
                message = Constant.CONST_LICENSE_INFORMATION_ADD_SUCCESS;
            else
                message = Constant.CONST_LICENSE_INFORMATION_SUCCESS;
            
            return message;
        }

        [WebMethod]
        public static string AddUserEducationalDetails(string Basic, string Specialization, string University, int StartMonth, int StartYear, int EndMonth, int EndYear, int StateID, string Municipality, bool Attending)
        {
            // DateTime StartDate, DateTime? EndDate,
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            string message = Constant.CONST_EDUCATION_INFORMATION_FAILURE;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                UserEducationalDetail userEducationalDetail = new UserEducationalDetail();
                userEducationalDetail.Basic = Basic.Trim();
                userEducationalDetail.Specialization = Specialization.Trim();
                userEducationalDetail.University = University.Trim();

                userEducationalDetail.StartMonth = StartMonth;
                userEducationalDetail.StartYear = StartYear;
                userEducationalDetail.EndMonth = EndMonth;
                userEducationalDetail.EndYear = EndYear;

                //userEducationalDetail.StartDate = StartDate;
                //userEducationalDetail.EndDate = EndDate;


                userEducationalDetail.StateId = StateID;
                userEducationalDetail.Municipality = Municipality.Trim();
                userEducationalDetail.IsAttending = Attending;
                userEducationalDetail.UserId = SessionWrapper.LoggedUser.UserId;
                userProfileInfo = UserEducationalDetailHelper.SaveUserEducationDetail(userEducationalDetail);

            }
            catch { }
            if (userProfileInfo.IsFirstRecord)
                message = Constant.CONST_EDUCATION_INFORMATION_ADD_SUCCESS;
            else
            message = Constant.CONST_EDUCATION_INFORMATION_SUCCESS;
            return message;
        }

        [WebMethod]
        public static string AddPostGraduationDetails(string PostGraduation, string Specialization, string University, string Municipality, int StateID, int StartMonth, int StartYear, int EndMonth, int EndYear, bool Attending)
        {                    
            // DateTime StartDate, DateTime? EndDate
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            string message = Constant.CONST_EDUCATION_INFORMATION_FAILURE;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                UserPostGraduation userPost = new UserPostGraduation();
                
                userPost.PostGraduation = PostGraduation.Trim();
                userPost.Specialization = Specialization.Trim();
                userPost.University = University.Trim();
                userPost.Municipality = Municipality.Trim();
                userPost.StateId = StateID;

                userPost.StartMonth = StartMonth;
                userPost.StartYear = StartYear;
                userPost.EndMonth = EndMonth;
                userPost.EndYear = EndYear;

                //userPost.StartDate = StartDate;
                //userPost.EndDate = EndDate;
                userPost.IsAttending = Attending;
                userPost.UserId = SessionWrapper.LoggedUser.UserId;

                userProfileInfo = UserEducationalDetailHelper.SaveUserPostGraduation(userPost); ;
            }
            catch { }
            if (userProfileInfo.IsFirstRecord)
                message = Constant.CONST_EDUCATION_INFORMATION_ADD_SUCCESS;
            else
                message = Constant.CONST_EDUCATION_INFORMATION_SUCCESS;
           
            return message;
        }

        [WebMethod]
        public static string AddEmploymentDetails(string[] OrganizationName, string[] City, int[] StateId, string[] TelephoneNumber, string[] PositionTitle, string[] Description, int[] StartMonth, int[] StartYear, int[] EndMonth, int[] EndYear, string[] IsAttending)
        {
            // DateTime[] StartDate, DateTime?[] EndDate,
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            string message = Constant.CONST_PROFESSIONAL_EXP_FAILURE;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                List<UserEmploymentDetail> empDetailList = new List<UserEmploymentDetail>();
                UserEmploymentDetail empDetails;
                int count = 0;
                while (count < OrganizationName.Length)
                {
                    if (!String.IsNullOrEmpty(OrganizationName[count]))
                    {
                        empDetails = new UserEmploymentDetail();
                        empDetails.OrgName = OrganizationName[count].Trim();
                        empDetails.City = City[count].Trim();
                        empDetails.Telephone = TelephoneNumber[count].Trim();
                        empDetails.StateId = StateId[count];
                        empDetails.PositionTitle = PositionTitle[count].Trim();


                        empDetails.StartMonth = StartMonth[count];
                        empDetails.StartYear = StartYear[count];
                        empDetails.EndMonth = EndMonth[count];
                        empDetails.EndYear = EndYear[count];

                        empDetails.Description = Description[count].Trim();
                        empDetails.IsAttending = Convert.ToBoolean(IsAttending[count]);

                        empDetails.UserId = SessionWrapper.LoggedUser.UserId;
                        empDetailList.Add(empDetails);
                    }
                    count++;
                }
                userProfileInfo = UserEmploymentDetailsHelper.SaveUserEmpDetails(empDetailList);
            }
            catch { }
            if (userProfileInfo.IsFirstRecord)
                message = Constant.CONST_PROFESSIONAL_ADD_SUCCESS;
          else
                message = Constant.CONST_PROFESSIONAL_EXP_SUCCESS;
            
            return message;
        }

        [WebMethod]
        public static string AddUserSkill(string[] Skills, string[] LanuagesKnown)
        {
           
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            string message = Constant.CONST_SKILL_INFORMATION_FAILURE;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            int count = 0;
            
            try
            {

                UserSkill userSkill = new UserSkill();
                userSkill.UserId = SessionWrapper.LoggedUser.UserId;

                userSkill.UserAdditionalSkills = new List<UserAdditionalSkill>();
                UserAdditionalSkill userAdditional;
                while (count < Skills.Length)
                {
                    if (!String.IsNullOrEmpty(Skills[count]))
                    {
                        userAdditional = new UserAdditionalSkill();
                        userAdditional.Skill = Skills[count].Trim();
                        userSkill.UserAdditionalSkills.Add(userAdditional);
                    }
                    count++;
                }


                userSkill.UserLanuagesKnowns = new List<UserLanuagesKnown>();
                UserLanuagesKnown userLanguages;
                count = 0;
                while (count < LanuagesKnown.Length)
                {
                    if (!String.IsNullOrEmpty(LanuagesKnown[count]))
                    {
                        userLanguages = new UserLanuagesKnown();
                        userLanguages.Lanuage = LanuagesKnown[count].Trim();
                        userSkill.UserLanuagesKnowns.Add(userLanguages);
                    }
                    count++;
                }
                userProfileInfo = UserSkillHelper.SaveUserSkill(userSkill);
            }
            catch { }

            if (userProfileInfo.IsFirstRecord)            
                message = Constant.CONST_SKILL_ADD_SUCCESS;
            else
            message = Constant.CONST_SKILL_SUCCESS;
           
            return message;
        }

        [WebMethod]
        public static string UpdateUserDetails(string FirstName, string MiddleName, string LastName, string EmailAddress, string Mobile,string Identification, string Gender, string Month, string Day, string Year, string Password, string Address1, string Address2, string City, int StateId, string Zip)
        {
            bool isUpdated = false;
            string message = Constant.CONST_PROFILE_DETAILS_FAILURE;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                User user = new User();
                user.UserId = SessionWrapper.LoggedUser.UserId;
                user.FirstName = FirstName.Trim();
                user.MiddleName = MiddleName.Trim();
                user.LastName = LastName.Trim();
                user.Email = EmailAddress.Trim();
                user.CellPhone = Mobile.Trim();
                user.IdentificationValue = EncryptionHelper.Encryptdata(Identification.Trim());
                user.Gender = Convert.ToBoolean(Gender);                                
                //user.Birthday = DateTime.ParseExact(Birthday, "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                user.Birthday = Month + "-" + Day + "-" + Year;
                user.Password = EncryptionHelper.Encryptdata(Password);
                user.Address1 = Address1.Trim();
                user.Address2 = Address2.Trim();
                user.City = City.Trim();
                user.StateId = StateId;
                user.Zip = Zip.Trim();
                isUpdated = UserHelper.UpdateUserDetails(user);
            }
            catch { }
            if (isUpdated)
            {
                message = Constant.CONST_PROFILE_DETAILS_SUCCESS;
            }         
            return message;
        }

        [WebMethod]
        public static string AddReferenceInfo(string[] Name, string[] Relationship, string[] MobileNo, string[] YearsKnown, string[] RefType)
        {
            //bool isAdded = false;
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            string message = Constant.CONST_REFERENCE_INFORMATION_FAILURE;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            int count = 0;
            try
            {
                List<UserReferenceInfo> userReferences = new List<UserReferenceInfo>();
                UserReferenceInfo userReference;

                int referenceTypeId;
                count = 0;
                while (count < Name.Length)
                {
                    if (!String.IsNullOrEmpty(Name[count]))
                    {
                        userReference = new UserReferenceInfo();
                        referenceTypeId = ReferenceTypeHelper.GetReferenceTypeIdByName(RefType[count]);
                        userReference.Name = Name[count].Trim();
                        userReference.Relationship = Relationship[count].Trim();
                        userReference.MobileNumber = MobileNo[count].Trim();
                        userReference.YearsKnown = YearsKnown[count].Trim();
                        userReference.ReferenceTypeId = referenceTypeId;
                        userReference.UserId = SessionWrapper.LoggedUser.UserId;

                        userReferences.Add(userReference);
                    }

                    count++;
                }
                userProfileInfo = UserReferenceInfoHelper.SaveUserReferenceInfo(userReferences);
            }
            catch { }
            if (userProfileInfo.IsFirstRecord)
                message = Constant.CONST_REFERENCE_INFORMATION_ADD_SUCCESS;
            else
                message = Constant.CONST_REFERENCE_INFORMATION_SUCCESS;

            return message;
        }

        [WebMethod]
        public static string DeleteReferenceInformationById(int ReferenceInformationId)
        {
            bool isDeleted = false;
            string message = string.Empty;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                isDeleted = UserReferenceInfoHelper.DeleteUserReference(ReferenceInformationId);
            }
            catch { }

            if (isDeleted)
            {
                message = Constant.CONST_REFERENCE_INFORMATION_DELETE_SUCCESS;
            }
            return message;
        }

        [WebMethod]
        public static string DeleteAdditionalSkillById(int AdditionalSkillId)
        {
            bool isDeleted = false;
            string message = string.Empty;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                isDeleted = UserSkillHelper.DeleteUserSkill(AdditionalSkillId);
            }
            catch { }
            if (isDeleted)
            {
                message = Constant.CONST_SKILL_DELETE_SUCCESS;
            }

            return message;
        }

        [WebMethod]
        public static string DeleteLanguagesKnownById(int LanguagesKnownId)
        {
            bool isDeleted = false;
            string message = string.Empty;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                isDeleted = UserSkillHelper.DeleteUserLanuages(LanguagesKnownId);
            }
            catch { }
            if (isDeleted)
            {
                message = Constant.CONST_LANGUAGE_DELETE_SUCCESS;
            }
            return message;
        }

        [WebMethod]
        public static string DeleteEmpDetailsById(int EmpDetailsId)
        {
            bool isDeleted = false;
            string message = string.Empty;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                isDeleted = UserEmploymentDetailsHelper.DeleteEmpDetailsById(EmpDetailsId);
            }
            catch { }

            if (isDeleted)
            {
                message = Constant.CONST_PROFESSIONAL_EXP_DELETE_SUCCESS;
            }
            return message;
        }       

        [WebMethod]
        public static string DeletePostGradById(int PostGraduationId)
        {
            bool isDeleted = false;
            string message = string.Empty;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                isDeleted = UserEducationalDetailHelper.DeletePostGradById(PostGraduationId);
            }
            catch{}
            if (isDeleted)
            {
                message = Constant.CONST_EDUCATION_INFORMATION_DELETE_SUCCESS;
            }
            return message;
        }

        [WebMethod]
        public static List<int> GetReferenceIdList()
        {
           return  UserReferenceInfoHelper.GetReferenceIdList(SessionWrapper.LoggedUser.UserId);            
        }

        [WebMethod]
        public static List<int> GetProfessionalIdList()
        {
            return UserEmploymentDetailsHelper.GetProfessionalIdList(SessionWrapper.LoggedUser.UserId);
        }

        [WebMethod]
        public static List<int>[] GetSkillIdList()
        {           
            return UserSkillHelper.GetSkillIdList(SessionWrapper.LoggedUser.UserId);
        }

        [WebMethod]
        public static int GetPostGraduationIdList()
        {
            return UserEducationalDetailHelper.GetPostGraduationId(SessionWrapper.LoggedUser.UserId);
        }

        private static OrderDetails GetSessionOrderDetails()
        {
            OrderDetails orderDetails = SessionWrapper.OrderDetail;
            if (orderDetails == null)
            {
                orderDetails = new OrderDetails();
            }
            return orderDetails;
        }

        [WebMethod]
        public static SessionExpired CheckIfSessionIsValid()
        {
            SessionExpired sessionexpired = new SessionExpired();
            sessionexpired.IsValid = true;
            if (SessionWrapper.LoggedUser == null)
            {
                sessionexpired.IsValid = false;
                      
            }
            return sessionexpired;
        }
    }
}