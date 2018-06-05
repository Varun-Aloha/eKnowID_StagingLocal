using eknowID.AppCode;
using eknowID.Controls;
using EknowIDData.Helper;
using EknowIDData.Helper.UserProfileHelper;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;
using EknowIDLib;
using EknowIDModel;
using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eknowID.Pages
{
    public partial class SearchByProf_PaymentInfo : BasePage, IAuthenticationRequired
    {
        public const string paymentType = "SALE";
        public const string country = "US";
        public const string ipnNotificationUrl = "https://paypalipntomato.pagekite.me/IPNListener.aspx";
        public static string totalReportCost = string.Empty;
        public static int orderID;
        public static bool isResumeCheckerModule;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.Url.ToString().Contains("?")) && Request.QueryString["st"] == null)
            {
                Response.Redirect("~/Pages/index.aspx");
            }
            if (!IsPostBack && !Request.Url.ToString().Contains("?"))
            {
                if (SessionWrapper.OrderDetail != null)
                {
                    if (SessionWrapper.AlacartReportList.Count != 0)
                    {
                        List<int> alacartRptIDList = SessionWrapper.AlacartReportList;

                        List<Report> alacartReportList = new List<Report>();
                        Report report;

                        foreach (int reportID in alacartRptIDList)
                        {
                            report = new Report();
                            report = PlanHelper.GetReportByReportID(reportID);

                            alacartReportList.Add(report);
                        }
                        SessionWrapper.OrderDetail.ReportList = alacartReportList;
                    }

                    orderID = OrderDetailsHelper.SaveOrderDetails(SessionWrapper.OrderDetail);
                    SessionWrapper.PaymentDetails = new PaymentDetails();
                }
                FillCombos();
                if (Request.UrlReferrer != null)
                {
                    isResumeCheckerModule = Request.UrlReferrer.AbsoluteUri.Contains("RC_DetailedAnalysis.aspx") == true ? true : false;
                }
            }


            if (SessionWrapper.ModuleName == Constant.SECURE_JOB)
            {
                ucSearchHeader.Visible = true;
                IdentityTheft_SearchByRef.Visible = false;

                Label lblSearchByProf = ucSearchHeader.FindControl("lblSelectByProf") as Label;
                lblSearchByProf.Text = "Payment Info & Checkout";

                Label lblCheckOut = ucSearchHeader.FindControl("lblCheckOut") as Label;
                lblCheckOut.ForeColor = System.Drawing.Color.FromArgb(153, 0, 0);

                Image imgBtnCheckout = ucSearchHeader.FindControl("imgBtnDot4") as Image;
                imgBtnCheckout.ImageUrl = "~/Images/color_hover_round.png";
            }
            else
            {
                ucSearchHeader.Visible = false;
                IdentityTheft_SearchByRef.Visible = true;


                Label lblSearchByProf = IdentityTheft_SearchByRef.FindControl("lblSelectByProf") as Label;
                lblSearchByProf.Text = "Payment Info & Checkout";

                Label lblCheckOut = IdentityTheft_SearchByRef.FindControl("lblCheckOut") as Label;
                lblCheckOut.ForeColor = System.Drawing.Color.FromArgb(153, 0, 0);

                Image imgBtnCheckout = IdentityTheft_SearchByRef.FindControl("imgBtnDot4") as Image;
                imgBtnCheckout.ImageUrl = "~/Images/color_hover_round.png";
            }

            GetUserDetails(SessionWrapper.LoggedUser.UserId);

            if (Request.Url.ToString().Contains("?") && Request.QueryString != null)
            {
                if (Request.QueryString["st"] == "Completed")
                {
                    paymentSuccess(Request.QueryString["tx"], null);
                }

            }

        }

        private void GetUserDetails(int UserId)
        {
            User user = UserHelper.GetUserById(UserId);

            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtEmailAddress.Text = user.Email;
            txtMobileNumber.Text = user.CellPhone;
            txtAddressLine1.Text = user.Address1;
            txtAddressLine2.Text = user.Address2;
            txtCity.Text = user.City;
            ddlPaymentstate.Index = user.StateId.HasValue ? user.StateId.Value : 0; ;
            txtZipCode.Text = user.Zip;

        }

        private void FillCombos()
        {
            for (int month = 1; month <= 12; month++)
            {
                ddlExpirationMonth.Items.Add(month.ToString("D2"));
            }

            for (int year = DateTime.Now.Year; year <= DateTime.Now.Year + 5; year++)
            {
                ddlExpirationYear.Items.Add(year.ToString());
            }

            #region Use Card List table to get card type list
            IRepository<CardList> cardRepo = new Repository<CardList>();
            IList<CardList> cardList = cardRepo.SelectAll();

            ddlCardType.DataTextField = "CardType";
            ddlCardType.DataValueField = "CardType";

            ddlCardType.DataSource = cardList;
            ddlCardType.DataBind();

            ddlCardType.Items.Insert(0, new ListItem("Select", "0"));
            ddlCardType.SelectedIndex = 0;
            #endregion
        }

        private void SavePaymentSummary(string TransactionID, string CorrelationID)
        {
            try
            {
                Order order = OrderHelper.GetOrderById(orderID);
                decimal totalCost = Convert.ToDecimal(totalReportCost.Substring(1));
                decimal disCountPrice = SessionWrapper.PaymentDetails.discountOffered;
                if (order != null)
                {
                    int CouponId = planOrderSummary.CouponId;
                    int ordID = OrderHelper.UpdatePayment(TransactionID, CorrelationID, SessionWrapper.PaymentDetails.couponID, orderID, disCountPrice, totalCost);
                }
                string userName = txtFirstName.Text + " " + txtLastName.Text;

                //Set Payment Details into session
                SessionWrapper.PaymentDetails.userName = userName;
                SessionWrapper.PaymentDetails.TransactionID = TransactionID;
                SessionWrapper.PaymentDetails.orderID = orderID;
                SessionWrapper.PaymentDetails.totalReportCost = totalReportCost;
                SessionWrapper.PaymentDetails.isPaymentNotificationSend = false;
                Response.Redirect("~/pages/PaymentSuccess.aspx");
            }
            catch { }
        }

        protected void imgBtnCompletePurchase_Click(object sender, EventArgs e)
        {
            //if terms and condition acceptable to user
            if (chkAgreement.Checked == true)
            {
                DoDirectPaymentRequestType request = new DoDirectPaymentRequestType();
                DoDirectPaymentRequestDetailsType requestDetails = new DoDirectPaymentRequestDetailsType();
                request.DoDirectPaymentRequestDetails = requestDetails;

                requestDetails.PaymentAction = (PaymentActionCodeType)
                    Enum.Parse(typeof(PaymentActionCodeType), paymentType.ToString());

                // Populate card requestDetails
                CreditCardDetailsType creditCard = new CreditCardDetailsType();
                requestDetails.CreditCard = creditCard;
                PayerInfoType payer = new PayerInfoType();
                PersonNameType name = new PersonNameType();


                name.FirstName = txtFirstName.Text;

                name.LastName = txtLastName.Text;
                payer.PayerName = name;
                creditCard.CardOwner = payer;

                creditCard.CreditCardNumber = txtCardNumber.Text;
                creditCard.CreditCardType = (CreditCardTypeType)
                        Enum.Parse(typeof(CreditCardTypeType), ddlCardType.SelectedValue.ToString());
                creditCard.CVV2 = txtSecurityCode.Text;

                creditCard.ExpMonth = Int32.Parse(ddlExpirationMonth.SelectedItem.Text);
                creditCard.ExpYear = Int32.Parse(ddlExpirationYear.SelectedItem.Text);

                requestDetails.PaymentDetails = new PaymentDetailsType();
                requestDetails.PaymentDetails.NotifyURL = ipnNotificationUrl.ToString();

                DropDownList ddlState = ddlPaymentstate.FindControl("ddlState_1") as DropDownList;

                AddressType billingAddr = new AddressType();
                if (txtFirstName.Text != String.Empty && txtLastName.Text != String.Empty && txtAddressLine1.Text != String.Empty)
                {
                    billingAddr.Name = txtFirstName.Text + " " + txtLastName.Text;
                    billingAddr.Street1 = txtAddressLine1.Text;
                    billingAddr.Street2 = txtAddressLine2.Text;
                    billingAddr.CityName = txtCity.Text;
                    billingAddr.StateOrProvince = ddlState.SelectedItem.Text;
                    billingAddr.Country = (CountryCodeType)Enum.Parse(typeof(CountryCodeType), country.ToString());
                    billingAddr.PostalCode = txtZipCode.Text;

                    //Fix for release
                    billingAddr.Phone = txtMobileNumber.Text;
                    payer.Address = billingAddr;
                }

                Label totalCost = planOrderSummary.FindControl("lblTotalPrice") as Label;
                totalReportCost = totalCost.Text;
                // Populate payment requestDetails
                CurrencyCodeType currency = (CurrencyCodeType)
                    Enum.Parse(typeof(CurrencyCodeType), "USD");
                BasicAmountType paymentAmount = new BasicAmountType(currency, totalCost.Text.Substring(1));
                requestDetails.PaymentDetails.OrderTotal = paymentAmount;
                requestDetails.PaymentDetails.NotifyURL = ipnNotificationUrl.ToString();

                // Invoke the API
                DoDirectPaymentReq wrapper = new DoDirectPaymentReq();
                wrapper.DoDirectPaymentRequest = request;
                PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();
                DoDirectPaymentResponseType response = service.DoDirectPayment(wrapper);

                //Save OrderState
                if (response.Ack.Value.ToString() == "SUCCESS")
                {
                    paymentSuccess(response.TransactionID, response.CorrelationID);
                }
                else
                {
                    paymentFailure(response.Errors[0].ShortMessage);
                }

            }
        }

        /// <summary>
        /// Payment success
        /// </summary>
        /// <param name="paymentResponse"></param>
        private void paymentSuccess(string TransactionID, string CorrelationID)
        {
            OrderStateHelper orderStateHelper = new OrderStateHelper();
            orderStateHelper.saveOrderStateAsync(orderID, SessionWrapper.LoggedUser.UserId);

            if (SessionWrapper.OrderDetail.DrugVerificationDetail != null)
            {
                StringBuilder emailBody = new StringBuilder(ConstructMail.GetMailBody(Constant.DRUG_VERIFICATION));
                emailBody = emailBody.Replace(Constant.CONST_FIRSTNAME, SessionWrapper.LoggedUser.FirstName);
                emailBody = emailBody.Replace(Constant.CONST_LASTNAME, SessionWrapper.LoggedUser.LastName);
                string toMailAddress = SessionWrapper.LoggedUser.Email + "," + Constant.ADMINEMAIL;

                SendMail.Sendmail(toMailAddress, Constant.CONST_DRUGVERIFICATION_SUBJECT, emailBody.ToString());
            }
            SavePaymentSummary(TransactionID, CorrelationID);

        }

        /// <summary>
        /// Payment Failure
        /// </summary>
        /// <param name="paymentResponse"></param>
        private void paymentFailure(string paymentErrorMsg)
        {
            TransactionLogHelper.SaveError(orderID, paymentErrorMsg, "", "");
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "AnUniqueKey", "showErrorReport();", true);
        }

        protected void btnExpressCheckout_Click(object sender, EventArgs e)
        {
            string redirecturl = "";
            redirecturl += ConfigurationManager.AppSettings["expressCheckoutURL"].ToString() + "&business=" + ConfigurationManager.AppSettings["paypalemail"].ToString();
            redirecturl += "&first_name=" + txtFirstName.Text.Trim();
            redirecturl += "&last_name=" + txtLastName.Text.Trim();
            redirecturl += "&city=" + txtCity.Text.Trim();
            DropDownList ddlState = ddlPaymentstate.FindControl("ddlState_1") as DropDownList;
            redirecturl += "&state=" + ddlState.SelectedItem.Text.Trim();
            redirecturl += "&item_name=eKnowID-Background verification";
            Label totalCost = planOrderSummary.FindControl("lblTotalPrice") as Label;
            totalReportCost = totalCost.Text;

            redirecturl += "&amount=" + totalCost.Text;
            redirecturl += "&quantity=1";
            redirecturl += "&currency=USD";
            redirecturl += "&return=" + ConfigurationManager.AppSettings["SuccessURL"].ToString();
            redirecturl += "&cancel_return=" + ConfigurationManager.AppSettings["FailedURL"].ToString();

            Response.Redirect(redirecturl);
        }
    }
}