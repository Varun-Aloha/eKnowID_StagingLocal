using System.Collections.Generic;
using EknowIDModel;
using TazWorksCom.WrapperClasses;
using TazWorksCom.XMLClasses;
using EknowIDData.Helper;
using TazWorksCom.HelperClasses;
using System;
using System.Linq;
using EknowIDLib;


namespace TazWorksCom
{
    public class ConstructRequest
    {
        int _orderId;
        int _userID;
        BackgroundCheck _backgroundCheck;
        BackgroundSearchPackage _backgroundSearchPackage;
        Screenings _screenings;
        List<ScreeningType> list;

        public void GetResponse(int orderId, int userID)
        {
            string parameter = string.Empty;
            string response = string.Empty;
            try
            {

                _orderId = orderId;
                _userID = userID;

                parameter = GetXMLResponse();

                ProcessRequest request = new ProcessRequest();
                response = request.HttpPost(parameter);

                if (!string.IsNullOrEmpty(response))
                {
                    BackgroundReports backgroundReports = (BackgroundReports)SerializationHelper.XmlDeserializeFromString(response, typeof(BackgroundReports));

                    OrderStateWrapper orderStatusWrapper = new OrderStateWrapper(backgroundReports);
                    OrderState orderState = orderStatusWrapper.GetOrderStatus();
                    int orderID = OrderStatusHelper.SaveOrderState(orderState);

                    TransactionLogHelper.SaveError(_orderId, "XmlSend", parameter, response);
                }
                else
                {
                    TransactionLogHelper.SaveError(_orderId, "", parameter, response);
                }
            }
            catch(Exception ex) { TransactionLogHelper.SaveError(_orderId, "", parameter, response + "\t\n exception details: " + ex.Message); }

        }

        public void AddReferenceInfo()
        {
            List<ReferenceInfo> referenceList = ReferenceInfoHelper.GetReferenceInfoListByOrderId(_orderId);

            if (referenceList != null)
            {
                //if (list.Find(type => type.Type == "ReferenceScreening") == null)
                //{
                    for (int i = 0; i < referenceList.Count; i++)
                    {
                        ReferenceScreeningWraper referenceScreeningWrapper = new ReferenceScreeningWraper(referenceList[i]);
                        ReferenceScreening referenceScreening = referenceScreeningWrapper.GetXMLNode();
                        list.Add(referenceScreening);

                    }
                //}
            }
        }

        public void AddEducationalDetails()
        {
            EducationalDetail educationalDetails = EducationalDetailHelper.GetEducationalInfoByOrderId(_orderId);

            if (educationalDetails != null)
            {
                EducationScreeningWrapper educationScreeningWrapper = new EducationScreeningWrapper(educationalDetails);
                    EducationScreening educationScreening = educationScreeningWrapper.GetXMLNode();
                    list.Add(educationScreening);
                PostGraduationDetail postGraduationDetails = EducationalDetailHelper.GetPostGraduationInfoByEducationInfoId(educationalDetails.EducationalDetailId);
                if(postGraduationDetails != null) {
                    EducationalDetail educationalDetail = new EducationalDetail();
                    educationalDetail.Basic = postGraduationDetails.PostGraduation;
                    educationalDetail.EndMonth = postGraduationDetails.EndMonth;
                    educationalDetail.EndYear = postGraduationDetails.EndYear;
                    educationalDetail.IsAttending = postGraduationDetails.IsAttending;
                    educationalDetail.Municipality = postGraduationDetails.Municipality;
                    educationalDetail.Specialization = postGraduationDetails.Specialization;
                    educationalDetail.StartMonth = postGraduationDetails.StartMonth;
                    educationalDetail.StartYear = postGraduationDetails.StartYear;
                    educationalDetail.State = postGraduationDetails.State;
                    educationalDetail.StateId = postGraduationDetails.StateId;
                    educationalDetail.University = postGraduationDetails.University;

                    educationScreeningWrapper = new EducationScreeningWrapper(educationalDetail);
                    educationScreening = educationScreeningWrapper.GetXMLNode();
                    list.Add(educationScreening);
                }
        }
        }

        public void AddLicesnseInfo()
        {
            LicenseInfo licenseInfo = LicenseInfoHelper.GetLicenseInfoByOrderId(_orderId);

            if (licenseInfo != null)
            {
                //if (list.Find(type => type.Type == "LicenseScreening") == null)
                //{
                    LicenseWrapper licenseWrapper = new LicenseWrapper(licenseInfo);
                    LicenseScreening licenseScreening = licenseWrapper.GetLicenseXMLNode();
                    list.Add(licenseScreening);
                //}
            }
        }

        public void AddEmploymentDetails()
        {
            List<EmploymentDetail> empDetailsList = EmploymentDetailsHelper.GetEmpDetailsListByOrderId(_orderId);

            if (empDetailsList != null)
            {
                //if (list.Find(type => type.Type == "EmploymentScreening") == null)
                //{
                    for (int i = 0; i < empDetailsList.Count; i++)
                    {
                        EmploymentWrapper employmentWrapper = new EmploymentWrapper(empDetailsList[i]);
                        EmploymentScreening empScreening = employmentWrapper.GetXMLNode();
                        list.Add(empScreening);
                    }
                //}
            }
        }

        public void AddPersonalData()
        {
            User userDetails = PersonalDataHelper.GetUserDetailsByOrderId(_userID);

            if (userDetails != null)
            {
                PersonalDataWarpper personalDataWrapper = new PersonalDataWarpper(userDetails);
                PersonalData personalData = personalDataWrapper.GetXMLNode();
                _backgroundSearchPackage.PersonalData = personalData;
                _backgroundSearchPackage.ReferenceId = _orderId.ToString();
            }
        }

        public void AddAdditionalTag()
        {
            AdditionalItems items = AdditionalItemsWrapper.AddCredentials();
            _screenings.AdditionalItems.Add(items);
            //list.Add(items);
        }

        public void AddCriminalCheck(List<eknowID.Repositories.AlacartReport> alacartReportList)
        {
            List<int> criminalItems = CriminalCheckHelper.GetCriminalItems(_orderId);
            User userDetails = PersonalDataHelper.GetUserDetailsByOrderId(_userID);

            foreach (int criminalNumber in criminalItems)
            {
                if (criminalNumber == (int)CriminalCheckNumber.COUNTY)
                {
                    AddCountyCriminal(alacartReportList);
                }
                if (criminalNumber == (int)CriminalCheckNumber.FEDERAL)
                {
                    AddFederalCriminal(alacartReportList);
                }
                if (criminalNumber == (int)CriminalCheckNumber.INSTACRIMINAL_MULTISTATE)
                {
                    AddMultiStateCriminal(userDetails);
                }
                if (criminalNumber == (int)CriminalCheckNumber.INSTACRIMINAL_SINGLESTATE)
                {
                    AddSingleStateCriminal(userDetails);
                }
                if (criminalNumber == (int)CriminalCheckNumber.INTERNATIONAL_10)
                {
                    AddInternational10YearCriminal(userDetails);
                }
                if (criminalNumber == (int)CriminalCheckNumber.INTERNATIONAL_7)
                {
                    AddInternational10YearCriminal(userDetails);
                }
                if (criminalNumber == (int)CriminalCheckNumber.INSTANT_STATE)
                {
                    AddStateCriminal(alacartReportList);
                }
            }
        }

        public void AddSSNTag()
        {
            if (SSNHelper.IsSSNIncluded(_orderId))
            {
                SSNScreening ssn = SSNWrapper.AddSocialSecuritySearch();
                list.Add(ssn);
            }
        }

        private void AddAliasReport()
        {
            if (NationalCriminalAliasHelper.IsAliasReportIncluded(_orderId))
            {
                InstaCriminalNationalAlias alias = InstaCriminalNationalAliasWrapper.AddAliasCheck();
                list.Add(alias);
            }
        }

        private void AddCivilSearchReport(List<eknowID.Repositories.AlacartReport> alacartReportsList) {
                        
            if (CivilSearchHelper.IsCivilSearchIncluded(_orderId)) {
                int qty = 1;                              
                string[] states;
                string[] counties;
                GetStates_Counties_DistrictsSelected(alacartReportsList, Constant.CIVIL_SEARCH, ref qty, out states, out counties);
                for (int i = 0; i < qty; i++) {
                    CountyCivilScreening civilSearchScreening = new CountyCivilScreening();
                    //set value
                    civilSearchScreening.Region = (null != states && states.Any() && (i <= states.Count() - 1)) ? states[i] : ""; ;
                    civilSearchScreening.County = (null != counties && counties.Any() && (i <= counties.Count() - 1)) ? counties[i] : ""; ;

                    list.Add(civilSearchScreening);
                }
            }
        }

        private void GetStates_Counties_DistrictsSelected(List<eknowID.Repositories.AlacartReport> alacartReportsList, string searchReportName, ref int qty, out string [] states, out string [] counties_Districts) {
            var searchReport = alacartReportsList.Any(p => p.Report.Name.Equals(searchReportName)) ?
                                       alacartReportsList.Where(p => p.Report.Name.Equals(searchReportName)).FirstOrDefault() : null;
            User userDetails = PersonalDataHelper.GetUserDetailsByOrderId(_userID);
            qty = null != searchReport ? searchReport.Qty : 1;
            char[] options = new char[] { ',' };
            states = (null != searchReport && !string.IsNullOrEmpty(searchReport.StatesSelected)) ?
                    searchReport.StatesSelected.Trim().Split(options) :
                    (null != userDetails ? new string[] { StateHelper.GetStateById(userDetails.StateId).AlphaCode } : new string[] { });
            counties_Districts = (null != searchReport && !string.IsNullOrEmpty(searchReport.Couty_DistrictsSelected)) ?
                                    searchReport.Couty_DistrictsSelected.Trim().Split(options) :
                                    (null != userDetails ? new string[] { userDetails.City ?? "" } : new string[] { });
        }

        private void AddCreditReport()
        {
            if (CreditHelper.IsCreditIncluded(_orderId))
            {
                CreditScreening credit = CreditWrapper.AddCreditReport(); ;
                list.Add(credit);
            }
        }

        public void AddDrugVerification()
        {
            DrugVerificationDetail drugDetails = DrugVerifcationHelper.GetDrugVerification(_orderId);
            if (drugDetails != null)
            {
                DrugVerificationWrapper drug = new DrugVerificationWrapper(drugDetails);
                DrugScreening drugScreening = drug.GetXMLNode();
                list.Add(drugScreening);
            }
        }

        private void AddCountyCriminal(List<eknowID.Repositories.AlacartReport> alacartReportsList)
        {
            
            int qty = 1;
            string[] states;
            string[] counties;
            GetStates_Counties_DistrictsSelected(alacartReportsList, Constant.COUNTY_CRIMINAL_SEARCH, ref qty, out states, out counties);

            for (int i = 0; i < qty; i++) {
                CountyCriminalScreening CountyCriminalScreening = new CountyCriminalScreening();
                //set value
                CountyCriminalScreening.Region = (null != states && states.Any() && (i <= states.Count() - 1)) ? states[i] : ""; ;
                CountyCriminalScreening.County = (null != counties && counties.Any() && (i <= counties.Count() - 1)) ? counties[i] : ""; ;

                list.Add(CountyCriminalScreening);
            }            
        }

        private void AddFederalCriminal(List<eknowID.Repositories.AlacartReport> alacartReportsList)
        {
            int qty = 1;
            string[] states;
            string[] districts;
            GetStates_Counties_DistrictsSelected(alacartReportsList, Constant.FEDERAL_CRIMINAL_SEARCH, ref qty, out states, out districts);

            for (int i = 0; i < qty; i++) {
                FederalCriminalScreening federalCriminalScreening = new FederalCriminalScreening();
                //set value
                federalCriminalScreening.Region = (null != states && states.Any() && (i <= states.Count() - 1)) ? states[i] : ""; ;
                federalCriminalScreening.District = (null != districts && districts.Any() && (i <= districts.Count() - 1)) ? districts[i] : ""; ;

                list.Add(federalCriminalScreening);
            }            
        }

        private void AddStateCriminal(List<eknowID.Repositories.AlacartReport> alacartReportsList) {
            int qty = 1;
            string[] states;
            string[] districts;
            GetStates_Counties_DistrictsSelected(alacartReportsList, Constant.STATE_CRIMINAL_SEARCH, ref qty, out states, out districts);

            for (int i = 0; i < qty; i++) {
                StateCriminalScreening stateCriminalScreening = new StateCriminalScreening();
                //set value
                stateCriminalScreening.Region = (null != states && states.Any() && (i <= states.Count() - 1)) ? states[i] : "";
                list.Add(stateCriminalScreening);
            }
        }

        private void AddSingleStateCriminal(User User)
        {
            CriminalWrapper criminalWrapper = new CriminalWrapper(User);
            InstaCriminalSingleStateScreening singleState = criminalWrapper.GetSingleStateCriminalNode();
            list.Add(singleState);
        }

        private void AddMultiStateCriminal(User User)
        {
            CriminalWrapper criminalWrapper = new CriminalWrapper(User);
            InstaCriminalMultiStateScreening multiStateScreening = criminalWrapper.GetMultiStateCriminalNode();
            list.Add(multiStateScreening);
        }       

        private void AddInternational10YearCriminal(User User)
        {
            CriminalWrapper criminalWrapper = new CriminalWrapper(User);
            InternationalCriminalScreening internationalCriminal = criminalWrapper.GetInternationalCriminalNode();
            list.Add(internationalCriminal);
        }

        private string GetXMLResponse()
        {
            list = new List<ScreeningType>();

            _backgroundCheck = new BackgroundCheck();
            _backgroundSearchPackage = new BackgroundSearchPackage();
            _screenings = new Screenings();
            _screenings.AdditionalItems = new List<AdditionalItems>();

            eknowID.Repositories.IPlanRepository _planRepository = new eknowID.Repositories.PlanRepository();
            var alacartReportList = _planRepository.GetAdditionalAlacartReports(_orderId);

            AddPersonalData();
            AddEducationalDetails();
            AddLicesnseInfo();
            AddReferenceInfo();
            AddEmploymentDetails();
            AddCivilSearchReport(alacartReportList);
            AddCriminalCheck(alacartReportList);
            AddAdditionalTag();
            AddSSNTag();
            AddAliasReport();
            AddCreditReport();
            AddDrugVerification();

            if (list.Count != 0)
            {
                _screenings.Screening = list;
                _backgroundSearchPackage.Screenings = _screenings;
            }

            _backgroundCheck.BackgroundSearchPackage = _backgroundSearchPackage;

            return SerializationHelper.XmlSerializeToString(_backgroundCheck);
        }

        public OrderState XMLStatusEnquiry(int orderId, int userID)
        {
            OrderState orderStateDetails = OrderStatusHelper.GetOrderState(orderId);
            string parameter = GetXMLStatusEnquiry(orderStateDetails.TazWorksOrderId);            

            ProcessRequest request = new ProcessRequest();
            string response = request.HttpPost(parameter);

            OrderState orderState = new OrderState();

            if (!string.IsNullOrEmpty(response))
            {

                BackgroundReports backgroundReports = (BackgroundReports)SerializationHelper.XmlDeserializeFromString(response, typeof(BackgroundReports));

                OrderStateWrapper orderStatusWrapper = new OrderStateWrapper(backgroundReports);

                if (backgroundReports.BackgroundReportPackage.ScreeningStatus.OrderStatus.ToString() != "x:error")
                {
                    orderState = orderStatusWrapper.GetEnquiryOrderStatus(orderId, orderStateDetails.URL);
                    int orderID = OrderStatusHelper.SaveOrderState(orderState);
                }
                else
                {
                    TransactionLogHelper.SaveError(orderId, "Error Occurred", parameter, response);
                }
            }
            else
            {
                TransactionLogHelper.SaveError(orderId, "Error Occurred", parameter, response);
            }

            return orderState;
        }

        private string GetXMLStatusEnquiry(int TazWorksOrderId)
        {
            TazWorksCom.StatusEnqiury.BackgroundCheck _enquiryBackgroundCheck = new TazWorksCom.StatusEnqiury.BackgroundCheck();
            EnquiryBackgroundSearchPackage _enquiryBackgroundSearchPackage = new EnquiryBackgroundSearchPackage();

            _enquiryBackgroundSearchPackage.OrderId = TazWorksOrderId.ToString();
            _enquiryBackgroundCheck.BackgroundSearchPackage = _enquiryBackgroundSearchPackage;

            return SerializationHelper.XmlSerializeToString(_enquiryBackgroundCheck);
        }

        public OrderState XMLStatusEnquiry(int orderId)
        {
            OrderState orderStateDetails = OrderStatusHelper.GetOrderState(orderId);
            string parameter = GetXMLStatusEnquiry(orderStateDetails.TazWorksOrderId);            

            ProcessRequest request = new ProcessRequest();
            string response = request.HttpPost(parameter);

            OrderState orderState = new OrderState();
            if (!string.IsNullOrEmpty(response))
            {
                BackgroundReports backgroundReports = (BackgroundReports)SerializationHelper.XmlDeserializeFromString(response, typeof(BackgroundReports));

                OrderStateWrapper orderStatusWrapper = new OrderStateWrapper(backgroundReports);

                if (backgroundReports.BackgroundReportPackage.ScreeningStatus.OrderStatus.ToString() != "x:error")
                {
                    orderState = orderStatusWrapper.GetEnquiryOrderStatus(orderId, orderStateDetails.URL);
                    int orderID = OrderStatusHelper.SaveOrderState(orderState);

                    TazWorksStatus tazWorksStatus;
                    Enum.TryParse(backgroundReports.BackgroundReportPackage.ScreeningStatus.OrderStatus.Substring(2).ToUpper(), out tazWorksStatus);

                    //UpdateOrderStatus into order Table
                    switch (tazWorksStatus)
                    {
                        case TazWorksStatus.ERROR:
                            OrderStatusHelper.UpdateOrderStatus(orderId, (int)TazWorksStatus.ERROR);
                            break;
                        case TazWorksStatus.FAILED:
                            OrderStatusHelper.UpdateOrderStatus(orderId, (int)TazWorksStatus.FAILED);
                            break;
                        case TazWorksStatus.CANCELED:
                            OrderStatusHelper.UpdateOrderStatus(orderId, (int)TazWorksStatus.CANCELED);
                            break;
                        case TazWorksStatus.COMPLETED:
                            OrderStatusHelper.UpdateOrderStatus(orderId, (int)TazWorksStatus.COMPLETED);
                            break;
                        case TazWorksStatus.READY:
                            OrderStatusHelper.UpdateOrderStatus(orderId, (int)TazWorksStatus.READY);
                            break;
                        case TazWorksStatus.PENDING:
                            OrderStatusHelper.UpdateOrderStatus(orderId, (int)TazWorksStatus.PENDING);
                            break;
                        case TazWorksStatus.APPLICANT_PENDING:
                            OrderStatusHelper.UpdateOrderStatus(orderId, (int)TazWorksStatus.APPLICANT_PENDING);
                            break;
                        case TazWorksStatus.APPLICANT_PROCESS:
                            OrderStatusHelper.UpdateOrderStatus(orderId, (int)TazWorksStatus.APPLICANT_PROCESS);
                            break;
                        case TazWorksStatus.NEW:
                            OrderStatusHelper.UpdateOrderStatus(orderId, (int)TazWorksStatus.NEW);
                            break;
                        case TazWorksStatus.MESSAGE:
                            OrderStatusHelper.UpdateOrderStatus(orderId, (int)TazWorksStatus.MESSAGE);
                            break;

                    }

                }
                else
                {
                    TransactionLogHelper.SaveError(orderId, "Error Occurred", parameter, response);
                }
            }
            else
            {
                TransactionLogHelper.SaveError(orderId, "Error Occurred", parameter, response);
            }
            return orderState;

        }
    }
}
