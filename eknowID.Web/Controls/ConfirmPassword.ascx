<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfirmPassword.ascx.cs" Inherits="eknowID.Controls.ConfirmPassword" %>
<script type="text/javascript" language="javascript">

    //To set water text 
    $(function () {
        $('#txtEmail').watermark('Email Address');
    });


</script>
<style type="text/css">
    #imgBtnLogin
    {
        cursor: pointer;
    }   
</style>
<div class="stretchDiv" style="height: 329px; padding-top: 0; width: 550px;">
    <div class="closeBtnDiv" style="margin-right: -20px;">
        <a class="bClose"></a>
    </div>
    <div class="signInLogo borderRadiusTopCorners6" style="width: 540px; margin-left: 0px !important;">
        <b><span class="bigTitle">Forgot Password</span></b>
    </div>
    <div class="divForgotPwdSubHeading">
        <span class="ForgotPwdSubHeading">Enter your Registered Email Address and we will send
            a mail</span>
        <br />
        <span class="ForgotPwdSubHeading">containing the Password Reset Link</span>
    </div>
    <div class="floatLeft ForgotPwdBody">
         <div>
            <div class="paddingTop15 paddingLeft15" style=" font-weight:bolder;">
                New Password</div>
            <div class="padding15" style="padding-top: 7px !important;">
                <asp:TextBox ID="txtNewPwd" Width="205px" runat="server" MaxLength="30" CssClass="required"></asp:TextBox></div>
        </div>
        <div>
            <div class="paddingTop15 paddingLeft15" style=" font-weight:bolder;">
                Confirm New Password</div>
            <div class="padding15">
                <asp:TextBox ID="txtConfirmPassword" Width="205px" runat="server" TextMode="Password" MaxLength="30" CssClass="required" onkeydown= "handle(event.keyCode);" onkeypress="return (event.keyCode!=13);"></asp:TextBox></div>
            <div class="floatLeft" style="margin-left:18px;margin-top:-10px;">
            <asp:Label ID="lblErrorSignIn" runat="server"  ForeColor="Red" Font-Bold="true" Text="Invalid UserName or Password"  style="display:none" />
            </div>
            <div style="margin-left: 128px; margin-top: 5px;font-weight:bolder;" class="clearBoth forgotPassword">
                <a href="../pages/forgotPassword.aspx" target="_blank" style="text-decoration: none" class="lnkColor">Forgot Password?</a></div>
        </div>
        <div class="padding15  floatRight" style="margin-left: 125px; margin-top: 12px; padding-top: 7px !important;
            margin-right: 10px;">
            <input type="button" class="blackBtnMiddle whiteColor" value="Reset Password" />
        </div>
        <div class="ForgotPasswordBottomImg">
            <img src="../Images/forgot_password_bottom.png" alt="" />
        </div>
    </div>
</div>

