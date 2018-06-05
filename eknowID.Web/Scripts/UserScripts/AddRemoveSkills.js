var uniqueSkillId = 2;
var skillcounter = uniqueSkillId;
//var removeSkillIds = [];

var Skills = [];
var additionalSkillid = [];



function CreateSkillControl() {
    var copy = $("#skillOriginal").clone(true);
    var formId = 'SkillForm' + uniqueSkillId;
    copy.attr('id', formId);
    copy.attr('class', 'removediv');
    copy.addClass('borderRadius6');
    copy.addClass('AddNewBorder');
    copy.find("input:hidden").val('');
    copy.find("textarea").val('');
    copy.find('label.error').remove();
    copy.find('img.remove').val('Remove');
    copy.find('img.remove').show();

    $('#skillContainer').append(copy);
    $('#' + formId).find('input,textarea,img').each(function () {
        $(this).attr('id', $(this).attr('id').split("_")[0] + "_" + uniqueSkillId);
        $(this).attr('name', $(this).attr('id').split("_")[0] + "_" + uniqueSkillId);
        //$(this).attr('id', $(this).attr('id').slice(0, -1) + uniqueSkillId);

    });
    uniqueSkillId++;
    skillcounter = uniqueSkillId;
}

function getSkillData() {
    
    Skills = [];
    for (i = 1; i < uniqueSkillId; i++) {
        Skills.push($('#txtSkills_' + i).val());
    }
}

function setSkillData() {
    var id = 1;
    for (i = 0; i < uniqueSkillId - 1; i++) {
        $('#txtSkills_' + id).val(Skills[i]);
        $('#hdnadditionalSkillId_' + id).val(additionalSkillid[i]);
        id++;
    }
}

function AddSkillControl(skillcontrolCount) {
    for (i = 1; i < skillcontrolCount; i++) {
        CreateSkillControl();
    }
}

function RemoveSkillControl(controlId) {   
    
    //decrement uniqueId count on remove button click
    uniqueSkillId--;
    var skillId = "";
    var id = controlId.id.split("_")[1];
    var hiddenFieldId = "hdnadditionalSkillId_" + id;
    skillId = $('#' + hiddenFieldId).val();

    $("#SkillForm" + id).remove();

    //Check if this control is newly added 
    if (skillId != "") {
        
        //Get the list of skillids to be removed
        //removeSkillIds.push(skillId);

        //If this not newly added
        RemoveSkillFromDatabase(skillId);
    }

}

function RemoveSkillFromDatabase(Id) {

    var ControlData = "AdditionalSkillId:" + Id;
    $.ajax({
        cache: false,
        type: "POST",
        url: "UserInfoHandling.aspx/DeleteAdditionalSkillById",
        contentType: "application/json; charset=utf-8",
        data: "{" + ControlData + "}",
        dataType: "json",
        success: function (result) {
            OpenDialog(result.d);
        }
    });
}


function ValidateSkillInformation() {
    
    var errorMessage = "Please check the following things :<br/>";

    for (i = 1; i < uniqueSkillId; i++) {
        if (!($("#txtSkills_" + i).valid())) {
            errorMessage = errorMessage + "- Please enter skill.<br/>";
            break;
        }
    }

    if (uniqueLangId != 2) {
        for (i = 1; i < uniqueLangId; i++) {
            if (!($("#txtLanguage_" + i).valid())) {
                errorMessage = errorMessage + "- Please enter language known.<br/>";
                break;
            }
        }
    }

    OpenDialog(errorMessage, function () {
        $('div#tabs-4 textarea.error,input[type="text"].error').first().focus();
    });
}