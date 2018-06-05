<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="singIn.ascx.cs" Inherits="eknowID.Controls.singIn" %>
<script type="text/javascript" language="javascript">
    function handle(code) {
        if (code == 13) {
            ValidateSignIn();
        }
    }

    function ValidateSignIn() {
        var email = $("#txtEmail").val();
        var Password = $("#txtPasswordSingIn").val().length;

        if (!($('#txtEmail').valid()) || !($('#txtPasswordSingIn').valid())) {
            if (email == "" && Password == 0) {
                $("#lblErrorSignIn").text("Please enter your account credentials.");
                $("#lblErrorSignIn").css("display", "inherit");
                $("#txtPasswordSingIn").val('');
                $('#txtEmail').focus();
                return false;
            }
            else {
                if ($('#txtEmail').valid()) {
                    if (!($('#txtPasswordSingIn').valid())) {
                        if (Password == 0) {
                            $("#lblErrorSignIn").text("Please enter valid password.");
                        } else {
                            $("#lblErrorSignIn").text("The username or password you entered is incorrect.");
                        }
                        $("#lblErrorSignIn").css("display", "inherit");
                        $("#txtPasswordSingIn").val('');
                        $('#txtPasswordSingIn').focus();
                        return false;
                    }
                }
                else {
                    $("#lblErrorSignIn").text("Please enter valid email address.");
                    $("#lblErrorSignIn").css("display", "inherit");
                    $('#txtEmail').focus();
                    $("#txtPasswordSingIn").val('');
                    return false;
                }
            }
        }
        else {

            AuthenticateUserSignIn();
        }
    }

    function AuthenticateUserSignIn() {

        if (($('#txtEmail').valid()) && ($('#txtPasswordSingIn').valid())) {
            var controlData = "email:'" + $("#<%=txtEmail.ClientID%>").val() + "'";
            controlData = controlData + ",password:'" + $("#<%=txtPasswordSingIn.ClientID%>").val() + "'";
            $.ajax({
                type: "POST",
                url: "loginajaxcalls.aspx/AuthenticateUser",
                contentType: "application/json; charset=utf-8",
                data: "{" + controlData + "}",
                dataType: "json",
                success: function (result) {
                    if (result.d.Success != false) {

                        if ($.cookie('redirectToOrderDetail') == "true") {
                            window.location.href = "../Pages/OrderDetail.aspx";
                        }
                        else {
                            location.reload(true);
                        }
                    }
                    else {
                        $("#<%=lblErrorSignIn.ClientID %>").text("The username or password you entered is incorrect.");
                        document.getElementById('<%=lblErrorSignIn.ClientID %>').style.display = "inherit";
                        $("#txtPasswordSingIn").val('');
                    }
                }
            });
        }
    }
</script>
<style type="text/css">
    .signInLogo {
        height: 72px;
        width: 100%;
        padding-top: 15px;
        background-image: url(../Images/sign_in_header_bg_popup.png);
        background-repeat: repeat-x;
    }

    #imgBtnLogin {
        cursor: pointer;
    }
</style>
<!--[if gte IE 8]>
	<style type="text/css">
  .signInBottomImg
{
  
    margin-top:-14px;
}

</style>
<![endif]-->
<div class="stretchDiv" style="height: 360px; width: 100%; font-family: Arial,Helvetica,sans-serif; font-size: 12px; box-sizing:initial;">
    <div class="floatRight">
        <a class="dialogClose" onclick="CloseSingIn();"></a>
    </div>
    <div class="dialogHeader borderRadiusTopCorners6" style="box-sizing:initial">
        <b><span class="bigTitle" style="color: #2a2a2a; margin-left: 24px;">Sign In</span> or <a href="#" class="lnkColor" onclick="SignUpDialog();"
            title="Join Now">Join Now</a></b>
    </div>
    <div id="singIn" class="paddingTop15" style="padding-left: 28px; box-sizing:initial">
        <h2 class="marginBottom0 marginTop0 paddingBottom15" style="color: #5f5e5e; font-size:20px;">Sign In with your eKnowID Account</h2>
    </div>
    <div class="floatLeft signInForm paddingLeft15">
        <div style="box-sizing:initial">
            <div class="paddingTop15 paddingLeft15 labelColor" style="font-weight: bolder; box-sizing:initial">
                Email Address
            </div>
            <div class="padding15" style="padding-top: 7px !important; width: 300px; box-sizing:initial">
                <asp:TextBox ID="txtEmail" ClientIDMode="Static" runat="server" MaxLength="50" CssClass="required email width275"
                    onkeydown="handle(event.keyCode);" onkeypress="return (event.keyCode!=13);" TabIndex="1"></asp:TextBox><span
                        class="red asterisk">*</span>
            </div>
        </div>
        <div style="box-sizing:initial">
            <div class="paddingTop15 paddingLeft15 labelColor" style="font-weight: bolder; box-sizing:initial">
                Password
            </div>
            <div class="padding15" style="padding-top: 7px !important; width: 300px; box-sizing:initial">
                <asp:TextBox ID="txtPasswordSingIn" ClientIDMode="Static" runat="server" TextMode="Password"
                    minlength="6" MaxLength="15" CssClass="required width275" onkeydown="handle(event.keyCode);"
                    onkeypress="return (event.keyCode!=13);" TabIndex="2"></asp:TextBox><span class="red asterisk">*</span>
            </div>
            <div class="floatLeft" style="margin-left: 18px; margin-top: -10px;">
                <asp:Label ID="lblErrorSignIn" runat="server" ForeColor="Red" Font-Bold="true" Text="Invalid UserName or Password"
                    ClientIDMode="Static" Font-Size="10px" Style="display: none" Width="288" />
            </div>
            <div class="padding15" style="height: 46px; padding-top: 3px; width: 274px; box-sizing:initial">
                <img id="imgBtnLogin" src="../Images/Login_btn.png" onclick="ValidateSignIn();" alt=""
                    tabindex="3" onkeydown="handle(event.keyCode);" onkeypress="return (event.keyCode!=13);"
                    class="floatLeft" />
                <asp:ImageButton ID="imgBtnConnectLinkedIn" runat="server" ImageUrl="~/Images/Sign_in_Linkedin.png"
                    CausesValidation="False" OnClientClick="return SocailSiteLogin('LINKEDIN','SingInUp')" Style="margin-left: 4px; width: 172px;" />
                <span style="font-weight: bolder; margin: 5px 0 0; width: 186px;" class="floatLeft forgotPassword">
                    <a href="#" target="_blank" style="text-decoration: none" class="lnkColor">Forgot Password?</a></span>
            </div>
        </div>
    </div>
    <div class="floatLeft" style="background-image: url(../Images/sign_up_img.png); width: 207px; height: 345px; margin-top: -111px; margin-left: 35px; background-repeat: no-repeat;">
    </div>
    <img src="../Images/sign_in_bottom_white_bg_new.png" alt="" class="signInBottomImg"
        style="width: 520px; box-sizing:initial" />
</div>
