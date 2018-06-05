<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="purchaseError.ascx.cs"
    Inherits="eknowID.Controls.purchaseError" %>
<div class="borderRadius6 padding1" id="completePurchsediv" style="height: 200px !important;
    width: 380px !important;">
    <div class="borderRadiusTopCorners6 popupHeader">
        <div class="orderSummaryHeader">
            <asp:Label ID="lblOrderSummary" runat="server" Text="Order Summary" />
        </div>
        <img src="../Images/close_icon_popup.png" class="floatRight" alt="" onclick="errorPopUpclose();"
            style="margin-top: -37px;" />
    </div>
    <div class="padding30" style="height: 85px;">
        <div class="purchaseErrorPopupimg">
        </div>
        <div class="purchaseErrorPopupText">
            Your transaction has failed.</div>
    </div>
    <div class="clearBoth">
    </div>
    <%--<img src="../Images/cal_icon.png" class="floatRight" style="margin-top: -16px; margin-right: 19px" />--%>
    <div class="floatRight">
        <asp:Button ID="btnOk" runat="server" CssClass="blackBtnMiddle" ForeColor="WhiteSmoke"
            Style="margin-top: -16px; margin-right: 35px" Text="OK" OnClientClick="errorPopUpclose();" />
    </div>
</div>
