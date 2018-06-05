<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmPassword.aspx.cs"
    Inherits="eknowID.Pages.ConfirmPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="shortcut icon" href="../Images/favicon_icon.ico" />

    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.validate.min.js" type="text/javascript"></script>

    <%--<link rel="stylesheet" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/ui/1.9.2/jquery-ui.js" type="text/javascript"></script>    
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.9/jquery.validate.min.js"></script>    --%>
    
    <script src="../Scripts/jquery.watermark.js" type="text/javascript"></script>
    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        var interval;
        //To set water text 
        $(function () {
            $("#divPwdPolicies").css({"color":"red" });
            $('#txtEmail').watermark('Email Address');
            $("#txtNewPwd").keyup(function (e) {
                var tmpCount = 0;
                $("#lblErrorConfirmForgotPwd").html("");

                var strPassword = $("#txtNewPwd").val();
                var matchLowerCaseChar = /(?=.*[a-z])/;
                var matchUpperCaseChar = /(?=.*[A-Z])/;
                var matchNumber = /(?=.*[0-9])/;
                var matchSpecialChar = /(?=.*[!@#$%^&*])/;

                if (strPassword.match(matchLowerCaseChar)) {
                    $("#pwdLowerCaseChar").css({ "background-image": "url(../Images/green_tick.png)", "color": "green" });
                    tmpCount++;
                }
                else {
                    $("#pwdLowerCaseChar").css({ "background-image": "url(../Images/CorssSign.png)", "color":"red" });
                }
                if (strPassword.match(matchUpperCaseChar)) {
                    $("#pwdUpperCaseChar").css({ "background-image": "url(../Images/green_tick.png)", "color": "green" });
                    tmpCount++;
                }
                else {
                    $("#pwdUpperCaseChar").css({ "background-image": "url(../Images/CorssSign.png)", "color": "red" });                    
                }
                if (strPassword.match(matchNumber)) {
                    $("#pwdNumberChar").css({ "background-image": "url(../Images/green_tick.png)", "color": "green" });
                    tmpCount++;
                }
                else {
                    $("#pwdNumberChar").css({ "background-image": "url(../Images/CorssSign.png)", "color":"red" });
                }
                if (strPassword.match(matchSpecialChar)) {
                    $("#pwdSpecialChar").css({ "background-image": "url(../Images/green_tick.png)", "color": "green" });
                    tmpCount++;
                }
                else {
                    $("#pwdSpecialChar").css({ "background-image": "url(../Images/CorssSign.png)", "color":"red" });
                }
                if (strPassword.length >= 6) {
                    $("#pwdLength").css({ "background-image": "url(../Images/green_tick.png)", "color": "green" });
                    tmpCount++;
                }
                else {
                    $("#pwdLength").css({ "background-image": "url(../Images/CorssSign.png)", "color":"red" });
                }
                if(tmpCount >= 4)
                {
                    $("#pwdVerificationTitle").css({ "color": "green" });
                }
                else
                {
                    $("#pwdVerificationTitle").css({ "color": "red" });
                }               
            });
            $("#txtConfirmPassword").keyup(function (e) {
                $("#lblErrorConfirmForgotPwd").html("");
            });
        });

        function redirectToHome() {
            window.location = "index.aspx";
        }

        function showErrorMessage(errorMessage) {
            document.getElementById('lblErrorConfirmForgotPwd').innerHTML = errorMessage;
            document.getElementById('<%=lblErrorConfirmForgotPwd.ClientID %>').style.display = "inherit";
            document.getElementById('<%=lblSuccessMsg.ClientID %>').style.display = "none";
        }

        function handleConfirmPassword(code) {
            if (code == 13) {
                ConfirmPassword();
            }
        }

        function ConfirmPassword() {
            //if (!$("#form1").valid())
            // {
                //if (!$("#txtNewPwd").valid()) {
                    if ($("#txtNewPwd").val() == "") {
                                showErrorMessage('Please enter password.');
                                $("#txtNewPwd").focus();
                        return false;
                            }
                    else //if ($("#txtNewPwd").val().length < 6)
                            {
                        var count = 0;
                        if ($("#txtNewPwd").val().length >= 6) {
                            count++;
                        }

                        var strPassword = $("#txtNewPwd").val();
                        var matchExpressions = ['(?=.*[0-9])', '(?=.*[!@#$%^&*])', '(?=.*[A-Z])', '(?=.*[a-z])'];

                        for (var i = 0; i < matchExpressions.length; i++) {
                            if (strPassword.match(matchExpressions[i]))
                                count++;
                        }
                        if (count <= 3) {
                            showErrorMessage("Password does not meet the minimum standards.");
                                $("#txtNewPwd").focus();
                            return false;
                            }
                    }
                //}
                //else {

                    //if (!$("#txtConfirmPassword").valid()) {
                        if ($("#txtConfirmPassword").val() == "") {
                            showErrorMessage('Please enter confirm password.');
                            $("#txtConfirmPassword").focus();
                            return false;
                        }
                        else if ($("#txtNewPwd").val() != $("#txtConfirmPassword").val()) {
                            showErrorMessage("Your new password and confirm password does not match.");
                            $("#txtConfirmPassword").focus();
                            return false;
                        }
                    //}
                //}
            //}
            
//            var newPassword = $("#<%=txtNewPwd.ClientID%>").val();
//            var confirmPwd = $("#<%=txtConfirmPassword.ClientID%>").val();
//            var newPasswordValidate = $("#<%=txtNewPwd.ClientID %>").valid();
//            var confirmPwdValidate = $("#<%=txtConfirmPassword.ClientID %>").valid();

//            if (newPasswordValidate == 0 || confirmPwdValidate == 0) {
//                if (newPassword.length == 0 && confirmPwd.length == 0) {
//                    showErrorMessage('Please enter password and confirm password.');
//                }
//                else  if(newPassword.length < 6) {
//                    showErrorMessage('Please enter valid password(6-15 in character in length)');
//                }
//                else if (newPassword != confirmPwd) {
//                    showErrorMessage('Password that you entered in the ‘Confirm Password’ field does not match with the new password.');
//                }
////                else if (newPassword.length < 6 || confirmPwd.length < 6) {
////                    showErrorMessage('Password length should be 6 to 15 characters.');
////                }
////                else {

////                }
//            }
            //else {
                var forgotPwdID = $("#hdnForgotID").val();
                if (forgotPwdID == '') {
                    showErrorMessage('User verification URL send on your emailID.');
                    return false;
                }
//                if (newPassword != confirmPwd) {
//                    showErrorMessage('Password that you entered in the ‘Confirm Password’ field does not match with the new password.');
//                }
                else {

//                    if (($('#mstrPage').valid())) {
                        var controlData = "forgotID:'" + $("#hdnForgotID").val() + "'";
                        controlData = controlData + ",newPassword:'" + $("#<%=txtNewPwd.ClientID%>").val() + "'";
                        $("#overlay").show();
                        $.ajax({
                            type: "POST",
                            url: "loginajaxcalls.aspx/SetForgotPassword",
                            contentType: "application/json; charset=utf-8",
                            data: "{" + controlData + "}",
                            dataType: "json",
                            success: function (result) {
                                $("#overlay").hide();
                                if (result.d.Success == false) {
                                    showErrorMessage('This password reset link is already used/expired.');
                                }
                                else {
                                    document.getElementById('<%=lblSuccessMsg.ClientID %>').style.display = "inherit";
                                    document.getElementById('<%=lblSuccessMsg.ClientID %>').style.color = "green";
                                    document.getElementById('<%=lblErrorConfirmForgotPwd.ClientID %>').style.display = "none";
                                    $("#<%=txtNewPwd.ClientID%>").val('');
                                    $("#<%=txtNewPwd.ClientID%>").focus();
                                    $("#<%=txtConfirmPassword.ClientID%>").val('');
                                    $('*[generated=true]').remove();
                                    $("#overlay").show();
                                    $("#overlayMsg").val("Please wait, you will automatically get redirected to login page in 5 sec.")
                                    interval = window.setInterval(" redirectToHome();", 6000);
                                }
                            }
                        });
//                    }
                }
            //}
        }
        window.onload = function (e) {
            $("#<%=txtNewPwd.ClientID%>").focus();
        }

            jQuery.extend(jQuery.validator.messages, {
            required: "*",
            remote: "Please fix this field.",
            email: "*",
            url: "Please enter a valid URL.",
            date: "Please enter a valid date.",
            dateISO: "Please enter a valid date (ISO).",
            number: "*",
            digits: "Please enter only digits.",
            creditcard: "Please enter a valid credit card number.",
            equalTo: "*",
            accept: "Please enter a value with a valid extension.",
            maxlength: jQuery.validator.format("Please enter no more than {0} characters."),
            minlength: jQuery.validator.format("*"),
            rangelength: jQuery.validator.format("Please enter a value between {0} and {1} characters long."),
            range: jQuery.validator.format("Please enter a value between {0} and {1}."),
            max: jQuery.validator.format("Please enter a value less than or equal to {0}."),
            min: jQuery.validator.format("Please enter a value greater than or equal to {0}.")
        });

        function RedirectToHome() {
                $("#overlay").hide();
            window.location.href = "../Pages/index.aspx";
        }
    </script>
    <style type="text/css">
        #imgBtnLogin {
            cursor: pointer;
        }

        ul.list_PwdVerification {
            list-style: none;
            display: inline-block;
            margin-bottom: 10px;
            padding-left: 13px;
            margin-top: 0px;
        }

        ul.list_PwdVerification li {
            background: white url(../Images/CorssSign.png) no-repeat 10px center;
            margin-bottom: 10px;
            padding: 2px 5px 2px 40px;
            margin: 5px auto;
        }

        ul.list_PwdVerification li::before {
            content: '';
            position: relative;
            border: 1px solid #cddce9;
            margin-right: 10px;
        }

        #overlay {
            position: fixed;
            width: 100%;
            max-height: 100%;
            top: 0%;
            left: 0%;
            bottom: 0%;
            right: 0%;
            margin: auto;
            display: none;
            z-index: 9999;
            background: rgba(0,0,0,.70);
        }

        .loading {
            width: 50px;
            height: 57px;
            position: fixed;
            top: 50%;
            left: 50%;
            margin: -28px 0 0 -25px;
        }

    </style>
    <title>eknowID change password</title>
</head>
<body>
    <div id="overlay">
        <img alt="" src="../Images/loader.gif" class="loading" />
    </div>
    <form id="form1" runat="server">
        <div>

            <div class="stretchDiv" style="height: 455px; padding-top: 40px;">
                <div class="paddingLeft28">
                    <img class="cursorPointer" src="../Images/site_logo.png" alt="" onclick="RedirectToHome();" />
                </div>
                <br class="clearBoth" />
            <div style="float: left; width: 520px;">
                <div style="margin-left: 50px;">
                        <h1 style="color: #DD4B39;">Reset your password</h1>
                </div>
                <div class="divForgotPwdSubHeading" style="padding-left: 47px;">
                    <span class="ForgotPwdSubHeading">Enter a new password. We highly recommend you create
                        a </span>
                    <br />
                    <span class="ForgotPwdSubHeading">unique password.</span>
                    <br />
                    <br />
                    <span class="ForgotPwdSubHeading">Note: You can't reuse your old password once you change
                        it.</span>
                </div>
            </div>
            <div style="float: left; margin-left: 20px; width: 427px;">
                    <div class="floatLeft ForgotPwdBody" style="background-color: #F1F1F1; border-radius: 5px 5px 5px 5px; padding-left: 40px; width: 333px; height: 227px;">
                    <div>
                        <div class="paddingTop15 paddingLeft15" style="font-weight: bolder;">
                                New Password
                            </div>
                        <div class="padding15" style="padding-top: 7px !important;">
                            <asp:TextBox ID="txtNewPwd" Width="205px" runat="server" minlength="6" MaxLength="15"
                                CssClass="required" TextMode="Password" onkeydown="handleConfirmPassword(event.keyCode);"
                                    onkeypress="return (event.keyCode!=13);" ClientIDMode="Static"></asp:TextBox>
                            </div>
                    </div>
                    <div>
                        <div class="paddingTop15 paddingLeft15" style="font-weight: bolder;">
                                Confirm Password
                            </div>
                        <div class="padding15">
                            <asp:TextBox ID="txtConfirmPassword"   equalTo="#txtNewPwd" Width="205px" runat="server" TextMode="Password"
                                minlength="6" MaxLength="15" CssClass="required" onkeydown="handleConfirmPassword(event.keyCode);"
                                onkeypress="return (event.keyCode!=13);" ClientIDMode="Static"></asp:TextBox>
                        </div>
                            <div class="floatLeft clearBoth" style="margin-left: 18px; margin-top: -10px; height: 35px;">
                                <asp:Label ID="lblErrorConfirmForgotPwd" runat="server" ForeColor="Red" Font-Bold="true"
                                    Text="" Style="display: none" ClientIDMode="Static" />
                                <asp:Label ID="lblSuccessMsg" runat="server" ForeColor="Red" Font-Bold="true" Text="Password changed successfully! (Please wait, you will automatically get redirected to login page.)"
                                    Style="display: none;" />
                            </div>
                    </div>
                    <div class="padding15  floatRight clearBoth" style="padding: 0 11px 0 0;">
                        <input type="button" class="blackBtnMiddle whiteColor" value="Reset Password" onclick="ConfirmPassword();" />
                        <asp:HiddenField runat="server" ID="hdnForgotID" ClientIDMode="Static" />
                    </div>
                    </div><br /><br /><br />
                    <div id="divPwdPolicies" class="floatLeft clearBoth" style="margin-left: 10px; color:red;">
                         <strong id="pwdVerificationTitle">Password must meet the following minimum standards(any 4):</strong>
                        <ul class="list_PwdVerification">                           
                            <li class="PwdNonVerified" id="pwdLength">Be at least six characters in length</li>
                            <li class="PwdNonVerified" id="pwdLowerCaseChar">Contain at least one lowercase character</li>
                            <li class="PwdNonVerified" id="pwdNumberChar">Contain at least one number</li>
                            <li class="PwdNonVerified" id="pwdSpecialChar">Contain at least one special character</li>
                            <li class="PwdNonVerified" id="pwdUpperCaseChar">Contain at least one uppercase character</li>
                        </ul>                                                                 
                </div>
                </div>
        </div>
    </div>
    </form>
</body>
</html>
