<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="EkentechWallet.aspx.cs" Inherits="eknowID.Pages.EkentechWallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../Scripts/jquery.payment.js"></script>

    <style type="text/css">
        .btn-wallet {
            background: #fb5240;
            text-transform: uppercase;
            font-weight: bold;
            letter-spacing: 2px;
            border: #fb5240 solid 2px;
            font-size: 13px;
            height: 42px;
            margin-top: -4px;
        }

        .btn-continue {
            height: auto !important;
            margin-top: 0px;
        }

        .wallet-text-height {
            height: 40px;
            margin: -3px 0 0 0;
        }

        .gridview-padding th, td {
            padding: 10px;
        }

        table.dataTable thead .sorting,
        table.dataTable thead .sorting_asc,
        table.dataTable thead .sorting_desc {
            background: none;
        }
    </style>

    <script type="text/javascript">

        $(function () {

            //bind jquery grid 
            $('#walletHistroyGrid').DataTable();

            $("#pnlWalletPayment").hide();

            $("#btnAddWalletMoney").click(function () {

                var addMoney = parseFloat($("#txtWalletAmount").val()).toFixed(2);

                if ($("#txtWalletAmount").val() == "") {

                    $("#walletamountError").html("Please enter amount to add.");
                    return;
                }

                else if (addMoney <= 0) {

                    $("#walletamountError").html("Please enter valid amount to add.");
                    return;
                }
                $("#pnlWalletPayment").show();
            });

            $("#btnWalletPaymentCancel").click(function () {
                $("#txtccNumber").val("");
                $("#txtExpDate").val("");
                $("#txtSecurityCode").val("");

                $("#pnlWalletPayment").hide();
            });

            //set credit card image
            $(".cc-number").keyup(function (e) {

                if ($(".cc-number").val().length <= 2) {
                    $('.ccImage').css('background-image', 'none');
                    return;
                }

                var cardType = $.payment.cardType($('.cc-number').val());

                switch (cardType) {
                    case 'visa':
                        $('.ccImage').css('background-image', 'url(../Images/Payment-Visa-card.png)');
                        break;
                    case 'amex':
                        $('.ccImage').css('background-image', 'url(../Images/Payment-AmericanExpress-Card.png)');
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


            $("#txtWalletAmount").keydown(function () {
                $("#walletamountError").html("");
            });

            $("#txtWalletAmount").keypress(function () {
                $("#walletamountError").html("");
            });

            $("#txtccNumber").keypress(function () {
                $("#cardNumber").hide();
            });

            $("#txtExpDate").keypress(function () {
                $("#cardExpire").hide();
            });

            $("#txtSecurityCode").keypress(function () {
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

            $('#btnWalletPayment').click(function (e) {

                e.preventDefault();
                var isValidPage = false;

                isValidPage = $.payment.validateCardNumber($('.cc-number').val());

                if (!isValidPage) {
                    $("#txtccNumber").focus();
                    $("#cardNumber").html("Please enter valid card number.");
                    $("#cardNumber").show();
                    return
                }
                $("#cardNumber").hide();

                isValidPage = $.payment.validateCardExpiry($('.cc-exp').payment('cardExpiryVal'));

                if (!isValidPage) {
                    $("#txtExpDate").focus();
                    $("#cardExpire").html("Please enter a valid Expire Date");
                    $("#cardExpire").show();
                    return
                }
                $("#cardExpire").hide();

                var cardType = $.payment.cardType($('.cc-number').val());

                isValidPage = $.payment.validateCardCVC($('.cc-cvc').val(), cardType)

                if (!isValidPage) {
                    $("#txtSecurityCode").focus();
                    $("#cardCvv").html("Please enter valid Security code number");
                    $("#cardCvv").show();
                    return;
                }
                $("#cardCvv").hide();
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

                    var creditCardModel = {
                        "CardType": cardType.toUpperCase(),
                        "CardNumber": $("#txtccNumber").val().replace(/\s/g, ''),
                        "ExpMonth": expireFields.month,
                        "ExpYear": expireFields.year,
                        "SecurityCode": $("#txtSecurityCode").val(),
                        "Amount": $("#txtWalletAmount").val()
                    };


                    var paymentWalletModal = {
                        "paymentWalletModal": creditCardModel
                    };

                    $.ajax({
                        type: "POST",
                        url: "EkentechWallet.aspx/RequesterMakePayment",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(paymentWalletModal),
                        dataType: "json",
                        async: true,
                        success: function (result) {

                            if (result.d.IsError) {
                                $("#overlay").hide();

                                if (result.d.ErrorMessage != '' || result.d.ErrorMessage.length != 0) {
                                    $("#errorMessage").fadeIn();
                                    $("#errorMessage").animate({ top: '75px' }, "slow");

                                    $("#ErrorDescription").text(result.d.ErrorMessage);
                                    $("#errorMessage").fadeOut(10000);
                                }
                            }
                            else {
                                window.location.reload();
                            }
                        }
                    });
                }
            });
        });

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="eknowid-bg">
        <div class="container-fluid addMoney">
            <div class="row divPayment ">
                <div class="col-lg-3">
                    <img src="http://icons.iconarchive.com/icons/icons8/ios7/256/Finance-Wallet-icon.png" width="50" />
                    <span><b>$<asp:Label ID="lblWalletBalance" runat="server"></asp:Label></b></span>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-4 walletAmountClass payment-text-height">
                    <asp:TextBox ID="txtWalletAmount" runat="server" MaxLength="6" Placeholder="Enter Amount to be Added in Wallet" CssClass="form-control text-width-230px digitsOnly wallet-text-height" required></asp:TextBox>
                </div>
                <div class="col-lg-4 walletAmountClass">
                    <input type="button" id="btnAddWalletMoney" class="btn btn-default btn-wallet btnCancelContinue" value="Add Money to Wallet" />
                </div>
                <div class="row errorMsg" style="padding-top: 5px;">
                    <span id="walletamountError" class="Error"></span>
                </div>
            </div>
        </div>

        <asp:Panel ID="pnlWalletPayment" CssClass="cardDetails" runat="server">
            <div class="container-fluid">
                <div class="row paymentHeading">
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-md-4" style="width: 25%">
                                <label class="control-label">Card Number</label>
                            </div>
                            <div class="col-md-4" style="width: 12.5%;">
                                <label class="control-label">Expire Date</label>
                            </div>
                            <div class="col-md-4">
                                <label class="control-label">Security Code</label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <asp:TextBox
                                    ID="txtccNumber"
                                    runat="server"
                                    CssClass="input-sm form-control cc-number text-width-230px  ccImage wallet-text-height"
                                    placeHolder="•••• •••• •••• ••••">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-3" style="width: 150px;">
                                <asp:TextBox
                                    ID="txtExpDate"
                                    runat="server"
                                    CssClass="input-sm form-control cc-exp text-width wallet-text-height"
                                    placeholder="•• / ••••">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-3" style="width: 150px;">
                                <asp:TextBox ID="txtSecurityCode"
                                    CssClass="form-control input-sm digitsOnly cc-cvc wallet-text-height"
                                    runat="server" TextMode="Password"
                                    placeholder="•••">
                                </asp:TextBox>
                            </div>
                            <div class="col-md-3 btnCancelContinue">
                                <input type="button" id="btnWalletPayment" value="Continue" class="btn btn-default btn-wallet btn-continue" />
                                <input type="button" id="btnWalletPaymentCancel" value="Cancel" class="btn btn-default cancelHover" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6" style="padding-top: 10px;">
                                <span id="cardNumber" class="card-error"></span>
                                <span id="cardExpire" class="card-error"></span>
                                <span id="cardCvv" class="card-error"></span>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </asp:Panel>

        <div class="container-fluid gridDiv">
            <div class="row">
                <div class="col-lg-12">
                    <div class="col-lg-12">

                        <asp:Repeater ID="rptWalletHistroy" runat="server">
                            <HeaderTemplate>
                                <table id="walletHistroyGrid" class="table table-striped table-bordered">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Transaction Id </th>
                                            <th>Deposite</th>
                                            <th>Withdrawal</th>
                                            <th>Transaction Date</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>

                            <ItemTemplate>
                                <tr>
                                    <td><%# Container.ItemIndex + 1 %> </td>
                                    <td><%# !string.IsNullOrEmpty(Convert.ToString(Eval("TransactionId"))) ? Eval("TransactionId") : "-"  %></td>
                                    <td><%# !string.IsNullOrEmpty(Eval("Deposite","{0:0.00}")) ? "$" + Eval("Deposite","{0:0.00}") : "-"  %></td>
                                    <td><%# !string.IsNullOrEmpty(Eval("Withdrawal","{0:0.00}")) ? "$" + Eval("Withdrawal","{0:0.00}") : "-"  %></td>
                                    <td><%# Eval("InsertedDate") %> </td>
                                </tr>

                            </ItemTemplate>

                            <FooterTemplate>
                                </tbody>
                            </table>
                            </FooterTemplate>
                        </asp:Repeater>

                    </div>
                </div>
            </div>
        </div>

    </section>

</asp:Content>
