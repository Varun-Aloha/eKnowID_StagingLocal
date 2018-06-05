function SaveUserProfileDetails(TabTitle, ShowAlert) {

    var methodURL;
    var controlData;
    var ssnvalidate = true;
    var mobileNumber = 10;
    TabTitle = TabTitle.replace(/^\s+|\s+$/g, '');
    if (TabTitle == "") {
        TabTitle = 'Contact Information';
    }

    if (TabTitle == 'Contact Information') {
        //        ssnvalidate = $("#hdnSSN").valid() && $("#hdnConfirmSSN").valid();
        mobileNumber = $("#txtCntMobile").val().length;
    }
    //    if (!$('#mstrPage').valid() || !ssnvalidate || (mobileNumber!=10 && mobileNumber!=0)) {
    if (!$('#mstrPage').valid() || (mobileNumber != 10 && mobileNumber != 0)) {
        ValidateCurrentTab(TabTitle);
        return;
    }

    if (($('#mstrPage').valid())) {

        if (TabTitle == 'Contact Information') {

            var Identification = "";
            methodURL = "UserInfoHandling.aspx/UpdateUserDetails";
            controlData = "FirstName:'" + $("#txtCntFname").val() + "'";
            controlData = controlData + ",MiddleName:'" + $("#txtCntMname").val() + "'";
            controlData = controlData + ",LastName:'" + $("#txtCntLname").val() + "'";
            controlData = controlData + ",EmailAddress:'" + $("#txtCntEmail").val() + "'";
            controlData = controlData + ",Mobile:'" + $("#txtCntMobile").val() + "'";
            controlData = controlData + ",Identification:'" + Identification + "'";

            if (document.getElementById('rdbCntMale').checked) {
                controlData = controlData + ",Gender:'true'";
            }
            else {
                controlData = controlData + ",Gender:'false'";
            }
            // controlData = controlData + ",Birthday:'" + $("#txtCntDOB").val() + "'";
            controlData = controlData + ",Month:'" + $("#dob select#month1").val() + "'";
            controlData = controlData + ",Day:'" + $("#dob select#day").val() + "'";
            controlData = controlData + ",Year:'" + $("#dob select#year").val() + "'";

            controlData = controlData + ",Password:'" + $("#txtCntPassword").val() + "'";
            controlData = controlData + ",Address1:'" + $("#txtCntAddLine1").val() + "'";
            controlData = controlData + ",Address2:'" + $("#txtCntAddLine2").val() + "'";
            controlData = controlData + ",City:'" + $("#txtCntCity").val() + "'";

            var stateID = $("#ddlStateContactInfo select").val();

            controlData = controlData + ",StateId:" + stateID;
            controlData = controlData + ",Zip:'" + $("#txtCntZip").val() + "'";


            ajaxCall(methodURL, controlData, ShowAlert);

            return true;
        }

        if (TabTitle == 'Professional Experience') {

            methodURL = "UserInfoHandling.aspx/AddEmploymentDetails";

            GetEmploymentData();

            //controlData = "'OrganizationName':" + JSON.stringify(orgName) + ",'City':" + JSON.stringify(city) + ",'TelephoneNumber':" + JSON.stringify(telephone) + ",'StateId':" + JSON.stringify(state) + ",'PositionTitle':" + JSON.stringify(PositionTitle) + ",'StartDate':" + JSON.stringify(StartDt) + ",'EndDate':" + JSON.stringify(EndDt) + ",'Description':" + JSON.stringify(Descript);

            controlData = "'OrganizationName':" + JSON.stringify(orgName) + ",'City':" + JSON.stringify(city) + ",'TelephoneNumber':" + JSON.stringify(telephone) + ",'StateId':" + JSON.stringify(state) + ",'PositionTitle':" + JSON.stringify(PositionTitle) + ",'Description':" + JSON.stringify(Descript) + ",'StartMonth':" + JSON.stringify(startMonth) + ",'StartYear':" + JSON.stringify(startYear) + ",'EndMonth':" + JSON.stringify(endMonth) + ",'EndYear':" + JSON.stringify(endYear) + ",'IsAttending':" + JSON.stringify(isAttending);

            ajaxCall(methodURL, controlData, ShowAlert);

            SetHiddenFieldValues(TabTitle);

            return true;
        }

        if (TabTitle == 'Education') {

            methodURL = "UserInfoHandling.aspx/AddUserEducationalDetails";
            var attending = false;

            if ($('#chkAttending').is(':checked')) {
                attending = true;
            }
            controlData = "Basic:'" + $("#txtBasic").val() + "'";
            controlData = controlData + ",Specialization:'" + $("#txtSpecialization").val() + "'";

            controlData = controlData + ",University:'" + $("#txtUniversity").val() + "'";

            controlData = controlData + ",StartMonth:" + $("#ddlMonthStart").val();
            controlData = controlData + ",StartYear:" + $("#ddlYearStart select").val();
            controlData = controlData + ",EndMonth:" + $("#ddlMonthEnd").val();
            controlData = controlData + ",EndYear:" + $("#ddlYearEnd select").val();



            var stateID = $("#ddlStateEducational select").val();

            controlData = controlData + ",StateID:" + stateID;
            controlData = controlData + ",Municipality:'" + $("#txtMunicipality").val() + "'";
            controlData = controlData + ",Attending:" + attending;
            var postGraduation = $("#Post").is(':visible');

            SaveUserEducation(methodURL, controlData, postGraduation, ShowAlert);


            if (postGraduation) {

                controlData = "";
                attending = false;

                if ($('#chkPostAttending').is(':checked')) {
                    attending = true;
                }
                methodURL = "UserInfoHandling.aspx/AddPostGraduationDetails";
                controlData = "PostGraduation:'" + $("#txtPostGraduation").val() + "'";
                controlData = controlData + ",Specialization:'" + $("#txtPostSpecialization").val() + "'";
                controlData = controlData + ",University:'" + $("#txtPostUniversity").val() + "'";
                controlData = controlData + ",Municipality:'" + $("#txtPostMuncipality").val() + "'";

                stateID = 0;
                stateID = $("#ddlStatePostGraduation select").val();

                controlData = controlData + ",StateID:" + stateID;

                controlData = controlData + ",StartMonth:" + $("#ddlPostMonthStart").val();
                controlData = controlData + ",StartYear:" + $("#ddlPostYearStart select").val();
                controlData = controlData + ",EndMonth:" + $("#ddlPostMonthEnd").val();
                controlData = controlData + ",EndYear:" + $("#ddlPostYearEnd select").val();
                controlData = controlData + ",Attending:" + attending;

                ajaxCall(methodURL, controlData, ShowAlert);
                SetHiddenFieldValues(TabTitle);

                return true;
            }
        }

        if (TabTitle == 'Reference Details') {

            methodURL = "UserInfoHandling.aspx/AddReferenceInfo";
            GetRefData();
            controlData = "'Name':" + JSON.stringify(RefName) + ",'Relationship':" + JSON.stringify(Relationship) + ",'MobileNo':" + JSON.stringify(MobileNo) + ",'YearsKnown':" + JSON.stringify(YearsKnown) + ",'RefType':" + JSON.stringify(RefType);

            ajaxCall(methodURL, controlData, ShowAlert);

            SetHiddenFieldValues(TabTitle);

            return true;
        }

        if (TabTitle == 'Driving Record') {

            methodURL = "UserInfoHandling.aspx/AddUserLicenseInfo";
            controlData = "LicenseNumber:'" + $("#txtNumber").val() + "'";
            controlData = controlData + ",LicenseName:'" + $("#txtName").val() + "'";
            //controlData = controlData + ",LicensingAgency:'" + $("#txtAgency").val() + "'";

            var stateID = $("#ddlStateLicenseInfo select").val();

            controlData = controlData + ",StateId:" + stateID;
            ajaxCall(methodURL, controlData, ShowAlert);
            return true;
        }
        else {
            $('#mstrPage').validate();
            return false;

        }
    }
}

function ajaxCall(methodURL, controlData, ShowAlert) {

    $.ajax({
        type: "POST",
        url: methodURL,
        contentType: "application/json; charset=utf-8",
        data: "{" + controlData + "}",
        async: false,
        dataType: "json",
        success: function (result) {
            if (ShowAlert == "true") {

                if (result.d == "Session Expired")
                    sessioTimeOut();
                else
                    OpenDialog(result.d);
            }
        }
    });
}

function SaveUserEducation(methodURL, controlData, IsPostGraduation, ShowAlert) {

    $.ajax({
        type: "POST",
        url: methodURL,
        contentType: "application/json; charset=utf-8",
        data: "{" + controlData + "}",
        async: false,
        dataType: "json",
        success: function (result) {

            if (IsPostGraduation) {
                if (ShowAlert == "true") {
                    OpenDialog(result.d);
                }
            }
        }
    });
}

function ChangeProfileTab() {
    var ssnvalidate = true;
    if (tabIndex == "") {
        tabIndex = 0;
        //        ssnvalidate = $("#hdnSSN").valid() && $("#hdnConfirmSSN").valid();
    }
    if ($('#mstrPage').valid()) {

        var index = tabIndex + 1;
        var totalSize = $(".ui-tabs-panel").size();
        if (index < totalSize) {
            $("#tabs").tabs('select', index);
        }
        else {
            $("#tabs").tabs('select', 0);
        }
    }
}

function ValidateCurrentTab(TabName) {

    if (TabName == "Contact Information") {
        ValidateContactInfo('userProfile');
    }
    if (TabName == "Professional Experience") {
        ValidateEmpDetails();
    }
    if (TabName == "Education") {
        ValidateEducationDetails();
    }
    if (TabName == "Driving Record") {
        ValidateLicenseInfo();
    }
    if (TabName == "Reference Details") {
        ValidateReferenceInfo();
    }
    if (TabName == "Skills") {
        ValidateSkillInformation();
    }

}