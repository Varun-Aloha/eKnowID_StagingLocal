using eknowID.Repositories.Constant;
using eknowID.Repositories.Tables;
using eknowID.Repositories.ViewModels;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;
using EknowIDLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eknowID.Repositories
{
    public class PlanRepository : BaseRepository, IPlanRepository
    {
        #region Public Methods

        public bool IsCompanyProfilePresent(int userId)
        {
            var userCompnay = _dbContext.Users.Where(u => u.UserId == userId).Select(u => u.CompanyId).FirstOrDefault();

            return userCompnay != null ? true : false;
        }

        public bool IsCandidateEmailPresent(int userId, string email)
        {
            var candidate = _dbContext.Candidates.Where(p => p.UserId == userId && p.Email == email).FirstOrDefault();

            return candidate != null ? true : false;
        }

        public bool SaveCandidateDetail(Candidate candidate)
        {
            candidate.Id = Guid.NewGuid();

            _dbContext.Candidates.Add(candidate);
            return _dbContext.SaveChanges() > 0;
        }

        public bool depositeMoneyToWallet(PaymentWalletHistory paymentWallet)
        {
            var walletBalance = _dbContext.WalletBalances.Where(p => p.UserId == paymentWallet.UserId).FirstOrDefault();

            if (walletBalance != null)
            {
                //update balance                
                walletBalance.Balance += Convert.ToDecimal(paymentWallet.Deposite);
                walletBalance.UpdatedOn = DateTime.Now;
                _dbContext.Entry(walletBalance).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                //insert statement
                var walletBla = new WalletBalance()
                {
                    UserId = paymentWallet.UserId,
                    UpdatedOn = DateTime.Now,
                    Balance = Convert.ToDecimal(paymentWallet.Deposite)
                };

                _dbContext.WalletBalances.Add(walletBla);
            }

            _dbContext.PaymentWalletHistors.Add(paymentWallet);
            _dbContext.SaveChanges();

            return true;
        }

        public bool UpdateEmailTrackStatus(Guid assessmentId)
        {
            var order = _dbContext.Orders.Where(o => o.AssessmentId == assessmentId).FirstOrDefault();

            if (order == null) return false;

            order.Status = (int)WrapperStatusEnum.email_opened; // applicant is openend email
            _dbContext.Entry(order).State = System.Data.Entity.EntityState.Modified; // modify entity

            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteUserById(int userId)
        {
            var user = _dbContext.Users.Where(p => p.UserId == userId).FirstOrDefault();

            if (user == null) return false;

            user.IsActive = false;

            _dbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateUserDetail(User user)
        {
            var userDetail = _dbContext.Users.Where(p => p.UserId == user.UserId).FirstOrDefault();

            if (userDetail == null) return false;

            userDetail.FirstName = user.FirstName;
            userDetail.LastName = user.LastName;
            userDetail.UserType = user.UserType;
            _dbContext.Entry(userDetail).State = System.Data.Entity.EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteReport(int reportId) {

            var reportDetail = _dbContext.Reports.Where(p => p.ReportId == reportId).FirstOrDefault();
            reportDetail.IsActive = false;
            _dbContext.Entry(reportDetail).State = System.Data.Entity.EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public bool AddUpdateReportDetail(Report report) {

            var reportDetail = 0 < report.ReportId ? _dbContext.Reports.Where(p => p.ReportId == report.ReportId).FirstOrDefault() : new Report();
            if (reportDetail == null) return false;

            reportDetail.Name = report.Name;
            reportDetail.Description = report.Description;
            reportDetail.ReportTypeID = report.ReportTypeID;
            reportDetail.Price = report.Price;
            reportDetail.TurnaroundTime = report.TurnaroundTime;
            reportDetail.MaxVerificationCount = report.MaxVerificationCount;
            reportDetail.IsMultipleCheckEnabled = false;
            reportDetail.IsActive = true;
            if (report.MaxVerificationCount > 1) {
                reportDetail.IsMultipleCheckEnabled = true;
            }

            _dbContext.Entry(reportDetail).State = 0 < report.ReportId ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;                
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateUserLastLoginDate(int userId)
        {
            var userDetail = _dbContext.Users.Where(p => p.UserId == userId).FirstOrDefault();

            if (userDetail == null) return false;

            userDetail.LastLoginDate =DateTime.Now;
            
            _dbContext.Entry(userDetail).State = System.Data.Entity.EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateCandidateEmail(int orderId, string email)
        {
            var candidate = _dbContext.Candidates.Where(p => p.OrderId == orderId).FirstOrDefault();

            if (candidate == null) return false;

            candidate.Email = email;

            _dbContext.Entry(candidate).State = System.Data.Entity.EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public bool AddUpdateOrderPendingNotes(int orderId, string pendingNote) {
            var order = _dbContext.Orders.Where(p => p.OrderId == orderId).FirstOrDefault();

            if (order == null) return false;

            order.PendingNotes = pendingNote;

            _dbContext.Entry(order).State = System.Data.Entity.EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateOrderExtraCharges(int orderId, decimal? amount, string description) {
            var order = _dbContext.Orders.Where(p => p.OrderId == orderId).FirstOrDefault();
            var userId = order.UserId;

            order.PaidAmt += amount ?? 0;

            var additionalCharge = new OrderAdditionalCharge();
            additionalCharge.OrderId = orderId;
            additionalCharge.Amount = amount ?? 0;
            additionalCharge.Description = description;      

            var walletBalance = _dbContext.WalletBalances.FirstOrDefault(p => p.UserId.Equals(userId));
            var paymentWalletHistory = new PaymentWalletHistory();

            if (null == walletBalance) {
                walletBalance = new WalletBalance();
                walletBalance.UserId = userId;
            }
            walletBalance.Balance -= amount ?? 0;
            walletBalance.UpdatedOn = DateTime.Now;


            paymentWalletHistory.TransactionId = description;
            paymentWalletHistory.Withdrawal = amount ?? 0;
            paymentWalletHistory.UserId = userId;
            paymentWalletHistory.InsertedDate = DateTime.Now;

            _dbContext.Entry(additionalCharge).State = System.Data.Entity.EntityState.Added;
            _dbContext.Entry(walletBalance).State = 0 < walletBalance.Id ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;
            _dbContext.Entry(paymentWalletHistory).State = System.Data.Entity.EntityState.Added;

            return _dbContext.SaveChanges() > 0;
        }

        public Order ResendCandidateEmail(int orderId)
        {
            _dbContext.Configuration.LazyLoadingEnabled = false;

            var order = _dbContext.Orders.Where(p => p.OrderId == orderId).FirstOrDefault();

            if (order == null) return null;

            order.IsResendEmail = true;
            order.Status = (int)WrapperStatusEnum.order_place;
            order.ResendEmailCount = order.ResendEmailCount + 1;

            _dbContext.Entry(order).State = System.Data.Entity.EntityState.Modified;
            _dbContext.SaveChanges();

            return order;
        }

        public int GetUserCounts(int? userType, int userId, int? companyId)
        {
            var query = _dbContext.Users.Where(u => u.IsActive == true);

            if (userType == (int)UserTypeEnum.SUPER_ADMIN)
            {
                return query.ToList().Count;
            }
            else if (companyId != null)
                query = query.Where(u => u.CompanyId == companyId && u.Email != EknowIDLib.Constant.CONST_CMS_ADMIN_USERID);
            else
                query = query.Where(u => u.UserId == userId && u.Email != EknowIDLib.Constant.CONST_CMS_ADMIN_USERID);

            return query.ToList().Count;
        }

        public int CreateCompnayProfile(int userId, Company compnay)
        {
            _dbContext.Companies.Add(compnay);
            _dbContext.SaveChanges();

            //update compnay id into user table
            var user = _dbContext.Users.Where(u => u.UserId == userId).FirstOrDefault();

            user.CompanyId = compnay.Id;
            _dbContext.Entry(user).State = System.Data.Entity.EntityState.Modified; // modify entity
            _dbContext.SaveChanges();

            return compnay.Id;
        }

        public int SavePaymentDetail(PaymentModel paymentModel)
        {
            var order = new Order()
            {
                UserId = paymentModel.OrderDetailModel.UserId,
                TransactionId = paymentModel.PaymentResponseModal.TransactionId ?? string.Empty,
                CorrelationId = paymentModel.PaymentResponseModal.CorrelationId ?? string.Empty,
                Description = paymentModel.PaymentResponseModal.ErrorMessage ?? string.Empty,
                PlanId = paymentModel.OrderDetailModel.PlanType,
                PurchasedDate = System.DateTime.Now,
                PaidAmt = paymentModel.OrderDetailModel.TotalOrder,
                ProfessionId = 34, // dumy profession Id, no profession is required for this order
                Status = (int)WrapperStatusEnum.order_place,
                OrderTypeID = paymentModel.OrderDetailModel.OrderTypeId,
                AssessmentId = Guid.NewGuid(),
                ResendEmailCount = 0 // set 0 for default entry
            };

            foreach (var item in paymentModel.AlacartReportListWithQty) {
                var reportName = _dbContext.Reports.FirstOrDefault(p => p.ReportId.Equals(item.Key)).Name;
                var statesSelected = "";
                var county_DistrictsSelected = "";
                if(reportName == "State Criminal Records") {
                    statesSelected = paymentModel.SelectedStates;
                    county_DistrictsSelected = "";
                } else if(reportName == "County Criminal Courthouse Search") {

                    if(!string.IsNullOrEmpty(paymentModel.SelectedCounties)) {

                        string[] splitter = new string[] { "," };
                        var countiesSelected = paymentModel.SelectedCounties.Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();

                        var counties = _dbContext.StateCountyCourtFees.Where(p => countiesSelected.Contains(p.Id)).OrderBy(p=>p.Id);
                        
                        statesSelected = string.Join(",", counties.Select(p => p.State.AlphaCode));
                        county_DistrictsSelected = string.Join(",", counties.Select(p => p.County));
                        foreach(var county in counties) {
                            var additionalCharge = new OrderAdditionalCharge() {
                                OrderId = order.OrderId,
                                Amount = county.DistrictCourtFees ?? 0,
                                Description = "County Criminal Court aceess Fee:" + county.County
                            };
                            _dbContext.OrderAdditionalCharges.Add(additionalCharge);
                        }
                    }

                } else if (reportName == "County Civil Courthouse Search") {
                    if (!string.IsNullOrEmpty(paymentModel.SelectedCivilCounties)) {

                        string[] splitter = new string[] { "," };
                        var countiesSelected = paymentModel.SelectedCivilCounties.Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();

                        var counties = _dbContext.StateCountyCourtFees.Where(p => countiesSelected.Contains(p.Id)).OrderBy(p => p.Id);

                        statesSelected = string.Join(",", counties.Select(p => p.State.AlphaCode));
                        county_DistrictsSelected = string.Join(",", counties.Select(p => p.County));
                        foreach (var county in counties) {
                            var additionalCharge = new OrderAdditionalCharge() {
                                OrderId = order.OrderId,
                                Amount = county.DistrictCourtFees ?? 0,
                                Description = "County Civil Court aceess Fee:" + county.County
                            };
                            _dbContext.OrderAdditionalCharges.Add(additionalCharge);
                        }
                    }
                } else if (reportName == "Federal Criminal Courthouse Search") {
                    if (!string.IsNullOrEmpty(paymentModel.SelectedDistricts)) {

                        string[] splitter = new string[] { "," };
                        var districtsSelected = paymentModel.SelectedDistricts.Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();

                        var districts = _dbContext.StateDistrictCourtFees.Where(p => districtsSelected.Contains(p.Id)).OrderBy(p => p.Id);

                        statesSelected = string.Join(",", districts.Select(p => p.State.AlphaCode));
                        county_DistrictsSelected = string.Join(",", districts.Select(p => p.DistrictCourt ?? ""));
                    }
                }

                var alacarteReport = new AlacartReport() {
                    OrderId = order.OrderId,
                    ReportId = item.Key,
                    Qty = item.Value,
                    StatesSelected = statesSelected,
                    Couty_DistrictsSelected = county_DistrictsSelected
                };

                _dbContext.AlacartReports.Add(alacarteReport); //add report to database;
                if("Education Verification" == reportName || "Employment Verification" == reportName) {
                    var additionalCharge = new OrderAdditionalCharge() {
                        OrderId = order.OrderId,
                        Amount = 25 * item.Value,
                        Description = reportName + " Holding Fee ($25 * Qty): "
                    };
                    _dbContext.OrderAdditionalCharges.Add(additionalCharge);
                }
                if("Credit Report" == reportName) {
                    var user = _dbContext.Users.FirstOrDefault(p => p.UserId.Equals(paymentModel.OrderDetailModel.UserId));
                    if(paymentModel.IsCreditReportAuditingChargesPaid) {
                        user.Company.IsCreditReportAuditingChargesPaid = true;
                       //_dbContext.SaveChanges();                       

                        StringBuilder emailBody = new StringBuilder(ConstructMail.GetMailBody(EknowIDLib.Constant.CREDIT_REPORT_CREDENTIALING_SUPPORT));
                        emailBody = emailBody.Replace(EknowIDLib.Constant.CONST_FIRSTNAME, user.FirstName);
                        emailBody = emailBody.Replace(EknowIDLib.Constant.CONST_LASTNAME, user.LastName);
                        emailBody = emailBody.Replace(EknowIDLib.Constant.CONST_COMPANYNAME, user.Company.Name);
                        
                        SendMail.Sendmail(EknowIDLib.Constant.SUPPORT_EKNOWID_MAILID, EknowIDLib.Constant.CONST_CREDIT_REPORT_CREDENTIALING_SUBJECT, emailBody.ToString());                        
                    }
                    //user.Company.
                    var additionalCharge = new OrderAdditionalCharge() {
                        OrderId = order.OrderId,
                        Amount = 75,
                        Description = reportName + " on-site inspection charges: "
                    };
                    _dbContext.OrderAdditionalCharges.Add(additionalCharge);
                }
            }

            if(!string.IsNullOrEmpty(paymentModel.SelectedStates)) {
                string[] splitter = new string[] { "," };
                string[] statesSelected = paymentModel.SelectedStates.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                foreach(var state in statesSelected) {
                    var stateCriminalRecord = _dbContext.StateCriminalCourtFees.Any(s => s.AlphaCode.Equals(state)) ? _dbContext.StateCriminalCourtFees.FirstOrDefault(s => s.AlphaCode.Equals(state)) : null;
                    if(null != stateCriminalRecord) {
                        var additionalCharge = new OrderAdditionalCharge() {
                            OrderId = order.OrderId,
                            Amount = stateCriminalRecord.Fee ?? 0,
                            Description = "State criminal access Fee: " + stateCriminalRecord.Name                            
                        };
                        _dbContext.OrderAdditionalCharges.Add(additionalCharge);
                    }
                }
            }

            _dbContext.Orders.Add(order);

            if ((paymentModel.IsFullWalletPayment || paymentModel.IsPartialWalletPayment) && !paymentModel.IsPaymentError)
            {
                //deducat money from wallet
                var PaymentWalletHistors = new PaymentWalletHistory()
                {
                    Withdrawal = paymentModel.OrderDetailModel.WalletPrice,
                    InsertedDate = DateTime.Now,
                    UserId = paymentModel.OrderDetailModel.UserId
                };

                _dbContext.PaymentWalletHistors.Add(PaymentWalletHistors);

                var wallBalance = _dbContext.WalletBalances.Where(p => p.UserId == paymentModel.OrderDetailModel.UserId).FirstOrDefault();

                if (wallBalance != null)
                {
                    //calculate final balance.
                    var tmpOrderTotal = paymentModel.OrderDetailModel.OrderTotal;

                    if (wallBalance.Balance <= tmpOrderTotal)
                        wallBalance.Balance = 0.00M;
                    else
                        wallBalance.Balance = (wallBalance.Balance - paymentModel.OrderDetailModel.OrderTotal);

                    wallBalance.UpdatedOn = DateTime.Now;
                    _dbContext.Entry(wallBalance).State = System.Data.Entity.EntityState.Modified;
                }
            }

            _dbContext.SaveChanges();

            return order.OrderId;
        }

        public int GetApplicantOrderTypeId()
        {
            return _dbContext.OrderTypes.Where(or => or.OrderTypeName == "Applicant/Candidate").FirstOrDefault().OrderTypeID;
        }

        public decimal GetWalletBalance(int UserId)
        {
            var result = _dbContext.WalletBalances.Where(p => p.UserId == UserId).Select(p => new { balance = p.Balance }).FirstOrDefault();

            if (result == null) return 0;

            return Convert.ToDecimal(result.balance);

        }

        public PlanViewModal GetIncludeReportList(int orderId)
        {
            var queryReportIncluded = (from plnReport in _dbContext.PlanReports
                                       join AlacarteRpt in _dbContext.Reports on plnReport.ReportId equals AlacarteRpt.ReportId
                                       join innerOrder in _dbContext.Orders on plnReport.PlanId equals innerOrder.PlanId
                                       where innerOrder.OrderId == orderId
                                       select new ReportViewModal { ReportName = AlacarteRpt.Name });

            var queryAlacartReport = (from alacartRpt in _dbContext.AlacartReports
                                      join innnerRpt in _dbContext.Reports on alacartRpt.ReportId equals innnerRpt.ReportId
                                      join innerOdr in _dbContext.Orders on alacartRpt.OrderId equals innerOdr.OrderId
                                      where innerOdr.OrderId == orderId
                                      select new AlacartViewModal
                                      {
                                          AlacartReprtName = innnerRpt.Name,
                                          Rate = innnerRpt.Price,
                                          Qty = alacartRpt.Qty,
                                          statesSelected = alacartRpt.StatesSelected
                                      });

            bool isCriminalMultiStateCheckReportSelected = queryAlacartReport.Any(p => p.AlacartReprtName.Equals("eKnowID Criminal MultiState Alias", StringComparison.OrdinalIgnoreCase));
            if (isCriminalMultiStateCheckReportSelected) {
                queryReportIncluded = queryReportIncluded.Where(p => !p.ReportName.Equals("National Criminal Database with Alias"));
            }


            var additionalCharges = _dbContext.OrderAdditionalCharges.Where(c => c.Deleted.Equals(false) && c.OrderId.Equals(orderId))
                                        .Select(c=> new OrderAdditionalChargeViewModel {
                                            Id = c.Id,
                                            OrderId = c.OrderId,
                                            Amount = c.Amount,
                                            Description = c.Description                                            
                                        });

            //char[] options = new char[] { ',' };
            //var statesSelected = (queryAlacartReport.Any(p => p.AlacartReprtName.Equals("State Criminal Records")) ? 
            //                        (queryAlacartReport.Where(p => p.AlacartReprtName.Equals("State Criminal Records")).FirstOrDefault().statesSelected ?? "") 
            //                        : "").Split(options,StringSplitOptions.RemoveEmptyEntries);
            //var AccessFees = _dbContext.StateCriminals.Any(p => statesSelected.Contains(p.AlphaCode)) ?
            //                    _dbContext.StateCriminals.Where(p => statesSelected.Contains(p.AlphaCode)).Sum(p => p.Fee ?? 0) : 0;

            //IRepository<EknowIDModel.StateCriminal> state_criminal = new Repository<EknowIDModel.StateCriminal>();
            //IList<EknowIDModel.StateCriminal> stateList = state_criminal.SelectAll().Where(p => !p.Availability.Trim().ToLower().Equals("not available")).ToList();
            //var AccessFees = statesSelected.Any() ? _dbContext
            var Order = _dbContext.Orders.FirstOrDefault(o => o.OrderId.Equals(orderId));
            var PlanReports = _dbContext.PlanReports.Where(p => p.PlanId == Order.PlanId);

            PlanViewModal queryResult = new PlanViewModal();
            if (PlanReports.Any()) {
                queryResult = (from pln in _dbContext.Plans
                               join plnRpt in _dbContext.PlanReports on pln.PlanId equals plnRpt.PlanId
                               join rpt in _dbContext.Reports on plnRpt.ReportId equals rpt.ReportId
                               join odr in _dbContext.Orders on pln.PlanId equals odr.PlanId
                               where odr.OrderId == orderId
                 select new PlanViewModal() {
                     PlanId = pln.PlanId,
                     PlanName = pln.Name,
                     Rate = pln.Rate,
                     DiscountAmt = odr.DiscountAmt,
                     ReportViewModal = queryReportIncluded,
                     AlacartViewModal = queryAlacartReport,
                     AdditionalCharges = additionalCharges
                 }).FirstOrDefault();
            }
            else {
                queryResult = (from pln in _dbContext.Plans                              
                               join odr in _dbContext.Orders on pln.PlanId equals odr.PlanId
                               where odr.OrderId == orderId
                               select new PlanViewModal() {
                                   PlanId = pln.PlanId,
                                   PlanName = pln.Name,
                                   Rate = pln.Rate,
                                   DiscountAmt = odr.DiscountAmt,                                   
                                   ReportViewModal = queryReportIncluded,
                                   AlacartViewModal = queryAlacartReport,
                                   AdditionalCharges = additionalCharges
                               }).FirstOrDefault();
            }

            return queryResult;
        }

        public OrderState GetOrderStateStatus(int orderId)
        {
            return _dbContext.OrderStates.Where(o => o.OrderId == orderId).OrderByDescending(o => o.InsertTime).FirstOrDefault();
        }

        public Order GetOrderStatus(int orderId)
        {
            return _dbContext.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();
        }

        public Plan GetSelectedPlanType(int planId)
        {
            return _dbContext.Plans.Include("PlanReports").Where(p => p.PlanId == planId).FirstOrDefault();
        }

        public User GetUserDetailById(int userId)
        {
            return _dbContext.Users.Where(p => p.UserId == userId).FirstOrDefault();
        }

        public List<string> GetReportList(List<int> reportListID)
        {
            return _dbContext.Reports.Where(p => reportListID.Contains(p.ReportId)).Select(p => p.Name).ToList();
        }

        public List<PlanViewModal> GetPlanTypes()
        {
            var queryReportViewModal = (from plnReport in _dbContext.PlanReports
                                        join rpt in _dbContext.Reports on plnReport.ReportId equals rpt.ReportId
                                        where (plnReport.PlanId == 20 || plnReport.PlanId == 21 || plnReport.PlanId == 22)
                                        select new ReportViewModal
                                        {
                                            PlanId = plnReport.PlanId,
                                            ReportName = rpt.Name
                                        });

            return (from pln in _dbContext.Plans
                    where pln.HasProfessionRelationship == false
                    select new PlanViewModal()
                    {
                        PlanId = pln.PlanId,
                        PlanName = pln.Name,
                        Rate = pln.Rate,
                        ReportViewModal = queryReportViewModal.Where(p => p.PlanId == pln.PlanId)
                    }).ToList();
        }

        public List<PlanDetail> GetSelectedPlanReportList(int planId)
        {
            _dbContext.Configuration.LazyLoadingEnabled = false;
            return _dbContext.PlanDetails.Where(p => p.PlanId == planId).ToList();
        }

        public List<Report> GetAlacarteReports()
        {
            return _dbContext.Reports.Where(p => p.ReportTypeID != 4).ToList();
        }

        public List<AlacartReport> GetAdditionalAlacartReports(int orderID) {
            //List<AlacartReport> lstReport = new List<AlacartReport>();

            return _dbContext.AlacartReports.Where(p => p.OrderId == orderID).ToList();

        }

        public List<User> GetUsersLists(int? userType, int userId, int? companyId)
        {
            if (userType == (int)UserTypeEnum.SUPER_ADMIN)
            {
                return _dbContext.Users.Where(u => u.IsActive == true).ToList();
            }
            else if (userType == (int)UserTypeEnum.ADMIN && companyId != null)
            {
                return _dbContext.Users.Where(u => u.IsActive == true && u.CompanyId == companyId).ToList();
            }

            return _dbContext.Users.Where(u => u.IsActive == true && u.UserId == userId && u.CompanyId == companyId).ToList();
        }

        public StateCriminalCourtFee GetStateCriminalFeesByStateAlphaCode(string alphaCode) {
            return _dbContext.StateCriminalCourtFees.Any(s => s.AlphaCode.Equals(alphaCode)) ? _dbContext.StateCriminalCourtFees.FirstOrDefault(s => s.AlphaCode.Equals(alphaCode)) : null;
        }

        public List<StateCriminalCourtFee> GetStateCriminalFeesList() {
            return _dbContext.StateCriminalCourtFees.Where(s=> !s.Deleted).ToList();
        }

        public List<State> GetStatesList() {
            return _dbContext.States.ToList();
        }

        public bool UpdateStateCriminalAccessFees(int stateId, decimal accessFees, string avilability, string turnAroundTime) {
            var StateCriminalAccessFees = 0 < stateId ? _dbContext.StateCriminalCourtFees.Where(p => p.StateId == stateId).FirstOrDefault() : new StateCriminalCourtFee();
            if (StateCriminalAccessFees == null) return false;

            StateCriminalAccessFees.Availability = avilability;
            StateCriminalAccessFees.TurnAroundTime = turnAroundTime;
            StateCriminalAccessFees.Fee = accessFees;            

            _dbContext.Entry(StateCriminalAccessFees).State = 0 < stateId ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateCountyCriminalAccessFees(int stateId, int countyId, string countyName, decimal accessFees) {
            var CountyCriminalAccessFees = 0 < countyId ? _dbContext.StateCountyCourtFees.Where(p => p.Id == countyId).FirstOrDefault() : new StateCountyCourtFee();
            if (0 >= countyId) {
                CountyCriminalAccessFees.StateId = stateId;
                CountyCriminalAccessFees.CircuitCourtFees = 0;
                CountyCriminalAccessFees.PerRecordFees = 0;
            }

            CountyCriminalAccessFees.County = countyName;            
            CountyCriminalAccessFees.DistrictCourtFees = accessFees;

            _dbContext.Entry(CountyCriminalAccessFees).State = 0 < countyId ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateFederalCriminalAccessFees(int stateId, int districtId, string districtName, decimal accessFees) {
            var FederalCriminalAccessFees = 0 < districtId ? _dbContext.StateDistrictCourtFees.Where(p => p.Id == districtId).FirstOrDefault() : new StateDistrictCourtFee();
            if (0 >= districtId) {
                FederalCriminalAccessFees.StateId = stateId;
            }

            FederalCriminalAccessFees.DistrictCourt = districtName;
            FederalCriminalAccessFees.DistrictCourtFees = accessFees;

            _dbContext.Entry(FederalCriminalAccessFees).State = 0 < districtId ? System.Data.Entity.EntityState.Modified : System.Data.Entity.EntityState.Added;
            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteStateCriminalAccessFees(int stateId) {
            var StateCriminalAccessFees = 0 < stateId ? _dbContext.StateCriminalCourtFees.Where(p => p.StateId == stateId).FirstOrDefault() : new StateCriminalCourtFee();
            if (StateCriminalAccessFees == null) return false;
            StateCriminalAccessFees.Deleted = true;
            _dbContext.Entry(StateCriminalAccessFees).State = System.Data.Entity.EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteCountyCriminalAccessFees(int countyId) {
            var CountyCriminalAccessFees = 0 < countyId ? _dbContext.StateCountyCourtFees.Where(p => p.Id == countyId).FirstOrDefault() : new StateCountyCourtFee();
            if (CountyCriminalAccessFees == null) return false;
            CountyCriminalAccessFees.Deleted = true;
            _dbContext.Entry(CountyCriminalAccessFees).State = System.Data.Entity.EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteFederalCriminalAccessFees(int districtId) {
            var FederalCriminalAccessFees = 0 < districtId ? _dbContext.StateDistrictCourtFees.Where(p => p.Id == districtId).FirstOrDefault() : new StateDistrictCourtFee();
            if (FederalCriminalAccessFees == null) return false;
            FederalCriminalAccessFees.Deleted = true;
            _dbContext.Entry(FederalCriminalAccessFees).State = System.Data.Entity.EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public List<StateCountyCourtFee> GetStateCountyFeesList() {
            return _dbContext.StateCountyCourtFees.Where(c=> !c.Deleted).ToList();
        }

        public List<StateDistrictCourtFee> GetStateFederalFeesList() {
            return _dbContext.StateDistrictCourtFees.Where(d=> !d.Deleted).ToList();
        }

        public List<UserViewModal> GetAllActiveUsersLists(int? userType) {
            List<UserViewModal> activeUsers = new List<UserViewModal>();
            if (userType == (int)UserTypeEnum.SUPER_ADMIN) {
                activeUsers = _dbContext.Users.Where(u => u.IsActive == true)
                                .Select(u => new UserViewModal() {
                                    UserId = u.UserId,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    CreatedDate = u.CreatedDate,
                                    CompayId = u.CompanyId,
                                    FullName =  u.FirstName + " " + u.LastName,
                                }).ToList();
            }
            return activeUsers;
        }

        public List<UserViewModal> GetSelfUsersList(int? userType, int userId, int? companyId)
        {
            var query = (from users in _dbContext.Users
                         join orders in _dbContext.Orders on users.UserId equals orders.UserId
                         where users.IsActive == true && orders.AssessmentId == Guid.Empty && orders.TransactionId != null && orders.TransactionId != string.Empty
                         select new UserViewModal()
                         {
                             UserId = users.UserId,
                             FirstName = users.FirstName,
                             LastName = users.LastName,
                             CreatedDate = users.CreatedDate,
                             CompayId = users.CompanyId
                         });

            if (userType == (int)UserTypeEnum.SUPER_ADMIN)
            {
                return query.ToList();
            }
            else if (userType == (int)UserTypeEnum.ADMIN && companyId != null)
            {
                return query.Where(u => u.CompayId == companyId).ToList();
            }

            return query.Where(u => u.UserId == userId).ToList();
        }

        public List<UserApplicantViewModal> GetApplicantUser(int? userType, int userId, int? companyId)
        {
            var query = (from users in _dbContext.Users
                         join company in _dbContext.Companies on users.CompanyId equals company.Id
                         join candidate in _dbContext.Candidates on users.UserId equals candidate.UserId
                         where users.IsActive == true
                         select new UserApplicantViewModal()
                         {
                             User = users,
                             Candidate = candidate,
                             Company = company
                         });

            if (userType == (int)UserTypeEnum.SUPER_ADMIN)
            {
                return query.ToList();
            }
            else if (userType == (int)UserTypeEnum.ADMIN)
            {
                query = query.Where(u => u.User.CompanyId == companyId);
            }
            else if (userType == (int)UserTypeEnum.NORMAL_USER)
            {
                query = query.Where(u => u.User.UserId == userId);
            }

            return query.ToList();
        }

        public List<TazworkOrderStatusModal> GetAllCandidateIncompleteOrderByStatus(int? userType, List<int> orderStatus, int userId, int? companyId)
        {
            var defaultCompany = new Company();
            var defaultCandidate = new Candidate();
            var query = (from order in _dbContext.Orders
                         join pln in _dbContext.Plans on order.PlanId equals pln.PlanId
                         join candidate in _dbContext.Candidates on order.OrderId equals candidate.OrderId into tmpCandidate
                         join user in _dbContext.Users on order.UserId equals user.UserId
                         join company in _dbContext.Companies on user.CompanyId equals company.Id into tmpCompany                         
                         where order.OrderTypeID == 6
                         from tu in tmpCandidate.DefaultIfEmpty()
                         from tc in tmpCompany.DefaultIfEmpty()
                         select new 
                         {
                             User = user,
                             Company = null != tc ? tc: null,
                             Order = order,
                             Candidate = null != tu ? tu : null,
                             Plan = pln,
                             OrderStatusText = order.Status == (int)WrapperStatusEnum.order_place ? "Order Placed" : order.Status == (int)WrapperStatusEnum.accept ? "Email Invite Sent" : order.Status == (int)WrapperStatusEnum.email_opened ? "Email Opened" : order.Status == (int)WrapperStatusEnum.inprogress ? "In Progress" : order.Status == (int)WrapperStatusEnum.results ? "Ready" : order.Status == (int)WrapperStatusEnum.reject ? "Cancel " : string.Empty,
                         }).AsEnumerable().Select(p=> new TazworkOrderStatusModal() {
                             User = p.User,
                             Company = null != p.Company ? p.Company : defaultCompany,
                             Order = p.Order,
                             Candidate = null != p.Candidate ? p.Candidate : defaultCandidate,
                             Plan = p.Plan,
                             OrderStatusText = p.OrderStatusText,
                             IsIncompleteOrder = true,
                         });

            query = query.Where(u => u.Order.TransactionId != null && u.Order.TransactionId != string.Empty && (u.Candidate.Id.Equals(Guid.Empty) || u.Company.Id.Equals(0)) && u.OrderStatusText.ToLower().Trim() != "cancel");

            if (userType == (int)UserTypeEnum.SUPER_ADMIN)
            {
                return query.ToList();
            }

            if (userType == (int)UserTypeEnum.ADMIN && companyId != null)
            {
                query = query.Where(u => u.User.CompanyId == companyId);
            }
            else
            {
                query = query.Where(u => u.User.UserId == userId);
            }

            return query.ToList();
        }
        public List<TazworkOrderStatusModal> GetAllCandidateOrderByStatus(int? userType, List<int> orderStatus, int userId, int? companyId) {
            var query = (from order in _dbContext.Orders
                         join pln in _dbContext.Plans on order.PlanId equals pln.PlanId
                         join candidate in _dbContext.Candidates on order.OrderId equals candidate.OrderId
                         join user in _dbContext.Users on order.UserId equals user.UserId
                         join company in _dbContext.Companies on user.CompanyId equals company.Id
                         where orderStatus.Contains(order.Status)
                         select new TazworkOrderStatusModal() {
                             User = user,
                             Company = company,
                             Order = order,
                             Candidate = candidate,
                             Plan = pln,
                             OrderStatusText = order.Status == (int)WrapperStatusEnum.order_place ? "Order Placed" : order.Status == (int)WrapperStatusEnum.accept ? "Email Invite Sent" : order.Status == (int)WrapperStatusEnum.email_opened ? "Email Opened" : order.Status == (int)WrapperStatusEnum.inprogress ? "In Progress" : order.Status == (int)WrapperStatusEnum.results ? "Ready" : order.Status == (int)WrapperStatusEnum.reject ? "Cancel " : string.Empty,
                             IsIncompleteOrder = false
                         });

            if (userType == (int)UserTypeEnum.SUPER_ADMIN) {
                return query.ToList();
            }

            if (userType == (int)UserTypeEnum.ADMIN && companyId != null) {
                query = query.Where(u => u.User.CompanyId == companyId);
            } else {
                query = query.Where(u => u.User.UserId == userId);
            }

            return query.ToList();
        }
        public List<TazworkOrderStatusModal> GetAllRequestorOrderByStatus(int? userType, List<int> orderStatus, int userId, int? companyId)
        {
            var query = (from order in _dbContext.Orders
                         join pln in _dbContext.Plans on order.PlanId equals pln.PlanId
                         join user in _dbContext.Users on order.UserId equals user.UserId
                         where orderStatus.Contains(order.Status) && order.OrderTypeID != 6 && order.TransactionId != null
                         select new TazworkOrderStatusModal()
                         {
                             User = user,
                             Plan = pln,
                             Order = order,
                             OrderStatusText = order.Status == (int)TazWorksStatus.PENDING ? "In-Progress" : order.Status == (int)TazWorksStatus.READY ? "Ready" : order.Status == (int)TazWorksStatus.CANCELED ? "Cancel" : order.Status == (int)TazWorksStatus.ERROR ? "Cancel" : "In-Progress",
                             IsIncompleteOrder = false
                         });

            if (userType == (int)UserTypeEnum.SUPER_ADMIN)
            {
                return query.ToList();
            }

            if (userType == (int)UserTypeEnum.ADMIN && companyId != null)
            {
                query = query.Where(u => u.User.CompanyId == companyId);
            }
            else
            {
                query = query.Where(u => u.User.UserId == userId);
            }

            return query.ToList();
        }

        public int GetApplicantUserCount(int? userType, int userId, int? companyId)
        {
            var query = (from users in _dbContext.Users join candidates in _dbContext.Candidates on users.UserId equals candidates.UserId select users);

            if (userType == (int)UserTypeEnum.SUPER_ADMIN)
            {
                return query.ToList().Count;
            }
            else if (userType == (int)UserTypeEnum.ADMIN && companyId != null)
            {
                return query.Where(u => u.CompanyId == companyId).ToList().Count;
            }

            return query.Where(u => u.UserId == userId).ToList().Count;
        }

        public List<Tuple<int, int>> GetTazworkOrderStatusCount(int? userType, int userId, int? companyId)
        {
            var tupleList = new List<Tuple<int, int>>();

            var defaultCompany = new Company();
            var defaultCandidate = new Candidate();

            //from order in _dbContext.Orders
            //join pln in _dbContext.Plans on order.PlanId equals pln.PlanId
            //join candidate in _dbContext.Candidates on order.OrderId equals candidate.OrderId into tmpCandidate
            //join user in _dbContext.Users on order.UserId equals user.UserId
            //join company in _dbContext.Companies on user.CompanyId equals company.Id into tmpCompany
            ////where orderStatus.Contains(order.Status)
            //from tu in tmpCandidate.DefaultIfEmpty()
            //from tc in tmpCompany.DefaultIfEmpty()


            var candidateOrders = (from order in _dbContext.Orders
                                   join user in _dbContext.Users on order.UserId equals user.UserId
                                   join candidate in _dbContext.Candidates on order.OrderId equals candidate.OrderId into tmpCandidate
                                   join company in _dbContext.Companies on user.CompanyId equals company.Id into tmpCompany
                                   where order.OrderTypeID == 6
                                   from tu in tmpCandidate.DefaultIfEmpty()
                                   from tc in tmpCompany.DefaultIfEmpty()
                                   select new {
                                       Company = null != tc ? tc : null,
                                       Order = order,
                                       Candidate = null != tu ? tu : null
                                   }).AsEnumerable().Select(p => new TazworkOrderStatusModal() {
                                       Company = null != p.Company ? p.Company : defaultCompany,
                                       Order = p.Order,
                                       Candidate = null != p.Candidate ? p.Candidate : defaultCandidate,
                                   });

            //var candidateOrders = (from user in _dbContext.Users
            //                       join order in _dbContext.Orders on user.UserId equals order.UserId
            //                       join candidate in _dbContext.Candidates on order.OrderId equals candidate.OrderId into tmpCandidate
            //                       join company in _dbContext.Companies on user.CompanyId equals company.Id into tmpCompany
            //                       where order.TransactionId != null && order.TransactionId != string.Empty && order.OrderTypeID == 6
            //                       select order);

            var selfOrders = (from user in _dbContext.Users
                              join order in _dbContext.Orders on user.UserId equals order.UserId
                              where order.TransactionId != null && order.TransactionId != string.Empty && order.OrderTypeID != 6
                              select order);

            //if (userType == (int)UserTypeEnum.ADMIN)
            //{
            //    candidateOrders = candidateOrders.Where(o => o.Order.User.CompanyId == companyId && companyId != null);
            //    selfOrders = selfOrders.Where(o => o.UserId == userId);
            //}
            //else if (userType == (int)UserTypeEnum.NORMAL_USER)
            //{
            //    candidateOrders = candidateOrders.Where(o => o.Order.UserId == userId && o.Order.User.CompanyId == companyId);
            //    selfOrders = selfOrders.Where(o => o.UserId == userId);
            //}

            if (userType == (int)UserTypeEnum.ADMIN) {
                if (companyId != null) {
                    candidateOrders = candidateOrders.Where(o => o.Order.User.CompanyId == companyId);
                    selfOrders = selfOrders.Where(o => o.UserId == userId);
                } else {
                    candidateOrders = candidateOrders.Where(o => o.Order.UserId == userId);
                selfOrders = selfOrders.Where(o => o.UserId == userId);
            }
            } else if (userType == (int)UserTypeEnum.NORMAL_USER) {
                if (companyId != null) {
                    candidateOrders = candidateOrders.Where(o => o.Order.UserId == userId && o.Order.User.CompanyId == companyId);
                    selfOrders = selfOrders.Where(o => o.UserId == userId);
                } else {
                    candidateOrders = candidateOrders.Where(o => o.Order.UserId == userId);
                selfOrders = selfOrders.Where(o => o.UserId == userId);
            }
            }

            var candidatePendingOrders = candidateOrders.Where(o => o.Order.TransactionId != null && o.Order.TransactionId != string.Empty &&
                                                    !(o.Candidate.Id.Equals(Guid.Empty) || o.Company.Id.Equals(0)) &&
                                                    (o.Order.Status == (int)WrapperStatusEnum.accept ||
                                                    o.Order.Status == (int)WrapperStatusEnum.email_opened ||
                                                    o.Order.Status == (int)WrapperStatusEnum.inprogress ||
                                                    o.Order.Status == (int)WrapperStatusEnum.order_place)).Distinct();
            var selfPendingOrders = selfOrders.Where(o => o.Status == (int)WrapperStatusEnum.accept ||
                                                    o.Status == (int)WrapperStatusEnum.email_opened ||
                                                    o.Status == (int)WrapperStatusEnum.inprogress ||
                                                    o.Status == (int)WrapperStatusEnum.order_place).Distinct();

            var candidateCompletedOrders = candidateOrders.Where(o => o.Order.TransactionId != null && o.Order.TransactionId != string.Empty &&
                                                !(o.Candidate.Id.Equals(Guid.Empty) || o.Company.Id.Equals(0)) &&
                                                o.Order.Status == (int)WrapperStatusEnum.results).Distinct();
            var selfCompleteOrders = selfOrders.Where(o => o.Status == (int)WrapperStatusEnum.results).Distinct();

            var cancelOrders = candidateOrders.Where(o => o.Order.TransactionId != null && o.Order.TransactionId != string.Empty &&
                                                    !(o.Candidate.Id.Equals(Guid.Empty) || o.Company.Id.Equals(0)) &&
                                                    (o.Order.Status == (int)WrapperStatusEnum.reject || o.Order.Status == (int)WrapperStatusEnum.error)).Distinct();
            var selfCancelOrders = selfOrders.Where(o => o.Status == (int)WrapperStatusEnum.reject || o.Status == (int)WrapperStatusEnum.error).Distinct();


            var incompleteOrders = candidateOrders.Where(o => o.Order.TransactionId != null && o.Order.TransactionId != string.Empty &&
                                                        (o.Candidate.Id.Equals(Guid.Empty) || o.Company.Id.Equals(0)) && o.Order.Status != (int)WrapperStatusEnum.reject).Distinct();

            var pendings = (candidatePendingOrders.ToList().Count) + (selfPendingOrders.ToList().Count);
            var completes = (candidateCompletedOrders.ToList().Count) + (selfCompleteOrders.ToList().Count);
            var canceled = (cancelOrders.ToList().Count) + (selfCancelOrders.ToList().Count);
            var incomplete = incompleteOrders.Count();

            tupleList.Add(Tuple.Create(pendings, (int)TazWorksStatus.PENDING));
            tupleList.Add(Tuple.Create(completes, (int)TazWorksStatus.READY));
            tupleList.Add(Tuple.Create(canceled, (int)TazWorksStatus.CANCELED));
            tupleList.Add(Tuple.Create(incomplete, (int)TazWorksStatus.INCOMPLETE));

            return tupleList;
        }

        public List<PaymentWalletHistory> GetPaymentWalletHistroy(int userId)
        {
            return _dbContext.PaymentWalletHistors.Where(p => p.UserId == userId).ToList();
        }

        public List<CandidateViewModal> GetExistsApplicanDetail(int userId)
        {
            var CandidateViewModal = new List<CandidateViewModal>();

            var query = from p in _dbContext.Candidates
                        where p.UserId == userId
                        group p by p.Email into g
                        select new
                        {
                            FirstName = g.FirstOrDefault().FirstName,
                            LastName = g.FirstOrDefault().LastName,
                            Email = g.FirstOrDefault().Email,
                            Description = g.FirstOrDefault().Description,
                            Id = g.FirstOrDefault().Id
                        };

            var result = query.ToList();

            foreach (var item in result)
            {
                var candidate = new CandidateViewModal()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Description = item.Description,
                    Id = item.Id
                };

                CandidateViewModal.Add(candidate);
            }

            return CandidateViewModal;
        }

        public void LogError(Exception ex)
        {
            try
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }
            catch (Exception exception)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            }
        }

        #endregion
    }
}