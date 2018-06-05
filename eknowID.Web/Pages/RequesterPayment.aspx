<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="RequesterPayment.aspx.cs" ClientIDMode="Static" Inherits="eknowID.Pages.RequesterPayment" %>

<%@ Register Src="~/Controls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="ProgressBar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../Scripts/jquery.payment.js"></script>


    <style type="text/css">
        #updatedWallet {
            display: none;
        }

        #walletBalance {
            display: none;
        }

        #PaymentMsgContainer {
            display: none;
            margin-left: 25px;
            font-size: 25px;
            margin-top: 10px;
            color: #a94442;
        }

        a {
            color: #38b6e7;
        }

            a:hover, a:active, a:focus {
                text-decoration: none !important;
                color: #38b6e7 !important;
            }

        .text-height {
            height: 40px;
            font-size: 15px;
            border-radius: 3px;
            box-shadow: inset 0 0 1px 1px #d5d5d5;
            background: #fff;
        }

        input::-webkit-input-placeholder {
            font-size: 17px;
        }

        input::-moz-placeholder {
            font-size: 17px;
        }

        input:-ms-input-placeholder {
            font-size: 17px;
        }

        input:-moz-placeholder {
            font-size: 17px;
        }
    </style>

    <script>


        var isPaymentReceived = false;

        $(window).bind('beforeunload', function () {
            if (!isPaymentReceived) {
                return "Are you sure you want to leave? Think of the kittens!";
            }
        });

        $(function () {

            $('#chkWallet').prop('checked', false); // Checks it

            var isFullWalletPayment = false;
            var isPartialWalletPayment = false;
            var isFullCreditCardPayment = true;

            var hdnTotalPrice = parseFloat($("#hdnTotalPrice").val());
            var hdnWalletBalance = parseFloat($("#hdnWalletBalance").val());

            $("#walletBalanceSummary").html(hdnWalletBalance.toFixed(2));
            $("#totalPayable").html(hdnTotalPrice.toFixed(2));

            //default enabled
            $("#txtccNumber").prop('disabled', false);
            $("#txtExpDate").prop('disabled', false);
            $("#txtSecurityCode").prop('disabled', false);
            $("#chkWallet").attr("disabled", false);

            if (hdnWalletBalance == 0) {
                $("#lblTitle").attr("title", "Your Wallet is Empty");
                $("#chkWallet").attr("disabled", true);
            }

            var setPaymentPrice = parseFloat(hdnTotalPrice).toFixed(2);            
            
            $("#chkWallet").change(function () {

                if ($(this).is(":checked")) {

                    isFullCreditCardPayment = false;

                    if (hdnTotalPrice <= hdnWalletBalance) {

                        isFullWalletPayment = true;

                        var result = parseFloat(hdnWalletBalance - hdnTotalPrice);
                        setPaymentPrice = result.toFixed(2);
                        $("#totalPayable").html("00.00");

                        $("#txtccNumber").prop('disabled', true);
                        $("#txtExpDate").prop('disabled', true);
                        $("#txtSecurityCode").prop('disabled', true);

                        $("#lblUpdatedWallet").html(setPaymentPrice);
                    }
                    else {

                        isPartialWalletPayment = true;

                        var result = parseFloat(hdnTotalPrice - hdnWalletBalance);

                        $("#lblRemainPaymentMsg")
                        setPaymentPrice = result.toFixed(2);
                        $("#totalPayable").html(setPaymentPrice);

                        $("#lblUpdatedWallet").html("0.00").show();
                    }
                    $("#updatedWallet").show();
                    $("#walletBalance").show();
                }
                else {

                    isFullCreditCardPayment = true;
                    isPartialWalletPayment = false;

                    $("#totalPayable").html(hdnTotalPrice);
                    $("#updatedWallet").hide();
                    $("#walletBalance").hide();

                    $("#txtccNumber").prop('disabled', false);
                    $("#txtExpDate").prop('disabled', false);
                    $("#txtSecurityCode").prop('disabled', false);
                }
            });

            //set credit card image
            $(".cc-number").keyup(function (e) {

                if ($(".cc-number").val().length <= 2) {
                    $('.ccImage').css('background-image', 'none');
                    $("#txtSecurityCode").attr("placeholder", "•••");
                    return;
                }

                var cardType = $.payment.cardType($('.cc-number').val());

                switch (cardType) {
                    case 'visa':
                        $('.ccImage').css('background-image', 'url(../Images/Payment-Visa-card.png)');                        
                        break;
                    case 'amex':
                        $('.ccImage').css('background-image', 'url(../Images/Payment-AmericanExpress-Card.png)');
                        $("#txtSecurityCode").attr("placeholder", "••••");
                        break;
                    case 'discover':
                        $('.ccImage').css('background-image', 'url(../Images/Payment-Discover-Card.png)');                        
                        break;
                    case 'jcb':
                        $('.ccImage').css('background-image', 'url(../Images/Payment-JCB-Card.png)');                        
                        break;
                    case 'mastercard':
                        $('.ccImage').css('background-image', 'url(../Images/Payment-Master-Card.png)');                        
                        break;
                    case 'dinersclub':
                        $('.ccImage').css('background-image', 'url(../Images/Payment-DinersClub-Card.png)');                        
                        break;
                    case 'maestro':
                        $('.ccImage').css('background-image', 'url(../Images/Payment-Maestro-Card.png)');                        
                        break;
                    case 'dankort':
                        $('.ccImage').css('background-image', 'url(../Images/Dankort.png)');                        
                        break;
                }
            });

            $("#txtccNumber").keyup(function () {
                $("#cardNumber").hide();
            });

            $("#txtExpDate").keyup(function () {
                $("#cardExpire").hide();
            });

            $("#txtSecurityCode").keyup(function () {
                $("#cardCvv").hide();
            });

            $('#chkFirstTerm').change(function () {
                $("#chkboxerror").hide();
            });

            $('#chkSecondTerm').change(function () {
                $("#chkboxerror").hide();
            });

            $('#chkThirdTerm').change(function () {
                $("#chkboxerror").hide();
            });

            $('.cc-number').payment('formatCardNumber');
            $('.cc-exp').payment('formatCardExpiry');
            $('.cc-cvc').payment('formatCardCVC');

            $.fn.toggleInputError = function (erred) {
                this.parent('.form-group').toggleClass('has-error', erred);
                return this;
            };

            $('#btnMakePayment').click(function (e) {

                e.preventDefault();
                var isValidPage = false;

                if (!isFullWalletPayment) {

                    isValidPage = $.payment.validateCardNumber($('.cc-number').val());

                    if (!isValidPage) {
                        $("#txtccNumber").focus();
                        $("#cardNumber").html("Please enter valid card number.");

                        $("#cardExpire").hide();
                        $("#cardCvv").hide();

                        $("#cardNumber").show();
                        return
                    }
                    $("#cardNumber").hide();

                    isValidPage = $.payment.validateCardExpiry($('.cc-exp').payment('cardExpiryVal'));

                    if (!isValidPage) {
                        $("#txtExpDate").focus();
                        $("#cardExpire").html("Please enter a valid Expiry Date");

                        $("#cardNumber").hide();
                        $("#cardCvv").hide();
                        $("#cardExpire").show();
                        return
                    }
                    $("#cardExpire").hide();

                    var cardType = $.payment.cardType($('.cc-number').val());

                    isValidPage = $.payment.validateCardCVC($('.cc-cvc').val(), cardType)

                    if (!isValidPage) {
                        $("#txtSecurityCode").focus();
                        $("#cardCvv").html("Please enter valid Security code number");

                        $("#cardNumber").hide();
                        $("#cardExpire").hide();
                        $("#cardCvv").show();
                        return;
                    }
                    $("#cardCvv").hide();
                }

                if (!$("#chkFirstTerm").prop("checked") || !$("#chkSecondTerm").prop("checked") || !$("#chkThirdTerm").prop("checked")) {
                    isValidPage = false
                    $("#chkboxerror").html("Please Accept all Terms and Conditions");

                    $("#cardNumber").hide();
                    $("#cardExpire").hide();
                    $("#cardCvv").hide();
                    $("#chkboxerror").show();
                    return;
                }
                $("#chkboxerror").hide();
                isValidPage = true;


                $('.cc-number').toggleInputError(!$.payment.validateCardNumber($('.cc-number').val()));
                $('.cc-exp').toggleInputError(!$.payment.validateCardExpiry($('.cc-exp').payment('cardExpiryVal')));
                $('.cc-cvc').toggleInputError(!$.payment.validateCardCVC($('.cc-cvc').val(), cardType));
                $('.cc-brand').text(cardType);

                $('.validation').removeClass('text-danger text-success');
                $('.validation').addClass($('.has-error').length ? 'text-danger' : 'text-success');

                //check all payment validation is success or not
                if ($('.has-error').length == 0 && isValidPage) {
                    $("#overlay").show();

                    var expireFields = $('input.cc-exp').payment('cardExpiryVal');
                    var cardType = $.payment.cardType($('.cc-number').val());

                    var creditCardModel = null;
                    var orderDetailModel = null;
                    var PaymentResponseModal = null;
                    var finalWalletPrice = 0;

                    if (isFullWalletPayment) {

                        finalWalletPrice = hdnTotalPrice.toFixed(2);

                        creditCardModel = {};

                        orderDetailModel = { "OrderTotal": $("#hdnPrice").val(), "WalletPrice": finalWalletPrice };

                        PaymentResponseModal = {}
                    }
                    else if (isFullCreditCardPayment || isPartialWalletPayment) {

                        creditCardModel = {
                            "CardType": cardType.toUpperCase(),
                            "CardNumber": $("#txtccNumber").val().replace(/\s/g, ''),
                            "ExpMonth": expireFields.month,
                            "ExpYear": expireFields.year,
                            "SecurityCode": $("#txtSecurityCode").val()
                        };

                        orderDetailModel = { "OrderTotal": $("#hdnPrice").val(), "TotalOrder": setPaymentPrice, "WalletPrice": hdnWalletBalance };

                        PaymentResponseModal = {}
                    }

                    var paymentModel = {
                        "paymentModel": {
                            "IsFullCreditCardPayment": isFullCreditCardPayment,
                            "IsPartialWalletPayment": isPartialWalletPayment,
                            "IsFullWalletPayment": isFullWalletPayment,
                            "CreditCardModel": creditCardModel,
                            "OrderDetailModel": orderDetailModel,
                            "PaymentResponseModal": PaymentResponseModal
                        }
                    };

                    $.ajax({
                        type: "POST",
                        url: "RequesterPayment.aspx/RequesterMakePayment",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(paymentModel),
                        dataType: "json",
                        async: true,
                        success: function (result) {                            
                            $("#overlay").hide();
                            window.scrollTo(0, 0);
                            if (result.d.IsError) {
                                

                                if (result.d.ErrorMessage != '' || result.d.ErrorMessage.length != 0) {
                                    $("#errorMessage").fadeIn();
                                    $("#errorMessage").animate({ top: '90px' }, "slow");

                                    $("#ErrorDescription").text(result.d.ErrorMessage);
                                    $("#errorMessage").fadeOut(10000);
                                }
                            }
                            else {
                                isPaymentReceived = true;
                                $("#errorMessage").fadeIn();
                                $("#errorMessage").animate({ top: '90px' }, "slow");

                                $("#ErrorDescription").text("Thank you for placing your order, you will get redirected to new page shortly");
                                //$("#errorMessage").fadeOut(10000);
                                setTimeout(function () {
                                    window.location.href = "../Pages/RequesterCandidate.aspx";
                                }, 3000);
                            }
                        }
                    });
                }
            });
        });
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hdnTotalPrice" runat="server" />
    <asp:HiddenField ID="hdnWalletBalance" runat="server" />
    <asp:HiddenField ID="hdnPrice" runat="server" />
    <asp:HiddenField ID="hdnIsPostback" runat="server" />

    <div class="eknowid-bg">
        <div class="container">
            <div class="row" style="margin-top: 115px; margin-left: 25px">

                <div class="row" style="margin-left: 10px; margin-right: 20px; margin-bottom: 60px;">
                    <ProgressBar:ProgressBar ID="progressBarRequestPayment" runat="server" />
                    <div class="col-lg-7 col-sm-12 col-xs-12 margin-top-80px">

                        <div class="payment" style="padding-left: 25px; padding-right: 25px;">

                            <div class="row">
                                <div class="col-md-12">
                                    <div style="font-size: 17px;">
                                        <span>
                                            <asp:CheckBox ID="chkWallet" runat="server" ViewStateMode="Disabled" />
                                            <label for="chkWallet" id="lblTitle"></label>
                                            <span style="margin-left: 10px;">Use Your Wallet ($<asp:Label ID="lblWalletBalance" runat="server"></asp:Label>)</span>
                                            <span><a href="AboutWallet.aspx" target="_blank">Read More ?</a></span>
                                        </span>
                                        <span class="pull-right" id="updatedWallet">Updated Wallet Balance ($<asp:Label ID="lblUpdatedWallet" runat="server"></asp:Label>)</span>
                                    </div>
                                    <div id="PaymentMsgContainer">You have to pay $(<asp:Label ID="lblRemainPaymentMsg" runat="server"></asp:Label>) by using credit card.</div>
                                </div>
                            </div>


                            <div class="row" style="margin-top: 25px; margin-left: -25px; margin-right: -25px;">
                                <div class="col-lg-12">
                                    <div style="border-bottom: 1px solid #e0e0e0">
                                    </div>
                                </div>
                            </div>

                            <div class="row" style="margin-top: 20px;">
                                <div class="col-md-6">
                                    <label class="control-label">Card Number</label>
                                </div>
                                <div class="col-md-3">
                                    <label class="control-label">Expiry Date</label>
                                </div>
                                <div class="col-md-3">
                                    <label class="control-label">Security Code</label>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <asp:TextBox
                                        ID="txtccNumber"
                                        runat="server"
                                        CssClass="input-lg form-control cc-number text-height text-width-230px  ccImage"
                                        placeHolder="•••• •••• •••• ••••">
                                    </asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <asp:TextBox
                                        ID="txtExpDate"
                                        runat="server"
                                        CssClass="input-lg form-control cc-exp text-height text-width"
                                        placeholder="•• / ••••">
                                    </asp:TextBox>
                                </div>


                                <div class="col-md-3">
                                    <asp:TextBox ID="txtSecurityCode"
                                        CssClass="form-control input-lg digitsOnly cc-cvc text-height"
                                        runat="server" TextMode="Password"
                                        placeholder="•••">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div style="margin-top: 10px;">
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <span id="cardNumber" class="card-error"></span>
                                    <span id="cardExpire" class="card-error"></span>
                                    <span id="cardCvv" class="card-error"></span>
                                </div>
                            </div>

                            <div class="row" style="margin-top: 15px; margin-left: -25px; margin-right: -25px;">
                                <div class="col-lg-12">
                                    <div style="border-bottom: 1px solid #e0e0e0">
                                    </div>
                                </div>
                            </div>

                            <div style="margin-top: 30px;"></div>

                            <div class="row">
                                <div class="col-lg-1 margin-top--1px">
                                    <asp:CheckBox ID="chkFirstTerm" runat="server" />
                                </div>

                                <div class="col-lg-10 font-size-15px margin-left--20px">

                                    <span>I agree to the 
                                    <span class="term-use"><b><a href="TermsofUse.aspx" target="_blank" style="text-decoration: none; color: #38b6e7">Terms of Use</a></b></span>
                                        and 
                                    <span class="term-use"><b><a href="PrivacyPolicy.aspx" target="_blank" style="text-decoration: none; color: #38b6e7">Privacy Policy.</a></b></span></span>
                                </div>

                            </div>

                            <div style="margin-top: 15px;"></div>

                            <div class="row">
                                <div class="col-lg-1 margin-top--1px">
                                    <asp:CheckBox ID="chkSecondTerm" runat="server" />
                                </div>


                                <div class="col-lg-10 font-size-15px margin-left--20px">
                                    I am requesting a background report for the permissible purpose of employment screening.<br />
                                    <div style="margin-bottom: 15px;"></div>

                                    I will abide by the 
                                    <span class="term-use"><b><a href="https://docs.google.com/document/d/1Yn_FsaZGuax-jrzQEzHLj-zp3zvJS-toULOtvCjVCWo/pub" target="_blank">Notice of Users of Consumer Reports: Obligations of Users Under the FCRA.</a></b></span>
                                    <br />
                                    <div style="margin-bottom: 15px;"></div>
                                    I understand that obtaining information on a consumer from a consumer reporting agency under false pretenses may 
                                    lead to fines and imprisonment under title 18 , United State Code.
                            
                                </div>
                            </div>
                            <div style="margin-top: 15px;"></div>

                            <div class="row">
                                <div class="col-lg-1 margin-top--1px">
                                    <asp:CheckBox ID="chkThirdTerm" runat="server" ClientIDMode="Static" />
                                </div>

                                <div class="col-lg-10 font-size-15px margin-left--20px">
                                    I have <span class="term-use"><b><a href="https://docs.google.com/document/d/1Cb1xFH3SrMJfoZcBXoZGrpOzI04XCEVRHjwp1kHgU7E/pub" target="_blank">consent</a></b></span>
                                    or will obtain consent from the candidate to run this report.<br />
                                    <div style="margin-bottom: 15px;"></div>
                                    I will provide candidates with 
                                    <span class="term-use"><b><a href="http://files.consumerfinance.gov/f/201504_cfpb_summary_your-rights-under-fcra.pdf" target="_blank">Summary Of Your Rights Under the Fair Credit Reporting Act.</a></b></span>

                                </div>

                            </div>


                            <div class="checkbox">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <span id="chkboxerror" class="card-error"></span>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div style="margin-top: 15px;">
                                <input type="button" id="btnMakePayment" value="Place Order" class="btn btn-default btn-place-order pull-left" style="width: 180px; height: 40px; font-size: 17px; box-shadow: 1px 1px 1px 1px #777777; letter-spacing: normal" />
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-1"></div>
                    <div class="col-lg-4  col-sm-12  col-xs-12">
                        <div class="row">

                            <div class="col-lg-12">
                                <div class="payment-summary-box">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="heading">Payment Summary</div>
                                        </div>
                                    </div>
                                    <ul class="payment-summary-list">
                                        <li>Report Total<span class="pull-right">$<asp:Label ID="lblPrice" runat="server"></asp:Label></span></li>
                                        <li id="walletBalance">Wallet Balance <span class="pull-right">- $<span id="walletBalanceSummary"></span></span></li>
                                        <li class="last-child">Total Due<span class="pull-right">$<span id="totalPayable"></span> </span></li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-lg-12">
                                <div class="hire_box">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="heading">Hire With Confidence</div>
                                        </div>
                                    </div>
                                    <ul class="list_1">
                                        <li>
                                            <img src="../Images/payment-icon1.png" />
                                            <span>100% Money Back Guarantee</span></li>
                                        <li>
                                            <img src="../Images/payment-icon2.png" />
                                            <span>Data Protected By SSL Encryption</span></li>
                                        <li>
                                            <img src="../Images/payment-icon3.png" />
                                            <span>Better Business Bureau Accredited</span></li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-lg-12">
                                <div class="order_summary_Final">
                                    <div class="order_summary_title">
                                        <div class="pull-left heading">
                                            <asp:Label ID="lblPlanName" runat="server"></asp:Label>
                                            Plan
                                        </div>
                                    </div>
                                    <div class="col-xs-12">
                                        <div class="order_summary_desc">
                                            <div class="clearfix"></div>
                                            <p>Report Included</p>
                                        </div>
                                    </div>


                                    <ul class="list_2">
                                        <asp:Repeater ID="rptrPlnRprts" runat="server">
                                            <ItemTemplate>
                                                <li><%# Container.DataItem.ToString() %></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>

                                    <%--<div class="order_summary_tot">
                                        <div class="col-xs-12">
                                            <div class="pull-left total" style="background-color: #ebebeb !important">
                                                total
                                            </div>
                                            <div class="pull-right total" style="background-color: #ebebeb !important">
                                                $<asp:Label ID="lblPrice" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdnPrice" runat="server" />
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                            <div class="col-xs-12">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
