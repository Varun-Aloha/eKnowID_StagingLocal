<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RC_EducationalDetails.ascx.cs"
    Inherits="eknowID.Controls.RC_EducationalDetails" %>
<%@ Register Src="stateDropdown.ascx" TagName="stateDropdown" TagPrefix="uc1" %>
<%@ Register Src="year.ascx" TagName="year" TagPrefix="uc2" %>
<script type="text/javascript">

    $(function () {
        $("#ddlYearStart select").addClass("ddlValidation");
        $("#ddlPostYearStart select").addClass("ddlValidation");

        var startCondition = "#ddlMonthStart";
        $("#ddlYearStart select").attr("ddlStartdate", startCondition);

        var startCondition1 = "#ddlPostMonthStart";
        $("#ddlPostYearStart select").attr("ddlStartdate", startCondition1);

        var condition = "#ddlMonthStart,#ddlYearStart select";
        $("#ddlYearEnd select").attr("ddlendyear", condition);

        var condition1 = "#ddlPostMonthStart,#ddlPostYearStart select";
        $("#ddlPostYearEnd select").attr("ddlendyear", condition1);

    });

    function show() {
        document.getElementById('Post').style.display = 'block';
        document.getElementById('divUserPost').style.display = 'block';
        document.getElementById('BtnAdd').style.display = 'none';
        $('#chkPostAttending').prop("checked", false);
        $("#ddlPostMonthStart").val("0");
        $("#ddlPostYearStart select").val("0");
    }
    function Hide() {

        document.getElementById('Post').style.display = 'none';
        document.getElementById('BtnAdd').style.display = 'block';
        document.getElementById('divUserPost').style.display = 'none';
        $(".clearValue").val('');
        $("#ddlStatePostGraduation select").val('0');


        RemovePostGradFromDatabase();
    }

    function RemovePostGradFromDatabase() {

        var postGradId = $("#hdnPostGraduation").val();
        if (postGradId != "") {


            $.ajax({
                cache: false,
                type: "POST",
                url: "UserInfoHandling.aspx/DeletePostGradById",
                contentType: "application/json; charset=utf-8",
                data: "{PostGraduationId:" + postGradId + "}",
                dataType: "json",
                success: function (result) {
                    if (result.d == "Session Expired")
                        sessioTimeOut();
                    else
                        OpenDialog("Post graduation removed successfully.");
                }
            });
        }
    }

    $(function () {
        $("#chkAttending").click(function () {

            if ($('#chkAttending').is(':checked')) {

//                $('#chkPostAttending').prop("checked", false);
//                $("#ddlPostYearEnd select").prop("disabled", false);
//                $("#ddlPostMonthEnd").prop("disabled", false);

//                $(".addPostButton").css("display", "none");              

                $("#ddlYearEnd select").val("0");
                $("#ddlMonthEnd").val("0");

                $("#ddlYearEnd select").prop("disabled", "disabled");
                $("#ddlMonthEnd").prop("disabled", "disabled");
            }
            else {
//                if ($("#divUserPost").css("display") == "none" && $("#Post").css("display") == "none") {
//                    $(".addPostButton").css("display", "inline");
//                }

                $("#ddlYearEnd select").prop("disabled", false);
                $("#ddlMonthEnd").prop("disabled", false);
            }
        });
    });


    $(function () {
        $("#chkPostAttending").click(function () {

            if ($('#chkPostAttending').is(':checked')) {

//                $('#chkAttending').prop("checked", false);
//                $("#ddlYearEnd select").prop("disabled", false);
//                $("#ddlMonthEnd").prop("disabled", false);

                $("#ddlPostYearEnd select").val("0");
                $("#ddlPostMonthEnd").val("0");

                $("#ddlPostYearEnd select").prop("disabled", "disabled");
                $("#ddlPostMonthEnd").prop("disabled", "disabled");
            }
            else {

                $("#ddlPostYearEnd select").prop("disabled", false);
                $("#ddlPostMonthEnd").prop("disabled", false);
            }
        });
    });

    $(function () {
        if ($('#chkPostAttending').is(':checked')) {

            $("#ddlPostYearEnd select").val("0");
            $("#ddlPostMonthEnd").val("0");
            
            $("#ddlPostYearEnd select").prop("disabled", "disabled");
            $("#ddlPostMonthEnd").prop("disabled", "disabled");
        }
    });

    $(function () {
        if ($('#chkAttending').is(':checked')) {

            $("#ddlYearEnd select").val("0");
            $("#ddlMonthEnd").val("0");

            $("#ddlYearEnd select").prop("disabled", "disabled");
            $("#ddlMonthEnd").prop("disabled", "disabled");
        }
    });

</script>
<!--[if IE]>
     <style type="text/css">
   	    .width105
        {
        width:107px !important;
        }
    </style>
   <![endif]-->
   <style type="text/css">
      input[type="checkbox"]
        {
            margin-left:0px;
            }
   </style>
<div id="EducationInfoContainer" class="width100per">
    <div class="border1Solid padding21 width100per">
        <h3 class="margin_0px">
            Education Details
        </h3>
        <div style="height: 245px;">
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Diploma / Degree
                </div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtBasic" runat="server" ClientIDMode="Static" CssClass="width180 required validateTab"
                        MaxLength="100"></asp:TextBox><span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Specialization</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtSpecialization" runat="server" ClientIDMode="Static" CssClass="width180 required validateTab"
                        MaxLength="100"></asp:TextBox><span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    University / Institute
                </div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtUniversity" runat="server" ClientIDMode="Static" CssClass="width180 required validateTab"
                        MaxLength="100" /><span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    City</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtMunicipality" runat="server" ClientIDMode="Static" CssClass="width180 required validateTab"
                        MaxLength="30"></asp:TextBox><span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Region / State</div>
                <div class="floatLeft width245" id="ddlStateEducational">
                    <uc1:stateDropdown ID="ddlStateEducation" runat="server" />
                    <span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px Start">
                <div class="floatLeft width180">
                    Start Date</div>
                <div class="floatLeft">
                    <select name="ddlMonthStart" id="ddlMonthStart" class="ddlValidation" runat="server" style="float:left !important;"
                        clientidmode="Static">
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
                    <div id="ddlYearStart" style="width: 108px; float: left;">
                        <uc2:year ID="year1" runat="server" />                        
                        <span class="red asterisk">*</span>
                    </div>
                </div>                
            </div>
            <div class="clearBoth " style="padding-top: 10px">
                <div class="width180 floatLeft">
                    End Date</div>
                <div class="floatLeft">                    
                    <select name="ddlMonthEnd" id="ddlMonthEnd" ddlendmonth="#ddlMonthStart,#ddlYearStart select,#ddlYearEnd select"
                        runat="server" clientidmode="Static" class="floatLeft">
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
                    <div id="ddlYearEnd" class="floatLeft" style="width: 108px; margin-left: 7px; float:left;">
                        <uc2:year ID="year2" runat="server" />
                    </div>
                </div>
             
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft" style="height: 1px;">
                </div>
                <div class="floatLeft" style="margin-top: 2px;">
                   <asp:CheckBox ID ="chkAttending" runat="server" ClientIDMode="Static" Text="Currently attending."/>
                </div>
            </div>
        </div>
    </div>
    <div id="divUserPost" class="marginTop20 border1Solid padding21 width100per displayNone"
        runat="server" clientidmode="Static">
        <div class="floatRight removebtn" title="Remove" style="margin-top: -20px; margin-right: -20px;">
            <img src="../Images/close_20x20.png" alt="" class="remove cursorPointer" style="padding-right: 10px;"
                id="btnpostGraduation_1" onclick="Hide();" /></div>
        <div id="Post" class="" style="height: 245px; display: none;" runat="server" clientidmode="Static">            
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Post Graduation</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtPostGraduation" runat="server" ClientIDMode="Static" CssClass="width180 required clearValue validateTab"
                        MaxLength="100"></asp:TextBox><span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Specialization</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtPostSpecialization" runat="server" ClientIDMode="Static" CssClass="width180 required clearValue validateTab"
                        MaxLength="100"></asp:TextBox><span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    University / Institute
                </div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtPostUniversity" runat="server" ClientIDMode="Static" CssClass="width180 required clearValue validateTab"
                        MaxLength="100" /><span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    City</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtPostMuncipality" runat="server" ClientIDMode="Static" CssClass="width180 required clearValue validateTab"
                        MaxLength="30"></asp:TextBox><span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Region / State</div>
                <div class="floatLeft width245" id="ddlStatePostGraduation">
                    <uc1:stateDropdown ID="ddlStatePostEducation" runat="server" />
                    <span class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Start Date</div>
                <div class="floatleft">            
                    <select name="month" id="ddlPostMonthStart"  class="ddlValidation" style="float:left !important;" runat="server" clientidmode="Static">
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
                    </select><span class="red asterisk floatLeft" >*</span>                 
                    <div id="ddlPostYearStart" style ="width:108px; float:left;">
                        <uc2:year ID="year3" runat="server" />
                        <span class="red asterisk">*</span>
                    </div>                   
                </div>
            </div>
            <div class="clearBoth " style="padding-top: 10px">
                <div class="width180 floatLeft">
                    End Date</div>
                <div class="floatLeft">                    
                    <select name="month" id="ddlPostMonthEnd"  style="float:left !important;" ddlendmonth="#ddlPostMonthStart,#ddlPostYearStart select,#ddlPostYearEnd select" runat="server" clientidmode="Static">
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
                    <div id="ddlPostYearEnd" style ="width:108px; float:left; margin-left:7px;">
                        <uc2:year ID="year4" runat="server" />
                    </div>                    
                </div>                
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft" style="height: 1px;">
                </div>
                <div class="floatLeft" style="margin-top: 2px;">                
                   <asp:CheckBox ID ="chkPostAttending" runat="server" ClientIDMode="Static" Text="Currently attending."/>                
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdnPostGraduation" runat="server" Value="" ClientIDMode="Static" />
    </div>
    <div style="width: 100%; margin-left: 48px; min-height:15px;" class="marginTop5">
        <input type="button" id="BtnAdd" value="+ Add Post Graduation" class="addNewRefRow floatRight addPostButton"
            runat="server" clientidmode="Static" onclick="show();" /></div>
</div>
