<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="eknowID.Pages.Home" %>

<%@ Register Src="~/Controls/latestNews.ascx" TagName="latestNews" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/partner.ascx" TagName="partners" TagPrefix="uc3" %>
<%@ Register Src="../Controls/ImageSlider.ascx" TagName="ImageSlider" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/UploadResume.ascx" TagName="UploadResume" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--[if IE 8]>
	<style type="text/css">
.marginLeft_5
{
    margin-left:-5px !important;
}
</style>
<![endif]-->
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
        <uc1:ImageSlider ID="ImageSlider1" runat="server" />  
    <div id="sliderContent" class="minWidth1000px">
        <div class="stretchDiv">
        <a href="PressLink.aspx" class="txtDecorationNone">
            <div class="clearBoth margin_left_right_auto divPressLink">
                <div class="floatRight divEreNet">
                </div>
                <div class="floatRight divInformationWeek">
                </div>
                <div class="floatRight divSfGate">
                </div>
                <div class="floatRight divForbes">
                </div>
                <div class="floatRight divMoneyWatch">
                </div>
            </div>
            </a>
            <div class="stretchDiv grahicImage">
                <p class="WhyEknowIDHeading">
                    Why eKnowID?</p>
                <div class="stretchDiv divYouTubeSearchMain">
                    <div class="divYoutubeHomePage floatLeft">
                        <iframe id="iframeYoutube" runat="server" width="420" height="255" src="http://www.youtube.com/embed/RP8Xj0oUW4U?feature=player_detailpage&wmode=transparent"
                            frameborder="0"></iframe>
                    </div>
                    <div class="floatLeft divSearchPercentageMain">
                        <div class="divSearchPercentage">
                            Employers requiring background checks - 70%<br />
                            <div class="divSearchProgressBackground">
                                <div class="divSearchProgressForeground" style="width: 70%;">
                                </div>
                            </div>
                        </div>
                        <div class="divSearchPercentage marginTop20">
                            Background checks containing errors - 50%<br />
                            <div class="divSearchProgressBackground">
                                <div class="divSearchProgressForeground" style="width: 50%;">
                                </div>
                            </div>
                        </div>
                        <div class="divSearchPercentage marginTop20">
                            Consumers unaware of background errors and outdated information - 65%<br />
                            <div class="divSearchProgressBackground">
                                <div class="divSearchProgressForeground" style="width: 65%;">
                                </div>
                            </div>
                        </div>
                        <div class="divSearchPercentage marginTop20">
                            eKnowID Satisfaction Guarantee - 100%<br />
                            <div class="divSearchProgressBackground">
                                <div class="divSearchProgressForeground" style="width: 100%;">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="peopleSay" class="floatLeft">
                    <div class="divWhatPeopleSayHeading">
                        <span class="marginleft20">What people say about us</span></div>
                    <div id="peopleImage" class="floatLeft">
                        <img id="imgTestimonialsImage" runat="server" src="../Images/image_1_testimonial.png"
                            alt="" width="75" height="75" style="margin-top: 15px;" />
                    </div>
                    <div id="peopleThaught">
                        <div id="divTestimonialsContent" runat="server">
                            I was having trouble landing a job, so I used eKnowID to see what my potential employers
                            were seeing in my background check. eKnowID investigators checked my history, and
                            I was surprised to see false information under my name. I was able to use the information
                            eKnowID gave me in order fix these issues and ensure better job prospects in the
                            future!
                        </div>
                        <br />
                        <strong id="divTestimonialsSignature" runat="server"></strong>
                    </div>
                </div>
                <div id="latestBlogs" class="floatLeft">
                    <span class="sectionTitle capsTitle">LATEST BLOG POSTS</span>
                    <div class="imgLatestNewsSeperator">
                    </div>
                    <span class="blogPostText">
                        <asp:Label ID="lblBlogHeader" runat="server" Text="" class="lnkColor boldText">AP IMPACT: When your criminal past isn't yours</asp:Label>
                        <br />
                        <div id="divBlogContent" runat="server">
                            It was just over two years ago when my brother, after being unemployed for a year
                            and a half, found his new job. It was a long grueling process but he was relieved
                            to finally be employed again.</div>
                    </span>
                </div>
                <div class="clearBoth">
                </div>
                <div class="marginleft20">
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
        </div>
    </div>
</asp:Content>
