<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="UserProfile.aspx.cs" Inherits="eknowID.Pages.UserProfile" %>

<%@ Register Src="../Controls/ContactInfo.ascx" TagName="ContactInfo" TagPrefix="uc1" %>
<%@ Register Src="../Controls/EmploymentDetails.ascx" TagName="EmploymentDetails"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/EducationalDetails.ascx" TagName="EducationalDetails"
    TagPrefix="uc3" %>
<%--<%@ Register Src="../Controls/AdditionalSkills.ascx" TagName="AdditionalSkills" TagPrefix="uc4" %>--%>
<%--<%@ Register Src="../Controls/LanguageKnown.ascx" TagName="LanguageKnown" TagPrefix="uc5" %>--%>
<%@ Register Src="../Controls/ReferenceDetails.ascx" TagName="ReferenceDetails" TagPrefix="uc6" %>
<%@ Register Src="../Controls/LicenseInformation.ascx" TagName="LicenseInformation"
    TagPrefix="uc7" %>
<%@ Register Src="~/Controls/UploadResume.ascx" TagName="UploadResume" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/UserScripts/SaveUserProfileDetails.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/RemoveHelper.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/AddRemoveLanguages.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/AddRemoveEmploymentInfo.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/AddRemoveReferenceInfo.js" type="text/javascript"></script>
    <%--<script src="../Scripts/UserScripts/AddRemoveSkills.js" type="text/javascript"></script>--%>
    <script src="../Scripts/UserScripts/EducationDetails.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/LicenseInformation.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/ContactInfo.js" type="text/javascript"></script>
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

            var showPopup = $.cookie('showUploadResumeDialog');
            $.cookie('showFreeUploadResumeDialog', 'false');
            if (showPopup == "true") {
                $("#divUploadResume").bPopup({
                    appendTo: 'form',
                    modalClose: false,
                    opacity: 0.6,
                    positionStyle: 'fixed'
                });
            }
            $.cookie('showUploadResumeDialog', 'false');
        });

        function OpenUpoadResume() {
            $("#divUploadResume").bPopup({
                appendTo: 'form',
                modalClose: false,
                opacity: 0.6,
                positionStyle: 'fixed'
            });
        }
        $(document).ready(function () {

            if (navigator.userAgent.indexOf('Safari') != -1 && navigator.userAgent.indexOf('Chrome') == -1) {
                $('.divSaveUserProfileBtn').attr('style', 'padding-right: 21px !important; width: 271px !important;');
            }
        });
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
            float: right; /*margin-right: 85px;*/           
        }
        
        .educationBody
        {
            height: auto !important;
            overflow: visible !important;
        }
        
        #tabs
        {
            border: 0px;
            background: none;
        }
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
        .ui-widget
        {
            font: inherit;
        }
        /* #divUserPost
        {
            border: 2px solid #dddddd;
            padding-left: 14px;
        }*/
        .divUserGrad
        {
            border: 2px solid #dddddd;
            padding-left: 14px !important;
        }
        /*   .divUserContactInfo
        {
            margin-left: 11px;
        }*/
        /*  #tabs-1
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
        
        .close
        {
            cursor: pointer;
            position: absolute;
            background-image: url(../Images/Close_icon.png);
            background-repeat: no-repeat;
            height: 35px;
            width: 35px;
            margin-left: -20px;
            margin-top: -15px;
        }
        .divSaveUserProfileBtn
        {
             padding-right: 15px !important;
             width: 265px !important;
        }       
    </style>
<!--[if IE 9]>
	<style type="text/css">
     .divSaveUserProfileBtn
        {
             padding-right: 21px !important;
             width: 268px !important;
        }
        </style>
<![endif]-->
<!--[if IE 8]>
	<style type="text/css">
     .divSaveUserProfileBtn
        {
             padding-right: 20px !important;
             width: 268px !important;
        }
        </style>
<![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: auto; min-height: 450px; min-width: 1000px; display: inline-block;
        width: 100%; background-color: #E7E7E7;">
        <div class="stretchDiv">
            <div style="margin: auto; width: auto; padding: 30px 10px 30px 6px;">
                <div>
                    <h1 class="SearchByRefUC_heading marginBottom0 marginTop0" style="padding-left: 0px;">
                        My Profile</h1>
                </div>
                <br />
                <div class="width100per" style="margin-right: -21px">
                    <h2 class="SearchByRefUC_heading floatLeft margin_0px">
                        Welcome
                        <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>,
                    </h2>
                    <div class="floatLeft">
                        <%--Profile Completenees--%></div>
                    <div class="floatLeft width200 borderRadius6" style="height: 10px;">
                        <div class="profileComplete">
                        </div>
                    </div>
                    <div class="floatRight">
                        <input type="button" id="btnImportProfile" class="floatRight height25px padding0"
                            style="width: 132px; background-image: url(../Images/import_profile.png); background-repeat: no-repeat;
                            border: 0px;" onclick="OpenUpoadResume()" /></div>
                </div>
            </div>
            <div class="floatLeft marginBottom30">
                <div id="tabs">
                    <div style="float: left; width: 30%;">
                        <ul style="width: 100%; background-image: none;">
                            <li><a href="#tabs-1" style="color: White; font-size: 13px;">
                                <div class="height48">
                                    <img src="../Images/profile_icon_contact.png" alt="" /><label>Contact Information</label></div>
                            </a></li>
                            <li><a href="#tabs-2" style="color: White; font-size: 13px;">
                                <div class="height48">
                                    <img src="../Images/profile_icon_experience.png" alt="" /><label>Professional Experience</label></div>
                            </a></li>
                            <li><a href="#tabs-3" style="color: White; font-size: 13px;">
                                <div class="height48">
                                    <img src="../Images/profile_icon_education.png" alt="" /><label>Education</label></div>
                            </a></li>
                            <li><a href="#tabs-5" style="color: White; font-size: 13px;">
                                <div class="height48">
                                    <img src="../Images/profile_icon_car.png" alt="" class="marginLeft7 marginTop8" /><label
                                        class="marginLeft7">Driving Record</label></div>
                            </a></li>
                            <li><a href="#tabs-6" style="color: White; font-size: 13px;">
                                <div class="height48">
                                    <img src="../Images/profile_icon_reference.png" alt="" /><label>Reference Details</label></div>
                            </a></li>
                        </ul>
                    </div>
                    <div id="MainTabContainer" class="marginTop5" style="width: 69%; float: left;">
                        <div style="float: left; width: 100%; background-color: #FFFFFF;">
                            <%--<asp:Label ID ="lblMessageContactInfo" runat="server" CssClass="paddingLeft25" ClientIDMode="Static" Text="Test"/>--%>
                            <div class="clearBoth">
                                <div id="tabs-1" class="floatLeft tabs">
                                    <uc1:ContactInfo ID="ContactInfo1" runat="server" />
                                </div>
                                <div id="tabs-2" class="floatLeft tabs">
                                    <uc2:EmploymentDetails ID="EmploymentDetails1" runat="server" />
                                </div>
                                <div id="tabs-3" class="floatLeft tabs">
                                    <uc3:EducationalDetails ID="EducationalDetails1" runat="server" />
                                </div>
                                <%-- <div id="tabs-4" class="floatLeft Width510">
                                    <div class="AddSkills marginLeft25">
                                        <uc4:AdditionalSkills ID="AdditionalSkills1" runat="server" />
                                    </div>
                                    <div class="clearBoth">
                                        <hr class="darkGrey clearBoth" />
                                    </div>
                                    <div class="LanguagesKnown marginLeft25">
                                        <uc5:LanguageKnown ID="LanguageKnown" runat="server" />
                                    </div>
                                    <div class="clearBoth">
                                        <hr class="darkGrey clearBoth" />
                                    </div>
                                </div>--%>
                                <div id="tabs-5" class="floatLeft tabs">
                                    <uc7:LicenseInformation ID="LicenseInformation1" runat="server" />
                                </div>
                                <div id="tabs-6" class="floatLeft tabs">
                                    <uc6:ReferenceDetails ID="ReferenceDetails1" runat="server" />
                                </div>
                                <!-- <div id="tabs-7" class="floatLeft Width510">
                                    <h1>
                                        Back Ground Check</h1>
                                    <p>
                                        Proin elit arcu, rutrum commodo, vehicula tempus, commodo a, risus. Curabitur nec
                                        arcu. Donec sollicitudin mi sit amet mauris. Nam elementum quam ullamcorper ante.
                                        Etiam aliquet massa et lorem. Mauris dapibus lacus auctor risus. Aenean tempor ullamcorper
                                        leo. Vivamus sed magna quis ligula eleifend adipiscing. Duis orci. Aliquam sodales
                                        tortor vitae ipsum. Aliquam nulla. Duis aliquam molestie erat. Ut et mauris vel
                                        pede varius sollicitudin. Sed ut dolor nec orci tincidunt interdum. Phasellus ipsum.
                                        Nunc tristique tempus lectus.</p>
                                </div>-->
                            </div>
                            <div class="clearBoth">
                                <%--   <div style="height: 10px; width: 100%; background-repeat: no-repeat; background-image: url(../Images/UserProfile_seperator.png);">
                                </div>--%>
                                <div id="buttonContainer" class="floatLeft divSaveUserProfileBtn">
                                    <input type="button" value="SAVE PROFILE" class="blackBtnMiddle whiteColor" onclick="SaveUserProfileDetails(selectedTabTitle,'true')" />
                                    <input type="button" value="SAVE & CONTINUE" class="blackBtnMiddle whiteColor" onclick="SaveUserProfileDetails(selectedTabTitle,'false'); ChangeProfileTab();" />
                                </div>
                                <div class="floatLeft" style="margin-left: 10px; background-color: Red;">
                                </div>
                            </div>
                        </div>
                        <!--Do not delete this code need to include once the we coded the verify my Profile functionality -->
                        <!--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        <!--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        <!--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        <!--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        <!--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        <!--   <div class="RightContent floatLeft">
                            <div class="alignJustify marginTop15">
                                <div class="rightContentHeaderBG">
                                    <h3>
                                        Verify My Profile
                                    </h3>
                                </div>
                                <div class="contentPadding">
                                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem
                                    Ipsum has been the industry's standard dummy text ever since 1500s, when an unknown
                                    printer took a gallery of type and scrambled it to make a type specimen book. It
                                    has survived not only five centuries, but also the leap into electronic typesetting,
                                    remaining essentially unchanged</div>
                                <div class="floatRight">
                                    <asp:Button ID="btnVerifyProfile" runat="server" Text="Verify My Profile" CssClass="contentBtnBg boldText"
                                        Style="font-size: 11px;" />
                                </div>
                            </div>
                            <div class="RightDiv2 alignJustify clearBoth" style="margin-top: 50px;">
                                <div class="rightContentHeaderBG">
                                    <h3>
                                        Share My Profile
                                    </h3>
                                </div>
                                <div class="contentPadding">
                                    The Standard chunck of Lorem Ipsum used since the 1500s is reproduced below for
                                    those intrested. Sections 1.10.32 and 1.10.33 from "de Finibus Bonorum et Malorum"
                                    by Cicero are also reproduced in their exact original form, accompanied by English
                                    Versions from the 1914 Translation by H. Rackham</div>
                                <div class="floatRight">
                                    <asp:Button ID="btnShareProfile" runat="server" Text="Share My Profile" CssClass="contentBtnBg boldText"
                                        Style="font-size: 11px; margin-bottom: 15px;" />
                                </div>
                            </div>
                        </div>-->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="displayNone" id="divUploadResume" style="height: auto;">
        <div class="width447 borderRadiusTopCorners6" style="background-color: White;">
            <div class="floatRight">
                <a class="dialogClose" onclick="CloseResumeDialog();"></a>
            </div>
            <uc1:UploadResume ID="uploadResume" runat="server" />
            <br />
            <br />
        </div>
        <img src="../Images/sign_in_bottom_white_bg_new.png" alt="" class="width447 height21" />
    </div>
</asp:Content>
