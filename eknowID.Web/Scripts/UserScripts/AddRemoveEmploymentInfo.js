var empUniqueId = 2;
var empcounter = empUniqueId;

var empdetailsId = [];
var orgName = [];
var city = [];
var state = [];
var telephone = [];
//var numberMonths = [];

var PositionTitle = [];
var StartDt = [];
var EndDt = [];
var Descript = [];

var startMonth = [];
var startYear = [];
var endMonth = [];
var endYear = [];
var isAttending = [];

//var PositionInfoId = [];

function CreateEmpControl() {
    
    var copy = $("#original").clone(true);
    var formId = 'NewForm' + empUniqueId;
    copy.attr('id', formId);
    copy.attr('class', 'removediv');
    copy.addClass('border1Solid');
    copy.addClass('padding21');
    copy.addClass('marginTop20');
    copy.addClass('width100per');
    copy.find("input:hidden").val('');
    copy.find("textarea").val('');
    copy.find('label.error').remove();
    copy.find('img.remove').val('Remove');
    copy.find('img.remove').show();

    $('#container').append(copy);
    $('#' + formId).find('input,select,textarea,img,#ddlStateEmpDetails_1,#ddlYearEnd_1,#ddlYearStart_1,label').each(function () {

        if ($(this).is("label")) {
            ($(this).attr('for', $(this).attr('for').split("_")[0] + "_" + empUniqueId));
        }
        else {
            $(this).attr('id', $(this).attr('id').split("_")[0] + "_" + empUniqueId);
            $(this).attr('name', $(this).attr('id').split("_")[0] + "_" + empUniqueId);
        }

    });



    var endMonthCondition = '#ddlMonthStart_' + empUniqueId + ',#ddlYearStart_' + empUniqueId + " select" + ',#ddlYearEnd_' + empUniqueId + " select";
    

    $('#ddlMonthEnd_' + empUniqueId).attr('ddlEndMonth', endMonthCondition);

    var endYearCondition = '#ddlMonthStart_' + empUniqueId + ',#ddlYearStart_' + empUniqueId + " select";
    $('#ddlYearEnd_' + empUniqueId).attr('ddlEndYear', endMonthCondition);


    var startdateCondition = '#ddlMonthStart_' + empUniqueId;
    $("#ddlYearStart_" + empUniqueId + " select").attr("ddlStartdate", startdateCondition);

    $("#chkAttendingEmp_" + empUniqueId).removeAttr("checked");
    $('#' + formId+ " select").removeAttr("disabled");
    empUniqueId++;
    empcounter = empUniqueId;
}

function AddEmpControl(empControlCount) {
    for (i = 1; i < empControlCount; i++) {
        CreateEmpControl();
    }
}

function RemoveEmpControl(controlId) {
    empUniqueId--;
    var employmentDetailsId = ""; //New

    var id = controlId.id.split("_")[1];

    var hiddenFieldId = "hdnEmploymentDetailsId_" + id;

    employmentDetailsId = $('#' + hiddenFieldId).val();

    $("#NewForm" + id).remove();

    //Check if this control is newly added 
    if (employmentDetailsId != "") {

        //If this not newly added
        RemoveEmpDetailsFromDatabase(employmentDetailsId);
    }

}

function GetEmploymentData() {    

    empdetailsId = [];
    orgName = [];
    city = [];
    state = [];
    telephone = [];

    PositionTitle = [];
    StartDt = [];
    EndDt = [];
    Descript = [];

    startMonth = [];
    startYear = [];
    endMonth = [];
    endYear = [];
    isAttending = [];

    for (i = 1; i < empUniqueId; i++) {

        orgName.push($('#txtOrgName_' + i).val());
        city.push($('#txtProfCity_' + i).val());
        state.push($('#ddlStateEmpDetails_' + i + ' select').val());
        telephone.push($('#txtTelephoneNumber_' + i).val());
        PositionTitle.push($('#txtTitle_' + i).val());
        startMonth.push($("#ddlMonthStart_" + i).val());
        startYear.push($("#ddlYearStart_" + i + " select").val());
        endMonth.push($("#ddlMonthEnd_" + i).val());
        endYear.push($("#ddlYearEnd_" + i + " select").val());
        isAttending.push($("#chkAttendingEmp_" +i).is(':checked').toString())

        Descript.push($('#txtDescription_' + i).val());
    }

}

function SetEmpDetails() {
    var id = 1;
    for (i = 0; i < empUniqueId - 1; i++) {

        $('#txtOrgName_' + id).val(orgName[i]);
        $('#txtProfCity_' + id).val(city[i]);
        $("#ddlStateEmpDetails_" + id + " select").val(state[i]);
        $('#txtTelephoneNumber_' + id).val(telephone[i]);
        $('#txtTitle_' + id).val(PositionTitle[i]);
        $("#ddlMonthStart_" + id).val(startMonth[i]);
        $("#ddlYearStart_" + id + " select").val(startYear[i]);
        $("#ddlMonthEnd_" + id).val(endMonth[i]);
        $("#ddlYearEnd_" + id + " select").val(endYear[i]);
        $('#txtDescription_' + id).val(Descript[i]);
        $('#hdnEmploymentDetailsId_' + id).val(empdetailsId[i]);

        if (isAttending[i] == "True") {
            $('#chkAttendingEmp_' + id).prop('checked', true);

            $("#ddlMonthEnd_" + id).prop("disabled","disabled");
            $("#ddlYearEnd_" + id + " select").prop("disabled", "disabled");
        }
        else {
            $('#chkAttendingEmp_' + id).prop('checked', false);    
        }
        
        id++;
    }
}

function RemoveEmpDetailsFromDatabase(Id) {

    var ControlData = "EmpDetailsId:" + Id;

    $.ajax({
        cache: false,
        type: "POST",
        url: "UserInfoHandling.aspx/DeleteEmpDetailsById",
        contentType: "application/json; charset=utf-8",
        data: "{" + ControlData + "}",
        dataType: "json",
        success: function (result) {
//            if (result.d == "Session Expired")
//                sessioTimeOut();
//            else
//                OpenDialog(result.d);
        }
    });
}

function ValidateEmpDetails() {

    var errorMessage = "Please fill mandatory information to continue.";

    for (i = 1; i < empUniqueId; i++) {       

        if (!($("#ddlYearStart_" + i + " select").valid())) {

            if ($("#ddlYearStart_" + i + " select").val() != 0) {
                errorMessage = "Please enter valid start date, must be less than today's date.";
                break;
            }
        }

        if (($("#ddlMonthEnd_" + i).val() > 0) || ($("#ddlYearEnd_" + i + " select").val() > 0)) {

            if ($("#ddlYearEnd_" + i + " select").val() < $("#ddlYearStart_" + i + " select").val()) {

                errorMessage = "Please enter valid end date, must be greater than start date.";
                break;
            }
            else if ($("#ddlYearEnd_" + i + " select").val() == $("#ddlYearStart_" + i + " select").val()) {

                if ($("#ddlMonthEnd_" + i).val() < $("#ddlMonthStart_" + i).val()) {

                    errorMessage = "Please enter valid end date must be greater than start date.";
                    break;
                }
            }
        }
    }   
   var id = $('div#EmployeeInfoContainer input[type="text"].error,select.error').first().attr("id");
    if (id.indexOf("txtTelephoneNumber") !== -1) {
        errorMessage = "Please enter valid mobile number.";
    }

    OpenDialog(errorMessage, function () {
        $('div#EmployeeInfoContainer input[type="text"].error,select.error').first().focus();
    });
}