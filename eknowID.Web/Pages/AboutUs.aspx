<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="eKnowID.Pages.AboutUs" %>

<%@ Register Src="../Controls/ImageSlider.ascx" TagName="ImageSlider" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body
        {
            font-size: 12px !important;
            font-family: Sans-Serif !important;
        }
        .headingColor
        {
            color: #980000;
        }
        .width94per
        {
            width: 94%;
        }
        .width425
        {
            width: 462px;
        }
        div.divAboutUsBg p
        {
            margin: 7px 0px;
        }
        ul
        {
            margin-top: 0px;
        }
        .divBBB
        {
            clear: both;
            height: 92px;
            padding-top: 0;
            width: 432px;
            padding-left: 100px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        $(function () {
            var screenwidth = $("#mstrPage").width();
            $("#divAboutUsOuter").css('width', screenwidth);
            $("#divAboutUsOuter").css('overflow', 'hidden');
            var sliderwidth = 1800 - screenwidth;
            if (sliderwidth >= 0) {
                var minusIndex = sliderwidth / 2 * -1;
                $("#divAboutUs").css('margin-left', minusIndex);
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margin_left_right_auto" id="divAboutUsOuter">
        <div class="divAboutUsBackground margin_left_right_auto" id="divAboutUs">
        </div>
    </div>
    <div class="divAboutUsBg minWidth1000px" style="height: 1051px;">
        <div class="stretchDiv paddingBottom15 paddingLeft28 paddingTop10 divAboutUsInner boxShadowIE8"
            style="height: 990px;">
            <h1 class="width150">
                About Us</h1>
            <div style="width: 562px;" class="floatLeft">
                <p class="alignJustify width95per">
                    <font class="eKnowIDRed">eKnowID</font> was created because we understand personal
                    information is constantly evolving, and people are seeking more control over their
                    personal information. We believe there is an increasing need to take background
                    checking technologies from the corporate and governmental spheres and make them
                    accessible for private use.</p>
                <p class="alignJustify width95per">
                    <font class="eKnowIDRed">eKnowID</font>’s online suite of background checking
                    tools, powered by the latest technology offered to banking, employers, housing authorities,
                    non-profits, job seekers, students and school faculty, is now available to individuals
                    looking to take control of their own personal information.We value accuracy, as
                    well as your time and urgency: all U.S. background checks are completed within 72
                    hours and international checks are completed in 2 weeks.
                </p>
                <div class="clearBoth divAboutUsSubHeading" style="height: 272px;">
                    <div class="divAboutUsSubHeadingImg" style="background-image: url(../images/innovation_img.png);">
                    </div>
                    <div class="divAboutUsSubHeadingDesc width425 marginTop8">
                        <div class="eKnowIDRed aboutUsSubHeadingFont">
                            Innovative Technology</div>
                        <p class="alignJustify width94per">
                            The creators of <font class="eKnowIDRed">eKnowID</font> have a history in developing innovative and user-friendly
                            background investigation products. For example:</p>
                        <p class="alignJustify width94per">
                            <ul style="padding-left: 15px">
                                <li><b>Arrestfree.com</b></li></ul>
                        </p>
                        <ul>
                            <li>Enables you to pull your criminal background information</li>
                        </ul>
                        <p class="alignJustify width94per">
                            <ul style="padding-left: 15px">
                                <li><b>Collegescreen.com</b></li></ul>
                        </p>
                        <ul>
                            <li>Provides students and colleges with background screening packages</li>
                        </ul>
                        <p class="alignJustify width94per">
                            <ul style="padding-left: 15px">
                                <li><b>C.L.E.A.R. (Criminal Link Exchange And Reporting)</b></li></ul>
                        </p>
                        <ul>
                            <li>The first identity theft detection system of its kind.</li>
                        </ul>
                        <p class="alignJustify width94per">
                            <b>We hold provisional patents on our technology services.</b>
                        </p>
                    </div>
                </div>
                <div class="clearBoth divAboutUsSubHeading" style="height: 137px; margin-top: 0px;">
                    <div class="divAboutUsSubHeadingImg" style="background-image: url(../images/complian_img.png);">
                    </div>
                    <div class="divAboutUsSubHeadingDesc width425 marginTop8">
                        <div class="eKnowIDRed aboutUsSubHeadingFont">
                            Compliant Focused</div>
                        <p class="alignJustify width94per">
                            Unlike our competitors, we are committed to providing the most up-to-date technologies,
                            and our private investigators help you uncover the most comprehensive data available
                            about your background. We hold active membership with a number professional associations
                            and organizations, including National Association of Professional Background Screeners
                            (NAPBS) and Better Business Bureau (BBB).</p>
                    </div>
                </div>
                <div class="clearBoth divAboutUsSubHeading" style="height: 252px; margin-top: 0px;">
                    <div class="divAboutUsSubHeadingImg" style="background-image: url(../images/money_img.png);">
                    </div>
                    <div class="divAboutUsSubHeadingDesc width425 marginTop8" style="height: 255px;">
                        <div class="eKnowIDRed aboutUsSubHeadingFont">
                            Our Money Back Guarantee
                        </div>
                        <p class="alignJustify width94per">
                            We are so confident our records are the best that we are offering a money back guarantee.
                            If criminal records should have been returned based on our Coverage, and they were
                            not, you may receive a refund for your background check.
                        </p>
                        <p class="alignJustify width94per">
                            You must agree to the Coverage as listed in the Terms and Conditions, and in the
                            event you challenge a complete report and can prove that a record exists in a jurisdiction
                            included in the Coverage area, <font class="eKnowIDRed">eKnowID</font> will refund the purchase in full.</p>
                        <p class="alignJustify width94per">
                            The money back guarantee does not apply to the following:</p>
                        <ul>
                            <li>Records not located in the Coverage area.</li>
                            <li>Records expunged by the courts.</li>
                            <li>Juvenile records or arrest records that did not result in conviction</li>
                        </ul>
                    </div>
                </div>
                <div class="divBBB">
                    <div class="floatLeft">
                        <a target="_blank" id="bbblink" class="sehzbus" href="https://www.bbb.org/chicago/business-reviews/screening-background-and-employment/kentech-consulting-in-chicago-il-88032082#bbblogo"
                            title="KENTECH Consulting, Inc., Screening - Background & Employment, Chicago, IL"
                            style="display: block; position: relative; overflow: hidden; width: 100px; height: 38px;
                            margin: 0px; padding: 0px;">
                            <img style="padding: 0px; border: none;" id="bbblinkimg" src="https://seal-chicago.bbb.org/logo/sehzbus/kentech-consulting-88032082.png"
                                width="200" height="38" alt="KENTECH Consulting, Inc., Screening - Background & Employment, Chicago, IL" /></a><script
                                    type="text/javascript">                                                                                                                                                   var bbbprotocol = (("https:" == document.location.protocol) ? "https://" : "http://"); document.write(unescape("%3Cscript src='" + bbbprotocol + 'seal-chicago.bbb.org' + unescape('%2Flogo%2Fkentech-consulting-88032082.js') + "' type='text/javascript'%3E%3C/script%3E"));</script>
                    </div>
                    <div class="floatLeft marginleft15">
                        <!-- webbot  bot="HTMLMarkup" startspan -->
                        <!-- GeoTrust QuickSSL [tm] Smart  Icon tag. Do not edit. -->
                        <script language="javascript" type="text/javascript" src="//smarticon.geotrust.com/si.js"></script>
                        <!-- end  GeoTrust Smart Icon tag -->
                        <!-- webbot  bot="HTMLMarkup" endspan -->
                    </div>
                </div>               
            </div>
            <div class="floatRight divAboutUsRightPnl">
                <div>
                </div>
                <div class="clearBoth" style="margin-top: 0; padding-top: 1px;">
                    <h3 class="SearchByRefUC_heading" style="margin-top: 27px;">
                        Blog Updates</h3>
                    <div class="floatLeft">
                        <img src="../Images/blog_img.png" alt="" />
                    </div>
                    <div class="floatLeft alignJustify width135 padding10" style="padding-top: 0px;">
                        <span class="eKnowIDRed boldText">AP IMPACT: When your criminal past isn't yours</span><br />
                        It was just over two years ago when my brother, after being unemployed ...
                    </div>
                    <div class="floatRight paddingBottom20">
                        <a href="http://eknowid.wordpress.com/" target="_blank" class="SearchByRefUC_heading"
                            style="text-decoration: none; font-weight: bold;">Read More</a>
                    </div>
                </div>
                <br />
                <div>
                </div>
                <div class="clearBoth" style="border-top: 1px solid #D8D8D8; height: 250px; padding-top: 1px;">
                    <h3 class="SearchByRefUC_heading" style="margin-top: 25px;">
                        The Facts</h3>
                    <div class="floatLeft alignJustify">
                        <div>
                            <div class="floatLeft" style="height: 16px; padding-top: 4px;">
                                <img src="../Images/arrow_img.png" alt="" /></div>
                            <div class="floatLeft" style="width: 267px; margin-left: 5px;">
                                <span>Identity theft affects about 8-12 million people every year. (Mitch Lipka, Reuters)</span></div>
                        </div>
                        <div class="marginTop5">
                            <div class="floatLeft" style="height: 16px; padding-top: 4px;">
                                <img src="../Images/arrow_img.png" alt="" /></div>
                            <div class="floatLeft" style="width: 267px; margin-left: 5px;">
                                <span>College-aged students are at high risk for identity theft (The United States Department
                                    of Education) </span>
                            </div>
                        </div>
                        <div class="marginTop5">
                            <div class="floatLeft" style="height: 16px; padding-top: 4px;">
                                <img src="../Images/arrow_img.png" alt="" /></div>
                            <div class="floatLeft" style="width: 267px; margin-left: 5px;">
                                <span>In the first four months of fiscal 2013, the IRS opened 542 investigations of
                                    possible cases of tax-related identity theft, as compared to 898 for all of fiscal
                                    year 2013 and 276 in fiscal year 2011. (Linda Stern, Reuters)</span></div>
                        </div>                      
                    </div>
                </div>
            </div>
            <div class="clearBoth">
            </div>           
        </div>
    </div>
</asp:Content>
