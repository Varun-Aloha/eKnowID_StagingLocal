<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="GetStarted_ProtectID.aspx.cs" Inherits="eknowID.Pages.GetStarted_ProtectID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .SecureJobBanner
        {
            background-image: url(../images/Secure-Job_banner.png);
            width: 1800px;
            height: 240px;
        }
        .divSecJob
        {
            background-color: #E7E7E7;
            height: 500px;
            padding-top: 30px;
            color: #404040;
        }
        .divSmartPhoneUser
        {  height: 175px;
    margin-top: 10px;}
    </style>
    <script language="javascript" type="text/javascript">
        $(function () {
            var screenwidth = $("#mstrPage").width();
            $("#SecureJobBannerOuter").css('width', screenwidth);
            $("#SecureJobBannerOuter").css('overflow', 'hidden');
            var sliderwidth = 1800 - screenwidth;
            if (sliderwidth >= 0) {
                var minusIndex = sliderwidth / 2 * -1;
                $("#divSecureJob").css('margin-left', minusIndex);
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="SecureJobBannerOuter" class="margin_left_right_auto">
        <div class="SecureJobBanner" id="divSecureJob">
        </div>
    </div>
    <div class="heightauto divSecJob minWidth1000px" style="padding-bottom: 30px; height: 525px;">
        <div class="stretchDiv paddingLeft28 paddingTop10 divAboutUsInner" style="margin-top: 1px;
            height: 462px !important">
            <div class="width100per">
                <div class="floatLeft alignJustify" style="width: 50%; line-height: 1.5">
                    <h1>
                        Identity Theft
                    </h1>
                    <p>
                    Identity theft is the number one fraud complaint in the country. Identity theft is no longer just limited to financial frauds but crimes are being committed as well. 
                    A background check from <font class="headingColor">eKnowID</font> can help you find out if a crime or financial fraud has been committed in your name. 
                    </p>
                    <p>A simple record check can put your mind at ease and can let you take proactive measures before you are a victim of identity.</p>
                   <p>Run a self check for as little as $12.95 with <font class="headingColor">eKnowID</font> today to protect you and your loved ones against identity theft fraud.</p> 
                    <br />
                    <br />
                    <a href="../Pages/SelectProf_PackageSelection.aspx" title="GET STARTED NOW" class="floatRight">
                        <img src="../images/red_get_started_btn.png"></img>
                    </a>
                </div>
                <div class="floatLeft paddingLeft25" style="width: 47%; line-height: 1.5">
                    <img src="../Images/vertical_line1.png" class="floatLeft paddingRight20" style="height: 430px;" />
                    <h1>
                        Who Should Order This?
                    </h1>
                    <div class="width100per">
                        <div style="height: 150px;" class="width100per padding10">
                            <div class="floatLeft" style="width: 33%;">
                                <img src="../Images/YoungAdults_2.png" alt="" />
                            </div>
                            <div class="alignJustify floatLeft marginleft15" style="width: 60%;height: 180px;">
                                <b class="faintblack fontsize16">Young adults and Social Media</b>
                                <br />
                                <p class="pText">
                                    Younger age groups are often targets for identity theft because of their clean records.
                                    Also, with the nature of social media, people can access information more easily
                                    and readily. People who post often, especially on public platforms, are at higher
                                    risk for identity theft.
                                </p>
                            </div>
                        </div>
                        <div style="height: 20px;">
                            <img src="../Images/line_sign_up.png" alt="" width="350px;" class="marginleft25" />
                        </div>
                    </div>
                    <div class="width100per divSmartPhoneUser">
                        <div style="height: 150px" class="width100per padding10">
                            <div class="floatLeft" style="width: 33%;">
                                <img src="../Images/SmartPhoneUsers_2.png" alt="" />
                            </div>
                            <div class="alignJustify floatLeft marginleft15" style="width: 60%;">
                                <b class="faintblack fontsize16">Smartphone Users</b>
                                <br />
                                <p class="pText">
                                    Smartphones have given users the ability to easily access important and private
                                    information. However, while people tend to be careful to password protect computers
                                    and other places housing delicate information, a large percentage of Smartphone
                                    users do not password protect their phone which makes them more at risk for theft.
                                </p>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
