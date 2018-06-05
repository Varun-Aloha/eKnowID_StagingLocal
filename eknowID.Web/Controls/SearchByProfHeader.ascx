<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchByProfHeader.ascx.cs"
    Inherits="eknowID.Controls.SearchByProfHeader" %>
<!--[if gte IE 8]>
	<style type="text/css">
  .divTabHR
{
  width:506px;
  margin-left:-118px;
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
    function setImageMapClickableArea() {
        var SelectProfFlag = '<%=Session["SelectProfFlag"]%>';
        var ChoosePlanFlag = '<%=Session["ChoosePlanFlag"]%>';
        var PaymentFlag = '<%=Session["PaymentFlag"]%>';

        if (SelectProfFlag == "True") {
            $('.profession').attr('href', '../Pages/SearchByProf_SelectProf.aspx');
            $('.Chooseplan').attr('href', '#');
            $('.Payment').attr('href', '#');
            $('.Chooseplan').attr('style', "cursor:default");
            $('.Payment').attr('style', "cursor:default");
            $('.lnkChoosePlan').attr('style', "cursor:default");
            $('.lnkPayment').attr('style', "cursor:default");
        }
        if (ChoosePlanFlag == "True") {
            $('.Chooseplan').attr('href', '../Pages/SelectProf_PackageSelection.aspx');
            $('.lnkChoosePlan').attr('href', '../Pages/SelectProf_PackageSelection.aspx');
            $('.Chooseplan').attr('style', "cursor:pointer");
            $('.lnkChoosePlan').attr('style', "cursor:pointer");
            $('.Payment').attr('href', '#');
            $('.Payment').attr('style', "cursor:default");
            $('.lnkPayment').attr('style', "cursor:default");
        }
        if (PaymentFlag == "True") {
            $('.Payment').attr('href', '../Pages/SearchByProf_PaymentInfo.aspx');
            $('.lnkPayment').attr('href', '../Pages/SearchByProf_PaymentInfo.aspx');
            $('.Payment').attr('style', "cursor:pointer");
            $('.lnkPayment').attr('style', "cursor:pointer");
        }
    }
</script>
<div style="width: 100%;">
    <%-- <div>
        <h2 class="SearchByRefUC_heading">
            Search by Profession</h2>
    </div>
    <div class="SearchByRefUC_SelectProfDiv lnkSelectProf">
        <a href="../Pages/SearchByProf_SelectProf.aspx?SelectedTab=Select Profession" class="SearchByRefUC_tabHeading lblSelectProf">
            Select Profession</a>
    </div>
    <div class="SearchByRefUC_ChoosePlanDiv">
        <a href="#" class="SearchByRefUC_tabHeading lnkChoosePlan">Choose Plan</a>
    </div>
    <div class="SearchByRefUC_PaymentDiv">
        <a href="#" class="SearchByRefUC_tabHeading lnkPayment">Payment Info & Checkout</a>
    </div>--%>
    <div class="z-index_1" style="width: 1011px;">
        <div style="height: 90px;">
            <div class="divSelectProfHeading">
                <asp:Label ID="lblSelectByProf" runat="server" Text=" Package Selection"></asp:Label>
            </div>
            <div class="floatLeft divSelectByProfBgLeft">
            </div>
            <div class="floatLeft divSelectByProfBgMiddle">
                <div class="divSearchByProfTabHeading" style="margin-left: 200px;">
                    <div class="divTabHeading">
                        <asp:Label ID="lblSelectProfession" runat="server" Text="Package Selection" /></div>
                    <div class="divTabHeading" style="margin-left: 35px;">
                        <asp:Label ID="lblChoosePlan" runat="server" Text="Upgrade Package" /></div>
                    <div class="divTabHeading" style="margin-left: 47px;">
                        <asp:Label ID="lblImportInformation" runat="server" Text="Import Your Profile" /></div>
                    <div class="divTabHeading" style="margin-left: 70px;">
                        <asp:Label ID="lblCheckOut" runat="server" Text="Checkout" /></div>
                </div>
                <div class="divSearchByProfTabImg">
                    <hr class="divTabHR" />
                    <asp:Image ID="imgBtnDot1" runat="server" ImageUrl="../Images/tab_normal_round.png"
                        CssClass="floatLeft marginTop_13" />
                    <asp:Image ID="imgBtnDot2" runat="server" ImageUrl="../Images/tab_normal_round.png"
                        CssClass="floatLeft marginTop_13" Style="margin-left: 153px;" />
                    <asp:Image ID="imgBtnDot3" runat="server" ImageUrl="../Images/tab_normal_round.png"
                        CssClass="floatLeft marginTop_13" Style="margin-left: 153px;" />
                    <asp:Image ID="imgBtnDot4" runat="server" ImageUrl="../Images/tab_normal_round.png"
                        CssClass="floatLeft marginTop_13" Style="margin-left: 152px;" />
                    <%-- <asp:ImageButton ID="imgBtnDot1" runat="server" ImageUrl="../Images/tab_normal_round.png"
                        CssClass="floatLeft"  />
                     <asp:ImageButton ID="imgBtnDot2" runat="server" ImageUrl="../Images/tab_normal_round.png"
                        CssClass="floatLeft" style="margin-left:117px;" Style=" margin-left: 135px;" />                
                    <asp:ImageButton ID="imgBtnDot3" runat="server" ImageUrl="../Images/tab_normal_round.png" style=" float: left;
                        margin-left: -12px;" />
                 
                    <asp:ImageButton ID="imgBtnDot4" runat="server" ImageUrl="../Images/tab_normal_round.png" />--%>
                </div>
            </div>
            <div class="floatLeft divSelectByProfBgRight">
            </div>
        </div>
        <%-- <img class="left SearchByRefUC_tabImage" src="../Images/tab_1i_selected.png" alt="How It Works"
            usemap="#process_map" runat="server" id="ImgSearchByProf" />--%>
        <%-- <map name="process_map">
            <area shape="poly" href="../Pages/SearchByProf_SelectProf.aspx?SelectedTab=Select Profession"
                title="Select profession." coords="310,59,0,59,0,0,310,0,331,29,310,59" class="profession">
            <area shape="poly" href="#" title="Choose plan." coords="626,59,317,59,335,29,317,0,626,0,644,29,626,59"
                class="Chooseplan">
            <area shape="poly" href="#" title="Payment Info & Checkout." coords="954,59,631,59,650,29,631,0,954,0,954,59"
                class="Payment">
        </map>--%>
    </div>
</div>
