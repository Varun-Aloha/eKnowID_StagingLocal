using eknowID.AppCode;
using eknowID.Repositories;
using eknowID.Repositories.ViewModels;
using eknowID.Services;
using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;
using System;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eknowID.Pages
{
    public partial class EkentechWallet : System.Web.UI.Page, IAuthenticationRequired
    {
        PackageService packageService;

        public EkentechWallet()
        {
            packageService = new PackageService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionWrapper.LoggedUser == null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "openLoginModal", "openLoginModal()", true);
                return;
            }

            if (!Page.IsPostBack)
            {
                var response = packageService.GetWalletBalance(SessionWrapper.LoggedUser.UserId);

                lblWalletBalance.Text = response.ToString("00.00");

                BindGrid();
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

        private void BindGrid()
        {
            rptWalletHistroy.DataSource = packageService.GetPaymentWalletHistroy(SessionWrapper.LoggedUser.UserId);
            rptWalletHistroy.DataBind();
        }
    }
}