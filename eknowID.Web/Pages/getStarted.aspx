<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/main.master" AutoEventWireup="true" CodeBehind="getStarted.aspx.cs" Inherits="eknowID.Pages.getStarted" %>

<%@ Register Src="~/Controls/partner.ascx" TagName="partners" TagPrefix="uc3" %>
<%@ Register Src="../Controls/ImageSlider.ascx" TagName="ImageSlider" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/UploadResume.ascx" TagName="UploadResume" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divGetStartedMain {
            color: #404040;
            font-size: 13px;
            height: 780px;
        }

        .margin_left_10px {
            margin-left: 10px;
        }

        .imgDiv_WhyEKnowID {
            margin-top: 35px;
            height: 97px;
            width: 69px;
        }

        .navGetStarted {
            display: none !important;
        }

        .navMenu {
            margin-left: 190px !important;
        }
    </style>
    <script type="text/javascript" language="javascript">        
        function OpenUpoadResume() {
            $.cookie('showFreeUploadResumeDialog', 'true');
            $("#divUploadResume").bPopup({
                appendTo: 'form',
                modalClose: false,
                opacity: 0.6,
                positionStyle: 'fixed'
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="width1000px margin_left_right_auto">
        <%--  <uc1:ImageSlider ID="ImageSlider1" runat="server" />--%>
    </div>
    <div class="width1000px margin_left_right_auto divGetStartedMain">
        <div class="eKnowIDModuleMainDiv padding10 marginTop15" style="height: 135px;">
            <div class="imgDiv_WhyEKnowID" style="background-image: url(../Images/resume_icon.png);">
            </div>
            <div class="moduleInfo">
                <h3 class="faintGray fontsize16 margin_0px">Free Resume Check</h3>
                <p>
                    Run a free check now to know the mistakes you are making in your resume. Delaying the check could lead you to not know whether your resume is perfect or not.
                </p>
            </div>
            <div>
                <div class="floatRight">
                    <a href="#" onclick="OpenUpoadResume();">
                        <div class="FreeResumeCheck">
                        </div>
                    </a>
                </div>
            </div>
        </div>
        <div class="GetStartModuleSeperator margin_left_right_auto">
        </div>
        <div class="eKnowIDModuleMainDiv padding10 marginTop15">
            <div class="imgDiv_WhyEKnowID">
            </div>
            <div class="moduleInfo">
                <h3 class="faintGray fontsize16 margin_0px">Background Checks For Employment</h3>
                <p>
                    Do you know what a potential employer sees during your background check process?
                    <font class="eKnowIDRed">eKnowID</font> can show you.
                </p>
                <p>
                    If you are a recent graduate/job seeker, then any one of our ‘Secure a Job’ packages
                    can let you see what the employers see. Order a package for as low as $24.95
                </p>
            </div>
            <div>
                <div class="floatLeft margin_left_10px">
                    <a href="GetStarted_SecureJob.aspx">
                        <img alt="" src="../Images/learn_more_btn.png">
                    </a>
                </div>
                <div class="floatRight">
                    <a href="SearchByProf_SelectProf.aspx">
                        <div class="SecureJobRunCheck">
                        </div>
                    </a>
                </div>
            </div>
        </div>
        <div class="GetStartModuleSeperator margin_left_right_auto">
        </div>
        <div class="eKnowIDModuleMainDiv padding10 marginTop15">
            <div class="imgDiv_WhyEKnowID" style="background-image: url(../Images/unconver_bg_icon.png);">
            </div>
            <div class="moduleInfo">
                <h3 class="faintGray fontsize16 margin_0px">Ala Carte Background Checks</h3>
                <p>
                    <font class="eKnowIDRed">eKnowID</font> enables you to identify what is in your
                    background and helping you take proactive measures to protect yourself from Identity
                    fraud and keep your credit worthiness intact.
                </p>
                <p>
                    Don’t let a background check spoil your life. Get started now and uncover your background
                    for as low as $14.95.
                </p>
            </div>
            <div>
                <div class="floatLeft margin_left_10px">
                    <a href="GetStarted_UncoverBackground.aspx">
                        <img alt="" src="../Images/learn_more_btn.png">
                    </a>
                </div>
                <div class="floatRight">
                    <a href="AlacartReport.aspx">
                        <div class="UncoverYourBgRunCheck">
                        </div>
                    </a>
                </div>
            </div>
        </div>
        <div class="GetStartModuleSeperator margin_left_right_auto">
        </div>
        <div class="eKnowIDModuleMainDiv padding10 marginTop15">
            <div class="imgDiv_WhyEKnowID" style="background-image: url(../Images/protect_icon.png);">
            </div>
            <div class="moduleInfo">
                <h3 class="faintGray fontsize16 margin_0px">Protect Your Identity</h3>
                <p>
                    It only takes a moment for your identity to get stolen. If you are receiving credit
                    cards that you didn’t order then there is a chance that you are a victim of identity
                    fraud.
                </p>
                <p>
                    Order a package with <font class="eKnowIDRed">eKnowID</font> for as low as $12.95
                    and let your mind rest in peace.
                </p>
            </div>
            <div>
                <div class="floatLeft margin_left_10px">
                    <a href="GetStarted_ProtectID.aspx">
                        <img alt="" src="../Images/learn_more_btn.png">
                    </a>
                </div>
                <div class="floatRight">
                    <a href="SelectProf_PackageSelection.aspx">
                        <div class="ProtectIDRunCheck">
                        </div>
                    </a>
                </div>
            </div>
        </div>
        <div class="marginleft20" style="margin-top: 75px;">
            <uc3:partners ID="patners" runat="server" />
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
    </div>
</asp:Content>
