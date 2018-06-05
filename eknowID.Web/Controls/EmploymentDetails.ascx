<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmploymentDetails.ascx.cs"
    Inherits="eknowID.Controls.EmploymentDetails" %>
<%@ Register Src="stateDropdown.ascx" TagName="stateDropdown" TagPrefix="uc1" %>
<%@ Register Src="year.ascx" TagName="year" TagPrefix="uc2" %>
<script type="text/javascript" language="javascript">

    $(function () {

        $("#ddlYearStart_1 select").addClass("ddlValidation");

        var startdateCondition = "#ddlMonthStart_1";
        $("#ddlYearStart_1 select").attr("ddlStartdate", startdateCondition);

        var condition = "#ddlMonthStart_1,#ddlYearStart_1 select";
        $("#ddlYearEnd_1 select").attr("ddlendyear", condition);

        //        var myselect = document.getElementById("ddlYearStart_1"), year = new Date().getFullYear();
        //        myselect.add(new Option("Year", 0), null);
        //        var gen = function (max) { do { myselect.add(new Option(year, year), null); max++; year--; } while (max < 100); } (1);

        //        var yearEnd = document.getElementById("ddlYearEnd_1"), year = new Date().getFullYear();
        //        yearEnd.add(new Option("Year", 0), null);
        //        var gen = function (max) { do { yearEnd.add(new Option(year, year), null); max++; year--; } while (max < 100); } (1);
    });

//    $(function () {
//        $("#txtStartDate_1").datepicker({
//            changeYear: true,
//            changeMonth: true,
//            yearRange: "-100:+0",
//            onSelect: function (selected) {
//                $('#txtEndDate_1').datepicker("option", "minDate",
//                selected)
//                $("#txtStartDate_1").valid();
//            }
//        });
//        $("#txtEndDate_1").datepicker({
//            changeYear: true,
//            changeMonth: true,
//            yearRange: "-100:+0",
//            onSelect: function (selected) {
//                $('#txtStartDate_1').datepicker("option", "maxDate",
//                selected)
//                $("#txtEndDate_1").valid();
//            }
//        });


//        $('input[id^="txtStartDate_"]').click(function () {
//            inputName = $(this).attr('id');
//            number = inputName.split("_")[1]; // get [number]

//        }).datepicker({
//            changeYear: true,
//            changeMonth: true,
//            //dateFormat: 'mm-dd-yy',
//            onSelect: function (selected) {
//                $('#txtEndDate_' + number).datepicker("option", "minDate",
//                selected)
//                $('#txtStartDate_' + number).valid();
//            }
//        });

//        $('input[id^="txtEndDate_"]').click(function () {
//            inputName = $(this).attr('id');
//            number = inputName.split("_")[1]; // get [number]

//        }).datepicker({
//            changeYear: true,
//            changeMonth: true,
//            //dateFormat: 'mm-dd-yy',
//            onSelect: function (selected) {
//                $('#txtStartDate_' + number).datepicker("option", "maxDate",
//                selected)
//                $('#txtEndDate_' + number).valid();
//            }
//        });
//    });

//    function ShowDatePickerStart(Control) {
//        var id = Control.id.split("_")[1];
//        $("#txtStartDate_" + id).datepicker('show');
//    }

//    function ShowDatePickerEnd(Control) {
//        var id = Control.id.split("_")[1];
//        $("#txtEndDate_" + id).datepicker('show');
//    }


    $(function () {
        $("input[type='checkbox']").click(function () {

            var id = this.id;
            id = id.split("_");
                        
            if ($(this).is(':checked')) {

                //$(".empAddnew").css("display", "none");

                $("#ddlMonthEnd_" + id[1]).val("0");
                $("#ddlYearEnd_" + id[1] + " select").val("0");

                $("#ddlYearEnd_" + id[1] + " select").prop("disabled", "disabled");
                $("#ddlMonthEnd_" + id[1]).prop("disabled", "disabled");
            }
            else {

                //$(".empAddnew").css("display", "inline");

                $("#ddlYearEnd_" + id[1] + " select").prop("disabled", false);
                $("#ddlMonthEnd_" + id[1]).prop("disabled", false);
            }
        });
        var qty = Number($("[id*=employmentDetailsCount]").val());
        if(1 < qty)
        {
            for(var i=1; i< qty; i++)
            {
                $("[id*=EmployeeInfoContainer]").find("#btnAddNew").click();                
            }
            $("[id*=EmployeeInfoContainer]").find("[id*=btnRemoveEmpControl]").hide();
            $("[id*=EmployeeInfoContainer]").find("#btnAddNew").hide();
        }
    });
  
</script>
<style type="text/css">
    .fontType
    {
        font-family: Verdana,Arial,sans-serif;
    }
    input[type="checkbox"]
    {
        margin-left:0px;
    }
</style>
<div style="height: 435px;" id="EmployeeInfoContainer" class="width100per">
    <input id="employmentDetailsCount" type="hidden" value="" runat="server"/>
    <div id="original" class="border1Solid padding21 width100per">
        <div class="floatRight removebtn">
            <img src="../Images/close_20x20.png" id="btnRemoveEmpControl" alt="" class="remove marginTop-20 marginRight-10 displayNone cursorPointer"
                title="Remove" onclick="RemoveEmpControl(this);" /></div>
        <h3 class="margin_0px">
            Professional Experience
        </h3>
        <div style="height: 125px;">
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Organization Name</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtOrgName_1" runat="server" CssClass="width180 required validateTab"
                        ClientIDMode="Static" MaxLength="50"></asp:TextBox><span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    City</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtProfCity_1" runat="server" CssClass="width180 charSpaceOnly required LettersWithSpace validateTab"
                        ClientIDMode="Static" MaxLength="30"></asp:TextBox><span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    State/Province
                </div>
                <div class="floatLeft width245" id="ddlStateEmpDetails_1">
                    <uc1:stateDropdown ID="ddlStateEmp" runat="server" />
                    <span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Telephone
                </div>
                <div class="floatLeft" id="Div1">
                    <asp:TextBox ID="txtTelephoneNumber_1" runat="server" CssClass="width180 required number digitsOnly validateTab"
                        ClientIDMode="Static" MaxLength="10" minlength="10" /><span class="red asterisk">*</span>
                </div>
            </div>
        </div>
        <div>
            <h3>
                Position Information</h3>
        </div>
        <div style="height: 185px;">
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Position Title</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtTitle_1" runat="server" CssClass="width180  required validateTab"
                        ClientIDMode="Static" MaxLength="30"></asp:TextBox><span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Start Date</div>
                <div class="floatLeft">
                    <select name="ddlMonthStart_1" id="ddlMonthStart_1" class="ddlValidation floatLeft">
                        <option value="0">Month</option>
                        <option value="1">January</option>
                        <option value="2">February</option>
                        <option value="3">March</option>
                        <option value="4">April</option>
                        <option value="5">May</option>
                        <option value="6">June</option>
                        <option value="7">July</option>
                        <option value="8">August</option>
                        <option value="9">September</option>
                        <option value="10">October</option>
                        <option value="11">November</option>
                        <option value="12">December</option>
                    </select><span class="red asterisk floatLeft">*</span>                    
                    <div id="ddlYearStart_1" class="floatLeft yearContainer" style="width:108px;">
                        <uc2:year ID="year1" runat="server" />
                        <span class="red asterisk floatLeft">*</span>
                    </div>
                    
                </div>                
            </div>
            <div class="clearBoth paddingTop10">
                <div class="width180 floatLeft">
                    End Date</div>
                <div class="floatLeft">
                    <select name="ddlMonthEnd_1" id="ddlMonthEnd_1" ddlEndMonth="#ddlMonthStart_1,#ddlYearStart_1 select,#ddlYearEnd_1 select" class="floatLeft">
                        <option value="0">Month</option>
                        <option value="1">January</option>
                        <option value="2">February</option>
                        <option value="3">March</option>
                        <option value="4">April</option>
                        <option value="5">May</option>
                        <option value="6">June</option>
                        <option value="7">July</option>
                        <option value="8">August</option>
                        <option value="9">September</option>
                        <option value="10">October</option>
                        <option value="11">November</option>
                        <option value="12">December</option>
                    </select>

                    <div id="ddlYearEnd_1" class="floatLeft yearContainer" style="width:108px; margin-left:7px;">
                        <uc2:year ID="year2" runat="server" />                        
                    </div>                 
                </div>
           
            </div>
            <div class="clearBoth paddingTop10">
                <div class="width180 floatLeft" style="height: 1px;">
                </div>
                <div class="floatLeft">
                    <asp:CheckBox ID ="chkAttendingEmp_1" runat="server" ClientIDMode="Static" Text="Presently working here." CssClass="chkAttendingEmp"/>                
                </div>
            </div>
            <div class="clearBoth paddingTop10" style="margin-bottom: 5px;">
                <div class="width180 floatLeft">
                    Duties/Description</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtDescription_1" TextMode="MultiLine" runat="server" CssClass="width180 validateTab"
                        ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="hiddenContainer">
            <input type="hidden" class="positionInfo" id="hdnEmploymentDetailsId_1" />
        </div>
    </div>
    <div id="container">
    </div>
    <div class="divAddNewRefRow width100per marginTop5" style="min-height:15px;">
        <input id="btnAddNew" class="addNewRefRow floatRight empAddnew" type="button" value="+ Add New"
            onclick="CreateEmpControl();" style="margin-right: -51px;" />
    </div>
</div>
