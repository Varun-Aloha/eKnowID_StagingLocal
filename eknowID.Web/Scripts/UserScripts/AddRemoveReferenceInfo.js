var refUniqueId = 2;
var refCounter = refUniqueId;

var RefName = [];
var Relationship = [];
var MobileNo = [];
var YearsKnown = [];
var RefType = [];
var ReferenceInfoId = [];


function CreateRefControl() {
    if (refUniqueId < 6)
     {
        $('.divBtnAddNewRef').attr("style", "display:block !important;");
        var copy = $("#referenceOriginal").clone(true);

        copy.find(':radio').each(function () {
            $(this).prop('name', $(this).prop('name') + refUniqueId);
        });

        var formId = 'ReferenceInfo' + refUniqueId;
        copy.attr('id', formId);

        copy.attr('class', 'removediv');
        copy.addClass('width100per');
        copy.addClass('padding21');
        copy.addClass('marginTop20');
        copy.addClass('border1Solid');        
        copy.find('label.error').remove();
        copy.find("input").val('');
        copy.find("input:hidden").val('');
        copy.find('img.remove').val('Remove');
        copy.find('img.remove').show();

        $('#referenceContainer').append(copy);

        $('#' + formId).find('input[type=text],input[type=hidden],textarea,img').each(function () {
            $(this).attr('id', $(this).attr('id').split("_")[0] + "_" + refUniqueId);
            $(this).attr('name', $(this).attr('id').split("_")[0] + "_" + refUniqueId);
        });

        $('#' + formId).find('input[type=radio]').each(function () {
            $(this).attr('id', $(this).attr('id').split("_")[0] + "_" + refUniqueId);
        });

        $('#rdbProfessional_' + refUniqueId).attr('checked', 'checked');
        refUniqueId++;
        refCounter = refUniqueId;
        if (refUniqueId > 5) {
            $('.divBtnAddNewRef').attr("style", "display:none !important;");
        }
    }
}

function AddRefControl(refcontrolCount) {

    for (i = 1; i < refcontrolCount; i++) {
        CreateRefControl();
    }
}

function GetRefData() {
    
    RefName = [];
    Relationship = [];
    MobileNo = [];
    YearsKnown = [];
    RefType = [];
    ReferenceInfoId = [];

    for (i = 1; i < refUniqueId; i++) {
        RefName.push($('#txtName_' + i).val());
        Relationship.push($('#txtRelationShip_' + i).val());
        MobileNo.push($('#txtNumber_' + i).val());
        YearsKnown.push($('#txtYears_' + i).val());
        if ($('#rdbProfessional_' + i).is(':checked'))
        {
            RefType.push('Professional');
        }
        else
        {
             RefType.push('Personal');
        }
    }
}

function SetReferenceData() {
    var id = 1;
    for (i = 0; i < refUniqueId - 1; i++) {
        $('#txtName_' + id).val(RefName[i]);
        $('#txtRelationShip_' + id).val(Relationship[i]);
        $('#txtNumber_' + id).val(MobileNo[i]);
        $('#txtYears_' + id).val(YearsKnown[i]);
        $('#hdnreferenceInfo_' + id).val(ReferenceInfoId[i]);

        if (RefType[i] == 1) {
            $("#rdbProfessional_" + id).prop("checked", true);
            $("#rdbPersonal_" + id).prop("checked", false);
        }
        else {
            $("#rdbProfessional_" + id).prop("checked", false);
            $("#rdbPersonal_" + id).prop("checked", true);
        }
        id++;
    }
}

function RemoveReferenceControl(ControlId) {    
    refUniqueId--;
    var referenceInfoId = "";
    var id = ControlId.id.split("_")[1];
    var hiddenFieldId = "hdnreferenceInfo_" + id;
    referenceInfoId = $('#' + hiddenFieldId).val();

    $("#ReferenceInfo" + id).remove();
    if (refUniqueId <= 5) {
       $('.divBtnAddNewRef').attr("style", "display:block !important;");
    }
    //Check if this control is newly added
    if (referenceInfoId != "") {
        //If this not newly added
        RemoveReferenceInfoFromDatabase(referenceInfoId);
    }
}

function RemoveReferenceInfoFromDatabase(Id) {
    var ControlData = "ReferenceInformationId:" + Id;

    $.ajax({
        cache: false,
        type: "POST",
        url: "UserInfoHandling.aspx/DeleteReferenceInformationById",
        contentType: "application/json; charset=utf-8",
        data: "{" + ControlData + "}",
        dataType: "json",
        success: function (result) {
            if (result.d == "Session Expired")
                sessioTimeOut();
            else
                OpenDialog(result.d);
        }
    });
}

function ValidateReferenceInfo() {  

    if (!($("#mstrPage").valid())) {

        var errorMessage = "Please fill mandatory information to continue.";

        var id = $('div#ReferenceInfoContainer input[type="text"].error').first().attr("id");
        if (id.indexOf("txtNumber") !== -1) {
            errorMessage = "Please enter valid mobile number.";
        }

        OpenDialog(errorMessage, function () {           
            $('div#ReferenceInfoContainer input[type="text"].error').first().focus();

        });
    }    
}   