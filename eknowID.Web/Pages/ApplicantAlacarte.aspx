<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="ApplicantAlacarte.aspx.cs" Inherits="eknowID.Pages.ApplicantAlacarte" %>

<%@ Register Src="~/Controls/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="ProgressBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        input[type=number]::-webkit-inner-spin-button,
        input[type=number]::-webkit-outer-spin-button {
            opacity: 1;
        }

        .less {
            word-wrap: break-word;
            text-overflow: ellipsis;
            overflow: hidden;
            max-height: 10px;
            /*padding: 10px;*/
        }

        .more {
            white-space: normal;
            margin: 0 auto;
            width: 100%;
            height: auto;
        }

        .text-size {
            /*display: block;*/
            margin-right:40px;
            font-size: 14px;
            font-weight: normal;
            text-align: left;
            color: #fb5240 !important;
            cursor: pointer;
            float:right;
        }
        p {
            margin: 0px 0px 0px 0px;
        }
    </style>
    <script type="text/javascript" src="../Scripts/bootbox.min.js"></script>
    <script type="text/javascript">

        $(function () {

            $("#addOnSearches").keypress(function (evt) {
                if ($(evt.target).is('[type="number"]')) {
                    evt.preventDefault();
                }
            });

            $("#stateCriminalList").find(".dropdown-menu").html($("#hdnStateCriminalList").val());
            $("#stateCountyList").find(".dropdown-menu").html($("#hdnCountyCriminalList").val());
            $("#stateFederalList").find(".dropdown-menu").html($("#hdnFederalCriminalList").val())
            $("#stateCivilList").find(".dropdown-menu").html($("#hdnCountyCivilList").val())

            var listOfReports = []; //store report Name
            var listOfReportsPrice = []; // store report Price
            var listOfAlacarteReportsID = []; // store report ID
            var listOfReportQty = [];
            var listOfReportMaxCount = [];
            var StateCriminalSelectList = [];
            var StateCountySelectList = [];
            var CivilCountySelectList = [];
            var StateFederalSelectList = [];
            var alacarteList = "";
            var totalPrice = 0;
            var IsCreditReportCredentialAuditStatusPending = false;
            var IsCreditReportAuditingChargesPaid = false;
            var IsCreditReportAjaxRequestsComplete = false;
            
            var reportsSelected = $("#hdnReport").val();
            var ids = reportsSelected.split(',');
            $("#hdnIsCreditReportAuditingChargesPaid").val(IsCreditReportAuditingChargesPaid);

            $("#addOnSearches").html($("#hdnReportList").val());
            $("#lblPrice").text($("#hdnPlanPrice").val());

            if ($("#hdnTotalPrice").val() != "")
                $("#totalPrice").text("$" + $("#hdnTotalPrice").val());
            else
                $("#totalPrice").text("$" + $("#hdnPlanPrice").val());

            $.each(ids, function (key, value) {
                if (value !== "") {
                $("#" + value).attr("checked", "checked");
                    var price = parseFloat($("#" + value).attr('data-report-price'));
                    listOfAlacarteReportsID.push(value);
                    listOfReportsPrice.push(price.toFixed(2));
                }
            });
            $("#addOnSearches").find("li").each(function () {
                listOfReportQty.push($(this).find(".clsQuantity").val());
            });

            var rptPrice = $("#hdnPlanPrice").val();
            $("#lblPrice").html(rptPrice);
            $("#hdnTotalPrice").val(rptPrice);

            $("#divUpgradePackageList").find(":checkbox").click(function () {
                var chkbox = $(this);
                var reportName = $(this).attr('data-report-name');
                var confirmedAddingReport = true;
                if ($(this).is(':checked')) {                    

                    var price = parseFloat($(this).attr('data-report-price'));
                    var qty = parseInt($(this).attr('data-report-maxverificationcount'));
                    var reportId = $(this).attr('ID');
                    if ("eKnowID Criminal MultiState Alias" === reportName)
                    {
                        price = 5.95;
                        var templi = $("#defaultSearches").find('li').filter(function () { return $.text([this]) === 'National Criminal Database with Alias'; });
                        templi.hide('slow');
                        templi.text("eKnowID Criminal MultiState Alias");
                        templi.show('slow');
                    }
                    if ("Employment Verification" === reportName || "Education Verification" === reportName) {
                   
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
                                    color:'black'
                                }
                            },
                            callback: function (result) {                               
                                if(result)
                                {
                                    //price += 25.0000;
                                    listOfReports.push(reportName);
                                    listOfReportsPrice.push(price.toFixed(2));
                                    listOfReportQty.push(1);
                                    listOfReportMaxCount.push(qty);
                                    listOfAlacarteReportsID.push(reportId);
                                    UpdateOrderSummaryDetails(IsCreditReportAuditingChargesPaid);
                                }
                                else
                                {
                                    $(chkbox).prop("checked", false);
                                }
                            }
                        });
                    } else if ("Credit Report" === reportName) {
                        $.ajax({
                            type: "POST",
                            url: "ApplicantAlacarte.aspx/CheckIfUserIsLoggedIn",
                            contentType: "application/json; charset=utf-8",
                            async: false,
                            success: function (result) {                               
                                if (!result.d) {
                                    bootbox.confirm({
                                        message: "In Order to select Credit Report user must be logged in and user company profile should be present in our system.",
                                        buttons: {
                                            confirm: {
                                                label: 'Ok',
                                                className: 'btn-success'
                                            },
                                            cancel: {
                                                label: 'Cancel',
                                                className: 'btn-danger',
                                                color: 'black'
                                            }
                                        },
                                        callback: function (result) {                                           
                                            if (result) {
                                                openLoginModal();
                                            }
                                        }
                                    });
                                }
                                else {
                                    $.ajax({
                                        type: "POST",
                                        url: "ApplicantAlacarte.aspx/CheckForUserCompanyDetails",
                                        contentType: "application/json; charset=utf-8",
                                        async: false,
                                        success: function (result) {
                                            
                                            if (!result.d) {
                                                openCompnayProfileModal();
                                            } else {
                                                //verifyCreditReportCredentialingAuditStatusForCompany();
                                                $.ajax({
                                                    type: "POST",
                                                    url: "ApplicantAlacarte.aspx/VerifyCreditReportCredentialingAuditStatusForCompany",
                                                    contentType: "application/json; charset=utf-8",
                                                    async: false,
                                                    success: function (result) {
                                                        
                                                        if (result.d.IsCreditReportAuditingChargesPaid) {
                                                            IsCreditReportAuditingChargesPaid = false;                                                           
                                                            $("#hdnIsCreditReportAuditingChargesPaid").val(IsCreditReportAuditingChargesPaid);
                                                            //IsCreditReportAjaxRequestsComplete = true;
                                                            listOfReports.push(reportName);
                                                            listOfReportsPrice.push(price.toFixed(2));
                                                            listOfReportQty.push(1);
                                                            listOfReportMaxCount.push(qty);
                                                            listOfAlacarteReportsID.push(reportId);
                                                            UpdateOrderSummaryDetails(IsCreditReportAuditingChargesPaid);
                                                            //if(null == result.d.IsEligibleForCreditReportAuditing)
                                                            //{
                                                            //    IsCreditReportCredentialAuditStatusPending = true;
                                                            //    alert("Credentials auditing report status is pending.")
                                                            //}
                                                            //else if (result.d.IsEligibleForCreditReportAuditing) {
                                                            //    alert("Eligible For Credit Report Auditing.")
                                                            //}
                                                            //else {
                                                            //    alert("Not Eligible For Credit Report Auditing.")
                                                            //}                                                           
                                                            //IsCreditReportAjaxRequestsComplete = true;
                                                        } else {
                                                            bootbox.confirm({
                                                                message: "An on-site inspection is required to verify that your business is eligible to run employment credit checks. The process generally takes 3-5 business days and incurs a one-time fee of $75. After that, each credit report ordered by your company will be $18.",
                                                                buttons: {
                                                                    confirm: {
                                                                        label: 'Ok',
                                                                        className: 'btn-success'
                                                                    },
                                                                    cancel: {
                                                                        label: 'Cancel',
                                                                        className: 'btn-danger',
                                                                        color: 'black'
                                                                    }
                                                                },
                                                                callback: function (result) {                                                                    
                                                                    if (result) {
                                                                        IsCreditReportAuditingChargesPaid = true;
                                                                        $("#hdnIsCreditReportAuditingChargesPaid").val(IsCreditReportAuditingChargesPaid);
                                                                        //IsCreditReportAjaxRequestsComplete = true;
                                                                        listOfReports.push(reportName);
                                                                        listOfReportsPrice.push(price.toFixed(2));
                                                                        listOfReportQty.push(1);
                                                                        listOfReportMaxCount.push(qty);
                                                                        listOfAlacarteReportsID.push(reportId);
                                                                        UpdateOrderSummaryDetails(IsCreditReportAuditingChargesPaid);
                                                                    }
                                                                }
                                                            });                                                           
                                                        }
                                                    }
                                                });
                                            }
                                        }
                                    });
                                }
                            }
                        });                       
                    }
                    else {
                        listOfReports.push(reportName);
                        listOfReportsPrice.push(price.toFixed(2));
                        listOfReportQty.push(1);
                        listOfReportMaxCount.push(qty);
                        listOfAlacarteReportsID.push(reportId);

                        UpdateOrderSummaryDetails(IsCreditReportAuditingChargesPaid);
                    }
                }
                else {
                    var index = listOfReports.indexOf(reportName);
                    listOfReports.splice(index, 1);
                    listOfReportsPrice.splice(index, 1);
                    listOfAlacarteReportsID.splice(index, 1);
                    listOfReportQty.splice(index, 1);
                    listOfReportMaxCount.splice(index, 1);
                    if ("State Criminal Records" === reportName) {
                        StateCriminalSelectList = [];
                        $("#hdnStateCriminalSelectList").val(StateCriminalSelectList);
                    }
                    if ("County Criminal Courthouse Search" === reportName) {
                        StateCountySelectList = [];
                        $("#hdnCountyCriminalSelectList").val(StateCountySelectList);
                    }
                    if ("County Civil Courthouse Search" === reportName) {
                        CivilCountySelectList = [];
                        $("#hdnCountyCivilSelectList").val(CivilCountySelectList);
                    }
                    if ("Federal Criminal Courthouse Search" === reportName) {
                        StateFederalSelectList = [];
                        $("#hdnFederalCriminalSelectList").val(StateFederalSelectList);
                    }
                    if ("eKnowID Criminal MultiState Alias" === reportName) {                        
                        price = 5.95;
                        var templi = $("#defaultSearches").find('li').filter(function () { return $.text([this]) === 'eKnowID Criminal MultiState Alias'; });
                        templi.hide('slow');
                        templi.text("National Criminal Database with Alias");
                        templi.show('slow');
                    }
                    if ("Employment Verification" === reportName || "Education Verification" === reportName)
                    {
                        setTotalPrice(-25);
                    }

                    UpdateOrderSummaryDetails(IsCreditReportAuditingChargesPaid);
                }

                               
            });
            
            function UpdateOrderSummaryDetails(IsAuditingChargesPaid) {
                alacarteList = "";
                var selectedIndex = 0;
                var holdingFees = 0;
                $.each(listOfReports, function (key, value) {
                    var qtyTxt = "";
                    var stateTxt = "";
                    if (1 < listOfReportMaxCount[key]) {
                        qtyTxt = " <span><input class='clsQuantity' type='number' min='1' max='"
                                    + listOfReportMaxCount[key] + "'" + (" data-report-id='" + listOfAlacarteReportsID[key] + "'")
                                    + ("value='" + listOfReportQty[key] + "'") + "/></span>";
                    }
                    var currentPrice = parseFloat(listOfReportsPrice[key] * listOfReportQty[key]).toFixed(2);
                    holdingFees = (25.00 * listOfReportQty[key]).toFixed(2);
                    if ("State Criminal Records" === value) {
                        $("#stateCriminalList").find(".dropdown-menu").attr("data-report-id", listOfAlacarteReportsID[key]);
                        $("#stateCriminalList").find(".dropdown-menu").attr("data-report-price", listOfReportsPrice[key]);                        
                        stateTxt = $("#stateCriminalList").html();//$(stateTxt)[0].outerHTML                        
                        alacarteList += "<li class='alacartReportListItem'>" + " <span class='clsPrice'> " + "$" + currentPrice + "</span>" + "<span class='rptAlacartName'>" + value + "</span>" + qtyTxt + "<ul style='list-style:none;'><li><label id='lblStateCriminalError' style='color:red'></label>" + stateTxt + "</li></ul></li>";
                    }
                    else if ("Employment Verification" === value || "Education Verification" === value) {
                        alacarteList += "<li class='alacartReportListItem'>" + " <span class='clsPrice'>" + "$" + currentPrice + "</span>" + "<span class='rptAlacartName'>" + value + "</span>" + qtyTxt +
                            "<ul style='list-style:none;'><li><input type='hidden' value='25.00' class='alacartPrice holdingFees'/>Holding Fees: <span class='clsPrice holdingFeesTxt' style='float:right; margin-right:25px;'>$" + holdingFees + "</span></li></ul></li>";
                        //holdingFees += 25.00;
                    }
                    else if ("Credit Report" === value) {
                        var inspectionFees = (IsAuditingChargesPaid ? 75.00 : 0.00).toFixed(2);
                        alacarteList += "<li class='alacartReportListItem'>" + " <span class='clsPrice'>" + "$" + currentPrice + "</span>" + "<span class='rptAlacartName'>" + value + "</span>" + qtyTxt +
                            (IsAuditingChargesPaid ? ("<ul style='list-style:none;'><li><input type='hidden' value='" + inspectionFees + "' class='alacartPrice inspectionFees'/>on-site inspection Fees: <span class='clsPrice inspectionFeesTxt' style='float:right; margin-right:25px;'>$" + inspectionFees + "</span></li></ul>") : "") +
                            "</li>";
                        //holdingFees += 25.00;
                    }
                    else if ("County Criminal Courthouse Search" === value) {
                        $("#stateCountyList").find(".dropdown-menu").attr("data-report-id", listOfAlacarteReportsID[key]);
                        $("#stateCountyList").find(".dropdown-menu").attr("data-report-price", listOfReportsPrice[key]);
                        stateTxt = $("#stateCountyList").html();//$(stateTxt)[0].outerHTML                        
                        alacarteList += "<li class='alacartReportListItem'>" + " <span class='clsPrice'> " + "$" + currentPrice + "</span>" + "<span class='rptAlacartName'>" + value + "</span>" + qtyTxt + "<ul style='list-style:none;'><li><label id='lblCountyCriminalError' style='color:red'></label>" + stateTxt + "</li></ul></li>";
                    }
                    else if ("County Civil Courthouse Search" === value) {
                        $("#stateCivilList").find(".dropdown-menu").attr("data-report-id", listOfAlacarteReportsID[key]);
                        $("#stateCivilList").find(".dropdown-menu").attr("data-report-price", listOfReportsPrice[key]);
                        stateTxt = $("#stateCivilList").html();//$(stateTxt)[0].outerHTML                        
                        alacarteList += "<li class='alacartReportListItem'>" + " <span class='clsPrice'> " + "$" + currentPrice + "</span>" + "<span class='rptAlacartName'>" + value + "</span>" + qtyTxt + "<ul style='list-style:none;'><li><label id='lblCountyCivilError' style='color:red'></label>" + stateTxt + "</li></ul></li>";
                    }
                    else if("Federal Criminal Courthouse Search" === value)
                    {
                        $("#stateFederalList").find(".dropdown-menu").attr("data-report-id", listOfAlacarteReportsID[key]);
                        $("#stateFederalList").find(".dropdown-menu").attr("data-report-price", listOfReportsPrice[key]);
                        stateTxt = $("#stateFederalList").html();//$(stateTxt)[0].outerHTML                        
                        alacarteList += "<li class='alacartReportListItem'>" + " <span class='clsPrice'> " + "$" + currentPrice + "</span>" + "<span class='rptAlacartName'>" + value + "</span>" + qtyTxt + "<ul style='list-style:none;'><li><label id='lblFederalCriminalError' style='color:red'></label>" + stateTxt + "</li></ul></li>";
                    }
                    else {
                        alacarteList += "<li class='alacartReportListItem'>" + " <span class='clsPrice'> " + "$" + currentPrice + "</span>" + "<span class='rptAlacartName'>" + value + "</span>" + qtyTxt + "</li>";
                    }
                });

                var tempTotalPrice = 0;
                $(listOfReportsPrice).each(function (key, value) {
                    tempTotalPrice += parseFloat(listOfReportsPrice[key]);
                });

                totalPrice = parseFloat(tempTotalPrice.toFixed(2));
                totalPrice += parseFloat(rptPrice);

                $("#hdnReport").val(listOfAlacarteReportsID);
                $("#hdnTotalPrice").val(totalPrice.toFixed(2));

                //set report list into hidden field
                $("#hdnReportList").val(alacarteList);
                $("#addOnSearches").html(alacarteList);
                $("#hdnReportQty").val(listOfReportQty);
                
                
                SetQuantityChangeEvent();
                SetDropdownFilterEvents();
                SetStateCriminalMultiselectChangeEvent();
                SetCountyCriminalMultiselectChangeEvent();
                SetCountyCivilMultiselectChangeEvent();
                SetFederalCriminalMultiselectChangeEvent();
                setTotalPrice(parseFloat(rptPrice));                
            }
            
            $("img").click(function () {

                var imageclass = $(this).attr('data-attribute');

                var imgName = $(this).attr("src").split("/");

                if (imgName[imgName.length - 1] == "red_arrow_down.png")
                    $(this).attr("src", "../Images/red_arrow_up.png");

                else
                    $(this).attr("src", "../Images/red_arrow_down.png");

                $("." + imageclass).fadeToggle("2000");
            });

            function UpdateStateCriminalMultiselect() {
                if (0 < $("#addOnSearches").find("#divStateCriminal .dropdown-menu").length) {

                    if (0 < StateCriminalSelectList.length) {
                        $("#addOnSearches").find("#divStateCriminal .dropdown-menu").find("input:checkbox").each(function () {
                            var stateID = $(this).parent().attr('data-stateid');
                            if ($.inArray(stateID, StateCriminalSelectList) > -1) {                                
                                $(this).prop('checked', true);
                            }
                            else {
                                $(this).prop('checked', false);
                            }
                        });
                        var accessPrice = 0;

                        $("#addOnSearches").find('#divStateCriminal .dropdown-menu').find("input:checked").each(function () {
                            accessPrice += parseFloat($(this).parent().attr("data-value"));
                        });

                        $("#addOnSearches").find('#divStateCriminal .dropdown-menu').parent().find(".clsPrice").text("$" + accessPrice.toFixed(2));
                    }
                    else {
                        $("#addOnSearches").find("#divStateCriminal .dropdown-menu").find("input:checkbox").prop('checked', false);
                    }
                }
            }

            function UpdateCountyCriminalMultiselect() {
                if (0 < $("#addOnSearches").find("#divStateCounty .dropdown-menu").length) {

                    if (0 < StateCountySelectList.length) {
                        $("#addOnSearches").find("#divStateCounty .dropdown-menu").find("input:checkbox").each(function () {
                            var stateID = $(this).parent().attr('data-countyid');
                            if ($.inArray(stateID, StateCountySelectList) > -1) {                                
                                $(this).prop('checked', true);
                            }
                            else {
                                $(this).prop('checked', false);
                            }
                        });
                        var accessPrice = 0;

                        $("#addOnSearches").find('#divStateCounty .dropdown-menu').find("input:checked").each(function () {
                            accessPrice += parseFloat($(this).parent().attr("data-value"));
                        });

                        $("#addOnSearches").find('#divStateCounty .dropdown-menu').parent().find(".clsPrice").text("$" + accessPrice.toFixed(2));
                    }
                    else {
                        $("#addOnSearches").find("#divStateCounty .dropdown-menu").find("input:checkbox").prop('checked', false);
                    }
                }
            }
            
            function UpdateCountyCivilMultiselect() {
                if (0 < $("#addOnSearches").find("#divCivilCounty .dropdown-menu").length) {

                    if (0 < CivilCountySelectList.length) {
                        $("#addOnSearches").find("#divCivilCounty .dropdown-menu").find("input:checkbox").each(function () {
                            var stateID = $(this).parent().attr('data-countyid');
                            if ($.inArray(stateID, CivilCountySelectList) > -1) {                               
                                $(this).prop('checked', true);
                            }
                            else {
                                $(this).prop('checked', false);
                            }
                        });
                        var accessPrice = 0;

                        $("#addOnSearches").find('#divCivilCounty .dropdown-menu').find("input:checked").each(function () {
                            accessPrice += parseFloat($(this).parent().attr("data-value"));
                        });

                        $("#addOnSearches").find('#divCivilCounty .dropdown-menu').parent().find(".clsPrice").text("$" + accessPrice.toFixed(2));
                    }
                    else {
                        $("#addOnSearches").find("#divCivilCounty .dropdown-menu").find("input:checkbox").prop('checked', false);
                    }
                }
            }

            function UpdateFederalCriminalMultiselect() {
                if (0 < $("#addOnSearches").find("#divStateFederal .dropdown-menu").length) {

                    if (0 < StateFederalSelectList.length) {
                        $("#addOnSearches").find("#divStateFederal .dropdown-menu").find("input:checkbox").each(function () {
                            var stateID = $(this).parent().attr('data-federalid');
                            if ($.inArray(stateID, StateFederalSelectList) > -1) {                                
                                $(this).prop('checked', true);
                            }
                            else {
                                $(this).prop('checked', false);
                            }
                        });
                        var accessPrice = 0;

                        $("#addOnSearches").find('#divStateFederal .dropdown-menu').find("input:checked").each(function () {
                            accessPrice += parseFloat($(this).parent().attr("data-value"));
                        });

                        $("#addOnSearches").find('#divStateFederal .dropdown-menu').parent().find(".clsPrice").text("$" + accessPrice.toFixed(2));
                    }
                    else {
                        $("#addOnSearches").find("#divStateFederal .dropdown-menu").find("input:checkbox").prop('checked', false);
                    }
                }
            }

            function SetQuantityChangeEvent()
            {                
                $("#addOnSearches").find(".clsQuantity").change(function () {
                    var reportId = $(this).attr("data-report-id");
                    var reportName = $(this).closest(".alacartReportListItem").find(".rptAlacartName").text();
                    if ($.inArray(reportId, listOfAlacarteReportsID) > -1) {
                        var index = $.inArray(reportId, listOfAlacarteReportsID);
                        var qty = parseInt($(this).val());
                        var price = parseFloat(listOfReportsPrice[index] * qty).toFixed(2);
                        listOfReportQty[index] = qty;
                        $(this).closest("li").find(".clsPrice:first").text("$" + price);
                        var rptPrice = $("#hdnPlanPrice").val();
                        $(this).attr("value", qty);
                        $("#hdnReportQty").val(listOfReportQty);                        
                        $("#hdnReportList").val($("#addOnSearches").html());

                        if ("Employment Verification" === reportName || "Education Verification" === reportName) {
                            var report = $(this).closest(".alacartReportListItem");
                            var holdingFees = $(report).find(".holdingFees").val();
                            var newHoldingFees = (qty * (Number(String(holdingFees).replace('$', '')))).toFixed(2);
                            $(report).find(".holdingFeesTxt").text("$" + newHoldingFees);
                        }
                        setTotalPrice(rptPrice);
                    }
                    UpdateStateCriminalMultiselect();
                    UpdateCountyCriminalMultiselect();
                    UpdateCountyCivilMultiselect();
                    UpdateFederalCriminalMultiselect();
                });                
            }

            function SetStateCriminalMultiselectChangeEvent()
            {
                $("#addOnSearches").find('#divStateCriminal .dropdown-menu a').on('click', function (event) {
                    var $target = $(event.currentTarget),
                       val = $target.attr('data-stateid'),
                       $inp = $target.find('input');

                    if ($.inArray(val, StateCriminalSelectList) > -1) {
                        var index = $.inArray(val, StateCriminalSelectList);
                        StateCriminalSelectList.splice(index, 1);
                        $inp.prop('checked', false);
                    } else {
                        StateCriminalSelectList.push(val);
                        $inp.prop('checked', true);
                    }

                    var currentAlacartReport = $("#addOnSearches").find('#divStateCriminal').closest(".alacartReportListItem");

                    var verificationErrorCount = VerifyStateCriminalRptQtyAndStatesSelected(val, $inp);

                    var reportId = $(currentAlacartReport).find('.dropdown-menu').attr("data-report-id");
                    var reportPrice = parseFloat($(currentAlacartReport).find('.dropdown-menu').attr("data-report-price"));

                    var accessPrice = 0;

                    $("#addOnSearches").find('#divStateCriminal .dropdown-menu').find("input:checked").each(function () {
                        accessPrice += parseFloat($(this).parent().attr("data-value"));
                    });

                    $(currentAlacartReport).find('.dropdown-menu').parent().find(".clsPrice").text("$" + accessPrice.toFixed(2));

                    var rptPrice = parseFloat($("#hdnPlanPrice").val());
                    setTotalPrice(rptPrice);

                    $("#hdnReportList").val($("#addOnSearches").html());
                    $("#hdnStateCriminalSelectList").val(StateCriminalSelectList);

                    $(event.target).blur();
                    //$("#lblStateCriminalError").text("");
                    return false;
                });
                UpdateStateCriminalMultiselect();
            }

            function SetCountyCriminalMultiselectChangeEvent() {
                              

                $("#addOnSearches").find('#divStateCounty .dropdown-menu a').on('click', function (event) {                    
                    var $target = $(event.currentTarget),
                       val = $target.attr('data-countyid'),
                       $inp = $target.find('input')
                       txtVal = $target.text().trim().substring(0, $target.text().trim().indexOf("(",0)).trim();
                       
                    if ($.inArray(val, StateCountySelectList) > -1) {
                        var index = $.inArray(val, StateCountySelectList);
                        StateCountySelectList.splice(index, 1);
                        $inp.prop('checked', false);
                        $("#lblselectedStateCounties").text($("#lblselectedStateCounties").text().replace(txtVal + ",", ""));
                    } else {
                        StateCountySelectList.push(val);
                        $inp.prop('checked', true);
                        $("#lblselectedStateCounties").text($("#lblselectedStateCounties").text() + txtVal + ", ");
                    }

                    var currentAlacartReport = $("#addOnSearches").find('#divStateCounty').closest(".alacartReportListItem");

                    var verificationErrorCount = VerifyCountyCriminalRptQtyAndStatesSelected(val, $inp);

                    var reportId = $(currentAlacartReport).find('.dropdown-menu').attr("data-report-id");
                    var reportPrice = parseFloat($(currentAlacartReport).find('.dropdown-menu').attr("data-report-price"));

                    var accessPrice = 0;

                    $("#addOnSearches").find('#divStateCounty .dropdown-menu').find("input:checked").each(function () {
                        accessPrice += parseFloat($(this).parent().attr("data-value"));
                    });

                    $(currentAlacartReport).find('.dropdown-menu').parent().find(".clsPrice").text("$" + accessPrice.toFixed(2));

                    var rptPrice = parseFloat($("#hdnPlanPrice").val());
                    setTotalPrice(rptPrice);

                    $("#hdnReportList").val($("#addOnSearches").html());
                    $("#hdnCountyCriminalSelectList").val(StateCountySelectList);

                    $(event.target).blur();
                    $("#addOnSearches").find('#divStateCounty .dropdown-menu').hide("slow");
                    $("#addOnSearches").find('#divStateCounty .searchFiltertxt').val("");
                    $("#addOnSearches").find('#divStateCounty .searchFiltertxt').keyup();
                    //$("#lblStateCriminalError").text("");
                    return false;
                });
                UpdateCountyCriminalMultiselect();
            }            

            function SetDropdownFilterEvents() {
                $("#addOnSearches").find(".searchFiltertxt").focusin(function () {                    
                    $(this).parent().find('.dropdown-menu').show();
                });

                $("#addOnSearches").find(".searchFiltertxt").focusout(function () {
                    setTimeout(function (Jthis) {
                        $(Jthis).parent().find('.dropdown-menu').hide();
                    }, 1000, this);
                });
                
                $("#addOnSearches").find(".searchFiltertxt").keyup(function () {
                    function timer(Jthis) {
                        var filterText = $(Jthis).val();
                        var $ddl = $(Jthis).closest(".button-group").find(".dropdown-menu").html($("#hdnCountyCriminalList").val());
                        var items = $($ddl).find(".liParent");

                        var exp = new RegExp(filterText, "i");
                        var arr = $.grep(items,
                            function (n) {
                                return exp.test($(n).text().split(' ')[0]);
                            });

                        if (arr.length > 0) {
                            $ddl.html("");
                            //countItemsFound(arr.length);
                            $.each(arr, function () {
                                $ddl.append(this);
                                //$ddl.get(0).selectedIndex = 0;
                            });
                            if ("countyCriminal" === $(Jthis).attr("data-searchtype")) {
                                SetCountyCriminalMultiselectChangeEvent();
                            }
                            else {
                                SetCountyCivilMultiselectChangeEvent();
                            }
                            $ddl.show();
                        }
                        else {
                            //countItemsFound(arr.length);
                            $ddl.append("<li>No Items Found</li>");
                            $ddl.show();
                        }
                    };
                    setTimeout(timer(this), 2000);
                });

                //$("#addOnSearches").find(".btnDropDownMenu").click(function () {
                //    debugger;
                //    $(this).parent().find(".dropdown-menu").hide("fast");
                //    $(this).parent().find(".searchFiltertxt").val("");
                //    setTimeout(function () { $(this).parent().find(".searchFiltertxt").focus(); }, 100);
                //});
            }
            
            function SetCountyCivilMultiselectChangeEvent() {
                $("#addOnSearches").find('#divCivilCounty .dropdown-menu a').on('click', function (event) {                    
                    var $target = $(event.currentTarget),
                       val = $target.attr('data-countyid'),
                       $inp = $target.find('input')
                       txtVal = $target.text().trim().substring(0, $target.text().trim().indexOf("(", 0)).trim();

                    if ($.inArray(val, CivilCountySelectList) > -1) {
                        var index = $.inArray(val, CivilCountySelectList);
                        CivilCountySelectList.splice(index, 1);
                        $inp.prop('checked', false);
                        $("#lblselectedCivilCounties").text($("#lblselectedCivilCounties").text().replace(txtVal + ",", ""));
                    } else {
                        CivilCountySelectList.push(val);
                        $inp.prop('checked', true);
                        $("#lblselectedCivilCounties").text($("#lblselectedCivilCounties").text() + txtVal + ", ");
                    }

                    var currentAlacartReport = $("#addOnSearches").find('#divCivilCounty').closest(".alacartReportListItem");

                    var verificationErrorCount = VerifyCountyCivilRptQtyAndStatesSelected(val, $inp);

                    var reportId = $(currentAlacartReport).find('.dropdown-menu').attr("data-report-id");
                    var reportPrice = parseFloat($(currentAlacartReport).find('.dropdown-menu').attr("data-report-price"));

                    var accessPrice = 0;

                    $("#addOnSearches").find('#divCivilCounty .dropdown-menu').find("input:checked").each(function () {
                        accessPrice += parseFloat($(this).parent().attr("data-value"));
                    });

                    $(currentAlacartReport).find('.dropdown-menu').parent().find(".clsPrice").text("$" + accessPrice.toFixed(2));

                    var rptPrice = parseFloat($("#hdnPlanPrice").val());
                    setTotalPrice(rptPrice);

                    $("#hdnReportList").val($("#addOnSearches").html());
                    $("#hdnCountyCivilSelectList").val(CivilCountySelectList);

                    $(event.target).blur();
                    //$("#lblStateCriminalError").text("");
                    return false;
                });
                UpdateCountyCivilMultiselect();
            }

            function SetFederalCriminalMultiselectChangeEvent() {                
                $("#addOnSearches").find('#divStateFederal .dropdown-menu a').on('click', function (event) {
                    var $target = $(event.currentTarget),
                       val = $target.attr('data-federalid'),
                       $inp = $target.find('input');

                    if ($.inArray(val, StateFederalSelectList) > -1) {
                        var index = $.inArray(val, StateFederalSelectList);
                        StateFederalSelectList.splice(index, 1);
                        $inp.prop('checked', false);
                    } else {
                        StateFederalSelectList.push(val);
                        $inp.prop('checked', true);
                    }

                    var currentAlacartReport = $("#addOnSearches").find('#divStateFederal').closest(".alacartReportListItem");

                    var verificationErrorCount = VerifyFederalCriminalRptQtyAndStatesSelected(val, $inp);

                    var reportId = $(currentAlacartReport).find('.dropdown-menu').attr("data-report-id");
                    var reportPrice = parseFloat($(currentAlacartReport).find('.dropdown-menu').attr("data-report-price"));

                    var accessPrice = 0;

                    $("#addOnSearches").find('#divStateFederal .dropdown-menu').find("input:checked").each(function () {
                        accessPrice += parseFloat($(this).parent().attr("data-value"));
                    });

                    $(currentAlacartReport).find('.dropdown-menu').parent().find(".clsPrice").text("");//"$" + accessPrice.toFixed(2)

                    var rptPrice = parseFloat($("#hdnPlanPrice").val());
                    setTotalPrice(rptPrice);

                    $("#hdnReportList").val($("#addOnSearches").html());
                    $("#hdnFederalCriminalSelectList").val(StateFederalSelectList);

                    $(event.target).blur();
                    //$("#lblStateCriminalError").text("");
                    return false;
                });
                UpdateFederalCriminalMultiselect();
            }

            function VerifyStateCriminalRptQtyAndStatesSelected(val, $inp)
            {
                var verificationErrorCount = 0;
                if (0 < $("#addOnSearches").find('#divStateCriminal .dropdown-menu').length) {
                    var currentAlacartReport = $("#addOnSearches").find('#divStateCriminal .dropdown-menu').closest(".alacartReportListItem");
                    var maxAllowedQty = Number($(currentAlacartReport).find(".clsQuantity").attr("max"));
                    var selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
                    var selectedQty = Number($(currentAlacartReport).find(".clsQuantity").val());



                    if (maxAllowedQty < selectedStatesCount) {
                        var index = $.inArray(val, StateCriminalSelectList);
                        StateCriminalSelectList.splice(index, 1);
                        $inp.prop('checked', false);
                        $("#lblStateCriminalError").text("You can select max " + maxAllowedQty + " states.");
                        selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
                        verificationErrorCount++;
                        return verificationErrorCount;
                    }

                    if ($.inArray("State Criminal Records", listOfReports) > -1) {
                        if (0 >= StateCriminalSelectList.length || 0 >= $("#addOnSearches").find('#divStateCriminal .dropdown-menu').find("input:checked").length) {
                            $("#lblStateCriminalError").text("You need to select state for this Add-On Search");
                            $(currentAlacartReport).find(".dropdown-toggle").focus();
                            verificationErrorCount++;
                            return verificationErrorCount;
                        }
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

            function VerifyCountyCriminalRptQtyAndStatesSelected(val, $inp) {              
                var verificationErrorCount = 0;
                if (0 < $("#addOnSearches").find('#divStateCounty .dropdown-menu').length) {
                    var currentAlacartReport = $("#addOnSearches").find('#divStateCounty .dropdown-menu').closest(".alacartReportListItem");
                    var maxAllowedQty = Number($(currentAlacartReport).find(".clsQuantity").attr("max"));
                    var selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
                    var selectedQty = Number($(currentAlacartReport).find(".clsQuantity").val());



                    if (maxAllowedQty < selectedStatesCount) {
                        var index = $.inArray(val, StateCountySelectList);
                        StateCountySelectList.splice(index, 1);
                        $inp.prop('checked', false);
                        $("#lblCountyCriminalError").text("You can select max " + maxAllowedQty + " counties.");
                        var txtVal = $($inp).parent().text().trim().substring(0, $($inp).parent().text().trim().indexOf("(", 0)).trim();
                        $("#lblselectedStateCounties").text($("#lblselectedStateCounties").text().replace(txtVal + ",", ""));
                        selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
                        verificationErrorCount++;
                        return verificationErrorCount;
                    }

                    if ($.inArray("County Criminal Courthouse Search", listOfReports) > -1) {
                        if (0 >= StateCountySelectList.length || 0 >= $("#addOnSearches").find('#divStateCounty .dropdown-menu').find("input:checked").length) {
                            $("#lblCountyCriminalError").text("You need to select County for this Add-On Search");
                            $(currentAlacartReport).find(".dropdown-toggle").focus();
                            verificationErrorCount++;
                            return verificationErrorCount;
                        }
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

            function VerifyCountyCivilRptQtyAndStatesSelected(val, $inp) {               
                var verificationErrorCount = 0;
                if (0 < $("#addOnSearches").find('#divCivilCounty .dropdown-menu').length) {
                    var currentAlacartReport = $("#addOnSearches").find('#divCivilCounty .dropdown-menu').closest(".alacartReportListItem");
                    var maxAllowedQty = Number($(currentAlacartReport).find(".clsQuantity").attr("max"));
                    var selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
                    var selectedQty = Number($(currentAlacartReport).find(".clsQuantity").val());



                    if (maxAllowedQty < selectedStatesCount) {
                        var index = $.inArray(val, CivilCountySelectList);
                        CivilCountySelectList.splice(index, 1);
                        $inp.prop('checked', false);
                        $("#lblCountyCivilError").text("You can select max " + maxAllowedQty + " counties.");
                        var txtVal = $($inp).parent().text().trim().substring(0, $($inp).parent().text().trim().indexOf("(", 0)).trim();
                        $("#lblselectedCivilCounties").text($("#lblselectedStateCounties").text().replace(txtVal + ",", ""));
                        selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
                        verificationErrorCount++;
                        return verificationErrorCount;
                    }

                    if ($.inArray("County Civil Courthouse Search", listOfReports) > -1) {
                        if (0 >= CivilCountySelectList.length || 0 >= $("#addOnSearches").find('#divCivilCounty .dropdown-menu').find("input:checked").length) {
                            $("#lblCountyCivilError").text("You need to select County for this Add-On Search");
                            $(currentAlacartReport).find(".dropdown-toggle").focus();
                            verificationErrorCount++;
                            return verificationErrorCount;
                        }
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

            function VerifyFederalCriminalRptQtyAndStatesSelected(val, $inp) {
                var verificationErrorCount = 0;
                if (0 < $("#addOnSearches").find('#divStateFederal .dropdown-menu').length) {
                    var currentAlacartReport = $("#addOnSearches").find('#divStateFederal .dropdown-menu').closest(".alacartReportListItem");
                    var maxAllowedQty = Number($(currentAlacartReport).find(".clsQuantity").attr("max"));
                    var selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
                    var selectedQty = Number($(currentAlacartReport).find(".clsQuantity").val());



                    if (maxAllowedQty < selectedStatesCount) {
                        var index = $.inArray(val, StateFederalSelectList);
                        StateFederalSelectList.splice(index, 1);
                        $inp.prop('checked', false);
                        $("#lblFederalCriminalError").text("You can select max " + maxAllowedQty + " districts.");
                        selectedStatesCount = $(currentAlacartReport).find("input:checked").length;
                        verificationErrorCount++;
                        return verificationErrorCount;
                    }

                    if ($.inArray("Federal Criminal Courthouse Search", listOfReports) > -1) {
                        if (0 >= StateFederalSelectList.length || 0 >= $("#addOnSearches").find('#divStateFederal .dropdown-menu').find("input:checked").length) {
                            $("#lblFederalCriminalError").text("You need to select districts for this Add-On Search");
                            $(currentAlacartReport).find(".dropdown-toggle").focus();
                            verificationErrorCount++;
                            return verificationErrorCount;
                        }
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

            function setTotalPrice(rptPrice) {
                var tempTotalPrice = 0;
                $(listOfReportsPrice).each(function (key, value) {
                    tempTotalPrice += parseFloat(listOfReportsPrice[key] * listOfReportQty[key]);
                });

                var holdingFees = 0;
                $(".holdingFeesTxt").each(function () {
                    holdingFees += (Number(String($(this).text()).replace('$', '')));
                });                
                //var holdingFees = 0;
                //holdingFees = 25.00 * $(".holdingFees").length;
                var accessPrice = 0;
                $("#addOnSearches").find('.dropdown-menu').find("input:checked").each(function () {
                    accessPrice += parseFloat($(this).parent().attr("data-value"));
                });

                var creditReportInspectionCharges = 0;
                $(".inspectionFees").each(function () {
                    creditReportInspectionCharges += (Number($(this).val()));
                });

                totalPrice = parseFloat(tempTotalPrice.toFixed(2));
                totalPrice += parseFloat(rptPrice);
                totalPrice += parseFloat(holdingFees);
                totalPrice += parseFloat(accessPrice);
                totalPrice += parseFloat(creditReportInspectionCharges);

                $("#hdnTotalPrice").val(totalPrice.toFixed(2));
                $("#totalPrice").html("$" + totalPrice.toFixed(2));
            }
            
            $("#btnContinue").click(function () {
                var verificationErrorCount = VerifyStateCriminalRptQtyAndStatesSelected('', '');
                verificationErrorCount += VerifyCountyCriminalRptQtyAndStatesSelected('', '');
                verificationErrorCount += VerifyFederalCriminalRptQtyAndStatesSelected('', '');
                verificationErrorCount += VerifyCountyCivilRptQtyAndStatesSelected('', '');
                if(0 < verificationErrorCount)
                {                   
                    return false;
                }
            });

            PackageDescriptionTextWrap();                        

        });

        function PackageDescriptionTextWrap() {            
            $('.less').each(function () {
                if ($(this)[0].scrollHeight <= 40) {
                    $(this).closest(".row").find(".text-size").hide();
                }
            });

            $(".text-size").each(function () {
                $(this).click(function () {
                    $(this).closest(".row").find("p").toggleClass("less");
                    if ($(this).html() == "Read more...") {
                        $(this).html("Read less...");
                    }
                    else {
                        $(this).html("Read more...");
                    }
                });
            });
        }

        //function SetAccessFees(Jthis) {
        //    var accessFees = parseFloat($(Jthis).val()).toFixed(2);
        //    $(Jthis).parent().find(".clsPrice").text("$" + accessFees);
        //}       
        
    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hdnReport" runat="server" />
    <asp:HiddenField ID="hdnTotalPrice" runat="server" />
    <asp:HiddenField ID="hdnReportList" runat="server" />
    <asp:HiddenField ID="hdnPlanPrice" runat="server" value="0"/>
    <asp:HiddenField ID="hdnContinueBtnClick" runat="server" />
    <asp:HiddenField ID="hdnReportQty" runat="server" />
    <asp:HiddenField ID="hdnStateCriminalSelectList" runat="server" />
    <asp:HiddenField ID="hdnStateCriminalList" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hdnCountyCriminalSelectList" runat="server" />
    <asp:HiddenField ID="hdnCountyCriminalList" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hdnCountyCivilSelectList" runat="server" />
    <asp:HiddenField ID="hdnCountyCivilList" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hdnFederalCriminalSelectList" runat="server" />
    <asp:HiddenField ID="hdnFederalCriminalList" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hdnIsCreditReportAuditingChargesPaid" runat="server" ClientIDMode="Static" />
    <select id="ddlStates" runat="server" style="display:none"></select>
    <select id="ddlCounties" runat="server" style="display:none"></select>    
    
    <section class="eknowid-bg">
        <div class="container" style="padding-top: 110px;">
            <ProgressBar:ProgressBar ID="ProgressBar" runat="server" />            
            <div class="row">
                <div class="col-xs-12">
                    <div class="row">
                        <div class="col-md-7 customize_bg" id="divUpgradePackageList">
                            <div class="custom_left">
                                <div class="text-left">
                                    <h4>Upgrade Package</h4>
                                </div>
                                <div class="col-lg-12" style="width: 100%; height: auto; background-color: #424242; padding: 5px; color: #ffffff; margin-bottom: 15px;">
                                    Criminal Searches 
                                </div>
                                <asp:Repeater ID="reptAlacarteCriminalReport" runat="server">
                                    <ItemTemplate>
                                        <div class="row form-group border-bottom padding-btm-10">

                                            <div class="pull-left col-md-12">
                                                <div>
                                                    <span>
                                                        <input type="checkbox" id='<%# Eval("ReportId") %>' data-report-name='<%# Eval("Name") %>' data-report-price='<%# Eval("Price") %>' 
                                                            data-report-ismulticheckenabled='<%# Eval("IsMultipleCheckEnabled") %>' data-report-maxverificationcount='<%# Eval("MaxVerificationCount") %>'/>
                                                    </span>
                                                    <span style="margin-left: 10px; font-weight:bold;"><%# Eval("Name") %>   ( <%# Eval("TurnaroundTime") %> )</span>
                                                    <span style="font-weight:bold; min-width: 60px;" class="pull-right">$<%# Eval("Price","{0:0.00}") %></span>
                                                    <span class='text-size'>Read more...</span>
                                                    <p style="margin-left: 25px; padding-top: 10px; font-size: 14px; font-family: sans-serif; text-align: justify; max-width: 80%;" 
                                                        class='less <%#Eval("ReportId") %>'><%# Eval("Description") %></p>
                                                    <%--<div style='margin-left: 25px; padding: 0px; font-size: 14px; font-family: sans-serif; text-align: justify; max-width: 80%;'>
                                                        
                                                    </div>--%>
                                                </div>
                                            </div>
                                            <%--<div class="col-md-1  pull-right">
                                                <img src="../Images/red_arrow_down.png" data-attribute="<%# Eval("ReportId") %>" style="cursor: pointer;" />
                                            </div>--%>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>



                                <div class="col-lg-12" style="width: 100%; height: auto; background-color: #424242; padding: 5px; color: #ffffff; margin-bottom: 15px;">
                                    Verification Searches
                                </div>
                                <asp:Repeater ID="reptAlacarteVerificationReport" runat="server">
                                    <ItemTemplate>
                                        <div class="row form-group border-bottom padding-btm-10">

                                            <div class="pull-left col-md-12">
                                                <div>
                                                    <span>
                                                        <input type="checkbox" id='<%# Eval("ReportId") %>' data-report-name='<%# Eval("Name") %>' data-report-price='<%# Eval("Price") %>' 
                                                            data-report-ismulticheckenabled='<%# Eval("IsMultipleCheckEnabled") %>' data-report-maxverificationcount='<%# Eval("MaxVerificationCount") %>'/>
                                                    </span>
                                                    <span style="margin-left: 10px; font-weight:bold"><%# Eval("Name") %>   ( <%# Eval("TurnaroundTime") %> )</span>
                                                    <span style="font-weight:bold; min-width: 60px;" class="pull-right">$<%# Eval("Price","{0:0.00}") %></span>
                                                    <span class='text-size'>Read more...</span>
                                                    <p style="margin-left: 25px; padding-top: 10px; font-size: 14px; font-family: sans-serif; text-align: justify; max-width: 80%;" 
                                                        class='less <%#Eval("ReportId") %>'><%# Eval("Description") %></p>
                                                   <%-- <div style='margin-left: 25px; padding: 0px; font-size: 14px; font-family: sans-serif; text-align: justify; max-width: 80%;'>
                                                        
                                                    </div>--%>
                                                </div>
                                            </div>
                                           <%-- <div class="col-md-1  pull-right">
                                                <img src="../Images/red_arrow_down.png" data-attribute="<%# Eval("ReportId") %>" style="cursor: pointer;" />
                                            </div>--%>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>


                                <div class="col-lg-12" style="width: 100%; height: auto; background-color: #424242; padding: 5px; color: #ffffff; margin-bottom: 15px;">
                                    Miscellaneous Searches
                                </div>
                                <asp:Repeater ID="reptAlacarteMiscellaneousReport" runat="server">
                                    <ItemTemplate>
                                        <div class="row form-group border-bottom padding-btm-10">

                                            <div class="pull-left col-md-12">
                                                <div>
                                                    <span>
                                                        <input type="checkbox" id='<%# Eval("ReportId") %>' data-report-name='<%# Eval("Name") %>' data-report-price='<%# Eval("Price") %>' 
                                                            data-report-ismulticheckenabled='<%# Eval("IsMultipleCheckEnabled") %>' data-report-maxverificationcount='<%# Eval("MaxVerificationCount") %>'/>
                                                    </span>
                                                    <span style="margin-left: 10px; font-weight:bold"><%# Eval("Name") %>   ( <%# Eval("TurnaroundTime") %> )</span>
                                                    <span style="font-weight:bold; min-width: 60px;" class="pull-right">$<%# Eval("Price","{0:0.00}") %></span>
                                                    <span class='text-size'>Read more...</span>
                                                    <p style="margin-left: 25px; padding-top: 10px; font-size: 14px; font-family: sans-serif; text-align: justify; max-width: 80%;" 
                                                        class='less <%#Eval("ReportId") %>'><%# Eval("Description") %></p>
                                                   <%-- <div style='margin-left: 25px; padding: 0px; font-size: 14px; font-family: sans-serif; text-align: justify; max-width: 80%;'>
                                                        
                                                    </div>--%>
                                                </div>
                                            </div>
                                           <%-- <div class="col-md-1  pull-right">
                                                <img src="../Images/red_arrow_down.png" data-attribute="<%# Eval("ReportId") %>" style="cursor: pointer;" />
                                            </div>--%>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="col-lg-1"></div>
                        <div class="col-md-4" style="margin-left: 30px;">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="order_summary">
                                        <div class="order_summary_title2">
                                            <h4 class="pull-left"><span class="cart"></span><span>order summary</span></h4>
                                        </div>
                                        <div class="col-xs-12">
                                            <div class="order_summary_desc">
                                                <div class="pull-left">
                                                    <h4>
                                                        <asp:Literal ID="litePlanName" runat="server"></asp:Literal>
                                                        Plan </h4>
                                                </div>
                                                <div class="pull-right">
                                                    <div class="price" id="reportPrice">
                                                        $<asp:Label ID="lblPrice" runat="server" ClientIDMode="Static"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                                <p>Package Includes</p>
                                            </div>
                                        </div>
                                        <div class="summry_list">
                                            <ul class="list_2" id="defaultSearches">
                                                <asp:Repeater ID="rptrPlnRprts" runat="server">
                                                    <ItemTemplate>
                                                        <li><%# Container.DataItem.ToString() %></li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                            <div class="clearfix"></div>
                                            <p style="border: 1px solid #eaeaea; width: 100%;"></p>
                                        </div>
                                        <div class="summry_list">
                                            <h4 style="margin-left: 35px;">Add-On Searches</h4>
                                            <ul class="list_2" id="addOnSearches">
                                            </ul>
                                        </div>
                                        <div class="col-xs-12">
                                            <div class="order_summary_desc">
                                                <div class="pull-left">
                                                    <h4>Total </h4>
                                                </div>
                                                <div class="pull-right">
                                                    <div class="price">
                                                        <asp:Label ID="totalPrice" runat="server" ClientIDMode="Static"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <label id="lblError" style="color:red"></label>
                                        </div>

                                        <div class="order_summary_title2">
                                            <div class="pull-right">
                                                <asp:Button ID="btnContinue" ClientIDMode="Static" runat="server" Text="Continue" CssClass="btn btn-default btnSignup" OnClick="btnOrderContinue_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="stateCriminalList" style="display: none">
                <div id="divStateCriminal" class="container" style="width:100%;">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="button-group" style="margin-left:5px;"">Access Fees
                                <button style="margin-left:20px;" type="button" class="btn-sm dropdown-toggle" data-toggle="dropdown"><label class="">Select State</label> <span style="color: #666666;" class="caret"></span></button>
                                <ul class="dropdown-menu" style="height:200px; overflow-y:scroll; overflow-x:hidden; background-color:#e5e5e5 !important; left:100px; padding:0px;">
                                </ul><span style="float:right; margin-right:25px;" class='clsPrice'>$0.00</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="stateCountyList" style="display: none">
                <div id="divStateCounty" class="container" style="width:100%;">
                    <div class="row">
                        <label id="lblselectedStateCounties" style="margin-left:105px;"></label>
                        <div class="col-lg-12">
                            <div class="button-group" style="margin-left:5px;"">Access Fees
                                <button style="margin-left:20px; padding: 0px 5px 0px 0px; display:none;" type="button" class="btn-sm dropdown-toggle btnDropDownMenu" data-toggle="dropdown">
                                    <span style="color: #666666;" class="caret"></span>
                                </button><input data-searchtype="countyCriminal" class="searchFiltertxt" type="text" style="margin-left:20px; border-style:none; color:black; padding: 0px 5px 0px 0px;" placeholder="Search State..." />
                                <ul class="dropdown-menu" style="height:200px; overflow-y:scroll; overflow-x:hidden; background-color:#e5e5e5 !important; left:100px; padding:10px;">
                                </ul><span style="float:right; margin-right:25px;" class='clsPrice'>$0.00</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="stateCivilList" style="display: none">
                <div id="divCivilCounty" class="container" style="width:100%;">
                    <div class="row">
                        <label id="lblselectedCivilCounties" style="margin-left:105px;"></label>
                        <div class="col-lg-12">
                            <div class="button-group" style="margin-left:5px;"">Access Fees
                                <button style="margin-left:20px; padding: 0px 5px 0px 0px; display:none;" type="button" class="btn-sm dropdown-toggle btnDropDownMenu" data-toggle="dropdown">
                                    <span style="color: #666666;" class="caret"></span>
                                </button><input data-searchtype="countyCivil" class="searchFiltertxt" type="text" style="margin-left:20px; border-style:none; color:black; padding: 0px 5px 0px 0px;" placeholder="Search State..." />
                                <ul class="dropdown-menu" style="height:200px; overflow-y:scroll; overflow-x:hidden; background-color:#e5e5e5 !important; left:100px; padding:10px;">
                                </ul><span style="float:right; margin-right:25px;" class='clsPrice'>$0.00</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="stateFederalList" style="display: none">
                <div id="divStateFederal" class="container" style="width:100%;">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="button-group" style="margin-left:5px;"">Access Fees
                                <button style="margin-left:20px;" type="button" class="btn-sm dropdown-toggle" data-toggle="dropdown"><label class="">Select State</label> <span style="color: #666666;" class="caret"></span></button>
                                <ul class="dropdown-menu" style="height:200px; overflow-y:scroll; overflow-x:hidden; background-color:#e5e5e5 !important; left:100px; padding:10px;">
                                </ul><span style="float:right; margin-right:25px;" class='clsPrice'>$0.00</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
