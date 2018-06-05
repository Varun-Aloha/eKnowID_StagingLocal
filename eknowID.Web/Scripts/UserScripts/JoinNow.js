var allowed = true;


function ValidateSignUp() {

    if (!($("#joinNowForm input.required").valid()) || !$('#chkAgree').is(':checked')) {

        var errorMessage = "Please fill mandatory information to continue."


        if (!($('#txtEmailAddress').valid())) {
            if ($("#txtEmailAddress").val().length > 0) {
                errorMessage = "Please enter valid email address to continue.";
            }
        }

        if (!($('#txtConfirmEmailAddress').valid()) && $('#txtEmailAddress').valid()) {
            if ($("#txtConfirmEmailAddress").val().length > 0) {
                errorMessage = "Confirm Email field does not match to the Email field.";
            }
        }

        if (!($('#txtPassword').valid()) && $('#txtConfirmEmailAddress').valid() && $('#txtEmailAddress').valid()) {
            if (($('#txtPassword').val().length < 6) && ($('#txtPassword').val().length != 0)) {
                errorMessage = "Please enter valid password(6-15 character in length).";
            }
        }

        if (!($('#txtConfirmPassword').valid()) && $('#txtPassword').valid() && $('#txtConfirmEmailAddress').valid() && $('#txtEmailAddress').valid()) {
            if ($('#txtConfirmPassword').val().length > 0) {
                errorMessage = "Please re-enter the correct password in the ‘Confirm Password’ field.";
            }
        }

        if (!$('#chkAgree').is(':checked') && $('#txtConfirmPassword').valid() && $('#txtPassword').valid() && $('#txtConfirmEmailAddress').valid() && $('#txtEmailAddress').valid()) {
            errorMessage = "Please accept Terms & Conditions.";
        }

        OpenDialog(errorMessage, function () {
            $('div#inputContainer input[type="text"].error,input[type="password"].error,select.error').first().focus();
        });

        return;
    }
    else {
        AddUser();
    }
}


function AddUser() {

    var URL = "loginajaxcalls.aspx/SignupUser"
    var URLCheckEmail = "loginajaxcalls.aspx/CheckIfExist";
    var ControlDataCheckEmail = "emailID:'" + $("#txtEmailAddress").val() + "'";


    var controlData = "FirstName:'" + $("#txtFirstName").val() + "'";
    controlData = controlData + ",MiddleName:'" + $("#txtMiddleName").val() + "'";
    controlData = controlData + ",LastName:'" + $("#txtLastName").val() + "'";
    controlData = controlData + ",EmailAddress:'" + $("#txtEmailAddress").val() + "'";
    controlData = controlData + ",Password:'" + $("#txtPassword").val() + "'";
    controlData = controlData + ",UserType: 2"; //UserType == 2 for Admin

    AjaxCallSingUp(URLCheckEmail, ControlDataCheckEmail, function (result) {
        res = result.d.Message;

        if (res == "Exist") {
            //$('#btnCreateAccount').removeAttr('disabled');
            OpenDialog("User already present with this mailID", function () { return; });
        }
        else {
            if (res == "Not Exist") {
                OpenProcessingImage();
                AjaxCallSingUp(URL, controlData, SingUpSuccess);
            }
        }
    });
}

function AjaxCallSingUp(URL, ControlData, SuccessFunction) {
    $.ajax({
        type: "POST",
        url: URL,
        contentType: "application/json; charset=utf-8",
        data: "{" + ControlData + "}",
        dataType: "json",
        success: SuccessFunction
    });
}

function SingUpSuccess(result) {
    CloseProcessingImage();
    $("#signUpPopUp").bPopup().close();
    if ($.cookie('showUploadResumeDialog') == "true" && $.cookie('redirectToOrderDetail') == "true") {
        window.location.href = "../Pages/OrderDetail.aspx";
    }
    else {
        window.location.href = "../Pages/UserProfile.aspx";
    }
}

$(function () {
    $(".validateSingUp").keydown(function (e) {
        if (!allowed) return;
        allowed = false;
        if (e.which == 13) {
            ValidateSignUp();
            e.preventDefault();
            return false;
        }
    });

    $(document).keyup(function (e) {
        allowed = true;
    });
    $(document).focus(function (e) {
        allowed = true;
    });
});