<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="completePurchase.ascx.cs"
    Inherits="eknowID.Controls.completePurchase" %>
    <script type="text/javascript" language="javascript">

        function redirectToHome() {          
            window.location.href = "../pages/AdminDashboard.aspx";
        }
        
</script>
<div class="borderRadius6 padding1" id ="completePurchsediv" style="height: 540px !important;">
    <div class="borderRadiusTopCorners6 popupHeader">
        <div class="orderSummaryHeader">
            <asp:Label ID="lblOrderSummary" runat="server" Text="Order Summary" />
        </div>
        <img src="../Images/close_icon_popup.png" class="floatRight cursorPointer" alt="" onclick="redirectToHome();" style=" margin-top: -37px;" />
    </div>
    <div class="padding30">
        Dear&nbsp;
        <asp:Label ID="lblName" runat="server" />
        ,
        <br />
        <p class="paddingTop15">
            Thank you for your order!</p>
        <p>
            Your purchase is complete and you will recieve an email containing the ordered report
            shortly.</p>
        <div class="lightgrayBackGround borderRadius6 padding15" id ="orderInformation">
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
                    <div class="height_30px clearBoth hideContent">
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
                    Optional Report
                </div>
                    <div class="floatLeft paddingTop10 width48per boldText">
                        <asp:Label ID="lblOptRptCost" runat="server" />
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
    <%--<img src="../Images/cal_icon.png" class="floatRight" style="margin-top: -16px; margin-right: 19px" />--%>
    <div class="floatRight">
    <asp:Button ID="btnOk" runat="server" CssClass="blackBtnMiddle CompletePurchase" ForeColor="WhiteSmoke"
            Style="margin-top: -16px; margin-right: 35px" Text="OK" OnClientClick="redirectToHome();" />
    </div>
</div>
