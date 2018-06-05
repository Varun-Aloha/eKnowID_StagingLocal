<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="Contactus.aspx.cs" Inherits="eknowID.Pages.Contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .viewMap {
            color: #4A80C0 !important;
            font-size: 14px;
            font-weight: bold;
            margin-top: 0;
            padding-top: 0;
            text-align: left;
            text-decoration: none;
        }

        .divContactUsMain {
            height: 400px !important;
            margin-top: 1px;
            color: #404040;
            font-family: helvetica;
            font-size: 13px;
        }

        .divContactInfo {
            font-size: 13px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="minWidth1000px grayBackground" style="height: 493px; padding-top: 30px; font-size: 13px;">
        <div class="stretchDiv paddingBottom15 paddingLeft28 paddingTop10 divWhyEknowMain boxShadowIE8 divContactUsMain">
            <h1>Contact Information</h1>
            <p class="alignJustify width95per" style="margin-left: 3px;">
                Customer service is available 24 hours a day, 7 days a week via email to meet your needs and address all emergencies.
            </p>
            <p class="alignJustify width95per" style="margin-left: 3px;">
                You may also contact our corporate office via phone, fax, email or postal mail at any time.
            </p>
            <div class="divContactInfo floatLeft">
                <div style="width: 55px;" class="floatLeft boldText">
                    Address:
                </div>
                <div style="width: 230px; height: 60px;" class="floatLeft marginLeft5">
                    520 W Erie Suite 340,<br />                    
                    Chicago, IL 60654
                </div>
                <br />
                <br />
                <div style="width: 55px;" class="floatLeft boldText">
                    Phone:
                </div>
                <div style="width: 230px; height: 44px;" class="floatLeft marginLeft5">
                    1-888-SIX CHEC (749-2432)
                    <br />
                    8-5pm CST
                </div>
                <br />
                <br />
                <div style="width: 55px;" class="floatLeft boldText">
                    Fax:
                </div>
                <div style="width: 230px; height: 27px;" class="floatLeft marginLeft5">
                    1-312-276-8989   
                </div>
                <br />
                <br />
                <div style="width: 55px;" class="floatLeft boldText">
                    Email:
                </div>
                <div style="width: 230px;" class="floatLeft marginLeft5">
                    support@eknowid.com 
                </div>
                <br />
                <br />
            </div>
            <div class="floatLeft" style="margin: 10px 0px 0px 58px;">
                <small>
                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2969.9422583890464!2d-87.64449198461344!3d41.89409887239187!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x880e2ccb6bb78499%3A0x7a19b01986f6d997!2s520+W+Erie+St+%23340%2C+Chicago%2C+IL+60654%2C+USA!5e0!3m2!1sen!2sin!4v1465368490339" width="425" height="260" frameborder="0" style="border: 0" allowfullscreen></iframe>
                </small>
            </div>
            <br />
            <br />
        </div>
    </div>
</asp:Content>
