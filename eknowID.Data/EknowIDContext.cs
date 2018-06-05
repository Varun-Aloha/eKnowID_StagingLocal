using eknowID.Model;
using EknowIDModel;
using EknowIDModel.UserProfile;
using System.Data.Objects;

namespace EknowIDData
{
    public class EknowIDContext : ObjectContext
    {
        public EknowIDContext()
            : base("name=EknowIDEntities", "EknowIDEntities")
        {
            _plans = CreateObjectSet<Plan>();
            _professions = CreateObjectSet<Profession>();
            _reports = CreateObjectSet<Report>();
            _users = CreateObjectSet<User>();
            _states = CreateObjectSet<State>();
            _stateCriminalCourtFees = CreateObjectSet<StateCriminalCourtFee>();
            _stateCountyCourtFees = CreateObjectSet<StateCountyCourtFee>();
            _stateDistrictCourtFees = CreateObjectSet<StateDistrictCourtFee>();
            _accountRefs = CreateObjectSet<AccountRef>();
            _professionReports = CreateObjectSet<ProfessionReport>();
            _professionPlans = CreateObjectSet<ProfessionPlan>();
            _planReports = CreateObjectSet<PlanReport>();
            _secQuestions = CreateObjectSet<SecQuestion>();
            _identificationTypes = CreateObjectSet<IdentificationType>();
            _referenceInfoes = CreateObjectSet<ReferenceInfo>();
            _licenseInfoes = CreateObjectSet<LicenseInfo>();
            _educationalDetails = CreateObjectSet<EducationalDetail>();
            _orders = CreateObjectSet<Order>();
            _OrderAdditionalCharges = CreateObjectSet<OrderAdditionalCharge>();
            _orderOptReports = CreateObjectSet<OrderOptReport>();
            _coupons = CreateObjectSet<Coupon>();
            _couponDiscountTypes = CreateObjectSet<CouponDiscountType>();
            _referenceTypes = CreateObjectSet<ReferenceType>();
            _orderStates = CreateObjectSet<OrderState>();
            _userEducationDetails = CreateObjectSet<UserEducationalDetail>();
            _userLicenseInfoes = CreateObjectSet<UserLicenseInfo>();
            _userSkills = CreateObjectSet<UserSkill>();
            _userAdditionalSkills = CreateObjectSet<UserAdditionalSkill>();
            _userLanuagesKnown = CreateObjectSet<UserLanuagesKnown>();
            _userReferenceInfoes = CreateObjectSet<UserReferenceInfo>();
            _cardLists = CreateObjectSet<CardList>();
            _employmentDetails = CreateObjectSet<EmploymentDetail>();
            _userEmploymentDetails = CreateObjectSet<UserEmploymentDetail>();
            _postGraduationDetails = CreateObjectSet<PostGraduationDetail>();
            _userPostGraduationDetails = CreateObjectSet<UserPostGraduation>();
            _forgotPassword = CreateObjectSet<ForgotPassword>();
            _counties = CreateObjectSet<County>();
            _districts = CreateObjectSet<District>();
            _drugDetails = CreateObjectSet<DrugVerificationDetail>();
            _drugVerification = CreateObjectSet<DrugVerification>();
            _validationRule = CreateObjectSet<ValidationRule>();
            _city = CreateObjectSet<City>();
            _courtLocation = CreateObjectSet<CourtLocation>();
            _courtType = CreateObjectSet<CourtType>();
            _orderType = CreateObjectSet<OrderType>();
            _reportType = CreateObjectSet<ReportType>();
            _transactionLog = CreateObjectSet<TransactionLog>();
            _alacartReport = CreateObjectSet<AlacartReport>();
            _cmsHomePage = CreateObjectSet<CMSHomePage>();
            _emailSendLog = CreateObjectSet<EmailSendLog>();
            _companies = CreateObjectSet<Company>();
            _candidates = CreateObjectSet<Candidate>();
        }


        private ObjectSet<Company> _companies;
        public ObjectSet<Company> Company
        {
            get
            {
                return _companies;
            }
        }

        private ObjectSet<Candidate> _candidates;
        public ObjectSet<Candidate> Candidate
        {
            get
            {
                return _candidates;
            }
        }

        private ObjectSet<ProfessionPlan> _professionPlans;
        public ObjectSet<ProfessionPlan> ProfessionPlans
        {
            get
            {
                return _professionPlans;
            }
        }

        private ObjectSet<ProfessionReport> _professionReports;
        public ObjectSet<ProfessionReport> ProfessionReports
        {
            get
            {
                return _professionReports;
            }
        }


        private ObjectSet<Plan> _plans;
        public ObjectSet<Plan> Plans
        {
            get
            {
                return _plans;
            }
        }


        private ObjectSet<Profession> _professions;
        public ObjectSet<Profession> Professions
        {
            get
            {
                foreach (Profession profession in _professions)
                {
                    LoadProperty(profession, "ProfessionReports");
                }
                return _professions;
            }
            set { _professions = value; }
        }

        private ObjectSet<Report> _reports;
        public ObjectSet<Report> Reports
        {
            get { return _reports; }
            set { _reports = value; }
        }

        private ObjectSet<User> _users;
        public ObjectSet<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        private ObjectSet<State> _states;
        public ObjectSet<State> States
        {
            get { return _states; }
            set { _states = value; }
        }

        private ObjectSet<StateCriminalCourtFee> _stateCriminalCourtFees;
        public ObjectSet<StateCriminalCourtFee> StateCriminalCourtFee {
            get { return _stateCriminalCourtFees; }
            set { _stateCriminalCourtFees = value; }
        }

        private ObjectSet<StateCountyCourtFee> _stateCountyCourtFees;
        public ObjectSet<StateCountyCourtFee> StateCountyCourtFee {
            get { return _stateCountyCourtFees; }
            set { _stateCountyCourtFees = value; }
        }

        private ObjectSet<StateDistrictCourtFee> _stateDistrictCourtFees;
        public ObjectSet<StateDistrictCourtFee> StateDistrictCourtFee {
            get { return _stateDistrictCourtFees; }
            set { _stateDistrictCourtFees = value; }
        }

        private ObjectSet<AccountRef> _accountRefs;
        public ObjectSet<AccountRef> AccountRefs
        {
            get { return _accountRefs; }
            set { _accountRefs = value; }
        }

        private ObjectSet<PlanReport> _planReports;
        public ObjectSet<PlanReport> PlanReports
        {
            get { return _planReports; }
            set { _planReports = value; }
        }

        private ObjectSet<SecQuestion> _secQuestions;
        public ObjectSet<SecQuestion> SecQuestions
        {
            get { return _secQuestions; }
            set { _secQuestions = value; }
        }

        private ObjectSet<IdentificationType> _identificationTypes;
        public ObjectSet<IdentificationType> IdentificationTypes
        {
            get { return _identificationTypes; }
            set { _identificationTypes = value; }
        }


        private ObjectSet<ReferenceInfo> _referenceInfoes;
        public ObjectSet<ReferenceInfo> ReferenceInfoes
        {
            get;
            set;
        }

        private ObjectSet<LicenseInfo> _licenseInfoes;
        public ObjectSet<LicenseInfo> LicenseInfoes
        {
            get;
            set;
        }

        private ObjectSet<EducationalDetail> _educationalDetails;
        public ObjectSet<EducationalDetail> EducationalDetails
        {
            get;
            set;
        }

        private ObjectSet<Order> _orders;
        public ObjectSet<Order> Orders
        {
            //get;
            //set;

            get { return _orders; }
            set { _orders = value; }
        }

         private ObjectSet<OrderAdditionalCharge> _OrderAdditionalCharges;
        public ObjectSet<OrderAdditionalCharge> OrderAdditionalCharges {
            get { return _OrderAdditionalCharges; }
            set { _OrderAdditionalCharges = value; }
        }

        private ObjectSet<OrderOptReport> _orderOptReports;
        public ObjectSet<OrderOptReport> OrderOptReports
        {
            get;
            set;
        }

        private ObjectSet<Coupon> _coupons;
        public ObjectSet<Coupon> Coupons
        {
            get
            {
                return _coupons;
            }
        }


        private ObjectSet<CouponDiscountType> _couponDiscountTypes;
        public ObjectSet<CouponDiscountType> CouponDiscountTypes
        {
            get
            {
                return _couponDiscountTypes;
            }
        }

        private ObjectSet<ReferenceType> _referenceTypes;
        public ObjectSet<ReferenceType> ReferenceTypes
        {
            get
            {
                return _referenceTypes;
            }
        }

        private ObjectSet<OrderState> _orderStates;
        public ObjectSet<OrderState> OrderStates
        {
            get
            {
                return _orderStates;
            }
        }

        private ObjectSet<UserEducationalDetail> _userEducationDetails;
        public ObjectSet<UserEducationalDetail> UserEducationDetails
        {
            get
            {
                return _userEducationDetails;
            }
        }

        private ObjectSet<UserLicenseInfo> _userLicenseInfoes;
        public ObjectSet<UserLicenseInfo> UserLicenseInfoes
        {
            get
            {
                return _userLicenseInfoes;
            }
        }

        private ObjectSet<UserSkill> _userSkills;
        public ObjectSet<UserSkill> UserSkills
        {
            get
            {
                return _userSkills;
            }
        }

        private ObjectSet<UserAdditionalSkill> _userAdditionalSkills;
        public ObjectSet<UserAdditionalSkill> UserAdditionalSkills
        {
            get
            {
                return _userAdditionalSkills;
            }
        }
        private ObjectSet<UserLanuagesKnown> _userLanuagesKnown;
        public ObjectSet<UserLanuagesKnown> UserLanuagesKnowns
        {
            get
            {
                return _userLanuagesKnown;
            }
        }
        private ObjectSet<UserReferenceInfo> _userReferenceInfoes;
        public ObjectSet<UserReferenceInfo> UserReferenceInfoes
        {
            get
            {
                return _userReferenceInfoes;
            }
        }

        private ObjectSet<CardList> _cardLists;
        public ObjectSet<CardList> CardList
        {
            get
            {
                return _cardLists;
            }
        }


        private ObjectSet<EmploymentDetail> _employmentDetails;
        public ObjectSet<EmploymentDetail> EmploymentDetail
        {
            get
            {
                return _employmentDetails;
            }
        }

        private ObjectSet<UserEmploymentDetail> _userEmploymentDetails;
        public ObjectSet<UserEmploymentDetail> UserEmploymentDetail
        {
            get
            {
                return _userEmploymentDetails;
            }
        }

        private ObjectSet<PostGraduationDetail> _postGraduationDetails;
        public ObjectSet<PostGraduationDetail> PostGraduationDetail
        {
            get
            {
                return _postGraduationDetails;
            }
        }

        private ObjectSet<UserPostGraduation> _userPostGraduationDetails;
        public ObjectSet<UserPostGraduation> UserPostGraduation
        {
            get
            {
                return _userPostGraduationDetails;
            }
        }

        private ObjectSet<ForgotPassword> _forgotPassword;
        public ObjectSet<ForgotPassword> ForgotPassword
        {
            get
            {
                return _forgotPassword;
            }
        }

        private ObjectSet<District> _districts;
        public ObjectSet<District> District
        {
            get
            {
                return _districts;
            }
        }
        private ObjectSet<County> _counties;
        public ObjectSet<County> County
        {
            get
            {
                return _counties;
            }
        }

        private ObjectSet<DrugVerificationDetail> _drugDetails;
        public ObjectSet<DrugVerificationDetail> DrugVerificationDetails
        {
            get
            {
                return _drugDetails;
            }
        }

        private ObjectSet<DrugVerification> _drugVerification;
        public ObjectSet<DrugVerification> DrugVerification
        {
            get
            {
                return _drugVerification;
            }
        }

        private ObjectSet<ValidationRule> _validationRule;
        public ObjectSet<ValidationRule> ValidationRule
        {
            get
            {
                return _validationRule;
            }
        }

        private ObjectSet<City> _city;
        public ObjectSet<City> City
        {
            get
            {
                return _city;
            }
        }
        private ObjectSet<CourtType> _courtType;
        public ObjectSet<CourtType> CourtType
        {
            get
            {
                return _courtType;
            }
        }
        private ObjectSet<CourtLocation> _courtLocation;
        public ObjectSet<CourtLocation> CourtLocation
        {
            get
            {
                return _courtLocation;
            }
        }
        private ObjectSet<OrderType> _orderType;
        public ObjectSet<OrderType> OrderType
        {
            get { return _orderType; }
            set { _orderType = value; }
        }

        private ObjectSet<ReportType> _reportType;
        public ObjectSet<ReportType> ReportType
        {
            get { return _reportType; }
            set { _reportType = value; }
        }

        private ObjectSet<TransactionLog> _transactionLog;
        public ObjectSet<TransactionLog> TransactionLog
        {
            get { return _transactionLog; }
            set { _transactionLog = value; }
        }

        private ObjectSet<AlacartReport> _alacartReport;
        public ObjectSet<AlacartReport> AlacartReport
        {
            get { return _alacartReport; }
            set { _alacartReport = value; }
        }

        private ObjectSet<CMSHomePage> _cmsHomePage;
        public ObjectSet<CMSHomePage> CmsHomePage
        {
            get { return _cmsHomePage; }
            set { _cmsHomePage = value; }
        }

        private ObjectSet<EmailSendLog> _emailSendLog;
        public ObjectSet<EmailSendLog> EmailSendLogs
        {
            get
            {
                return _emailSendLog;
            }
        }
    }
}
