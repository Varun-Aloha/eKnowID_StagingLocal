<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="ApplicantPackages.aspx.cs" Inherits="eknowID.Pages.ApplicantPackages" %>

<%@ Register Src="~/Controls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="ProgressBar" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdnIsPackageSelected" runat="server" ClientIDMode="Static" />
    <section class="priceBox eknowid-bg">
        <div class="container" style="padding-top: 25px;">
            <ProgressBar:ProgressBar ID="progressBarApplicantPackages" runat="server" />
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-6  col-xs-12">
                    <div class="serviceBox">
                        <div class="basicPrice">
                            <div class="priceTitle">
                                <span class="glyphicon glyphicon-th"></span>
                                <h2>
                                    <asp:Label ID="lblBasic" runat="server"></asp:Label>
                                </h2>
                            </div>
                        </div>
                        <div class="priceDetail">
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-sm-5 col-xs-12">
                                    <div class="perReportCircle red-bg">
                                        <span class="sup">$</span><asp:Label ID="lblBasicPrice" runat="server"></asp:Label>
                                    </div>
                                    <asp:HiddenField ID="hdnBasicPlanId" runat="server" />
                                </div>
                                <div class="col-lg-8 col-md-8 col-sm-7 col-xs-12">
                                    <h4>A basic search of criminal and sex offender records.<br />(<24 business hrs)</h4>
                                </div>
                            </div>
                        </div>
                        <div class="priceList">
                            <ul class="red">
                                <asp:Repeater ID="rptrBasicReports" runat="server">
                                    <ItemTemplate>
                                        <li><%# Eval("ReportName") %></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="priceBtn">
                            <asp:Button runat="server" ID="btnPkgBasic" CssClass="btn red-bg" Text="select" ClientIDMode="Static" OnClick="btnPkgBasic_Click" CausesValidation="false" />
                        </div>
                    </div>
                </div>

                <div class="col-lg-4 col-md-4 col-sm-6  col-xs-12">
                    <div class="serviceBox">
                        <div class="standardPrice">
                            <div class="priceTitle">
                                <span class="glyphicon glyphicon-certificate"></span>
                                <h2>
                                    <asp:Label runat="server" ID="lblStandred"></asp:Label></h2>
                            </div>
                        </div>
                        <div class="priceDetail">
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-sm-5 col-xs-12">
                                    <div class="perReportCircle blue-bg">
                                        <span class="sup">$</span><asp:Label ID="lblStandredPrice" runat="server"></asp:Label>
                                    </div>
                                    <asp:HiddenField ID="hdnStandardPlanId" runat="server" />
                                </div>
                                <div class="col-lg-8 col-md-8 col-sm-7 col-xs-12">
                                    <h4>A deeper look at the county level for non-digitized criminal records. (<48 business hrs)</h4>
                                </div>
                            </div>
                        </div>
                        <div class="priceList">
                            <ul class="blue">
                                <asp:Repeater ID="rptrStandardReports" runat="server">
                                    <ItemTemplate>
                                        <li><%# Eval("ReportName") %></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="priceBtn">
                            <asp:Button runat="server" ID="btnPkgStandard" CssClass="btn blue-bg" Text="select" OnClick="btnPkgStandard_Click" CausesValidation="false" />
                        </div>
                    </div>
                </div>

                <div class="col-lg-4 col-md-4 col-sm-6  col-xs-12">
                    <div class="serviceBox">
                        <div class="premiamPrice">
                            <div class="priceTitle">
                                <span class="glyphicon glyphicon-usd"></span>
                                <h2>
                                    <asp:Label runat="server" ID="lblTophire"></asp:Label>
                                </h2>
                            </div>
                        </div>
                        <div class="priceDetail">
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-sm-5 col-xs-12">
                                    <div class="perReportCircle orange-bg">
                                        <span class="sup">$</span><asp:Label ID="lblTophirePrice" runat="server"></asp:Label>
                                    </div>
                                    <asp:HiddenField ID="hdnPremiumPlanId" runat="server" />
                                </div>
                                <div class="col-lg-8 col-md-8 col-sm-7 col-xs-12">
                                    <h4>Verify resume claims for management-level positions.<br />(<72 business hrs)</h4>
                                </div>
                            </div>
                        </div>
                        <div class="priceList">
                            <ul class="orange">
                                <asp:Repeater ID="rptrTophireReports" runat="server">
                                    <ItemTemplate>
                                        <li><%# Eval("ReportName") %></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <div class="priceBtn">
                            <asp:Button runat="server" ID="btnPkgPremium" CssClass="btn orange-bg" Text="select" OnClick="btnPkgPremium_Click" CausesValidation="false" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
