using eknowID.Repositories.Constant;
using eknowID.Repositories.ViewModels;
using System;
using System.Linq;
using Wrapper.Model;

namespace eknowID.Repositories.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        #region Public Methods

        /// <summary>
        /// Update tazwork status
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <param name="actionType"></param>
        /// <param name="assessmentViewModel"></param>
        /// <returns></returns>
        public bool UpdateTazworkOrderStatus(string assessmentId, string actionType, AssessmentViewModel assessmentViewModel)
        {
            Guid assmntId;
            if (!Guid.TryParse(assessmentId, out assmntId)) return false;

            //parse enum and get tazwork status
            WrapperStatusEnum status;
            if (!Enum.TryParse(actionType, out status)) return false;

            var orderId = UpdateAssessmentStatus(assmntId, (int)status);

            if (orderId == 0) return false;

            var odrStatus = new OrderState()
            {
                InsertTime = System.DateTime.Now,
                OrderId = orderId,
                TazWorksOrderId = 0, // set default tazWorkOrder id it's order id is contain in wrapperdb database table
                TazWorksStatus = (int)status,
                URL = assessmentViewModel.result ?? string.Empty
            };

            _dbContext.OrderStates.Add(odrStatus);
            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Get all newly created assessment
        /// </summary>
        /// <returns></returns>
        public AssessmentList GetAllNewAssessment()
        {
            _dbContext.Configuration.LazyLoadingEnabled = true;

            var applicantOrderType = _dbContext.OrderTypes.Where(o => o.OrderTypeName == "Applicant/Candidate").FirstOrDefault().OrderTypeID;

            var result = (from requestor in _dbContext.Users
                          join candi in _dbContext.Candidates on requestor.UserId equals candi.UserId
                          join compny in _dbContext.Companies on requestor.CompanyId equals compny.Id
                          join order in _dbContext.Orders on candi.OrderId equals order.OrderId
                          where order.Status == (int)WrapperStatusEnum.order_place && order.OrderTypeID == applicantOrderType
                          select new Content
                          {
                              alacarteReport = new AlacarteReport { ReportDetails = (from report in _dbContext.Reports join alacartRpt in _dbContext.AlacartReports on report.ReportId equals alacartRpt.ReportId join o in _dbContext.Orders on alacartRpt.OrderId equals o.OrderId where order.Status == (int)WrapperStatusEnum.order_place && order.OrderTypeID == applicantOrderType && order.OrderId == o.OrderId
                                                                                     select new AlacarteReportDetails { ReportName = report.Name, Qty = alacartRpt.Qty, StatesSelected = alacartRpt.StatesSelected, Counties_DistrictsSelected = alacartRpt.Couty_DistrictsSelected }).ToList()},
                              Id = order.AssessmentId,
                              CreateDate = order.PurchasedDate,
                              Candidate = new AssessmentCandidate { FirstName = candi.FirstName, LastName = candi.LastName, Email = candi.Email, Id = candi.Id },
                              Company = new AssessmentCompany { Id = compny.Id, Name = compny.Name },
                              Requestor = new AssessmentRequester { Email = requestor.Email, FirstName = requestor.FirstName, LastName = requestor.LastName, Phone = compny.CompanyPhone },
                              WrapperPartnerId = EknowIdConstant.WrapperPartnerApiKey,
                              Offer = new Offer { CatalogId = (order.PlanId == 20 ? EknowIdConstant.ExpressLiteOffer : order.PlanId == 21 ? EknowIdConstant.StandardOffer : order.PlanId == 22 ? EknowIdConstant.TopHireOffer : ""), Name = string.Empty }
                          }).ToList();

            return new AssessmentList
            {
                Content = result,
                TotalFound = result.Count()
            };
        }

        /// <summary>
        /// Update ReSendEmail flag false
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateEknowIDResendAssessmnet(string id)
        {
            Guid assmntId;
            if (!Guid.TryParse(id, out assmntId)) return false;

            var orderDetail = _dbContext.Orders.Where(p => p.AssessmentId == assmntId).FirstOrDefault();

            if (orderDetail == null) return false;

            orderDetail.IsResendEmail = false;
            orderDetail.Status = (int)WrapperStatusEnum.accept;

            _dbContext.Entry(orderDetail).State = System.Data.Entity.EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Get all resend email assessment when ReSendEmail is set to true
        /// </summary>
        /// <returns></returns>
        public AssessmentList GetAllResentAssessments()
        {
            _dbContext.Configuration.LazyLoadingEnabled = true;

            var applicantOrderType = _dbContext.OrderTypes.Where(o => o.OrderTypeName == "Applicant/Candidate").FirstOrDefault().OrderTypeID;

            var result = (from order in _dbContext.Orders
                          where order.IsResendEmail == true && order.OrderTypeID == applicantOrderType
                          select new Content
                          {
                              Id = order.AssessmentId,
                          }).ToList();

            return new AssessmentList
            {
                Content = result,
                TotalFound = result.Count()
            };
        }

        /// <summary>
        /// Update assessment status in order table
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdateAssessmentStatus(Guid assessmentId, int status)
        {
            var orderDetail = _dbContext.Orders.Where(assmnt => assmnt.AssessmentId == assessmentId).FirstOrDefault();

            if (orderDetail == null) return 0;

            orderDetail.Status = status;
            _dbContext.Entry(orderDetail).State = System.Data.Entity.EntityState.Modified;
            _dbContext.SaveChanges();

            return orderDetail.OrderId;
        }
        
        /// <summary>
        /// Update refund detials in Order table
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="refundAmount"></param>
        public void UpdateRefundDetails(int orderId, decimal refundAmount) {
            var orderDetail = _dbContext.Orders.Where(order => order.OrderId == orderId).FirstOrDefault();

            if (orderDetail == null) return;
            if (null != orderDetail.RefundAmt)
            {
                orderDetail.RefundAmt += refundAmount;
            }
            else
            {
                orderDetail.RefundAmt = refundAmount;
            }
            _dbContext.Entry(orderDetail).State = System.Data.Entity.EntityState.Modified;
            _dbContext.SaveChanges();
        }        

        #endregion
    }
}