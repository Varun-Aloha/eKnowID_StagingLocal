var startYearEdu = [];
var endYearEdu = [];
var startYearPost = [];
var endYearPost = [];

//function ValidateEducationDetails() {

//    var errorMessage = "Please check the following things :<br/><br/>";    

//    if (!($("#txtBasic").valid())) {
//        errorMessage = errorMessage + "- Please enter basic graduation.<br/>";
//    }
//    if (!($("#txtSpecialization").valid())) {
//        errorMessage = errorMessage + "- Please enter specialization for basic graduation.<br/>";
//    }
//    if (!($("#txtUniversity").valid())) {
//        errorMessage = errorMessage + "- Please enter university for basic graduation.<br/>";
//    }
//    if (!($("#txtMunicipality").valid())) {
//        errorMessage = errorMessage + "- Please enter valid municipality for basic graduation.<br/>";
//    }
//    if (!($("#txtStartDate").valid())) {
//        errorMessage = errorMessage + "- Please enter valid start date for basic graduation.<br/>";
//        $("#txtStartDate").val('');
//    }
//    if (!($("#txtEndDate").valid())) {
//        errorMessage = errorMessage + "- Please enter valid end date for basic graduation, must be greater than start date.<br/>";
//        $("#txtEndDate").val('');
//    }
//    if (!($("#ddlStateEducational select").valid())) {
//        errorMessage = errorMessage + "- Please select state for basic graduation.<br/>";
//    }


//    var postGraduationdiv = document.getElementById("Post").style.display;

//    if (postGraduationdiv == "block") {

//        if (!($("#txtPostGraduation").valid())) {
//            errorMessage = errorMessage + "- Please enter post graduation.<br/>";
//        }
//        if (!($("#txtPostSpecialization").valid())) {
//            errorMessage = errorMessage + "- Please enter specialization for post graduation.<br/>";
//        }
//        if (!($("#txtPostUniversity").valid())) {
//            errorMessage = errorMessage + "- Please enter university for post graduation.<br/>";
//        }
//        if (!($("#txtPostMuncipality").valid())) {
//            errorMessage = errorMessage + "- Please enter municipality for post graduation.<br/>";
//        }
//        if (!($("#ddlStatePostGraduation select").valid())) {
//            errorMessage = errorMessage + "- Please select state for post graduation.<br/>";
//        }
//        if (!($("#txtPostStartDate").valid())) {
//            errorMessage = errorMessage + "- Please enter valid start date for post graduation.<br/>";
//            $("#txtPostStartDate").val('');
//        }
//        if (!($("#txtPostEndDate").valid())) {
//            errorMessage = errorMessage + "- Please enter valid end date for post graduation, must be greater than start date.<br/>";
//            $("#txtPostEndDate").val('');
//        }        
//    }

//    OpenDialog(errorMessage, function () {
//        $('div#EducationInfoContainer input[type="text"].error,select.error').first().focus();
//    });   
//}



function ValidateEducationDetails() {

    if (!($("#mstrPage").valid())) {


        var errorMessage = "Please fill mandatory information to continue.";

        if (!($("#ddlYearStart select").valid())) {
            if ($("#ddlYearStart select").val() != 0) {
                errorMessage = "Please enter valid start date must be less than today's date.";
                ShowEducationPopup(errorMessage);
                return false;
            }
        }


        if (($("#ddlMonthEnd").val() > 0) || ($("#ddlYearEnd").val() > 0)) {

            if ($("#ddlYearEnd select").val() < $("#ddlYearStart select").val()) {
                errorMessage = "Please enter valid end date, must be greater than start date.";
                ShowEducationPopup(errorMessage);
                return false;

            }
            else if ($("#ddlYearEnd select").val() == $("#ddlYearStart select").val()) {
                if ($("#ddlMonthEnd").val() < $("#ddlMonthStart").val()) {
                    errorMessage = "Please enter valid end date must be greater than start date.";
                    ShowEducationPopup(errorMessage);
                    return false;
                }
            }
        }

        var postGraduationdiv = document.getElementById("Post").style.display;

        if (postGraduationdiv == "block") {


            if (!($("#ddlPostYearStart select").valid())) {
                if ($("#ddlPostYearStart select").val() != 0) {
                    errorMessage = "Please enter valid start date for post graduation must be less than today's date.";
                    ShowEducationPopup(errorMessage);
                    return false;
                }
            }

            if (($("#ddlPostMonthEnd").val() > 0) || ($("#ddlPostYearEnd select").val() > 0)) {

                if ($("#ddlPostYearEnd select").val() < $("#ddlPostYearStart select").val()) {

                    errorMessage = "Please enter valid end date, must be greater than start date";
                    ShowEducationPopup(errorMessage);
                    return false;

                }
                else if ($("#ddlPostYearEnd select").val() == $("#ddlPostYearStart select").val()) {
                    if ($("#ddlPostMonthEnd").val() < $("#ddlPostMonthStart").val()) {
                        errorMessage = "Please enter valid end date must be greater than start dat month";
                    }
                }
            }
        }

        ShowEducationPopup(errorMessage);

    }
}

function ShowEducationPopup(errorMessage) {

    OpenDialog(errorMessage, function () {
        $('div#EducationInfoContainer input[type="text"].error,select.error').first().focus();
    });
}

function SetEducationsDetails() {

    $("#ddlYearStart select").val(startYearEdu[0]);
    $("#ddlYearEnd select").val(endYearEdu[0]);

    $("#ddlPostYearStart select").val(startYearPost[0]);
    $("#ddlPostYearEnd select").val(endYearPost[0]);

}

function SetPostGraduationDetails() {
    $("#ddlPostYearStart select").val(startYearPost[0]);

    $("#ddlPostYearEnd select").val(endYearPost[0]);

}