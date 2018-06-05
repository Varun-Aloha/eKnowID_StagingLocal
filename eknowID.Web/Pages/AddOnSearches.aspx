<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="AddOnSearches.aspx.cs" Inherits="eknowID.Pages.AddOnSearches"
    ClientIDMode="Static" %>

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
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            //$("#reportsGrid").DataTable();
            $('#reportsGrid').DataTable({
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [4, 6, 7] }]
            });
        });
        function showReportEditPopup(reportId, reportName, description, reportType, price, turnaroundTime, maxSearchCount) {
            
            $('#reportEditModal').modal({ backdrop: 'static' });
            
            $("#hdnReportId").val(reportId);
            $("#txtEditReportName").val(reportName);
            $("#txtEditReportDescription").val(description);
            $("#ddlReprotType").val(reportType);
            $("#txtReportPrice").val(price);
            $("#txtReportTurnaroundTime").val(turnaroundTime);
            $("#txtReportMaxSearchCount").val(maxSearchCount);            

            $("#reportEditModal").modal("show");
        }

        function deleteReport(reportId)
        {
            var reportDetail = {
                reportId: reportId,
            };
            $.ajax({
                type: "POST",
                url: "AddOnSearches.aspx/DeleteReport",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(reportDetail),
                dataType: "json",
                async: false,
                success: function (result) {
                    if (result.d) {
                        alert("Report Deleted successfully.");
                        setTimeout(function () {
                            $("#reportEditModal").modal("hide");
                            location.href = "../pages/AddOnSearches.aspx";
                        }, 1000);
                    }
                    else {
                        alert("Error deleting report, Please try again later.");
                    }
                }
            });
        }

        function AddUpdateReportDetails()
        {
            var reportId = $("#hdnReportId").val();
            var reportName = $("#txtEditReportName").val();
            var reportDescription = $("#txtEditReportDescription").val();
            var reportTypeId = $("#ddlReprotType").val();
            var reportPrice = $("#txtReportPrice").val();
            var reportTurnaroundTime = $("#txtReportTurnaroundTime").val();
            var reportMaxSearchCount = $("#txtReportMaxSearchCount").val();

            var report = {
                "report": {
                    ReportId: reportId,
                    Name: reportName,
                    Description: reportDescription,
                    ReportTypeID: reportTypeId,
                    Price: reportPrice,
                    TurnaroundTime: reportTurnaroundTime,
                    MaxVerificationCount: reportMaxSearchCount
                }
            };
            
            $.ajax({
                type: "POST",
                url: "AddOnSearches.aspx/AddUpdateReportDetails",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(report),
                dataType: "json",
                async: false,
                success: function (result) {

                    if (result.d) {
                        $("#editUserError").html("Information Updated Successfully!");
                        setTimeout(function () {
                            $("#reportEditModal").modal("hide");
                            location.href = "../pages/AddOnSearches.aspx";
                        }, 3000);
                    }
                    else {
                        $("#editUserError").html("Information updation error!");
                    }
                }
            });
        }

    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="modal fade" id="reportEditModal" role="dialog" tabindex='-1'>
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header modal-header-padding padding-10px">
                    <button type="button" class="close" data-dismiss="modal" style="opacity: 1">
                        <img src="../Images/close_btn.png" />
                    </button>
                    <h4 class="modal-title font-size-30px margin-left-15px">Add/Update report details</h4>
                </div>
                <div class="modal-body">
                    <input type="hidden" id="hdnReportId" />
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Report Name</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtEditReportName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Description</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox TextMode="MultiLine" Rows="6" ID="txtEditReportDescription" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Report Type</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:DropDownList runat="server" ID="ddlReprotType" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Report Price($):</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtReportPrice" runat="server" CssClass="form-control digitsOnly" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Turnaround Time:</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtReportTurnaroundTime" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Max. Search Count:</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtReportMaxSearchCount" runat="server" CssClass="form-control digitsOnly" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row pull-right">
                            <div class="col-sm-3">
                                <input style="width:100px;" type="button" id="btnAdd/UpdateReport" class="btn btn-primary" value="Submit" onclick="AddUpdateReportDetails(); return false;"/>
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

    <section class="eknowid-bg">
        <div class="container-fluid" style="margin-left: 40px; margin-right: 40px; padding-top: 110px; padding-bottom: 30px;">
            <asp:Panel ID="pnlReports" runat="server" Visible="true">
                <%-- <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active"><a href="#reports" aria-controls="reports" role="tab" data-toggle="tab">Reports</a></li>
                </ul>--%>
                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane fade in active" id="reports">
                        <div class="row" style="padding: 16px;">
                            <div class="col-lg-12">
                                <h3>Alacart Reports</h3>
                            </div>
                            <div class="col-lg-12">
                                <asp:Panel ID="pnlContainer" runat="server">
                                    <div class="row pull-right" style="margin-top: 8px;">
                                        <div class="col-lg-11">
                                            <% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN) { %>
                                            <input type="button" id="btnAdd" runat="server" class="btn btn-primary btn-user" value="Add New Report" 
                                                onclick="showReportEditPopup(0, '','', '', '', '', 1)" />
                                             <% } %>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Repeater ID="rptReports" runat="server">

                                    <HeaderTemplate>
                                        <table id="reportsGrid" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>Report Name</th>
                                                    <th>Description</th>
                                                    <th>Report Type</th>
                                                    <th>Price</th>
                                                    <th>Turnaround Time</th>
                                                    <th>Max Search Count</th>
                                                    <th>Edit</th>
                                                    <th>Delete</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("Name") %></td>
                                            <td><%# Eval("Description") %> </td>
                                            <td><%# Eval("ReportType.ReportTypeName") %> </td>
                                            <td style="text-align:right;"><%# Eval("Price","{0:C}") %></td>
                                            <td><%# Eval("TurnaroundTime") %> </td>
                                            <td><%# Eval("MaxVerificationCount") %> </td>
                                            <td style="vertical-align:middle;">

                                                <% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN) { %>
                                                <a href="#" class="btn btn-primary btn-edit" onclick="showReportEditPopup('<%# Eval("ReportId") %>','<%# Eval("Name") %>','<%# Eval("Description") %>', '<%# Eval("ReportType.ReportTypeID") %>', '<%# Eval("Price", "{0:F2}") %>', '<%# Eval("TurnaroundTime") %>', '<%# Eval("MaxVerificationCount") %>')">
                                                    <span class="glyphicon glyphicon-edit"></span>&nbsp Edit </a>
                                                <% } %>
                                                                                                                    
                                            </td>

                                            <td style="vertical-align:middle;">
                                                <% if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN) { %>
                                                <a href="#" class="btn btn-danger" onclick="deleteReport('<%# Eval("ReportId") %>')">
                                                    <span class="glyphicon glyphicon-trash"></span>&nbsp Delete 
                                                </a>
                                                <% } %>
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
        </div>
    </section>
</asp:Content>
