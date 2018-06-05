<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResumeChecking_AlaCartReport.ascx.cs"
    Inherits="eknowID.Controls.ResumeChecking_AlaCartReport" %>
<script src="../Scripts/Tooltip/jquery.bt.min.js" type="text/javascript"></script>
<link href="../Styles/jquery.bt.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript">
    function expandDetails(controlID) {
        var imgExpandID = controlID.id;
        var imgCollapsID = controlID.id.replace(/\imgExpand/g, 'imgCollaps');
        var reportDetailID = controlID.id.replace(/\imgExpand/g, 'reportDetails');
        $("#" + imgExpandID).attr("style", "display:none");
        $("#" + imgCollapsID).attr("style", "display:block");
        $("#" + reportDetailID).slideToggle("medium");
    }
    function collapsDetails(controlID) {
        var imgCollapsID = controlID.id;
        var imgExpandID = controlID.id.replace(/\imgCollaps/g, 'imgExpand');
        var reportDetailID = controlID.id.replace(/\imgCollaps/g, 'reportDetails');
        $("#" + imgCollapsID).attr("style", "display:none");
        $("#" + imgExpandID).attr("style", "display:block");
        $("#" + reportDetailID).slideToggle("medium");
    }

    $(function () {
        $(".imgExpandBtn").hover(function () {
            $('.imgExpandBtn').btOff();
            var description = "Click for description.";
            $("#description").text(description);
        });
    });


    $(function () {
        //  $('#divTooltip').hide();

        $('.imgExpandBtn').bt({
            positions: 'top',
            contentSelector: "$('#divTooltip')", /*hidden div*/
            trigger: ['hover'],
            centerPointX: .5,
            spikeLength: 10,
            spikeGirth: 10,
            width: 140,
            padding: 10,
            cornerRadius: 4,
            fill: '#FFF',
            strokeStyle: '#ABABAB',
            strokeWidth: 2
        });
    });

</script>
<style type="text/css">
    .divAlacartMain
    {
        min-height: 30px;
        width: 940px;
    }
    .divHeaderBorder
    {
        border-top: 1px solid #D8D8D8;
        height: 5px;
        width: 940px;
        margin: 0px 0px 5px 0px;
    }
    .divAlacartReortHeader
    {
        width: 900px;
        float: left;
        padding-left: 10px;
        font-size: 13px;
    }
    .lblReportName
    {
        margin-left: 10px;
        color: #454545;
        vertical-align: middle;
        font-weight: bold;
    }
    .lblReportPrice
    {
        color: #8B0000;
    }
    .divExpandCollapsImg
    {
        width: 30px;
        float: right;
    }
    .divReportDetails
    {
        display: none;
        color: #454545;
        margin-left: 41px;
        width: 845px;
    }
    .divReportDescription
    {
        color: #454545;
        margin-bottom: 20px;
        width: 815px;
    }
</style>
<div class="divAlacartMain">
    <asp:HiddenField ID="hdnReportId" runat="server" />
    <div id="divTooltip" style="display: none;" class="alignJustify padding8 height21">
        <span id="description" class="floatLeft"></span>
    </div>
    <div class="height_30px">
        <div class="divAlacartReortHeader">
            <div class="floatLeft">
                <asp:CheckBox ID="chkReportName" runat="server" onClick="selectAlacartReport(this);" />
            </div>
            <div class="floatLeft">
                <asp:Label ID="lblReportName" runat="server" Text="" CssClass="lblReportName"></asp:Label>
                <asp:Label ID="lblTurnaroundTime" runat="server" Text="" CssClass="lblReportName"></asp:Label>
            </div>
            <div class="floatRight" style="width: 55px;">
                <asp:Label ID="lblReportPrice" runat="server" Text="" class="floatRight" CssClass="lblPrice floatLeft"></asp:Label>
            </div>
        </div>
        <div class="divExpandCollapsImg">
            <img id="imgExpand" alt="" src="../Images/red_arrow_down.png" width="20" height="20"
                onclick="expandDetails(this);" style="display: block;" runat="server" class="imgExpandBtn cursorPointer display_block" />
            <img id="imgCollaps" alt="" src="../Images/red_arrow_up.png" width="20" height="20"
                onclick="collapsDetails(this);"  runat="server" class="cursorPointer display_none"/>
        </div>
    </div>
    <div class="RC_DetailAnalysis_DefaultDescript" id="reportDefaultDescription" runat="server">
    </div>
    <div>
    </div>
    <div class="divReportDetails" id="reportDetails" runat="server">
        <div class='divHeaderBorder' style="width: 815px;">
        </div>
        <div class="divReportDescription alignJustify" id="reportDescription" runat="server">
        </div>
    </div>
    <div class="divHeaderBorder">
    </div>
</div>
