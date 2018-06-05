<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="GetStarted_UncoverBackground.aspx.cs" Inherits="eknowID.Pages.GetStarted_UncoverBackground" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .SecureJobBanner
        {
            background-image: url(../images/UncoverBackground_2.png);
            width: 1800px;
            height: 240px;
        }
        .divSecJob
        {
            background-color: #E7E7E7;
            height: 435px;
            padding: 30px 0px 60px 0px;
            color: #404040;
        }
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
    <div id="SecureJobBannerOuter">
        <div class="SecureJobBanner" id="divSecureJob">
        </div>
    </div>
    <div class="heightauto divSecJob minWidth1000px">
        <div class="stretchDiv paddingLeft28 paddingTop10 divAboutUsInner" style="margin-top: 1px;
            height: 400px !important">
            <div class="width100per">
                <div class="floatLeft alignJustify" style="width: 50%; line-height: 1.5;">
                    <h1 style="margin-bottom:5px;">
                        Uncover Your Background
                    </h1>
                    <p>Ever wondered what is in a background check? <font class="headingColor">eKnowID</font> can help you find out.</p>

                    <p>Don’t let a background check spoil your career. <font class="headingColor">eKnowID</font> employs the same state of the art data technology private companies use in pre-employment, landlord screening and tenant checking.</p>
                    <p>Get a record check from <font class="headingColor">eKnowID</font> today, and <font class="headingColor">eKnowID</font> can help you by looking through millions of criminal records and put your mind at ease for as little as $14.95 with A la Carte reports.</p>
                    <br /> 
                    <br />
                    <a href="../Pages/AlacartReport.aspx" title="GET STARTED NOW" class="floatRight">
                        <img src="../images/red_get_started_btn.png" alt=""></img>
                    </a>
                </div>
                <div class="floatLeft paddingLeft25" style="width: 47%; line-height: 1.5">
                    <img src="../Images/vertical_line1.png" class="floatLeft paddingRight20" style="height: 430px;"
                        alt="" />
                    <h1>
                        Who Should Order This?
                    </h1>
                    <div class="width100per">
                        <div style="height: 150px;" class="width100per padding10">
                            <div class="floatLeft" style="width: 33%;">
                                <img src="../Images/Tenants_2.png" alt="" />
                            </div>
                            <div class="alignJustify floatLeft marginleft15" style="width: 60%;">
                                <b class="faintblack fontsize16">Tenants</b>
                                <br />
                                <p class="pText">
                                    It is easy to spend a lot of money on background checks when you are looking for
                                    apartments. With eKnowID, you can conduct your own background check to give to potential
                                    landlords.
                                </p>
                            </div>                             
                       
                    </div>
                     <div>
                            <img src="../Images/line_sign_up.png" alt="" width="350px;" class="marginleft25" />
                        </div>
                  <div style="height: 150px;" class="width100per padding10">
                            <div class="floatLeft" style="width: 33%;">
                                <img src="../Images/YoungAdults_2.png" alt="" />
                            </div>
                            <div class="alignJustify floatLeft marginleft15" style="width: 60%;">
                                <b class="faintblack fontsize16">Individuals</b>
                                <br />
                                <p class="pText">
                                    Life can be chaotic, but knowing what is in your background can give you certainty about one thing. With eKnowID, take the first step toward gaining peace of mind. 
                                </p>
                            </div>
                        </div>
                </div>
            </div>
        </div>
    </div>
   </div>
</asp:Content>
