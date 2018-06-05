using eknowID.Repositories;
using eknowID.Repositories.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eknowID.Services
{
    public class PackageService
    {
        #region Data Members
        IPlanRepository _packageRepository;
        #endregion

        #region Constructor
        public PackageService()
        {
            _packageRepository = new PlanRepository();
        }
        #endregion

        #region Public Methods

        public bool AddMoneyToWallet(PaymentWalletHistory paymentWallet)
        {
            try
            {
                return _packageRepository.depositeMoneyToWallet(paymentWallet);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }

        public bool IsCompanyProfilePresent(int userId)
        {
            try
            {
                return _packageRepository.IsCompanyProfilePresent(userId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }

        public bool IsCandidateEmailPresent(int userId, string email)
        {
            try
            {
                return _packageRepository.IsCandidateEmailPresent(userId, email);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }

        public bool SaveCandidateDetail(Candidate candidate)
        {
            try
            {
                return _packageRepository.SaveCandidateDetail(candidate);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }

        public bool UpdateUserDetail(User user)
        {
            try
            {
                return _packageRepository.UpdateUserDetail(user);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }

        public bool AddUpdateReportDetail(Report report) {
            try {
                return _packageRepository.AddUpdateReportDetail(report);
            } catch (Exception ex) {
                LogError(ex);
                return false;
            }
        }

        public bool DeleteReport(int reportId) {
            try {
                return _packageRepository.DeleteReport(reportId);
            } catch (Exception ex) {
                LogError(ex);
                return false;
            }
        }

        public bool UpdateUserLastLoginDate(int userId) {
            try {
                return _packageRepository.UpdateUserLastLoginDate(userId);
            } catch (Exception ex) {
                LogError(ex);
                return false;
            }
        }

        public bool UpdateCandidateEmail(int orderId, string email)
        {
            try
            {
                return _packageRepository.UpdateCandidateEmail(orderId, email);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }

        public bool AddUpdateOrderPendingNotes(int orderId, string pendingNote) {
            try {
                return _packageRepository.AddUpdateOrderPendingNotes(orderId, pendingNote);
            } catch (Exception ex) {
                LogError(ex);
                return false;
            }
        }

        public bool UpdateOrderExtraCharges(int orderId, decimal? amount, string description) {
            try {
                return _packageRepository.UpdateOrderExtraCharges(orderId, amount, description);
            } catch (Exception ex) {
                LogError(ex);
                return false;
            }
        }

        public Order ResendCandidateEmail(int orderId)
        {
            try
            {
                return _packageRepository.ResendCandidateEmail(orderId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public bool UpdateEmailTrackStatus(Guid assessmentId)
        {
            try
            {
                return _packageRepository.UpdateEmailTrackStatus(assessmentId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }

        public bool DeleteUserById(int userId)
        {
            try
            {
                return _packageRepository.DeleteUserById(userId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }

        public int CreateCompnayProfile(int userId, Company compnay)
        {
            try
            {
                return _packageRepository.CreateCompnayProfile(userId, compnay);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return 0;
            }
        }

        public int SavePaymentDetail(PaymentModel paymentModel)
        {
            try
            {
                return _packageRepository.SavePaymentDetail(paymentModel);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return 0;
            }
        }

        public int GetApplicantOrderTypeId()
        {
            try
            {
                return _packageRepository.GetApplicantOrderTypeId();
            }
            catch (Exception ex)
            {
                LogError(ex);
                return 0;
            }
        }

        public int GetUserCounts(int? userType, int userId, int? companyId)
        {
            try
            {
                return _packageRepository.GetUserCounts(userType, userId, companyId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return 0;
            }
        }

        public decimal GetWalletBalance(int UserId)
        {
            try
            {
                return _packageRepository.GetWalletBalance(UserId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return 0;
            }
        }

        public PlanViewModal GetIncludeReportList(int orderId)
        {
            try
            {
                return _packageRepository.GetIncludeReportList(orderId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public OrderState GetOrderStateStatus(int orderId)
        {
            try
            {
                return _packageRepository.GetOrderStateStatus(orderId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public Order GetOrderStatus(int orderId)
        {
            try
            {
                return _packageRepository.GetOrderStatus(orderId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public Plan GetSelectedPlanType(int planId)
        {
            try
            {
                return _packageRepository.GetSelectedPlanType(planId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public User GetUserDetailById(int userId)
        {
            try
            {
                return _packageRepository.GetUserDetailById(userId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public List<User> GetUsersLists(int? userType, int userId, int? companyId)
        {
            try
            {
                return _packageRepository.GetUsersLists(userType, userId, companyId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public StateCriminalCourtFee GetStateCriminalFeesByStateAlphaCode(string alphaCode) {
            try {
                return _packageRepository.GetStateCriminalFeesByStateAlphaCode(alphaCode);
            } catch (Exception ex) {
                LogError(ex);
                return null;
            }
        }

        public bool UpdateStateCriminalAccessFees(int stateId, decimal accessFees, string avilability, string turnAroundTime) {
            try {
                return _packageRepository.UpdateStateCriminalAccessFees(stateId, accessFees, avilability, turnAroundTime);
            } catch (Exception ex) {
                LogError(ex);
                return false;
            }
        }

        public bool UpdateCountyCriminalAccessFees(int stateId, int countyId, string countyName, decimal accessFees) {
            try {
                return _packageRepository.UpdateCountyCriminalAccessFees(stateId, countyId, countyName, accessFees);
            } catch (Exception ex) {
                LogError(ex);
                return false;
            }
        }

        public bool UpdateFederalCriminalAccessFees(int stateId, int districtId, string districtName, decimal accessFees) {
            try {
                return _packageRepository.UpdateFederalCriminalAccessFees(stateId, districtId, districtName, accessFees);
            } catch (Exception ex) {
                LogError(ex);
                return false;
            }
        }

        public bool DeleteStateCriminalAccessFees(int stateId) {
            try {
                return _packageRepository.DeleteStateCriminalAccessFees(stateId);
            } catch (Exception ex) {
                LogError(ex);
                return false;
            }
        }

        public bool DeleteCountyCriminalAccessFees(int countyId) {
            try {
                return _packageRepository.DeleteCountyCriminalAccessFees(countyId);
            } catch (Exception ex) {
                LogError(ex);
                return false;
            }
        }

        public bool DeleteFederalCriminalAccessFees(int districtId) {
            try {
                return _packageRepository.DeleteFederalCriminalAccessFees(districtId);
            } catch (Exception ex) {
                LogError(ex);
                return false;
            }
        }

        public List<State> GetStatesList() {
            try {
                return _packageRepository.GetStatesList();
            } catch (Exception ex) {
                LogError(ex);
                return null;
            }
        }

        public List<StateCriminalCourtFee> GetStateCriminalFeesList() {
            try {
                return _packageRepository.GetStateCriminalFeesList();
            } catch (Exception ex) {
                LogError(ex);
                return null;
            }
        }

        public List<StateCountyCourtFee> GetStateCountyFeesList() {
            try {
                return _packageRepository.GetStateCountyFeesList();
            } catch (Exception ex) {
                LogError(ex);
                return null;
            }
        }

        public List<StateDistrictCourtFee> GetStateFederalFeesList() {
            try {
                return _packageRepository.GetStateFederalFeesList();
            } catch (Exception ex) {
                LogError(ex);
                return null;
            }
        }

        


        public List<UserViewModal> GetAllActiveUsersLists(int? userType) {
            try {
                return _packageRepository.GetAllActiveUsersLists(userType);
            } catch (Exception ex) {
                LogError(ex);
                return null;
            }
        }

        public List<UserViewModal> GetSelfUsersList(int? userType, int userId, int? companyId)
        {
            try
            {
                return _packageRepository.GetSelfUsersList(userType, userId, companyId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public List<UserApplicantViewModal> GetApplicantUser(int? userType, int userId, int? companyId)
        {
            try
            {
                return _packageRepository.GetApplicantUser(userType, userId, companyId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public List<TazworkOrderStatusModal> GetAllCandidateOrderByStatus(int? isAdminUser, List<int> orderStatus, int userId, int? companyId)
        {
            try
            {
                return _packageRepository.GetAllCandidateOrderByStatus(isAdminUser, orderStatus, userId, companyId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public List<TazworkOrderStatusModal> GetAllCandidateIncompleteOrderByStatus(int? isAdminUser, List<int> orderStatus, int userId, int? companyId) {
            try {
                return _packageRepository.GetAllCandidateIncompleteOrderByStatus(isAdminUser, orderStatus, userId, companyId);
            } catch (Exception ex) {
                LogError(ex);
                return null;
            }
        }

        public List<TazworkOrderStatusModal> GetAllRequestorOrderByStatus(int? isAdminUser, List<int> orderStatus, int userId, int? companyId)
        {
            try
            {
                return _packageRepository.GetAllRequestorOrderByStatus(isAdminUser, orderStatus, userId, companyId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public List<Tuple<int, int>> GetTazworkOrderStatusCount(int? isAdminUser, int userId, int? companyId)
        {
            try
            {
                return _packageRepository.GetTazworkOrderStatusCount(isAdminUser, userId, companyId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public int GetApplicantUserCount(int? userType, int userId, int? companyId)
        {
            try
            {
                return _packageRepository.GetApplicantUserCount(userType, userId, companyId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return 0;
            }
        }

        public List<PaymentWalletHistory> GetPaymentWalletHistroy(int userId)
        {
            try
            {
                return _packageRepository.GetPaymentWalletHistroy(userId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public List<PlanViewModal> GetPlanTypes()
        {
            try
            {
                return _packageRepository.GetPlanTypes();
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public List<string> GetReportList(List<int> reportListID)
        {
            try
            {
                return _packageRepository.GetReportList(reportListID);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public List<Report> GetAlacartReport()
        {
            try
            {
                return _packageRepository.GetAlacarteReports().ToList();
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public List<PlanDetail> GetSelectedPlanReportList(int planId)
        {
            try
            {
                return _packageRepository.GetSelectedPlanReportList(planId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        public List<CandidateViewModal> GetExistsApplicanDetail(int userId)
        {
            try
            {
                return _packageRepository.GetExistsApplicanDetail(userId);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return null;
            }
        }

        #endregion

        #region Private Methods
        private string Encryptdata(string password)
        {
            try
            {
                string strmsg = string.Empty;
                byte[] encode = new byte[password.Length];
                encode = Encoding.UTF8.GetBytes(password);
                strmsg = Convert.ToBase64String(encode);
                return strmsg;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return string.Empty;
            }
        }

        private void LogError(Exception ex)
        {
            _packageRepository.LogError(ex);
        }
        #endregion
    }
}
