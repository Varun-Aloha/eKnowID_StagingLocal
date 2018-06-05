<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="UserOrderHistory.aspx.cs" Inherits="eknowID.Pages.UserOrderHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link href="http://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>

    <script type="text/javascript" language="javascript">

        $(function () {
            $("#txtPurchasedDate").click(function () {
                $("#txtPurchasedDate").datepicker({ dateFormat: 'mm/dd/yy' });
                $("#txtPurchasedDate").datepicker("show");
            });
        });

        var url = "";
        var orderId = "";
        var orderStatus = "";
        var interval;
        var popUpCloseFlag;

        function ShowOrderStatus(OrderId) {
            GetOrderStatus(OrderId.id);
            setOrderStatusDetails();
        }
        function showIncludeReports(OrderId) {
            GetIncludeReportList(OrderId.id);
            setReportListDetails(OrderId.id);
        }

        function GetIncludeReportList(OrderId) {
            var controlData = "OrderId :" + OrderId;
            $("#hdnOrderID").val(OrderId);
            var innerHtmlText = "";
            $.ajax({
                type: "POST",
                async: false,
                url: "UserOrderHistory.aspx/GetIncludeReportList",
                contentType: "application/json; charset=utf-8",
                data: "{" + controlData + "}",
                dataType: "json",
                success: function (result) {
                    document.getElementById("lblPlanPrice").innerHTML = result.d.packagePrice;
                    document.getElementById("lblPackageName").innerHTML = result.d.packageName;
                    document.getElementById("lblTotalPrice").innerHTML = result.d.totalPrice;
                    document.getElementById("lblDiscountPrice").innerHTML = result.d.discountPrice;
                    document.getElementById("lblTotalPaid").innerHTML = result.d.paidPrice;

                    var basicReports = result.d.basicReportList;
                    if (basicReports != null && basicReports.length > 0) {
                        for (var key in basicReports) {
                            innerHtmlText = innerHtmlText + ('<img class="vertical_align_middle" border="0" alt="0" src="../Images/green_tick.png"><label class="lblReportName" style="margin-left:15px;color: #3C3C3C;">' + basicReports[key] + '</label><br/>');
                        }
                        $('.divBasicReportList').html(innerHtmlText);
                    }
                    else {
                        innerHtmlText = innerHtmlText + ('<label class="lblReportName" style="margin-left:15px;color: #3C3C3C;">No Basic report exists.</label><br/>');
                        $('.divBasicReportList').html(innerHtmlText);
                    }

                    var additionalReports = result.d.additionalReportList;
                    if (additionalReports.length > 0) {
                        var loopCount = 0;
                        innerHtmlText = ""
                        while (loopCount < result.d.additionalReportList.length) {
                            innerHtmlText = innerHtmlText + ('<div style="width:400px;height:20px;"><img class="vertical_align_middle" border="0" alt="0" src="../Images/green_tick.png"><label class="lblReportName" style="margin-left:15px;color: #3C3C3C;">' + result.d.additionalReportList[loopCount].reportName + '</label><div style="width:52px;float:right;color: #3C3C3C;"><label class="lblReportName" style="float:right;">$' + result.d.additionalReportList[loopCount].Price + '</label></div>');
                            loopCount++;
                        }
                        $('.divAdditionalReportList').html(innerHtmlText);
                    }
                    if (result.d.OrderType == "Uncover Your Background") {
                        $(".divPackageSelection").attr("style", "display:none;");
                        $(".divAdditionalReport").text("Report Selected");
                    }
                    else {
                        $(".divPackageSelection").attr("style", "display:block;");
                        $(".divAdditionalReport").text("Additional Report Selected");
                    }

                    innerHtmlText = ('<input id="btnOk" type="button" value="OK" Class="BtnblackMiddle floatRight" onclick="CloseReportIncludePopup();"/>');
                    $('.divOKbtn').html(innerHtmlText);

                }
            });
        }
        function setReportListDetails(OrderId) {
            $('#reportList').bPopup({
                modalClose: false,
                opacity: 0.6,
                positionStyle: 'fixed'
            });
        }

        function setOrderStatusDetails() {
            document.getElementById("lblOrderId").innerHTML = orderId;
            document.getElementById("lblOrderStatus").innerHTML = orderStatus;
            document.getElementById("iframeOrder").setAttribute("src", url);
            $('#orderStatus').bPopup({
                modalClose: false,
                opacity: 0.6,
                positionStyle: 'fixed'
            });
        }

        function GetOrderStatus(OrderId) {
            var controlData = "OrderId :" + OrderId;
            $.ajax({
                type: "POST",
                async: false,
                url: "orderHandling.aspx/GetOrderStatus",
                contentType: "application/json; charset=utf-8",
                data: "{" + controlData + "}",
                dataType: "json",
                success: function (result) {
                    url = result.d.URL;
                    orderId = result.d.OrderId;
                    orderStatus = result.d.xmlRequestStatus;
                    if (result.d.TazWorksOrderId == 2) {
                        popUpCloseFlag = false;
                        interval = window.setInterval("checkPendingOrderStatus(" + result.d.OrderId + ");", 5000);
                    }
                }
            });
        }

        function checkPendingOrderStatus(OrderId) {
            var controlData = "OrderId :" + OrderId;
            $.ajax({
                type: "POST",
                async: false,
                url: "orderHandling.aspx/GetPendingOrderEnquiryDetails",
                contentType: "application/json; charset=utf-8",
                data: "{" + controlData + "}",
                dataType: "json",
                success: function (result) {
                    if (result.d.TazWorksOrderId == 1 && popUpCloseFlag == false) {
                        url = result.d.URL;
                        orderId = result.d.OrderId;
                        orderStatus = result.d.xmlRequestStatus;
                        setOrderStatusDetails();
                        clearInterval(interval);
                    }
                }
            });
        }

        function reloadPage() {
            if (orderStatus == "COMPLETED" || orderStatus == "READY") {
                location.reload();
            }
        }

        function CloseStatusPopup() {
            popUpCloseFlag = true;
            clearInterval(interval);
        }
        function CloseReportIncludePopup() {
            $(".divMainReportIncludePopUp").bPopup().close();
        }

        function changeHashOnLoad() {
            var url = document.referrer;

            if (url.indexOf("SearchByProf_PaymentInfo") != -1) {
                window.location.href += "#";
                setTimeout("changeHashAgain()", "50");

            }
        }

        function changeHashAgain() {
            window.location.href += "1";
        }

        var storedHash = window.location.hash;
        window.setInterval(function () {
            if (window.location.hash != storedHash) {
                window.location.hash = storedHash;
            }
        }, 50);

        $(function () {
            window.onload = changeHashOnLoad;
        });

        $(function () {
            $('.charactersOnly').bind('input', function () {
                if ($(this).val().match(/[^a-zA-Z]/g)) {
                    this.value = this.value.replace(/[^a-zA-Z]/g, '');
                }
            });
        });

    </script>
    <!--[if IE 8]>
                                            <style type="text/css">
    .reportIncludePadding
    {
    padding-left:50px !important;
    }     
    .divOKbtn
    {
    margin-right:35px;
    }
    .divPaymentDetails
     {
    margin-right:35px;
    }
    .divPackageName
    {
    width:435px;
    }
    .divSelectedReportPrice
    {
     margin-right: 14px;
    }
    </style>
    <![endif]-->
    <style type="text/css">
        .lblReportName {
            font-family: arial;
            font-size: 14px;
        }

        .BtnblackMiddle {
            background-image: url("../images/black_btn_middle.png");
            background-repeat: repeat-x;
            border: 0 none;
            border-radius: 5px 5px 5px 5px;
            font-weight: bold;
            height: 30px;
            margin: 3px;
            color: White;
        }

        .divOKbtn {
            height: 37px;
            margin-top: 20px;
            clear: both;
        }

        .viewReportPadding {
            padding-left: 30px !important;
        }

        .reportIncludePadding {
            padding-left: 40px !important;
        }

        table.grvOrderHistory .empty td {
            border-style: none;
            border-width: 0px;
            background-color: #ffffff;
            height: 80px;
            padding-left: 15px;
            font-size: 20px;
        }

        .noOrderExistErrorMSg {
            font-size: 15px;
            font-weight: normal;
        }

        .lblPaymentSummary {
            color: #3C3C3C;
            float: left;
            font-size: 14px;
        }

        .width400px {
            width: 400px !important;
        }

        .sendPdfReport {
            padding-left: 23px !important;
        }

        .divPaymentDetails {
            height: 62px;
            float: right;
            clear: both;
            margin-top: 15px;
        }

        .divPackageName {
            min-height: 150px;
            clear: both;
            background-color: White;
        }

        .control-height {
            height: 30px !important;
        }

        .button-control {
            height: 35px;
            width: 100px;
            background-color: #e11e23;
            border: none;
            color: white;
            font-size: 17px;
            font-weight: bold;
            font-family: serif;
            border-radius: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="SearchByRef_background minWidth1000px" style="height: 485px;">
        <div class="stretchDiv" style="min-height: 475px;">
            <div class="padding30" style="padding-left: 0px !important;">

                <div style="width: 1000px; background-color: #ffffff; box-shadow: 2px 2px 2px #888888; height: auto; border-radius: 2px;">
                    <div style="border-bottom: 2px solid #789ec2; font-size: 22px; font-weight: bold; padding: 10px; color: #3a6185">
                        Search by below criteria
                    </div>

                    <div style="margin-top: 10px; padding: 10px;">
                        <asp:TextBox ID="txtPurchasedDate" runat="server" Placeholder="Purchased Date" Style="height: 30px;" ClientIDMode="Static"></asp:TextBox>
                        <asp:TextBox ID="txtApplicantName" runat="server" CssClass="charactersOnly" Placeholder="Applicant Name" Style="height: 30px;"></asp:TextBox>
                        <asp:DropDownList ID="drpPurchasedPlan" runat="server" Style="height: 35px; width: 150px;">
                            <asp:ListItem Text="Select Plan" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Express Lite" Value="1"></asp:ListItem>
                            <asp:ListItem Text="The Standard" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Top Hire" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Basic" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Gold" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Platinum" Value="6"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnOrderSearch" runat="server" Text="Search" OnClick="btnOrderSearch_Click" CssClass="button-control" />
                        <asp:Button ID="btnCancelSearch" runat="server" Text="Cancel" OnClick="btnCancelSearch_Click" CssClass="button-control" />
                    </div>
                    <div style="padding: 10px; font-size: 15px; color: #a94442; display: none;" id="showError">
                        Please enter value to search
                    </div>
                </div>

                <h1 class="SearchByRefUC_heading">Order History</h1>
                <div class="paddingBottom30 stretchDiv">
                    <asp:GridView ID="grvOrderHistory" runat="server" GridLines="Horizontal" CssClass="blueBorder grvOrderHistory"
                        Style="width: 1000px;" AutoGenerateColumns="False" ClientIDMode="Static" AllowPaging="true"
                        PageSize="05" OnPageIndexChanging="grvOrderHistory_PageIndexChanging" AllowSorting="true"
                        OnRowCommand="grvOrderHistory_RowCommand">
                        <AlternatingRowStyle CssClass="alternaterowcolor blueBorder" />
                        <HeaderStyle CssClass="grvHeaderStyle  gridHeaderBg blueBorder" />
                        <RowStyle CssClass="grvRowStyle blueBorder" />
                        <Columns>

                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
                                SortExpression="PurchasedDate" ItemStyle-CssClass="paddingLeft10" HeaderStyle-CssClass="paddingLeft10">
                                <HeaderTemplate>
                                    <asp:LinkButton runat="server" ID="lnkPurchasedDate" Text="Purchased Date" OnClick="grvOrderHistory_Sort"
                                        CommandArgument="OrderId" ForeColor="black" Font-Underline="False" ToolTip="Sort" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%# Eval("PurchasedDate")%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Plan" HeaderText="Purchased Plan" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" />
                                                                                    
                            <asp:BoundField DataField="TransactionId" HeaderText="Transaction ID" HtmlEncode="false"
                                HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />

                            <asp:TemplateField HeaderText="Reports Included">
                                <ItemTemplate>
                                    <img onclick="showIncludeReports(this)" src="../Images/icon_report_included.png"
                                        alt="" class="reportIncludePadding cursorPointer" id=" <%# Eval("OrderId") %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View Report">
                                <ItemTemplate>
                                    <img onclick="ShowOrderStatus(this)" src="../Images/search_icon.png" alt="" class="viewReportPadding cursorPointer"
                                        id=" <%# Eval("OrderId") %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Send PDF">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnPdf" runat="server" CausesValidation="false" CommandName="SendPDF"
                                        CssClass="sendPdfReport" ImageUrl="../Images/pdf.png" Visible='<%# IsOrderComplete((int)Eval("OrderStatusId")) %>'></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle CssClass="empty" />
                        <EmptyDataTemplate>
                            <font class="noOrderExistErrorMSg">There are currently no orders.</font>
                        </EmptyDataTemplate>
                        <PagerSettings FirstPageText="First Page" LastPageText="Last Page" Mode="NumericFirstLast"
                            Position="Bottom" />
                        <PagerStyle BackColor="Lavender" ForeColor="LightSlateGray" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div id="orderStatus" style="display: none; height: 506px; width: 730px; background-color: White;"
            class="borderRadius6">
            <div class="closeBtnDiv">
                <a class="bClose" onclick="CloseStatusPopup();reloadPage();"></a>
            </div>
            <div class="width100per height_30px borderRadiusTopCorners6 paddingTop10" style="background: gray;">
                <h1 class="marginBottom0 marginTop0" style="margin-top: -5px; margin-left: 12px;">Order Status For Order Id-
                    <asp:Label ID="lblOrderId" ClientIDMode="Static" runat="server" Text="" />
                    is
                    <asp:Label ID="lblOrderStatus" ClientIDMode="Static" runat="server" Text="" /></h1>
            </div>
            <br />
            <br />
            <div>
                <iframe id="iframeOrder" style="height: 400px; width: 98%; border-width: 0px; margin-left: 8px;"></iframe>
            </div>
        </div>
        <div id="reportList" style="display: none;" class="divMainReportIncludePopUp">
            <div class="divSubReportIncludePopUp">
                <div class="closeBtnDiv">
                    <a class="bClose" onclick="return CloseReportIncludePopup();"></a>
                </div>
                <div class="width100per height_30px borderRadiusTopCorners6 paddingTop10 headReportIncludePopUp">
                    <h1 class="marginBottom0 marginTop0" style="margin-top: -5px; margin-left: 12px;">Order Summary
                    </h1>
                </div>
                <br />
                <div class="width100per paddingLeft15" style="line-height: 21px;">
                    <div id="innerContainer" class="floatLeft">
                        <div class="divPackageName">
                            <div class="SearchByRefChosePlan_ReportIncludeDiv divPackageSelection width400px">
                                <h3 class="SearchByRefChosePlan_ReportIncludeHeadNew divReportSelected floatLeft marginLeft7">Package Selected
                                </h3>
                                <asp:Label runat="server" ID="lblPackageName" Text="" CssClass="marginTop15 floatLeft divReportSelected marginleft15"
                                    ClientIDMode="Static"></asp:Label>
                                <asp:Label runat="server" ID="lblPlanPrice" Text="" CssClass="marginTop15  floatRight divReportSelected divSelectedReportPrice"
                                    ClientIDMode="Static"></asp:Label>
                            </div>
                            <div id="Div1" class="WidthIE8 divPackageSelection">
                                <img src="../Images/payment_summery_sep_line_bottom.png" alt="" style="height: 2px; width: 400px;" />
                            </div>
                            <div class="divBasicReportList clearBoth marginTop5 divPackageSelection">
                            </div>
                            <div id="seperatorNew" class="marginTop5 divPackageSelection">
                                <img src="../Images/payment_summery_sep_line_bottom.png" alt="" style="height: 3px; width: 400px;" />
                            </div>
                            <div class="SearchByRefChosePlan_ReportIncludeDiv width400px">
                                <asp:Label runat="server" ID="Label1" Text="" Style="color: #373737 !important; font-size: 13px; font-weight: bold;"
                                    CssClass="marginTop15 floatLeft"></asp:Label>
                                <h3 class="SearchByRefChosePlan_ReportIncludeHeadNew divReportSelected floatLeft marginLeft5 divAdditionalReport"
                                    style="margin-top: 7px !important;">Additional Reports Selected
                                </h3>
                            </div>
                            <div class="divAdditionalReportList clearBoth" style="min-height: 20px;">
                            </div>
                            <div class="divPaymentDetails">
                                <asp:Label runat="server" ID="lblTotal" Text="Total" Style="margin-right: 5px;" CssClass="lblPaymentSummary"></asp:Label>
                                <asp:Label runat="server" ID="lblTotalPrice" Text="" CssClass="lblPaymentSummary boldText"
                                    Style="float: right;" ClientIDMode="Static"></asp:Label>
                                <br />
                                <asp:Label runat="server" ID="lblDiscount" Text="Discount" Style="margin-right: 5px;"
                                    CssClass="lblPaymentSummary"></asp:Label>
                                <asp:Label runat="server" ID="lblDiscountPrice" Text="" CssClass="lblPaymentSummary boldText"
                                    Style="float: right;" ClientIDMode="Static"></asp:Label>
                                <br />
                                <asp:Label runat="server" ID="lblPaid" Text="Total Paid" Style="margin-right: 5px;"
                                    CssClass="lblPaymentSummary"></asp:Label>
                                <asp:Label runat="server" ID="lblTotalPaid" Text="" CssClass="lblPaymentSummary boldText"
                                    Style="float: right;" ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class="divOKbtn floatRight">
                            </div>
                        </div>
                    </div>
                    <br />
                </div>
                <img src="../Images/sign_in_bottom_white_bg_new.png" alt="" width="450px" />
            </div>
            <img style="width: 449px;" alt="" src="../Images/sign_in_bottom_white_bg_new.png">
        </div>
    </div>
</asp:Content>
