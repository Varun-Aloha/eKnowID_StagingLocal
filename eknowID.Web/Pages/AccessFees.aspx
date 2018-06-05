<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="AccessFees.aspx.cs" Inherits="eknowID.Pages.AccessFees"  
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
            $('#stateCriminalFeesGrid').DataTable({
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [4, 5] }]
            });
            $('#stateCountyFeesGrid').DataTable({
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [3, 4] }]
            });
            $('#stateFederalFeesGrid').DataTable({
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [3, 4] }]
            });
        });

        function showStateCriminalAccessFeeEditPopup(stateId, stateName, Fee, availability, turnaroundTime) {

            $('#stateCriminalEditModal').modal({ backdrop: 'static' });            
            $("#hdnStateId").val(stateId);
            $("#lblStateName").text(stateName);
            $("#txtStateCriminalFees").val(Fee);
            $("#txtAvailability").val(availability);
            $("#txtTurnAroundTime").val(turnaroundTime);
            if (0 === stateId)
            {
                $("#lblStateName").hide();
                if (0 >= $("#stateCriminalEditModal").find("#ddlStates").length) {
                    $("#lblStateName").after($("#ddlStates")[0].outerHTML);
                }
                $("#stateCriminalEditModal").find("#ddlStates").show();
            }
            else
            {
                $("#lblStateName").show();
                $("#stateCriminalEditModal").find("#ddlStates").hide();
            }
           

            $("#stateCriminalEditModal").modal("show");
        }

        function showCountyCriminalAccessFeeEditPopup(stateId, countyId, stateName, countyName, Fee) {            
            $('#stateCountyEditModal').modal({ backdrop: 'static' });

            $("#hdnCountyId").val(countyId);
            $("#hdnCountyStateId").val(stateId);
            $("#lblCountyStateName").text(stateName);
            $("#txtCountyFees").val(Fee);
            $("#txtCountyName").val(countyName);            
            if (0 === countyId) {
                $("#lblCountyStateName").hide();
                if (0 >= $("#stateCountyEditModal").find("#ddlStates").length) {
                    $("#lblCountyStateName").after($("#ddlStates")[0].outerHTML);
                }
                $("#stateCountyEditModal").find("#ddlStates").show();
            }
            else {
                $("#lblCountyStateName").show();
                $("#stateCountyEditModal").find("#ddlStates").hide();
            }

            $("#stateCountyEditModal").modal("show");
        }

        function showFederalCriminalAccessFeeEditPopup(stateId, federalId, stateName, DistrictName, Fee) {
            $('#stateFederalEditModal').modal({ backdrop: 'static' });            
            $("#hdnFederalId").val(federalId);
            $("#hdnFederalStateId").val(stateId);
            $("#lblFederalStateName").text(stateName);
            $("#txtDistrictFees").val(Fee);
            $("#txtDistrictName").val(DistrictName);
            if (0 === federalId) {
                $("#lblFederalStateName").hide();
                if (0 >= $("#stateFederalEditModal").find("#ddlStates").length) {
                    $("#lblFederalStateName").after($("#ddlStates")[0].outerHTML);
                }
                $("#stateFederalEditModal").find("#ddlStates").show();
            }
            else {
                $("#lblFederalStateName").show();
                $("#stateFederalEditModal").find("#ddlStates").hide();
            }

            $("#stateFederalEditModal").modal("show");
        }

        function AddUpdateStateCriminalAccessFees()
        {
            var stateId = $("#hdnStateId").val();           
            var accessFees = $("#txtStateCriminalFees").val();
            var avilability = $("#txtAvailability").val();
            var turnAroundTime = $("#txtTurnAroundTime").val();
            if (0 === stateId)
            {
                stateId = $("#stateCriminalEditModal").find("#ddlStates").val();
            }

            var objStateCriminalAccessFees = {
                stateId: stateId,
                accessFees: accessFees,
                avilability: avilability,
                turnAroundTime: turnAroundTime
            };

            $.ajax({
                type: "POST",
                url: "AccessFees.aspx/AddUpdateStateCriminalAccessFees",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(objStateCriminalAccessFees),
                dataType: "json",
                async: false,
                success: function (result) {
                    window.location.reload();
                }
            });
        }

        function AddUpdateCountyCriminalAccessFees() {            
            var countyId = $("#hdnCountyId").val();
            var accessFees = $("#txtCountyFees").val();
            var countyName = $("#txtCountyName").val(); 
            var stateId = $("#hdnCountyStateId").val();
            if ("0" === countyId) {
                stateId = $("#stateCountyEditModal").find("#ddlStates").val();
            }
            var objCountyCriminalAccessFees = {
                stateId : stateId,
                countyId: countyId,
                countyName: countyName,
                accessFees: accessFees
            };

            $.ajax({
                type: "POST",
                url: "AccessFees.aspx/AddUpdateCountyCriminalAccessFees",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(objCountyCriminalAccessFees),
                dataType: "json",
                async: false,
                success: function (result) {
                    window.location.reload();
                }
            });
        }

        function AddUpdateFederalCriminalAccessFees() {
            var districtId = $("#hdnFederalId").val();
            var accessFees = $("#txtDistrictFees").val();
            var districtName = $("#txtDistrictName").val();
            var stateId = $("#hdnFederalStateId").val();

            if ("0" === districtId) {
                stateId = $("#stateFederalEditModal").find("#ddlStates").val();
            }
            var objCountyCriminalAccessFees = {
                stateId : stateId,
                districtId: districtId,
                districtName: districtName,
                accessFees: accessFees
            };

            $.ajax({
                type: "POST",
                url: "AccessFees.aspx/AddUpdateFederalCriminalAccessFees",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(objCountyCriminalAccessFees),
                dataType: "json",
                async: false,
                success: function (result) {
                    window.location.reload();
                }
            });
        }

        function DeleteStateCriminalAccessFees(stateId) {           
            var objStateCriminalAccessFees = {
                stateId: stateId
            };

            $.ajax({
                type: "POST",
                url: "AccessFees.aspx/DeleteStateCriminalAccessFees",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(objStateCriminalAccessFees),
                dataType: "json",
                async: false,
                success: function (result) {
                    window.location.reload();
                }
            });
        }

        function DeleteCountyCriminalAccessFees(countyId) {            
            var objCountyCriminalAccessFees = {
                countyId: countyId
            };

            $.ajax({
                type: "POST",
                url: "AccessFees.aspx/DeleteCountyCriminalAccessFees",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(objCountyCriminalAccessFees),
                dataType: "json",
                async: false,
                success: function (result) {
                    window.location.reload();
                }
            });
        }

        function DeleteFederalCriminalAccessFees(districtId) {            
            var objCountyCriminalAccessFees = {
                districtId: districtId
            };

            $.ajax({
                type: "POST",
                url: "AccessFees.aspx/DeleteFederalCriminalAccessFees",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(objCountyCriminalAccessFees),
                dataType: "json",
                async: false,
                success: function (result) {
                    window.location.reload();
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ClientIDMode="Static" ID="ddlStates" runat="server" style="display:none"></asp:DropDownList>
    <div class="modal fade" id="stateCriminalEditModal" role="dialog" tabindex='-1'>
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header modal-header-padding padding-10px">
                    <button type="button" class="close" data-dismiss="modal" style="opacity: 1">
                        <img src="../Images/close_btn.png" />
                    </button>
                    <h4 class="modal-title font-size-30px margin-left-15px">Add/Update State Criminal Access Fees</h4>
                </div>
                <div class="modal-body">
                    <input type="hidden" id="hdnStateId" />
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>State Name</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:Label ID="lblStateName" runat="server" CssClass="form-control" ClientIDMode="Static" disabled></asp:Label>                                
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Access Fee</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox TextMode="Number" step="0.01" ID="txtStateCriminalFees" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Availability</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtAvailability" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Turnaround Time:</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtTurnAroundTime" runat="server" CssClass="form-control digitsOnly" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>                                       
                    <div class="form-group">
                        <div class="row pull-right">
                            <div class="col-sm-3">
                                <input style="width:100px;" type="button" id="btnAddUpdateStateCriminalAccessFees" class="btn btn-primary" value="Submit" onclick="AddUpdateStateCriminalAccessFees(); return false;"/>
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

    <div class="modal fade" id="stateCountyEditModal" role="dialog" tabindex='-1'>
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header modal-header-padding padding-10px">
                    <button type="button" class="close" data-dismiss="modal" style="opacity: 1">
                        <img src="../Images/close_btn.png" />
                    </button>
                    <h4 class="modal-title font-size-30px margin-left-15px">Add/Update County Criminal Access Fees</h4>
                </div>
                <div class="modal-body">
                    <input type="hidden" id="hdnCountyId" />
                    <input type="hidden" id="hdnCountyStateId" />
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>State Name</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:Label ID="lblCountyStateName" runat="server" CssClass="form-control" ClientIDMode="Static" disabled></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>County Name</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtCountyName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Access Fee</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox TextMode="Number" step="0.01" ID="txtCountyFees" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>                                                           
                    <div class="form-group">
                        <div class="row pull-right">
                            <div class="col-sm-3">
                                <input style="width:100px;" type="button" id="btnAddUpdateCountyAccessFees" class="btn btn-primary" value="Submit" onclick="AddUpdateCountyCriminalAccessFees(); return false;"/>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div id="editCountyFeesError" class="Error"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="stateFederalEditModal" role="dialog" tabindex='-1'>
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header modal-header-padding padding-10px">
                    <button type="button" class="close" data-dismiss="modal" style="opacity: 1">
                        <img src="../Images/close_btn.png" />
                    </button>
                    <h4 class="modal-title font-size-30px margin-left-15px">Add/Update Federal Criminal Access Fees</h4>
                </div>
                <div class="modal-body">
                    <input type="hidden" id="hdnFederalId" />
                    <input type="hidden" id="hdnFederalStateId" />
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>State Name</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:Label ID="lblFederalStateName" runat="server" CssClass="form-control" ClientIDMode="Static" disabled></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>District</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtDistrictName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-3">
                                <label>Access Fee</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox TextMode="Number" step="0.01" ID="txtDistrictFees" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>                                                           
                    <div class="form-group">
                        <div class="row pull-right">
                            <div class="col-sm-3">
                                <input style="width:100px;" type="button" id="btnAddUpdateFederalCriminalAccessFees" class="btn btn-primary" value="Submit" onclick="AddUpdateFederalCriminalAccessFees(); return false;"/>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div id="editFederalAccessFeesError" class="Error"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <section class="eknowid-bg">
        <div class="container-fluid" style="margin-left: 40px; margin-right: 40px; padding-top: 110px; padding-bottom: 30px;">
            <asp:Panel ID="pnlReports" runat="server" Visible="true">
                 <ul class="nav nav-tabs" role="tablist">                   
                    <li role="presentation" class="active"><a href="#StateCriminalFees-tab" aria-controls="StateCriminalFees-tab" role="tab" data-toggle="tab">State Criminal</a></li>
                    <li role="presentation"><a href="#StateCountyFees-tab" aria-controls="StateCountyFees-tab" role="tab" data-toggle="tab" >State County</a></li>
                    <li role="presentation"><a href="#StateFederalFees-tab" aria-controls="StateFederalFees-tab" role="tab" data-toggle="tab">State Federal</a></li>
                </ul>
                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane fade in active" id="StateCriminalFees-tab">
                        <div class="row" style="padding: 16px; height: 250px;">
                            <div class="col-lg-12">
                                <h3>State Criminal Access Fees</h3>
                            </div>
                            <div class="col-lg-12">
                                <asp:Panel ID="pnlContainer" runat="server">
                                    <div class="row pull-right" style="margin-top: 8px;">
                                        <div class="col-lg-11">                                            
                                            <a href="#" runat="server" id="linkAddStateCriminalAccessFees" class="btn btn-primary btn-user" onclick="showStateCriminalAccessFeeEditPopup(0, '', 0, '', '')">
                                                <span class="glyphicon glyphicon-plus"></span>&nbsp Add 
                                            </a>                                                                                         
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Repeater ID="rptStateCriminalFees" runat="server">

                                    <HeaderTemplate>
                                        <table id="stateCriminalFeesGrid" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>State Name</th>
                                                    <th>Fees</th>
                                                    <th>Availability</th>
                                                    <th>TurnAroundTime</th>                                                    
                                                    <th>Edit</th>
                                                    <th>Delete</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("Name") %></td>
                                                    <td><%# Eval("Fee","{0:C}") %> </td>
                                                    <td><%# Eval("Availability") %> </td>
                                                    <td><%# Eval("TurnAroundTime") %></td>                                           
                                                    <td>

                                                        <%                                            
                                                            if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN) { %>
                                                        <a href="#" class="btn btn-primary btn-edit" onclick="showStateCriminalAccessFeeEditPopup('<%# Eval("StateId") %>','<%# Eval("Name") %>','<%# Eval("Fee", "{0:F2}") %>', '<%# Eval("Availability") %>', '<%# Eval("TurnAroundTime") %>')"><span class="glyphicon glyphicon-edit"></span>&nbsp Edit </a>
                                                        <% } %>
                                                                                                                    
                                                    </td>
                                                    <td>
                                                        <a href="#" class="btn btn-danger" onclick="DeleteStateCriminalAccessFees('<%# Eval("StateId") %>')">
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
                    <div role="tabpanel" class="tab-pane fade in" id="StateCountyFees-tab">
                        <div class="row" style="padding: 16px; height: 250px;">
                            <div class="col-lg-12">
                                <h3>State County Access Fees</h3>
                            </div>
                            <div class="col-lg-12">
                                <asp:Panel ID="Panel1" runat="server">
                                    <div class="row pull-right" style="margin-top: 8px;">
                                        <div class="col-lg-11">   
                                            <a href="#" runat="server" id="linkAddCountyCriminalAccessFees" class="btn btn-primary btn-user" onclick="showCountyCriminalAccessFeeEditPopup(0, 0, '', '', 0)">
                                                <span class="glyphicon glyphicon-plus"></span>&nbsp Add 
                                            </a>                                                                                         
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Repeater ID="rptStateCountyAccessFees" runat="server">

                                    <HeaderTemplate>
                                        <table id="stateCountyFeesGrid" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>State Name</th>
                                                    <th>County</th>
                                                    <th>Fees</th>                                                                                                       
                                                    <th>Edit</th>
                                                    <th>Delete</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("State.Name") %></td>
                                                    <td><%# ((string)Eval("County") == "") ? "All Counties" : Eval("County") %> </td>
                                                    <td><%# Eval("DistrictCourtFees", "{0:C}") %> </td>                                                                                             
                                                    <td>

                                                        <%                                            
                                                            if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN) { %>
                                                        <a href="#" class="btn btn-primary btn-edit" onclick="showCountyCriminalAccessFeeEditPopup('<%# Eval("StateId") %>', '<%# Eval("Id") %>', '<%# Eval("State.Name") %>', '<%# Eval("County") %>', '<%# Eval("DistrictCourtFees", "{0:F2}") %>')"><span class="glyphicon glyphicon-edit"></span>&nbsp Edit </a>
                                                        <% } %>
                                                                                                                    
                                                    </td>

                                                    <td>
                                                        <a href="#" class="btn btn-danger" onclick="DeleteCountyCriminalAccessFees('<%# Eval("Id") %>')">
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
                    <div role="tabpanel" class="tab-pane fade in" id="StateFederalFees-tab">
                        <div class="row" style="padding: 16px; height: 250px;">
                            <div class="col-lg-12">
                                <h3>State Federal Access Fees</h3>
                            </div>
                            <div class="col-lg-12">
                                <asp:Panel ID="Panel2" runat="server">
                                    <div class="row pull-right" style="margin-top: 8px;">
                                        <div class="col-lg-11"> 
                                            <a href="#" runat="server" id="linkAddFederalCriminalAccessFees" class="btn btn-primary btn-user" onclick="showFederalCriminalAccessFeeEditPopup(0, 0, '', '', 0)">
                                                <span class="glyphicon glyphicon-plus"></span>&nbsp Add 
                                            </a>                                                                                         
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Repeater ID="rptStateFederalAccessFees" runat="server">

                                    <HeaderTemplate>
                                        <table id="stateFederalFeesGrid" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>State Name</th>
                                                    <th>District</th>
                                                    <th>Fees</th>                                                                                                    
                                                    <th>Edit</th>
                                                    <th>Delete</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("State.Name") %></td>
                                                    <td><%# Eval("DistrictCourt") %> </td>
                                                    <td><%# Eval("DistrictCourtFees", "{0:C}") %> </td>                                                                                               
                                                    <td>

                                                        <%                                            
                                                            if (userType == (int)EknowIDLib.UserTypeEnum.SUPER_ADMIN) { %>
                                                        <a href="#" class="btn btn-primary btn-edit" onclick="showFederalCriminalAccessFeeEditPopup('<%# Eval("StateId") %>', '<%# Eval("Id") %>', '<%# Eval("State.Name") %>', '<%# Eval("DistrictCourt") %>', '<%# Eval("DistrictCourtFees", "{0:F2}") %>')"><span class="glyphicon glyphicon-edit"></span>&nbsp Edit </a>
                                                        <% } %>
                                                                                                                    
                                                    </td>

                                                    <td>
                                                        <a href="#" class="btn btn-danger" onclick="DeleteFederalCriminalAccessFees('<%# Eval("Id") %>')">
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
        </div>
    </section>
</asp:Content>
