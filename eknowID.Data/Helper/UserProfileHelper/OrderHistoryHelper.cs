using System;
using System.Collections.Generic;
using System.Linq;
using EknowIDData.Interfaces;
using EknowIDModel;
using EknowIDData.Implementations;
using System.Data.Objects;

namespace EknowIDData.Helper.UserProfileHelper
{
    public class OrderHistoryHelper
    {
        public static List<OrderHistory> GetOrders(int userID, bool isAdmin)
        {
            return GetOrders(userID, isAdmin, string.Empty, string.Empty, string.Empty);
        }

        public static List<OrderHistory> GetOrders(int userID, bool isAdmin, string purchasedDate, string applicantName, string purchasedPlan)
        {
            var orderData = new List<Order>();
            var orderHistoryList = new List<OrderHistory>();

            using (EknowIDContext ctx = new EknowIDContext())
            {
                var query = (from ordstate in ctx.OrderStates
                             join order in ctx.Orders on ordstate.OrderId equals order.OrderId
                             from candidate in ctx.Candidate
                             select new { Order = order, Candidate = candidate, OrderState = ordstate });

                if (applicantName != string.Empty && purchasedDate == string.Empty && purchasedPlan == string.Empty)
                {
                    query = query.Where(t => t.Candidate.FirstName.Contains(applicantName) || t.Candidate.LastName.Contains(applicantName));
                }

                else if (purchasedDate != string.Empty && applicantName == string.Empty && purchasedPlan == string.Empty)
                {
                    DateTime dt = DateTime.Parse(purchasedDate);
                    query = query.Where(t => EntityFunctions.TruncateTime(t.Order.PurchasedDate) == EntityFunctions.TruncateTime(dt));
                }

                else if (purchasedPlan != string.Empty && applicantName == string.Empty && purchasedDate == string.Empty)
                {
                    query = query.Where(t => t.Order.Plan.Name.Contains(purchasedPlan));
                }

                else if (applicantName != string.Empty && purchasedDate != string.Empty && purchasedPlan == string.Empty)
                {
                    DateTime dt = DateTime.Parse(purchasedDate);
                    query = query.Where(t => (t.Candidate.FirstName.Contains(applicantName) || t.Candidate.LastName.Contains(applicantName)) && EntityFunctions.TruncateTime(t.Order.PurchasedDate) == EntityFunctions.TruncateTime(dt));
                }
                else if (applicantName != string.Empty && purchasedPlan != string.Empty && purchasedDate == string.Empty)
                {
                    query = query.Where(t => (t.Candidate.FirstName.Contains(applicantName) || t.Candidate.LastName.Contains(applicantName)) && t.Order.Plan.Name.Contains(purchasedPlan));
                }

                else if (purchasedDate != string.Empty && purchasedPlan != string.Empty && applicantName == string.Empty)
                {
                    DateTime dt = DateTime.Parse(purchasedDate);
                    query = query.Where(t => EntityFunctions.TruncateTime(t.Order.PurchasedDate) == EntityFunctions.TruncateTime(dt) && t.Order.Plan.Name.Contains(purchasedPlan));
                }
                else if (applicantName != string.Empty && purchasedDate != string.Empty && purchasedPlan != string.Empty)
                {
                    DateTime dt = DateTime.Parse(purchasedDate);
                    query = query.Where(t => (t.Candidate.FirstName.Contains(applicantName) || t.Candidate.LastName.Contains(applicantName)) && EntityFunctions.TruncateTime(t.Order.PurchasedDate) == EntityFunctions.TruncateTime(dt) && t.Order.Plan.Name.Contains(purchasedPlan));
                }

                if (!isAdmin)
                {
                    query = query.Where(t => t.Order.UserId == userID);
                }

                orderData = query.Select(t => t.Order).Distinct().ToList();
            }

            foreach (Order or in orderData)
            {
                orderHistoryList.Add(GetOrderHistoryByPlanId(or));
            }

            return orderHistoryList;
        }        
       

        public static List<OrderHistory> GetSearchResult(int userID, bool isAdmin, string purchasedDate, string applicantName, string purchasedPlan)
        {
            var orderData = new List<Order>();
            var orderHistoryList = new List<OrderHistory>();

            using (EknowIDContext ctx = new EknowIDContext())
            {
                var query = (from ordstate in ctx.OrderStates
                             join order in ctx.Orders on ordstate.OrderId equals order.OrderId
                             join candidate in ctx.Candidate on order.OrderId equals candidate.OrderId
                             select new { Order = order, Candidate = candidate, OrderState = ordstate });

                if (applicantName != string.Empty && purchasedDate == string.Empty && purchasedPlan != string.Empty)
                {
                    query = query.Where(t => t.Candidate.FirstName.Contains(applicantName) || t.Candidate.LastName.Contains(applicantName));
                }

                else if (purchasedDate != string.Empty && applicantName == string.Empty && purchasedPlan == string.Empty)
                {
                    DateTime dt = DateTime.Parse(purchasedDate);
                    query = query.Where(t => EntityFunctions.TruncateTime(t.Order.PurchasedDate) == EntityFunctions.TruncateTime(dt));
                }

                else if (purchasedPlan != string.Empty && applicantName == string.Empty && purchasedPlan == string.Empty)
                {
                    query = query.Where(t => t.Order.Plan.Name.Contains(purchasedPlan));
                }

                else if (applicantName != string.Empty && purchasedDate != string.Empty && purchasedPlan == string.Empty)
                {
                    DateTime dt = DateTime.Parse(purchasedDate);
                    query = query.Where(t => (t.Candidate.FirstName.Contains(applicantName) || t.Candidate.LastName.Contains(applicantName)) && EntityFunctions.TruncateTime(t.Order.PurchasedDate) == EntityFunctions.TruncateTime(dt));
                }
                else if (applicantName != string.Empty && purchasedPlan != string.Empty && purchasedDate == string.Empty)
                {
                    query = query.Where(t => (t.Candidate.FirstName.Contains(applicantName) || t.Candidate.LastName.Contains(applicantName)) && t.Order.Plan.Name.Contains(purchasedPlan));
                }

                else if (purchasedDate != string.Empty && purchasedPlan != string.Empty && applicantName == string.Empty)
                {
                    DateTime dt = DateTime.Parse(purchasedDate);
                    query = query.Where(t => EntityFunctions.TruncateTime(t.Order.PurchasedDate) == EntityFunctions.TruncateTime(dt) && t.Order.Plan.Name.Contains(purchasedPlan));
                }
                else if (applicantName != string.Empty && purchasedDate != string.Empty && purchasedPlan != string.Empty)
                {
                    DateTime dt = DateTime.Parse(purchasedDate);
                    query = query.Where(t => (t.Candidate.FirstName.Contains(applicantName) || t.Candidate.LastName.Contains(applicantName)) && EntityFunctions.TruncateTime(t.Order.PurchasedDate) == EntityFunctions.TruncateTime(dt) && t.Order.Plan.Name.Contains(purchasedPlan));
                }

                if (!isAdmin)
                {
                    query = query.Where(t => t.Order.UserId == userID);
                }

                orderData = query.Select(t => t.Order).Distinct().ToList();
            }

            foreach (Order or in orderData)
            {
                orderHistoryList.Add(GetOrderHistoryByPlanId(or));
            }

            return orderHistoryList;

            #region old


            //using (EknowIDContext ctx = new EknowIDContext())
            //{
            //    if (applicantName != string.Empty && purchasedDate == string.Empty && purchasedPlan == string.Empty)
            //    {
            //        orderStateIDs = (from ordstate in ctx.OrderStates
            //                         join order in ctx.Orders on ordstate.OrderId equals order.OrderId
            //                         join candidate in ctx.Candidate on order.OrderId equals candidate.OrderId
            //                         where (ordstate.TazWorksStatus == 2 && (candidate.FirstName.Contains(applicantName) || candidate.LastName.Contains(applicantName)))
            //                         select ordstate.OrderId).Distinct().ToList<int>();
            //    }
            //    else if (purchasedDate != string.Empty && applicantName == string.Empty && purchasedPlan == string.Empty)
            //    {
            //        DateTime dt = DateTime.Parse(purchasedDate);

            //        orderStateIDs = (from ordstate in ctx.OrderStates
            //                         join order in ctx.Orders on ordstate.OrderId equals order.OrderId
            //                         join candidate in ctx.Candidate on order.OrderId equals candidate.OrderId
            //                         where (ordstate.TazWorksStatus == 2 && EntityFunctions.TruncateTime(order.PurchasedDate) == EntityFunctions.TruncateTime(dt))
            //                         select ordstate.OrderId).Distinct().ToList<int>();
            //    }
            //    else if (purchasedPlan != string.Empty && applicantName == string.Empty && purchasedDate == string.Empty)
            //    {
            //        orderStateIDs = (from ordstate in ctx.OrderStates
            //                         join order in ctx.Orders on ordstate.OrderId equals order.OrderId
            //                         join candidate in ctx.Candidate on order.OrderId equals candidate.OrderId
            //                         where (ordstate.TazWorksStatus == 2 && (order.Plan.Name.Contains(purchasedPlan)))
            //                         select ordstate.OrderId).Distinct().ToList<int>();
            //    }
            //    else if (applicantName != string.Empty && purchasedDate != string.Empty)
            //    {
            //        DateTime dt = DateTime.Parse(purchasedDate);

            //        orderStateIDs = (from ordstate in ctx.OrderStates
            //                         join order in ctx.Orders on ordstate.OrderId equals order.OrderId
            //                         join candidate in ctx.Candidate on order.OrderId equals candidate.OrderId
            //                         where (ordstate.TazWorksStatus == 2 && ((candidate.FirstName.Contains(applicantName) || candidate.LastName.Contains(applicantName)) &&
            //                                                                (EntityFunctions.TruncateTime(order.PurchasedDate) == EntityFunctions.TruncateTime(dt))))
            //                         select ordstate.OrderId).Distinct().ToList<int>();
            //    }
            //    else if (applicantName != string.Empty && purchasedPlan != string.Empty)
            //    {
            //        orderStateIDs = (from ordstate in ctx.OrderStates
            //                         join order in ctx.Orders on ordstate.OrderId equals order.OrderId
            //                         join candidate in ctx.Candidate on order.OrderId equals candidate.OrderId
            //                         where (ordstate.TazWorksStatus == 2 && (candidate.FirstName.Contains(applicantName) || candidate.LastName.Contains(applicantName)) &&
            //                                                                (order.Plan.Name == purchasedPlan))
            //                         select ordstate.OrderId).Distinct().ToList<int>();
            //    }
            //    else if (purchasedDate != string.Empty && purchasedPlan != string.Empty)
            //    {
            //        DateTime dt = DateTime.Parse(purchasedDate);

            //        orderStateIDs = (from ordstate in ctx.OrderStates
            //                         join order in ctx.Orders on ordstate.OrderId equals order.OrderId
            //                         join candidate in ctx.Candidate on order.OrderId equals candidate.OrderId
            //                         where (ordstate.TazWorksStatus == 2 && (order.Plan.Name.Contains(purchasedPlan)) &&
            //                                                                (EntityFunctions.TruncateTime(order.PurchasedDate) == EntityFunctions.TruncateTime(dt)))
            //                         select ordstate.OrderId).Distinct().ToList<int>();
            //    }
            //    else
            //    {
            //        orderStateIDs = (from ordstate in ctx.OrderStates
            //                         join order in ctx.Orders on ordstate.OrderId equals order.OrderId
            //                         join candidate in ctx.Candidate on order.OrderId equals candidate.OrderId
            //                         where ordstate.TazWorksStatus == 2
            //                         select ordstate.OrderId).Distinct().ToList<int>();
            //    }
            //}


            //if (isAdmin)
            //{
            //    foreach (int orderID in orderStateIDs)
            //    {
            //        ISpecification<Order> orderSpc = new Specification<Order>(u => u.OrderId == orderID);
            //        Repository<Order> orderRep = new Repository<Order>();
            //        IList<Order> order = orderRep.SelectAll(orderSpc);
            //        if (order.Count > 0)
            //        {
            //            orderData.Add(order[0]);
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (int orderID in orderStateIDs)
            //    {
            //        ISpecification<Order> orderSpc = new Specification<Order>(u => u.UserId == userID && u.OrderId == orderID);
            //        Repository<Order> orderRep = new Repository<Order>();
            //        IList<Order> order = orderRep.SelectAll(orderSpc);
            //        if (order.Count > 0)
            //        {
            //            orderData.Add(order[0]);
            //        }
            //    }
            //}


            #endregion
        }

        public static List<OrderHistory> GetPendingOrderState(int userID, bool isAdmin)
        {
            List<int> orderStateIDs = null;
            List<Order> orderData = new List<Order>();
            List<OrderHistory> orderHistoryList = new List<OrderHistory>();

            using (EknowIDContext ctx = new EknowIDContext())
            {
                orderStateIDs = (from ordstate in ctx.OrderStates
                                 where ordstate.TazWorksStatus == 2
                                 select ordstate.OrderId).Distinct().ToList<int>();
            }

            if (isAdmin)
            {
                foreach (int orderID in orderStateIDs)
                {
                    ISpecification<Order> orderSpc = new Specification<Order>(u => u.OrderId == orderID);
                    Repository<Order> orderRep = new Repository<Order>();
                    IList<Order> order = orderRep.SelectAll(orderSpc);
                    if (order.Count > 0)
                    {
                        orderData.Add(order[0]);
                    }
                }
            }
            else
            {
                foreach (int orderID in orderStateIDs)
                {
                    ISpecification<Order> orderSpc = new Specification<Order>(u => u.UserId == userID && u.OrderId == orderID);
                    Repository<Order> orderRep = new Repository<Order>();
                    IList<Order> order = orderRep.SelectAll(orderSpc);
                    if (order.Count > 0)
                    {
                        orderData.Add(order[0]);
                    }
                }
            }

            foreach (Order or in orderData)
            {
                orderHistoryList.Add(GetOrderHistoryByPlanId(or));
            }

            return orderHistoryList;
        }

        public static OrderHistory GetOrderHistoryByPlanId(Order order)
        {
            OrderHistory orderHistory = new OrderHistory();
            Repository<Plan> planRepo = new Repository<Plan>("PlanId");
            Plan plan = planRepo.SelectByKey(order.PlanId.ToString());

            OrderState orderState = OrderStatusHelper.GetOrderState(order.OrderId);
            int discount;            
            orderHistory.ReportStatus = OrderStatusHelper.GetReportStatusByOrderId(order.OrderId);            
            orderHistory.OrderTypeID = order.OrderTypeID;
            orderHistory.OrderId = order.OrderId;
            orderHistory.PurchasedDate = order.PurchasedDate.ToShortDateString();
            orderHistory.Plan = plan.Name;
            orderHistory.OrderStatusId = orderState.TazWorksStatus;
            orderHistory.Price = plan.Rate;
            discount = Convert.ToInt32(order.DiscountAmt);
            if (discount == 0)
            {
                orderHistory.ReportDiscount = "-";
            }
            else
            {
                orderHistory.ReportDiscount = order.DiscountAmt.ToString();
            }

            orderHistory.Paid = order.PaidAmt;
            //orderHistory.Report = "";
            if (order.TransactionId != null)
            {
                orderHistory.TransactionId = order.TransactionId;
            }
            orderHistory.OrderTypeName = OrderStatusHelper.GetOrderTypeName(order.OrderTypeID);
            if (orderHistory.OrderTypeName == "By Profession")
            {
                orderHistory.OrderTypeName = orderHistory.OrderTypeName + " - " + ProfessionHelper.GetProfessionNameById(OrderHelper.GetOrderById(order.OrderId).ProfessionId);
            }
            if (order.OrderTypeID == 5)
            { orderHistory.Plan = "A la Carte"; }
            return orderHistory;
        }

        public static string GetPdfURL(int orderID)
        {
            string pdfUrl;
            OrderState orderState = OrderStatusHelper.GetOrderState(orderID);
            pdfUrl = orderState.URL;
            return pdfUrl;
        }
    }
}
