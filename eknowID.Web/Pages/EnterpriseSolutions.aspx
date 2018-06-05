<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="EnterpriseSolutions.aspx.cs" Inherits="eKnowID.Pages.EnterpriseSolutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divFAQBg
        {
            background-color: #E7E7E7;
            height: auto !important;
            padding-bottom: 30px;
            padding-top: 30px;
            font-size: 13px;
            color: #404040;
        }
        .divFAQInner
        {
            background-color: white;
            height: auto !important;
            margin-top: 1px;
            width: 900px;
            padding: 30px 50px;
            border-color: #D7D7D7;
            border-radius: 2px 2px 2px 2px;
            box-shadow: 2px 2px 4px #8A8A8A;
            color: #404040;
            font-family: helvetica;
            font-size: 13px;
        }
        p
        {
            margin: 7px 0px;
        }    
        .divAboutUsBackground   
        {
              background-image: url(../images/enterprise_banner.png);
        }
    </style>
    <script language="javascript" type="text/javascript">
        $(function () {
            var screenwidth = $("#mstrPage").width();
           
            $("#divEnterPriseSolOuter").css('overflow', 'hidden');
            var sliderwidth = 1800 - screenwidth;
            if (sliderwidth >= 0) {
                var minusIndex = sliderwidth / 2 * -1;
                $("#divEnterPriseSolOuter").css('margin-left', minusIndex);
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margin_left_right_auto" id="divEnterPriseSolOuter">
        <div class="divAboutUsBackground margin_left_right_auto" id="divAboutUs">
        </div>
    </div>
    <div class="divFAQBg minWidth1000px">
        <div class="stretchDiv paddingBottom15 paddingLeft28 paddingTop10 divFAQInner boxShadowIE8">
            <h1>
                Enterprise Solutions</h1>
            <p class="alignJustify width95per">
                Looking for an online solution to run Employee/Tenant Checks?
            </p>
            <p class="alignJustify width95per">
                Kentech Consulting, the parent company of eKnowID, enables businesses with direct
                access to a myriad of up-to-the-minute data sources for making smart decisions and
                provides innovative and expert solutions for sectors like Housing, Employment, Education,
                Healthcare, Banking, etc. Verification of references, biometric fingerprint scanning,
                professional licenses, driving records, drug screening, credit history, civil history,
                criminal background checks FCRA compliant background screening, identity verification
                (SSA Direct), sex offender checks, nationwide crim-watch, people search, credit
                reports, OFAC are a part of the services offered.</p>
            <p class="alignJustify width95per">
                Kentech consulting’s Employment check enables clients to create secure work environments,
                improve corporate governance, satisfy compliance demands, manage intelligence assets,
                and gain the elusive competitive advantage derived from developing and maintaining
                superior human capital. Kentech’s Employment solutions include: <br />                
                 <ul>
                <li>National Criminal File</li>
                <li>International Criminal File</li>
                <li>County / Federal Criminal/Civil Records</li>
                 <li>Drug Testing</li>
                <li>Previous Employment Verification</li>
                <li>Professional License Verification</li>
                 <li>Biometric Fingerprint Scanning</li>
                <li>SSN Verification</li>
                <li>OFAC – US Patriot Act compliant</li>
                 <li>Education Verification</li>
                <li>Applicant Tracking & Recruiting Solutions</li>
            </ul>
                </p>
             <p class="alignJustify width95per">
             Tenant screening enables better housing and services to your tenants, ultimately fulfilling the vision of better communities. Tenant Solutions include:<br />                
                 <ul>
                <li>SSN Verification directly</li>
                <li>National Credit Report</li>
                <li>Crim-WatchTm</li>              
                <li>Court Eviction</li>
                <li>Housing Authority Integration Solutions</li>
                 <li>Rental History Verification</li>
                <li>Sex Offender Registry Search</li>
            </ul>
                </p>           
        </div>
    </div>
</asp:Content>
