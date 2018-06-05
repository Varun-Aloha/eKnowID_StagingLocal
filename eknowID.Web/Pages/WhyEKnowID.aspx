<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="WhyEKnowID.aspx.cs" Inherits="eknowID.Pages.WhyEKnowID" %>

<%@ Register Src="../Controls/ImageSlider.ascx" TagName="ImageSlider" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <script language="javascript" type="text/javascript">
        $(function () {
            var screenwidth = $("#mstrPage").width();
            $("#divWhyEKnowIDOuter").css('width', screenwidth);
            $("#divWhyEKnowIDOuter").css('overflow', 'hidden');
            var sliderwidth = 1800 - screenwidth;
            if (sliderwidth >= 0) {
                var minusIndex = sliderwidth / 2 * -1;
                $("#divWhyEKnowID").css('margin-left', minusIndex);
            }

        });
    </script>
    <style type="text/css">
    div.divWhyEknowBackground p
    {
        margin-top:7px;
    }
    
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="margin_left_right_auto" id="divWhyEKnowIDOuter">
        <div class="divWhyEKnowIDBackground margin_left_right_auto" id="divWhyEKnowID">
        </div>
    </div>
    <div class="divWhyEknowBackground margin_left_right_auto minWidth1000px">
        <div class="divWhyEknowMain boxShadowIE8">
            <h1 style="width: 171px;">
                Why eKnowID
            </h1>
            <div class="floatLeft divWhyEknowInner">
                <div class="clearBoth floatLeft alignJustify paddingBottom15" style="width: 95%">
                    <p>
                        In this modern age a person’s digital profile is readily used to determine eligibility
                        for employment, education and housing. The same tools these companies and organizations
                        use to uncover this sensitive information can be valuable to an individual seeking
                        the same personal information. <font class="eKnowIDRed">eKnowID</font> gives consumers the opportunity to “know
                        what they know.”</p>
                    <ul style="padding-left: 13px !important;">
                        <li>Know what your potential employer knows before applying for the job of your dreams.</li>
                        <li>Know what a potential landlord knows before applying for an apartment or a mortgage
                            on perfect home for your family.</li>
                        <li>Know that your identity is safe before you apply for credit cards or auto loans.</li>
                    </ul>
                    <p>
                        Simply put, knowing what public records exist in your name can make life easier
                        and safer.</p>
                    <p>
                        <font class="eKnowIDRed">eKnowID</font> will ensure:</p>
                </div>
                <div class="featureMainDiv_WhyEKnowID padding10">
                    <div class="imgDiv_WhyEKnowID paddingRight15" style="background-image: url(../images/icon_search.png);">
                    </div>
                    <div>
                        <b class="fontsize15 eKnowIDRed">Searches are Done Right</b>
                        <p>
                            We will provide you with information you are looking for, and we assure peace of
                            mind. We guarantee accurate and precise information.</p>
                    </div>
                </div>
                <div class="featureMainDiv_WhyEKnowID padding10 clearBoth">
                    <div class="imgDiv_WhyEKnowID paddingRight15" style="background-image: url(../images/icon_quality.png);">
                    </div>
                    <div>
                        <b class="fontsize15 eKnowIDRed">Clear and Concise Reports of High Quality</b>
                        <p>
                            Our cutting-edge investigative techniques yield thorough and understandable reports.
                            We offer customized packages designed to fit each customer’s particular need. The
                            completed reports are comprehensive and easy to read.</p>
                    </div>
                </div>
                <div class="featureMainDiv_WhyEKnowID padding10">
                    <div class="imgDiv_WhyEKnowID paddingRight15" style="background-image: url(../images/icon_privacy.png);">
                    </div>
                    <div>
                        <b class="fontsize15 eKnowIDRed">Respect for Person and Privacy</b>
                        <p>
                            We value property. We will not sell, rent, share or assign personal information.</p>
                    </div>
                </div>
                <div class="featureMainDiv_WhyEKnowID padding10">
                    <div class="imgDiv_WhyEKnowID paddingRight15" style="background-image: url(../images/icon_affordable.png);">
                    </div>
                    <div>
                        <b class="fontsize15 eKnowIDRed">Affordability</b>
                        <p>
                            We believe in the importance of personal background checks. We suggest packages
                            to fit your needs, but if you want to check other information or create your own
                            package, no problem. We provide a la carte options for you to customize your check.</p>
                    </div>
                </div>
            </div>
            
        </div>
    </div>
</asp:Content>
