using EknowIDData.Implementations;
using EknowIDData.Interfaces;
using EknowIDModel;
using System.Collections.Generic;
using System.Linq;

namespace EknowIDData.Helper
{
    public class OrderStatusHelper
    {

        public static bool UpdateOrderStatus(int orderId, int orderStatus)
        {
            using (EknowIDContext ctx = new EknowIDContext())
            {
                var orderDetail = ctx.Orders.Where(odr => odr.OrderId == orderId).FirstOrDefault();

                if (orderDetail != null)
                {
                    orderDetail.Status = orderStatus;
                    return ctx.SaveChanges() > 0;
                }

                return false;
            }
        }

        public static int SaveOrderState(OrderState orderState)
        {
            Repository<OrderState> orderStateRepository = new Repository<OrderState>();
            orderStateRepository.Add(orderState);
            orderStateRepository.Save();
            return orderState.OrderId;
        }

        public static OrderState GetOrderState(int orderID)
        {
            ISpecification<OrderState> OrederStSpc = new Specification<OrderState>(os => os.OrderId == orderID);
            IRepository<OrderState> orderstate = new Repository<OrderState>();
            OrderState orderst = orderstate.SelectAll(OrederStSpc).LastOrDefault();
            return orderst;
        }

        public static string GetReportStatusByOrderId(int orderId)
        {
            using (EknowIDContext ctx = new EknowIDContext())
            {
                var invitationorderStatus = (from order in ctx.Orders where order.OrderId == orderId select order.Status).FirstOrDefault();
                var orderStatus = (from oderStatus in ctx.OrderStates where oderStatus.OrderId == orderId select oderStatus.TazWorksStatus).FirstOrDefault();

                if (invitationorderStatus == 1)
                    return "Email Invite Sent";
                else if (orderStatus == 10)
                    return "Completed";
                else if (orderStatus == 7)
                    return "Applicant Pending";
                else if (orderStatus == 12)
                    return "Research under way";
                else if (orderStatus == 2)
                    return "Pending";
                else if (orderStatus == 3)
                    return "Failed";
                else if (orderStatus == 4)
                    return "Completed";
                else if (orderStatus == 6)
                    return "Canceled";
                else if (orderStatus == 8)
                    return "Applicant Process";
                else if (orderStatus == 9)
                    return "Error";
                else
                    return string.Empty;
            }
        }

        public static List<int> GetPendingOrders()
        {
            using (EknowIDContext ctx = new EknowIDContext())
            {
                var applicantOrderType = ctx.OrderType.Where(o => o.OrderTypeName == "Applicant/Candidate").FirstOrDefault();

                if (applicantOrderType == null)
                    return null;

                var query = (from order in ctx.Orders
                             join orderStates in ctx.OrderStates on new { order.OrderId } equals new { orderStates.OrderId }
                             where order.OrderTypeID != applicantOrderType.OrderTypeID && orderStates.TazWorksStatus == 2
                             select orderStates.OrderId);

                return query.Distinct().ToList();
            }
        }

        public static List<string> GetReportList(int orderID)
        {
            List<string> lstReport = new List<string>();

            using (EknowIDContext ctx = new EknowIDContext())
            {
                lstReport = (from order in ctx.Orders
                             join planReport in ctx.PlanReports on new { order.PlanId } equals new { planReport.PlanId }
                             join report in ctx.Reports on new { planReport.ReportId } equals new { report.ReportId }
                             where order.OrderId == orderID
                             select report.Name).ToList<string>();
            }
            return lstReport;
        }
        public static List<AlacartReport> GetAdditionalReportList(int orderID)
        {
            ISpecification<AlacartReport> alacarteSpec = new Specification<AlacartReport>(a => a.OrderId == orderID);
            Repository<AlacartReport> alacarteRep = new Repository<AlacartReport>();
            IList<AlacartReport> alacarteReports = alacarteRep.SelectAll(alacarteSpec);

            return alacarteReports.ToList<AlacartReport>();
        }

        public static string GetOrderTypeName(int OrderTypeID)
        {
            string moduleName;
            Repository<OrderType> OrderTypeRepo = new Repository<OrderType>("OrderTypeID");
            OrderType OrderType = OrderTypeRepo.SelectByKey(OrderTypeID.ToString());
            return moduleName = OrderType.OrderTypeName;


        }

        public static List<Report> GetAdditionalReports(int orderID)
        {
            List<Report> lstReport = new List<Report>();

            using (EknowIDContext ctx = new EknowIDContext())
            {
                lstReport = (from alacartReports in ctx.AlacartReport
                             join report in ctx.Reports on new { alacartReports.ReportId } equals new { report.ReportId }
                             where alacartReports.OrderId == orderID
                             select report).ToList<Report>();
            }
            return lstReport;
        }

        public static List<string> GetAdditionalReportNameList(int orderID)
        {
            List<string> lstReport = new List<string>();

            using (EknowIDContext ctx = new EknowIDContext())
            {
                lstReport = (from alacartReports in ctx.AlacartReport
                             join report in ctx.Reports on new { alacartReports.ReportId } equals new { report.ReportId }
                             where alacartReports.OrderId == orderID
                             select report.Name).ToList<string>();
            }
            return lstReport;
        }
    }
}
