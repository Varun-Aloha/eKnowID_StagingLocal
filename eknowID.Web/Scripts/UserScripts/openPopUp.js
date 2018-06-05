function SignInDialog() {

    $("html, body").animate({ scrollTop: 0 }, "slow");


    $("#signUpPopUp").bPopup().close();
    $("body").css("overflow", "hidden");

    //$.cookie('showUploadResumeDialog', 'false');

    $("#txtEmail").val('');
    $("#txtPassword").val('');
    $("*[generated=true]").remove();
    $("#lblErrorSignIn").css("display", "none");

    $("#signInPopUp").bPopup({
        appendTo: 'form',
        modalClose: false,
        opacity: 0.6,
        positionStyle: 'fixed' //'fixed' or 'absolute'
    });

    $("#txtEmail").focus();
}

function SignUpDialog() {

    $("body").css("overflow", "hidden");

    $("#signInPopUp").bPopup().close();

    $.cookie('showUploadResumeDialog', 'true');


    $("#inputContainer input[type ='text'],input[type ='password'],select").val('');
    $('*[generated=true]').remove();

    $("#signUpPopUp").bPopup({
        appendTo: 'form',
        modalClose: false,
        opacity: 0.6,
        positionStyle: 'fixed'  //'fixed' or 'absolute'
    });

    $("#txtFirstName").focus();
    $("#pwdMeter").css("display", "none");
}

; (function ($) {

    // DOM Ready
    $(function () {

        // Binding a click event
        // From jQuery v.1.7.0 use .on() instead of .bind()
        $('.test').bind('click', function (e) {

            // Prevents the default action to be triggered. 
            e.preventDefault();
            //            // Close the SignIn popup if Open
            //         
            //            // Triggering bPopup when click event is fired
            $('#Panel1').bPopup({
                modalClose: false,
                opacity: 0.6,
                positionStyle: 'absolute'
            });

        });

    });
})(jQuery);


; (function ($) {

    // DOM Ready
    $(function () {

        // Binding a click event
        // From jQuery v.1.7.0 use .on() instead of .bind()
        $('.SearchByRefChosePlan_lnkViewReport').bind('click', function (e) {

            // Prevents the default action to be triggered. 
            e.preventDefault();
            //            // Close the SignIn popup if Open
            //         
            //            // Triggering bPopup when click event is fired
            $('#pnlViewReport').bPopup({
                modalClose: false,
                opacity: 0.6,
                positionStyle: 'absolute'
            });

        });

    });
})(jQuery);

function showPaymentSummary() {
    needToConfirm = false;
    $('#completePurchse').bPopup({
        follow: [false, false],
        modalClose: false,
        escClose: false,
        opacity: 0.6,
        positionStyle: 'absolute'
    });
    $(".CompletePurchase").focus();
}

function showPaymentErrorSummary() {
    needToConfirm = false;
    $('#completePurchseErrorPopup').bPopup({
        modalClose: false,
        escClose: false,
        opacity: 0.6,
        positionStyle: 'absolute'
    });
}

function OpenSampleReport() {
    $('#SampleReport').bPopup({
        modalClose: false,
        escClose: false,
        opacity: 0.6,
        positionStyle: 'absolute'
    });
}

//Show Forgot password popup
; (function ($) {

    // DOM Ready
    $(function () {

        // Binding a click event
        // From jQuery v.1.7.0 use .on() instead of .bind()
        $('.forgotPassword').bind('click', function (e) {

            // Prevents the default action to be triggered. 
            e.preventDefault();
            // Close the SignIn popup if Open

            $('#signInPopUp').bPopup().close();
            // Triggering bPopup when click event is fired
            $('#ForgotPwdPopup').bPopup({
                appendTo: 'form',
                modalClose: false,
                opacity: 0.6,
                positionStyle: 'absolute'
            });
            $('#txtEmailID').focus();
        });

    });
})(jQuery);
