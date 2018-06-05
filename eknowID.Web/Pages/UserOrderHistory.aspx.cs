using eknowID.AppCode;
using EknowIDData.Helper;
using EknowIDData.Helper.UserProfileHelper;
using EknowIDLib;
using EknowIDModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace eknowID.Pages
{
    public partial class UserOrderHistory : BasePage, IAuthenticationRequired
    {
        private SortOrder currentSortOrder;
        private string currentSortColumn;
        public bool isAdminUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            isAdminUser = ((main)this.Master).isAdminUser;

            txtPurchasedDate.Attributes.Add("readonly", "readonly");

            if (!IsPostBack)
            {
                currentSortColumn = "OrderId";
                currentSortOrder = SortOrder.Descending;
                BindGrid();
            }
            else
            {
                this.currentSortOrder = (SortOrder)ViewState["SortOrder"];
                this.currentSortColumn = ViewState["SortColumn"].ToString();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["SortOrder"] = currentSortOrder;
            ViewState["SortColumn"] = currentSortColumn;

            AddSortingImage(grvOrderHistory, currentSortOrder, currentSortColumn);
        }

        private void AddSortingImage(GridView gridView, SortOrder currentSortOrder, string currentSortColumn)
        {
            if ((gridView.Rows.Count == 0) || (string.IsNullOrEmpty(currentSortColumn)))
                return;

            Image orderImage = new Image();
            Image PurchaseImage = new Image();
            orderImage.EnableTheming = false;

            if (currentSortOrder == SortOrder.Ascending)
            {
                orderImage.ImageUrl = "~/Images/desc.gif";
                PurchaseImage.ImageUrl = "~/Images/desc.gif";
            }
            else
            {
                orderImage.ImageUrl = "~/Images/asc.gif";
                PurchaseImage.ImageUrl = "~/Images/asc.gif";
            }

            gridView.HeaderRow.Cells[0].Controls.Add(PurchaseImage);
        }

        protected void grvOrderHistory_Sort(object sender, EventArgs e)
        {
            if (sender is LinkButton)
            {
                LinkButton gridHeader = (LinkButton)sender;
                string newSortColumn = gridHeader.CommandArgument;
                this.currentSortColumn = gridHeader.CommandArgument;
                if (newSortColumn == "OrderId")
                {
                    if (currentSortOrder == SortOrder.Ascending)
                        currentSortOrder = SortOrder.Descending;

                    else
                        currentSortOrder = SortOrder.Ascending;
                }
                grvOrderHistory.SelectedIndex = -1;
                BindGrid();
            }
        }

        protected void grvOrderHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvOrderHistory.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        private void BindGrid()
        {
            List<OrderHistory> orders = OrderHistoryHelper.GetOrders(SessionWrapper.LoggedUser.UserId, isAdminUser);

            // Sort users
            if (currentSortColumn == "OrderId")
            {
                if (currentSortOrder == SortOrder.Ascending)
                    orders = orders.OrderBy(o => o.OrderId).ToList();

                else
                    orders = orders.OrderByDescending(o => o.OrderId).ToList();
            }
            grvOrderHistory.DataSource = orders;
            grvOrderHistory.DataBind();

        }

        protected Boolean IsOrderComplete(int orderIDStatus)
        {
            if (orderIDStatus == 10 || orderIDStatus == 4)
                return true;
            else
                return false;
        }

        protected void grvOrderHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SendPDF")
            {

                GridViewRow row = (((ImageButton)e.CommandSource).NamingContainer) as GridViewRow;
                Label orderID = (Label)row.FindControl("lblOrderID");
                int orderid = Convert.ToInt32(orderID.Text);

                CreatePDF pdf = new CreatePDF(orderid);

                pdf.UrlTOPDF(OrderHistoryHelper.GetPdfURL(orderid));
                SendMail.Sendmail(orderid);
            }
        }

        [WebMethod]
        public static OrderHistoryData GetIncludeReportList(int OrderId)
        {
            //var isAdmin = SessionWrapper.LoggedUser.Email == Constant.CONST_CMS_ADMIN_USERID ? true : SessionWrapper.LoggedUser.IsAdmin ? true : false;

            var isAdmin = null;

            OrderHistoryData orderHistoryData;
            orderHistoryData = new OrderHistoryData();
            decimal totalPrice = 0;
            List<OrderHistory> orders = OrderHistoryHelper.GetOrders(SessionWrapper.LoggedUser.UserId, isAdmin);
            OrderHistory orderHistory = orders.Where(ord => ord.OrderId == OrderId).FirstOrDefault();

            orderHistoryData.packageName = orderHistory.Plan;
            orderHistoryData.packagePrice = orderHistory.OrderTypeName != Constant.UNCOVER_BACKGROUND ? orderHistory.Price.ToString("C") : string.Empty;
            orderHistoryData.paidPrice = orderHistory.Paid.ToString("C");

            if (orderHistory.OrderTypeName != Constant.UNCOVER_BACKGROUND)
            {
                orderHistoryData.basicReportList = OrderStatusHelper.GetReportList(OrderId);
                orderHistoryData.basicReportList.Sort();
            }
            List<EknowIDModel.AlacartReport> additionalReportList = OrderStatusHelper.GetAdditionalReportList(OrderId);
            totalPrice = orderHistory.Price;
            Report report;
            AlacarteReports alacarteReport;
            List<AlacarteReports> alacartReportList = new List<AlacarteReports>();
            foreach (EknowIDModel.AlacartReport alacartReport in additionalReportList)
            {
                report = new Report();
                alacarteReport = new AlacarteReports();
                report = PlanHelper.GetReportByReportID(alacartReport.ReportId);
                alacarteReport.reportName = report.Name;
                alacarteReport.Price = report.Price.Value; ;
                totalPrice = totalPrice + report.Price.Value;
                alacartReportList.Add(alacarteReport);
            }

            orderHistoryData.totalPrice = totalPrice.ToString("C");
            orderHistoryData.additionalReportList = alacartReportList;
            orderHistoryData.OrderType = orderHistory.OrderTypeName;

            orderHistoryData.discountPrice = orderHistory.ReportDiscount;

            return orderHistoryData;

        }

        protected void btnOrderSearch_Click(object sender, EventArgs e)
        {
            List<OrderHistory> orders = OrderHistoryHelper.GetOrders(SessionWrapper.LoggedUser.UserId, isAdminUser, txtPurchasedDate.Text, txtApplicantName.Text, drpPurchasedPlan.SelectedItem.Value == "0" ? string.Empty : drpPurchasedPlan.SelectedItem.Text);

            // Sort users
            if (currentSortColumn == "OrderId")
            {
                if (currentSortOrder == SortOrder.Ascending)
                    orders = orders.OrderBy(o => o.OrderId).ToList();

                else
                    orders = orders.OrderByDescending(o => o.OrderId).ToList();
            }
            grvOrderHistory.DataSource = orders;
            grvOrderHistory.DataBind();
        }

        protected void btnCancelSearch_Click(object sender, EventArgs e)
        {
            clearControls();
            BindGrid();
        }

        private void clearControls()
        {
            txtApplicantName.Text = string.Empty;
            txtPurchasedDate.Text = string.Empty;
            drpPurchasedPlan.ClearSelection();
            drpPurchasedPlan.Items.FindByValue("0").Selected = true;
        }
    }

    public class OrderHistoryData
    {

        public int orderId { get; set; }
        public string packageName { get; set; }
        public string packagePrice { get; set; }
        public List<string> basicReportList { get; set; }
        public List<AlacarteReports> additionalReportList { get; set; }
        public string totalPrice { get; set; }
        public string paidPrice { get; set; }
        public string discountPrice { get; set; }
        public string OrderType { get; set; }
    }

    public class AlacarteReports
    {
        public string reportName { get; set; }
        public virtual Decimal? Price { get; set; }
    }
}