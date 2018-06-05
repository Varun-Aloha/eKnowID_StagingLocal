using eknowID.AppCode;
using eknowID.Repositories;
using eknowID.Repositories.ViewModels;
using eknowID.Services;
using EknowIDLib;
using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;
using System;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.Repositories.Constant;
using EknowIDData.Helper;
using eknowID.MasterPages;

namespace eknowID.Pages
{
    public partial class YourWallet : System.Web.UI.Page, IAuthenticationRequired
    {
        public int? userType;
        PackageService packageService;
        private AssessmentOrderService orderService;
        public YourWallet()
        {
            packageService = new PackageService();
            orderService = new AssessmentOrderService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            userType = ((newMain)this.Master).userType;
            hdnUserType.Value = ((UserTypeEnum) userType).ToString();

            if (SessionWrapper.LoggedUser == null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "openLoginModal", "openLoginModal()", true);
                return;
            }

            //if (!Page.IsPostBack)
            //{
                var userId = null != Request.QueryString["user_Id"] ? int.Parse(Request.QueryString["user_Id"]) : SessionWrapper.LoggedUser.UserId;
                var response = packageService.GetWalletBalance(userId);

                lblWalletBalance.Text = response.ToString("00.00");
                BindGrid(userId);
                PopulateUsers(userId);
                hdnUserId.Value = userId.ToString();
            //}
        }

        private void PopulateUsers(int userId) {
            if (SessionWrapper.LoggedUser != null && (SessionWrapper.LoggedUser.UserType ?? 3) == (int)UserTypeEnum.SUPER_ADMIN)
            {
                var activeUsers = packageService.GetAllActiveUsersLists((int) UserTypeEnum.SUPER_ADMIN);
                ddlUsers.DataTextField = "FullName";
                ddlUsers.DataValueField = "UserId";
                ddlUsers.DataSource = activeUsers.OrderBy(u => u.FullName);
                ddlUsers.DataBind();
            }
            else
            {
                selectWalletUsers.Visible = false;
            }          
            ddlUsers.Items.Insert(0, new ListItem("Select", "0"));
            ddlUsers.SelectedIndex = 0;
            if (null != ddlUsers.Items.FindByValue(userId.ToString()))
            {
                ddlUsers.ClearSelection();
                ddlUsers.Items.FindByValue(userId.ToString()).Selected = true;
            }
        }

        [WebMethod]
        public static ResponseModel RequesterMakePayment(PaymentWalletModal paymentWalletModal)
        {
            var paymentResponse = MakePayment(paymentWalletModal);

            if (paymentResponse == null)
                return new ResponseModel(true, "Some technical issue is occur. Please try after some time");


            if (paymentResponse.Ack.Value == AckCodeType.SUCCESS || paymentResponse.Ack.Value == AckCodeType.SUCCESSWITHWARNING)
            {
                var packageService = new PackageService();

                var paymentWallet = new PaymentWalletHistory()
                {
                    Deposite = Convert.ToDecimal(paymentWalletModal.Amount),
                    InsertedDate = DateTime.Now,
                    UserId = SessionWrapper.LoggedUser.UserId,
                    TransactionId = paymentResponse.TransactionID
                };

                var response = packageService.AddMoneyToWallet(paymentWallet);

                return new ResponseModel(false, string.Empty);
            }

            else if (paymentResponse.Ack.Value == AckCodeType.FAILURE)
            {
                var errorType = paymentResponse.Errors;
                if (errorType != null)
                {
                    string errorMessage = errorType[0].LongMessage ?? errorType[0].ShortMessage ?? "Please try again some time!"; ;

                    return new ResponseModel(true, errorMessage);
                }
                else
                {
                    return new ResponseModel(true, "Please try again later?");
                }
            }
            return new ResponseModel(true, "Some technical issue is occur. Please try after some time");
        }

        private static DoDirectPaymentResponseType MakePayment(PaymentWalletModal paymentModel)
        {
            // Create request object
            var request = new DoDirectPaymentRequestType();
            var requestDetails = new DoDirectPaymentRequestDetailsType();
            request.DoDirectPaymentRequestDetails = requestDetails;

            var creditCard = new CreditCardDetailsType();
            requestDetails.CreditCard = creditCard;
            var payer = new PayerInfoType();

            creditCard.CardOwner = payer;

            creditCard.CreditCardNumber = paymentModel.CardNumber;

            creditCard.CreditCardType = (CreditCardTypeType)
                Enum.Parse(typeof(CreditCardTypeType), paymentModel.CardType.ToUpper());
            creditCard.CVV2 = paymentModel.SecurityCode;

            creditCard.ExpMonth = Convert.ToInt32(paymentModel.ExpMonth);
            creditCard.ExpYear = Convert.ToInt32(paymentModel.ExpYear);

            requestDetails.PaymentDetails = new PaymentDetailsType();

            CurrencyCodeType currency = (CurrencyCodeType)
                Enum.Parse(typeof(CurrencyCodeType), "USD");
            var paymentAmount = new BasicAmountType(currency, paymentModel.Amount);
            requestDetails.PaymentDetails.OrderTotal = paymentAmount;

            // Invoke the API
            var wrapper = new DoDirectPaymentReq();
            wrapper.DoDirectPaymentRequest = request;

            var service = new PayPalAPIInterfaceServiceService();

            // API call             
            return service.DoDirectPayment(wrapper);
        }

        [WebMethod]
        public static ResponseModel RefundToUsersWallet(RefundWalletModel refundModel)
        {
            try {

                AddMoneyToUsersWallet(refundModel.UserId, refundModel.RefundAmount, refundModel.BuyerNote);

                if (refundModel.OrderStatus == (int)WrapperStatusEnum.email_opened || refundModel.OrderStatus == (int)WrapperStatusEnum.accept || 
                    refundModel.OrderStatus == (int)WrapperStatusEnum.inprogress || refundModel.OrderStatus == (int)WrapperStatusEnum.order_place) {
                    //Change order status to cancelled.
                    OrderStatusHelper.UpdateOrderStatus(refundModel.OrderId, (int)TazWorksStatus.CANCELED);
                }

               //Update refund details in Order table
                var orderService = new AssessmentOrderService();
                orderService.UpdateRefundDetails(refundModel.OrderId, refundModel.RefundAmount);                
                return new ResponseModel(false, string.Empty);
            } catch (Exception ex)
            {
                return new ResponseModel(false, ex.Message);
            }
        }

        [WebMethod]
        public static ResponseModel AddMoneyToUsersWallet(int userId, decimal amount, string note) {
            try {
                var packageService = new PackageService();

                var paymentWallet = new PaymentWalletHistory() {
                    Deposite = Convert.ToDecimal(amount),
                    InsertedDate = DateTime.Now,
                    UserId = userId,
                    TransactionId = note
                };

                //Update refund details in WalletBalance & PaymentWalletHistory table 
                var response = packageService.AddMoneyToWallet(paymentWallet);
                return new ResponseModel(false, string.Empty);
            } catch (Exception ex) {
                return new ResponseModel(true, ex.Message);
            }
        }

        private void BindGrid(int userId)
        {
            rptWalletHistroy.DataSource = packageService.GetPaymentWalletHistroy(userId);
            rptWalletHistroy.DataBind();
        }
    }
}