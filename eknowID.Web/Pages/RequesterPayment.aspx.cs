using eknowID.AppCode;
using eknowID.Repositories;
using eknowID.Services;
using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace eknowID.Pages
{
    public partial class RequesterPayment : System.Web.UI.Page, IAuthenticationRequired
    {
        PackageService packageService;
        protected void Page_Load(object sender, EventArgs e)
        {
            packageService = new PackageService();

            if (SessionWrapper.LoggedUser == null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "openLoginModal", "openLoginModal()", true);
                return;
            }
            if (SessionWrapper.SelectedPlanType == 0)
            {
                Response.Redirect("../Pages/ApplicantPackages.aspx");
                return;
            }

            if (!Page.IsPostBack)
            {                               
                var selectedPlan = packageService.GetSelectedPlanType(SessionWrapper.SelectedPlanType);
                var totalPrice = SessionWrapper.TotalReportPrice;
                var alacartReportList = packageService.GetReportList(SessionWrapper.AlacartReportList);

                hdnTotalPrice.Value = totalPrice;               
                lblPlanName.Text = selectedPlan.Name;
                lblPrice.Text = totalPrice;
                hdnPrice.Value = totalPrice;

                var rprts = new List<string>();

                foreach (var plnRprt in selectedPlan.PlanReports)
                {
                    rprts.Add(plnRprt.Report.Name);
                }

                foreach (var rprt in alacartReportList)
                {
                    rprts.Add(rprt);
                }

                rptrPlnRprts.DataSource = rprts;
                rptrPlnRprts.DataBind();
            }

            var walletBalance = packageService.GetWalletBalance(SessionWrapper.LoggedUser.UserId);
            hdnWalletBalance.Value = walletBalance.ToString("00.00");
            lblWalletBalance.Text = walletBalance.ToString("00.00"); // wallet balance
        }

        [WebMethod]
        public static ResponseModel RequesterMakePayment(PaymentModel paymentModel)
        {
            var PackageService = new PackageService();            
            

            paymentModel.OrderDetailModel.PlanType = SessionWrapper.SelectedPlanType;
            paymentModel.OrderDetailModel.UserId = SessionWrapper.LoggedUser.UserId;
            paymentModel.OrderDetailModel.OrderTypeId = SessionWrapper.OrderType;
            paymentModel.AlacartReportList = SessionWrapper.AlacartReportList; //Added alacarte report list id into database.
            paymentModel.AlacartReportListWithQty = SessionWrapper.AlacartReportListWithQty;
            paymentModel.SelectedStates = SessionWrapper.SelectedStates;
            paymentModel.SelectedCounties = SessionWrapper.SelectedCounties;
            paymentModel.SelectedCivilCounties = SessionWrapper.SelectedCivilCounties;
            paymentModel.SelectedDistricts = SessionWrapper.SelectedDistricts;
            paymentModel.IsCreditReportAuditingChargesPaid = SessionWrapper.IsCreditReportAuditingChargesPaid;

            try
            {
                if (paymentModel.IsFullWalletPayment)
                {
                    paymentModel.AlacartReportList = SessionWrapper.AlacartReportList;
                    paymentModel.AlacartReportListWithQty = SessionWrapper.AlacartReportListWithQty;
                    paymentModel.PaymentResponseModal.TransactionId = "0000000000000000"; // set dummy trnsaction ID for the full wallet payment.
                    int orderId = PackageService.SavePaymentDetail(paymentModel);
                    SessionWrapper.PaymentOrderId = orderId;

                    return new ResponseModel(false, string.Empty);
                }
                else
                {
                    var paymentResponse = MakePayment(paymentModel);

                    if (paymentResponse == null)
                    {
                        return new ResponseModel(true, "Some technical issue is occur. Please try after some time");
                    }

                    else if (paymentResponse.Ack.Value == AckCodeType.SUCCESS || paymentResponse.Ack.Value == AckCodeType.SUCCESSWITHWARNING)
                    {
                        paymentModel.PaymentResponseModal.TransactionId = paymentResponse.TransactionID;

                        paymentModel.AlacartReportList = SessionWrapper.AlacartReportList;
                        paymentModel.AlacartReportListWithQty = SessionWrapper.AlacartReportListWithQty;

                        int orderId = PackageService.SavePaymentDetail(paymentModel);
                        SessionWrapper.PaymentOrderId = orderId;

                        return new ResponseModel(false, string.Empty);
                    }

                    else if (paymentResponse.Ack.Value == AckCodeType.FAILURE)
                    {
                        // log into database
                        var errorType = paymentResponse.Errors;
                        if (errorType != null)
                        {
                            paymentModel.PaymentResponseModal.ErrorMessage = errorType[0].LongMessage ?? errorType[0].ShortMessage ?? "Please try again some time!"; ;
                            paymentModel.PaymentResponseModal.CorrelationId = paymentResponse.CorrelationID ?? string.Empty;

                            paymentModel.IsPaymentError = true; // set payment error falg to true.
                            var response = PackageService.SavePaymentDetail(paymentModel);
                            return new ResponseModel(true, paymentModel.PaymentResponseModal.ErrorMessage);
                        }
                        else
                        {
                            return new ResponseModel(true, "Please try again later?");
                        }
                    }
                }
            }
            catch (Exception ex) { }

            return new ResponseModel(true, "Some technical issue is occur. Please try after some time");
        }

        private static DoDirectPaymentResponseType MakePayment(PaymentModel paymentModel)
        {
            // Create request object
            var request = new DoDirectPaymentRequestType();
            var requestDetails = new DoDirectPaymentRequestDetailsType();
            request.DoDirectPaymentRequestDetails = requestDetails;

            var creditCard = new CreditCardDetailsType();
            requestDetails.CreditCard = creditCard;
            var payer = new PayerInfoType();

            // (Optional) First and last name of buyer.
            PersonNameType name = new PersonNameType();
            name.FirstName = string.Format("{0} {1}", SessionWrapper.LoggedUser.FirstName, SessionWrapper.LoggedUser.LastName);
            name.LastName = SessionWrapper.LoggedUser.Email; //pass buyer email address.
            payer.PayerName = name;

            creditCard.CardOwner = payer;

            creditCard.CreditCardNumber = paymentModel.CreditCardModel.CardNumber;

            creditCard.CreditCardType = (CreditCardTypeType)
                Enum.Parse(typeof(CreditCardTypeType), paymentModel.CreditCardModel.CardType.ToUpper());
            creditCard.CVV2 = paymentModel.CreditCardModel.SecurityCode;

            creditCard.ExpMonth = Convert.ToInt32(paymentModel.CreditCardModel.ExpMonth);
            creditCard.ExpYear = Convert.ToInt32(paymentModel.CreditCardModel.ExpYear);

            requestDetails.PaymentDetails = new PaymentDetailsType();


            CurrencyCodeType currency = (CurrencyCodeType)
                Enum.Parse(typeof(CurrencyCodeType), "USD");
            var paymentAmount = new BasicAmountType(currency, paymentModel.OrderDetailModel.TotalOrder.ToString());
            requestDetails.PaymentDetails.OrderTotal = paymentAmount;

            // Invoke the API
            var wrapper = new DoDirectPaymentReq();
            wrapper.DoDirectPaymentRequest = request;

            var service = new PayPalAPIInterfaceServiceService();

            // API call             
            return service.DoDirectPayment(wrapper);
        }
    }
}