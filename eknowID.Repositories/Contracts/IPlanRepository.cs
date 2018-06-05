using eknowID.Repositories.ViewModels;
using System;
using System.Collections.Generic;

namespace eknowID.Repositories
{
    public interface IPlanRepository
    {
        #region Interface Signature

        bool UpdateEmailTrackStatus(Guid assessmentId);

        bool UpdateUserDetail(User user);

        bool AddUpdateReportDetail(Report report);

        bool DeleteReport(int reportId);

        bool UpdateUserLastLoginDate(int userId);

        bool UpdateCandidateEmail(int orderId, string email);

        bool AddUpdateOrderPendingNotes(int orderId, string pendingNote);

        Order ResendCandidateEmail(int orderId);

        bool DeleteUserById(int userId);

        bool depositeMoneyToWallet(PaymentWalletHistory paymentWallet);

        bool SaveCandidateDetail(Candidate candidate);

        bool IsCompanyProfilePresent(int userId);

        bool IsCandidateEmailPresent(int userId,string email);

        int GetUserCounts(int? userType,int userId, int? companyId);

        int SavePaymentDetail(PaymentModel paymentModel);

        int GetApplicantOrderTypeId();

        int CreateCompnayProfile(int userId, Company company);

        decimal GetWalletBalance(int UserId);
        
        Plan GetSelectedPlanType(int planTypeId);

        User GetUserDetailById(int userId);

        PlanViewModal GetIncludeReportList(int orderId);

        OrderState GetOrderStateStatus(int orderId);

        Order GetOrderStatus(int orderId);

        List<string> GetReportList(List<int> reportListID);

        List<PaymentWalletHistory> GetPaymentWalletHistroy(int userId);

        List<User> GetUsersLists(int? userType,int userId, int? companyId);

        StateCriminalCourtFee GetStateCriminalFeesByStateAlphaCode(string alphaCode);

        List<StateCriminalCourtFee> GetStateCriminalFeesList();

        List<State> GetStatesList();

        bool UpdateStateCriminalAccessFees(int stateId, decimal accessFees, string avilability, string turnAroundTime);

        bool UpdateCountyCriminalAccessFees(int stateId, int countyId, string countyName, decimal accessFees);

        bool UpdateFederalCriminalAccessFees(int stateId, int districtId, string districtName, decimal accessFees);

        bool DeleteStateCriminalAccessFees(int stateId);

        bool DeleteCountyCriminalAccessFees(int countyId);

        bool DeleteFederalCriminalAccessFees(int districtId);

        List<StateCountyCourtFee> GetStateCountyFeesList();

        List<StateDistrictCourtFee> GetStateFederalFeesList();

        List<UserViewModal> GetSelfUsersList(int? userType, int userId, int? companyId);

        List<UserApplicantViewModal> GetApplicantUser(int? userType, int userId, int? companyId);

        List<TazworkOrderStatusModal> GetAllCandidateOrderByStatus(int? isAdminUser, List<int> orderSatus, int userId, int? companyId);

        List<TazworkOrderStatusModal> GetAllCandidateIncompleteOrderByStatus(int? isAdminUser, List<int> orderSatus, int userId, int? companyId);

        List<TazworkOrderStatusModal> GetAllRequestorOrderByStatus(int? isAdminUser, List<int> orderStatus, int userId, int? companyId);

        List<Tuple<int, int>> GetTazworkOrderStatusCount(int? isAdminUser, int userId, int? companyId);

        int GetApplicantUserCount(int? userType, int userId, int? companyId);

        List<Report> GetAlacarteReports();

        List<AlacartReport> GetAdditionalAlacartReports(int orderID);

        List<PlanDetail> GetSelectedPlanReportList(int planId);

        List<CandidateViewModal> GetExistsApplicanDetail(int userId);

        List<PlanViewModal> GetPlanTypes();
        
        void LogError(Exception ex);

        List<UserViewModal> GetAllActiveUsersLists(int? userType);
        bool UpdateOrderExtraCharges(int orderId, decimal? amount, string description);        

        #endregion
    }
}