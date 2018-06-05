function CheckIfUserloggedIn() {
    var selectedReprtID = "";
    $('input[type=checkbox]').each(function () {
        var chkControlIdVal = this.id;
        var chkSelectAllClass = $(this).attr("class");

        if ((chkSelectAllClass != "criminalAll") && (chkSelectAllClass != "verificationAll") && (chkSelectAllClass != "miscellaneousAll")) {
            var hdnReportIdVal = chkControlIdVal.replace(/\_chkReportName_/g, '_hdnReportId_');
            if (this.checked) {
                selectedReprtID = selectedReprtID + "," + $("#" + hdnReportIdVal).val();
            }
        }
    });

    selectedReprtID = selectedReprtID.substring(1);
    var isUserLoggedIn = $('#hdnUserLoggedIn').val();
    var controlData = "alacartReportList:'" + selectedReprtID + "'";
    $.ajax({
        type: "POST",
        url: "AlacartReport.aspx/SetSelectedAlacartReportList",
        contentType: "application/json; charset=utf-8",
        data: "{" + controlData + "}",
        dataType: "json",
        success: function (result) {
            if (isUserLoggedIn == "False") {
                SignInDialog();
            }
            else {
                window.location.href = "../Pages/OrderDetail.aspx";
            }
        }
    });
    $.cookie('showUploadResumeDialog', 'true');
    $.cookie('redirectToOrderDetail', 'true');
}

function setRequireAdditionalInfo() {
    $.ajax({
        type: "POST",
        url: "AlacartReport.aspx/SetAdditionalInfoRequire",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        async: false,
        dataType: "json",
        success: function (result) {
            var isUserLoggedIn = $('#hdnUserLoggedIn').val();
            if (isUserLoggedIn == "False") {
                SignInDialog();
            }
            else {
                window.location.href = "../Pages/OrderDetail.aspx";
            }
        }
    });
}

function setSelectedReportListBg() {
    var flag = 1;
    $('div.divSelectedAlacartReportList').each(function () {
        if (flag == 1) {
            $("#" + this.id).attr("style", "background-color:#EAEAEA;");
            flag = 0;
            return true;
        }

        if (flag == 0) {
            $("#" + this.id).attr("style", "background-color:white;");
            flag = 1;
            return true;
        }
    });
}

function setAlacartReport(control, isChecked) {

    var chkId = control;
    var reportNameid = chkId.replace("chkReportName", "lblReportName");
    var reportPriceid = chkId.replace("chkReportName", "lblReportPrice");
    var lblTotalPriceID = chkId.replace("chkReportName", "lblReportPrice");
    var divId = chkId.replace("chkReportName", "reportNameContainer");
    var totatPrice = parseFloat($("#hdnTotalPriceWithoutDisc").val());

    if (isChecked) {
        var div = "<div style='height: 38px; width: 258px; background-color: White;' id ='DIVID' class='divSelectedAlacartReportList'> <div class='floatLeft' style=' width: 93%;margin-left:15px;'><div class='floatLeft'><img class='vertical_align_middle floatLeft marginRight15' alt='0' src='../Images/green_tick19x20.png'/></div><div class='floatLeft' style='width:160px;'>REPORTNAME</div><div class='floatRight'> REPORTPRICE</div> </div></div>";
        div = div.replace("REPORTNAME", $("#" + reportNameid).text());
        div = div.replace("REPORTPRICE", $("#" + reportPriceid).text());
        div = div.replace("DIVID", divId);
        $("#upgradeReportContainer").append(div);

        var reportPrice = parseFloat($("#" + reportPriceid).text().substr(1));
        totatPrice = totatPrice + reportPrice;
        totatPrice = totatPrice.toFixed(2);
        $("#hdnTotalPriceWithoutDisc").val(totatPrice);
        $("#lblTotalPrice").text("$" + totatPrice);
    }
    else {

        $("#" + divId).remove();
        var reportPrice = parseFloat($("#" + reportPriceid).text().substr(1));
        totatPrice = totatPrice - reportPrice;
        totatPrice = totatPrice.toFixed(2);
        $("#hdnTotalPriceWithoutDisc").val(totatPrice);
        $("#lblTotalPrice").text("$" + totatPrice);
    }
    setSelectedReportListBg();

    var selectedReprtID = "";
    $('input[type=checkbox]').each(function () {
        var chkControlIdVal = this.id;
        var hdnReportIdVal = chkControlIdVal.replace(/\_chkReportName_/g, '_hdnReportId_');
        if (this.checked) {
            selectedReprtID = selectedReprtID + "," + $("#" + hdnReportIdVal).val();
        }
    });

    if (selectedReprtID == "") {
        $(".alacartNextBtn").attr("style", "background-image:url(../Images/disabled_next_btn_red.png);");
        $("#btnNext").attr('disabled', 'true');
    }
    else {
        $(".alacartNextBtn").attr("style", "background-image:url(../Images/next_btn_red.png);");
        $("#btnNext").removeAttr('disabled');
    }
}

//Select Alacart report
function selectAlacartReport(control) {   
    var chkId = control.id;
    var criminalModuleIdIndex = chkId.indexOf("Criminal");
    var verificationModuleIdIndex = chkId.indexOf("Verification");
    var miscellaneousModuleIdIndex = chkId.indexOf("Miscellaneous");
    var selectAllCheckboxId;
    var reportListControlId;

    if (criminalModuleIdIndex != -1) {
        selectAllCheckboxId = "criminalAll";
        reportListControlId = "divCriminal";
    }

    if (verificationModuleIdIndex != -1) {
        selectAllCheckboxId = "verificationAll";
        reportListControlId = "divVerification";
    }

    if (miscellaneousModuleIdIndex != -1) {
        selectAllCheckboxId = "miscellaneousAll";
        reportListControlId = "divMiscellaneous";
    }


    if ($("#" + chkId).is(':checked')) {
        setAlacartReport(chkId, true);
        setSelectAllCheckbox(selectAllCheckboxId, reportListControlId);
    }
    else {
        setAlacartReport(chkId, false);
        $("." + selectAllCheckboxId).attr('checked', false);


    }
}

//Select All Report
function selectAllReport(chkControlClass, reportListControl) {
    $("#" + reportListControl + " input[type='checkbox']").each(function () {
        if ($("." + chkControlClass).is(':checked')) {
            if ($("#" + this.id).is(':checked') == false) {
                $("#" + this.id).attr('checked', true);
                setAlacartReport(this.id, true);
            }
        }
        else {
            $("#" + this.id).attr('checked', false);
            setAlacartReport(this.id, false);
        }
    })
}

function setSelectAllCheckbox(selectAllCheckboxId, reportListControl) {
    var flag = true;
    $("#" + reportListControl + " input[type='checkbox']").each(function () {
        if ($("#" + this.id).is(':checked') == false) {
            flag = false;
        }

        if (flag == true)
            $("." + selectAllCheckboxId).attr('checked', true);
        else
            $("." + selectAllCheckboxId).attr('checked', false);

    });
}
