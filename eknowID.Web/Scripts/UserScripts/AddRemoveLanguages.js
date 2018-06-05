var uniqueLangId = 2;
var langcounter = uniqueLangId;

var languagesKnown = [];
var languagesKnownId = [];

function CreateLangControl() {
    var copy = $("#langOriginal").clone(true);
    var formId = 'langForm' + uniqueLangId;
    copy.attr('id', formId);
    copy.addClass('borderRadius6');
    copy.addClass('AddNewBorder');
    copy.find("input:hidden").val('');
    copy.find('label.error').remove();
    copy.find('img.remove').val('Remove');
    copy.find('img.remove').show();


    $('#langContainer').append(copy);
    $('#' + formId).find('input,textarea,img').each(function () {
        $(this).attr('id', $(this).attr('id').split("_")[0] + "_" + uniqueLangId);
        $(this).attr('name', $(this).attr('id').split("_")[0] + "_" + uniqueLangId);
        //$(this).attr('id', $(this).attr('id').slice(0, -1) + uniqueLangId);

    });    

    //Make Extra added Languages Mandatory
    $('#langForm' + uniqueLangId).find('input[id=txtLanguage_' + uniqueLangId + " ]").addClass('required');

    uniqueLangId++;
    if (uniqueLangId > 2) {
        $('#txtLanguage_1').addClass('required');
    }
    langcounter = uniqueLangId;
}

function getLangData() {
    
    languagesKnown = [];
    for (i = 1; i < uniqueLangId; i++) {
        languagesKnown.push($('#txtLanguage_' + i).val());
    }
}

function setLangData() {
    var id = 1;
    for (i = 0; i < langcounter - 1; i++) {
        $('#txtLanguage_' + id).val(languagesKnown[i]);
        $('#hdnlanguagesKnownId_' + id).val(languagesKnownId[i]);
        id++;
    }
}

function AddLangControl(langControlCount) {
    
    for (i = 1; i < langControlCount; i++) {
        CreateLangControl();
    }
}

function RemoveLangControl(controlId) {
    uniqueLangId--;

    if (uniqueLangId < 3) {
        $('#txtLanguage_1').removeClass('required');
    }
    var languagesKnownId = "";
    var id = controlId.id.split("_")[1];
    var hiddenFieldId = "hdnlanguagesKnownId_" + id;
    languagesKnownId = $('#' + hiddenFieldId).val();

    $("#langForm" + id).remove();

    //Check if this control is newly added 
    if (languagesKnownId != "") {

        //If this not newly added
        RemoveLanguagesKnownFromDatabase(languagesKnownId);
    }

}

function RemoveLanguagesKnownFromDatabase(Id) {  

    var ControlData = "LanguagesKnownId:" + Id;

    $.ajax({
        cache: false,
        type: "POST",
        url: "UserInfoHandling.aspx/DeleteLanguagesKnownById",
        contentType: "application/json; charset=utf-8",
        data: "{" + ControlData + "}",
        dataType: "json",
        success: function (result) {
            OpenDialog(result.d);
        }
    });
} 