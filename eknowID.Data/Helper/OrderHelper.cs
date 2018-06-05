using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;

namespace EknowIDData.Helper
{
    public class OrderHelper
    {
        public static int SaveOrder(Order order)
        {
            Repository<Order> orderRepository = new Repository<Order>();
            orderRepository.Add(order);
            orderRepository.Save();
            return order.OrderId;
        }

        public static Order GetOrderById(int orderId)
        {
            Repository<Order> orderRepository = new Repository<Order>("OrderId");
            return orderRepository.SelectByKey(orderId.ToString());
        }

        public static int UpdatePayment(string TransactionID, string CorrelationID, int CouponId, int orderID, decimal discountAmt, decimal totalAmt)
        {
            Repository<Order> orderRepository = new Repository<Order>("OrderId");
            Order orders = orderRepository.SelectByKey(orderID.ToString());
            orders.TransactionId = TransactionID;
            orders.CorrelationId = CorrelationID;
            orders.DiscountAmt = discountAmt;
            orders.PaidAmt = totalAmt;
            orders.Status = 2; // TazWorksStatus = 2 x:pending

            if (CouponId > 0)
            {
                orders.CouponId = CouponId;
            }

            orderRepository.Save();
            return orders.OrderId;

        }

        public static List<PlanReport> GetPlanReportList(int OrderID)
        {
            Repository<Order> orderRepository = new Repository<Order>("OrderId");
            Order order = orderRepository.SelectByKey(OrderID.ToString());

            ISpecification<PlanReport> specPlanReport = new Specification<PlanReport>(u => u.PlanId == order.PlanId);
            Repository<PlanReport> planReportRep = new Repository<PlanReport>();
            IList<PlanReport> planReports = planReportRep.SelectAll(specPlanReport);

            return planReports.ToList<PlanReport>();
        }

        public static OrderState GetOrderStatus(int OrderId)
        {
            Repository<OrderState> repository = new Repository<OrderState>("OrderId");
            OrderState OrderState = repository.SelectByKey(OrderId.ToString());

            return OrderState;
        }

        public static void SaveMailSendLog(EmailSendLog emailSendLog)
        {
            Repository<EmailSendLog> emailSendLogRepository = new Repository<EmailSendLog>();
            emailSendLogRepository.Add(emailSendLog);
            emailSendLogRepository.Save();
        }
    }
}
