<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="SearchByProf_Login.aspx.cs" Inherits="eknowID.Pages.SearchByProf_Login"
    MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/Controls/SearchByProfHeader.ascx" TagName="SearchByRef" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/joinEknowID.ascx" TagName="ChoosePlan" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/innerSignIn.ascx" TagName="SignIn" TagPrefix="uc3" %>
<%@ Register Src="~/Controls/innerSignUp.ascx" TagName="SignUp" TagPrefix="uc4" %>
<%@ Register Src="~/Controls/innerSignUpData.ascx" TagName="SignUpData" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery.watermark.js" type="text/javascript"></script>
    <script type="text/javascript">
        var emailAddress = "";
        var password = "";
        var confirm = "";
        $(document).ready(function () {

            $('#SignUpLink').click(function () {
                $('#ucSignInDiv').css('display', 'none');
                $('#ucSignUpDiv').css('display', 'block');
                $('#txtinnerSignUpEmail').focus();
               
            });

            $('#SignInLink').click(function () {
                $('#ucSignUpDiv').css('display', 'none');
                $('#lblError').css('display', 'none');
                $('#ucSignInDiv').css('display', 'block');
                $("#txtSignInEmail").focus();
            });


        });

        function showinnerSignUp() {      
            
            emailAddress = $('#txtinnerSignUpEmail').val();
            password = $('#txtinnerPassword').val();
            confirm = $('#txtinnerConfirmPassword').val();
            if (!($("#mstrPage").valid())) {

                if (emailAddress == "" && password.length == 0 && confirm.length == 0) {
                    $("#lblInnerError1").text("Please fill mandatory information to continue.");
                    $("#lblInnerError1").css("display", "inherit");                 
                    $('#txtinnerSignUpEmail').focus();
                    return false;
                }

                if ($('#txtinnerSignUpEmail').valid()) {
                    if (password.length == 0 && confirm.length == 0) {
                        $("#lblInnerError1").text("Please enter the password and confirm password.");
                        $("#lblInnerError1").css("display", "inherit");
                        $("#txtinnerPassword").val('');
                        $("#txtinnerConfirmPassword").val('');
                        $('#txtinnerPassword').focus();
                        return false;
                    }

                    if ($('#txtinnerPassword').valid()) {
                        if (!($('#txtinnerConfirmPassword').valid())) {
                            $("#lblInnerError1").text("Confirm password does not match,please re-enter the password in the ‘Confirm Password’ field.");
                            $("#txtinnerPassword").val('');
                            $("#txtinnerConfirmPassword").val('');
                            $('#txtinnerPassword').focus();
                    $("#lblInnerError1").css("display", "inherit");
                    return false;
                        }
                    }
                    else {
                        $("#lblInnerError1").text("Please enter valid the password in the ‘Password’ field.");
                        $("#txtinnerPassword").val('');
                        $("#txtinnerConfirmPassword").val('');
                        $('#txtinnerPassword').focus();
                        $("#lblInnerError1").css("display", "inherit");
                        return false;
                    }              

                } 
                else {
                    $("#lblInnerError1").text("Please enter a valid email address.");
                    $("#txtinnerPassword").val('');
                    $("#txtinnerConfirmPassword").val('');
                    $('#txtinnerSignUpEmail').focus();
                    $("#lblInnerError1").css("display", "inherit");
                    return false;
                }

                if (!$('#txtinnerSignUpEmail').valid()) {
                    $("#lblInnerError1").text("Please enter the valid email address.");
                    $("#txtinnerPassword").val('');
                    $("#txtinnerConfirmPassword").val('');
                    $('#txtinnerSignUpEmail').focus();
                    $("#lblInnerError1").css("display", "inherit");
                    return false;
                }              

                return false;
            }


                $('#txtEmailAddressInner').val(emailAddress);
                $('#txtConfirmEmailAddressInner').val(emailAddress);
                $('#txtPasswordInner').val(password);
                $('#txtConfirmPasswordInner').val(password);

                $('#ucSignUpDiv').css('display', 'none');
                $('#ucJoinIDDiv').css('display', 'none');
                $('#ucSignUpDataDiv').css('display', 'block');
                $('#txtFName').focus();
            }
        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="SearchByRef_background" style="height: 632px; background-color: White;">
        <div class="SearchByRef_mainDiv">
            <div>
                <uc1:SearchByRef ID="ucSearchHeader" runat="server" />
            </div>
            <div style="padding-top: 35px; padding-left: 20px;">
          
                <div id="ucSignInDiv">
                    <uc3:SignIn ID="ucSignIn" runat="server" />
                </div>
                <div id="ucSignUpDiv" style="display: none">
                    <uc4:SignUp ID="ucSignUp" runat="server" />
                </div>
            </div>
            <div id="ucSignUpDataDiv" style="display: none">
                <uc5:SignUpData ID="ucSignUpData" runat="server" />
            </div>
        </div>
    </div>--%>
</asp:Content>
