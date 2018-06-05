<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs"
    Inherits="eknowID.Pages.AdminDashboard" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">           
        .label {
            float: inherit;
            color: #333;
            max-width: inherit;
            font-weight: unset;
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            font-size: 14px;
        }
        #refundModal .form-control
        {
            border-style:none
        }
        td label{
            float:unset;
            vertical-align:middle;
            margin-left:10px;
        }

        .ellipsis-text {
            white-space: nowrap;
            width: 140px;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        #reportIncluded, #alacarteReportIncluded, #additionalChragesIncluded  {
            font-size: 15px;
            margin-left: 16px;
        }

        /*#alacarteReportIncluded {
            font-size: 15px;
            margin-left: 16px;
        }*/

        .btn {
            background: #fb5240 none repeat scroll 0 0;
            color: #fff;
            padding: 4px;
        }

            .btn:hover {
                background: #fb5240 none repeat scroll 0 0;
                border-color: #fff;
            }

            .btn:focus {
                background: #fb5240 none repeat scroll 0 0;
                border-color: #fff;
            }

        .visible {
            display: inline-block;
        }

        .disable {
            display: none;
        }

        table.dataTable thead .sorting,
        table.dataTable thead .sorting_asc,
        table.dataTable thead .sorting_desc {
            background: none;
        }

        .userPanel-error {
            background-color: #f2dede;
            color: #a94442;
            font-size: 30px;
            height: 200px;
            padding: 50px;
            margin-top: 50px;
        }

        .btn-edit {
            background-color: #337ab7;
        }

            .btn-edit:active {
                background-color: #337ab7;
            }

            .btn-edit:hover {
                background-color: #337ab7;
            }


        .error {
            color: #a94442;
        }

        .currencyinput input {
            border: 0;
        }

        .popover {
            min-width: 200px;
            min-height:60px;
            background-color:rgba(255, 255, 255, 0.9);
            padding:0px;
        }
        .popover-title{
            background-color: rgba(128,128,128,0.9);
            color: white;
        }
        .popover-content
        {
            padding:0px;
            background-color:white;
        }
        .selected{
            background-color:#e3e3e3;
        }
    </style>

    <script type="text/javascript">

        var selectedRow = 0, selectedColumn = 0, isSuccess = false;

        //set default value.
        $("#hdnIsAdmin").val(null);

        function OpenCompanyProfileModal() {
            $("body").css("overflow", "hidden");
            $("#compnayErrorModal").modal('hide');
            $("#ModalCompnayProfile").modal('show');
        }


        function deleteUser(userId, isAdmin) {

            if (isAdmin === "1" || isAdmin === "2") // is_SuperAdmin
            {
                alert("This User can not be deleted because it's SUPER ADMIN.");
                return;
            }

            if (confirm("Are you sure you want to delete user?")) {

                var userDetail = {
                    userId: userId,
                };

                $.ajax({
                    type: "POST",
                    url: "AdminDashboard.aspx/DeleteUserByAdmin",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(userDetail),
                    dataType: "json",
                    async: false,
                    success: function (result) {
                        if (result.d) {
                            alert("User Deleted successfully.");
                            location.reload(true);
                        }
                        else
                            alert("Error deleting user, Please try again later.");
                    }
                });

            }
            return false;
        }

        //This function is used to send pdf to requestor email account
        function SendPdfToEmail(orderId) {

            $("#overlay").show();

            var orderDetail = {
                orderId: orderId
            };

            $.ajax({
                type: "POST",
                url: "AdminDashboard.aspx/SendPdfToEmail",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(orderDetail),
                dataType: "json",
                async: false,
                success: function (result) {
                    $("#overlay").hide();
                    if (result.d)
                        alert("Email send success!");
                    else
                        alert("Email send error. Please try again!");
                }
            });
        }

        //This function is used for view report status like pending or completed for view pdf
        function ViewReportStatus(orderId) {
            var orderDetail = {
                orderId: orderId
            };
            $("#reportStatusViewModal").find("#statusReport_OrderId").val(orderId);
            $.ajax({
                type: "POST",
                url: "AdminDashboard.aspx/GetOrderStatus",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(orderDetail),
                dataType: "json",
                async: false,
                success: function (result) {
                    if (result == null) {
                        alert("Something went wrong. Please try again...");
                        return;
                    }

                    $("#iframeOrder").attr('src', result.d.URL);
                    $("#reportStatusViewModal").modal("show"); //show modal
                }
            });
        }       

        //This function is used for view included reports.
        function SelectedReportView(orderId, applicantName, CompanyName, dateOrdered) {           
            //Bind data
            var orderDetail = {
                orderId: orderId
            };
            $("#lblApplicantName").text(applicantName);
            $("#lblDateOrdered").text(dateOrdered);
            $("#lblCompanyName").text(CompanyName);
            $("#reportViewModal").find("#alacarteReportIncludedHeader").show();
            $("#reportViewModal").find("#alacarteReportIncludedFooter").show();
            $("#reportViewModal").find("#additionalChragesIncludedHeader").show();
            $("#reportViewModal").find("#additionalChragesIncludedFooter").show();

            var totalPaid = 0;
            var planTotal = 0;
            var discountAmt = 0;
            var alaCarteTotal = 0;           
            var OtherCharges = 0;
            var HoldingFees = 0;
            $.ajax({
                type: "POST",
                url: "AdminDashboard.aspx/GetIncludeReportList",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(orderDetail),
                dataType: "json",
                async: false,
                success: function (result) {

                    if (result === null || result.d === null) {
                        alert("Please try again...");
                        return;
                    }
                    
                    $("#reportIncluded").html("");
                    $("#alacarteReportIncluded").html("");
                    $("#additionalChragesIncluded").html("");
                    $("#litePackageName").text(result.d.PlanName);
                    $("#litePackageRate").text("$" + result.d.Rate.toFixed(2));
                    $("#lblPlanTotal").text("$" + result.d.Rate.toFixed(2));
                    $("#lblPlanDiscount").text(result.d.DiscountAmt == undefined ? "-" : "$" + result.d.DiscountAmt.toFixed(2));
                    //$("#lblAccessFees").text(result.d.AccessFees == undefined ? "-" : "$" + result.d.AccessFees.toFixed(2));
                    //$("#lblOtherCharges").text(result.d.ExtraCharges == undefined ? "-" : "$" + result.d.ExtraCharges.toFixed(2));
                    //$("#lblOtherCharges").attr("title", result.d.ChargesDescription)
                    planTotal = parseFloat(result.d.Rate);
                    discountAmt = parseFloat(result.d.DiscountAmt == undefined ? 0 : result.d.DiscountAmt);

                    $.each(result.d.ReportViewModal, function (key, value) {
                        $("#reportIncluded").append("<li><div class='col-xs-12'>" + value.ReportName + "</div></li>")
                        alaCarteTotal += parseFloat(value.Rate == undefined ? 0 : value.Rate);
                    });

                    $.each(result.d.AlacartViewModal, function (key, value) {
                        $("#alacarteReportIncluded").append("<li>"
                            + "<span style='float:right;'>" + "$" + (value.Rate * value.Qty).toFixed(2) + "</span>"
                            + "<div class='col-xs-8'>" + value.AlacartReprtName + "</div>"
                            + "<div class='col-xs-2'>" + value.Qty + "</div></li>")
                        //if ("Employment Verification" === value.AlacartReprtName || "Education Verification" === value.AlacartReprtName)
                        //{
                        //    HoldingFees += 25;
                        //}
                        alaCarteTotal += parseFloat(value.Rate == undefined ? 0 : (value.Rate * value.Qty));
                    });

                    if (0 >= result.d.AlacartViewModal.length)
                    {
                        $("#alacarteReportIncluded").html("");
                        $("#alacarteReportIncludedHeader").hide();
                        $("#alacarteReportIncludedFooter").hide();
                    }

                    $.each(result.d.AdditionalCharges, function (key, value) {
                        $("#additionalChragesIncluded").append("<li>"
                            + "<span style='float:right;'>" + "$" + (value.Amount).toFixed(2) + "</span>"
                            + "<div class='col-xs-10'>" + value.Description + "</div></li>")
                        OtherCharges += parseFloat(value.Amount == undefined ? 0 : (value.Amount));
                    });

                    if (0 >= result.d.AdditionalCharges.length) {
                        $("#additionalChragesIncluded").html("");
                        $("#additionalChragesIncludedHeader").hide();
                        $("#additionalChragesIncludedFooter").hide();
                    }

                    $("#lblPlanTotal").text("$" + (planTotal + alaCarteTotal + OtherCharges).toFixed(2));
                    totalPaid = ((planTotal + alaCarteTotal + OtherCharges + HoldingFees) - discountAmt);

                    $("#lblTotalPaid").text("$" + totalPaid.toFixed(2));
                    $("#reportViewModal").modal("show").css({"z-index":"2000"});
                    $("#submitExtracharges").attr("data-orderid", orderId);
                    return false; //prevent linkbutton postback.
                }
            });
        }

        //This function is used for refund process for an order
        function RefundProcess(jthis, gridId, orderId, transactionId, paidAmount, refundAmount, userId, userName, email, status) {
            $("#refundamountError").text("");
            var transactionAmount = (parseFloat(paidAmount) - parseFloat(refundAmount === "" ? 0 : refundAmount)).toFixed(4);
            //var refundTable = $('#' + gridId).DataTable();
            //var refundObj = refundTable.row($(jthis).parents('tr')).data();
            $("#refundModal").find("#lblName").text(userName);
            $("#refundModal").find("#lblemail").text(email);
            $("#refundModal").find("#lblTransactionId").text(transactionId);
            $("#refundModal").find("#lblTransactionAmount").text("$" + transactionAmount);
            $("#refundModal").find("#txtRefundAmount").val(transactionAmount);
            $("#refundModal").find("#hdnRefundUserId").val(userId);
            $("#refundModal").find("#txtNoteToBuyer").val("");
            $("#refundModal").find("#hdnRefundOrderId").val(orderId);
            $("#refundModal").find("#hdnRefundOrderStatus").val(status);
            $("#refundModal").find("#chkFullRefund").attr("checked", "checked");

            var refundInputs = $("#refundModal").find(".currencyinput ");

            refundInputs.css({
                "border-color": ""
            });
            $("#refundModal").find("#refundOrderDetails").click(function () {
                SelectedReportView(orderId, userName, '', '');
            });           
            $("#refundModal").modal("show");
            return false; //prevent linkbutton postback.
        }

        function SubmitRefund() {
            $("#overlay").show();
            $("#refundamountError").text("");
            var paidAmount = parseFloat($("#lblTransactionAmount").text().substring(1));
            var refundAmount = parseFloat($("#refundModal").find("#txtRefundAmount").val());
            var buyerNote = $("#refundModal").find("#txtNoteToBuyer").val().trim();

            if (refundAmount > paidAmount || refundAmount <= 0) {
                $("#refundamountError").html("Please enter valid amount to refund.");
                $("#overlay").hide();
                var txtRefund = $("#refundModal").find("#txtRefundAmount");
                txtRefund.focus();
                $(txtRefund).closest(".currencyinput").css({
                    "border-color": "red"
                });
                //alert("Please make sure that Refund Amount is less than Or equal to Paid Amount.");
                return;
            }
            if ("" === buyerNote) {
                $("#refundamountError").html("Please enter some remark/note for this transaction.");
                $("#overlay").hide();
                var txtNote = $("#refundModal").find("#txtNoteToBuyer");
                txtNote.focus();
                txtNote.css({
                    "border-color": "red"
                });
                //alert("Please make sure that Refund Amount is less than Or equal to Paid Amount.");
                return;
            }

            var refundUserId = $("#refundModal").find("#hdnRefundUserId").val();
            var orderId = $("#refundModal").find("#hdnRefundOrderId").val();
            var orderStatus = $("#refundModal").find("#hdnRefundOrderStatus").val();

            var refundModelData = { UserId: refundUserId, RefundAmount: refundAmount, BuyerNote: buyerNote, OrderId: orderId, OrderStatus: orderStatus };
            var refundModel = {
                "refundModel": refundModelData
            };



            $.ajax({
                type: "POST",
                url: "YourWallet.aspx/RefundToUsersWallet",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(refundModel),
                dataType: "json",
                async: true,
                success: function (result) {
                    $("#overlay").hide();
                    if (result.d.IsError) {
                        if (result.d.ErrorMessage !== '' || result.d.ErrorMessage.length !== 0) {
                            $("#errorMessage").fadeIn();
                            $("#errorMessage").animate({ top: '75px' }, "slow");

                            $("#ErrorDescription").text(result.d.ErrorMessage);
                            $("#errorMessage").fadeOut(10000);
                        }
                    }
                    else {
                        window.location.reload();
                    }
                    $("#refundModal").modal("hide");
                }
            });
        }

        function resetCssBorder(id) {
            var refundInputs = $(id).find(".currencyinput ");

            refundInputs.css({
                "border-color": ""
            });
        }

        function chkFullRefundOn_click(jthis) {
            if ($(jthis).is(":checked")) {
                $("#refundModal").find("#txtRefundAmount").attr("readonly", "readonly");
                $("#txtRefundAmount").val($("#lblTransactionAmount").text().substring(1));
                $("#refundModal").find(".readonly").css({
                    "background-color": "#eee"
                });
            } else {
                $("#refundModal").find("#txtRefundAmount").removeAttr("readonly");
                $("#refundModal").find(".readonly").css({
                    "background-color": ""
                });
            }

        }

        //end report view funcationlity
        function resendCandidateEmail(orderId) {

            if (!(confirm("Are you sure you want to resend candidate email?"))) return;

            var isSend = false;
            var candidateTable = $('#candidateGrid').DataTable();

            var orderId = { orderId: orderId };

            $.ajax({
                type: "POST",
                url: "AdminDashboard.aspx/ResentCandidateEmail",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(orderId),
                dataType: "json",
                async: false,
                success: function (result) {

                    if (result.d != null) {

                        alert("Applicant Email resend successfully.");

                        var div = "<div style='display:inline-block;width:120px;'>";
                        var resendLink = "<div class='pull-left'> <a href='#' onClick='resendCandidateEmail(" + orderId.orderId + ")' class='btn btn-primary'>Resend</a></div> <div class='pull-right'><span class='badge'>" + result.d.ResendEmailCount + " <span> </div> </div>";

                        $('#candidateGrid tbody').on('click', 'td', function () {
                            selectedRow = candidateTable.cell(this).index().row;
                            candidateTable.cell(selectedRow, 5).data("Order Placed ").draw();

                            candidateTable.cell(selectedRow, 0).data(div + resendLink).draw();
                        });

                    }
                    else {
                        alert("Applicant resend email failed.");
                    }
                }
            });

            return false;
        }

        function showUpdateCandidateEmailPopup(orderId, email) {

            $(".Error").html("");
            $('#candidateEmailModal').modal({ backdrop: 'static' });

            $("#hdnOrderId").val(orderId);
            $("#txtCandidateEmail").val(email);
            $("#candidateEmailModal").modal("show");

            var candidateTable = $('#candidateGrid').DataTable();

            $('#candidateGrid tbody').on('click', 'td', function () {

                selectedRow = candidateTable.cell(this).index().row;
                selectedColumn = candidateTable.cell(this).index().column;
            });
        } 

        function showUpdatePendingNotePopup(orderId, note, Jthis) {

            $(".Error").html("");
            $('#pendingNotesModal').modal({ backdrop: 'static' });

            $("#hdnOrderId").val(orderId);
            $("#txtPendingNotes").val($(Jthis).find(".pendingnotes").attr("data-original-title"));
            $("#pendingNotesModal").modal("show");

            //var candidateTable = $('#candidateGrid').DataTable();

            //$('#candidateGrid tbody').on('click', 'td', function () {

            //    selectedRow = candidateTable.cell(this).index().row;
            //    selectedColumn = candidateTable.cell(this).index().column;
            //});
        }

        

        function setUserRole(Jthis)
        {
            var selectedVal = $(Jthis).val();
            $("#hdnIsAdmin").val(selectedVal);
        }

        function showAdminEditPopup(userId, firstName, lastName, isAdmin) {
            //debugger;
            if (isAdmin == 1 || isAdmin == 2) {
                alert("This user is SUPER ADMIN and cannot be edited.");
                return false;
            }
            isAdmin = (isAdmin === "") ? 3 : isAdmin;
            $(".Error").html("");
            $('#adminEditModal').modal({ backdrop: 'static' });

            $("#hdnUserId").val(userId);

            $("#txtEditUserFirstName").val(firstName);
            $("#txtEditUserLastName").val(lastName);

            //$("#chkIsAdmin").prop("checked", (isAdmin == 2)); // is_Admin == 2 for enum

            $('[id*=radioLstSelectRole] input[value="' + isAdmin + '"]').attr("checked", "checked");

            if (isAdmin == 2)
                $("#hdnIsAdmin").val("2"); //// is_Admin == 2 for enum

            $("#adminEditModal").modal("show");
        }

        $(function () {

            //Clear error on keypress

            $("#txtCandidateEmail").keyup(function (e) {
                $(".Error").html("");
            });

            $("#txtEditUserFirstName").keyup(function (e) {
                $(".Error").html("");
            });

            $("#txtEditUserLastName").keyup(function (e) {
                $(".Error").html("");
            });

            //Update admin information
            $("#btnUpdateAdmin").click(function () {

                //check for empty field
                if ($("#txtEditUserFirstName").val() == "") {
                    $("#editUserError").html("Please enter user first name.");
                    return false;
                }

                if ($("#txtEditUserLastName").val() == "") {
                    $("#editUserError").html("Please enter user last name.");
                    return false;
                }

                //Bind data
                var user = {
                    "user": {
                        FirstName: $("#txtEditUserFirstName").val(),
                        LastName: $("#txtEditUserLastName").val(),
                        UserId: $("#hdnUserId").val(),
                        UserType: $("[id*=radioLstSelectRole] input:checked").val()
                    }
                };

                $.ajax({
                    type: "POST",
                    url: "AdminDashboard.aspx/UpdateUserDetail",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(user),
                    dataType: "json",
                    async: false,
                    success: function (result) {

                        if (result.d) {
                            $("#editUserError").html("Information Updated Successfully!");

                            setTimeout(function () {
                                location.href = "../pages/AdminDashboard.aspx";
                            }, 3000);
                        }
                        else {
                            $("#editUserError").html("Information updation error!");
                        }
                    }
                });
            });

            //update candidate email
            $("#btnUpdateEmail").click(function () {

                //check for empty field
                if ($("#txtCandidateEmail").val() == "") {
                    $("#msgEmailUpdate").html("Please enter candidate email address.");
                    return false;
                }

                //check for email validation
                var emailRegx = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

                if (!(emailRegx.test($("#txtCandidateEmail").val()))) {
                    $("#msgEmailUpdate").html("Please enter a valid email address.");
                    return false;
                }

                //Bind data
                var candidate = {
                    orderId: $("#hdnOrderId").val(),
                    email: $("#txtCandidateEmail").val()
                };

                $.ajax({
                    type: "POST",
                    url: "AdminDashboard.aspx/UpdateCandidateEmail",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(candidate),
                    dataType: "json",
                    async: false,
                    success: function (result) {
                        if (result.d) {
                            $("#msgEmailUpdate").html("Email updated successfully!");

                            var candidateTable = $('#candidateGrid').DataTable();

                            var editLink = '<span> <a href="#" onclick="showUpdateCandidateEmailPopup(' + $("#hdnOrderId").val() + ',\'' + $('#txtCandidateEmail').val() + '\')"> Edit </a> </span>';
                            candidateTable.cell(selectedRow, selectedColumn).data($("#txtCandidateEmail").val() + "   " + editLink).draw();
                        }
                        else {
                            $("#msgEmailUpdate").html("Email updation errors!");
                        }

                        setTimeout(function () { $("#candidateEmailModal").modal("hide"); }, 3000);
                    }
                });
            });

            $("#btnUpdatePendingNotes").click(function () {                
                //check for empty field
                if ($("#txtPendingNotes").val() == "") {
                    $("#msgPendingNotesUpdate").html("Please enter Pending note.");
                    return false;
                }                

                //Bind data
                var objPendingNote = {
                    orderId: $("#hdnOrderId").val(),
                    pendingNote: $("#txtPendingNotes").val()
                };

                $.ajax({
                    type: "POST",
                    url: "AdminDashboard.aspx/AddUpdateOrderPendingNotes",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(objPendingNote),
                    dataType: "json",
                    async: false,
                    success: function (result) {
                        if (result.d) {
                            $("#msgPendingNotesUpdate").html("Pending Note updated successfully!");
                            //$("#spanNote_" + $("#hdnOrderId").val()).attr("title", $("#txtPendingNotes").val());
                            $("#spanNote_" + $("#hdnOrderId").val()).attr("data-original-title", $("#txtPendingNotes").val());
                            //var candidateTable = $('#candidateGrid').DataTable();

                            //var editLink = '<span> <a href="#" onclick="showUpdateCandidateEmailPopup(' + $("#hdnOrderId").val() + ',\'' + $('#txtCandidateEmail').val() + '\')"> Edit </a> </span>';
                            //candidateTable.cell(selectedRow, selectedColumn).data($("#txtCandidateEmail").val() + "   " + editLink).draw();
                        }
                        else {
                            $("#msgPendingNotesUpdate").html("Pending note updation errors!");
                        }

                        setTimeout(function () { $("#pendingNotesModal").modal("hide"); }, 3000);
                    }
                });
            });

            //Active or deActive Admin.
            $(":checkbox").click(function () {
                if ($(this).is(':checked')) {
                    $("#hdnIsAdmin").val("2");
                }
                else {
                    $("#hdnIsAdmin").val(null);
                }
            });

            $("#reportStatusViewModal").on("hidden.bs.modal", function () {
                $("#iframeOrder").attr('src', "about:blank");
            });

            setTimeout(function () {                
                //$(".pendingnotes").popover(
                //{
                //    html: true,
                //    placement: 'left',
                //    title: '',
                //    trigger: 'hover',
                //    content: "Test Note"
                //});
                $(".pendingnotes").tooltip();
            },2000);
            
        });

        $(document).ready(function () {
            var isAdminUser = $("#hdnIsAdminUser").val();
            var isIncompleteOrders = $("#hdnIsIncompleteOrder").val();
            var sortArray = [0, 8, 9, 10, 11, 12, 13, 14];
            if (isAdminUser == "1") { // is_superAdmin or is_admin
                if (isIncompleteOrders === "1") {
                    sortArray = [0, 8, 9, 10, 11, 12, 13, 14];
               } 
            }
            else if (isAdminUser == "2") {                
                sortArray = [0, 8, 9, 10, 11, 12, 13];               
            }
            else {
                var sortArray = [0, 8, 9, 10, 11, 12];
            }

            $('#requestorGrid').DataTable();

            $('#candidateGrid').DataTable(
                {
                    "aoColumnDefs": [{ 'bSortable': false, 'aTargets': sortArray }],
                });

            $('#userGrid').DataTable({
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [4, 5, 6] }]
            });

            $('#selfUserGird').DataTable();
            $("#applicantUserGrid").DataTable();

            $('.dataTable tbody').on('click', 'tr', function () {
                if ($(this).hasClass('selected')) {                    
                    $(this).removeClass('selected');
                    $(this).closest(".dataTables_wrapper").find(".orderDetails").remove();
                    $("tr").css({ "height": "auto" });
                }
                else {                    
                    var table = $(this).closest(".dataTable").DataTable();
                    var tr = $(this);
                    table.$('tr.selected').removeClass('selected');
                    $(".orderDetails").remove();
                    $(this).addClass('selected');
                    $("tr").css({ "height": "auto" });

                    var orderId = $(tr).attr("data-orderid");
                    var orderDetail = {
                        orderId: orderId
                    };

                    $("#reportViewModal").find("#alacarteReportIncludedHeader").show();
                    $("#reportViewModal").find("#alacarteReportIncludedFooter").show();
                    $("#reportViewModal").find("#additionalChragesIncludedHeader").show();
                    $("#reportViewModal").find("#additionalChragesIncludedFooter").show();

                    var totalPaid = 0;
                    var planTotal = 0;
                    var discountAmt = 0;
                    var alaCarteTotal = 0;
                    var OtherCharges = 0;
                    var HoldingFees = 0;

                    $.ajax({
                        type: "POST",
                        url: "AdminDashboard.aspx/GetIncludeReportList",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(orderDetail),
                        dataType: "json",
                        async: false,
                        success: function (result) {

                            if (result === null || result.d === null) {
                                alert("Please try again...");
                                return;
                            }

                            
                            $("#reportIncluded").html("");
                            $("#alacarteReportIncluded").html("");
                            $("#additionalChragesIncluded").html("");
                            $("#litePackageName").text(result.d.PlanName);
                            $("#litePackageRate").text("$" + result.d.Rate.toFixed(2));
                            $("#lblPlanTotal").text("$" + result.d.Rate.toFixed(2));
                            $("#lblPlanDiscount").text(result.d.DiscountAmt == undefined ? "-" : "$" + result.d.DiscountAmt.toFixed(2));
                           
                            planTotal = parseFloat(result.d.Rate);
                            discountAmt = parseFloat(result.d.DiscountAmt == undefined ? 0 : result.d.DiscountAmt);

                            $.each(result.d.ReportViewModal, function (key, value) {
                                $("#reportIncluded").append("<li><div class='col-xs-12'>" + value.ReportName + "</div></li>")
                                alaCarteTotal += parseFloat(value.Rate == undefined ? 0 : value.Rate);
                            });

                            $.each(result.d.AlacartViewModal, function (key, value) {
                                $("#alacarteReportIncluded").append("<li>"
                                    + "<span style='float:right;'>" + "$" + (value.Rate * value.Qty).toFixed(2) + "</span>"
                                    + "<div class='col-xs-8'>" + value.AlacartReprtName + "</div>"
                                    + "<div class='col-xs-2'>" + value.Qty + "</div></li>")
                                //if ("Employment Verification" === value.AlacartReprtName || "Education Verification" === value.AlacartReprtName)
                                //{
                                //    HoldingFees += 25;
                                //}
                                alaCarteTotal += parseFloat(value.Rate == undefined ? 0 : (value.Rate * value.Qty));
                            });

                            if (0 >= result.d.AlacartViewModal.length) {
                                $("#alacarteReportIncluded").html("");
                                $("#alacarteReportIncludedHeader").hide();
                                $("#alacarteReportIncludedFooter").hide();
                            }

                            $.each(result.d.AdditionalCharges, function (key, value) {
                                $("#additionalChragesIncluded").append("<li>"
                                    + "<span style='float:right;'>" + "$" + (value.Amount).toFixed(2) + "</span>"
                                    + "<div class='col-xs-10'>" + value.Description + "</div></li>")
                                OtherCharges += parseFloat(value.Amount == undefined ? 0 : (value.Amount));
                            });

                            if (0 >= result.d.AdditionalCharges.length) {
                                $("#additionalChragesIncluded").html("");
                                $("#additionalChragesIncludedHeader").hide();
                                $("#additionalChragesIncludedFooter").hide();
                            }

                            $("#lblPlanTotal").text("$" + (planTotal + alaCarteTotal + OtherCharges).toFixed(2));
                            totalPaid = ((planTotal + alaCarteTotal + OtherCharges + HoldingFees) - discountAmt);

                            $("#lblTotalPaid").text("$" + totalPaid.toFixed(2));
                           
                            $(tr).closest(".dataTable").after("<div class='orderDetails' style='display:none'></Div>");

                            var rowH = $(tr).height(); // this row height
                            var posL = $(tr).position().left; // left position that div needs to be
                            var posT = $(tr).position().top + rowH + 5 + 'px';
                            

                            $(".orderDetails").html($("#reportViewModal").find(".modal-body").html())
                            $(".orderDetails").find(".requesterDetails").remove();
                            $(".orderDetails").find("#divCommandButtons").remove();
                            $(tr).closest(".dataTables_wrapper").find(".orderDetails").css({ "width": "100%", "background": "#eee", "position": "absolute", "display": 'block', "left": posL, "top": posT });
                            var conH = $(".orderDetails").height(); //corresponding content div height
                            var newrowH = conH + rowH + 20 + "px";
                            $(tr).css({ "height": newrowH });
                            $(".orderDetails").find(".row").each(function () {
                                $(this).removeClass("row");
                            });
                            $(".orderDetails").show();
                            //return false; //prevent linkbutton postback.
                        }
                    });


                    
                    //$(this).next().css({ 'width': $(this).width() });
                }
            });

        });


        //check whether company profile is present or not
        function IsCompanyProfilePresent() {

            // check whether compnay is exist or not.
            $.ajax({
                type: "POST",
                url: "AdminDashboard.aspx/IsCompnayProfilePresent",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (result) {
                    $("#overlay").hide();
                    if (result.d) {
                        openSignupModal();
                    }
                    else {
                        //display error message for compnay profile is not present
                        $("#compnayErrorModal").modal("hide");
                        alert("Company Profile does not exists. Please first create your Company Profile.");

                        OpenCompanyProfileModal();
                        return;
                    }
                }
            });
        }

        function DeletePendingOrder(orderId, orderStatus) {
            if (confirm("Are you sure, you want to delete this order?")) {
                $("#overlay").show();
                $.ajax({
                    type: "POST",
                    url: "AdminDashboard.aspx/DeletePendingOrder",
                    contentType: "application/json; charset=utf-8",
                    data: "{" + "orderId:" + orderId + ", orderStatus:" + orderStatus + "}",
                    dataType: "json",
                    async: false,
                    success: function (result) {
                        $("#overlay").hide();
                        window.location.reload();
                    }
                });
            }
            //$.post("AdminDashboard.aspx/DeletePendingOrder", { orderId: orderId, orderStatus: orderStatus }, function () {
            //    window.location.reload();
            //});
        }

        function toggleAdditionalChargesdiv()
        {
            $("#divAdditionalCharges").toggle();
        }

       

        function printOrderStatusReport(Jthis) {
            var orderId = $("#reportStatusViewModal").find("#statusReport_OrderId").val();
            var statusData = {
                orderId: orderId
            };
            $.ajax({
                type: "POST",
                url: "AdminDashboard.aspx/PrintOrderStatusReportPdf",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(statusData),
                dataType: "json",
                async: false,
                success: function (result) {           
                    var protocol = location.protocol;
                    var slashes = protocol.concat("//");
                    var host = slashes.concat(window.location.host);
                    var pdfPath = host + "/" + "pdfs/" + orderId + ".pdf#toolbar=0&navpanes=0&scrollbar=1&zoom=100&statusbar=0&view=FitH";//#toolbar=0&navpanes=0&scrollbar=1&zoom=100&statusbar=0&view=FitH

                    //$("#iframeOrder").attr("src", pdfPath);
                    //var rptWindow = $("#iframeOrder").get(0).contentWindow;
                    //rptWindow.focus();
                    //rptWindow.print();

                    var printSection = $("#pdfOrderReport");
            if (printSection.length == 0) {
                        printSection = $('<iframe id="pdfOrderReport" style="width:100%; height:100%">');
                $('body').append(printSection);
            }
                    $(printSection).attr("src", pdfPath);
                    //var x = document.getElementById("pdfOrderReport");
                    //x.print();                    

                    var finalHtml = $(printSection)[0].outerHTML;
                    var reportWindow = window.open();
                    reportWindow.document.write(finalHtml);
                    $(printSection).remove();
                    var printAndClose = function () {
                        if (reportWindow.frames["pdfOrderReport"].contentWindow) {
                            var documentWindow = reportWindow.frames["pdfOrderReport"].contentWindow;
                            if (documentWindow.document.readyState == 'complete') {
                                clearInterval(sched);
                                documentWindow.focus();
                                documentWindow.print();
                                documentWindow.close();
                            }
                        }
                    }
                    var sched = setInterval(printAndClose, 200);                   
                }
            });
            return false;
        }

        function downloadOrderStatusReport(Jthis) {
            var orderId = $("#reportStatusViewModal").find("#statusReport_OrderId").val();
            var statusData = {
                orderId: orderId
            };
            $.ajax({
                type: "POST",
                url: "AdminDashboard.aspx/DownloadOrderStatusReport",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(statusData),
                dataType: "json",
                async: false,
                success: function (result) {
                    var protocol = location.protocol;
                    var slashes = protocol.concat("//");
                    var host = slashes.concat(window.location.host);
                    var pdfPath = host + "/" + "pdfs";
                    var pdfFileName = "E" + orderId + ".pdf";
                    $("<a id='lnkPdfDownload' style='display:none'>Download</a>").appendTo('#divOrderStatusCommandButtons');
                    $("#lnkPdfDownload").attr("href", "/pdfs/" + pdfFileName).attr("download", orderId + ".pdf");//.attr("data-downloadurl", "application/pdf:" + pdfFileName + ":blob:" + pdfPath)
                    $("#lnkPdfDownload")[0].click();                    
                }
            });
            //return false;
        }

        function printReceipt()
        {           
            var content = $("#reportViewModal").find(".modal-body").html();
            var printSection = $('#printSection');
            if (printSection.length == 0) {
                printSection = $('<div id="printSection"></div>')
                $('body').append(printSection);
            }
            printSection.append(content);
            $('#printSection').find("#divAdditionalCharges").remove();
            $('#printSection').find("#divCommandButtons").remove();
           
            finalHtml = $('#printSection').html();
            
            newWin = window.open();
            newWin.document.write('<html><head><title></title>');
            newWin.document.write('<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.css" rel="stylesheet">');
            newWin.document.write('<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.2/jquery.min.js"><\/script>');
            newWin.document.write('<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"><\/script>');
            newWin.document.write('</head><body >');
            newWin.document.write(finalHtml);
            newWin.document.write('</body></html>');           
            newWin.document.close()
            newWin.focus();
            setTimeout(function () { newWin.print(); newWin.close(); }, 1000);           
            printSection.remove();

            return true;
            
        }




        function SaveOrderExtraCharges()
        {            
            var orderId = $("#submitExtracharges").attr("data-orderid");
            var amount = parseFloat($("#txtAccessFees").val());
            var description = $("#txtAccessFeesdescription").val();
            if(0 >= amount)
            {
                $("#txtAccessFees").parent().css({'border-color':'red'});
                return false;
            }
            if("" == description)
            {
                $("#txtAccessFeesdescription").css({ 'border-color': 'red' });
                return false;
            }
            $.ajax({
                type: "POST",
                url: "AdminDashboard.aspx/UpdateOrderExtraCharges",
                contentType: "application/json; charset=utf-8",
                data: "{" + "orderId:" + orderId + ", amount:" + amount + ", description:'" + description + "'}",
                dataType: "json",
                async: false,
                success: function (result) {
                    $("#reportViewModal").modal("hide");
                    window.location.reload();
                }
            });
        }

        function CompleteOrder(orderId)
        {
            $.ajax({
                type: "POST",
                url: "AdminDashboard.aspx/CompleteCandidateOrder",
                contentType: "application/json; charset=utf-8",
                data: "{" + "orderId:" + orderId + "}",
                dataType: "json",
                async: false,
                success: function (result) {
                    //$("#reportViewModal").modal("hide");
                    window.location.href = "../pages/RequesterCandidate.aspx";
                }
            });
        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hdnUserId" runat="server" />
    <asp:HiddenField ID="hdnOrderId" runat="server" />
    <asp:HiddenField ID="hdnIsAdmin" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdnIsAdminUser" runat="server" />
    <asp:HiddenField ID="hdnIsIncompleteOrder" runat="server" />
    <%-- Bootstrap Modal For display included report --%>

    <div class="modal fade" id="compnayErrorModal" role="dialog" tabindex='-1'>
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header modal-header-padding padding-10px">
                    <button type="button" class="close" data-dismiss="modal" style="opacity: 1">
                        <img src="../Images/close_btn.png" />
                    </button>
                    <h4 class="modal-title font-size-30px margin-left-15px">company profile does not exist</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <p style="font-size: 25px;">Create company profile by using the below link </p>
                            <p style="font-size: 25px;"><a href="#" onclick="OpenCompanyProfileModal();">Create compnay profile</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- End Bootstrap Modal --%>


    <%-- Bootstrap Modal For display included report --%>

    <div class="modal fade" id="reportStatusViewModal" role="dialog" tabindex='-1'>
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header modal-header-padding padding-10px">
                    <button type="button" class="close" data-dismiss="modal" style="opacity: 1">
                        <img src="../Images/close_btn.png" />
                    </button>
                    <h4 class="modal-title font-size-30px margin-left-15px">Order Report Status</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <input type="hidden" id="statusReport_OrderId" />
                        <div class="col-lg-12">
                            <iframe id="iframeOrder" name="iframeOrder" style="height: 400px; width: 98%; border-width: 0px; margin-left: 8px;"></iframe>
                        </div>
                        <div id="divOrderStatusCommandButtons">
                            <% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN || userType == (int)EknowIDLib.UserTypeEnum.ADMIN) { %>
                                <div class="pull-right">
                                    <a href="#" class="btn btn-primary btn-default" onclick="downloadOrderStatusReport();" style="background-color: #5bc0de;"><span class="glyphicon glyphicon-download"></span>&nbsp; Download Report</a>
                                </div>
                            
                                <div class="pull-left">
                                    <a href="#" class="btn btn-primary btn-default" onclick="printOrderStatusReport();"><span class="glyphicon glyphicon-print"></span>&nbsp; Print Report</a>
                                </div>
                            <% } %>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- End Bootstrap Modal --%>

    <%-- Bootstrap Modal For display included report --%>

    <div class="modal fade" id="reportViewModal" role="dialog" tabindex='-1'>
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header modal-header-padding padding-10px">
                    <button type="button" class="close" data-dismiss="modal" style="opacity: 1">
                        <img src="../Images/close_btn.png" />
                    </button>
                    <h4 class="modal-title font-size-30px margin-left-15px">Order Summary</h4>
                </div>
                <div class="modal-body">
                    <div class="row requesterDetails">
                        <div class="col-xs-6 form-group-custom">                            
                            <label id="lblApplicantName" style="border-style:none; font-weight:normal; font-size:20px; padding:0px;">Nilesh Sakore</label>
                        </div>                     
                         <div class="col-xs-6 form-group-custom">                            
                           <label id="lblDateOrdered" style="border-style:none; font-weight:normal; font-size:20px; float:right; padding:0px;">08/14/2017</label>
                        </div>
                        <div class="col-xs-6 form-group-custom">                            
                           <label id="lblCompanyName" style="border-style:none; font-weight:normal; font-size:20px; padding:0px;">Aloha Technology</label>
                        </div>                        
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div style="border-bottom: 2px solid #dddddd; margin: 10px 0px;"></div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-4">
                            <div style="font-size: 20px;">Package Selected</div>
                        </div>
                        <div class="col-xs-4">
                            <div style="font-size: 20px;">
                                <asp:Label ID="litePackageName" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-xs-4">
                            <div style="font-size: 20px;" class="pull-right">
                                <asp:Label ID="litePackageRate" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div style="border-bottom: 2px solid #dddddd; margin: 10px 0px;"></div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">
                            <ol id="reportIncluded">
                            </ol>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div style="border-bottom: 2px solid #dddddd; margin: 10px 0px;"></div>
                        </div>
                    </div>

                    <div class="row" id="alacarteReportIncludedHeader">
                        <div class="col-sm-12">
                            <div class="col-xs-8" style="padding-left: 0px;">
                                <h4>Additional Report Selected</h4>
                            </div>
                            <div class="col-xs-2">
                                <h4>Qty</h4>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <ol id="alacarteReportIncluded">
                            </ol>
                        </div>
                    </div>
                    <div class="row" id="alacarteReportIncludedFooter">
                        <div class="col-lg-12">
                            <div style="border-bottom: 2px solid #dddddd; margin: 10px 0px;"></div>
                        </div>
                    </div>

                    <div class="row" id="additionalChragesIncludedHeader">
                        <div class="col-sm-12">
                            <div class="col-xs-6" style="padding-left: 0px;">
                                <h4>Additional Charges</h4>
                            </div>
                            <div class="col-xs-4">
                                <h4></h4>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <ol id="additionalChragesIncluded">
                            </ol>
                        </div>
                    </div>

                    <div class="row" id="additionalChragesIncludedFooter">
                        <div class="col-lg-12">
                            <div style="border-bottom: 2px solid #dddddd; margin: 10px 0px;"></div>
                        </div>
                    </div>


                    <div class="row">                       
                        <div class="col-sm-12">
                            <div class="col-sm-8">
                                <% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN) { %>
                                    <div id="divAdditionalCharges" class="row form-horizontal col-sm-12" style="min-height:140px; display:none;">
                                        <div class="form-group" style="margin-bottom:5px;">
                                            <label class="control-label col-sm-4">Amount :</label>
                                            <div class="col-sm-8">
                                                <span class="currencyinput form-control">$<input type="number" onkeyup="resetCssBorder('#reportViewModal');" class="" style="width: 95%;" id="txtAccessFees" value="0" /></span>
                                            </div>
                                        </div>
                                        <div class="form-group" style="margin-bottom:5px;">
                                            <label class="control-label col-sm-4">Description :</label>
                                            <div class="col-sm-8">
                                                <textarea class="currencyinput  form-control" id="txtAccessFeesdescription" onkeyup="resetCssBorder('#reportViewModal');" cols="10" rows="2"></textarea>
                                            </div>
                                        </div>
                                        <div class="form-group" style="margin-bottom:5px;">
                                            <div class="col-sm-4"></div>
                                            <div class="col-sm-8">
                                                <input type="button" class="btn btn-default" value="Cancel" style="float: right" onclick="toggleAdditionalChargesdiv();" />
                                                <input id="submitExtracharges" type="button" class="btn btn-default" value="Submit" style="float: right" onclick="SaveOrderExtraCharges();" />
                                            </div>
                                        </div>
                                    </div>
                                <% } %>
                            </div>
                            <div class="col-sm-4" style="font-size: 15px; margin-top: 10px; min-height:140px; padding:0px;">
                                <span style="margin-right: 25px;">Total</span>
                                <span>
                                    <asp:Label ID="lblPlanTotal" runat="server" CssClass="pull-right bold"></asp:Label>
                                </span>
                                <br />
                                <%--<span style="margin-right: 25px;">Access Fees</span>
                                <span>
                                    <asp:Label ID="lblAccessFees" runat="server" CssClass="pull-right bold"></asp:Label>
                                </span>
                                <br />
                                <span style="margin-right: 25px;">Other Fees</span>
                                <span>
                                    <asp:Label ID="lblOtherCharges" runat="server" ToolTip="" CssClass="pull-right bold"></asp:Label>
                                </span>
                                <br />--%>
                                <span style="margin-right: 25px;">Discount</span>
                                <span>
                                    <asp:Label ID="lblPlanDiscount" runat="server" CssClass="pull-right bold"></asp:Label>
                                </span>

                                <br />
                                <span style="margin-right: 25px;">Total Paid</span>
                                <span>
                                    <asp:Label ID="lblTotalPaid" runat="server" CssClass="pull-right bold"></asp:Label>
                                </span>
                            </div>
                        </div>
                        <div id="divCommandButtons">
                            <% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN) { %>
                                <div class="pull-right">
                                    <a href="#" class="btn btn-primary btn-default" onclick="toggleAdditionalChargesdiv();" style="background-color: #5bc0de;"><span class="glyphicon glyphicon-plus"></span>&nbsp; Additional Charges</a>
                                </div>
                            <% } %>
                            <div class="pull-left">
                                <a href="#" class="btn btn-primary btn-default" onclick="printReceipt();"><span class="glyphicon glyphicon-print"></span>&nbsp; Print Receipt</a>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <%-- End Bootstrap Modal For display included report --%>

    <%-- Refund process Modal For display refund details --%>

    <div class="modal fade" id="refundModal" role="dialog" tabindex='-1'>
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header modal-header-padding padding-10px">
                    <button type="button" class="close" data-dismiss="modal" style="opacity: 1">
                        <img src="../Images/close_btn.png" />
                    </button>
                    <h4 class="modal-title font-size-30px margin-left-15px">Refund</h4>
                </div>
                <%--<div class="row errorMsg" style="padding-top: 5px; margin-left: -28px;">
            </div>--%>
                <div class="modal-body">
                    <input id="hdnRefundUserId" type="hidden" value="" />
                    <input id="hdnRefundOrderId" type="hidden" value="" />
                    <input id="hdnRefundOrderStatus" type="hidden" value="" />
                    <div class="row form-horizontal">
                        <div class="form-group" style="min-height: 25px;">
                            <span id="refundamountError" class="col-sm-12 Error"></span>
                        </div>
                        <div class="form-group col-md-6" style="margin:0px;">
                            <label class="control-label">Name:</label>
                            <%--<div class="control-label col-sm-7">--%>
                                <label class="form-control" id="lblName"></label>
                           <%-- </div>--%>
                        </div>
                        <div class="form-group col-md-6" style="margin:0px;">
                            <label class="control-label">Email:</label>
                            <%--<div class="control-label col-sm-7">--%>
                                <label class="form-control" id="lblemail"></label>
                           <%-- </div>--%>
                        </div>
                        <div class="form-group col-md-6" style="margin:0px;">
                            <label class="control-label">Transaction ID:</label>
                            <%--<div class="control-label col-sm-7">--%>
                                <label class="form-control" id="lblTransactionId"></label>
                            <%--</div>--%>
                        </div>
                        <div class="form-group col-md-6" style="margin:0px;">
                            <label class="control-label">Transaction Amount (USD):</label>
                            <%--<div class="control-label col-sm-7">--%>
                                <label class="form-control" id="lblTransactionAmount"></label>
                            <%--</div>--%>
                        </div>
                        <div class="form-group col-md-6" style="margin:0px;">
                            <label class="control-label">Refund Amount (USD):</label>
                            <%--<div class="col-sm-7">--%>
                                <%--<span class="currencyinput form-control readonly" style="background-color: #eee;">--%>
                                    <input type="number" onkeyup="resetCssBorder('#refundModal');" class="readonly form-control" style="border:1px solid #e2e2e2; background-color: #eee;" readonly="readonly" id="txtRefundAmount" />
                                <%--</span>--%>
                            <%--</div>--%>
                        </div>                        
                        <div class="form-group col-md-6" style="margin:0px;">
                            <label class="control-label">Transaction Remark :</label>
                            <%--<div class="col-sm-7">--%>
                                <textarea style="border:1px solid #e2e2e2" class="currencyinput  form-control" id="txtNoteToBuyer" onkeyup="resetCssBorder('#refundModal');" cols="10" rows="5"></textarea>
                            <%--</div>--%>
                        </div>
                        <div class="form-group col-md-6" style="margin:0px; top:-70px;">
                            <label class="control-label">Full Refund :</label>
                            <div class="col-sm-7">
                                <input style="height:25px;" class="form-control" type="checkbox" id="chkFullRefund" checked="checked" onclick="chkFullRefundOn_click(this);" />
                            </div>
                        </div>
                        <div class="form-group col-md-6" style="margin:0px; top:20px; left:-300px;">
                            <a id="refundOrderDetails" href="#">View Order Details</a>
                        </div>
                        <div class="form-group col-md-6">
                            <input type="button" class="btn btn-default" value="Cancel" style="float: right" data-dismiss="modal" />
                            <input type="button" class="btn btn-default" value="Refund" style="float: right" onclick="SubmitRefund();" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- End Refund process Modal For display refund details report --%>

    <%-- Bootstrap Modal For Requestor Information Start --%>
    <div class="modal fade" id="adminEditModal" role="dialog" tabindex='-1'>
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header modal-header-padding padding-10px">
                    <button type="button" class="close" data-dismiss="modal" style="opacity: 1">
                        <img src="../Images/close_btn.png" />
                    </button>
                    <h4 class="modal-title font-size-30px margin-left-15px">Update User Information</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>First Name</label>
                            </div>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtEditUserFirstName" runat="server" CssClass="form-control charactersOnly" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Last Name</label>
                            </div>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtEditUserLastName" runat="server" CssClass="form-control charactersOnly"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Select Role</label>
                            </div>
                            <div class="col-sm-9">
                                <%--<input name="radioLstSelectRole" type="radio" value="1"/> Super-Admin
                                    <input name="radioLstSelectRole" type="radio" value="1"/> Admin
                                    <input name="radioLstSelectRole" type="radio" value="1"/> Support-Admin
                                    <input name="radioLstSelectRole" type="radio" value="1"/> Normal-User--%>
                                <asp:RadioButtonList ID="radioLstSelectRole" runat="server" ClientIDMode="Static" RepeatDirection="Vertical" RepeatLayout="Table" TextAlign="Right">
                                    <asp:ListItem Text="Super-Admin" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Admin" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Support-Admin" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Normal-User" Value="3"></asp:ListItem>
                                </asp:RadioButtonList>
                                <%--<asp:CheckBox ID="chkIsAdmin" runat="server" ClientIDMode="Static"></asp:CheckBox>--%>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <input type="button" id="btnUpdateAdmin" class="btn btn-primary" value="Update" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">
                            <div id="editUserError" class="Error"></div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <%-- Bootstrap Modal End--%>


    <%-- Bootstrap Modal For Candidate email Updation --%>
    <div class="modal fade" id="candidateEmailModal" role="dialog" tabindex='-1'>
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header modal-header-padding padding-10px">
                    <button type="button" class="close" data-dismiss="modal" style="opacity: 1">
                        <img src="../Images/close_btn.png" />
                    </button>
                    <h4 class="modal-title font-size-30px margin-left-15px">Update Candidate Email</h4>
                </div>
                <div class="modal-body">

                    <div class="row">
                        <div class="col-sm-3">
                            <label>Candidate Email</label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtCandidateEmail" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <input type="button" id="btnUpdateEmail" class="btn btn-primary" value="Update" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">
                            <div id="msgEmailUpdate" class="Error"></div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="pendingNotesModal" role="dialog" tabindex='-1'>
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header modal-header-padding padding-10px">
                    <button type="button" class="close" data-dismiss="modal" style="opacity: 1">
                        <img src="../Images/close_btn.png" />
                    </button>
                    <h4 class="modal-title font-size-30px margin-left-15px">Order Pending Notes</h4>
                </div>
                <div class="modal-body">

                    <div class="row">
                        <div class="col-sm-3">
                            <label>Pending Notes</label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtPendingNotes" TextMode="MultiLine" Rows="2" Columns="15" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <input type="button" id="btnUpdatePendingNotes" class="btn btn-primary" value="Update" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">
                            <div id="msgPendingNotesUpdate" class="Error"></div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <%-- Bootstrap Modal End--%>

    <section class="eknowid-bg">
        <div class="container-fluid" style="margin-left: 40px; margin-right: 40px; padding-top: 110px; padding-bottom: 30px;">
            <div id="main">
                <iframe id="my-iframe" style="display: none"></iframe>
            </div>
            <div class="row">
                <div class="col-lg-2" style="padding-right:0px;">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="glyphicon glyphicon-user fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Literal ID="litUsers" runat="server" Text="0"></asp:Literal>
                                    </div>
                                    <div>Users</div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer">
                                <span class="pull-left">
                                    <asp:LinkButton ID="lnkViewUsers" runat="server" Text="View Details" OnClick="lnkViewUsers_Click"></asp:LinkButton>
                                </span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>

                <div class="col-lg-2" style="padding-right:0px;">
                    <div class="panel panel-candidate">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="glyphicon glyphicon-user fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Literal ID="liteApplicantUsers" runat="server" Text="0"></asp:Literal>
                                    </div>
                                    <div>
                                        Candidate
                                        <br />
                                        Users                                        
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer">
                                <span class="pull-left">
                                    <asp:LinkButton ID="linkSelfApplicant" runat="server" Text="View Details" OnClick="linkSelfApplicant_Click"></asp:LinkButton>
                                </span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>

                <div class="col-lg-2" style="padding-right:0px;">
                    <div class="panel panel-grey">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-warning fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Literal ID="litIncompleteOrders" runat="server" Text="0"></asp:Literal>
                                    </div>
                                    <div>
                                        Incomplete
                                        <br />
                                        Orders
                                    </div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer">
                                <span class="pull-left">
                                    <asp:LinkButton ID="LinkIncompleteOrders" runat="server" Text="View Details" OnClick="linkIncompleteOrders_Click"></asp:LinkButton>
                                </span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>

                <div class="col-lg-2" style="padding-right:0px;">
                    <div class="panel panel-yellow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-tasks fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Literal ID="litPendingOrders" runat="server" Text="0"></asp:Literal>
                                    </div>
                                    <div>
                                        Pending
                                        <br />
                                        Orders
                                    </div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer">
                                <span class="pull-left">
                                    <asp:LinkButton ID="linkPendingOrders" runat="server" Text="View Details" OnClick="linkPendingOrders_Click"></asp:LinkButton>
                                </span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>

                <div class="col-lg-2" style="padding-right:0px;">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-shopping-cart fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Literal ID="litCompletedOrders" runat="server" Text="0"></asp:Literal>
                                    </div>
                                    <div>
                                        Completed
                                        <br />
                                        Orders
                                    </div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer">
                                <span class="pull-left">
                                    <asp:LinkButton ID="linkCompletedOrders" runat="server" Text="View Details" OnClick="linkCompletedOrders_Click  "></asp:LinkButton>
                                </span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>

                <div class="col-lg-2" style="padding-right:0px;">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-support fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Literal ID="litCancelOrders" runat="server" Text="0"></asp:Literal>
                                    </div>
                                    <div>
                                        Cancelled
                                        <br />
                                        Orders
                                    </div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer">
                                <span class="pull-left">
                                    <asp:LinkButton ID="linkCancelOrders" runat="server" Text="View Details" OnClick="linkCancelOrders_Click"></asp:LinkButton>
                                </span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>

            <asp:Panel ID="pnlContainer" runat="server">
                <div class="row pull-right" style="margin-top: 8px;">
                    <div class="col-lg-6">
                        <input type="button" data-target="#mainModal" data-toggle="modal" data-keyboard="true" class="btn btn-primary btn-user" value="Place Order" />
                    </div>
                    <div class="col-lg-6">
                        <input type="button" id="btnAdd" runat="server" class="btn btn-primary btn-user" value="Add New User" onclick="IsCompanyProfilePresent();" />
                    </div>
                </div>

            </asp:Panel>

            <asp:Panel ID="pnlError" runat="server" Visible="false">

                <div class="userPanel-error">
                    Error :- You don't have permission to access users panel.
                </div>

            </asp:Panel>

            <asp:Panel ID="pnlUsers" runat="server" Visible="false">

                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#users" aria-controls="users" role="tab" data-toggle="tab">Users</a></li>
                </ul>

                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane fade in active" id="users">
                        <div class="row" style="padding: 16px;">
                            <div class="col-lg-12">
                                <h3>Users</h3>
                            </div>
                            <div class="col-lg-12">

                                <asp:Repeater ID="rptUsers" runat="server">

                                    <HeaderTemplate>
                                        <table id="userGrid" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>First Name</th>
                                                    <th>Last Name</th>
                                                    <th>Email Id</th>
                                                    <th>Created Date</th>
                                                    <th>Is Admin</th>
                                                    <th>Edit</th>
                                                    <th>Delete</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("FirstName") %></td>
                                            <td><%# Eval("LastName") %> </td>
                                            <td><%# Eval("Email") %> </td>
                                            <td><%# Eval("CreatedDate","{0:MM/dd/yyyy}") %></td>
                                            <td>
                                                <asp:CheckBox ID="chkIsAdminRead" runat="server" Checked='<%# Convert.ToInt32(Eval("UserType")) == (int) EknowIDLib.UserTypeEnum.SUPER_ADMIN || Convert.ToInt32(Eval("UserType")) == (int) EknowIDLib.UserTypeEnum.ADMIN ? true : false %>' onclick="javascript: return false;" />
                                            </td>
                                            <td>

                                                <%                                            
                                                    if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN || userType == (int)EknowIDLib.UserTypeEnum.ADMIN) { %>
                                                <a href="#" class="btn btn-primary btn-edit" onclick="showAdminEditPopup('<%# Eval("UserId") %>','<%# Eval("FirstName") %>','<%# Eval("LastName") %>', '<%# Eval("UserType") %>')"><span class="glyphicon glyphicon-edit"></span>&nbsp Edit </a>
                                                <% } %>
                                                                                                                    
                                            </td>

                                            <td>
                                                <a href="#" class="btn btn-danger" onclick="deleteUser('<%# Eval("UserId") %>','<%# Eval("UserType") %>')">
                                                    <span class="glyphicon glyphicon-trash"></span>&nbsp Delete 
                                                </a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>

                                    <FooterTemplate>
                                        </tbody>
                            </table>
                                                                                                 
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>

            </asp:Panel>

            <asp:Panel ID="pnlSelfApplicant" runat="server" Visible="false">

                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#tab-applicantUser" aria-controls="tab-applicantUser" role="tab" data-toggle="tab">Applicant Users</a></li>
                </ul>

                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane fade in active" id="tab-applicantUser">

                        <div class="row" style="padding: 16px;">
                            <div class="col-lg-12">
                                <h3>Applicant Users</h3>
                            </div>

                            <div class="col-lg-12">

                                <asp:Repeater ID="rptApplicantUser" runat="server">

                                    <HeaderTemplate>
                                        <table id="applicantUserGrid" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>Requestor Name</th>
                                                    <th>Requestor Email</th>
                                                    <th>Candidate Name</th>
                                                    <th>Candidate Email</th>
                                                    <th>Company Name</th>
                                                    <th>Created Date</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td><%# string.Format("{0} {1}",Eval("User.FirstName"),Eval("User.LastName"))  %></td>
                                            <td><%# Eval("User.Email")  %> </td>
                                            <td><%# string.Format("{0} {1}",Eval("Candidate.FirstName"),Eval("Candidate.LastName"))  %></td>
                                            <td><%# Eval("Candidate.Email") %></td>
                                            <td><%# Eval("Company.Name") %></td>
                                            <td><%# Eval("Candidate.CreatedOn","{0:MM/dd/yyyy}") %></td>
                                        </tr>
                                    </ItemTemplate>

                                    <FooterTemplate>
                                        </tbody>
                            </table>
                                                                                                 
                                    </FooterTemplate>
                                </asp:Repeater>

                            </div>

                        </div>
                    </div>

                </div>

            </asp:Panel>

            <asp:Panel ID="pnlOrderTypes" runat="server" Visible="false">

                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#example1-tab1" aria-controls="example1-tab1" role="tab" data-toggle="tab">Applicant Orders</a></li>
                    <li role="presentation"><a href="#example1-tab2" aria-controls="example1-tab2" role="tab" data-toggle="tab">Self Orders</a></li>
                </ul>

                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane fade in active" id="example1-tab1">

                        <div class="row" style="padding: 16px;">
                            <div class="col-lg-12">
                                <h3>Applicant Orders</h3>
                            </div>
                            <div class="col-lg-12" style="margin-bottom: 50px;">
                                <table id="candidateGrid" class="table table-striped table-bordered">
                                    <thead>
                                        <tr>
                                            <% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN || userType == (int)EknowIDLib.UserTypeEnum.ADMIN) { %>
                                            <th runat="server" id="reSendCandidateHeader">Re Email</th>
                                            <%} %>
                                            <th>Candidate</th>
                                            <th>Candidate Email</th>
                                            <th>Requestor</th>
                                            <th>Company</th>
                                            <th>Status</th>
                                            <th>Package</th>
                                            <th>Date</th>
                                            <th runat="server" id="ViewPendingNotesHeader">Pending<br />Notes</th>
                                            <th runat="server" id="viewReportCandidateHeader" style="padding: 5px; text-align: center; vertical-align: middle;">View Report</th>
                                            <th runat="server" id="sendReportCandidateHeader" style="padding: 5px; text-align: center; vertical-align: middle;">Send</th>
                                            <th id="reptCandidateOrderReceipt" style="padding: 5px; text-align: center; vertical-align: middle;">Receipt</th>
                                            <th runat="server" id="incompleteOrderCandidateHeader" style="padding: 5px; text-align: center; vertical-align: middle;">Complete Order</th>
                                            <th style="padding: 5px; text-align: center; vertical-align: middle;">Refund</th>
                                            <% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN) { %>
                                            <th runat="server" id="cancelCandidateHeader">Delete</th>
                                            <%} %>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="reptCandidateOrder" runat="server">
                                            <%--<HeaderTemplate>
                                        
                                    </HeaderTemplate>--%>

                                            <ItemTemplate>
                                                <tr data-orderid="<%#Eval("Order.OrderId") %>">
                                                    <% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN || userType == (int)EknowIDLib.UserTypeEnum.ADMIN) { %>
                                                    <td style="<%# (Convert.ToBoolean(Eval("IsIncompleteOrder")) == true) ? "display:none" : ""%>">
                                                        <div style="display: inline-block; width: 85px;">
                                                            <div class="pull-left">
                                                                <%--<asp:LinkButton ID="linkResendEmail" runat="server" CssClass="btn btn-primary" Text='Resend' OnClientClick='<%# String.Format("return resendCandidateEmail({0});", Eval("Order.OrderId")) %>' Enabled='<%# Convert.ToInt32(Eval("Order.Status")) == 0 || Convert.ToInt32(Eval("Order.Status")) == 1  || Convert.ToInt32(Eval("Order.Status")) == 5 ?  false : false %>' ></asp:LinkButton>--%>
                                                                <asp:Button ID="linkResendEmail" runat="server" CssClass="btn btn-primary" Text='Resend' OnClientClick='<%# String.Format("return resendCandidateEmail({0});", Eval("Order.OrderId")) %>' Enabled='<%# Convert.ToInt32(Eval("Order.Status")) == 0 || Convert.ToInt32(Eval("Order.Status")) == 1  || Convert.ToInt32(Eval("Order.Status")) == 5 ?  true : false %>'></asp:Button>
                                                            </div>
                                                            <div class="pull-right" style="padding: 5px 0px">
                                                                <span class="badge">
                                                                    <%# Eval("Order.ResendEmailCount") %>
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <%} %>
                                                    <td>
                                                        <asp:Literal ID="liteCandidateName" runat="server" Text='<%# string.Format("{0} {1}",Eval("Candidate.FirstName") , Eval("Candidate.LastName")) %>'></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <div class="ellipsis-text">
                                                            <label class="label" title="<%# Eval("Candidate.Email") %>"><%# Eval("Candidate.Email") %></label>
                                                            <%--<asp:Literal ID="liteCandidateEmail" runat="server" Text='<%# Eval("Candidate.Email") %>'></asp:Literal>--%>
                                                        </div>
                                                        <% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN || userType == (int)EknowIDLib.UserTypeEnum.ADMIN) { %>

                                                        <span class='<%# Convert.ToInt32(Eval("Order.Status")) == 10 ? "disable" : "visible" %>'>
                                                            <a href="#" onclick="showUpdateCandidateEmailPopup('<%#Eval("Order.OrderId") %>','<%#Eval("Candidate.Email") %>')">Edit</a>
                                                        </span>

                                                        <% } %>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="liteRequesterName" runat="server" Text='<%# string.Format("{0} {1}", Eval("User.FirstName") , Eval("User.LastName")) %>'></asp:Literal>
                                                    </td>
                                                    <td title='<%# Eval("Company.Name") %>'>
                                                        <div class="ellipsis-text">
                                                        <asp:Literal ID="liteCompanyName" runat="server" Text='<%# Eval("Company.Name") %>'></asp:Literal>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="liteOrderStatus" runat="server" Text='<%# Eval("OrderStatusText") %>'></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="liteOrderType" runat="server" Text='<%# Eval("Plan.Name") %>'></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="liteOrderdate" runat="server" Text='<%# Eval("Order.PurchasedDate","{0:MM/dd/yyyy}") %>'></asp:Literal>
                                                    </td>
                                                    <td style="text-align:center; <%#(Convert.ToBoolean(Eval("IsIncompleteOrder")) == false && (Convert.ToInt32(Eval("Order.status")) == 0 || Convert.ToInt32(Eval("Order.status")) == 1 || Convert.ToInt32(Eval("Order.status")) == 2 || Convert.ToInt32(Eval("Order.status")) == 5)? "" : "display:none") %>">
                                                        <a href="#" onclick="showUpdatePendingNotePopup('<%#Eval("Order.OrderId") %>','<%#Eval("Order.PendingNotes") %>', this)">
                                                            <span id="spanNote_<%#Eval("Order.OrderId") %>" title="<%#Eval("Order.PendingNotes") %>" data-orderid="<%#Eval("Order.OrderId") %>" class="pendingnotes glyphicon glyphicon-comment"></span> 
                                                        </a>
                                                    </td>
                                                    <td style="text-align: center; <%# (Convert.ToBoolean(Eval("IsIncompleteOrder")) == true || Convert.ToInt32(Eval("Order.status")) != 10) ? "display:none" : ""%>">
                                                        <a href="#" onclick="ViewReportStatus(<%#Eval ("Order.OrderId") %>)">
                                                            <asp:Image ImageUrl="~/Images/pdf.png" runat="server" />
                                                        </a>
                                                    </td>
                                                    <td style="text-align: center; <%# (Convert.ToBoolean(Eval("IsIncompleteOrder")) == true|| Convert.ToInt32(Eval("Order.status")) != 10) ? "display:none" : ""%>">
                                                        <a href="#" onclick="SendPdfToEmail(<%# Eval("Order.OrderId") %>);">
                                                            <asp:Image ImageUrl="~/Images/email.png" runat="server" Visible='<%# (Convert.ToInt32(Eval("Order.status")) == 10 && (365 >= (DateTime.Now - Convert.ToDateTime(Eval("Order.PurchasedDate"))).Days)) ? true : false %>' />
                                                        </a>
                                                    </td>
                                                    <td style="text-align: right; font-weight: bold;">
                                                        <a href="#" onclick="return SelectedReportView('<%#Eval("Order.OrderId") %>', '<%# string.Format("{0} {1}",Eval("Candidate.FirstName") , Eval("Candidate.LastName")) %>','<%#Eval("Company.Name") %>', '<%#Eval("Order.PurchasedDate","{0:MM/dd/yyyy}") %>');");">$<%# Eval("Order.PaidAmt","{0:0.00}") %></a>
                                                    </td>
                                                    <td style="text-align: center; <%# (Convert.ToBoolean(Eval("IsIncompleteOrder")) == true) ? "": "display:none"%>">
                                                        <a href="#" class="btn btn-danger" onclick="CompleteOrder('<%# Eval("Order.OrderId") %>')">
                                                            <span class="glyphicon glyphicon-warning-sign"></span>&nbsp Complete Order 
                                                        </a>
                                                    </td>
                                                    <td style="text-align: center; font-weight: bold;">
                                                        <button title="<%# Convert.ToDecimal(Eval("Order.RefundAmt")) > 0 ? ("Processed refund of amount: $" + Eval("Order.RefundAmt")) : "" %>" type="button" class="btn btn-info" style="padding: 4px; background-color: #5bc0de; <%# (Convert.ToInt32(Eval("Order.status")) == 6 || Convert.ToInt32(Eval("Order.status")) == 9 || (Eval("Order.RefundAmt") != null && (Eval("Order.RefundAmt","{0:0.0000}") == Eval("Order.PaidAmt","{0:0.0000}")))) ? "display:none": ""%>"
                                                            onclick="RefundProcess(this, 'candidateGrid', '<%# Eval("Order.OrderId") %>', '<%# Eval("Order.TransactionId") %>', '<%# Eval("Order.PaidAmt","{0:0.0000}") %>', '<%# Eval("Order.RefundAmt","{0:0.0000}") %>', '<%# Eval("User.UserId") %>', '<%# string.Format("{0} {1} ",Eval("User.FirstName") , Eval("User.LastName")) %>', '<%# Eval("User.Email")  %>', '<%# Eval("Order.status")  %>');">
                                                            <span class="glyphicon glyphicon-usd"></span>Refund
                                                        </button>
                                                        <label class="label" title="<%# Eval("Order.RefundAmt") %>"><%# ((Eval("Order.RefundAmt") != null && (Eval("Order.RefundAmt","{0:0.0000}") == Eval("Order.PaidAmt","{0:0.0000}"))) ? Eval("Order.RefundAmt","${0:0.00}") : "")%></label>

                                                    </td>
                                                    <% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN) { %>
                                                    <td style="text-align: center; <%# (Convert.ToInt32(Eval("Order.status")) == 10 ||Convert.ToInt32(Eval("Order.status")) == 6 || Convert.ToInt32(Eval("Order.status")) == 9) ? "display:none": ""%>">
                                                        <a href="#" class="btn btn-danger" onclick="DeletePendingOrder('<%# Eval("Order.OrderId") %>', '<%# Eval("Order.status")  %>')">
                                                            <span class="glyphicon glyphicon-trash"></span>&nbsp Delete 
                                                        </a>
                                                    </td>
                                                    <% } %>                                                    
                                                </tr>                                                
                                            </ItemTemplate>

                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div role="tabpanel" class="tab-pane fade" id="example1-tab2">

                        <div class="row" style="padding: 16px; height: 150px;">
                            <div class="col-lg-12">
                                <h3>Self Orders</h3>
                            </div>

                            <div class="col-lg-12">
                                <table id="requestorGrid" class="table table-striped table-bordered">
                                    <thead>
                                        <tr>
                                            <th>Requestor Name</th>
                                            <th>Requestor Email</th>
                                            <th>Status</th>
                                            <th>Package</th>
                                            <th>Order Date</th>
                                            <th>View Report</th>
                                            <th>Send</th>
                                            <th runat="server" id="selfOrdersPendingNotesHeader">Pending<br />Notes</th>
                                            <th>Receipt</th>
                                            <th>Refund</th>
                                            <% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN) { %>
                                            <th runat="server" id="cancelRequesterHeader">Delete</th>
                                            <% } %>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="reptRequesterOrder" runat="server">
                                            <ItemTemplate>
                                                <tr data-orderid="<%#Eval("Order.OrderId") %>">
                                                    <td>
                                                        <asp:Literal ID="liteRequesterName" runat="server" Text='<%# string.Format("{0} {1} ",Eval("User.FirstName") , Eval("User.LastName")) %>'></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <div class="ellipsis-text">
                                                            <label class="label" title="<%# Eval("User.Email") %>"><%# Eval("User.Email") %></label>
                                                            <%--<asp:Literal ID="liteRequestorEmail"  runat="server"  Text='<%# Eval("User.Email") %>'></asp:Literal>--%>
                                                        </div>
                                                    </td>

                                                    <td>
                                                        <asp:Literal ID="liteOrderStatus" runat="server" Text='<%# Eval("OrderStatusText") %>'></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="liteOrderType" runat="server" Text='<%# Eval("Plan.Name") %>'></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="liteOrderDate" runat="server" Text='<%# Eval("Order.PurchasedDate","{0:MM/dd/yyyy}") %>'></asp:Literal>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <a href="#" onclick="ViewReportStatus(<%#Eval ("Order.OrderId") %>)">
                                                            <asp:Image ImageUrl="~/Images/pdf.png" runat="server" />
                                                        </a>
                                                    </td>

                                                    <td style="text-align: center;">
                                                        <a href="#" onclick="SendPdfToEmail(<%# Eval("Order.OrderId") %>);">
                                                            <asp:Image ImageUrl="~/Images/email.png" runat="server" Visible='<%# (Convert.ToInt32(Eval("Order.Status")) == 10 && (365 >= (DateTime.Now - Convert.ToDateTime(Eval("Order.PurchasedDate"))).Days)) ? true : false %>' />
                                                        </a>
                                                    </td>
                                                    <td style="text-align:center; <%#(Convert.ToInt32(Eval("Order.status")) == 0 || Convert.ToInt32(Eval("Order.status")) == 1 || Convert.ToInt32(Eval("Order.status")) == 2 || Convert.ToInt32(Eval("Order.status")) == 5) ? "" : "display:none"%>">
                                                        <a href="#" onclick="showUpdatePendingNotePopup('<%#Eval("Order.OrderId") %>','<%#Eval("Order.PendingNotes") %>', this)">
                                                            <span id="spanNote_<%#Eval("Order.OrderId") %>" title="<%#Eval("Order.PendingNotes") %>" data-orderid="<%#Eval("Order.OrderId") %>" class="pendingnotes glyphicon glyphicon-comment"></span> 
                                                        </a>
                                                    </td>
                                                    <td style="text-align: right; font-weight: bold;">
                                                        <a href="#" onclick="return SelectedReportView('<%#Eval("Order.OrderId") %>', '<%# string.Format("{0} {1}",Eval("User.FirstName") , Eval("User.LastName")) %>','<%#Eval("Company.Name") %>', '<%#Eval("Order.PurchasedDate","{0:MM/dd/yyyy}") %>');">$<%# Eval("Order.PaidAmt","{0:0.00}") %></a>
                                                    </td>
                                                    <td style="text-align: center; font-weight: bold;">
                                                        <button title="<%# Convert.ToDecimal(Eval("Order.RefundAmt")) > 0 ? ("Already processed refund of amount: $" + Eval("Order.RefundAmt")) : "" %>" type="button" class="btn btn-info" style="padding: 4px; background-color: #5bc0de; <%# (Convert.ToInt32(Eval("Order.status")) == 6 || Convert.ToInt32(Eval("Order.status")) == 9 || (Eval("Order.RefundAmt") != null && (Eval("Order.RefundAmt","{0:0.0000}") == Eval("Order.PaidAmt","{0:0.0000}")))) ? "display:none": ""%>"
                                                            onclick="RefundProcess(this, 'requestorGrid', '<%# Eval("Order.OrderId") %>', '<%# Eval("Order.TransactionId") %>', '<%# Eval("Order.PaidAmt","{0:0.0000}") %>', '<%# Eval("Order.RefundAmt","{0:0.0000}") %>', '<%# Eval("User.UserId") %>', '<%# string.Format("{0} {1} ",Eval("User.FirstName") , Eval("User.LastName")) %>', '<%# Eval("User.Email")  %>', '<%# Eval("Order.status")  %>');">
                                                            <span class="glyphicon glyphicon-usd"></span>Refund
                                                        </button>
                                                        <%# ((Eval("Order.RefundAmt") != null && (Eval("Order.RefundAmt","{0:0.0000}") == Eval("Order.PaidAmt","{0:0.0000}"))) ? Eval("Order.RefundAmt","${0:0.00}") : "")%>                                                    
                                                    </td>
                                                    <% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN) { %>
                                                    <td style="text-align: center; <%# (Convert.ToInt32(Eval("Order.status")) == 10 || Convert.ToInt32(Eval("Order.status")) == 6 || Convert.ToInt32(Eval("Order.status")) == 9) ? "display:none": ""%>">
                                                        <a href="#" class="btn btn-danger" onclick="DeletePendingOrder('<%# Eval("Order.OrderId") %>', '<%# Eval("Order.status")  %>')">
                                                            <span class="glyphicon glyphicon-trash"></span>&nbsp Delete 
                                                        </a>
                                                    </td>
                                                    <% } %>
                                                </tr>                                                
                                            </ItemTemplate>

                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

            </asp:Panel>
        </div>
    </section>
</asp:Content>
