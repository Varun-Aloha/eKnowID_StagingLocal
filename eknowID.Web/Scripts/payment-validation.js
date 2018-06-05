
//prevent back
//$(document).ready(function () {
//    function disableBack() { window.history.forward() }

//    window.onload = disableBack();
//    window.onpageshow = function (evt) { if (evt.persisted) disableBack() }
//});

//function preventBack() {
//    window.history.forward();
//}
//setTimeout("preventBack()", 0);
//window.onunload = function () { null };


//prevent enter character in textbox
$(function () {
    $('.digitsOnly').bind('input', function () {
        var totalCharacterCount = $(this).val();
        var regExp = /^[a-zA-Z ]*$/;
        if (isNaN(totalCharacterCount)) {
            $(this).val('');
        }
    });
});

//check for postback validation like payment filed to display proper error message
var cardTypeSelectFlag, monthSelectFlag, yearSelectFlag;
cardTypeSelectFlag = monthSelectFlag = yearSelectFlag = false;

var expDateFlag, creditCardFlag;
expDateFlag = creditCardFlag = false;

$(function () {
    //check creditCard number is valid or not
    $("#CardNumber").blur(function () {
        var creditCardRegex = '^4[0-9]{12}(?:[0-9]{3})?$';
        var masterCard = '^5[1-5][0-9]{14}$';
        var discover = '^6(?:011|5[0-9]{2})[0-9]{12}$';
        var americanExpress = '^3[47][0-9]{13}$';

        var cardNumber = $("#CardNumber").val();

        if (!((cardNumber.match(creditCardRegex)) || (cardNumber.match(masterCard)) || (cardNumber.match(discover)) || (cardNumber.match(americanExpress)))) {
            creditCardFlag = false;
        }
        else
            creditCardFlag = true;
    });
    $("#ExpMonth").change(function () {
        if ($("#ExpMonth").val() != null && $("#ExpYear").val() != null) {
            var selectedDate = new Date($("#ExpYear").val(), $("#ExpMonth").val());

            var today = new Date();
            if (today > selectedDate) {
                expDateFlag = false;
            }
            else {
                expDateFlag = true;
            }
        }
    });
    $("#ExpYear").change(function () {
        if ($("#ExpMonth").val() != null && $("#ExpYear").val() != null) {
            var selectedDate = new Date($("#ExpYear").val(), $("#ExpMonth").val());
            var today = new Date();
            if (today > selectedDate) {
                expDateFlag = false;
            }
            else {
                expDateFlag = true;
            }
        }
    });

    //hide error message when user is select field again
    $("#CardType").change(function () {
        cardTypeSelectFlag = true;
        $("#cardTypeError").hide();
    });

    $("#ExpMonth").change(function () {
        monthSelectFlag = true;
        $("#monthError").hide();
    });

    $("#ExpYear").change(function () {
        yearSelectFlag = true;
        $("#yearError").hide();
    });

    $("#CardNumber").keydown(function () {
        $("#cardNumberError").hide();
    });

    $("#SecurityCode").keydown(function () {
        $("#card-error").hide();
        $("#securityError").hide();
    });

    $("#CardType").change(function () {
        $("#card-error").hide();
    });
    $("#CardNumber").keydown(function () {
        $("#card-error").hide();
    });

    //check for cardtype and cardnumber is valid or not
    $("#CardType").change(function () {
        $("#card-error").hide();
    });
    $("#CardNumber").change(function () {
        $("#card-error").hide();
    });
});
function checkCvvIsValidOrNot() {
    var cardType = $('#CardType').val();
    var CvvNumber = $('#SecurityCode').val();

    if ($('#SecurityCode').val().length < 3) {
        $("#card-error").show();
    }
    else {
        if ((CvvNumber.length == 3) && ((cardType == 'VISA') || (cardType == 'MASTERCARD') || (cardType == 'DISCOVER'))) {
            return true;
        }
        else if (CvvNumber.length == 4 && cardType == 'AMEX') {
            return true;
        }
        $("#card-error").html("Does not match card type and Security Code.");
        $("#card-error").show();
        return false;
    }
}

//hide when user is select field again.
function checkDropdownValidationMessageHidden() {
    if (cardTypeSelectFlag)
        $("#cardTypeError").hide();
    if (monthSelectFlag)
        $("#monthError").hide();

    if (yearSelectFlag)
        $("#yearError").hide();
}

//check cardnumber and cardtype is enter valid or not
function checkCardTypeAndNumber() {
    if ($("#CardNumber").val() == '' || $("#CardType").val() == '') {
        $("#card-error").hide();
    }
    else {
        if (!(checkCreditCard($("#CardNumber").val(), $("#CardType").val()))) {
            $("#card-error").html("Does not match card type and card number.please Select Valid");
            $("#card-error").show();
            return false;
        }
        else {
            $("#card-error").hide();
            if ($("#ExpMonth").val() != '' && $("#ExpYear").val() != '' && $("#SecurityCode").val() != '') {
                loading();
                return true;
            }
        }
    }
}

//check creditcard field is not empty when user is press paynow button
function checkFieldValidator() {
    if ($("#CardType").val() == '' || $("#CardType").val() == null) {
        $("#cardTypeError").html("The card type is required and can\'t be empty");
        $("#cardTypeError").show();
    }
    if ($("#CardNumber").val() == '' || $("#CardNumber").val() == null) {
        $("#cardNumberError").html("The card number is required and cannot be empty");
        $("#cardNumberError").show();

    }
    if ($("#ExpMonth").val() == '' || $("#ExpMonth").val() == null) {
        $("#monthError").html("The expire month is required and cannot be empty");
        $("#monthError").show();
    }
    if ($("#ExpYear").val() == '' || $("#ExpYear").val() == null) {
        $("#yearError").html("The expire year is required and cannot be empty");
        $("#yearError").show();
    }
    if ($("#SecurityCode").val() == '' || $("#SecurityCode").val() == null) {
        $("#securityError").html("The security code is required and cannot be empty");
        $("#securityError").show();
    }
}

//prevent referesh
var loading = function () {

    function disableF5(e) {
        if ((e.which || e.keyCode) == 116 || (e.which || e.keyCode) == 82) e.preventDefault();
    };
    $(document).on("keydown", disableF5);
};