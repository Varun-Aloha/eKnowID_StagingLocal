<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<%@ Register Src="../Controls/stateDropdown.ascx" TagName="stateDropdown" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="../Scripts/jquery.datatables.js"></script>
    <script src="../Scripts/bpopUp.js" type="text/javascript"></script>
    <link href="../Styles/jquery.datatable.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8">
        /* Formating function for row details */
        var a = "";
        function fnFormatDetails(oTable, nTr) {
            var aData = oTable.fnGetData(nTr);
            GetData(aData[1]);

            var sOut = '<table cellpadding="5" cellspacing="0" border="0"  frame=box style="padding-left:50px;">';
            sOut += '<tr><td><b>Street Address</b></td><td>' + a[0] + ' ' + a[1] + '</td></tr>';
            sOut += '<tr><td>Link to source:</td><td>Could provide a link here</td></tr>';
            sOut += '<tr><td>Extra info:</td><td>And any further details here (images etc)</td></tr>';
            sOut += '</table>';

            return sOut;
        }

        function GetData(StateId) {
            $.ajax({
                type: "POST",
                async: false,
                url: "Default2.aspx/GetCourtAddress",
                data: '{StateID:' + StateId + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }

        function OnSuccess(response) {
            a = response.d;
        }

        function open() {
            /*
            * Insert a 'details' column to the table
            */
            var nCloneTh = document.createElement('th');
            var nCloneTd = document.createElement('td');
            nCloneTd.innerHTML = '<img src="../Images/jquery.datatable/details_open.png">';
            nCloneTd.className = "center";

            $('#example thead tr').each(function () {
                this.insertBefore(nCloneTh, this.childNodes[0]);
            });

            $('#example tbody tr').each(function () {
                this.insertBefore(nCloneTd.cloneNode(true), this.childNodes[0]);
            });

            /*
            * Initialse DataTables, with no sorting on the 'details' column
            */
            var oTable = $('#example').dataTable({
                "aoColumnDefs": [
						{ "bSortable": false, "aTargets": [0] }
					],
                "aaSorting": [[1, 'asc']],
                "bDestroy":true
            });            

            /* Add event listener for opening and closing details
            * Note that the indicator for showing which row is open is not controlled by DataTables,
            * rather it is done here
            */
            $('#example tbody td img').live('click', function () {
                var nTr = $(this).parents('tr')[0];
                if (oTable.fnIsOpen(nTr)) {
                    /* This row is already open - close it */
                    this.src = "../Images/jquery.datatable/details_open.png";
                    oTable.fnClose(nTr);
                }
                else {
                    /* Open this row */
                    this.src = "../Images/jquery.datatable/details_close.png";
                    oTable.fnOpen(nTr, fnFormatDetails(oTable, nTr), 'details');
                }
            });

            

        }
        function Show() {

            $('#divCourtList').bPopup({
                modalClose: false,
                follow: [false, false],
                opacity: 0.6,
                positionStyle: 'absolute'
            });
        }

        function Populate() {
            $("#example").empty();

            $('<thead><tr><th>Office Name</th><th>City</th><th>State</th><th>Zip</th></tr></thead>').appendTo('#example');

//            var controlData = "StateId:1,CourtTypeId:1"
//            controlData = "" + $("#CourtLocater select").val();
//            controlData = controlData + 

            $.ajax({
                type: "POST", 
                async:false,               
                url: "Default2.aspx/GetCourtList",
                data: '{StateId:1,CourtTypeId:1}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $(response.d).appendTo("#example");
                },
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
            open();
            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="divCourtList" style="display: none; width: 500px; height: auto; border-radius: 4px;
            padding: 10px; background-color: White;">
            <div class="width100per">
                <div class="width48per floatLeft" id ="CourtLocater">
                    <uc1:stateDropdown ID="stateDropdown1" runat="server" />
                </div>
                <div class="width48per floatLeft">
                    <select id="ddlCourtType">
                        <option>Select</option>
                        <option>Bankruptcy Court</option>
                        <option>Court of Appeals</option>
                        <option>District Court</option>
                        <option>Pretrial Offices</option>
                        <option>Probation Offices</option>
                    </select>
                    &nbsp;&nbsp;&nbsp;
                    <input type="button" onclick="Populate();" id="btnLocate" class="floatRight" value="Locate" />
                </div>
            </div>
            <br /><br /><br />
            <table cellpadding="0" cellspacing="0" border="0" class="display" id="example">

                <tbody>
                </tbody>
            </table>
        </div>
        <input type="button" onclick="Show();" value="Open" id="btnOpen" />
    </div>
    </form>
</body>
</html>
