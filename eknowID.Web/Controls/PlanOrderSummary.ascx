<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlanOrderSummary.ascx.cs"
    Inherits="eknowID.Controls.PlanOrderSummary" %>
<script type="text/javascript" language="javascript">
    function couponCodeError(errorMessage) {
        document.getElementById('<%=lblErrorCouponCode.ClientID %>').innerHTML = errorMessage;
        document.getElementById('<%=lblErrorCouponCode.ClientID %>').style.display = "inherit";
        var txtCouponCode = $('#txtCouponCode').val();
        var txtEndChar = '';
        $('#txtCouponCode').focus().val('').val(txtCouponCode + txtEndChar);
        //            $("#txtCouponCode").focus();         
    }

    function setUncoverBackgroundListHeight()
    {
        $(".divAlacartReportList").attr("style", "height:515px !important;");
        $(".divUncoverBgHeading").attr("style", "display:none !important;");
        $(".divReportSelectedSeperator").attr("style", "display:none !important;");
        $(".planSummaryLeftShadow").attr("style", "height:629px !important;"); 
        $(".planSummaryRightShadow").attr("style", "height:629px !important;");
    }
    function setReportListHeight() {       
        $(".planSummaryLeftShadow").attr("style", "height:662px !important;");
        $(".planSummaryRightShadow").attr("style", "height:662px !important;");
    }
</script>
 <!--[if gte IE 8]>
	<style type="text/css">
.WidthIE8
{
    width:230px !important;
}
</style>
<![endif]-->
<style type="text/css">
.divAlacartReportList
{min-height: 405px; }
.planSummaryLeftShadow
{background-image: url(../images/choose_plan_left_shadow.png);
        background-repeat: repeat-y; width: 10px;}
.planSummaryRightShadow
{background-image: url(../images/choose_plan_right_shadow.png);
        background-repeat: repeat-y; width: 10px;}
</style>
<asp:HiddenField runat="server" ID="hdnTotalPriceWithoutDisc" />
<asp:HiddenField runat="server" ID="hdnPriceDisc" />
<asp:HiddenField runat="server" ID="hdnCouponID" />
<div>
    <asp:Image ID="imgPaymentHeader" runat="server" style=" background-repeat: no-repeat;
    height: 79px; margin-left: 4px;width: 271px;" ImageUrl="~/Images/payment_checkout_gold_2.png" />
    <%--<h2 class="font-family_Arial SearchByRefChosePlan_PlanHeading" style="margin: 0px;
            padding: 5px 0 0 10px;">
            <asp:Label runat="server" ID="lblOrderSummary" Text="Order Summary"></asp:Label></h2>--%>
</div>
<div style="clear: both">
   <%-- <div id="divInnerLeft" class="floatLeft planSummaryLeftShadow" >
        &nbsp;
    </div>--%>
    <div id="innerContainer" class="floatLeft" style="background-color:White; box-shadow: 0 2px 4px #8A8A8A;margin-left:10px;">
        <div>
            <div class="divAlacartReportList clearBoth">             
                <div class="SearchByRefChosePlan_ReportIncludeDiv divUncoverBgHeading">
                  <asp:Label runat="server" ID="lblPlanPrice" Text="" CssClass="marginTop15 floatLeft divReportSelected"></asp:Label>
                    <h3 class="SearchByRefChosePlan_ReportIncludeHeadNew divReportSelected floatLeft marginLeft5 divUncoverBgHeading" >
                        Package Includes
                    </h3>
                </div>
             <%--   <div id="Div1" class="WidthIE8">
                    <img src="../Images/payment_summery_sep_line_bottom.png" alt="" style="height: 2px;
                        width: 258px;" />
                </div>
                <div class="PlanOrderSummary_ReportListDivNew">
                    <asp:Repeater ID="rptBasicReportList" runat="server">
                        <ItemTemplate>
                            <li class="PlanOrderSummary_BasicReportListNew PlanOrderSummary_ReportList">
                                <table width="100%">
                                    <tr>
                                        <td width="30">
                                            <img src="../Images/green_plan_tick.png" height="20px" border="0" alt="0" class="vertical_align_middle" />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblBasicReportName" CssClass="blackColor" Text='<%# Bind("Name")%>'> </asp:Label>
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
                                            <img src="../Images/green_plan_tick.png" height="20px" border="0" alt="0" class="vertical_align_middle" />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblBasicReportName" CssClass="blackColor" Text='<%# Bind("Name")%>'> </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </li>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="PlanOrderSummary_ReportListDiv">
            <asp:Repeater ID="rptOptionalReportList" runat="server">
                <ItemTemplate>
                    <li class="PlanOrderSummary_ReportList">
                        <table width="100%">
                            <tr>
                                <td width="30">
                                    <img src="../Images/green_tick.png" border="0" alt="0" class="vertical_align_middle" />
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblBasicReportName" CssClass="whiteColor" Text='<%# Bind("Name")%>'> </asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblReportPrice" Style="float: right; font-size: 14px;
                                        font-weight: bold;" CssClass="SearchByRefChosePlan_lblReportName" Text='<%#DataBinder.Eval(Container.DataItem, "Price", "{0:C}")%>'> </asp:Label>
                                </td>
                            </tr>
                        </table>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </div>--%>
          <div id="Div1" class="WidthIE8">
                <img src="../Images/payment_summery_sep_line_bottom.png" alt="" style="height: 2px;
                    width: 258px;" />
            </div>
            <div class="PlanOrderSummary_ReportListDivNew">
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
                                </tr>
                            </table>
                        </li>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                 <div class="divReportSelectedSeperator">
                <img src="../Images/payment_summery_sep_line_bottom.png" alt="" style="height: 3px;
                    width: 258px;" />
            </div>
                <div class="PlanOrderSummary_ReportListDiv" style="width:258px !important;min-height:341px;margin-left:0px;">
                <div class="SearchByRefChosePlan_ReportIncludeDiv" style="height:35px !important;">
                <asp:Label runat="server" ID="Label1" Text="" Style="color: #373737 !important;
                    font-size: 13px; font-weight: bold;" CssClass="marginTop15 floatLeft"></asp:Label>
                <h3 class="SearchByRefChosePlan_ReportIncludeHeadNew divReportSelected floatLeft marginLeft5" style="margin-top:7px !important;">
                    Reports Selected
                </h3>
            </div>
           
                    <asp:Repeater ID="rptOptionalReportList" runat="server">
                        <ItemTemplate>
                        <li class="PlanOrderSummary_BasicReportListNew PlanOrderSummary_ReportList">
                            <table width="100%">
                                <tr>
                                    <td style="width:10%">
                                        <img src="../Images/green_tick19x20.png" height="20px" border="0" alt="0" class="vertical_align_middle" />
                                    </td>
                                    <td style="width:50%">
                                            <asp:Label runat="server" ID="lblBasicReportName" CssClass="blackColor" Text='<%# Bind("Name")%>'> </asp:Label>
                                        </td>
                                    <td style="width:10%; text-align:right;">
                                        <asp:Label runat="server" ID="Label2" CssClass="blackColor" Text='<%# Bind("qty")%>'> </asp:Label>
                                    </td>
                                    <td style="width:30%">
                                            <asp:Label runat="server" ID="lblReportPrice" Style="float: right; font-size: 14px;color:#3C3C3C !important; margin-left: 0;margin-right: 5px;" CssClass="SearchByRefChosePlan_lblReportName" 
                                                Text='<%#String.Format("{0:C}", (Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "Price")) * Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "qty"))))%>'> </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </li>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                        <li class="PlanOrderSummary_BasicReportListNewAlterNate PlanOrderSummary_ReportList">
                            <table width="100%">
                                <tr>
                                    <td style="width:10%">
                                        <img src="../Images/green_tick19x20.png" height="20px" border="0" alt="0" class="vertical_align_middle" />
                                    </td>
                                    <td style="width:50%">
                                            <asp:Label runat="server" ID="lblBasicReportName" CssClass="blackColor" Text='<%# Bind("Name")%>'> </asp:Label>
                                        </td>
                                    <td style="width:10%; text-align:right;">
                                        <asp:Label runat="server" ID="Label2" CssClass="blackColor" Text='<%# Bind("qty")%>'> </asp:Label>
                                    </td>
                                    <td style="width:30%">
                                            <asp:Label runat="server" ID="lblReportPrice" Style="float: right; font-size: 14px;color:#3C3C3C !important; margin-left: 0;margin-right: 5px;" CssClass="SearchByRefChosePlan_lblReportName" 
                                                Text='<%#String.Format("{0:C}", (Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "Price")) * Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "qty"))))%>'> </asp:Label>
                                        </td>                                 
                                </tr>
                            </table>
                        </li>
                    </AlternatingItemTemplate>
                    </asp:Repeater>
               
                </div>
            </div>
            </div>
            <div id="divAccessFees" runat="server" visible="false">
                <ul style="padding:0px; color:black;">
                    <li class="PlanOrderSummary_BasicReportListNew">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblAccessFessText" Text="Total:">Access Fees: </asp:Label>
                                </td>
                                <td style="float: right;">
                                    <asp:Label runat="server" ID="lblAccessFees" Text=""></asp:Label>
                                </td>
                        </table>
                    </li>
                </ul>
            </div>
            <div id="divHoldingFees" runat="server" visible="false">
                <ul style="padding:0px; color:black;">
                    <li class="PlanOrderSummary_BasicReportListNew">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblHoldingFessText" Text="Total:">Holding Fees: </asp:Label>
                                </td>
                                <td style="float: right;">
                                    <asp:Label runat="server" ID="lblHoldingFees" Text=""></asp:Label>
                                </td>
                        </table>
                    </li>
                </ul>
            </div>
            <div id="seperatorNew">
                <img src="../Images/payment_summery_sep_line_bottom.png" alt="" style="height: 3px;
                    width: 258px;" />
            </div>
            
            <div style="min-height: 65px; clear: both; padding: 0px 10px 0 10px;">
                <div class="clearboth" style="height: 15px;padding-top:5px;">
                    <asp:Label runat="server" ID="lblDiscountOffer" CssClass="footerCaptionText floatLeft "
                        Text="" Visible="false">Discount Offered:</asp:Label>
                    <asp:Label runat="server" ID="lblDisCountPrice" Text="" CssClass="footerCaptionText floatLeft "
                        Style="margin-left: 10px;" Visible="false"></asp:Label>
                </div>
                <div class="clearboth">
                    <div class="SearchByRefChosePlan_ReportIncludeDiv">
                        <div>
                            <h3 class="SearchByRefChosePlan_ReportIncludeHeadNew SearchByRefChosePlan_ReportIncludeHeadNewBold floatLeft">
                                Coupon Code
                            </h3>
                            <asp:TextBox ID="txtCouponCode" CssClass="floatLeft alphanumeric" Style="width: 110px;
                                margin: 10px 5px 0 5px;" runat="server" ClientIDMode="Static" />
                        </div>
                        <%--  <asp:RequiredFieldValidator ID="CouponCodeRequiredFieldValidator" runat="server"
                    ErrorMessage="*" CssClass="red floatLeft footerLayer" ValidationGroup="CouponValidation"
                    ControlToValidate="txtCouponCode"></asp:RequiredFieldValidator>--%>
                        <div class="floatRight">
                            <asp:LinkButton ID="lnkBtnApplyCoupon" runat="server" CssClass="SearchByRefChosePlan_ReportIncludeButtonNew floatLeft"
                                OnClick="lnkBtnApplyCoupon_Click" Style="margin-right: 10px;" OnClientClick="needToConfirm = false;">
                        <h3 class="SearchByRefChosePlan_ReportIncludeButtonNew floatLeft">
                        Apply </h3>
                            </asp:LinkButton>
                        </div>
                        <br />
                        <asp:Label ID="lblErrorCouponCode" runat="server" ForeColor="Red" Font-Bold="true"
                            Text="" Style="display: none; float:left" />
                    </div>
                </div>
            </div>
        </div>
    </div>
   <%-- <div id="divInnerRight" class="floatLeft planSummaryRightShadow" >
        &nbsp;
    </div>--%>
</div>
<div style="background-image: url(../images/payment_checkout_rightbox_bottom_bg_2.png);
    background-repeat: no-repeat; min-height: 47px; clear: both; padding: 10px 20px 0 10px;
    margin-left: 4px;">   
    <asp:Label runat="server" ID="lblTotalPrice" Text="" Style="color: white; float: right;
        font-weight: bold; font-size: 25px;"></asp:Label>
    <asp:Label runat="server" ID="lblTotal" Text="Total:" Style="color: white; float: right;
        font-size: 25px; margin-right: 5px;"></asp:Label>
</div>
