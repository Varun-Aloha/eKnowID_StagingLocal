<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="SearchByProf_ChoosePlan.aspx.cs" Inherits="eknowID.Pages.SearchByProf_ChoosePlan" %>

<%@ Register Src="~/Controls/SearchByProfHeader.ascx" TagName="SearchByRef" TagPrefix="uc1" %>
<%@ Register Src="../Controls/PlanDisplay.ascx" TagName="PlanDisplay" TagPrefix="uc3" %>
<%@ Register Src="~/Controls/DrugsVerficationDetails.ascx" TagName="DrugVerificationDetails"
    TagPrefix="uc7" %>
<%@ Register Src="../Controls/EducationalDetails.ascx" TagName="EducationalDetails"
    TagPrefix="uc4" %>
<%@ Register Src="../Controls/EmploymentDetails.ascx" TagName="EmploymentDetails"
    TagPrefix="uc5" %>
<%@ Register Src="../Controls/LicenseInformation.ascx" TagName="LicenseInformation"
    TagPrefix="uc6" %>
<%@ Register Src="../Controls/ReferenceDetails.ascx" TagName="ReferenceDetails" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/UserScripts/OrderDetailsTab.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/SaveOrderDetails.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/RemoveHelper.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/AddRemoveEmploymentInfo.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/AddRemoveReferenceInfo.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/LicenseInformation.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/EducationDetails.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function scrolltop() {
            window.scrollTo(0, 0);
        }

        function redirect() {
            window.location.href = "../Pages/index.aspx";
        }

        function page1height() {
            if ($.browser.msie && $.browser.version == '8.0') {
                $("#iframeViewReports").height("97%");
                $("#pnlViewReport").height("1260px");
            }
            else {
                $("#iframeViewReports").height("1300px");
                $("#pnlViewReport").height("110%");
            }
        }

        function page2height() {
            if ($.browser.msie && $.browser.version == '8.0') {
                $("#iframeViewReports").height("98%");
                $("#pnlViewReport").height("1350px");
            }
            else {
                $("#iframeViewReports").height("1400px");
                $("#pnlViewReport").height("110%");
            }
        }

        function page3height() {
            if ($.browser.msie && $.browser.version == '8.0') {
                $("#iframeViewReports").height("76%");
                $("#pnlViewReport").height("950px");
            }
            else {
                $("#iframeViewReports").height("1100px");
                $("#pnlViewReport").height("110%");
            }
        }
        function postback() {
            window.location.href = window.location.href;
        }

        //Validation of Current tab on enter key pressed

        $(function () {

            $(".validateTab").keydown(function (e) {
                if (e.which == 13) {

                    if (selectedTabTitle == "") {
                        selectedTabTitle = document.getElementById('lblPopUpHeader').innerHTML;
                    }

                    if (!$("#mstrPage").valid()) {
                        ValidateCurrentTab(selectedTabTitle);

                        e.preventDefault();
                        return false;
                    }
                    else {
                        e.preventDefault();
                        return false;
                    }
                }
            });
        });

        function CheckIfUserloggedIn() {

            var isUserLoggedIn = $('#hdnUserLoggedIn').val();
            if (isUserLoggedIn == "False") {
                $.cookie('redirectToOrderDetail', 'true');                
//                $('#messageDiv').bPopup({
//                    appendTo: 'form',
//                    modalClose: false,
//                    opacity: 0.6,
//                    positionStyle: 'fixed' //'fixed' or 'absolute'
//                });
                SignInDialog();
                
            }
            else {
                window.location.href = "../Pages/OrderDetail.aspx";
            }            
        } 

    </script>
    <style type="text/css">
        .planDetail
        {
            margin-bottom: 35px;
        }
        .SearchByRef_background
        {
            background-color: White;
            clear: both;
            min-height: 950px;
        }
        #pnlViewReport
        {
            display: none;
            height: 1250px;
            width: 1000px;
            background-color: transparent;
            top: 11% !important;
        }
        
        .ui-widget-header, .ui-tabs .ui-tabs-nav li
        {
            border: 0 none !important;
            background: none;
        }
        
        .ui-tabs .ui-tabs-nav li, ul li a
        {
            border-radius: 4px;
        }
        .ulList li a:hover
        {
            background-color: #8C8C8C !important;
            color: White !important;
        }
        .ulList li
        {
            background: none;
        }
        
       .ulList li a
        {
            font-size: 11px;
            font-weight: bold;
        }
        .ui-widget
        {
            font-family: Arial,Helvetica,sans-serif;
            font-size: 12px;
        }
        .ui-state-active a, .ui-state-active a:link, .ui-state-active a:visited
        {
            color: White;
        }
        .ui-tabs .ui-tabs-nav li.ui-tabs-active a, .ui-tabs .ui-tabs-nav li.ui-state-disabled a, .ui-tabs .ui-tabs-nav li.ui-tabs-loading a
        {
            background-color: #8C8C8C;
            cursor: text;
        }
        .addNewRefRow
        {
            background-color: #FFFFFF;
            border: medium none;
        }        
    </style>
    <!--[if gte IE 8]>
    <style type="text/css">
    .divUserProfileUpdate
    {
    width:94px;
    }
    </style>
    <![endif]-->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="SearchByRef_background">
        <div class="SearchByRef_mainDiv">
            <div class="margintop40">
                <uc1:SearchByRef ID="ucSearchHeader" runat="server" />
            </div>
            <div style="padding: 0 0 0 15px;">
                <div class="width100per paddingLeft10" style="height: 100px; padding-top: 30px;">
                    <div class="SearchByRefChosePlan_TickDiv">
                    </div>
                    <div class="SearchByRefChosePlan_ChoosePlanHeadDiv">
                        <h2 class="font-family_Arial color_3E3E3E margin_0px" style="font-weight: lighter">
                            Choose Plan as per your Requirement</h2>
                    </div>
                </div>
                <div style="padding-left: 15px;">
                    <asp:Repeater ID="plansList" runat="server" OnItemDataBound="plansList_ItemDataBound">
                        <ItemTemplate>
                            <div runat="server" id="planDispCol1" class="planDetail">
                                <uc3:PlanDisplay ID="PlanDisplay1" runat="server" />
                            </div>
                            <div runat="server" id="planDispCol2" class="planDetail">
                                <uc3:PlanDisplay ID="PlanDisplay2" runat="server" />
                            </div>
                            <div runat="server" id="planDispCol3" class="planDetail">
                                <uc3:PlanDisplay ID="PlanDisplay3" runat="server" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <!-- PopUp Divs Container -->
            <div>
                <!-- Order Status Tabs Popup -->
                <div style="width: 600px; display: none; background-color: White;" id="requiredDetails"
                    class="borderRadius6">
                    <div class="topHeaderDiv">
                        <asp:Label ID="lblPopUpHeader" runat="server" ClientIDMode="Static" Style="display: none"></asp:Label>
                        <asp:Label ID="lblAdditionalInfo" runat="server" ClientIDMode="Static" Text="Additional Information"></asp:Label>
                        <asp:Label ID="lblReviewOrder" runat="server" ClientIDMode="Static" Text="Review Information" CssClass="displayNone"></asp:Label>
                        <div class="popUpCloseButton">
                            <img src="../Images/close_icon_popup.png" alt="" onclick="CloseTab(); postback();"
                                style="cursor: pointer;" /></div>
                    </div>
                    <div id="tabs" style="border: none !important;">
                        <ul class="floatLeft ulList" style="margin-left: 30px;" id="Container">
                            <% if (isEmploymentDetails)
                               { %>
                            <li id="emp"><a href="#emp-1">Employment Details</a></li>
                            <%} %>
                            <% if (isEducationDetails)
                               { %>
                            <li id="edu"><a href="#edu-3">Education Details</a></li>
                            <%} %>
                            <% if (isLicenseDetails)
                               { %>
                            <li id="lic"><a href="#lic-3">License Info</a></li>
                            <%} %>
                            <% if (isReferenceInfo)
                               { %>
                            <li id="ref"><a href="#ref-2">Reference Details</a></li>
                            <%} %>
                        </ul>
                        <hr class="line" />
                        <div id="Contenttext" runat="server" class="paddingLeft28 alignJustify" style="padding-right:35px;" clientidmode="Static">
                            The selected package requires additional information. Please complete the required
                            information below in order to continue.</div>
                                <div id="ContenttextReadOnly"  class="paddingLeft10 paddingLeft28 alignJustify displayNone">
                                Please review the information you have entered before proceeding further.
                            </div>
                        <% if (isEmploymentDetails)
                           { %>
                        <div id="emp-1">
                            <uc5:employmentdetails id="EmploymentDetails1" runat="server" />
                        </div>
                        <%} %>
                        <% if (isEducationDetails)
                           { %>
                        <div id="edu-3">
                            <uc4:EducationalDetails ID="EducationalDetails1" runat="server" />
                        </div>
                        <%} %>
                        <% if (isLicenseDetails)
                           { %>
                        <div id="lic-3">
                            <uc6:LicenseInformation ID="LicenseInformation1" runat="server" />
                        </div>
                        <%} %>
                        <% if (isReferenceInfo)
                           { %>
                        <div id="ref-2">
                            <uc4:referencedetails id="ReferenceDetails1" runat="server" />
                        </div>
                        <%} %>
                    </div>
                    <div class="clearBoth paddingLeft28" style="margin-left:22px;" id ="divMessageContainer"> <p class="red">Data entered here will be updated in your profile.</p></div>
         
                    <div class="clearBoth floatRight" style="margin-bottom: 15px; margin-right: 10px;
                        margin-top: 5px;" id ="divBtnContainer" >
                        <input type="button" class="blackBtnMiddle whiteColor" value="Save" onclick="SaveOrderDetails(selectedTabTitle,'true');" />
                        <input type="button" class="blackBtnMiddle whiteColor" value="Save & Continue" onclick="SaveOrderDetails(selectedTabTitle,'false'); ChangeTab();" />
                        <input type="button" class="blackBtnMiddle whiteColor" value="Cancel" onclick="CloseTab();postback();" />
                    </div>
                    <div class="clearBoth floatRight displayNone" style="margin-bottom: 15px; margin-right: 10px;
                        margin-top: 5px;" id="divEditBtnContainer">
                        <input type="button" class="blackBtnMiddle whiteColor" value="Edit" onclick="EditOrderDetails();" />
                        <input type="button" class="blackBtnMiddle whiteColor" value="Continue" onclick="RedirectToPayment();" />
                    </div>
                </div>
                <!-- Drugs Verfication  Popup -->
                <asp:HiddenField ID="hdnDrugVerification" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdnDetailsPopups" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdnUserLoggedIn" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdnEditFlag" runat="server" ClientIDMode="Static" Value="1" />
                <% if (isDrugVerificationReq)
                   { %>
                <div id="DrugsVerficationDiv" class="borderRadius6" style="background-color: White;
                    display: none; width: 700px">
                    <div class="topHeaderDiv">
                        <asp:Label ID="Label1" runat="server" Text="Drugs Verification Details" ClientIDMode="Static"></asp:Label>
                        <div class="popUpCloseButton">
                            <img src="../Images/close_icon_popup.png" alt="" onclick="CloseDrugsDiv();" style="cursor: pointer;" /></div>
                    </div>
                    <uc7:DrugVerificationDetails ID="DrugVerificationDetails" runat="server" />
                    <div class="floatRight" style="margin-right: 10px">
                        <input type="button" class="blackBtnMiddle whiteColor" value="OK" onclick="SaveDrugDetails();" /></div>
                </div>
                <%} %>
                <!-- Sample Report Pop -->
                <div id="pnlViewReport">
                    <div class="bClose" onclick="postback();">
                    </div>
                    <iframe id="iframeViewReports" src="ViewSampleReport.aspx" height="105%" width="100%"
                        scrolling="no" frameborder="0"></iframe>
                </div>                
            </div>           
             
        </div>
    </div>
    <div style="height: 114px; background-color: White;" id="messageDiv" class="borderRadius6 padding10 width245 displayNone">
        <div class="closeBtnDiv">
            <a class="bClose"></a>
        </div>
        <div>
            <p class="alignJustify">
                To continue further, you need to login first.</p>    
                <p>Hit Continue button.</p>        
            <br />
            <input type="button" value="CONTINUE" onclick=" $('#messageDiv').bPopup().close(); SignInDialog();"
                class="blackBtnMiddle whiteColor" style="float:right !important" /></div>
    </div>
</asp:Content>
