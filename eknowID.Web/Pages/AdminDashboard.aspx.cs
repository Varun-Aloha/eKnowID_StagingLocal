using eknowID.AppCode;
using eknowID.MasterPages;
using eknowID.Repositories;
using eknowID.Repositories.Constant;
using eknowID.Repositories.ViewModels;
using eknowID.Services;
using EknowIDData.Helper;
using EknowIDData.Helper.UserProfileHelper;
using EknowIDLib;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;

namespace eknowID.Pages
{
    public partial class AdminDashboard : System.Web.UI.Page, IAuthenticationRequired
    {
        public int? userType;
        PackageService packageService;

        public AdminDashboard()
        {
            packageService = new PackageService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            userType = ((newMain)this.Master).userType;

            hdnIsAdminUser.Value = userType.ToString();

            if (!Page.IsPostBack)
            {
                if (userType == (int)UserTypeEnum.SUPER_ADMIN || userType == (int)UserTypeEnum.ADMIN)
                {
                    pnlUsers.Visible = true;

                    GetUserCounts(userType, SessionWrapper.LoggedUser.UserId, SessionWrapper.LoggedUser.CompanyId);
                    BindUserGrid(userType, SessionWrapper.LoggedUser.UserId, SessionWrapper.LoggedUser.CompanyId);
                }
                else
                {
                    pnlError.Visible = true; // display error message
                    btnAdd.Visible = false; // Add new user button when user is not admin.
                }

                GetOrderCounts();
                GetApplicantUserCount();
            }
        }

        protected void lnkViewUsers_Click(object sender, EventArgs e)
        {
            if (userType == (int)UserTypeEnum.NORMAL_USER)
            {
                pnlError.Visible = true; // display error message
                btnAdd.Visible = false; // Add new user button when user is not admin.
                pnlSelfApplicant.Visible = false;//not display panel when user is normal.
                pnlOrderTypes.Visible = false;//not display panel when user is normal.
            }
            else
            {
                pnlOrderTypes.Visible = false;
                pnlUsers.Visible = true;

                BindUserGrid(userType, SessionWrapper.LoggedUser.UserId, SessionWrapper.LoggedUser.CompanyId);
            }
        }

        protected void linkSelfApplicant_Click(object sender, EventArgs e)
        {
            if (userType == (int)UserTypeEnum.NORMAL_USER)
            {
                pnlError.Visible = false; // display error message
                btnAdd.Visible = false; // Add new user button when user is not admin.
            }

            BindSelfApplicantUserGrid(userType, SessionWrapper.LoggedUser.UserId, SessionWrapper.LoggedUser.CompanyId);
        }

        protected void linkIncompleteOrders_Click(object sender, EventArgs e) {
            var orderStatus = new List<int> {
                                                (int)WrapperStatusEnum.email_opened,
                                                (int)WrapperStatusEnum.order_place,
                                                (int)WrapperStatusEnum.accept,
                                                (int)WrapperStatusEnum.inprogress
                                            };            
            cancelCandidateHeader.Style.Remove("display");
            cancelRequesterHeader.Style.Remove("display");
            BindIncompleteOrderGrid(orderStatus);
        }

        protected void linkPendingOrders_Click(object sender, EventArgs e)
        {
            var orderStatus = new List<int> {                 
                                                (int)WrapperStatusEnum.email_opened, 
                                                (int)WrapperStatusEnum.order_place, 
                                                (int)WrapperStatusEnum.accept, 
                                                (int)WrapperStatusEnum.inprogress 
                                            };
            cancelCandidateHeader.Style.Remove("display");
            cancelRequesterHeader.Style.Remove("display");
            BindOrderGrid(orderStatus);
        }

        protected void linkCompletedOrders_Click(object sender, EventArgs e)
        {
            var orderStatus = new List<int> { (int)WrapperStatusEnum.results };
            cancelCandidateHeader.Style.Add("display", "none");
            cancelRequesterHeader.Style.Add("display", "none");
            BindOrderGrid(orderStatus);
        }

        protected void linkCancelOrders_Click(object sender, EventArgs e)
        {
            var orderStatus = new List<int> { 
                                              (int)WrapperStatusEnum.reject, 
                                              (int)WrapperStatusEnum.error 
                                            };
            cancelCandidateHeader.Style.Add("display", "none");
            cancelRequesterHeader.Style.Add("display", "none");
            BindOrderGrid(orderStatus);
        }

        #region Private Methods

        private void GetApplicantUserCount()
        {
            var applicantUserCount = packageService.GetApplicantUserCount(userType, SessionWrapper.LoggedUser.UserId, SessionWrapper.LoggedUser.CompanyId);

            liteApplicantUsers.Text = Convert.ToString(applicantUserCount);
        }

        private void GetOrderCounts()
        {
            var orderCount = packageService.GetTazworkOrderStatusCount(userType, SessionWrapper.LoggedUser.UserId, SessionWrapper.LoggedUser.CompanyId);

            foreach (var item in orderCount)
            {
                switch (item.Item2)
                {
                    case (int)TazWorksStatus.PENDING:
                        litPendingOrders.Text = Convert.ToString(item.Item1);
                        break;
                    case (int)TazWorksStatus.READY:
                        litCompletedOrders.Text = Convert.ToString(item.Item1);
                        break;
                    case (int)TazWorksStatus.CANCELED:
                        litCancelOrders.Text = Convert.ToString(item.Item1);
                        break;
                    case (int)TazWorksStatus.INCOMPLETE:
                        litIncompleteOrders.Text = Convert.ToString(item.Item1);
                        break;
                }
            }
        }

        private void BindOrderGrid(List<int> orderStaus)
        {
            if (userType == (int)UserTypeEnum.NORMAL_USER)
            {
                pnlError.Visible = false; // display error message
                btnAdd.Visible = false; // Add new user button when user is not admin.
                pnlSelfApplicant.Visible = false;//not display panel when user is normal.
                pnlOrderTypes.Visible = false;//not display panel when user is normal.
            }

            pnlSelfApplicant.Visible = false;
            pnlUsers.Visible = false;
            pnlOrderTypes.Visible = true;
            hdnIsIncompleteOrder.Value = "0";
            reSendCandidateHeader.Style.Add(HtmlTextWriterStyle.Display, "table-cell");
            //sendReportCandidateHeader.Style.Add(HtmlTextWriterStyle.Display, "table-cell");
            //viewReportCandidateHeader.Style.Add(HtmlTextWriterStyle.Display, "table-cell");
            incompleteOrderCandidateHeader.Style.Add(HtmlTextWriterStyle.Display, "none");
            if(orderStaus.Contains((int)WrapperStatusEnum.accept) || orderStaus.Contains((int)WrapperStatusEnum.email_opened) || orderStaus.Contains((int)WrapperStatusEnum.inprogress) || orderStaus.Contains((int)WrapperStatusEnum.order_place)) {
                ViewPendingNotesHeader.Style.Add(HtmlTextWriterStyle.Display, "table-cell");
                selfOrdersPendingNotesHeader.Style.Add(HtmlTextWriterStyle.Display, "table-cell");
            } else {
                ViewPendingNotesHeader.Style.Add(HtmlTextWriterStyle.Display, "none");
                selfOrdersPendingNotesHeader.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            if (orderStaus.Contains((int)WrapperStatusEnum.results)) {
                sendReportCandidateHeader.Style.Add(HtmlTextWriterStyle.Display, "table-cell");
                viewReportCandidateHeader.Style.Add(HtmlTextWriterStyle.Display, "table-cell");
            }
            else {
                sendReportCandidateHeader.Style.Add(HtmlTextWriterStyle.Display, "none");
                viewReportCandidateHeader.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            reptCandidateOrder.DataSource = packageService.GetAllCandidateOrderByStatus(userType, orderStaus, SessionWrapper.LoggedUser.UserId, SessionWrapper.LoggedUser.CompanyId) ?? new List<TazworkOrderStatusModal>();
            reptCandidateOrder.DataBind();

            reptRequesterOrder.DataSource = packageService.GetAllRequestorOrderByStatus(userType, orderStaus, SessionWrapper.LoggedUser.UserId, SessionWrapper.LoggedUser.CompanyId) ?? new List<TazworkOrderStatusModal>();
            reptRequesterOrder.DataBind();
        }

        private void BindIncompleteOrderGrid(List<int> orderStaus) {
            if (userType == (int)UserTypeEnum.NORMAL_USER) {
                pnlError.Visible = false; // display error message
                btnAdd.Visible = false; // Add new user button when user is not admin.
                pnlSelfApplicant.Visible = false;//not display panel when user is normal.
                pnlOrderTypes.Visible = false;//not display panel when user is normal.
            }

            pnlSelfApplicant.Visible = false;
            pnlUsers.Visible = false;
            pnlOrderTypes.Visible = true;
            hdnIsIncompleteOrder.Value = "1";
            reSendCandidateHeader.Style.Add(HtmlTextWriterStyle.Display, "none");
            sendReportCandidateHeader.Style.Add(HtmlTextWriterStyle.Display, "none");
            viewReportCandidateHeader.Style.Add(HtmlTextWriterStyle.Display, "none");
            incompleteOrderCandidateHeader.Style.Add(HtmlTextWriterStyle.Display, "table-cell");
            ViewPendingNotesHeader.Style.Add(HtmlTextWriterStyle.Display, "none");
            selfOrdersPendingNotesHeader.Style.Add(HtmlTextWriterStyle.Display, "none");

            reptCandidateOrder.DataSource = packageService.GetAllCandidateIncompleteOrderByStatus(userType, orderStaus, SessionWrapper.LoggedUser.UserId, SessionWrapper.LoggedUser.CompanyId) ?? new List<TazworkOrderStatusModal>();
            reptCandidateOrder.DataBind();

            reptRequesterOrder.DataSource = new List<TazworkOrderStatusModal>();
            reptRequesterOrder.DataBind();
        }

       

        private void GetUserCounts(int? userType, int userId, int? companyId)
        {
            litUsers.Text = Convert.ToString(packageService.GetUserCounts(userType, userId, companyId));
        }

        public void BindUserGrid(int? userType, int userId, int? companyId)
        {
            pnlSelfApplicant.Visible = false;
            pnlOrderTypes.Visible = false;

            rptUsers.DataSource = packageService.GetUsersLists(userType, userId, companyId);
            rptUsers.DataBind();
        }

        public void BindSelfApplicantUserGrid(int? userType, int userId, int? companyId)
        {
            pnlUsers.Visible = false;
            pnlOrderTypes.Visible = false;
            pnlSelfApplicant.Visible = true;

            rptApplicantUser.DataSource = packageService.GetApplicantUser(userType, userId, companyId);

            rptApplicantUser.DataBind();
        }

        #endregion

        #region Web Methods
        [WebMethod]
        public static void DeletePendingOrder(int orderId, int orderStatus) {
            if (orderStatus == (int)WrapperStatusEnum.email_opened || orderStatus == (int)WrapperStatusEnum.accept ||
                    orderStatus == (int)WrapperStatusEnum.inprogress || orderStatus == (int)WrapperStatusEnum.order_place) {
                //Change order status to cancelled.
                OrderStatusHelper.UpdateOrderStatus(orderId, (int)TazWorksStatus.CANCELED);
            }
        }

        [WebMethod]
        public static bool DeleteUserByAdmin(int userId)
        {
            var packageService = new PackageService();
            return packageService.DeleteUserById(userId);
        }

        [WebMethod]
        public static bool UpdateUserDetail(User user)
        {
            var packageService = new PackageService();
            return packageService.UpdateUserDetail(user);
        }

        [WebMethod]
        public static bool UpdateCandidateEmail(int orderId, string email)
        {
            var packageService = new PackageService();
            return packageService.UpdateCandidateEmail(orderId, email);
        }

        [WebMethod]
        public static bool AddUpdateOrderPendingNotes(int orderId, string pendingNote) {
            var packageService = new PackageService();
            return packageService.AddUpdateOrderPendingNotes(orderId, pendingNote);
        }

        [WebMethod]
        public static bool UpdateOrderExtraCharges(int orderId, decimal? amount, string description) {
            if (null != amount && 0 < amount) {
                var packageService = new PackageService();
                return packageService.UpdateOrderExtraCharges(orderId, amount, description);
            }
            return false;
        }

        [WebMethod]
        public static PlanViewModal GetIncludeReportList(int orderId)
        {
            var packageService = new PackageService();
            return packageService.GetIncludeReportList(orderId);
        }

        [WebMethod]
        public static OrderState GetOrderStatus(int orderId)
        {
            var orderState = new OrderState();
            var packageService = new PackageService();
          
            var orderStatus = packageService.GetOrderStatus(orderId);            
            
            switch (orderStatus.Status)
            {
                case (int)TazWorksStatus.ERROR:
                case (int)TazWorksStatus.CANCELED:
                case (int)TazWorksStatus.FAILED:
                    orderState.URL = "../Htmls/OrderError.htm";
                    break;
                case (int)TazWorksStatus.READY:
                    var orderStateStatus = packageService.GetOrderStateStatus(orderId);
                    TimeSpan orderTimeSpan = System.DateTime.Today - new System.DateTime(orderStatus.PurchasedDate.Year, orderStatus.PurchasedDate.Month, orderStatus.PurchasedDate.Day);                   
                    orderState.URL = (orderTimeSpan.Days <= 365) ? orderStateStatus.URL : "../Htmls/OrderExpired.html"; ;
                    break;
                default:
                    orderState.URL = "../Htmls/OrderInProgress.htm";
                    break;
            }

            return orderState;
        }

        [WebMethod]
        public static bool SendPdfToEmail(int orderId)
        {
            var packageService = new PackageService();

            var pdf = new CreatePDF(orderId);
            pdf.UrlTOPDF(packageService.GetOrderStateStatus(orderId).URL);
            
            return SendMail.Sendmail(orderId);
        }

        private static string GetFilePath() {
            string path = string.Format("{0}{1}", Constant.CURRENT_DIRECTORY, "pdfs");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        [WebMethod]
        public static bool IsCompnayProfilePresent()
        {
            var packageService = new PackageService();

            return packageService.IsCompanyProfilePresent(SessionWrapper.LoggedUser.UserId);
        }

        [WebMethod]
        public static Order ResentCandidateEmail(int orderId)
        {
            var packageService = new PackageService();

            return packageService.ResendCandidateEmail(orderId);
        }

        [WebMethod]
        public static bool CompleteCandidateOrder(int orderId) {
            SessionWrapper.PaymentOrderId = orderId;
            return true;
        }

        [WebMethod]
        public static bool DownloadOrderStatusReport(int orderId) {
            try {
                string PDF_File_Path = GetFilePath() + "\\" + orderId.ToString() + ".pdf";
                string encrypted_PDF_File_Path = GetFilePath() + "\\E" + orderId.ToString() + ".pdf";

                if (!File.Exists(PDF_File_Path)) {
                    var packageService = new PackageService();
                    var pdf = new CreatePDF(orderId);
                    pdf.UrlTOPDF(packageService.GetOrderStateStatus(orderId).URL);
                }

                if (!File.Exists(encrypted_PDF_File_Path)) {
                    FileStream stream = File.OpenRead(PDF_File_Path);

                    int length = Convert.ToInt32(stream.Length);
                    byte[] data = new byte[length];
                    stream.Read(data, 0, length);
                    stream.Close();
                    using (MemoryStream input = new MemoryStream(data)) {
                        using (MemoryStream output = new MemoryStream()) {
                            eknowID.Model.Candidate candidate = UserHelper.GetCandidateByOrderId(orderId);
                            string password = candidate.Email;
                            PdfReader reader = new PdfReader(input);
                            PdfEncryptor.Encrypt(reader, output, true, password, password, PdfWriter.ALLOW_SCREENREADERS);
                            data = output.ToArray();
                        }
                    }

                    File.WriteAllBytes(encrypted_PDF_File_Path, data);
                }
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        [WebMethod]
        public static bool PrintOrderStatusReportPdf(int orderId) {
            try {
                string PDF_File_Path = GetFilePath() + "\\" + orderId.ToString() + ".pdf";               

                if (!File.Exists(PDF_File_Path)) {
                    var packageService = new PackageService();
                    var pdf = new CreatePDF(orderId);
                    pdf.UrlTOPDF(packageService.GetOrderStateStatus(orderId).URL);
                }               
                return true;
            } catch (Exception ex) {
                return false;
            }
        }

        #endregion               
    }
}