<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="SearchByProf_PaymentInfo.aspx.cs" Inherits="eknowID.Pages.SearchByProf_PaymentInfo" %>

<%@ Register Src="~/Controls/SearchByProfHeader.ascx" TagName="SearchByRef" TagPrefix="uc1" %>
<%@ Register Src="../Controls/completePurchase.ascx" TagName="completePurchase" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/PlanOrderSummary.ascx" TagName="OrderSummary" TagPrefix="uc3" %>
<%@ Register Src="~/Controls/stateDropdown.ascx" TagName="stateDropdown" TagPrefix="uc4" %>
<%@ Register Src="~/Controls/purchaseError.ascx" TagName="purchaseError" TagPrefix="uc5" %>
<%@ Register Src="~/Controls/IdentityTheftSearchByProfHeader.ascx" TagName="IdentityTheft_SearchByRef"
    TagPrefix="uc6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .btnProcessReport {
            border: medium none;
            height: 32px;
            width: 168px;
            background-image: url(../images/process_report_btn.png);
        }

        .btnCheckoutExpress {
            border: medium none;
            height: 32px;
            width: 153px;
            background-image: url(../images/express_checkout.png);
            background-color: transparent;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/creditcard.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.history.go(+1);

        function ValidatePaymentInformation() {
            var errorMessage = "Please fill mandatory information to continue.";
            if (!($("#txtFirstName").valid())) {
                ShowPopupPayment(errorMessage);
                return false;
            }
            if (!($("#txtLastName").valid())) {
                ShowPopupPayment(errorMessage);
                return false;
            }
            if (!($("#txtEmailAddress").valid())) {
                if ($("#txtEmailAddress").val().length > 0) {
                    errorMessage = "Please enter valid email address.";
                    ShowPopupPayment(errorMessage);
                    return false;
                }
                else {
                    ShowPopupPayment(errorMessage);
                    return false;
                }
            }
            if (!($("#txtAddressLine1").valid())) {
                ShowPopupPayment(errorMessage);
                return false;
            }
            if (!($("#txtCity").valid())) {
                ShowPopupPayment(errorMessage);
                return false;
            }
            if (!($("#txtZipCode").valid())) {
                if ($("#txtZipCode").val().length > 0) {
                    errorMessage = "Please enter valid zip.";
                    ShowPopupPayment(errorMessage);
                    return false;
                }
                else {
                    ShowPopupPayment(errorMessage);
                    return false;
                }
            }
            if (!($("#divStatePayment select").valid())) {
                ShowPopupPayment(errorMessage);
                return false;
            }
            return true;
        }

        //Validate information for Express Checkout
        function ValidateCheckoutPaymentInfo() {

            var validatePaymentInfo = ValidatePaymentInformation();
            if (validatePaymentInfo == false) {
                return false;
            }

            if ($('#chkAgreement').is(':checked') == false) {
                OpenDialog("In order to use our services, you must agree to Terms of Service.");
                return false;
            }

            $("#ddlCardType").removeClass("ddlValidation");
            $("#txtCardNumber").removeClass("required");
            OpenProcessingImage();
            var isValid = true;
            needToConfirm = false;
            return isValid;
        }

        function ShowPopupPayment(errorMessage) {
            OpenDialog(errorMessage, function () {
                $('div#paymentInfoLeftContainer input[type="text"].error,select.error').first().focus();
            });
        }

        //Validate Payment Info for Card Payment
        function ValidatePaymentInfoClienClick() {

            var validatePaymentInfo = ValidatePaymentInformation();
            if (validatePaymentInfo == false) {
                return false;
            }

            var errorMessage = "Please fill mandatory information to continue.";

            if (!($("#ddlCardType").valid())) {
                ShowPopupPayment(errorMessage);
                return false;
            }

            if (!($("#txtCardNumber").valid()) || !($("#ddlCardType").valid())) {
                ShowPopupPayment(errorMessage);
                return false;
            }

            if (!$("#txtSecurityCode").valid()) {
                ShowPopupPayment(errorMessage);
                return false;
            }

            var cardValidate = CreditCardValidation();
            var securityCodeValidate = false;
            if (cardValidate == true) {
                OpenProcessingImage();
            }
            needToConfirm = false;
            return cardValidate;
        }

        function setUncoverBg() {
            $('.hideContent').attr("style", "display:none;");
            $("#orderInformation").attr("style", " height: 215px !important;");
            $("#completePurchsediv").attr("style", " height: 469px !important;");
        }

        function getPlanReport(flag) {
            if (flag == 0)
            { setUncoverBg(); }
            showPaymentSummary();
        }

        function showErrorReport() {

            showPaymentErrorSummary();
        }

        function popUpclose() {
            $('#completePurchse').bPopup().close();
        }

        function errorPopUpclose() {
            $('#completePurchseErrorPopup').bPopup().close();
        }

        function CreditCardValidation() {

            var CardNumber = $("#<%=txtCardNumber.ClientID %>").valid();
            var CardType = $("#<%=ddlCardType.ClientID %>").valid();

            if (CardNumber == 0 || CardType == 0) {
                OpenDialog("Please fill the mandatory field to continue.", function () {
                    $('div#paymentInfoLeftContainer input[type="text"].error,select.error').first().focus();
                });
            }
            else {
                if ($('#chkAgreement').is(':checked')) {
                    var state = $("#divStatePayment select").val();
                    //            Credit Card date and number validation
                    if (CreditCardDateValidation() && ValidateCreditCard()) {
                        if ($('#txtSecurityCode').val().length == 0)
                        { return true; }
                        if ($('#txtSecurityCode').val().length > 0) {
                            var cardType = $("#ddlCardType").val();

                            if ($('#txtSecurityCode').val().length == 3 && (cardType == "VISA" || cardType == "DISCOVER" || cardType == "MASTERCARD")) {
                                return true;
                            }
                            else if ($('#txtSecurityCode').val().length == 4 && cardType == "AMEX") {
                                return true;
                            }
                            else {
                                OpenDialog("Please enter correct security code.", function () {
                                    $('#txtSecurityCode').focus();
                                });
                                return false;
                            }
                        }
                    }
                    else {
                        return false;
                    }
                }
                else {
                    OpenDialog("In order to use our services, you must agree to Terms of Service.");

                    return false;
                }
            }
        }

        function ValidateCreditCard() {
            var CardNo = document.getElementById('<%=txtCardNumber.ClientID %>').value;
            var CCType = document.getElementById("<%=ddlCardType.ClientID%>");
            var CardType = CCType.options[CCType.selectedIndex].text;

            if (checkCreditCard(CardNo, CardType)) {
                return true;
            }
            else {
                OpenDialog(ccErrors[ccErrorNo]);
                return false;
            }
        }

        function CreditCardDateValidation() {
            var currentDate = new Date();
            var currentYear = currentDate.getFullYear();
            var currentMonth = currentDate.getMonth();
            var ddlYearVal = document.getElementById("<%=ddlExpirationYear.ClientID%>");
            var SelectedYear = ddlYearVal.options[ddlYearVal.selectedIndex].text;
            var ddlMonthVal = document.getElementById("<%=ddlExpirationMonth.ClientID%>");
            var SelectedMonth = ddlMonthVal.options[ddlMonthVal.selectedIndex].text;
            if (SelectedMonth <= currentMonth && SelectedYear <= currentYear) {

                OpenDialog("Please enter a valid credit card expiration date.", function () {
                    $('div#paymentInfoLeftContainer input[type="text"].error').first().focus();
                });
                return false;
            }
            return true;
        }

        var needToConfirm = true;

        window.onbeforeunload = function () {
            //Don't show confirmation popup only if session expire & direct redirect to home page. 
            if (parent.SessionTimeOutflag == false) {
                return confirmExit();
            }
        }

        //Show confirmation on page unload
        function confirmExit() {
            if (needToConfirm) {
                return "You have attempted to leave this page.  If you have made any changes to the fields without clicking the Save button, your changes will be lost.  Are you sure you want to exit this page?";

            }
        }

    </script>
    <div class="minWidth1000px" style="min-height: 1000px !important; background-color: #E7E7E7;">
        <div class="SearchByRef_mainDiv">
            <div class="margintop40">
                <%if (isResumeCheckerModule)
                  { %>
                <div class="divSelectProfHeading" style="margin-left: 20px;">
                    <asp:Label ID="lblSelectProfession" runat="server" Text="Payment Info & Checkout" />
                </div>
                <%} %>
                <%if (isResumeCheckerModule == false)
                  { %>
                <uc1:SearchByRef ID="ucSearchHeader" runat="server" />
                <uc6:IdentityTheft_SearchByRef ID="IdentityTheft_SearchByRef" runat="server" />
                <%} %>
            </div>
            <div class="clearBoth">
            </div>
            <div style="min-height: 900px; clear: both; padding-left: 20px;">
                <div style="height: 20px; margin-top: 15px;">
                    Quality takes time, you should know your identity within 72 hours of purchase (with
                    the exception of International Checks).
                </div>
                <div class="floatLeft" id="paymentInfoLeftContainer">
                    <div style="height: 686px; width: 600px; background-color: White !important;" class="clearBoth marginTop15 padding30  lightgrayBackGround borderRadius6">
                        <div class="paddingBottom15 boldText">
                            Payment Information
                        </div>
                        <div class="floatLeft paddingTop10 width120">
                            First Name
                        </div>
                        <div class="floatLeft padding8 width460">
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="width200 required charOnly ValidatePayment"
                                MaxLength="20" ClientIDMode="Static" onkeypress="return (event.keyCode!=13);" /><span
                                    class="red asterisk">*</span>
                        </div>
                        <div class="floatLeft paddingTop10 width120">
                            Last Name
                        </div>
                        <div class="floatLeft padding8 width460">
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="width200 required charOnly ValidatePayment"
                                MaxLength="20" ClientIDMode="Static" onkeypress="return (event.keyCode!=13);" /><span
                                    class="red asterisk">*</span>
                        </div>
                        <div class="floatLeft paddingTop10  width120">
                            Email Address
                        </div>
                        <div class="floatLeft padding8 width460">
                            <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="width200 email required ValidatePayment"
                                MaxLength="50" ClientIDMode="Static" onkeypress="return (event.keyCode!=13);" /><span
                                    class="red asterisk">*</span>
                        </div>
                        <div class="floatLeft paddingTop10 width120">
                            Mobile Number
                        </div>
                        <div class="floatLeft padding8 width460">
                            <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="width200 number digitsOnly ValidatePayment"
                                MaxLength="10" ClientIDMode="Static" minlength="10" />
                        </div>
                        <div class="floatLeft paddingTop10 width120">
                            Address Line1
                        </div>
                        <div class="floatLeft padding8 width460">
                            <asp:TextBox ID="txtAddressLine1" runat="server" CssClass="width200 required ValidatePayment"
                                MaxLength="100" ClientIDMode="Static" onkeypress="return (event.keyCode!=13);" /><span
                                    class="red asterisk">*</span>
                        </div>
                        <div class="floatLeft paddingTop10 width120">
                            Address Line2
                        </div>
                        <div class="floatLeft padding8 width460">
                            <asp:TextBox ID="txtAddressLine2" runat="server" CssClass="width200 ValidatePayment"
                                MaxLength="100" ClientIDMode="Static" onkeypress="return (event.keyCode!=13);" />
                        </div>
                        <div class="floatLeft paddingTop10 width120">
                            City
                        </div>
                        <div class="floatLeft padding8 width460">
                            <asp:TextBox ID="txtCity" runat="server" MaxLength="50" CssClass="required LettersWithSpace charOnly ValidatePayment"
                                ClientIDMode="Static" onkeypress="return (event.keyCode!=13);" /><span class="red asterisk">*</span>
                        </div>
                        <div class="floatLeft paddingTop10 width120">
                            State
                        </div>
                        <div class="floatLeft padding8 width460">
                            <div id="divStatePayment" class="width160">
                                <uc4:stateDropdown ID="ddlPaymentstate" runat="server" ClientIDMode="Static" onkeypress="return (event.keyCode!=13);" />
                                <span class="red asterisk">*</span>
                            </div>
                        </div>
                        <div class="floatLeft paddingTop10 width120">
                            Zip Code
                        </div>
                        <div class="floatLeft padding8 width460">
                            <asp:TextBox ID="txtZipCode" runat="server" CssClass="zipcode digitsOnly ValidatePayment required"
                                MaxLength="5" minlength="5" ClientIDMode="Static" onkeypress="return (event.keyCode!=13);" /><span
                                    class="red asterisk">*</span>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div id="paymentSeperator" class="padding15 marginTop15">
                        </div>
                        <div class="paddingBottom15 boldText clearBoth">
                            Credit Card Information
                        </div>
                        <div class="floatLeft paddingTop10 width120  clearBoth">
                            Card Type
                        </div>
                        <div class="floatLeft padding8" style="width: 225px;">
                            <asp:DropDownList ID="ddlCardType" runat="server" CssClass="width120 floatLeft ddlValidation"
                                ClientIDMode="Static">
                            </asp:DropDownList>
                            <span class="red asterisk">*</span>
                        </div>
                        <div class="floatLeft paddingTop10 width120  clearBoth">
                            Card Number
                        </div>
                        <div class="floatLeft padding8" style="width: 225px;">
                            <asp:TextBox ID="txtCardNumber" runat="server" CssClass="width200 required number digitsOnly ValidatePayment"
                                MaxLength="20" ClientIDMode="Static" onkeypress="return (event.keyCode!=13);" /><span
                                    class="red asterisk">*</span>
                        </div>
                        <div class="floatLeft" style="padding: 8px 8px 8px 0;">
                            <asp:Image ID="imgVisa" runat="server" ImageUrl="~/Images/visa_icon.png" Height="22px"
                                Width="31px" CssClass="floatLeft" Style="margin-left: 5px;" />
                            <asp:Image ID="imgMaster" runat="server" ImageUrl="~/Images/master_icon.png" Height="22px"
                                Width="31px" CssClass="floatLeft " Style="margin-left: 5px;" />
                            <asp:Image ID="imgAmex" runat="server" ImageUrl="~/Images/amex_icon.png" Height="22px"
                                Width="31px" CssClass="floatLeft " Style="margin-left: 5px;" />
                            <asp:Image ID="imgDiscover" runat="server" ImageUrl="~/Images/discover_icon.png"
                                Height="22px" Width="31px" CssClass="floatLeft " Style="margin-left: 5px;" />
                        </div>
                        <div class="floatLeft paddingTop10 width120 clearBoth">
                            Expiration Date
                        </div>
                        <div class="floatLeft padding8 width460">
                            <div class="floatLeft width96">
                                <asp:DropDownList ID="ddlExpirationMonth" runat="server" CssClass="width80" ClientIDMode="Static" />
                            </div>
                            <div class="floatLeft width135">
                                <asp:DropDownList ID="ddlExpirationYear" runat="server" CssClass="width120" ClientIDMode="Static" />
                                <span class="red asterisk">*</span>
                            </div>
                        </div>
                        <div class="floatLeft paddingTop10 width120 ">
                            Security Code
                        </div>
                        <div class="floatLeft padding8" style="width: 172px;">
                            <asp:TextBox ID="txtSecurityCode" runat="server" CssClass="number digitsOnly ValidatePayment"
                                ClientIDMode="Static" onkeypress="return (event.keyCode!=13);" MaxLength="4" />
                        </div>
                        <div class="floatLeft" style="padding: 8px 8px 8px 0;">
                            <asp:Image ID="imgSecurity" runat="server" ImageUrl="~/Images/security_icon.png"
                                heigh="22px" Width="35px" CssClass="floatLeft" Style="margin-left: 5px;" />
                        </div>
                        <div class="floatLeft paddingTop10 width120">
                        </div>
                        <div class="floatRight padding8 width460">
                            <asp:CheckBox ID="chkAgreement" ClientIDMode="Static" runat="server" CssClass="ValidatePayment"
                                Text="Yes, I have read and agree to the eKnowID" onkeypress="return (event.keyCode!=13);" />
                            <br />
                            <span style="margin-left: 24px;"><a href="PrivacyPolicy.aspx" target="_blank">Privacy
                                Policy</a> and <a href="TermsofUse.aspx" target="_blank">Terms and Conditions</a>.</span>
                        </div>
                    </div>
                    <div class="clearBoth">
                    </div>
                    <div class="floatRight marginTop15" style="margin-right: 3px;">
                        <div class="floatRight">
                            <asp:Button ID="imgBtnCompletePurchase" runat="server" CssClass="btnProcessReport"
                                ForeColor="WhiteSmoke" ClientIDMode="Static" OnClick="imgBtnCompletePurchase_Click"
                                OnClientClick=" return ValidatePaymentInfoClienClick();" />
                        </div>
                        <div class="floatRight marginRight10">
                            <asp:Button ID="btnExpressCheckout" runat="server" CssClass="btnCheckoutExpress"
                                ForeColor="WhiteSmoke" ClientIDMode="Static" OnClientClick=" return ValidateCheckoutPaymentInfo();"
                                OnClick="btnExpressCheckout_Click" />
                        </div>
                    </div>
                </div>
                <div class="floatLeft" style="margin-top: 9px; margin-left: 21px; min-height: 500px; width: 278px;">
                    <uc3:OrderSummary ID="planOrderSummary" runat="server" />
                </div>
                <div class="floatLeft marginTop15" style="height: 69px; width: 268px; margin-left: 32px;">
                    <div class="floatLeft">
                        <a target="_blank" id="bbblink" class="sehzbus" href="https://www.bbb.org/chicago/business-reviews/screening-background-and-employment/kentech-consulting-in-chicago-il-88032082#bbblogo"
                            title="KENTECH Consulting, Inc., Screening - Background & Employment, Chicago, IL"
                            style="display: block; position: relative; overflow: hidden; width: 100px; height: 38px; margin: 0px; padding: 0px;">
                            <img style="padding: 0px; border: none;" id="bbblinkimg" src="https://seal-chicago.bbb.org/logo/sehzbus/kentech-consulting-88032082.png"
                                width="200" height="38" alt="KENTECH Consulting, Inc., Screening - Background & Employment, Chicago, IL" /></a>
                        <script type="text/javascript">
                            var bbbprotocol = (("https:" == document.location.protocol) ? "https://" : "http://");
                            document.write(unescape("%3Cscript src='" + bbbprotocol + 'seal-chicago.bbb.org' + unescape('%2Flogo%2Fkentech-consulting-88032082.js') + "' type='text/javascript'%3E%3C/script%3E"));
                        </script>
                    </div>
                    <div class="marginleft15 floatLeft">
                        <!-- webbot  bot="HTMLMarkup" startspan -->
                        <!-- GeoTrust QuickSSL [tm] Smart  Icon tag. Do not edit. -->
                        <script language="javascript" type="text/javascript" src="//smarticon.geotrust.com/si.js"></script>
                        <!-- end  GeoTrust Smart Icon tag -->
                        <!-- webbot  bot="HTMLMarkup" endspan -->
                    </div>
                </div>
            </div>
            <div style="display: none; width: 700px; height: 350px; clear: both;" id="completePurchse">
                <uc2:completePurchase ID="completePurchase1" runat="server" />
            </div>
            <div id="completePurchseErrorPopup" style="display: none;">
                <uc5:purchaseError ID="purchaseErrorPopup" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
