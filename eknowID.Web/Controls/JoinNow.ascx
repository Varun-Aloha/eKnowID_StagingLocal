<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JoinNow.ascx.cs" Inherits="eknowID.Controls.JoinNow" %>
<script type="text/javascript" language="javascript">
    $('#txtFirstName').watermark('First');
    $('#txtLastName').watermark('Last');

    $(document).ready(function () {
        $('#txtPassword').pwdMeter({
            minLength: 6,
            displayGeneratePassword: false,
            generatePassText: 'Password Generator',
            generatePassClass: 'GeneratePasswordLink',
            randomPassLength: 15
        });
    });


    $(document).ready(function () {

        $('#txtPassword').keypress(function () {
            $("#pwdMeter").css("display", "block;");
        });
    });

    window.onload = function (e) {
        $("#pwdMeter").css("display", "none !important;");
    }
</script>
<style type="text/css">
    #btnCreateAccount
    {
        background-image: url(../Images/Create_Ac_btn.png);
        background-repeat: no-repeat;
        width: 134px;
        height: 29px;
        border-width: 0px;
        cursor: pointer;
    }
    
    
    .detailNameValue
    {
        padding: 5px;
        text-align: left;
        height: 25px;
        width: auto;
        margin-left: 25px;
    }
    .widthauto
    {
        width: auto;
    }
    .signUpLogo
    {
        height: 72px;
        width: auto;
        padding-top: 15px;
        padding-left: 10px;
        background-image: url(../Images/sign_in_header_bg_popup.png);
        background-repeat: repeat-x;
    }
    .signUpForm
    {
        margin-top: 10px;
        padding-top: 15px;
        padding-left: 15px;
        padding-bottom: 15px;
        border-radius: 4px;
    }
    .detailsNameList
    {
        text-align: center;
        width: 18%;        
    }  
    .signUpRightImage
{
    margin-top:-19px;
} 
</style>
<!--[if IE]>
	<style type="text/css">
.signUpRightImage
{
    margin-top:-17px;
}
</style>
<![endif]-->
<div style="width: 700px;">
    <div class="floatRight">
        <a class="dialogClose" onclick="CloseSingUp();"></a>
    </div>
    <div class="dialogHeader borderRadiusTopCorners6">
        <b><span class="bigTitle" style="color:#2a2a2a; margin-left:27px;">Join Now</span> or <a href="#" class="lnkColor signInDiv"
            title="SignIn" onclick="SignInDialog();">Sign In</a></b>
    </div>
    <div style="padding-left: 27px;">
        <b style="color: #415d8f; font-size: 25px; font-weight: 100;">Join eKnowID,</b><b
            style="color: #415d8f; font-size: 18px;">&nbsp;it's fast and easy !</b>
        <br />
        <p style="color: #6a6969; font-size: 16px;">
            Sign up now and <b style="color: #5f5e5e; font-size: 20px;">look Beyond Your Surface</b></p>
    </div>
    <div class="width100per" style="background-color: White;" id ="joinNowForm">
        <div class="signUpForm widthauto">
            <div class="detailsNameList floatLeft">
                <div class="detailsName labelColor">
                    Name
                </div>
                <div class='detailsName labelColor'>
                    Email Address
                </div>
                <div class='detailsName labelColor'>
                    Confirm Email Address
                </div>
                <div class='detailsName labelColor'>
                    Password
                </div>
                <div class='detailsName labelColor'>
                </div>
                <div class='detailsName labelColor'>
                    Confirm Password
                </div>
            </div>
            <div class='floatLeft' id="inputContainer">
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="20" ClientIDMode="Static"
                        CssClass="width80 required lettersonly charOnly validateSingUp" /><span class="red asterisk">*</span>
                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="width80 marginLeft10 charOnly validateSingUp"
                        MaxLength="20" ClientIDMode="Static" placeholder="Middle" />
                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="20" ClientIDMode="Static"
                        CssClass="width80 marginLeft10 required lettersonly charOnly validateSingUp" /><span
                            class="red asterisk">*</span>
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtEmailAddress" CssClass="width285 required email orgEmail validateSingUp"
                        runat="server" MaxLength="50" ClientIDMode="Static" /><span class="red asterisk">*</span>
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtConfirmEmailAddress" CssClass="width285 required email compareEmail validateSingUp"
                        equalTo="#txtEmailAddress" runat="server" MaxLength="50" ClientIDMode="Static" /><span
                            class="red asterisk">*</span>
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtPassword" CssClass="width285 required validateSingUp" runat="server"
                        minlength="6" MaxLength="15" TextMode="Password" ClientIDMode="Static" oncopy="return false;"
                        onpaste="return false;" oncut="return false;" /><span class="red asterisk">*</span>
                </div>
                <div class="detailNameValue">
                    <div class="strength-indicator" style="height: 30px;">
                        <div id="pwdMeter" class="neutral joinNowPwdMeter" runat="server" clientidmode="Static" style="display: none;margin-left:0px !important;">
                            Very Weak</div>
                    </div>
                </div>
                <div class='detailNameValue '>
                    <asp:TextBox ID="txtConfirmPassword" CssClass="width285 required comparePassword validateSingUp"
                        minlength="6" equalTo="#txtPassword" oncopy="return false;" onpaste="return false;"
                        oncut="return false;" runat="server" MaxLength="15" TextMode="Password" ClientIDMode="Static" /><span
                            class="red asterisk">*</span>
                </div>
                <div class='detailNameValue'>
                    <asp:CheckBox ID="chkAgree" runat="server" CssClass="validateSingUp" onkeypress="return (event.keyCode!=13);"
                        Text="I agree to the eKnowID " ClientIDMode="Static" /><a href="../Pages/TermsofUse.aspx"
                            target="_blank" class="lnkColor">Terms & Conditions</a>
                </div>
                <div class='detailNameValue'>
                    <input type="button" id="btnCreateAccount" class="Createbtn floatLeft" onclick="ValidateSignUp();" />
                </div>
            </div>
            <div class="floatRight signUpRightImage" style="background-image: url(../Images/sign_up_img.png); width: 207px;
                height: 345px; background-repeat: no-repeat;" >
            </div>
        </div>
    </div>
    <img src="../Images/sign_in_bottom_white_bg_new.png" class="joinCutImage" alt="" style="width: auto; margin-top:-14px;" />
</div>
