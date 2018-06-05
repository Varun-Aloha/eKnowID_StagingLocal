<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="innerSignIn.ascx.cs"
    Inherits="eknowID.Controls.innerSignIn" %>
<script type="text/javascript" language="javascript">

    function innerSignInhandle(code) {
        if (code == 13) {
            IsValidInnerSignIn();
        }
    }

    function IsValidInnerSignIn() {

        var email = $('#txtSignInEmail').val();
        var Password = $('#txtSignInPassword').val().length;
        if (!($("#mstrPage").valid())) {
            if (email.length == 0 && Password == 0) {
                $("#lblError").text("Please enter your account credentials.");
                $("#lblError").css("display", "inherit");
                $("#txtSignInPassword").val('');
                $('#txtSignInEmail').focus();
            }
            else {
                if ($('#txtSignInEmail').valid()) {
                    if (!($('#txtSignInPassword').valid())) {
                        if (Password == 0) {
                            $("#lblError").text("Please enter valid password.");
                        }
                        else {
                            $("#lblError").text("The username or password you entered is incorrect.");
                        }
                        $("#lblError").css("display", "inherit");
                        $("#txtSignInPassword").val('');
                        $('#txtSignInPassword').focus();
                        return false;
                    }
                }
                else {
                    $("#lblError").text("Please enter valid email address.");
                    $("#lblError").css("display", "inherit");
                    $("#txtSignInPassword").val('');
                    $('#txtSignInEmail').focus();
                    return false;
                }
            }
        }
        else {
            AuthenticateUser();
        }
    }

    function AuthenticateUser() {
        if ($('#mstrPage').valid()) {
            var controlData = "email:'" + $('#txtSignInEmail').val() + "'";
            controlData = controlData + ",password:'" + $('#txtSignInPassword').val() + "'";
            $.ajax({
                type: "POST",
                url: "loginajaxcalls.aspx/AuthenticateUser",
                contentType: "application/json; charset=utf-8",
                data: "{" + controlData + "}",
                dataType: "json",
                success: function (result) {
                    if (result.d.Success != false) {
                        $("#lblError").text("");
                        window.location.href = "SearchByProf_PaymentInfo.aspx";
                    }
                    else {
                        $("#lblError").text("The username or password you entered is incorrect.");
                        $("#txtSignInPassword").val('');
                        $('#txtSignInPassword').focus();
                        $("#lblError").css("display", "inherit");
                    }
                }
            });
        }
    }
    window.onload = function (e) {
        $("#txtSignInEmail").focus();
    }
</script>
<div class="SearchByRefLoginSignIn_MainDiv">
    <div class="SearchByRefLoginSignIn_HeadDiv">
        <b><span class="SearchByRefLoginSignIn_Heading">Sign in</span> or <a href="#" id="SignUpLink"
            class="lnkColor" title="SignUp">Sign up</a></b>
    </div>
    <div id="singIn" class="SearchByRefLoginSignIn_SubHeading">
        <h3 class="marginBottom0 marginTop0 paddingBottom15">Sign in with your eKnowID Account</h3>
    </div>
    <div class="SearchByRefLoginSignIn_LoginDiv floatLeft">
        <div>
            <div class="boldText">
                Email Address
            </div>
            <div class="SearchByRefLoginSignIn_Logintxt">
                <asp:TextBox ID="txtSignInEmail" Width="273px" CssClass="required email" runat="server"
                    MaxLength="50" onkeydown="innerSignInhandle(event.keyCode);" onkeypress="return (event.keyCode!=13);"
                    ClientIDMode="Static"></asp:TextBox>
            </div>
        </div>
        <div>
            <div class="boldText">
                Password
            </div>
            <div class="SearchByRefLoginSignIn_Logintxt">
                <asp:TextBox ID="txtSignInPassword" Width="273px" runat="server" CssClass="required"
                    TextMode="Password" minlength="6" MaxLength="15" onkeydown="innerSignInhandle(event.keyCode);"
                    onkeypress="return (event.keyCode!=13);" ClientIDMode="Static"></asp:TextBox>
            </div>
            <div class="floatLeft">
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Size="11px" Font-Bold="true"
                    Text="The username or password you entered is incorrect." ClientIDMode="Static"
                    Style="display: none" />
            </div>
            <div class="floatRight clearBoth forgotPassword">
                <a href="../Pages/forgotPassword.aspx" class="SearchByRefLoginSignIn_ForgotPwd">Forgot
                    Password?</a>
            </div>
        </div>
        <div class="SearchByRefLoginSignIn_LoginBtnDiv">
            <asp:ImageButton ID="imgBtnLogin" ImageUrl="~/Images/Login_btn.png" runat="server"
                OnClientClick="IsValidInnerSignIn();return false;" />
        </div>
    </div>
    <div class="SearchByRefLoginSignIn_SeperatorDiv floatLeft">
        <div class="SearchByRefLoginSignIn_leftSeperatorDiv">
        </div>

    </div>
    <div class="SearchByRefLoginSignIn_SocialSiteDiv floatLeft">
        <div>
            <asp:ImageButton ID="imgBtnFacebook" ImageUrl="~/Images/Sign_in_FB.png" runat="server"
                ClientIDMode="Static" OnClientClick="return login('facebook','SingIn','Inner')" />
        </div>
        <div style="margin-top: 10px">
            <asp:ImageButton ID="imgBtnLinkedIn" ImageUrl="~/Images/Sign_in_Linkedin.png" runat="server"
                ClientIDMode="Static" OnClientClick="return login('LINKEDIN','SingIn','Inner')" />
        </div>
    </div>
</div>
