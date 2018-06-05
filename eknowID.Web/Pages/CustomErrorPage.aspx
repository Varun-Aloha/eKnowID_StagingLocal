<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="CustomErrorPage.aspx.cs" Inherits="eknowID.Pages.CustomErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 455px; margin-bottom: 1px; padding-left: 105px; padding-top: 40px;">
        <div style="background-image: url(../images/order-error-Symbol-Error.png); float: left;
            height: 120px; width: 120px;">
        </div>
        <div style="float: left; margin-left: 26px; margin-top: 10px;">
            <div style="font-size: 25px; font-weight: bold;">
                <asp:Label ID="lblErrorHeading" runat="server" Text="An Error Has Occured."></asp:Label>
            </div>
            <div style="font-size: 15px; font-weight: lighter; margin: 10px 0 0 26px;">
                <asp:Label ID="lblSubErrorHeading" runat="server" Text="An unexpected error has occurred on our website."></asp:Label>
            </div>
            <div style="margin-top: 10px; padding-left: 26px;">
                <a href="index.aspx" style="color: #5383DB; font-weight: bold; text-decoration: none;">
                    Return to the homepage</a>
            </div>
        </div>
    </div>
</asp:Content>
