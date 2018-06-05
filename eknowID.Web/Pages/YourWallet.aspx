<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="YourWallet.aspx.cs" Inherits="eknowID.Pages.YourWallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/bootbox.min.js"></script>
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

            //initially reset the value for textbox.
            $("#txtccNumber").val("");
            $("#txtExpDate").val("");
            $("#txtSecurityCode").val("");
            $("#txtWalletAmount").val("");


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

                if ($("#hdnUserType").val() === "SUPER_ADMIN") {
                    bootbox.confirm({
                        message: "Select a payment method",
                        className: "bootBoxModal",
                        buttons: {
                            confirm: {
                                label: 'Offer/Gift Credit',
                                className: 'btn-danger',
                                background: '#fb5240'
                            },
                            cancel: {
                                label: 'Credit/Debit Card',
                                className: 'btn-danger',
                                background: '#fb5240'
                            }
                        },
                        callback: function (result) {
                            if (result) {
                                bootbox.confirm({
                                    message: "Are you sure you want to add a credit of <strong>$" + $("#txtWalletAmount").val() + " </strong>to <strong>" + $("#ddlUsers").find("option:selected").text() + " </strong>Wallet?<br/><br/>" +
                                        "<strong>Transaction Remark : </strong><input id='walletTxnremark' type='text' style='width:60%; height: 30px; border-radius: 5px; padding-left: 15px;' placeholder=' Please enter note/remark for this transaction...'/>",
                                    className: "bootBoxModal",
                                    buttons: {
                                        confirm: {
                                            label: 'Yes',
                                            className: 'btn-success'                                            
                                        },
                                        cancel: {
                                            label: 'No',
                                            className: 'btn-danger',
                                            background: '#fb5240'
                                        }
                                    },
                                    callback: function (result) {                                        
                                        if (result) {                                            
                                            var note = 0 < $(this).find("#walletTxnremark").length ? $(this).find("#walletTxnremark").val() : "";
                                            var controlData = "userId:'" + $("#ddlUsers").val() + "', amount:'" + $("#txtWalletAmount").val() + "', note:'" + note + "'";
                                            $.ajax({
                                                type: "POST",
                                                url: "YourWallet.aspx/AddMoneyToUsersWallet",
                                                contentType: "application/json; charset=utf-8",
                                                data: "{" + controlData + "}",
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
                                        else {
                                            $("#pnlWalletPayment").hide();
                                        }
                                    }
                                });
                            }
                            else {
                $("#pnlWalletPayment").show();
                            }
                        }
                    });
                }
                else {
                    $("#pnlWalletPayment").show();
                }

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
                    $("#cardExpire").html("Please enter a valid Expiry Date");
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
                        url: "YourWallet.aspx/RequesterMakePayment",
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
            $("#ddlUsers").change(function(){               
                var selecteUserId = parseInt($("#ddlUsers").val());
                var url = window.location.href;
                if (url.indexOf('?') > -1) {
                    url = String(window.location.href).substring(0, url.indexOf('?'));
                }                
                window.location.href = url + "?user_Id=" + selecteUserId;
            });
            //$("#ddlUsers").val($("#hdnUserId").val());
        });

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" runat="server" id="hdnUserId" ClientIDMode="Static"/>
    <asp:HiddenField ID="hdnUserType" runat="server" ClientIDMode="Static" />
    <section class="eknowid-bg">
        <div class="container-fluid addMoney">
            <div class="row divPayment ">
                <div class="col-lg-2">
                    <img src="../Images/Finance-Wallet-icon.png" width="50" />
                    <span><b>$<asp:Label ID="lblWalletBalance" runat="server"></asp:Label></b></span>
                </div>
                <div class="col-lg-4 walletAmountClass">
                    <div id="selectWalletUsers" clientidmode="Static" runat="server">
                        <strong>Select User</strong>&nbsp;&nbsp;                   
                    <asp:DropDownList ID="ddlUsers" runat="server" CssClass="SearchByRef_SelectProfDropDown"
                        ClientIDMode="Static" AutoPostBack="False">
                    </asp:DropDownList>
                    </div>                   
                </div>
                <div class="col-lg-3 walletAmountClass payment-text-height">
                    <asp:TextBox ID="txtWalletAmount" runat="server" MaxLength="6" Placeholder="Enter Amount to be Added in Wallet" CssClass="form-control text-width-230px digitsOnly wallet-text-height" required></asp:TextBox>
                </div>
                <div class="col-lg-3 walletAmountClass">
                    <input type="button" id="btnAddWalletMoney" class="btn btn-default btn-wallet btnCancelContinue" value="Add Money to Wallet" />
                </div>
                <div class="row errorMsg" style="padding-top: 5px; padding-left: 62%;">
                    <span id="walletamountError" class="Error"></span>
                </div>
            </div>
        </div>
        <%--<% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN) { %>

        <% } %>--%>
        <asp:Panel ID="pnlWalletPayment" CssClass="cardDetails" runat="server">
            <div class="container-fluid">
                <div class="row paymentHeading">
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-md-4" style="width: 25%">
                                <label class="control-label">Card Number</label>
                            </div>
                            <div class="col-md-4" style="width: 12.5%;">
                                <label class="control-label">Expiry Date</label>
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
                                            <th>Deposited</th>
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
