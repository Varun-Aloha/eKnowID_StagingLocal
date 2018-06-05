<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.ascx.cs"
    Inherits="eknowID.Controls.ForgotPassword" %>
<script type="text/javascript" language="javascript">
    window.onload = function (e) {
        $('#txtEmailID').focus();
    }
    //To set water text 
    $(function () {
        $('#txtEmailID').watermark('Email Address');
    });

    function emailValidation() {
        var email = $("#<%=txtEmailID.ClientID%>").val();
        var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
        return pattern.test(email);
    }

    function handle(code) {

        if (code == 13) {
            AuthenticateEmailID();
            //  return false;
        }
    }

    function showErrorMessage(errorMessage) {
        document.getElementById('lblErrorForgotPwd').innerHTML = errorMessage;
        document.getElementById('<%=lblErrorForgotPwd.ClientID %>').style.display = "inherit";
        document.getElementById('<%=lblSuccessMsg.ClientID %>').style.display = "none";
        document.getElementById('<%=lblWaitMessage.ClientID %>').style.display = "none";
    }
    function AuthenticateEmailID() {

        var flag = emailValidation();

        if (flag == false) {
            showErrorMessage('Please enter valid email address.');
            $('#txtEmailID').focus();
        }
        else {
            document.getElementById('<%=lblErrorForgotPwd.ClientID %>').style.display = "none";
            document.getElementById('<%=lblSuccessMsg.ClientID %>').style.display = "none";
            document.getElementById('<%=lblWaitMessage.ClientID %>').style.display = "inherit";
            if (($('#txtEmailID').valid())) {
                var controlData = "email:'" + $("#<%=txtEmailID.ClientID%>").val() + "'";
                $.ajax({
                    type: "POST",
                    url: "loginajaxcalls.aspx/ForgotPassword",
                    contentType: "application/json; charset=utf-8",
                    data: "{" + controlData + "}",
                    dataType: "json",
                    success: function (result) {
                        if (result.d.Success == false) {
                            showErrorMessage(result.d.ErrorMsg);
                        }
                        else {
                            document.getElementById('<%=lblSuccessMsg.ClientID %>').style.display = "inherit";
                            document.getElementById('<%=lblErrorForgotPwd.ClientID %>').style.display = "none";
                            document.getElementById('<%=lblWaitMessage.ClientID %>').style.display = "none";
                            $('#txtEmailID').val('');
                            $('#btnSubmit').attr("disabled", true);
                            $('#btnSubmit').css("cursor", "default");
                        }
                    }
                });
            }
        }
    }
    function closePopup() {

        $("body").css("overflow", "auto");
        document.getElementById('<%=lblErrorForgotPwd.ClientID %>').style.display = "none";
        document.getElementById('<%=lblWaitMessage.ClientID %>').style.display = "none";
        document.getElementById('<%=lblSuccessMsg.ClientID %>').style.display = "none";
        $('#txtEmailID').val('');
        $('#btnSubmit').attr("disabled", false);
        $('#btnSubmit').css("cursor", "pointer");
    }
</script>
<style type="text/css">
    #imgBtnLogin {
        cursor: pointer;
    }
</style>
<div style="height: 329px; padding-top: 0; width: 550px;">
    <div class="closeBtnDiv" style="margin-right: -20px;">
        <a class="bClose" onclick="return closePopup();"></a>
    </div>
    <div class="signInLogo borderRadiusTopCorners6" style="width: 550px;">
        <b><span class="bigTitle">Forgot Password</span></b>
    </div>
    <%--class="divForgotPwdSubHeading"--%>
    <div style="padding-left: 35px;">
        <span>Enter your Registered Email Address and we will send
            a mail</span>
        <br />
        <span>containing the Password Reset Link</span>
    </div>
    <div class="floatLeft ForgotPwdBody">
        <div>
            <div class="padding15" style="margin-top: 17px;">
                <asp:TextBox ID="txtEmailID" Width="215" runat="server" MaxLength="30" ClientIDMode="Static" onkeydown="handle(event.keyCode);" onkeypress="return (event.keyCode!=13);"></asp:TextBox>
            </div>
            <div class="floatLeft" style="margin-left: 18px; margin-top: -10px;">
                <asp:Label ID="lblErrorForgotPwd" runat="server" ForeColor="Red" Font-Bold="true"
                    Text="" Style="display: none" ClientIDMode="Static" />
                <asp:Label ID="lblSuccessMsg" runat="server" ForeColor="Red" Font-Bold="true" Text="Check your email to reset password"
                    Style="display: none;" />
                <asp:Label ID="lblWaitMessage" runat="server" ForeColor="Red" Font-Bold="true" Text="Please wait..."
                    Style="display: none;" />
            </div>
        </div>
        <div class="padding15  floatRight" style="margin-left: 125px; margin-top: 12px; padding-top: 7px !important; margin-right: 10px;">
            <input type="button" id="btnSubmit" class="blackBtnMiddle whiteColor" value="Submit"
                onclick="AuthenticateEmailID();" />
        </div>
        <div class="ForgotPasswordBottomImg">
            <img src="../Images/forgot_password_bottom.png" alt="" />
        </div>
    </div>
</div>
