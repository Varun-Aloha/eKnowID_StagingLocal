<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="eknowID.Pages.SingUpTemp" %>

<%@ Register Src="~/Controls/DrugsVerficationDetails.ascx" TagName="DrugVerificationDetails"
    TagPrefix="uc5" %>
<%@ Register Src="../Controls/EducationalDetails.ascx" TagName="EducationalDetails"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/EmploymentDetails.ascx" TagName="EmploymentDetails"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/LicenseInformation.ascx" TagName="LicenseInformation"
    TagPrefix="uc3" %>


<%@ Register Src="../Controls/ReferenceDetails.ascx" TagName="ReferenceDetails" TagPrefix="uc4" %>
<%@ Register Src="../Controls/JoinNow.ascx" TagName="JoinNow" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/signUp.ascx" TagName="sin" TagPrefix="uc1" %>
<%@ Register src="../Controls/dob.ascx" tagname="dob" tagprefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.8.3.js" type="text/javascript"></script>
<%--    <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/ui/1.9.2/jquery-ui.js" type="text/javascript"></script>--%>
    <script src="../Scripts/bpopUp.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/Common.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/openPopUp.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/AddRemoveEmploymentInfo.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/AddRemoveReferenceInfo.js" type="text/javascript"></script>
    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/UserScripts/OrderDetailsTab.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/LinkedInData.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.alerts.js" type="text/javascript"></script>
    <link href="../Styles/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/UserScripts/SaveOrderDetails.js" type="text/javascript"></script>
    <link href="../Styles/jquery.bt.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /*
        
        .ui-tabs .ui-tabs-nav li, ul li a
        {
            border-radius: 8px;
        }*/
        .ui-tabs .ui-tabs-nav li.ui-tabs-active
        {
            background-color: #8C8C8C;
        }
        
        ul li a:hover
        {
            background-color: #8C8C8C !important;
            color: White !important;
        }
        ul li
        {
            background: none;
        }
        
        ul li a
        {
            font-size: 11px;
            font-weight: bold;
        }
        .ui-widget
        {
            font-family: Arial,Helvetica,sans-serif;
            font-size: 12px;
        }
        .ui-state-active a, .ui-state-active a:link, .ui-state-active a:visited
        {
            color: White;
        }
        #loading
        {
            display: none;
        }
        .filename
        {
            visibility: hidden;
            height: 0;
            width: 0;
            display: block;
        }
        #loading
        {
            display: none;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function Test() {
            $('#loading').bPopup({
                modalClose: false,
                opacity: 0.6,
                positionStyle: 'absolute'
            });

            //$("#tabs").tabs("select", "Education Details");
            //$('#menu').tabs('select', "Education Details");
        }
        $(function () {
            $('#example7').bt({
                trigger: ['focus', 'blur'],
                positions: ['right'],
                fill: 'Gray'
            });
        });
        function NoneCheck() {
            alert('Hi');
            var a = $('.displayNone').css('display');

            alert(a);
        }

        function Alert() {
            //            var errorMessage = "Please check the following things :<br/><br/>";
            //            errorMessage = errorMessage + "- Please enter first name.<br/>";
            //            errorMessage = errorMessage + "- Please enter first name.<br/>";
            //            OpenDialog(errorMessage);
            //
            var ccc = 1;
            var cc = "how do i retrieve a textboxs title and name using jquery" + ccc;
            $("#example7").removeAttr("title");
            $("#example7").attr("title", cc);
            $('#example7').bt({
                trigger: ['focus', 'blur'],
                positions: ['right'],
                fill: 'Gray'
            });
            ccc++;
        }
        function IsValidLicenseNumber() {
            var regEx = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{+}\b$/i;
            var regExq = /^([\w-\.]+@([\w-]+\.)+[\w-]{1,})?$/;
            var email = $('#TextBox1').val();
            if (regExq.test(email)) {
                alert("ok");
            } else {
                alert('not ok');
            }

            //            var reg = /^(\d{7})$/;
            //            var licenseNumber = "1231323";
            //            if (reg.test(licenseNumber)) {
            //                alert("Ok");
            //            } else {
            //                alert("Not OK");
            //            }
        }
        function tea_break(msec) {
            var date = new Date();
            var curDate = null;
            do {
                curDate = new Date();

            }
            while (curDate - date < msec);
        }

        $(function () {
            $(".validateSingUp").keydown(function (e) {
                if (e.which == 13) {
                    var errorMessage = "Please check the following things :<br><br>";
                    errorMessage = errorMessage + "- Please enter first name.<br/>";
                    errorMessage = errorMessage + "- Please enter first name.<br/>";
                    jAlert(errorMessage, "Alert")
                    //OpenDialog(errorMessage);
                    e.preventDefault();
                    return false;
                }
            });
        });
        function OpenDialog(ErrorMessage) {
            $("#dialog").text("");
            $("#dialog").append(ErrorMessage)
            $("#dialog").dialog({
                resizable: false,
                height: 'auto',
                width: 'auto',
                stack: true,
                buttons: {
                    "OK": function () {
                        $(this).dialog("close");
                    }
                }
            });
        }
        function paste123() {
            var totalCharacterCount = $("#TextBox2").val();
            var regExp = /^[a-zA-Z ]*$/;
            if (isNaN(totalCharacterCount)) {
                $("#TextBox2").val('');
            }
        }

        $(function () {
            $('.digitsOnly').bind('input', function () {
                var totalCharacterCount = $(this).val();
                var regExp = /^[a-zA-Z ]*$/;
                if (isNaN(totalCharacterCount)) {
                    $(this).val('');
                }
            });

            $(".digitsOnly").keypress(function (e) {

                //Allow user to press crtl+v
                if (e.ctrlKey && (e.which == 86 || e.which == 118)) {
                    return true;
                }
                else {

                    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                        return false;
                    }
                }
            });
        });
        function OpenResumeParser() {
            $("#divResumeParser").bPopup({
                appendTo: 'form',
                modalClose: false,
                opacity: 0.6,
                positionStyle: 'fixed' //'fixed' or 'absolute'
            });
        }

        function openjoin() {
            $("#divUploadResume").bPopup({
                appendTo: 'form',
                modalClose: false,
                opacity: 0.6,
                positionStyle: 'fixed'
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button ID="btnmail" runat="server" Text="Send Mail" OnClick="btnmail_Click" />
    <div style="width: 600px; display: none; background-color: White;" id="requiredDetails"
        class="borderRadius6">
        <div class="topHeaderDiv">
            <asp:Label ID="lblPopUpHeader" runat="server" Text="Employment Details" ClientIDMode="Static"></asp:Label>
            <div class="popUpCloseButton">
                <img src="../Images/close_icon_popup.png" alt="" onclick="CloseTab();" style="cursor: pointer;" /></div>
        </div>
        <br />
        <br />

        
        <div id="tabs" style="border: none !important;">
            <ul class="floatLeft" id="Container">
                <% if (isEmploymentDetails)
                   { %>
                <li id="emp"><a href="#emp-1">Employment </a></li>
                <%} %>
                <% if (isEducationDetails)
                   { %>
                <li id="edu"><a href="#edu-3">Education</a></li>
                <%} %>
                <% if (isLicenseDetails)
                   { %>
                <li id="lic"><a href="#lic-3">License</a></li>
                <%} %>
                <% if (isReferenceInfo)
                   { %>
                <li id="ref"><a href="#ref-2">Reference</a></li>
                <%} %>
            </ul>
            <hr class="line" />
            <div id="Contenttext" runat="server" class="paddingLeft10">
                The selected package requires additional information. Please complete the required
                information below in order to continue</div>
            <% if (isEmploymentDetails)
               { %>
            <div id="emp-1">
                <uc2:EmploymentDetails ID="EmploymentDetails1" runat="server" />
            </div>
            <%} %>
            <% if (isEducationDetails)
               { %>
            <div id="edu-3">
                <uc1:EducationalDetails ID="EducationalDetails1" runat="server" />
            </div>
            <%} %>
            <% if (isLicenseDetails)
               { %>
            <div id="lic-3">
                <uc3:LicenseInformation ID="LicenseInformation1" runat="server" />
            </div>
            <%} %>
            <% if (isReferenceInfo)
               { %>
            <div id="ref-2">
                <uc4:ReferenceDetails ID="ReferenceDetails1" runat="server" />
            </div>
            <%} %>
            <input type="button" value="Test" onclick="Test();" />
        </div>
        <% if (isUserloggedIIn)
           { %>
        <div class="floatRight" style="padding-right: 30px;">
            <asp:CheckBox ID="chkupdateUserDetails" runat="server" Text="Update Details" /></div>
        <%} %>
        <div class="clearBoth floatRight" style="margin-right: 10px">
            <input type="button" class="blackBtnMiddle whiteColor" value="Save" />
            <input type="button" class="blackBtnMiddle whiteColor" value="Save & Continue" onclick="ChangeTab();" />
            <input type="button" class="blackBtnMiddle whiteColor" value="Cancel" onclick="CloseTab();" />
        </div>
    </div>
    <div id="DrugsVerficationDiv" class="borderRadius6" style="background-color: White;
        display: none; width: 700px">
        <div class="topHeaderDiv">
            <asp:Label ID="Label1" runat="server" Text="Drugs Verification Details" ClientIDMode="Static"></asp:Label>
            <div class="popUpCloseButton">
                <img src="../Images/close_icon_popup.png" alt="" onclick="CloseDrugsDiv();" style="cursor: pointer;" /></div>
        </div>
        <uc5:DrugVerificationDetails ID="DrugVerificationDetails" runat="server" />
        <div class="floatRight" style="margin-right: 10px">
            <input type="button" class="blackBtnMiddle whiteColor ma" value="OK" /></div>
    </div>
    <input type="button" value="Open" id="openB" onclick="OpenDetailsPopup();" />
    <asp:Button ID="Td" Text="Test123" runat="server" OnClick="Td_Click" />
    <input type="button" value="call" onclick="Test();" />
    <div class="displayNone" style="display: none;">
        djgajdghfjhagsdf</div>
    <div class="displayNone" style="display: none;">
        djgajdghfjhagsdf</div>
    <div class="displayNone" style="display: none;">
        djgajdghfjhagsdf</div>
    <input type="button" value="None Check" onclick="NoneCheck();" />
    <input type="button" value="Alert" onclick="Alert();" />
    <asp:TextBox ID="txtpwd" runat="server" /><asp:Button ID="btnEncr" runat="server"
        Text="Encrypt" OnClick="btnEncr_Click" />
    
    <asp:TextBox ID="sd" runat="server" class="validateSingUp" />
    <asp:TextBox ID="TextBox1" runat="server" ClientIDMode="Static" />
    <asp:TextBox ID="TextBox2" runat="server" class="digitsOnly" />
    <div id="dialog" title="Alert">
        <uc6:dob ID="dob1" runat="server" />
    </div>
    <input type="button" onclick="openjoin();" value="JoinNow" />
    <input id="example7" title="" value="focus" class="alt-target" type="text" />
    <input type="button" id="btnParser" value="Resume Parser" onclick="OpenResumeParser();" />
    <div id="divResumeParser" style="background-color: White; width: 300px; height: 150px;
        display: none;">
        <%--<input type="file" name="filediag" />--%>
        <asp:FileUpload ID="fileuploadResumeParser" runat="server" />
        <asp:Button ID="btnTe" runat="server" Text="Parser" OnClick="btnTe_Click" />
    </div>
    <input type="file" id="file" />
    <input type="submit" runat="server" id="btnSubmmiiii" value="btnSubmmiiii" />
    <div id="divUploadResume" class="borderRadiusTopCorners6 displayNone width500" style="background-color: White;
        height: 260px;">
        <%--                        <div class="floatRight">
            <a class="dialogClose" onclick="CloseResumeDialog();"></a>
        </div>
                <iframe src="RC_ProcessResume.aspx" style="border: 0px; height: 100%; width: 100%;">
                </iframe>  --%>
        <uc1:sin ID="signUp" runat="server" />
        <%--<uc1:JoinNow ID="signUp" runat="server" />--%>
    </div>
    <div id="loading">

        <img src="../Images/wait_animation.gif" alt="" /></div>

        <input type ="button"  value ="Testerhsfd" onclick="OpenProcessingImage();"/>
    </form>
</body>
</html>
