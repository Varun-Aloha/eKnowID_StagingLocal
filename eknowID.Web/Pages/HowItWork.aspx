<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="HowItWork.aspx.cs" Inherits="eknowID.Pages.HowItWork" %>

<%@ Register Src="../Controls/ImageSlider.ascx" TagName="ImageSlider" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/qtip.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.qtip-1.0.0-rc3.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var screenwidth = $("#mstrPage").width();
            $("#divHowItWorkOuterOuter").css('width', screenwidth);
            $("#divHowItWorkOuterOuter").css('overflow', 'hidden');
            var sliderwidth = 1800 - screenwidth;
            if (sliderwidth >= 0) {
                var minusIndex = sliderwidth / 2 * -1;
                $("#divHowItWork").css('margin-left', minusIndex);
            }
        });
    </script>

    <style type="text/css">
        .video-container {
            width: 70%;
            margin: 0 auto;
            margin-top: 30px;
            padding: 10px;
        }

        .divVideoContainerMain {
            height: 405px;
            margin-left: auto;
            margin-right: auto;
            margin-top: 80px;
            width: 1000px;
        }

        iframe {
            display: block;
            width: 100%;
        }
        
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="minWidth1000px" style="height: auto !important; background-color: #E7E7E7; padding-bottom: 30px;">
        <div id="divHowItWorkOuterOuter" class="margin_left_right_auto">
            <div class="divHowItWorkBackground margin_left_right_auto" id="divHowItWork">
            </div>
        </div>

        <div class="divVideoContainerMain">
            <iframe height="350" allowfullscreen="allowfullscreen"
                src="https://www.youtube.com/embed/QOfPSyN0fj8?feature=player_detailpage&amp;wmode=transparent"></iframe>
        </div>

        <div class="divHowItWorkMain boxShadowIE8">
            <div style="margin-left:30px;">
                <h1>How It Works</h1>
            </div>

            <div class="margin-left-23px inline-block">
                <div class="how-work-box-width">
                    <div class="margin-top-40px">
                        <img src="../Images/Authenticate.png" alt="" />
                    </div>
                    <div class="margin-top-20px">
                        <h3>Authenticate</h3>
                    </div>
                    <div>
                        <p>
                            Confirm your Company Details
                            <br />
                            with valid Email.
                        </p>
                    </div>
                </div>
                <div style="width: 200px; float: left">
                    <div class="how-work-box-width">
                        <div class="margin-top-40px">
                            <img src="../Images/Choose.png" alt="" />
                        </div>
                        <div class="margin-top-20px">
                            <h3>Choose</h3>
                        </div>
                        <div>
                            <p>
                                Select your Background Check Package 
                                along with your Applicant’s email. 
                                We’ll contact them directly to 
                                authorize consent and complete 
                                the background check.
                            </p>
                        </div>
                    </div>
                </div>
                <div style="width: 200px; float: left" class="margin-left-20px">
                    <div class="how-work-box-width">
                        <div class="margin-top-40px">
                            <img src="../Images/Review.png" alt="" />
                        </div>
                        <div class="margin-top-20px">
                            <h3>Review</h3>
                        </div>
                        <div>
                            <p>
                                You’ll receive notification once 
                                check is complete to login to review.
                            </p>
                        </div>
                    </div>
                </div>
                <div style="width: 200px; float: left" class="margin-left-20px">
                    <div class="how-work-box-width">
                        <div class="margin-top-40px">
                            <img src="../Images/Hire.png" alt="" />
                        </div>
                        <div class="margin-top-20px">
                            <h3>Hire</h3>
                        </div>
                        <div>
                            <p>
                                Now that you’ve done your check continue 
                            on building out a great stellar team.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
