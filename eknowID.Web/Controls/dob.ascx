<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="dob.ascx.cs" Inherits="eknowID.Controls.dob" %>
<script type="text/javascript">

    var numDays = {
        '1': 31, '2': 28, '3': 31, '4': 30, '5': 31, '6': 30,
        '7': 31, '8': 31, '9': 30, '10': 31, '11': 30, '12': 31
    };

    function setDays(oMonthSel, oDaysSel, oYearSel) {
        var nDays, oDaysSelLgth, opt, i = 1;
        nDays = numDays[oMonthSel[oMonthSel.selectedIndex].value];
        if (nDays == 28 && oYearSel[oYearSel.selectedIndex].value % 4 == 0)
            ++nDays;
        oDaysSelLgth = oDaysSel.length;
        if (nDays != oDaysSelLgth) {
            if (nDays < oDaysSelLgth)
                oDaysSel.length = nDays;
            else for (i; i < nDays - oDaysSelLgth + 1; i++) {
                opt = new Option(oDaysSelLgth + i, oDaysSelLgth + i);
                oDaysSel.options[oDaysSel.length] = opt;
            }
        }
//        var oForm = oMonthSel.form;
//        var month = oMonthSel.options[oMonthSel.selectedIndex].value;
//        var day = oDaysSel.options[oDaysSel.selectedIndex].value;
//        var year = oYearSel.options[oYearSel.selectedIndex].value;
//        oForm.hidden.value = month + '/' + day + '/' + year;
    } 

</script>

<select name="month1" id="month1" onchange="setDays(this,day,year)" class="ddlValidation" style="width:79px;">
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
<select name="day" id="day" onchange="setDays(month1,this,year)" class="ddlValidation">
<option value="0">Day</option>
<option value="1">1</option>
<option value="2">2</option>
<option value="3">3</option>
<option value="4">4</option>
<option value="5">5</option>
<option value="6">6</option>
<option value="7">7</option>
<option value="8">8</option>
<option value="9">9</option>
<option value="10">10</option>
<option value="11">11</option>
<option value="12">12</option>
<option value="13">13</option>
<option value="14">14</option>
<option value="15">15</option>
<option value="16">16</option>
<option value="17">17</option>
<option value="18">18</option>
<option value="19">19</option>
<option value="20">20</option>
<option value="21">21</option>
<option value="22">22</option>
<option value="23">23</option>
<option value="24">24</option>
<option value="25">25</option>
<option value="26">26</option>
<option value="27">27</option>
<option value="28">28</option>
<option value="29">29</option>
<option value="30">30</option>
<option value="31">31</option>
</select>
<asp:DropDownList ID ="year" runat="server" onchange="setDays(month1,day,this)" ClientIDMode="Static" CssClass="ddlValidation"/>
<%--<select name="year" id="year" onchange="setDays(month,day,this)">

</select>--%>
