<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="RC_DetailedAnalysis.aspx.cs" Inherits="eknowID.Pages.RC_DetailedAnalysis" %>

<%@ Register Src="~/Controls/ResumeChecking_AlaCartReport.ascx" TagPrefix="uc1" TagName="RC_Alacarte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" language="javascript">
    function selectAlacartReport(control) {
        var selectedReprtID = "";
        $('input[type=checkbox]').each(function () {
            var chkControlIdVal = this.id;
            var hdnReportIdVal = chkControlIdVal.replace(/\_chkReportName_/g, '_hdnReportId_');
            if (this.checked) {
                selectedReprtID = selectedReprtID + "," + $("#" + hdnReportIdVal).val();
            }
        });

        if (selectedReprtID == "") {
            $(".RC_ContinueBtn").attr("style", "background-image:url(../Images/continue_btn_blue_disable.png);");
            $("#btnNext").attr('disabled', 'true');
        }
        else {
            $(".RC_ContinueBtn").attr("style", "background-image:url(../Images/continue_blue_btn.png);");
            $("#btnNext").removeAttr('disabled');
        }

        selectedReprtID = selectedReprtID.substring(1);      
        var controlData = "alacartReportList:'" + selectedReprtID + "'";
        $.ajax({
            type: "POST",
            url: "AlacartReport.aspx/SetSelectedAlacartReportList",
            contentType: "application/json; charset=utf-8",
            data: "{" + controlData + "}",
            dataType: "json",
            success: function (result) {                         
            }
        });

    }

    function setResumeRequireAdditionalInfo() {
        $.cookie('redirectToOrderDetail', 'true');
        $.cookie('showUploadResumeDialog', 'false');
        var isUserLoggedIn = $('#hdnUserLoggedIn').val();

        if (isUserLoggedIn == "False") {
            SignInDialog();
        }
        else {
            window.location.href = "../Pages/OrderDetail.aspx";
        }
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="minWidth1000px RC_DetailAnalysisBg">
        <div class="margin_left_right_auto width1000px">
            <asp:HiddenField ID="hdnUserLoggedIn" runat="server" ClientIDMode="Static" />
            <div class="height50">
                <div class="divSelectProfHeading">
                    Detailed Analysis
                </div>
                <div class="divSelectProfHeading" style="font-size: 13px; font-weight: normal;">
                    Select Search types below to get a detailed analysis for your Resume.
                </div>
            </div>
            <div class="margin_left_right_auto RC_DetailAnalysisMainDiv">
                 <div class="divSelectProfHeading" style="font-size:18px;">
                 COMPLETE A SELF BACKGROUND CHECK - avoid any mistakes or surprises during a background check.
                </div>            
                <div>
                    <asp:Repeater ID="RCAlacartReportList" runat="server" OnItemDataBound="RCAlacartReportList_ItemDataBound">
                        <ItemTemplate>
                            <div runat="server" id="divAlacartReport">
                                <uc1:RC_Alacarte ID="ucRCAlarte" runat="server" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>               
            </div>
            <div class="clearBoth width1000px margin_left_right_auto height_30px paddingTop15">
         <div class="width100per height_30px"> 
         <%--<asp:Button ID="btnNext" runat="server" Text="Next" OnClientClick="return CheckIfUserloggedIn();" CssClass="floatRight" />--%>
         <input type="button" id="btnNext"  onclick="return setResumeRequireAdditionalInfo();" class="floatRight RC_ContinueBtn" disabled="disabled"/>
         </div>
             </div>
        </div>
    </div>
</asp:Content>
