<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlanDisplay.ascx.cs"
    Inherits="eknowID.Controls.PlanDisplay" %>
 <script type="text/javascript">
    $(document).ready(function () {
                var count =  <%=rptOptionalPlans.Items.Count %> ;
                var originalht = $('.SearchByRefChosePlan_DrugListSubDiv').height();
                var ht = (count * 25)
                
                if(originalht < ht)
                {
                 $('.SearchByRefChosePlan_DrugListSubDiv').css('height',ht);
                 
                }
    
     });   
</script>
<div>
<div class="SearchByRefChosePlan_PlanHeadDiv clearBoth">
        <h2 class="font-family_Arial SearchByRefChosePlan_PlanHeading">
            <asp:Label runat="server" ID="lblPlanName" style="color: #242B31;font-weight: 100;text-align: center;text-shadow: 1px 1px 0 #A6A8A9;"></asp:Label></h2>
        <div class="SearchByRefChosePlan_PriceDetailDiv">
            <div class="SearchByRefChosePlan_PriceDollerDiv">
                <h2 class="SearchByRefChosePlan_PriceDoller">
                    $</h2>
            </div>
            <div class="SearchByRefChosePlan_PriceDiv">
                <asp:Label ID="lblBasicPrice" runat="server" Text="14" CssClass="SearchByRefChosePlan_Pricelbl"></asp:Label>
            </div>
            <div class=" marginTop30px floatLeft">
                <asp:Label ID="lblBasicSpecialPrice" runat="server" Text="special price" CssClass="SearchByRefChosePlan_SpecialPricelbl"></asp:Label>
                <div class="SearchByRefChosePlan_PricePercentDiv">
                    <asp:Label ID="lblBasicSpecialPricePercent" runat="server" CssClass="SearchByRefChosePlan_PricePercentlbl"></asp:Label>
                    <asp:Label ID="lblBasicSpecialPriceOff" runat="server" Text="off" CssClass="SearchByRefChosePlan_PriceOfflbl"></asp:Label>
                </div>
            </div>
        </div>
        <div class="SearchByRefChosePlan_PlanDescDiv" id="basicDescriptDiv" runat="server">
        </div>
        <div class="SearchByRefChosePlan_ReportIncludeDiv">
            <h3 class="SearchByRefChosePlan_ReportIncludeHead">
                Report Includes
            </h3>
        </div>
       <div class="SearchByRefChosePlan_ReportListDiv">
            <asp:Repeater ID="rptBasicReportList" runat="server">
                <ItemTemplate>
                    <li class="SearchByRefChosePlan_ReportRepeater">
                        <img src="../Images/green_tick.png" border="0" alt="0" class="vertical_align_middle" />
                        <asp:Label runat="server" ID="lblBasicReportName" CssClass="SearchByRefChosePlan_lblReportName"  Text='<%# Bind("Name")%>'> </asp:Label>                        
                           <asp:Label runat="server"  Visible="false" ID="lblReportID" Text='<%# Bind("ReportId")%>'>'> </asp:Label>   
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </div>      
    </div>
    <div class="SearchByRefChosePlan_BottomDiv">
    <!--Uncomment this code when we want include optional reports in package-->
    <!--Uncomment this code when we want include optional reports in package-->
    <!--Uncomment this code when we want include optional reports in package-->
    <!--Uncomment this code when we want include optional reports in package-->
    <!--Uncomment this code when we want include optional reports in package-->
    <!--Uncomment this code when we want include optional reports in package-->
    <!--***********************////////////////////////********************-->

     <!-- <asp:Label ID="lblOptRpt" runat="server" Text ="Optional Reports" />
       <div class="SearchByRefChosePlan_DrugListSubDiv">
                <asp:Repeater ID="rptOptionalPlans" runat="server">
                    <ItemTemplate>
                        <li class="SearchByRefChosePlan_ReportRepeater">
                            <asp:CheckBox runat="server" ID="chkBasicOptionalReport"></asp:CheckBox>
                            <asp:Label runat="server" ID="lblBasicDrugTest" style="margin-left:2px;" Text='<%# Bind("Name")%>'>'> </asp:Label>
                            <asp:Label runat="server" style=" float:right; font-size: 14px;font-weight: bold; margin-right:40px" ID="lblBasicDrugTestPrice" Text='<%#DataBinder.Eval(Container.DataItem, "Price", "{0:C}")%>'> </asp:Label> 
                             <asp:Label runat="server"  Visible="false" ID="lblOptReportID" Text='<%# Bind("ReportId")%>'>'> </asp:Label>   
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </div>-->

    <!--Uncomment this code when we want include optional reports in package-->
    <!--Uncomment this code when we want include optional reports in package-->
    <!--Uncomment this code when we want include optional reports in package-->
    <!--Uncomment this code when we want include optional reports in package-->
    <!--Uncomment this code when we want include optional reports in package-->
    <!--Uncomment this code when we want include optional reports in package-->
    <!--***********************////////////////////////********************-->
    </div>
    <div class="SearchByRefChosePlan_BottomCornerDiv clearBoth">
        <asp:ImageButton ID="imgBtnBasicContinue" runat="server" ImageUrl="~/Images/continue_btn_blue.png"
            CssClass="SearchByRefChosePlan_btnContinue" onclick="imgBtnBasicContinue_Click" />
    </div>
    <div class="clearBoth">
        <a href="#" class="SearchByRefChosePlan_lnkViewReport">view sample report</a>
    </div>
</div>
<asp:HiddenField runat="server" ID="hdnEmpInfoReq"/>
<asp:HiddenField runat="server" ID="hdnEduInfoReq"/>
<asp:HiddenField runat="server" ID="hdnLicInfoReq"/>
<asp:HiddenField runat="server" ID="hdnRefInfoReq"/>
<asp:HiddenField runat="server" ID="hdnDrugVerificationPlan"/>
<asp:HiddenField runat="server" ID="hdnPlanID"/>