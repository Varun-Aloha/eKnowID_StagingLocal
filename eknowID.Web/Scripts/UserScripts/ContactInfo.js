var month = [];
var day = [];
var year = [];

function ValidateContactInfo(modelName) {

    var errorMessage = "Please fill mandatory information to continue.";

    if (!($('#txtCntFname').valid()) || !($('#txtCntLname').valid())) {
        ShowPopup(errorMessage);
        return false;
    }

    if ($("#txtCntMobile").val() != "" && $("#txtCntMobile").val().length != 10) {
        errorMessage = "Please enter valid mobile number.";

        ShowPopup(errorMessage);      
        return false;
    }
    if (modelName == 'orderDetail') {
    if (!($('#hdnSSN').valid())) {
        var ssn = $('#hdnSSN').val();

        if (ssn.length < 9 && ssn.length != 0) {
            errorMessage = "Please enter valid social security number(9 digits in length).";
        }

        ShowPopup(errorMessage);
        return false;
    }
    if (!($('#hdnConfirmSSN').valid()) && ($('#hdnSSN').valid())) {

        if ($('#hdnConfirmSSN').val().length > 0) {
            errorMessage = "Confirm social security number field does not match to the social security number field.";
        }

        ShowPopup(errorMessage);
        return false;
    }
    }
    if ($("#txtCntPassword").length > 0) {
        
        if (!($('#txtCntPassword').valid())) {

            if ($('#txtCntPassword').val().length < 6 && $('#txtCntPassword').val().length !=0) {
                errorMessage = "Please enter valid password(6-15 character in length).";
            }
            ShowPopup(errorMessage);
            return false;
        }

        if (!($('#txtCntConfirmPassword').valid()) && $('#txtCntPassword').valid()) {
            if ($('#txtCntConfirmPassword').val().length > 0) {
                errorMessage = "Please re-enter the correct password in the ‘Confirm Password’ field.";
            }
            ShowPopup(errorMessage);
            return false;
        }
    }
    ShowPopup(errorMessage);
    return false;
}

function ShowPopup(errorMessage) {

    OpenDialog(errorMessage, function () {
        var elementType = $('div#ContactInfoContainer input[type="text"].error,input[type="hidden"].error,input[type="password"].error,select.error').first().attr("type");
        if (elementType == "hidden") {
            var elementId = $('div#ContactInfoContainer input[type="text"].error,input[type="hidden"].error,input[type="password"].error,select.error').first().attr("id");
            if (elementId == "hdnSSN") {
                $("#hdnSSN").valid();
                $("#txtSecurity1").val("");
                $("#txtSecurity2").val("");
                $("#txtSecurity3").val("");
                $("#txtSecurity1").focus();
            }
            else if (elementId == "hdnConfirmSSN") {
                $("#hdnConfirmSSN").valid();
                $("#txtConfirmSecurity1").val("");
                $("#txtConfirmSecurity2").val("");
                $("#txtConfirmSecurity3").val("");
                $("#txtConfirmSecurity1").focus();
            }
        }
        else {
            $('div#ContactInfoContainer input[type="text"].error,input[type="password"].error,select.error').first().focus();
        }
    });
}

function SetContactDetails() {
    
    $("#dob select#month1").val(month[0]);

    $("#dob select#day").val(day[0]);

    $("#dob select#year").val(year[0]);

}