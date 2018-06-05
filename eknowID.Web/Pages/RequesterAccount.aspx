<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="RequesterAccount.aspx.cs" Inherits="eknowID.Pages.RequesterAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(function () {
            $("#txtRequesterEmail").keypress(function () {

                $("#emailError").hide();
            });
        });


        function hasEmailExists() {

            var isEmailAddressPresent = false;

            var emailId = {
                emailID: $("#txtRequesterEmail").val()
            }

            $.ajax({
                type: "POST",
                url: "loginajaxcalls.aspx/CheckIfExist",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(emailId),
                dataType: "json",
                async: false,
                success: function (result) {
                    if (result.d.Success) {
                        $("#emailError").html("email address is exists");
                        $("#emailError").show();
                        Page_IsValid = result.d.Success;
                        isEmailAddressPresent = false;
                    }
                    else {
                        $("#emailError").hide();
                        Page_IsValid = result.d.Success;
                        isEmailAddressPresent = true;
                    }
                }
            });

            return isEmailAddressPresent;
        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="section-2">
        <div class="top-content">
            <div class="inner-bg">
                <div class="container">
                    <div class="row" style="margin-top: -40px;">
                        <div class="col-sm-5 col-sm-offset-3">
                            <div class="form-box">
                                <div class="form-top">
                                    <div class="form-top-left">
                                        <h3>Sign up now</h3>
                                        <p>Fill in the form below to get instant access</p>
                                    </div>                                    
                                </div>
                                <div class="form-bottom">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtFirstName" runat="server" MaxLength="30" placeholder="First name..." CssClass="form-control textbox charactersOnly" required></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtLastName" runat="server" MaxLength="30" placeholder="Last name..." CssClass="form-control textbox charactersOnly" required></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtRequesterEmail" runat="server" MaxLength="50" placeholder="Email..." CssClass="form-control textbox"
                                            TextMode="Email" ClientIDMode="Static"
                                            pattern="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            oninvalid="setCustomValidity('Please enter valid email address.')"
                                            onchange="try{setCustomValidity('')}catch(e){}" required>
                                        </asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtRequPassword" runat="server" MaxLength="15" placeholder="Password" CssClass="form-control textbox" TextMode="Password" ClientIDMode="Static" required></asp:TextBox>
                                        <asp:CustomValidator runat="server" ID="cusCustom"
                                            ControlToValidate="txtRequPassword"
                                            OnServerValidate="cusCustom_ServerValidate"
                                            Text="Password must be grater then 6 and less the 15 characters"
                                            Display="Dynamic"
                                            ForeColor="#FF3300" Font-Size="Medium" />
                                    </div>

                                    <div class="form-group">
                                        <span id="emailError" class="card-error" style="font-size: 18px !important"></span>
                                    </div>

                                    <asp:Button runat="server" ID="btnRequesterSignup" Text="Sign up" CssClass="signup-button" OnClientClick="return hasEmailExists();" OnClick="btnRequesterSignup_Click" ClientIDMode="Static" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
