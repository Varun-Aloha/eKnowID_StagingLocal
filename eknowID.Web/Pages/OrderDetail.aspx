<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="OrderDetail.aspx.cs" Inherits="eknowID.Pages.OrderDetail" %>

<%@ Register Src="~/Controls/SearchByProfHeader.ascx" TagName="SearchByRef" TagPrefix="uc_SearchByProf" %>
<%@ Register Src="~/Controls/IdentityTheftSearchByProfHeader.ascx" TagName="IdentityTheft_SearchByRef"
    TagPrefix="IdTheft" %>
<%@ Register Src="~/Controls/OrderDetails_ContactInfo.ascx" TagName="ContactInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/EmploymentDetails.ascx" TagName="EmploymentDetails"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/EducationalDetails.ascx" TagName="EducationalDetails"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/ReferenceDetails.ascx" TagName="ReferenceDetails" TagPrefix="uc1" %>
<%@ Register Src="../Controls/LicenseInformation.ascx" TagName="LicenseInformation"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/DrugsVerficationDetails.ascx" TagName="DrugVerificationDetails"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/UploadResume.ascx" TagName="UploadResume" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/UserScripts/OrderDetailsTab.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/SaveOrderDetails.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/RemoveHelper.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/AddRemoveEmploymentInfo.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/AddRemoveReferenceInfo.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/EducationDetails.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/LicenseInformation.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/ContactInfo.js" type="text/javascript"></script>
    <!--[if lt IE 9]>
    <script src="../Scripts/Tooltip/jquery.bgiframe.min.js" type="text/javascript"></script>
    <script src="../Scripts/Tooltip/excanvas.js" type="text/javascript"></script>
    <![endif]-->
    <script src="../Scripts/Tooltip/jquery.bt.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery.bt.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        var tabIndex = "";
        var selectedTabTitle = "";
        $(function () {
            $("#tabs").tabs({
                select: function (event, ui) {
                    tabIndex = ui.index;
                    selectedTabTitle = $(ui.tab).text();
                    HideButtons(tabIndex);
                }
            });
        });

        function HideButtons(Index) {
            if (Index == 5) {
                $("#buttonContainer").hide();
            }
            else {
                $("#buttonContainer").show();
            }
        }

        $(function () {

            $(".validateTab").keydown(function (e) {
                if (e.which == 13) {
                    var mobileNumber = 10;
                    if (selectedTabTitle == "") {
                        selectedTabTitle = "Contact Information";
                        mobileNumber = $("#txtCntMobile").val().length;
                    }
                    if (!$('#mstrPage').valid() || (mobileNumber != 10 && mobileNumber != 0)) {
                        selectedTabTitle = selectedTabTitle.replace(/^\s+|\s+$/g, '');
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

        $(window).load(function () {
            var showUploadResumeDialog = $.cookie('showUploadResumeDialog');
           if (showUploadResumeDialog == "true") {
            <% if(! isResumeCheckerModule){ %>
                $("#divUploadResume").bPopup({
                    appendTo: 'form',
                    modalClose: false,
                    opacity: 0.6,
                    positionStyle: 'fixed'
                });
                <%} %>
         }
            $.cookie('showUploadResumeDialog', 'false');
            $.cookie('redirectToOrderDetail', 'false');
        });

        function ProfileMeter(percentage) {
            var testa = 'width:' + percentage + '%;';
            $('.profileComplete').attr('style', testa);
        }

        $("#blackBtnMiddle").css("float", "right");


        $(function () {
            $('#divTooltip').hide();
            $('#imgHelp').bt({
                positions: 'top',
                contentSelector: "$('#divTooltip')", /*hidden div*/
                trigger: ['click'],
                width: 220,
                centerPointX: .5,
                spikeLength: 5,
                spikeGirth: 10,
                padding: 10,
                cornerRadius: 4,
                fill: '#FFF',
                strokeStyle: '#ABABAB',
                strokeWidth: 2
            });
        });

        //Retreive all fields data on page load for spell error checking
//        window.onbeforeunload=setOrderData;

//        function setOrderData()
//        {
//            var spellErrorData = " ";
//            $('input[type=text]').each(function () {
//                if ($('#' + this.id).hasClass('digitsOnly') == false)
//                { spellErrorData = spellErrorData + this.value + " "; }
//            });

//            $('textarea').each(function () {
//                if ($('#' + this.id).hasClass('digitsOnly') == false)
//                { spellErrorData = spellErrorData + this.value + " "; }
//            });

//            var controlData = "spellCheckText :'" + spellErrorData + "'";
//            $.ajax({
//                type: "POST",
//                async: false,
//                url: "orderHandling.aspx/SetSpellErrorData",
//                contentType: "application/json; charset=utf-8",
//                data: "{" + controlData + "}",
//                dataType: "json",
//                success: function (result) {                   
//                }
//            });
//        }

    </script>
    <style type="text/css">
        .lightgrayBackGround
        {
            background-color: White;
            border-style: none;
        }
        .lightgrayBackGroundHeight
        {
            height: 380px !important;
        }
        .popupDivstyle
        {
            padding-left: 0px !important;
        }
        .addNewRefRow
        {
            background-color: #FFFFFF;
            border: medium none;
        }
        .divAddNewRefRow
        {
            clear: both;
            float: right;
            /*margin-bottom: 5px;*/
        }
        .educationBody
        {
            height: auto !important;
            overflow: visible !important;
        }
        /*  #tabs
        {
            border: 0px;
            background: none;
        }*/
        #MainTabContainer
        {
            border: 1px solid #DBDBDB;
            border-radius: 6px 6px 6px 6px;
            box-shadow: 2px 2px 4px #8A8A8A;
            height: auto;
        }
        .ui-widget-header, .ui-tabs .ui-tabs-nav li
        {
            border: 0 none !important;
            background: none;
        }
        .ui-tabs .ui-tabs-nav li.ui-tabs-active a
        {
            background-image: url(../Images/bg_menu_selected.png) !important;
        }
        #tabs li
        {
            padding: 1px;
        }
        .Width510
        {
            width: 510px;
        }
        #tabs li a
        {
            border: 1px solid #ccc;
            padding: 0px 10px 0px 10px;
            text-decoration: none;
            background-color: #eeeeee;
            border-bottom: none;
            outline: none;
            border-radius: 5px 5px 0 0;
            -moz-border-radius: 5px 5px 0 0;
            -webkit-border-top-left-radius: 5px;
            -webkit-border-top-right-radius: 5px;
            background-image: url(../Images/bg_menu_unselected.png);
            font-weight: bold;
            font-size: 11px;
            width: 245px;
        }
        #tabs .redbtn a
        {
            background-image: url(../Images/profile_tab_red_middle_side.png);
        }
        /*#tabs
        {
            margin-left: 12px;
            width: 1000px;
        }*/
        #tabs
        {
            border: 0px;
            background: none;
        }
        .ui-widget
        {
            font: inherit;
        }
        /*    #divUserPost
        {
            border: 2px solid #dddddd;
            padding-left: 14px;
        } */
        .divUserGrad
        {
            border: 2px solid #dddddd;
            padding-left: 14px !important;
        }
        /*    .divUserContactInfo
        {
            margin-left: 11px;
        }
       #tabs-1
        {
            border: 2px solid #DDDDDD;
            border-radius: 6px 6px 6px 6px;
            margin: 25px 0px 26px 32px;
            padding: 0px 0px 12px 0px;
        }*/
        .tabs
        {
            padding: 25px !important;
            width: 86.5%;
            border-width: 0px;
        }
        .divUserLicenseInfo
        {
            border: 2px solid #DDDDDD;
            border-radius: 6px 6px 6px 6px;
            margin-left: 10px;
        }
        #tabs li a div label
        {
            line-height: 41px;
            vertical-align: top;
        }
        #tabs li a div img
        {
            margin-top: 5px;
        }
        .profileComplete
        {
            height: 100%;
            background-color: Green;
            border-radius: 5px 5px 5px 5px;
            width: 0px;
        }
        .Savebtn
        {
            background-image: url("../images/continue.png");
            /*background-repeat: repeat-x;*/
            border: 0 none;
            border-radius: 5px 5px 5px 5px;
            float: right;
            font-weight: bold;
            height: 30px;
            width:108px;
            margin: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:HiddenField ID="hdnModuleName" runat="server" ClientIDMode="Static" />
    <div style="height: auto; min-height: 450px; min-width: 1000px; display: inline-block;
        width: 100%; background-color: #E7E7E7;">
        <div id="divTooltip" style="display: none;">
            Button will be enabled after filling all the mandatory information.<a href="javascript:void($('#imgHelp').btOff());"><img
                src="../Images/close_20x20.png" alt="close" width="12" height="12" class="gmap-close floatRight"
                style="margin-top: -15px; margin-right: -5px;" /></a>
        </div>
        <div class="stretchDiv">
            <div style="padding: 30px 0px; width: auto;">
                <div class="floatLeft">
                    <div>
                        <h2 class="divSelectProfHeading margin_0px" style="margin-left:5px;"> 
                            Welcome
                            <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>,
                        </h2> 
                        <% if (isResumeCheckerModule == false)
                                 { %>
                        <uc_SearchByProf:SearchByRef ID="ucSearchHeader" runat="server" />      
                        <IdTheft:IdentityTheft_SearchByRef ID ="IdentityTheft_SearchByRef" runat="server" />     
                        <%} %>       
                          <% if (isResumeCheckerModule == true)
                             { %>
                        <div class="divSelectProfHeading marginLeft5">
                <asp:Label ID="lblSelectByProf" runat="server" Text=" Import Profile"></asp:Label>
                <%} %>
            </div>      
                    </div>
               
                <div class="floatLeft width100per marginTop15">
                  <% if (isResumeCheckerModule == false)
                     { %>
                        <div class="floatLeft height_30px">
                        Your package selected requires following information:
                        </div>
                    <%} %>
                     <% if (isResumeCheckerModule == true)
                     { %>
                    <div class="floatLeft height_30px" style="margin:0px 0px 10px 5px;">
                    Please Review the information below and click on the 'Free Analysis' button to proceed.
                    </div>
                    <%} %>
                    <div class="floatLeft width200 borderRadius6" style="height: 10px;">
                        <div class="profileComplete">
                        </div>
                    </div>
                </div>
            </div>
            <div class="width100per floatLeft marginBottom30">
                <div class="width50" style="margin-left: -50px;">
                    <div class="width50 height50">
                        <img id="imgConDetail" src="../Images/greenTick.png" alt="" class="displayNone" />
                    </div>
                    <div class="width50 height50">
                        <img id="imgEmpDetail" src="../Images/greenTick.png" alt="" class="displayNone" />
                    </div>
                    <div class="width50 height50">
                        <img id="imgEduDetail" src="../Images/greenTick.png" alt="" class="displayNone" />
                    </div>
                    <div class="width50 height50">
                        <img id="imgLicDetail" src="../Images/greenTick.png" alt="" class="displayNone" />
                    </div>
                    <div class="width50 height50">
                        <img id="imgRefDetail" src="../Images/greenTick.png" alt="" class="displayNone" />
                    </div>
                </div>
                <div id="tabs" style="margin-top: -265px;">
                    <div style="float: left; width: 30%;">
                        <ul style="width: 100%; background-image: none;">
                            <li id="Contact"><a href="#tabs-1" style="color: White; font-size: 13px;">
                                <div class="height48">
                                    <img src="../Images/profile_icon_contact.png" alt="" /><label>Contact Information</label></div>
                            </a></li>
                            <% if (isEmploymentDetails)
                               { %>
                            <li id="emp"><a href="#tabs-2" style="color: White; font-size: 13px;">
                                <div class="height48">
                                    <img src="../Images/profile_icon_experience.png" alt="" /><label>Professional Experience</label></div>
                            </a></li>
                            <%} %>
                            <% if (isEducationDetails)
                               { %>
                            <li id="edu"><a href="#tabs-3" style="color: White; font-size: 13px;">
                                <div class="height48">
                                    <img src="../Images/profile_icon_education.png" alt="" /><label>Education</label></div>
                            </a></li>
                            <%} %>
                            <% if (isLicenseDetails)
                               { %>
                            <li id="lic"><a href="#tabs-5" style="color: White; font-size: 13px;">
                                <div class="height48">
                                    <img src="../Images/profile_icon_car.png" alt="" class="marginLeft7 marginTop8" /><label
                                        class="marginLeft7">Driving Record</label></div>
                            </a></li>
                            <%} %>
                            <% if (isReferenceInfo)
                               { %>
                            <li id="ref"><a href="#tabs-6" style="color: White; font-size: 13px;">
                                <div class="height48">
                                    <img src="../Images/profile_icon_reference.png" alt="" /><label>Reference Details</label></div>
                            </a></li>
                            <%} %>
                        </ul>
                    </div>
                    <div id="MainTabContainer" class="floatLeft marginTop5" style="width: 69%;">
                        <div style="float: left; width: 100%; background-color: #FFFFFF;">
                            <div class="clearBoth">
                                <div id="tabs-1" class="floatLeft tabs width100per">
                                    <uc1:ContactInfo ID="ContactInfo1" runat="server" />
                                </div>
                                <% if (isEmploymentDetails)
                                   { %>
                                <div id="tabs-2" class="floatLeft tabs width100per">
                                    <uc1:EmploymentDetails ID="EmploymentDetails1" runat="server" />
                                </div>
                                <%} %>
                                <% if (isEducationDetails)
                                   { %>
                                <div id="tabs-3" class="floatLeft tabs width100per">
                                    <uc1:EducationalDetails ID="EducationalDetails1" runat="server" />
                                </div>
                                <%} %>
                                <% if (isLicenseDetails)
                                   { %>
                                <div id="tabs-5" class="floatLeft tabs width100per">
                                    <uc1:LicenseInformation ID="LicenseInformation1" runat="server" />
                                </div>
                                <%} %>
                                <% if (isReferenceInfo)
                                   { %>
                                <div id="tabs-6" class="floatLeft tabs width100per">
                                    <uc1:ReferenceDetails ID="ReferenceDetails1" runat="server" />
                                </div>
                                <%} %>
                            </div>
                            <div class="clearBoth">
                           
                                <div id="buttonContainer" class="divSaveUserProfileBtn" style="margin-right:25px;">
                                  <img src="../Images/help.png" alt="" id="imgHelp" class="floatRight cursorPointer" />      
                                    <input type="button" id="btnCheckOut" disabled="disabled" class="floatRight height_30px width202 padding0 marginleft15"
                                        style="background-image: url(../Images/proceed_disable.png); background-repeat: no-repeat;
                                        border-width: 0px;" onclick="RedirectToPayment()" />
                                    
                                    <input type="button" class="Savebtn whiteColor" style="float: right !important;
                                        margin: 0px;" onclick="SaveUserProfileDetails(selectedTabTitle,'false'); ChangeProfileTab();" />
                                </div>
                                <div class="floatLeft" style="margin-left: 10px; background-color: Red;">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnDrugVerification" runat="server" ClientIDMode="Static" />
            <% if (isDrugVerificationReq)
               { %>
            <div id="DrugsVerficationDiv" class="borderRadius6" style="background-color: White;
                display: none; width: 700px">
                <div class="topHeaderDiv">
                    <asp:Label ID="Label1" runat="server" Text="Drugs Verification Details" ClientIDMode="Static"></asp:Label>
                    <div class="popUpCloseButton">
                        <img src="../Images/close_icon_popup.png" alt="" onclick="CloseDrugsDiv();" style="cursor: pointer;" /></div>
                </div>
                <uc1:drugverificationdetails id="DrugVerificationDetails" runat="server" />
                <div class="floatRight" style="margin-right: 10px">
                    <input type="button" class="blackBtnMiddle whiteColor" value="OK" onclick="SaveDrugDetails();" /></div>
            </div>
            <%} %>
        </div> </div>
    </div>
    <div class="displayNone" id="divUploadResume" style="height: auto;">
        <div class="width447 borderRadiusTopCorners6" style="background-color: White;">
            <div class="floatRight">
               <% if (isResumeCheckerModule == false)
                  { %>
                <a class="dialogClose" onclick="CloseResumeDialog();"></a>               
            </div>
            <uc1:UploadResume ID="uploadResume" runat="server" />
            <br />
            <br /> <%} %>
        </div>
        <img src="../Images/sign_in_bottom_white_bg_new.png" alt="" class="width447 height21" />
    </div>
</asp:Content>
