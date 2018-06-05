<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="PaymentSuccess.aspx.cs" Inherits="eknowID.Pages.PaymentSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divMainPaymentSuccess
        {
            height: 650px;
            padding: 30px 0px;
            font-size: 13px;
        }
        .divWhyEknowMain
        {
            height: 588px !important;
        }
        #completePurchsediv
        {
            height: 530px !important;
        }
          .submitButton
        {
            margin-top: -16px;
            margin-right: 35px;
            color:White;
            width:75px !important;
        }
        .height_445px
        {height: 445px;}
    </style>

    <!-- Google analytics start -->
   <!-- Google Code for Purchase Conversion Page -->
<script type="text/javascript">
/* <![CDATA[ */
var google_conversion_id = 1062499608;
var google_conversion_language = "en";
var google_conversion_format = "3";
var google_conversion_color = "ffffff";
var google_conversion_label = "u4rECNzloQUQmOrR-gM";
var google_conversion_value = 0;
/* ]]> */
</script>
<script type="text/javascript" src="//www.googleadservices.com/pagead/conversion.js">
</script>
<noscript>
<div style="display:inline;">
<img height="1" width="1" style="border-style:none;" alt="" src="//www.googleadservices.com/pagead/conversion/1062499608/?value=0&amp;label=u4rECNzloQUQmOrR-gM&amp;guid=ON&amp;script=0"/>
</div>
</noscript>
    <!-- Google analytics end -->

    <script type="text/javascript" language="javascript">

        window.history.go(+1);

        function redirectToUserOrderHistory() {
            window.location.href = "../pages/AdminDashboard.aspx";
            return false;
        }
        function setUncoverBg() {
            $('.hideContent').attr("style", "display:none;");
            $('.hideSelectProf').attr("style", "display:none;");
            $("#orderInformation").attr("style", " height: 215px !important;");
            $("#completePurchsediv").attr("style", " height: 469px !important;");
        }
        function setIDTheftBg() {
            $('.hideSelectProf').attr("style", "display:none;");
            $("#orderInformation").attr("style", " height: 215px !important;");
            $("#completePurchsediv").attr("style", " height: 469px !important;");
        }
        function setResumeCheckerBg() {
            $('.hideContent').attr("style", "display:none;");
            $("#orderInformation").attr("style", " height: 215px !important;");
            $("#completePurchsediv").attr("style", " height: 469px !important;");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="minWidth1000px grayBackground divMainPaymentSuccess">
        <div class="stretchDiv paddingBottom15 paddingLeft28 paddingTop10 divWhyEknowMain boxShadowIE8 divContactUsMain">
            <h1>
                Order Summary</h1>
            <div class="borderRadius6 padding1" id="completePurchsediv">
                <div class="padding30 height_445px">
                    Dear&nbsp;
                    <asp:Label ID="lblName" runat="server" />
                    ,
                    <br />
                    <p class="paddingTop15">
                        Thank you for your order!</p>
                    <p>
                        Your purchase is complete and you will recieve an email containing the ordered report
                        shortly.</p>
                    <div class="padding15" id="orderInformation">
                        <p class="boldText fontsize16 marginBottom0 marginTop0">
                            Order Information</p>
                        <div class="paddingLeft15 ">
                            <div class="height_30px clearBoth">
                                <div class="floatLeft paddingTop10 width48per">
                                    Transaction ID</div>
                                <div class="floatLeft paddingTop10 width48per boldText">
                                    <asp:Label ID="lblTransID" runat="server" />
                                </div>
                            </div>
                            <div class="height_30px clearBoth">
                                <div class="floatLeft paddingTop10 width48per">
                                    Order Number</div>
                                <div class="floatLeft paddingTop10 width48per boldText">
                                    <asp:Label ID="lblOrdNo" runat="server" />
                                </div>
                            </div>
                            <div class="height_30px clearBoth">
                                <div class="floatLeft paddingTop10 width48per">
                                    Purchase Date</div>
                                <div class="floatLeft paddingTop10 width48per boldText">
                                    <asp:Label ID="lblPurchaseDt" runat="server" />
                                </div>
                            </div>
                            <div class="height_30px clearBoth">
                                <div class="floatLeft paddingTop10 width48per">
                                    Module Name</div>
                                <div class="floatLeft paddingTop10 width48per boldText">
                                    <asp:Label ID="lblModuleName" runat="server" />
                                </div>
                            </div>
                            <div class="height_30px clearBoth hideSelectProf">
                                <div class="floatLeft paddingTop10 width48per">
                                    Selected Profession</div>
                                <div class="floatLeft paddingTop10 width48per boldText">
                                    <asp:Label ID="lblSelectedProf" runat="server" />
                                </div>
                            </div>
                            <div class="height_30px clearBoth hideContent">
                                <div class="floatLeft paddingTop10 width48per">
                                    Package Name</div>
                                <div class="floatLeft paddingTop10 width48per boldText">
                                    <asp:Label ID="lblPackageName" runat="server" />
                                </div>
                            </div>
                            <div class="height_30px clearBoth hideContent">
                                <div class="floatLeft paddingTop10 width48per">
                                    Package Cost</div>
                                <div class="floatLeft paddingTop10 width48per boldText">
                                    <asp:Label ID="lblRptCost" runat="server" />
                                </div>
                            </div>
                            <div class="height_30px clearBoth">
                                <div class="floatLeft paddingTop10 width48per">
                                 <asp:Label ID="lblAddReportCost" runat="server" Text=" Additional Report(s) Cost:" />                                   
                                </div>
                                <div class="floatLeft paddingTop10 width48per boldText">
                                    <asp:Label ID="lblOptRptCost" runat="server" />
                                </div>
                            </div>
                            <div class="height_30px clearBoth">
                                <div class="floatLeft paddingTop10 width48per">
                                   Other Charges</div>
                                <div class="floatLeft paddingTop10 width48per boldText">
                                    <asp:Label ID="lblOtherCharges" runat="server" />
                                </div>
                            </div>
                            <div class="height_30px clearBoth">
                                <div class="floatLeft paddingTop10 width48per">
                                    Discount Offered</div>
                                <div class="floatLeft paddingTop10 width48per boldText">
                                    <asp:Label ID="lblDiscountOffer" runat="server" />
                                </div>
                            </div>
                            <div class="height_30px clearBoth">
                                <div class="floatLeft paddingTop10 width48per">
                                    Transaction Amount</div>
                                <div class="floatLeft paddingTop10 width48per boldText">
                                    <asp:Label ID="lblTransAmount" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearBoth">
                </div>
                <div class="floatRight" style="margin-right: 110px;">
                <input type="button" class="blackBtnMiddle CompletePurchase submitButton" value="OK" onclick="return redirectToUserOrderHistory();"/>                  
                </div>
            </div>
        </div>
    </div>
</asp:Content>
