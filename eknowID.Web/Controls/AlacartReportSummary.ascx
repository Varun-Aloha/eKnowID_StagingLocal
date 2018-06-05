<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlacartReportSummary.ascx.cs"
    Inherits="eknowID.Controls.AlacartReportSummary" %>

    <script type="text/javascript" language="javascript">
       
        function setReportListWidth() {
            if ($.browser.msie && $.browser.version == '8.0') {
                $(".WidthIE8").attr("style", "width:230px !important;");
            }
        }
        $(function () {
            $("#stateCriminalList").find(".dropdown-menu").html($("#hdnStateCriminalList").val());
            $("#stateCountyList").find(".dropdown-menu").html($("#hdnCountyCriminalList").val());
            $("#stateCivilList").find(".dropdown-menu").html($("#hdnCountyCivilList").val());
            $("#stateFederalList").find(".dropdown-menu").html($("#hdnFederalCriminalList").val());
        });
    </script>
<!--[if gte IE 8]>
	<style type="text/css">
.WidthIE8
{
    width:230px !important;
}
</style>
<![endif]-->
<asp:HiddenField runat="server" ID="hdnTotalPriceWithoutDisc" ClientIDMode="Static" />
<asp:HiddenField runat="server" ID="hdnPriceDisc" />
<asp:HiddenField runat="server" ID="hdnCouponID" />
<div>
    <asp:Image ID="imgPaymentHeader" runat="server" Style="background-repeat: no-repeat;
        height: 79px; margin-left: 4px; width: 271px;" ImageUrl="~/Images/checkout_blue.png" />  
</div>
<div style="clear: both">
    <div id="divInnerLeft" class="floatLeft" style="background-image: url(../images/choose_plan_left_shadow.png);
        background-repeat: repeat-y; width: 10px; height: 531px;">
        &nbsp;
    </div>
    <div id="innerContainer" class="floatLeft" style="width:258px !important;">
        <div class="divReportIncludeList" style="min-height: 531px; clear: both; background-color: White;">
            <div class="SearchByRefChosePlan_ReportIncludeDiv">
                <asp:Label runat="server" ID="lblPlanPrice" Text="" Style="color: #373737 !important;
                    font-size: 13px; font-weight: bold;" CssClass="marginTop15 floatLeft"></asp:Label>
                <h3 class="SearchByRefChosePlan_ReportIncludeHeadNew divReportSelected floatLeft marginLeft5">
                    Reports Selected
                </h3>
            </div>
            <div id="Div1" class="WidthIE8">
                <img src="../Images/payment_summery_sep_line_bottom.png" alt="" style="height: 2px;
                    width: 258px;" />
            </div>
            <div class="PlanOrderSummary_ReportListDivNew">
             <div id ="upgradeReportContainer"> 
             </div>
                <asp:Repeater ID="rptBasicReportList" runat="server">
                    <ItemTemplate>
                        <li class="PlanOrderSummary_BasicReportListNew PlanOrderSummary_ReportList">
                            <table width="100%">
                                <tr>
                                    <td width="30">
                                        <img src="../Images/green_tick19x20.png" height="20px" border="0" alt="0" class="vertical_align_middle" />
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBasicReportName" CssClass="blackColor" Text='<%# Bind("Name")%>'> </asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblReportPrice" Style="float: right; font-size: 14px;
                                            color: #3C3C3C !important;" CssClass="SearchByRefChosePlan_lblReportName"
                                            Text='<%#DataBinder.Eval(Container.DataItem, "Price", "{0:C}")%>'> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </li>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <li class="PlanOrderSummary_BasicReportListNewAlterNate PlanOrderSummary_ReportList">
                            <table width="100%">
                                <tr>
                                    <td width="30">
                                        <img src="../Images/green_tick19x20.png" height="20px" border="0" alt="0" class="vertical_align_middle" />
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBasicReportName" CssClass="blackColor" Text='<%# Bind("Name")%>'> </asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblReportPrice" Style="float: right; font-size: 14px;
                                            color: #3C3C3C !important;" CssClass="SearchByRefChosePlan_lblReportName"
                                            Text='<%#DataBinder.Eval(Container.DataItem, "Price", "{0:C}")%>'> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </li>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div id="divInnerRight" class="floatLeft" style="background-image: url(../images/choose_plan_right_shadow.png);
        background-repeat: repeat-y; width: 10px; height: 531px;">
        &nbsp;
    </div>    
</div>
<div style="background-image: url(../images/payment_checkout_rightbox_bottom_bg_2.png);
    background-repeat: no-repeat; min-height: 47px; clear: both; padding: 10px 20px 0 10px;
    margin-left: 4px;">
    <asp:Label runat="server" ID="lblTotalPrice" Text="" Style="color: white; float: right;
        font-weight: bold; font-size: 25px;" ClientIDMode="Static"></asp:Label>
    <asp:Label runat="server" ID="lblTotal" Text="Total:" Style="color: white; float: right;
        font-size: 25px; margin-right: 5px;"></asp:Label>
</div>

<div id="stateCriminalList" style="display:none;">
    <div id="divStateCriminal" class="container" style="width:100%;">
        <div class="row">
            <div class="col-lg-12" style="padding-left:10px; padding-right:5px;">
                <div class="">
                    <button type="button" class="dropdown-toggle" data-toggle="dropdown"><label class="">Select State</label> <span style="color: #666666;" class="caret"></span></button>
                    <ul class="dropdown-menu" style="height:200px; overflow-y:scroll; overflow-x:hidden; background-color:#e5e5e5 !important; left:10px; padding:0px;">
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>
<div id="stateCountyList" style="display: none">
    <div id="divStateCounty" style="width:100%;  margin:5px;">
        <div class="row">
            <div class="col-lg-12" style="padding-left:10px; padding-right:5px;">
                <div class="button-group">
                    <button type="button" class="dropdown-toggle btnDropDownMenu" style="display:none;" data-toggle="dropdown"><label class="">Select County</label> 
                        <span style="color: #666666;" class="caret"></span>
                    </button><input data-searchtype="countyCriminal" class="searchFiltertxt" type="text" style="color:black; width:150px; padding: 0px 5px 0px 0px;" placeholder="Search State..." />
                    <br /><label id="lblselectedStateCounties" style="color:black;"></label>
                    <ul class="dropdown-menu" data-selectedItems="" style="height:200px; overflow-y:scroll; overflow-x:hidden; background-color:#e5e5e5 !important; left:10px; padding:0px;">
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>
<div id="stateCivilList" style="display: none">
    <div id="divCivilCounty" style="width:100%; margin:5px;">
        <div class="row">
            <div class="col-lg-12" style="padding-left:10px; padding-right:5px;">
                <div class="button-group">
                    <button type="button" class="dropdown-toggle btnDropDownMenu" style="display:none;" data-toggle="dropdown"><label class="">Select County</label> 
                        <span style="color: #666666;" class="caret"></span>
                    </button><input data-searchtype="countyCivil" class="searchFiltertxt" type="text" style="color:black; width:150px; padding: 0px 5px 0px 0px;" placeholder="Search State..." />
                    <br /><label id="lblSelectedCivilCounties" style="color:black;"></label>
                    <ul class="dropdown-menu" data-selectedItems="" style="height:200px; overflow-y:scroll; overflow-x:hidden; background-color:#e5e5e5 !important; left:10px; padding:0px;">
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>
<div id="stateFederalList" style="display: none">
    <div id="divStateFederal" class="container" style="width:100%;">
        <div class="row">
            <div class="col-lg-12" style="padding-left:10px; padding-right:5px;">
                <div class="">
                    <button type="button" class="dropdown-toggle" data-toggle="dropdown"><label class="">Select State</label> <span style="color: #666666;" class="caret"></span></button>
                    <ul class="dropdown-menu" style="height:200px; overflow-y:scroll; overflow-x:hidden; background-color:#e5e5e5 !important; left:10px; padding:0px;">
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>


