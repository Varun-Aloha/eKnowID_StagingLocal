using System;
using System.Collections.Generic;
using System.Web.Services;
using EknowIDModel;
using EknowIDData.Helper;
using TazWorksCom.HelperClasses;
using EknowIDModel.UserProfile;
using EknowIDData.Helper.UserProfileHelper;
using EknowIDLib;
using eknowID.AppCode;

namespace eknowID.Pages
{
    public partial class orderHandling : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string AddEducationalDetails(string Basic, string Specialization, string University, int StartMonth, int StartYear, int EndMonth, int EndYear, int StateID, string Municipality, bool Attending)
        {
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            string message = Constant.CONST_EDUCATION_INFORMATION_FAILURE;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                UserEducationalDetail userEducation = new UserEducationalDetail();
                OrderDetails orderDetails = GetSessionOrderDetails();
                EducationalDetail educationalDetail = new EducationalDetail();

                educationalDetail.Basic = Basic.Trim();
                educationalDetail.Specialization = Specialization.Trim();
                educationalDetail.University = University.Trim();
                educationalDetail.StartMonth = StartMonth;
                educationalDetail.StartYear = StartYear;
                educationalDetail.EndMonth = EndMonth;
                educationalDetail.EndYear = EndYear;
                educationalDetail.StateId = StateID;
                educationalDetail.Municipality = Municipality.Trim();
                educationalDetail.IsAttending = Attending;
                orderDetails.EducationalDetail = educationalDetail;
                SessionWrapper.OrderDetail = orderDetails;

                userEducation.Basic = Basic.Trim();
                userEducation.Specialization = Specialization.Trim();
                userEducation.University = University.Trim();
                userEducation.StartMonth = StartMonth;
                userEducation.StartYear = StartYear;
                userEducation.EndMonth = EndMonth;
                userEducation.EndYear = EndYear;
                userEducation.StateId = StateID;
                userEducation.Municipality = Municipality.Trim();
                userEducation.IsAttending = Attending;
                userEducation.UserId = SessionWrapper.LoggedUser.UserId;

                userProfileInfo = UserEducationalDetailHelper.SaveUserEducationDetail(userEducation);

                if (userProfileInfo.IsFirstRecord)
                {
                    message = Constant.CONST_EDUCATION_INFORMATION_ADD_SUCCESS;
                }
                else
                {
                    message = Constant.CONST_EDUCATION_INFORMATION_SUCCESS;
                }

            }
            catch { }
            return message;
        }

        [WebMethod]
        public static string AddPostGraduationDetails(string PostGraduation, string Specialization, string University, string Municipality, int StateID, int StartMonth, int StartYear, int EndMonth, int EndYear, bool Attending)
        {
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            string message = Constant.CONST_EDUCATION_INFORMATION_FAILURE;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                OrderDetails orderDetails = GetSessionOrderDetails();
                PostGraduationDetail postGraduationDetails = new PostGraduationDetail();

                UserPostGraduation userPostGraduation;

                postGraduationDetails.PostGraduation = PostGraduation.Trim();
                postGraduationDetails.Specialization = Specialization.Trim();
                postGraduationDetails.University = University.Trim();
                postGraduationDetails.Municipality = Specialization.Trim();
                postGraduationDetails.StateId = StateID;
                postGraduationDetails.StartMonth = StartMonth;
                postGraduationDetails.StartYear = StartYear;
                postGraduationDetails.EndMonth = EndMonth;
                postGraduationDetails.EndYear = EndYear;
                postGraduationDetails.IsAttending = Attending;

                orderDetails.EducationalDetail.PostGraduationDetails = new List<PostGraduationDetail>();
                orderDetails.EducationalDetail.PostGraduationDetails.Add(postGraduationDetails);

                userPostGraduation = new UserPostGraduation();

                userPostGraduation.PostGraduation = PostGraduation.Trim();
                userPostGraduation.Specialization = Specialization.Trim();
                userPostGraduation.University = University.Trim();
                userPostGraduation.Municipality = Specialization.Trim();
                userPostGraduation.StateId = StateID;
                userPostGraduation.StartMonth = StartMonth;
                userPostGraduation.StartYear = StartYear;
                userPostGraduation.EndMonth = EndMonth;
                userPostGraduation.EndYear = EndYear;
                userPostGraduation.IsAttending = Attending;

                userPostGraduation.UserId = SessionWrapper.LoggedUser.UserId;

                userProfileInfo = UserEducationalDetailHelper.SaveUserPostGraduation(userPostGraduation);


                if (userProfileInfo.IsFirstRecord)
                {
                    message = Constant.CONST_EDUCATION_INFORMATION_ADD_SUCCESS;
                }
                else
                {
                    message = Constant.CONST_EDUCATION_INFORMATION_SUCCESS;
                }
            }
            catch { }
            return message;
        }

        [WebMethod]
        public static string AddLicenseInfo(string LicenseNumber, string LicenseName, int StateID)
        {
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            string message = Constant.CONST_LICENSE_INFORMATION_FAILURE;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }

            try
            {
                UserLicenseInfo userLicense = new UserLicenseInfo();

                OrderDetails orderDetails = GetSessionOrderDetails();
                LicenseInfo licenseInfo = new LicenseInfo();

                licenseInfo.LicenseName = LicenseName.Trim();
                licenseInfo.LicenseNumber = LicenseNumber.Trim();
                licenseInfo.StateId = StateID;

                orderDetails.LicenseInfo = licenseInfo;
                SessionWrapper.OrderDetail = orderDetails;

                //userLicense = new UserLicenseInfo();

                userLicense.LicenseName = LicenseName.Trim();
                userLicense.LicenseNumber = LicenseNumber.Trim();
                userLicense.StateId = StateID;
                userLicense.UserId = SessionWrapper.LoggedUser.UserId;

                userProfileInfo = UserLicenseInfoHelper.SaveUserLicenseInfo(userLicense);

                if (userProfileInfo.IsFirstRecord)
                {
                    message = Constant.CONST_LICENSE_INFORMATION_ADD_SUCCESS;
                }
                else
                {
                    message = Constant.CONST_LICENSE_INFORMATION_SUCCESS;
                }

            }
            catch { }
            return message;
        }

        [WebMethod]
        public static string AddReferenceInfo(string[] Name, string[] Relationship, string[] MobileNo, string[] YearsKnown, string[] RefType)
        {
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            string message = Constant.CONST_REFERENCE_INFORMATION_FAILURE;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                List<UserReferenceInfo> userReferences = new List<UserReferenceInfo>();
                UserReferenceInfo userReference;

                OrderDetails orderDetails = GetSessionOrderDetails();
                ReferenceInfo referenceInfo;
                int referenceTypeId;
                orderDetails.ReferenceInfoes = new List<ReferenceInfo>();
                //get reference type id from stringint 
                int count = 0;
                while (count < Name.Length)
                {
                    referenceTypeId = ReferenceTypeHelper.GetReferenceTypeIdByName(RefType[count]);

                    referenceInfo = new ReferenceInfo();
                    userReference = new UserReferenceInfo();

                    referenceInfo.ReferenceTypeId = referenceTypeId;
                    referenceInfo.Name = Name[count].Trim();
                    referenceInfo.Relationship = Relationship[count].Trim();
                    referenceInfo.MobileNumber = MobileNo[count].Trim();
                    referenceInfo.YearsKnown = YearsKnown[count].Trim();

                    orderDetails.ReferenceInfoes.Add(referenceInfo);

                    userReference.ReferenceTypeId = referenceTypeId;
                    userReference.Name = Name[count].Trim();
                    userReference.Relationship = Relationship[count].Trim();
                    userReference.MobileNumber = MobileNo[count].Trim();
                    userReference.YearsKnown = YearsKnown[count].Trim();
                    userReference.UserId = SessionWrapper.LoggedUser.UserId;

                    userReferences.Add(userReference);

                    count++;
                }
                SessionWrapper.OrderDetail = orderDetails;

                if (userReferences.Count != 0)
                {
                    userProfileInfo = UserReferenceInfoHelper.SaveUserReferenceInfo(userReferences);

                    if (userProfileInfo.IsFirstRecord)
                    {
                        message = Constant.CONST_REFERENCE_INFORMATION_ADD_SUCCESS;
                    }
                    else
                    {
                        message = Constant.CONST_REFERENCE_INFORMATION_SUCCESS;
                    }
                }
                else
                {
                    message = Constant.CONST_REFERENCE_INFORMATION_ADD_SUCCESS;
                }
            }
            catch { }
            return message;
        }

        [WebMethod]
        public static string AddEmploymentDetails(string[] OrganizationName, string[] City, int[] StateId, string[] TelephoneNumber, string[] PositionTitle, string[] Description, int[] StartMonth, int[] StartYear, int[] EndMonth, int[] EndYear, string[] IsAttending)
        {
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            string message = Constant.CONST_PROFESSIONAL_EXP_FAILURE;
            if (SessionWrapper.LoggedUser == null)
            {
                return message = Constant.SESSION_EXPIRE;
            }
            try
            {
                List<UserEmploymentDetail> userEmpDetails = new List<UserEmploymentDetail>();
                UserEmploymentDetail userEmpDetail;
                OrderDetails orderDetails = GetSessionOrderDetails();
                orderDetails.EmploymentDetailes = new List<EmploymentDetail>();
                EmploymentDetail empDetails;
                List<EmploymentDetail> EmployeeDateGapCheck = new List<EmploymentDetail>();
                int count = 0;

                while (count < OrganizationName.Length)
                {
                    empDetails = new EmploymentDetail();
                    userEmpDetail = new UserEmploymentDetail();

                    empDetails.OrgName = OrganizationName[count].Trim();
                    empDetails.City = City[count].Trim();
                    empDetails.Telephone = TelephoneNumber[count].Trim();
                    empDetails.StateId = StateId[count];
                    empDetails.PositionTitle = PositionTitle[count].Trim();

                    empDetails.StartMonth = StartMonth[count];
                    empDetails.StartYear = StartYear[count];
                    empDetails.EndMonth = EndMonth[count];
                    empDetails.EndYear = EndYear[count];
                    empDetails.IsAttending = Convert.ToBoolean(IsAttending[count]);
                    empDetails.Description = Description[count].Trim();

                    userEmpDetail.OrgName = OrganizationName[count].Trim();
                    userEmpDetail.City = City[count].Trim();
                    userEmpDetail.Telephone = TelephoneNumber[count].Trim();
                    userEmpDetail.StateId = StateId[count];
                    userEmpDetail.PositionTitle = PositionTitle[count].Trim();

                    userEmpDetail.StartMonth = StartMonth[count];
                    userEmpDetail.StartYear = StartYear[count];
                    userEmpDetail.EndMonth = EndMonth[count];
                    userEmpDetail.EndYear = EndYear[count];

                    userEmpDetail.Description = Description[count].Trim();
                    userEmpDetail.IsAttending = Convert.ToBoolean(IsAttending[count]);
                    userEmpDetail.UserId = SessionWrapper.LoggedUser.UserId;

                    userEmpDetails.Add(userEmpDetail);
                    orderDetails.EmploymentDetailes.Add(empDetails);

                    empDetails.EmploymentDetailId = count;

                    string month = empDetails.StartMonth != 0 ? empDetails.StartMonth.ToString("00") : "01";
                    string year = empDetails.StartYear != 0 ? empDetails.StartYear.ToString(): "1900";
                    string startDate = "01/" + month + "/" + year;
                    DateTime StartDate = DateTime.ParseExact(startDate, "MM/dd/yyyy", null);
                    empDetails.StartDate = StartDate;

                    month = empDetails.EndMonth != 0 ? empDetails.EndMonth.ToString("00") : "01";
                    year = empDetails.EndYear != 0 ? empDetails.EndYear.ToString() : "1900";
                    string endDate = "01/" + month + "/" + year;
                    DateTime EndDate = DateTime.ParseExact(endDate, "MM/dd/yyyy", null);
                    empDetails.EndDate = EndDate;

                    EmployeeDateGapCheck.Add(empDetails);
                    count++;
                }

                SessionWrapper.OrderDetail = orderDetails;
                if (userEmpDetails.Count != 0)
                {
                    userProfileInfo = UserEmploymentDetailsHelper.SaveUserEmpDetails(userEmpDetails);
                    if (userProfileInfo.IsFirstRecord)
                    {
                        message = Constant.CONST_PROFESSIONAL_ADD_SUCCESS;
                    }
                    else
                    {
                        message = Constant.CONST_PROFESSIONAL_EXP_SUCCESS;
                    }
                }
                else
                {
                    message = Constant.CONST_PROFESSIONAL_ADD_SUCCESS;
                }               
            }
            catch { }
            return message;
        }

        [WebMethod]
        public static bool AddDrugDetails(int drugVerificationId)
        {
            bool isAdded = false;
            try
            {
                OrderDetails orderDetails = GetSessionOrderDetails();
                DrugVerificationDetail drugDetail = new DrugVerificationDetail();
                drugDetail.DrugVerificationId = drugVerificationId;
                orderDetails.DrugVerificationDetail = drugDetail;
                isAdded = true;
            }
            catch { }
            return isAdded;
        }

        [WebMethod]
        public static OrderState GetOrderStatus(int OrderId)
        {
            OrderState orderStateret = new OrderState();
            try
            {
                OrderStateHelper orderStateHelper = new OrderStateHelper();                
                OrderState orderState = OrderStatusHelper.GetOrderState(OrderId);
                orderStateret.InsertTime = orderState.InsertTime;
                orderStateret.OrderId = orderState.OrderId;
                if (String.IsNullOrEmpty(orderState.URL))
                {
                    orderStateret.URL = "../Htmls/DataLoading.htm";
                }
                else
                {
                    orderStateret.URL = orderState.URL;
                }
                orderStateret.TazWorksStatus = orderState.TazWorksStatus;
                if (orderState.TazWorksStatus != 4)
                {
                    orderStateHelper.saveOrderStatusEnquiryAsync(OrderId, SessionWrapper.LoggedUser.UserId);
                    orderStateret.TazWorksOrderId = 2;
                }
                orderStateret.OrderId = orderState.OrderId;
                SessionWrapper.orderStatusID = orderState.OrderStatusId;
                string str = (((TazWorksStatus)orderState.TazWorksStatus).ToString());
                orderStateret.xmlRequestStatus = str;
            }
            catch { }

            return orderStateret;
        }

        [WebMethod]
        public static OrderState GetPendingOrderEnquiryDetails(int OrderId)
        {
            OrderState orderStateret = new OrderState();
            try
            {
                OrderState orderState = OrderStatusHelper.GetOrderState(OrderId);
                if (orderState.OrderStatusId >= SessionWrapper.orderStatusID)
                {
                    orderStateret.OrderId = orderState.OrderId;
                    if (String.IsNullOrEmpty(orderState.URL))
                    {
                        orderStateret.URL = "../Htmls/OrderInProgress.htm";
                    }
                    else
                    {
                        orderStateret.URL = orderState.URL;
                    }

                    orderStateret.TazWorksOrderId = 1;
                    string str = (((TazWorksStatus)orderState.TazWorksStatus).ToString());
                    orderStateret.xmlRequestStatus = str;
                }
            }
            catch { }
            return orderStateret;
        }

        [WebMethod]
        public static string IsOrderValid()
        {
            string isValid = "valid";
            OrderDetails orderDetails = GetSessionOrderDetails();


            if (string.IsNullOrEmpty(SessionWrapper.LoggedUser.Zip))
            {
                string zip = UserHelper.GetUserById(SessionWrapper.LoggedUser.UserId).Zip;

                if (string.IsNullOrEmpty(zip))
                {
                    isValid = "Contact";
                    return isValid;
                }
            }

            if (SessionWrapper.RequiredInformation.isEmploymentDetailsRequired)
            {
                if (orderDetails.EmploymentDetailes == null)
                {
                    isValid = "emp";
                    return isValid;
                }
            }
            if (SessionWrapper.RequiredInformation.isEducationDetailsRequired)
            {
                if (orderDetails.EducationalDetail == null)
                {
                    isValid = "edu";
                    return isValid;
                }
            }
            if (SessionWrapper.RequiredInformation.isLicenseInformationRequired)
            {
                if (orderDetails.LicenseInfo == null)
                {
                    isValid = "lic";
                    return isValid;
                }
            }
            if (SessionWrapper.RequiredInformation.isReferenceInformationRequired)
            {
                if (orderDetails.ReferenceInfoes == null)
                {
                    isValid = "ref";
                    return isValid;
                }
            }

            return isValid;
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
        public static ValidationFormat GetRegularExpressionByStateId(int StateId)
        {
            int validationRuleId = StateHelper.GetStateById(StateId).ValidationRuleId.Value;

            ValidationRule validationRule = LicenseValidationHelper.GetValidationRuleById(validationRuleId);
            ValidationFormat validationFormat = new ValidationFormat();

            validationFormat.RegularExpression = validationRule.RegularExpression;
            validationFormat.IsSSN = validationRule.IsSSN;
            validationFormat.IsUserLoggedIn = false;
            validationFormat.SSN = string.Empty;
            validationFormat.ErrorMessage = validationRule.Description;

            if (SessionWrapper.LoggedUser != null)
            {
                validationFormat.IsUserLoggedIn = true;

                User user = UserHelper.GetUserById(SessionWrapper.LoggedUser.UserId);

                if (validationFormat.IsSSN)
                {
                    if (!string.IsNullOrEmpty(user.IdentificationValue))
                    {
                        validationFormat.SSN = EncryptionHelper.Decryptdata(user.IdentificationValue);
                    }
                }

                if (validationRule.IsLastCharcter)
                {
                    validationFormat.RegularExpression = validationFormat.RegularExpression.Replace("[a-zA-Z]", user.LastName[0].ToString());
                }

            }
            return validationFormat;
        }

        [WebMethod]
        public static List<string> GetIncludeReportList(int OrderId)
        {
            List<string> lstReport = new List<string>();
            try
            {
                lstReport = OrderStatusHelper.GetReportList(OrderId);
                lstReport.Sort();
            }
            catch { }

            return lstReport;
        }

        [WebMethod]
        public static string UpdateUserDetails(string FirstName, string MiddleName, string LastName, string EmailAddress, string Mobile, string Identification, string Gender, string Month, string Day, string Year, string Address1, string Address2, string City, int StateId, string Zip)
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

                if (Identification.Trim() == Constant.CONST_DEFAULT_SSN)
                    user.IdentificationValue = string.Empty;
                else
                user.IdentificationValue = EncryptionHelper.Encryptdata(Identification.Trim());

                user.Gender = Convert.ToBoolean(Gender);
                //user.Birthday = DateTime.ParseExact(Birthday, "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);                
                user.Address1 = Address1.Trim();
                user.Address2 = Address2.Trim();
                user.City = City.Trim();
                user.StateId = StateId;
                user.Zip = Zip.Trim();
                user.Birthday = Month + "-" + Day + "-" + Year;
                isUpdated = UserHelper.UpdateUserDetails(user);
            }
            catch { }
            if (isUpdated)
            {
                message = Constant.CONST_PROFILE_DETAILS_SUCCESS;
            }
            return message;
        }

        //Set Spell Error Checking text
        [WebMethod]
        public static void SetSpellErrorData(string spellCheckText)
        {
            try
            {
                SessionWrapper.ResumeRuleCheck.SpellCheckInput = SessionWrapper.ResumeRuleCheck.SpellCheckInput + spellCheckText;
            }
            catch { }
        }       
    }
}