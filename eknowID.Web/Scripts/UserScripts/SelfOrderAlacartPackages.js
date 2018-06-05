$(document).ready(function () {
    $(".z-index_1").attr("style", "width:1000px;");

    $('.less').each(function () {
        if ($(this)[0].scrollHeight <= 40) {
            $(this).closest("#divAlacartMain").find(".text-size").hide();
        }
    });

});

function setRequireAdditionalInfo() {
    $.ajax({
        type: "POST",
        url: "UpgradeReportPackage.aspx/SetAdditionalInfoRequire",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        async: false,
        dataType: "json",
        success: function (result) {
            var isUserLoggedIn = $('#hdnUserLoggedIn').val();
            if (isUserLoggedIn == "False") {
                SignInDialog();
                return false;
            }
            else {
                window.location.href = "../Pages/OrderDetail.aspx";
            }
        }
    });

    //CheckIfUserloggedIn();        
}

function CheckIfUserloggedIn() {
    var selectedReprtID = "";
    var selectedReportQty = "";
    var selectedStates = "";
    var selectedStateCounties = "";
    var selectedCivilCounties = "";
    var selectedStateFederals = "";
    var accessFees = 0;
    var holdingfees = 0;
    $(".divAlacartInner").find('input[type=checkbox]').each(function () {
        var chkControlIdVal = this.id;

        var hdnReportIdVal = chkControlIdVal.replace(/\_chkReportName_/g, '_hdnReportId_');
        if (this.checked) {
            var qty = undefined !== $(this).attr("data-qty") ? $(this).attr("data-qty") : "1";
            selectedReprtID = selectedReprtID + "," + $("#" + hdnReportIdVal).val();
            selectedReportQty = selectedReportQty + "," + qty;
        }
    });

    $("#paymentInfoRightContainer").find('#divStateCriminal .dropdown-menu').find("input:checked").each(function () {
        selectedStates = selectedStates + "," + $(this).parent().attr('data-stateid');
        accessFees += parseFloat($(this).parent().attr("data-value"));
    });

    $("#paymentInfoRightContainer").find('#divStateCounty .dropdown-menu').find("input:checked").each(function () {
        selectedStateCounties = selectedStateCounties + "," + $(this).parent().attr('data-countyid');
        accessFees += parseFloat($(this).parent().attr("data-value"));
    });

    $("#paymentInfoRightContainer").find('#divCivilCounty .dropdown-menu').find("input:checked").each(function () {
        selectedCivilCounties = selectedCivilCounties + "," + $(this).parent().attr('data-countyid');
        accessFees += parseFloat($(this).parent().attr("data-value"));
    });

    $("#paymentInfoRightContainer").find('#divStateFederal .dropdown-menu').find("input:checked").each(function () {
        selectedStateFederals = selectedStateFederals + "," + $(this).parent().attr('data-federalid');
        accessFees += parseFloat($(this).parent().attr("data-value"));
    });

    $("#paymentInfoRightContainer").find('.holdingFeesTxt').each(function () {
        holdingfees += (Number(String($(this).text()).replace('$', '')));
        //$(report).find(".holdingFeesTxt").text("$" + newHoldingFees);
    });

    selectedReprtID = selectedReprtID.substring(1);
    selectedReportQty = selectedReportQty.substring(1);
    selectedStates = selectedStates.substring(1);
    selectedStateCounties = selectedStateCounties.substring(1);
    selectedStateFederals = selectedStateFederals.substring(1);
    selectedCivilCounties = selectedCivilCounties.substring(1);


    //var accessFees = 0 < $('#ddlAccessFees').length ? parseFloat($('#ddlAccessFees').val()).toFixed(2) : 0;
    var controlData = "alacartReportList:'" + selectedReprtID + "', alacartReportQty:'" + selectedReportQty + "', selectedStates:'" + selectedStates +
        "', selectedDistricts:'" + selectedStateFederals + "', selectedCounties:'" + selectedStateCounties + "', selectedCivilCounties:'" + selectedCivilCounties +
        "', stateAccessFees:'" + accessFees + "', holdingFees:'" + holdingfees + "'";
    var isUserLoggedIn = $('#hdnUserLoggedIn').val();
    
    var verificationErrorCount = VerifyStateCriminalRptQtyAndStatesSelected('', '');
    verificationErrorCount += VerifyCountyCriminalRptQtyAndStatesSelected('', '');
    verificationErrorCount += VerifyFederalCriminalRptQtyAndStatesSelected('', '');
    verificationErrorCount += VerifyCountyCivilRptQtyAndStatesSelected('', '');

    if (0 < verificationErrorCount) {
        $(".dropdown-toggle").focus();
        return false;
    }

    $.ajax({
        type: "POST",
        url: "UpgradeReportPackage.aspx/SetSelectedAlacartReportList",
        contentType: "application/json; charset=utf-8",
        data: "{" + controlData + "}",
        dataType: "json",
        success: function (result) {

            if (isUserLoggedIn == "False") {
                SignInDialog();
                return false;
            }
            else {
                window.location.href = "../Pages/OrderDetail.aspx";
            }
        }
    });

    //            setRequireAdditionalInfo();

    $.cookie('showUploadResumeDialog', 'true');
    $.cookie('redirectToOrderDetail', 'true');
    $.cookie('showFreeUploadResumeDialog', 'false');
}

var divStyle = 0;

function selectAlacartReport(control) {
    //debugger;
    var chkId = control.id;
    var reportNameid = chkId.replace("chkReportName", "lblReportName");
    var reportPriceid = chkId.replace("chkReportName", "lblReportPrice");
    var lblTotalPriceID = chkId.replace("chkReportName", "lblReportPrice");
    var divId = chkId.replace("chkReportName", "reportNameContainer");
    var totatPrice = parseFloat($("#hdnTotalPriceWithoutDisc").val());

    if ($("#" + chkId).is(':checked')) {
        var div = "<div style='width: 258px; background-color: White;' id ='DIVID' class='divSelectedAlacartReportList'><div class='floatLeft' style=' width: 97%;margin-left:5px;'><input type='hidden' value='' class='alacartPrice'/><div class='floatLeft'><img class='vertical_align_middle floatLeft marginRight10' alt='0' src='../Images/green_tick19x20.png'/></div><div class='floatLeft rptAlacartName' style='width:130px;'>REPORTNAME</div><div class='floatRight alaCartTotal'> REPORTPRICE</div> </div></div>";
        div = div.replace("REPORTNAME", $("#" + reportNameid).text());
        div = div.replace("REPORTPRICE", $("#" + reportPriceid).text());


        div = div.replace("DIVID", divId);
        $("#upgradeReportContainer").append(div);

        var reportPrice = parseFloat($("#" + reportPriceid).text().substr(1));
        totatPrice = totatPrice + reportPrice;
        totatPrice = totatPrice.toFixed(2);
        $("#hdnTotalPriceWithoutDisc").val(totatPrice);
        $("#lblTotalPrice").text("$" + totatPrice);

        var alacartDiv = $(control).closest(".divAlacartMain");
        var price = $(alacartDiv).find("[id*=hdnReportPrice]").val();
        var isMultiCheckEnabled = ($(alacartDiv).find("[id*=hdnMultipleCheckEnabled]").val() === "True");
        var maxVerificationCount = $(alacartDiv).find("[id*=hdnMaxVerificationCount]").val();
        $("#" + divId).find(".alacartPrice").val(price);

        if (isMultiCheckEnabled) {
            $("#" + divId).find(".rptAlacartName").after(("<input onchange='alaCartQuantityChanged(this);' class='clsQuantity' type='number' value='1' min='1' max='9'" + ("data-chkId='" + chkId + "'") + "/>"));
            $("#" + divId).find(".clsQuantity").attr('max', maxVerificationCount);
            $("#" + divId).find(".clsQuantity").show();
        }
        if ("State Criminal Records" === $("#" + reportNameid).text()) {
            //$("#stateCriminalList").find(".dropdown-menu").attr("data-report-id", listOfAlacarteReportsID[key]);
            //$("#stateCriminalList").find(".dropdown-menu").attr("data-report-price", listOfReportsPrice[key]);
            var stateTxt = $("#stateCriminalList").html();//$(stateTxt)[0].outerHTML                        
            //alacarteList += "<li class='alacartReportListItem'>" + value + " <span class='clsPrice'> " + "$" + currentPrice + "</span>" + qtyTxt + "<ul style='list-style:none;'><li><label id='lblStateCriminalError' style='color:red'></label>" + stateTxt + "</li></ul></li>";

            var divAccessFees = $("<div class='floatLeft' style=' width: 97%;margin-left:5px;color:red;'><input type='hidden' value='' class='alacartPrice'/><div class='floatLeft rptAlacartName' >Access Fees</div><div id='ddlAccessFees' class='floatLeft'></div><div class='floatRight alaCartTotal'>$0.00</div></div>");
            $("#" + divId).append(divAccessFees);
            $("#" + divId).append("<label id='lblStateCriminalError' style='color:red; padding-left:25px;'></label>")
            $("#" + divId).find("#ddlAccessFees").html(stateTxt);
        }
        else if ("County Criminal Courthouse Search" === $("#" + reportNameid).text()) {
            //$("#stateCountyList").find(".dropdown-menu").attr("data-report-id", listOfAlacarteReportsID[key]);
            //$("#stateCountyList").find(".dropdown-menu").attr("data-report-price", listOfReportsPrice[key]);
            var stateTxt = $("#stateCountyList").html();//$(stateTxt)[0].outerHTML                        
            var divAccessFees = $("<div class='floatLeft' style=' width: 97%;margin-left:5px;color:red;'><input type='hidden' value='' class='alacartPrice'/><div id='ddlCountyAccessFees' class='floatLeft' style='width:200px;'><div class='floatLeft rptAlacartName'>Access Fees</div><br/></div><div class='floatRight alaCartTotal'>$0.00</div></div>");
            $("#" + divId).append(divAccessFees);
            $("#" + divId).append("<label id='lblCountyCriminalError' style='color:red; padding-left:25px;'></label>")
            $("#" + divId).find("#ddlCountyAccessFees").append(stateTxt);
        }
        else if ("County Civil Courthouse Search" === $("#" + reportNameid).text()) {
            //$("#stateCivilList").find(".dropdown-menu").attr("data-report-id", listOfAlacarteReportsID[key]);
            //$("#stateCivilList").find(".dropdown-menu").attr("data-report-price", listOfReportsPrice[key]);
            var stateTxt = $("#stateCivilList").html();//$(stateTxt)[0].outerHTML                        
            var divAccessFees = $("<div class='floatLeft' style=' width: 97%;margin-left:5px;color:red;'><input type='hidden' value='' class='alacartPrice'/><div id='ddlCountyCivilAccessFees' class='floatLeft' style='width:200px;'><div class='floatLeft rptAlacartName'>Access Fees</div><br/></div><div class='floatRight alaCartTotal'>$0.00</div></div>");
            $("#" + divId).append(divAccessFees);
            $("#" + divId).append("<label id='lblCountyCivilError' style='color:red; padding-left:25px;'></label>")
            $("#" + divId).find("#ddlCountyCivilAccessFees").append(stateTxt);
        }
        else if ("Federal Criminal Courthouse Search" === $("#" + reportNameid).text()) {
            //$("#stateFederalList").find(".dropdown-menu").attr("data-report-id", listOfAlacarteReportsID[key]);
            //$("#stateFederalList").find(".dropdown-menu").attr("data-report-price", listOfReportsPrice[key]);
            var stateTxt = $("#stateFederalList").html();//$(stateTxt)[0].outerHTML                        
            var divAccessFees = $("<div class='floatLeft' style=' width: 97%;margin-left:5px;color:red;'><input type='hidden' value='' class='alacartPrice'/><div class='floatLeft rptAlacartName' >Access Fees</div><div id='ddlDistrictAccessFees' class='floatLeft'></div><div class='floatRight alaCartTotal'>$0.00</div></div>");
            $("#" + divId).append(divAccessFees);
            $("#" + divId).append("<label id='lblFederalCriminalError' style='color:red; padding-left:25px;'></label>")
            $("#" + divId).find("#ddlDistrictAccessFees").html(stateTxt);
        }
        else if ("Employment Verification" === $("#" + reportNameid).text() || "Education Verification" === $("#" + reportNameid).text()) {
            bootbox.confirm({
                message: "$25 additional holding charges applicable for Education/Employment search, do you want to proceed ?",
                buttons: {
                    confirm: {
                        label: 'Yes',
                        className: 'btn-success'
                    },
                    cancel: {
                        label: 'No',
                        className: 'btn-danger',
                        color: 'black'
                    }
                },
                callback: function (result) {
                    if (result) {
                        var divHoldingFees = $("<div class='floatLeft' style=' width: 97%;margin-left:5px;color:red;'><input type='hidden' value='25.00' class='alacartPrice holdingFees'/><div class='floatLeft rptAlacartName' style='width:100px; text-align:right;'>Holding Fees</div><div class='floatRight holdingFeesTxt alaCartTotal'>$25.00</div></div>");
                        $("#" + divId).append(divHoldingFees);
                        $("#" + divId).css({ 'min-height': '70px' });

                    }
                    else {
                        $("#" + chkId).prop("checked", false);
                        $("#" + divId).remove();
                    }
                    updateTotalPrice();
                }
            });
        }
    }
    else {

        $("#" + divId).remove();
        updateTotalPrice();
    }

    setSelectedReportListBg();

    if ("State Criminal Records" === $("#" + reportNameid).text()) {
        $("#" + divId).css({ 'min-height': '100px' });
        $("#" + divId).find('.dropdown-menu a').on('click', function (event) {

            var $target = $(event.currentTarget),
               val = $target.attr('data-stateid'),
               $inp = $target.find('input');

            if ($inp.prop('checked') == true) {
                $inp.prop('checked', false);
            } else {
                $inp.prop('checked', true);
            }

            var verificationErrorCount = VerifyStateCriminalRptQtyAndStatesSelected(val, $inp);

            var accessPrice = 0;
            $("#" + divId).find('.dropdown-menu').find("input:checked").each(function () {
                accessPrice += parseFloat($(this).parent().attr("data-value"));
            });

            $("#" + divId).find("#ddlAccessFees").parent().find(".alaCartTotal").text("$" + accessPrice.toFixed(2));
            updateTotalPrice();
            if (0 == verificationErrorCount) {
                $("#lblStateCriminalError").text("");
            }
            return false;
        });
    }

    if ("Federal Criminal Courthouse Search" === $("#" + reportNameid).text()) {
        $("#" + divId).css({ 'min-height': '100px' });
        $("#" + divId).find('.dropdown-menu a').on('click', function (event) {
            var $target = $(event.currentTarget),
               val = $target.attr('data-federalid'),
               $inp = $target.find('input');

            if ($inp.prop('checked') == true) {
                $inp.prop('checked', false);
            } else {
                $inp.prop('checked', true);
            }

            var verificationErrorCount = VerifyFederalCriminalRptQtyAndStatesSelected(val, $inp);

            var accessPrice = 0;
            $("#" + divId).find('.dropdown-menu').find("input:checked").each(function () {
                accessPrice += parseFloat($(this).parent().attr("data-value"));
            });

            $("#" + divId).find("#ddlDistrictAccessFees").parent().find(".alaCartTotal").text("$" + accessPrice.toFixed(2));
            updateTotalPrice();
            if (0 == verificationErrorCount) {
                $("#lblFederalCriminalError").text("");
            }
            return false;
        });
    }

    if ("County Civil Courthouse Search" === $("#" + reportNameid).text()) {        
        $("#" + divId).css({ 'min-height': '120px' });
        $("#" + divId).find('.dropdown-menu a').on('click', function (event) {

            var $target = $(event.currentTarget),
               val = $target.attr('data-countyid'),
               $inp = $target.find('input'),
               txtVal = $target.text().trim().substring(0, $target.text().trim().indexOf("(", 0)).trim();

            if ($inp.prop('checked') == true) {
                $inp.prop('checked', false);
                $("#lblSelectedCivilCounties").text($("#lblSelectedCivilCounties").text().replace(txtVal + ",", ""));
            } else {
                $inp.prop('checked', true);
                $("#lblSelectedCivilCounties").text($("#lblSelectedCivilCounties").text() + txtVal + ", ");
            }

            var verificationErrorCount = VerifyCountyCivilRptQtyAndStatesSelected(val, $inp);

            var accessPrice = 0;
            $("#" + divId).find('.dropdown-menu').find("input:checked").each(function () {
                accessPrice += parseFloat($(this).parent().attr("data-value"));
            });

            $("#" + divId).find("#ddlCountyCivilAccessFees").parent().find(".alaCartTotal").text("$" + accessPrice.toFixed(2));
            updateTotalPrice();
            if (0 == verificationErrorCount) {
                $("#lblCountyCivilError").text("");
            }
            return false;
        });

        $("#" + divId).find(".searchFiltertxt").focusin(function () {
            $(this).parent().find('.dropdown-menu').show();
        });

        $("#" + divId).find(".searchFiltertxt").focusout(function () {
            setTimeout(function (Jthis) {
                $(Jthis).parent().find('.dropdown-menu').hide();
            }, 1000, this);
        });

        $("#" + divId).find(".searchFiltertxt").keyup(function () {           
            function timer(Jthis, parentdivId) {
                var filterText = $(Jthis).val().toLowerCase();
                var $ddl = $(Jthis).closest(".button-group").find(".dropdown-menu");                

                $.each($($ddl).find(".liParent"), function (index, item) {                   
                    if (1 < filterText.length) {
                        if (String($(item).text().split(' ')[0]).toLowerCase().includes(filterText, 0)) {
                            $(item).show();
                        }
                        else {
                            $(item).hide();
                        }
                    }
                    else
                    {
                        $(item).show();
                    }
                });
                $ddl.show();               
            };
            setTimeout(timer(this, divId), 3000);
        });       
    }

    if ("County Criminal Courthouse Search" === $("#" + reportNameid).text()) {
        $("#" + divId).css({ 'min-height': '120px' });
        $("#" + divId).find('.dropdown-menu a').on('click', function (event) {

            var $target = $(event.currentTarget),
               val = $target.attr('data-countyid'),
               $inp = $target.find('input'),
               txtVal = $target.text().trim().substring(0, $target.text().trim().indexOf("(", 0)).trim();

            if ($inp.prop('checked') == true) {
                $inp.prop('checked', false);
                $("#lblselectedStateCounties").text($("#lblselectedStateCounties").text().replace(txtVal + ",", ""));
            } else {
                $inp.prop('checked', true);
                $("#lblselectedStateCounties").text($("#lblselectedStateCounties").text() + txtVal + ", ");
            }

            var verificationErrorCount = VerifyCountyCriminalRptQtyAndStatesSelected(val, $inp);

            var accessPrice = 0;
            $("#" + divId).find('.dropdown-menu').find("input:checked").each(function () {
                accessPrice += parseFloat($(this).parent().attr("data-value"));
            });

            $("#" + divId).find("#ddlCountyAccessFees").parent().find(".alaCartTotal").text("$" + accessPrice.toFixed(2));
            updateTotalPrice();
            if (0 == verificationErrorCount) {
                $("#lblCountyCriminalError").text("");
            }
            return false;
        });

        $("#" + divId).find(".searchFiltertxt").focusin(function () {
            $(this).parent().find('.dropdown-menu').show();
        });

        $("#" + divId).find(".searchFiltertxt").focusout(function () {
            setTimeout(function (Jthis) {
                $(Jthis).parent().find('.dropdown-menu').hide();
            }, 1000, this);
        });

        $("#" + divId).find(".searchFiltertxt").keyup(function (divId) {           
            function timer(Jthis, parentdivId) {
                var filterText = $(Jthis).val().toLowerCase();
                var $ddl = $(Jthis).closest(".button-group").find(".dropdown-menu");

                $.each($($ddl).find(".liParent"), function (index, item) {
                    if (1 < filterText.length) {
                        if (String($(item).text().split(' ')[0]).toLowerCase().includes(filterText, 0)) {
                            $(item).show();
                        }
                        else {
                            $(item).hide();
                        }
                    }
                    else {
                        $(item).show();
                    }
                });
                $ddl.show();
               
            };
            setTimeout(timer(this, divId), 3000);
        });
    }

    $("#" + divId).keypress(function (evt) {
        if ($(evt.target).is('[type="number"]')) {
            evt.preventDefault();
        }
    });
}


function VerifyStateCriminalRptQtyAndStatesSelected(val, $inp) {

    var verificationErrorCount = 0;
    if (0 < $("#upgradeReportContainer").find('#divStateCriminal .dropdown-menu').length) {
        var currentAlacartReport = $("#upgradeReportContainer").find('#divStateCriminal .dropdown-menu').closest(".divSelectedAlacartReportList");
        var maxAllowedQty = Number($(currentAlacartReport).find(".clsQuantity").attr("max"));
        var selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
        var selectedQty = Number($(currentAlacartReport).find(".clsQuantity").val());



        if (maxAllowedQty < selectedStatesCount) {
            //var index = $.inArray(val, StateCriminalSelectList);
            //StateCriminalSelectList.splice(index, 1);
            $inp.prop('checked', false);
            $("#lblStateCriminalError").text("You can select max " + maxAllowedQty + " states.");
            selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
            verificationErrorCount++;
            return verificationErrorCount;
        }

        if (0 >= $(currentAlacartReport).find('.dropdown-menu').find("input:checked").length) {
            $("#lblStateCriminalError").text("You need to select state for this Add-On Search");
            $(currentAlacartReport).find(".dropdown-toggle").focus();
            verificationErrorCount++;
            return verificationErrorCount;
        }


        if (selectedStatesCount != selectedQty) {
            $(currentAlacartReport).find(".clsQuantity").val(selectedStatesCount);
            $(currentAlacartReport).find(".clsQuantity").change();
        }
        else {
            $("#lblStateCriminalError").text("");
        }
    }

    return verificationErrorCount;
}

function VerifyFederalCriminalRptQtyAndStatesSelected(val, $inp) {

    var verificationErrorCount = 0;
    if (0 < $("#upgradeReportContainer").find('#divStateFederal .dropdown-menu').length) {
        var currentAlacartReport = $("#upgradeReportContainer").find('#divStateFederal .dropdown-menu').closest(".divSelectedAlacartReportList");
        var maxAllowedQty = Number($(currentAlacartReport).find(".clsQuantity").attr("max"));
        var selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
        var selectedQty = Number($(currentAlacartReport).find(".clsQuantity").val());



        if (maxAllowedQty < selectedStatesCount) {
            //var index = $.inArray(val, StateCriminalSelectList);
            //StateCriminalSelectList.splice(index, 1);
            $inp.prop('checked', false);
            $("#lblFederalCriminalError").text("You can select max " + maxAllowedQty + " districts.");
            selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
            verificationErrorCount++;
            return verificationErrorCount;
        }

        if (0 >= $(currentAlacartReport).find('.dropdown-menu').find("input:checked").length) {
            $("#lblFederalCriminalError").text("You need to select district for this Add-On Search");
            $(currentAlacartReport).find(".dropdown-toggle").focus();
            verificationErrorCount++;
            return verificationErrorCount;
        }


        if (selectedStatesCount != selectedQty) {
            $(currentAlacartReport).find(".clsQuantity").val(selectedStatesCount);
            $(currentAlacartReport).find(".clsQuantity").change();
        }
        else {
            $("#lblFederalCriminalError").text("");
        }
    }

    return verificationErrorCount;
}

function VerifyCountyCivilRptQtyAndStatesSelected(val, $inp) {

    var verificationErrorCount = 0;
    if (0 < $("#upgradeReportContainer").find('#divCivilCounty .dropdown-menu').length) {
        var currentAlacartReport = $("#upgradeReportContainer").find('#divCivilCounty .dropdown-menu').closest(".divSelectedAlacartReportList");
        var maxAllowedQty = Number($(currentAlacartReport).find(".clsQuantity").attr("max"));
        var selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
        var selectedQty = Number($(currentAlacartReport).find(".clsQuantity").val());



        if (maxAllowedQty < selectedStatesCount) {
            //var index = $.inArray(val, StateCriminalSelectList);
            //StateCriminalSelectList.splice(index, 1);
            $inp.prop('checked', false);
            $("#lblCountyCivilError").text("You can select max " + maxAllowedQty + " Counties.");
            var txtVal = $($inp).parent().text().trim().substring(0, $($inp).parent().text().trim().indexOf("(", 0)).trim();
            $("#lblselectedCivilCounties").text($("#lblselectedStateCounties").text().replace(txtVal + ",", ""));
            selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
            verificationErrorCount++;
            return verificationErrorCount;
        }

        if (0 >= $(currentAlacartReport).find('.dropdown-menu').find("input:checked").length) {
            $("#lblCountyCivilError").text("You need to select County for this Add-On Search");
            $(currentAlacartReport).find(".dropdown-toggle").focus();
            verificationErrorCount++;
            return verificationErrorCount;
        }


        if (selectedStatesCount != selectedQty) {
            $(currentAlacartReport).find(".clsQuantity").val(selectedStatesCount);
            $(currentAlacartReport).find(".clsQuantity").change();
        }
        else {
            $("#lblCountyCivilError").text("");
        }
    }

    return verificationErrorCount;
}

function VerifyCountyCriminalRptQtyAndStatesSelected(val, $inp) {

    var verificationErrorCount = 0;
    if (0 < $("#upgradeReportContainer").find('#divStateCounty .dropdown-menu').length) {
        var currentAlacartReport = $("#upgradeReportContainer").find('#divStateCounty .dropdown-menu').closest(".divSelectedAlacartReportList");
        var maxAllowedQty = Number($(currentAlacartReport).find(".clsQuantity").attr("max"));
        var selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
        var selectedQty = Number($(currentAlacartReport).find(".clsQuantity").val());



        if (maxAllowedQty < selectedStatesCount) {
            //var index = $.inArray(val, StateCriminalSelectList);
            //StateCriminalSelectList.splice(index, 1);
            $inp.prop('checked', false);
            $("#lblCountyCriminalError").text("You can select max " + maxAllowedQty + " Counties.");
            var txtVal = $($inp).parent().text().trim().substring(0, $($inp).parent().text().trim().indexOf("(", 0)).trim();
            $("#lblselectedStateCounties").text($("#lblselectedStateCounties").text().replace(txtVal + ",", ""));
            selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
            verificationErrorCount++;
            return verificationErrorCount;
        }

        if (0 >= $(currentAlacartReport).find('.dropdown-menu').find("input:checked").length) {
            $("#lblCountyCriminalError").text("You need to select County for this Add-On Search");
            $(currentAlacartReport).find(".dropdown-toggle").focus();
            verificationErrorCount++;
            return verificationErrorCount;
        }


        if (selectedStatesCount != selectedQty) {
            $(currentAlacartReport).find(".clsQuantity").val(selectedStatesCount);
            $(currentAlacartReport).find(".clsQuantity").change();
        }
        else {
            $("#lblCountyCriminalError").text("");
        }
    }

    return verificationErrorCount;
}


function setSelectedReportListBg() {
    var flag = 1;
    $('div.divSelectedAlacartReportList').each(function () {
        if (flag == 1) {
            $("#" + this.id).css({ "background-color": "#EAEAEA" });
            flag = 0;
            return true;
        }

        if (flag == 0) {
            $("#" + this.id).css({ "background-color": "white" });
            flag = 1;
            return true;
        }
    });
}

function alaCartQuantityChanged(Jthis) {
    var qty = $(Jthis).val();
    var chkId = $(Jthis).attr("data-chkId");
    var reportName = $(Jthis).parent().find(".rptAlacartName").text();
    $("#" + chkId).attr("data-qty", qty);
    var price = $(Jthis).parent().find(".alacartPrice").val();
    var newPrice = (qty * (Number(String(price).replace('$', '')))).toFixed(2);
    $(Jthis).next().text("$" + newPrice);
    if ("Employment Verification" === reportName || "Education Verification" === reportName) {
        var report = $(Jthis).closest(".divSelectedAlacartReportList");
        var holdingFees = $(report).find(".holdingFees").val();
        var newHoldingFees = (qty * (Number(String(holdingFees).replace('$', '')))).toFixed(2);
        $(report).find(".holdingFeesTxt").text("$" + newHoldingFees);
    }
    updateTotalPrice();
}



function SetAccessFeesByState(Jthis) {
    var accessPrice = parseFloat($(Jthis).val());
    $(Jthis).parent().parent().find(".alaCartTotal").text("$" + accessPrice.toFixed(2));
    updateTotalPrice();
    $("#lblError").text("");
}

function updateTotalPrice() {
    var totalPrice = 0;
    $("#paymentInfoRightContainer").find(".alaCartTotal").each(function () {
        totalPrice += parseFloat($.trim($(this).text()).substr(1));
    });
    totalPrice = totalPrice.toFixed(2);
    $("#paymentInfoRightContainer").find("#hdnTotalPriceWithoutDisc").val(totalPrice);
    $("#paymentInfoRightContainer").find("#lblTotalPrice").text("$" + totalPrice);
}