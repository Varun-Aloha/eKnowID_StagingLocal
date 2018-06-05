<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IdentityTheftSearchByProfHeader.ascx.cs"
    Inherits="eknowID.Controls.IdentityTheftSearchByProfHeader" %>
<!--[if gte IE 8]>
	<style type="text/css">
  .divTabHR
{
  width:506px;
  margin-left:-168px;
}

</style>
<![endif]-->
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        if ($.browser.safari) {
            $('.SearchByRefUC_SelectProfDiv').attr("style", " margin: 52px 0 0 61px !important;");
            $('.SearchByRefUC_ChoosePlanDiv').attr("style", " margin: 52px 0 0 400px !important;");
            $('.SearchByRefUC_PaymentDiv').attr("style", " margin: 52px 0 0 712px !important;");
        }
    }); 
</script>
<div style="width: 100%;">
    <div class="z-index_1" style="width: 1000px;">
        <div style="height: 90px;">
            <div class="divSelectProfHeading">
                <asp:Label ID="lblSelectByProf" runat="server" Text="Select Report"></asp:Label>
            </div>
            <div class="floatLeft divSelectByProfBgLeft">
            </div>
            <div class="floatLeft divSelectByProfBgMiddle">
                <div class="divSearchByProfTabHeading" style="margin-left: auto; width: 499px;">
                    <div class="divTabHeading">
                        <asp:Label ID="lblChoosePlan" runat="server" Text="Select Report" /></div>
                    
                    <div class="divTabHeading" style=" margin-left: 86px;width: 116px;">
                        <asp:Label ID="lblImportInformation" runat="server" Text="Import Your Profile" /></div>
                    <div class="divTabHeading" style="float:right;width:55px;">
                        <asp:Label ID="lblCheckOut" runat="server" Text="Checkout" /></div>
                </div>
                <div class="divSearchByProfTabImg" style="margin-left: 257px;">
                    <hr class="divTabHR" style="width: 440px;" />
                    <asp:Image ID="imgBtnDot2" runat="server" ImageUrl="../Images/tab_normal_round.png"
                        CssClass="floatLeft marginTop_13" />
                    <asp:Image ID="imgBtnDot3" runat="server" ImageUrl="../Images/tab_normal_round.png"
                        CssClass="floatLeft marginTop_13" Style="margin-left: 212px;" />
                    <asp:Image ID="imgBtnDot4" runat="server" ImageUrl="../Images/tab_normal_round.png"
                        CssClass="floatLeft marginTop_13" Style="margin-left: 209px;" />                   
                </div>
            </div>
            <div class="floatLeft divSelectByProfBgRight">
            </div>
        </div>
    </div>
</div>
