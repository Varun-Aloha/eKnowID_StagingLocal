<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="GetStarted_SecureJob.aspx.cs" Inherits="eknowID.Pages.GetStarted_SecureJob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .SecureJobBanner
        {
            background-image: url(../images/secure_job_brand_new.png);
            width: 1800px;
            height: 240px;
        }
        .divSecJob
        {
            background-color: #E7E7E7;
            height: 500px;
            padding-top: 30px;
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
    <div class="heightauto divSecJob minWidth1000px" style="height: 526px;">
        <div class="stretchDiv paddingLeft28 paddingTop10 divAboutUsInner" style="height: 435px!important;">
            <div class="width100per">
                <div class="floatLeft alignJustify" style="width: 50%; line-height: 1.5">
                    <h1 class="SearchByRefUC_heading">
                        Secure a Job
                    </h1>
                    In today’s competitive job market, more companies are using background checks to
                    make informed decisions on who to hire. While your resume may be strong, errors
                    and discrepancies found can jeopardize your career. Take control of your accomplishments
                    and credentials you’ve worked hard to earn. <font class="headingColor">eKnowID</font>
                    enables job seekers to easily establish and verify their reputation in conjunction
                    with their potential employer. Employers know how to check your identity, now it's
                    time you know your ID.
                    <br />
                    <br />
                    <a href="../Pages/SearchByProf_SelectProf.aspx" title="GET STARTED NOW"
                        class="floatRight">
                        <img src="../images/red_get_started_btn.png"></img>
                    </a>
                </div>
                <div class="floatLeft paddingLeft25" style="width: 47%; line-height: 1.5">
                    <img src="../Images/vertical_line1.png" class="floatLeft paddingRight20" style="height: 430px;" />
                    <h1 class="SearchByRefUC_heading">
                        Who Should Order This?
                    </h1>
                    <div class="width100per">
                        <div style="height: 150px;" class="width100per padding10">
                            <div class="floatLeft" style="width: 33%;">
                                <img src="../Images/Job_Seekers.png" alt="" />
                            </div>
                            <div class="alignJustify floatLeft marginTop26 marginleft15" style="width: 60%;">
                                <b class="faintblack fontsize16">Job seekers</b>
                                <br />
                                <p class="pText">
                                    Are you sure your resume matches your background check? People often lose job opportunities
                                    due to inaccuracies found in their background check, inaccuracies they may not even
                                    be aware of.
                                </p>
                            </div>
                        </div>
                        <div>
                            <img src="../Images/line_sign_up.png" alt="" width="350px;" class="marginleft25" />
                        </div>
                    </div>
                    <div class="width100per">
                        <div style="height: 150px" class="width100per padding10">
                            <div class="floatLeft" style="width: 33%;">
                                <img src="../Images/Recent_Graduates.png" alt="" />
                            </div>
                            <div class="alignJustify floatLeft marginTop26 marginleft15" style="width: 60%;">
                                <b class="faintblack fontsize16">Recent graduates</b>
                                <br />
                                <p class="pText">
                                    If you recently finished college, chances are you are in the midst of applying for
                                    your first full-time job in your desired field. eKnowID provides you with unique
                                    self-check background packages catered to your job field and shows the typical background
                                    checks run for applicants applying in your field.
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
