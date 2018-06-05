function SaveUserProfileDetails(TabTitle, ShowAlert) {
    //Check if Selected tab is 0
    var ssnvalidate = true;
    var mobileNumber = 10;
    if (TabTitle == "") {
        TabTitle = 'Contact Information';
        indexval = 0;
    }
    TabTitle = TabTitle.replace(/^\s+|\s+$/g, '');


    if (TabTitle == 'Contact Information') {
        ssnvalidate = $("#hdnSSN").valid() && $("#hdnConfirmSSN").valid();
        mobileNumber = $("#txtCntMobile").val().length;
    }


    if ($('#mstrPage').valid() && ssnvalidate && (mobileNumber == 10 || mobileNumber == 0)) {
        var methodURL;
        var controlData;

        var NumberOfTabs = $(".ui-tabs-panel").size();


        if (TabTitle == 'Professional Experience') {
            methodURL = "orderHandling.aspx/AddEmploymentDetails";

            GetEmploymentData();            

            controlData = "'OrganizationName':" + JSON.stringify(orgName) + ",'City':" + JSON.stringify(city) + ",'TelephoneNumber':" + JSON.stringify(telephone) + ",'StateId':" + JSON.stringify(state) + ",'PositionTitle':" + JSON.stringify(PositionTitle) + ",'Description':" + JSON.stringify(Descript) + ",'StartMonth':" + JSON.stringify(startMonth) + ",'StartYear':" + JSON.stringify(startYear) + ",'EndMonth':" + JSON.stringify(endMonth) + ",'EndYear':" + JSON.stringify(endYear) + ",'IsAttending':" + JSON.stringify(isAttending);
            AjaxCall(methodURL, controlData, ShowAlert);

            SetHiddenFieldValues(TabTitle);
            return true;
        }

        if (TabTitle == 'Contact Information') {
            
            var Identification = $("#txtSecurity1").val() + $("#txtSecurity2").val() + $("#txtSecurity3").val()
            methodURL = "orderHandling.aspx/UpdateUserDetails";
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

            controlData = controlData + ",Month:'" + $("#dob select#month1").val() + "'";
            controlData = controlData + ",Day:'" + $("#dob select#day").val() + "'";
            controlData = controlData + ",Year:'" + $("#dob select#year").val() + "'";

            controlData = controlData + ",Address1:'" + $("#txtCntAddLine1").val() + "'";
            controlData = controlData + ",Address2:'" + $("#txtCntAddLine2").val() + "'";
            controlData = controlData + ",City:'" + $("#txtCntCity").val() + "'";

            var stateID = $("#ddlStateContactInfo select").val();

            controlData = controlData + ",StateId:" + stateID;
            controlData = controlData + ",Zip:'" + $("#txtCntZip").val() + "'";


            AjaxCall(methodURL, controlData, ShowAlert);

            return true;
        }


        if (TabTitle == 'Education') {

            methodURL = "orderHandling.aspx/AddEducationalDetails";

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
            if (postGraduation) {
                AjaxCall(methodURL, controlData, 'false');
            }
            else {
                AjaxCall(methodURL, controlData, ShowAlert);
            }

            if (postGraduation) {

                controlData = "";
                attending = false;
                if ($('#chkPostAttending').is(':checked')) {
                    attending = true;
                }

                methodURL = "orderHandling.aspx/AddPostGraduationDetails";
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

                AjaxCall(methodURL, controlData, ShowAlert);
                SetHiddenFieldValues(TabTitle);
                return true;
            }
        }
        if (TabTitle == 'Driving Record') {

            methodURL = "orderHandling.aspx/AddLicenseInfo";
            controlData = "LicenseNumber:'" + $("#txtNumber").val() + "'";
            controlData = controlData + ",LicenseName:'" + $("#txtName").val() + "'";
            stateID = $("#ddlStateLicenseInfo select").val();
            controlData = controlData + ",StateID:" + stateID;

            AjaxCall(methodURL, controlData, ShowAlert);

            return true;

        }

        if (TabTitle == 'Reference Details') {
            methodURL = "orderHandling.aspx/AddReferenceInfo";
            GetRefData();
            controlData = "'Name':" + JSON.stringify(RefName) + ",'Relationship':" + JSON.stringify(Relationship) + ",'MobileNo':" + JSON.stringify(MobileNo) + ",'YearsKnown':" + JSON.stringify(YearsKnown) + ",'RefType':" + JSON.stringify(RefType);
            AjaxCall(methodURL, controlData, ShowAlert);

            SetHiddenFieldValues(TabTitle);
            return true;
        }
    }
    else {
        ValidateCurrentTab(TabTitle);
        return false;
    }

}

function AjaxCall(methodURL, controlData, ShowAlert) {

    $.ajax({
        cache: false,
        type: "POST",
        url: methodURL,
        contentType: "application/json; charset=utf-8",
        data: "{" + controlData + "}",
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

function CheckIfOrderIsValid() {

    methodURL = "orderHandling.aspx/IsOrderValid"
    $.ajax({
        cache: false,
        type: "POST",
        url: methodURL,
        contentType: "application/json; charset=utf-8",

        dataType: "json",
        success: function (result) {
            GetTabTitle(result.d)
        }
    });
}

function GetTabTitle(title) {

    if (title == "valid") {
        
        //Check if drug test is applicable 
        var drugTest = $('#hdnDrugVerification').val();
        var moduleName = $('#hdnModuleName').val();
        if (drugTest == "True") {
            DrugsVerficationPopUp();
        }
        else {
            if (moduleName == 'Resume Checker') {
                $("#btnResumeParse").attr("disabled", false);
                $("#btnResumeParse").css("background-image", "url(../Images/free_analysis_normal.png)");
             }
            else {

                $("#btnCheckOut").attr("disabled", false);
                $("#btnCheckOut").css("background-image", "url(../Images/proceed_normal.png)");
            }
            $('#tabs').tabs('select', 0);
        }
    }
    else {
        if (title != "") {
            var tabIndex;
            if (title == undefined) {
                tabIndex = 0;
            }
            else {
                tabIndex = $('#tabs ul li').index($('#' + title));
            }

            $('#tabs').tabs('select', tabIndex);
        }
    }
}

function SaveDrugDetails() {

    var drugVerificationId = $("#ddlDrugVerification").val();
    var URL = "orderHandling.aspx/AddDrugDetails";
    $.ajax({
        cache: false,
        type: "POST",
        url: URL,
        contentType: "application/json; charset=utf-8",
        data: "{drugVerificationId:" + drugVerificationId + "}",
        dataType: "json",
        success: function (result) {
            CloseDrugsDiv();            
        }
    });
}

function ValidateCurrentTab(TabName) {
    if (TabName == "Contact Information") {
        ValidateContactInfo('orderDetail');
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
}

function AjaxCallOrderDetails(URL, ControlData, SuccessFunction) {
    $.ajax({
        type: "POST",
        url: URL,
        contentType: "application/json; charset=utf-8",
        data: "{" + ControlData + "}",
        dataType: "json",
        success: SuccessFunction
    });
}