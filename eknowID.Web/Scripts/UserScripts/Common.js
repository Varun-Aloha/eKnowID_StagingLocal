function OpenDialog(ErrorMessage, CallBackFunction) {

    $("#dialogMessageContainer").text("");
    $("#dialogMessageContainer").append(ErrorMessage)

    $('#dialog').bPopup({
        modalClose: false,
        follow: [false, false],
        onClose: CallBackFunction,
        opacity: 0.6,
        positionStyle: 'absolute'
    });

    $('#btnOk').focus();
}

function UpgradePackageDescriptionTextWrap(Jthis) {
    $(Jthis).closest(".divAlacartMain").find(".divReportDetails").toggleClass("less");
    if ($(Jthis).html() == "Read more...") {
        $(Jthis).html("Read less...");
    }
    else {
        $(Jthis).html("Read more...");
    }
}


function CloseDialog() {
    $('#dialog').bPopup().close();
}
function OpenProcessingImage(CallbackFunction) {
    $('#loading').bPopup({
        modalClose: false,
        escClose: false,
        onClose: CallbackFunction,
        opacity: 0.6,
        positionStyle: 'absolute'
    });
}
function CloseProcessingImage() {
    $('#loading').bPopup().close();
}
function CloseSingUp() {

    $.cookie('showUploadResumeDialog', 'false');
    $.cookie('redirectToOrderDetail', 'false');
    $('#signUpPopUp').bPopup().close();

    $("body").css("overflow", "scroll");
}
function CloseSingIn() {
    $.cookie('showUploadResumeDialog', 'false');
    $.cookie('redirectToOrderDetail', 'false');
    $('#signInPopUp').bPopup().close();
    $("body").css("overflow", "scroll");
}
$(function () {    
    $(document).keyup(function (e) {
        if (e.keyCode === 27) { // escape key maps to keycode 27
            $("body").css("overflow", "scroll");
        }
    });


    $('.digitsOnly').bind('input', function () {
        var totalCharacterCount = $(this).val();
        var regExp = /^[a-zA-Z ]*$/;
        if (isNaN(totalCharacterCount)) {
            $(this).val('');
        }
    });

    $(".digitsOnly").keypress(function (e) {

        //Allow user to press crtl+v
        if (e.ctrlKey && (e.which === 86 || e.which === 118)) {
            return true;
        }
        else {

            if (e.which !== 8 && e.which !== 0 && (e.which < 48 || e.which > 57)) {
                return false;
            }
        }
    });

    $(".charSpaceOnly").keypress(function (e) {
        if (e.which !== 8 && e.which !== 0) {
            var char = String.fromCharCode(e.which);
            var regExp = /^[a-zA-Z ]*$/;
            if (!regExp.test(char)) {
                return false;
            }
        }
    });

    $('.charSpaceOnly').bind('input', function () {
        var totalCharacterCount = $(this).val();
        var regExp = /^[a-zA-Z ]*$/;
        if (!regExp.test(totalCharacterCount)) {
            $(this).val('');
        }
    });

    $(".charOnly").keypress(function (e) {
        if (e.which !== 8 && e.which !== 0) {
            var char = String.fromCharCode(e.which);
            var regExp = /^[a-zA-Z]*$/;
            if (!regExp.test(char)) {
                return false;
            }
        }
    });

    $('.charOnly').bind('input', function () {
        var totalCharacterCount = $(this).val();
        var regExp = /^[a-zA-Z ]*$/;
        if (isNaN(totalCharacterCount)) {            
        }
        else {
            $(this).val('');
        }
    });

});

function ClearHistory(URL) {
    $.removeCookie('redirectToOrderDetail');
    $.removeCookie('showUploadResumeDialog');

    var backlen = history.length;
    history.go(-backlen);
    window.location.href = URL;
}