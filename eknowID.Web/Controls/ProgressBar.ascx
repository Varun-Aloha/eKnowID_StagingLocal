<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgressBar.ascx.cs" Inherits="eknowID.Controls.ProgressBar" %>

<div class="packageHeading">
    <div class="row center-block">
        <div class="col-md-12">
            <div class="col-md-4 col-sm-3 col-xs-3 headingText">
                <asp:Label ID="lblPackageSelect" CssClass="packageText" runat="server">Package Select</asp:Label>
                <div class="stepHeading" id="packageSelection">
                </div>
                <div class="stepLine packageLine"></div>
            </div>
            <div class="col-md-4 col-sm-3 col-xs-3 headingText">
                <asp:Label ID="upgradePackage" CssClass="packageText" runat="server">Upgrade Package</asp:Label>
                <div class="stepHeading" id="reportSelection">
                </div>
                <div class="stepLine upgradeLine"></div>
            </div>
            <div class="col-md-4 col-sm-3 col-xs-3 headingText">
                <asp:Label ID="makePayment" CssClass="packageText" runat="server">Checkout</asp:Label>
                <div class="stepHeading" id="paymentSelection">
                </div>
            </div>
        </div>
    </div>
</div>

