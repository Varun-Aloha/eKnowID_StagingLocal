<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="UpgradeReportPackage.aspx.cs" Inherits="eknowID.Pages.UpgradeReportPackage" %>

<%@ Register Src="~/Controls/SearchByProfHeader.ascx" TagName="SearchByRef" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/AlaCartReport.ascx" TagName="alacart" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/UpgradeAlacartReport.ascx" TagName="alacartReportSummary"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divAlacartReportInner {
            width: 940px !important;
            padding: 30px !important;
        }

        .divAlacartInner {
            background-color: white;
            border-color: #D7D7D7;
            border-radius: 2px 2px 2px 2px;
            box-shadow: 2px 2px 4px #8A8A8A;
            color: #404040;
            font-family: helvetica;
            font-size: 13px;
            margin-top: 1px;
            min-height: 645px;
            padding: 30px 45px;
            width: 605px;
        }

        .divPlanReportHeading {
            width: 590px !important;
            font-weight: bold;
        }

        .divSelectedAlacartReportList {
            min-height: 40px;
            padding-bottom: 5px;
            padding-top: 5px;
            width: 258px;
            clear:both;
        }
        .clsQuantity
        {
            width:30px;
            margin-left:5px;            
        }
        .dropdown-menu > ul > li > a {
            display: block;
            padding: 3px 20px;
            clear: both;
            font-weight: 400;
            line-height: 1.42857143;
            color: #333;
            white-space: nowrap;
        }
    </style>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
        
    <script type="text/javascript" src="../Scripts/bootbox.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>    
    <script type="text/javascript" src="../Scripts/UserScripts/SelfOrderAlacartPackages.js"></script>
    <script type="text/javascript" language="javascript">
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:HiddenField ID="hdnUserLoggedIn" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdnStateCriminalList" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hdnCountyCriminalList" runat="server" ClientIDMode="Static"/>    
    <asp:HiddenField ID="hdnCountyCivilList" runat="server" ClientIDMode="Static"/>    
    <asp:HiddenField ID="hdnFederalCriminalList" runat="server" ClientIDMode="Static"/>

    <select id="ddlStates" clientidmode="Static" runat="server" style="display:none"></select>
    <div class="SearchByRef_background minWidth1000px" style="height: auto !important; padding-bottom: 30px;">
        <div class="SearchByRef_mainDiv" style="width: 1000px;">
            <div class="margintop40">
                <uc2:SearchByRef ID="ucSearchHeader" runat="server" />
            </div>
        </div>
        <div class="margin_left_right_auto" style="width: 1000px; padding-bottom: 30px; min-height:1000px">
            <div class="divAlacartInner floatLeft">
                <div style="height: 40px; width: 100%;">
                    <div class="floatLeft width150" style="color: #323232; font-size: 20px; font-weight: 700;">
                        À la Carte
                    </div>
                </div>
                <div class="divPlanReportHeading clearBoth floatLeft">
                    Criminal Searches
                </div>
                <div class="clearBoth">
                </div>
                <asp:Repeater ID="CriminalAlacartReportList" runat="server" OnItemDataBound="alacartReportList_ItemDataBound">
                    <ItemTemplate>
                        <div runat="server" id="divAlacartReport">
                            <uc1:alacart ID="AlacartReport" runat="server" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="divPlanReportHeading clearBoth floatLeft">
                    Verification Searches
                </div>
                <div class="clearBoth">
                </div>
                <asp:Repeater ID="VerificationAlacartReportList" runat="server" OnItemDataBound="alacartReportList_ItemDataBound">
                    <ItemTemplate>
                        <div runat="server" id="divAlacartReport">
                            <uc1:alacart ID="AlacartReport" runat="server" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="divPlanReportHeading clearBoth floatLeft">
                    Miscellaneous Searches
                </div>
                <div class="clearBoth">
                </div>
                <asp:Repeater ID="MiscellaneousAlacartReportList" runat="server" OnItemDataBound="alacartReportList_ItemDataBound">
                    <ItemTemplate>
                        <div runat="server" id="divAlacartReport">
                            <uc1:alacart ID="AlacartReport" runat="server" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="divHeaderBorder">
                </div>
            </div>
            <div class="floatLeft" id="paymentInfoRightContainer" style="margin-left: 21px; height: 660px; width: 278px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc3:alacartReportSummary ID="planOrderSummary" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnChooseReport" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <input type="button" id="btnNext" value="" onclick="CheckIfUserloggedIn()" class="floatRight alacartNextBtn" style="background-image: url(../Images/next_btn_red.png); margin:10px;" />
            </div>
            <div style="display: none">
                <asp:Button ID="btnChooseReport" runat="server" OnClick="btnChooseReport_Click" ClientIDMode="Static" />
            </div>
        </div>
       <%-- <div class="clearBoth width1000px margin_left_right_auto height_30px paddingTop15">
            <div style="width: 695px; height: 30px;">                
                <input type="button" id="btnNext" value="" onclick="CheckIfUserloggedIn()" class="floatRight alacartNextBtn" style="background-image: url(../Images/next_btn_red.png);" />
            </div>
        </div>--%>        
    </div>   
</asp:Content>
