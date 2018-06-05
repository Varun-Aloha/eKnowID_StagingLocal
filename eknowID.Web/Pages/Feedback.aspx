<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="eknowID.Pages.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" language="javascript">
        function ValidateFeedbackForm() {

            var errorMessage = "Please fill mandatory information to continue.";
            if (!($("#mstrPage").valid())) {

                if (!($('#txtFeedbackEmailAddress').valid())) {
                    if ($('#txtFeedbackEmailAddress').val().length > 0) {
                        errorMessage = "Please enter valid email address.<br/>";
                    }
                }

                if (errorMessage.trim() != "") {
                    OpenDialog(errorMessage, function () {
                        $('div.divFeedbackBg input[type="text"].error,textarea.error').first().focus();
                    });
                }
            }
        }

        function successPopup() {
            OpenDialog("Thank you for your feedback.", function () {
                window.location.href = "../Pages/index.aspx";
            });
        }

        function setCaptchaTxtFocus() {
            $("#txtcaptcha").focus();
        }
        $(function () {
            $(".validateFeedback").keydown(function (e) {
                if (e.which == 13) {
                    ValidateFeedbackForm();
                    e.preventDefault();
                    return false;
                }
            });
        });

    </script>
    <style type="text/css">
        .divCaptchaRefresh {
            float: left;
            height: 48px;
            padding-top: 17px;
            width: 147px;
        }

        .divFeedbackBg {
            background-color: #E7E7E7;
            height: 583px;
            padding-top: 35px;
            color: #404040;
            font-family: helvetica;
            font-size: 13px;
        }

        .divInnerFeedbackBg {
            background-color: white;
            border-color: #D7D7D7;
            border-radius: 2px 2px 2px 2px;
            box-shadow: 2px 2px 4px #8A8A8A;
            height: 492px;
            padding-top: 30px;
            padding-bottom: 30px;
            padding-left: 50px;
            padding-right: 50px;
            width: 900px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdnCaptchaVal" runat="server" ClientIDMode="Static" />
    <div class="divFeedbackBg minWidth1000px">
        <div class="divInnerFeedbackBg clearBoth margin_left_right_auto paddingBottom15 paddingTop10">
            <h1>Feedback</h1>
            <div class="divFeedbackMain">
                <div>
                    eKnowID values innovation and development. Please feel free to give your feedback
                    by filling out the boxes below. We look forward to hearing from you.
                </div>
                <div class="divSubFeedback">
                    <div>
                        <div class='detailsName floatLeft' style="font-weight: bolder; color: #5f5e5e;">
                            Email:
                        </div>
                        <div class='detailNameValue'>
                            <asp:TextBox ID="txtFeedbackEmailAddress" CssClass="width260 required email orgEmail validateFeedback"
                                runat="server" MaxLength="50" ClientIDMode="Static" /><span
                                    class="red asterisk">*</span>
                        </div>
                    </div>
                    <div>
                        <div class='detailsName floatLeft' style="font-weight: bolder; color: #5f5e5e;">
                            Subject:
                        </div>
                        <div class='detailNameValue'>
                            <asp:TextBox ID="txtFeedbackSubject" CssClass="width260 required validateFeedback"
                                runat="server" MaxLength="50" ClientIDMode="Static" /><span
                                    class="red asterisk">*</span>
                        </div>
                    </div>
                    <div style="height: 140px;">
                        <div class='detailsName floatLeft' style="font-weight: bolder; color: #5f5e5e;">
                            Message:
                        </div>
                        <div class='detailNameValue' style="height: 112px;">
                            <asp:TextBox ID="txtFeedbackMessage" runat="server" TextMode="MultiLine" CssClass="required feedbackMessageTxt validateFeedback"
                                ClientIDMode="Static" MaxLength="100" /><span
                                    class="red asterisk">*</span>
                        </div>

                        <div>
                            <div class='detailsName floatLeft' style="font-weight: bolder; color: #5f5e5e; height: 0px !important">
                            </div>
                            <div class='detailNameValue'>
                                *Answers to questions will be answered within 24 hours.
                            </div>
                        </div>
                    </div>
                    <div>
                        <div class='detailsName floatLeft'>
                        </div>
                        <div class='detailNameValue divCaptcha floatLeft'>
                            <asp:Image ID="imgcaptcha" AlternateText="Captcha" runat="server" CssClass="floatLeft"
                                ClientIDMode="Static" />
                            <div class="divCaptchaRefresh floatLeft">
                                <asp:LinkButton ID="LBcaptcha" runat="server" CssClass="marginleft15" OnClick="LBcaptcha_Click"
                                    ToolTip="Change Image"><img src="../Images/refresh.png" alt="" /></asp:LinkButton>
                            </div>
                            <br />
                            <br />
                            Type letters from the image:<br />
                            <br />
                            <asp:TextBox ID="txtcaptcha" runat="server" ClientIDMode="Static" CssClass="required validateFeedback"
                                MaxLength="5"></asp:TextBox><span
                                    class="red asterisk">*</span><br />
                            <asp:Label ID="lblErrorCaptcha" runat="server" ForeColor="Red" Font-Bold="true" Text="The text is not correct!"
                                ClientIDMode="Static" CssClass="captchaErrorMsg marginLeft5" Visible="false" />
                            <asp:Label ID="lblSuccessCaptcha" runat="server" ForeColor="Red" Font-Bold="true"
                                Text="" ClientIDMode="Static" CssClass="captchaSuccessMsg" /><br />
                        </div>
                    </div>
                    <div class="divFeedbackSubmit">
                        <asp:Button ID="btnOk" runat="server" CssClass="blackBtnMiddle CompletePurchase" ForeColor="WhiteSmoke" Text="Submit" OnClientClick="return ValidateFeedbackForm();" OnClick="btnOk_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
