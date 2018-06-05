<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RCheckerHeader.ascx.cs" Inherits="eknowID.Controls.RCheckerHeader" %>

<script type="text/javascript" language="javascript">
//    $(document).ready(function () {
//        if ($.browser.safari) {
//            $('.SearchByRefUC_SelectProfDiv').attr("style", " margin: 52px 0 0 61px !important;");
//            $('.SearchByRefUC_ChoosePlanDiv').attr("style", " margin: 52px 0 0 400px !important;");
//            $('.SearchByRefUC_PaymentDiv').attr("style", " margin: 52px 0 0 712px !important;");
//        }
//    });
//    function setImageMapClickableArea() {
//        var SelectProfFlag = '<%=Session["SelectProfFlag"]%>';
//        var ChoosePlanFlag = '<%=Session["ChoosePlanFlag"]%>';
//        var PaymentFlag = '<%=Session["PaymentFlag"]%>';

//        if (SelectProfFlag == "True") {
//            $('.profession').attr('href', '../Pages/SearchByProf_SelectProf.aspx?SelectedTab=Select Profession');
//            $('.Chooseplan').attr('href', '#');
//            $('.Payment').attr('href', '#');
//            $('.Chooseplan').attr('style', "cursor:default");
//            $('.Payment').attr('style', "cursor:default");
//            $('.lnkChoosePlan').attr('style', "cursor:default");
//            $('.lnkPayment').attr('style', "cursor:default");
//        }
//        if (ChoosePlanFlag == "True") {
//            $('.Chooseplan').attr('href', '../Pages/SearchByProf_ChoosePlan.aspx?SelectedTab=ChoosePlan');
//            $('.lnkChoosePlan').attr('href', '../Pages/SearchByProf_ChoosePlan.aspx?SelectedTab=ChoosePlan');
//            $('.Chooseplan').attr('style', "cursor:pointer");
//            $('.lnkChoosePlan').attr('style', "cursor:pointer");
//            $('.Payment').attr('href', '#');
//            $('.Payment').attr('style', "cursor:default");
//            $('.lnkPayment').attr('style', "cursor:default");
//        }
//        if (PaymentFlag == "True") {
//            $('.Payment').attr('href', '../Pages/SearchByProf_PaymentInfo.aspx?SelectedTab=Payment');
//            $('.lnkPayment').attr('href', '../Pages/SearchByProf_PaymentInfo.aspx?SelectedTab=Payment');
//            $('.Payment').attr('style', "cursor:pointer");
//            $('.lnkPayment').attr('style', "cursor:pointer");
//        }
//    }
</script>
<div style="width: 100%">
    <div>
        <h2 class="SearchByRefUC_heading">
            Resume Checker</h2>
    </div>
    <div class="SearchByRefUC_SelectProfDiv lnkSelectProf">
        <a href="../Pages/SearchByProf_SelectProf.aspx" class="SearchByRefUC_tabHeading lblSelectProf">
            Upload Resume</a>
    </div>
    <div class="SearchByRefUC_ChoosePlanDiv">
        <a href="#" class="SearchByRefUC_tabHeading lnkChoosePlan">Choose Plan</a>
    </div>
    <div class="SearchByRefUC_PaymentDiv">
        <a href="#" class="SearchByRefUC_tabHeading lnkPayment">Payment Info & Checkout</a>
    </div>
    <div class="z-index_1">
        <img class="left SearchByRefUC_tabImage" src="../Images/tab_1i_selected.png" alt="How It Works"
            usemap="#process_map" runat="server" id="ImgSearchByProf" />
        <map name="process_map">
            <area shape="poly" href="../Pages/SearchByProf_SelectProf.aspx"
                title="Select profession." coords="310,59,0,59,0,0,310,0,331,29,310,59" class="profession">
            <area shape="poly" href="#" title="Choose plan." coords="626,59,317,59,335,29,317,0,626,0,644,29,626,59"
                class="Chooseplan">
            <area shape="poly" href="#" title="Payment Info & Checkout." coords="954,59,631,59,650,29,631,0,954,0,954,59"
                class="Payment">
        </map>
    </div>
</div>

