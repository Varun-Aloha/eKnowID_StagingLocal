<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="UploadResume.aspx.cs" Inherits="eknowID.Pages.UploadResume" %>

<%@ Register Src="~/Controls/RCheckerHeader.ascx" TagName="RCheckerHeader" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ContactInfo.ascx" TagName="ContactInfo" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/EmploymentDetails.ascx" TagName="ProfExperience" TagPrefix="uc3" %>
<%@ Register Src="~/Controls/EducationalDetails.ascx" TagName="Education" TagPrefix="uc4" %>
<%@ Register Src="~/Controls/ReferenceDetails.ascx" TagName="Reference" TagPrefix="uc5" %>
<%@ Register Src="~/Controls/LicenseInformation.ascx" TagName="License" TagPrefix="uc6" %>
<%--<%@ Register Src="~/Controls/RUpload.ascx" TagName="RUpload" TagPrefix="uc7" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/UserScripts/SaveUserProfileDetails.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/RemoveHelper.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/AddRemoveLanguages.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/AddRemoveEmploymentInfo.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/AddRemoveReferenceInfo.js" type="text/javascript"></script>
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

                    if (selectedTabTitle == "") {
                        selectedTabTitle = "Contact Information";
                    }
                    if (!$('#mstrPage').valid()) {
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
            $("#divUploadResume").bPopup({
                appendTo:'form',
                modalClose: false,
                opacity: 0.6,
                positionStyle: 'fixed'
            });
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
            float: right;
            margin-right: 85px;
            /*margin-bottom: 5px;*/
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
        #tabs
        {
            margin-left: 12px;
            width: 1000px;
        }
        .ui-widget
        {
            font: inherit;
        }
        #divUserPost
        {
            border: 2px solid #dddddd;
            padding-left: 14px;
        }
        .divUserGrad
        {
            border: 2px solid #dddddd;
            padding-left: 14px !important;
        }
        .divUserContactInfo
        {
            margin-left: 11px;
        }
        .divUserLicenseInfo
        {
            border: 2px solid #DDDDDD;
            border-radius: 6px 6px 6px 6px;
            margin-left: 10px;
        }
        #tabs-1
        {
            border: 2px solid #DDDDDD;
            border-radius: 6px 6px 6px 6px;
            margin: 25px 0px 26px 32px;
            padding: 0px 16px 12px 0px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="SearchByRef_background" style="margin-bottom: 50px">
        <div class="SearchByRef_mainDiv">
            <div>
                <uc1:RCheckerHeader ID="ucRChecker" runat="server" />
            </div>
            <h3>
                My Resume</h3>
            <p class="alignJustify">
                Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh
                euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
            <br />
            <div class="floatLeft" style="margin-bottom: 20px;">
                <div id="tabs">
                    <div style="float: left;">
                        <ul style="width: 275px; background-image: none;">
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
                                    <img src="../Images/profile_icon_license.png" alt="" /><label>License</label></div>
                            </a></li>
                            <li><a href="#tabs-6" style="color: White; font-size: 13px;">
                                <div class="height48">
                                    <img src="../Images/profile_icon_reference.png" alt="" /><label>Reference Details</label></div>
                            </a></li>
                        </ul>
                    </div>
                    <div id="MainTabContainer" class="floatLeft marginTop5">
                        <div style="float: left; width: 630px; background-color: #FFFFFF;" class="paddingTop15">
                            <div class="clearBoth">
                                <div id="tabs-1" class="floatLeft Width510">
                                    <uc2:ContactInfo ID="ContactInfo1" runat="server" />
                                </div>
                                <div id="tabs-2" class="floatLeft Width510">
                                    <uc3:ProfExperience ID="EmploymentDetails1" runat="server" />
                                </div>
                                <div id="tabs-3" class="floatLeft Width510">
                                    <uc4:Education ID="EducationalDetails1" runat="server" />
                                </div>
                                <div id="tabs-5" class="floatLeft Width510">
                                    <uc6:License ID="LicenseInformation1" runat="server" />
                                </div>
                                <div id="tabs-6" class="floatLeft Width510">
                                    <uc5:Reference ID="ReferenceDetails1" runat="server" />
                                </div>
                            </div>
                            <div class="clearBoth">
                                <div style="height: 10px; width: 100%; background-repeat: no-repeat; background-image: url(../Images/UserProfile_seperator.png);">
                                </div>
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
    <div id="divUploadResume" class="borderRadius6 displayNone" style="background-color: White;
     width: 375px; height:190px;">
    <iframe src="RC_ProcessResume.aspx" style="border:0px; height:100%; width:100%;">    
    </iframe>
    </div>
        </div>       
    </div>
</asp:Content>
