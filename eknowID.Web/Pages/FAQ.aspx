<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="FAQ.aspx.cs" Inherits="eknowID.Pages.FAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .divFAQBg
        {
            background-color: #E7E7E7;
            height: auto !important;
            padding-bottom: 30px;
            padding-top: 30px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divFAQBg minWidth1000px">
        <div class="stretchDiv paddingBottom15 paddingLeft28 paddingTop10 divFAQInner boxShadowIE8">
            <h1>
                FAQs</h1>
            <b>Why should I check my background? I have no criminal record.</b>
            <p class="alignJustify width95per">
                Approximately 15 million people a year in the United States alone experience identity
                theft. The financial losses exceed $50 billion dollars annually. In other cases,
                individuals’ identities can be stolen to commit criminal acts and charges and/or
                convictions can and will be issued in that person’s name. Problems like these can
                be easily prevented by knowing what information is in your record. Knowledge is
                the best defense against identity theft, and eKnowID will provide you with this
                knowledge.</p>
            <br />
            <b>What is SSL? Does eKnowID have a SSL certificate?</b>
            <p class="alignJustify width95per">
                SSL is an acronym for “Secure Sockets Layer.” It is a security protocol developed
                for sending information over the Internet safely and securely. It makes your sensitive
                information unrecognizable to all servers except the one you are inputting your
                data into. Any website that asks sensitive information should be SSL secure, and
                eKnowID does have a SSL certificate.</p>
            <br />
            <b>Why do you need my Social Security Number?</b>
            <p class="alignJustify width95per">
                We will only ask for a social security number if you request a social security number
                verification or credit check.
            </p>
            <br />
            <b>How does the eKnowID money back guarantee work?</b>
            <p class="alignJustify width95per">
                We are so confident our records are the best that we are offering a money back guarantee.
                If criminal records should have been returned based on our Coverage, and they were
                not, you may receive a refund for your background check.
            </p>
            <p class="alignJustify width95per">
                You must agree to the coverage as listed in the terms and conditions, and in the
                event you challenge a complete report and can prove that a record exists in a jurisdiction
                included in the Coverage area, eKnowID will refund the purchase in full.</p>
            <p class="alignJustify width95per">
                The money back guarantee does not apply to the following:</p>
            <ul>
                <li>Records not located in the Coverage area.</li>
                <li>Records expunged by the courts.</li>
                <li>Juvenile records or arrest records that did not result in conviction</li>
            </ul>
            <br />
            <b>How long after I pay for my reports will I get it?</b>
            <p class="alignJustify width95per">
                Turnaround time depends on the type of check you request but generally isn’t more
                than a two days.
            </p>
            <br />
            <b>Where do you get all of the information?</b>
            <p class="alignJustify width95per">
                Our background check solution utilizes ethical and lawful information-gathering
                methods, using technological sources, open-sources, proprietary databases and information
                developed through human intelligence. Our case managers and licensed investigators
                work efficiently to give you the ability to perform instant searches.</p>
            <br />
            <b>I feel uncomfortable giving you all of the info you are asking for. Is it safe and
                secure?</b>
            <p class="alignJustify width95per">
                Rest assured your information is safe when working with eKnowID. We will never take
                your information and sell it to a third party. Our SSL certification ensures that
                all data passed between the web server and browsers remain both private, secure
                and unrecognizable to any other server except the one you are using.
            </p>
            <br />
            <b>What type of payment method(s) can I use to secure my eKnowID background investigation?</b>
            <p class="alignJustify width95per">
                You can pay with any accepted credit card.</p>
            <br />
        </div>
    </div>
</asp:Content>
