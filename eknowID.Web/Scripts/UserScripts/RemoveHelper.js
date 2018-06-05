function SetHiddenFieldValues(TabName) {

    var URL;  

    if (TabName == "Reference Details") {
        URL = "UserInfoHandling.aspx/GetReferenceIdList";
        GetList(URL, TabName);
    }

    if (TabName == "Professional Experience" || TabName == "Employment Details") {
        URL = "UserInfoHandling.aspx/GetProfessionalIdList";
        var data = GetList(URL, TabName);
    }

    if (TabName == "Skills") {
        URL = "UserInfoHandling.aspx/GetSkillIdList";
        var data = GetList(URL, TabName);
    }

    if (TabName == "Education" || TabName == "Education Details") {
        URL = "UserInfoHandling.aspx/GetPostGraduationIdList";
        var data = GetList(URL, TabName);
    }
}

function GetList(methodURL, TabName) {

    $.ajax({
        cache: false,
        type: "POST",
        url: methodURL,
        contentType: "application/json; charset=utf-8",
        data: "{}",
        dataType: "json",
        success: function (result) {
            if (TabName == "Reference Details") {
                SetReferenceHiddenValues(result)
            }

            if (TabName == "Professional Experience" || TabName == "Employment Details") {
                SetProfessionalHiddenValues(result)
            }

            if (TabName == "Skills") {
                SetSkillHiddenValues(result)
            }

            if (TabName == "Education" || TabName == "Education Details") {
                SetPostGraduationHiddenValues(result)
            }

        }
    });
}

function SetReferenceHiddenValues(data) {
    for (i = 2; i < refUniqueId; i++) {
        $('#hdnreferenceInfo_' + i).val(data.d[i - 1]);
    }
}

function SetProfessionalHiddenValues(data) {
    for (i = 2; i < empUniqueId; i++) {
        $('#hdnEmploymentDetailsId_' + i).val(data.d[i - 1]);
    }
}

function SetSkillHiddenValues(data) {
    for (i = 2; i < uniqueSkillId; i++) {
        $('#hdnadditionalSkillId_' + i).val(data.d[0][i - 1]);
    }

    for (i = 2; i < uniqueLangId; i++) {
        $('#hdnlanguagesKnownId_' + i).val(data.d[1][i - 1]);
    }
}

function SetPostGraduationHiddenValues(data) {
    $('#hdnPostGraduation').val(data.d);
}