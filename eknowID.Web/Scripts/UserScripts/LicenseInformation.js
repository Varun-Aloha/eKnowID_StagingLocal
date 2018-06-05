//function ValidateLicenseInfo() {

//    var errorMessage = "Please check the following things :<br/><br/>";

//    if (!($("#ddlStateLicenseInfo select").valid())) {
//        errorMessage = errorMessage + "- Please select state name.<br/>";
//    }

//    if (!($("#txtNumber").valid())) {

//        var licNumber = $("#txtNumber").val().trim();
//        if (licNumber != "") {
//            var specificError = $('#hdnErrorMessage').val();
//            if (specificError != "") {
//                errorMessage = errorMessage + "- " + specificError + "<br/>"
//            }
//            else {
//                errorMessage = errorMessage + "- Please enter license number.<br/>";
//            }
//        }
//        else {
//            errorMessage = errorMessage + "- Please enter license number.<br/>";
//        }
//    }
//    if (!($("#txtName").valid())) {
//        errorMessage = errorMessage + "- Please enter license name.<br/>";
//    }
//    //    if (!($("#txtAgency").valid())) {
//    //        errorMessage = errorMessage + "- Please enter licensing agency.<br/>";
//    //    }


//    OpenDialog(errorMessage, function () {
//        $('div#LicenseInfoContainer input[type="text"].error,select.error').first().focus();
//    });
//}

function ValidateLicenseInfo() {

    if (!($("#mstrPage").valid())) {
        var errorMessage = "Please fill mandatory information to continue.";


        if (!($("#txtNumber").valid()) && ($("#ddlStateLicenseInfo select").valid())) {

            var licNumber = $("#txtNumber").val().trim();
            if (licNumber != "") {
                var specificError = $('#hdnErrorMessage').val();
                if (specificError != "") {
                    errorMessage = specificError;
                }
            }           
        }

        OpenDialog(errorMessage, function () {
            $('div#LicenseInfoContainer input[type="text"].error,select.error').first().focus();
        });
    }
}

$(function () {
    $('#ddlStateLicenseInfo select').change(function () {
        //Clear error message dropdown changes
        $('#hdnErrorMessage').val('');
        CheckLicenseNumber();
    });
});


function CheckLicenseNumber() {
    var stateId = $('#ddlStateLicenseInfo select').val();

    if (stateId != 0) {

        $.ajax({
            type: "POST",
            url: "../Pages/orderHandling.aspx/GetRegularExpressionByStateId",
            contentType: "application/json; charset=utf-8",
            data: "{StateId:" + stateId + "}",
            dataType: "json",
            asyc: false,
            success: function (data) {
                //IsValidLicenseNumber(data.d.RegularExpression);  
                $('#hdnRegularExp').val(data.d.RegularExpression);
                $('#hdnIsSSN').val(data.d.IsSSN);
                $('#hdnIsLoggedIn').val(data.d.IsUserLoggedIn);
                $('#hdnSSN').val(data.d.SSN);
                $('#hdnErrorMessage').val(data.d.ErrorMessage);

                ValidateLicenseNumber(data.d.RegularExpression, data.d.IsSSN, data.d.IsUserLoggedIn, data.d.SSN);

                $('#txtNumber').bt(data.d.ErrorMessage.replace('<br/>&nbsp;',''), {
                    trigger: ['focus', 'blur'],
                    positions: ['right'],
                    fill: 'Gray'
                });
            }
        });
    }
    else {
        $('#txtNumber').removeClass('validLicenseNo');
        $('#txtNumber').bt("Please select the state.", {
            trigger: ['focus', 'blur'],
            positions: ['right'],
            fill: 'Gray'
        });
    }

}
function LicenseWrapper(regExpression, IsSSN, UserLoogedIn, SSN) {

    if (IsSSN == "True") {
        IsSSN = true;
    } else {
        IsSSN = false;
    }
    UserLoogedIn = true; 
    //ValidateLicenseNumber(regExpression, IsSSN, UserLoogedIn, SSN);    
}
function ValidateLicenseNumber(regExpression, IsSSN, UserLoogedIn, SSN) {

    $('#txtNumber').addClass('validLicenseNo');
    regExpression = new RegExp(regExpression, "i");
    //var IsSSN = data.d.IsSSN;
    //var UserLoogedIn = data.d.IsUserLoggedIn;
    var licenseNumber = $('#txtNumber').val();
    if (UserLoogedIn) {
        //var SSN = data.d.SSN;
        if (IsSSN) {
            var reg = /^(\d{9})$/;
            if (reg.test(licenseNumber)) {

                //Create Regular Expression for SSN number
                var regExpSSN = new RegExp(SSN, "i");
                //If there may SSN validation for License Number and License Number entered by user is 9 digits then Match License Number with SSN Number of the user
                jQuery.validator.addMethod("validLicenseNo", function (value, element) {
                    return this.optional(element) || regExpSSN.test(value);
                }, "*");
                $('#txtNumber').valid();

            }
            else {
                //jQuery.validator.addMethod("validLicenseNo", function (value, element) {
                //return this.optional(element) || regExpression.test(value);
                //}, "*");
                //$('#txtNumber').valid();
                ValidateWithOrignalExpression(regExpression);
            }

        }
        else {
            //If there is not need of SSN validation for License Number  then simply match the number with regular expression we have.
            //jQuery.validator.addMethod("validLicenseNo", function (value, element) {
            //return this.optional(element) || regExpression.test(value);
            //}, "*");
            //$('#txtNumber').valid();
            ValidateWithOrignalExpression(regExpression);
        }
    }
    else {
        //If user is not logged in then validate the License Number with regular expression we have
        //jQuery.validator.addMethod("validLicenseNo", function (value, element) {
        //return this.optional(element) || regExpression.test(value);
        //}, "*");
        //$('#txtNumber').valid();
        ValidateWithOrignalExpression(regExpression);
    }
}


function ValidateWithOrignalExpression(regExpression) {
    jQuery.validator.addMethod("validLicenseNo", function (value, element) {
        return this.optional(element) || regExpression.test(value);
    }, "*");
    $('#txtNumber').valid();
}

function CheckIfValid() {

    var regEx = $('#hdnRegularExp').val();
    var IsSSN = $('#hdnIsSSN').val();
    var IsLoggedIn = $('#hdnIsLoggedIn').val();
    var SSN = $('#hdnSSN').val();

    if (IsSSN == "True" || IsSSN == "true") {
        IsSSN = true;
    }
    else {
        IsSSN = false;
    }
    if (IsLoggedIn == "True" || IsLoggedIn == "true") {
        IsLoggedIn = true;
    }
    else {
        IsLoggedIn = false;
    }

    ValidateLicenseNumber(regEx, IsSSN, IsLoggedIn, SSN);
}