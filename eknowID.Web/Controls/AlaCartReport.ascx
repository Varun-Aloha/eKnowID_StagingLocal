<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlaCartReport.ascx.cs" Inherits="eknowID.Controls.AlaCartReport" %>  

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
            $(".imgExpandBtn, .chkreportSelector").hover(function () {
                //$('.imgExpandBtn').btOff();
                //var description = "Click for description.";
                //$("#description").text(description);                       
                if ($(this).hasClass("imgExpandBtn")) {
                                $('.imgExpandBtn').btOff();
                                var description = "Click for description.";
                                $("#description").text(description);
                } else if (undefined !== $(this).attr("title")) {
                    $(this).btOff();
                    var description = $(this).attr("title");
                    $("#description").text(description);
                }
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
            width: 605px;
        }
        .divHeaderBorder
        {
            border-top: 1px solid #D8D8D8;
            height: 15px;
            width:605px;
        }
        .divAlacartReortHeader
        {
            width: 100%;
            float: left;
            padding-left: 10px;
            font-size: 16px;
            font-weight:bold;
            min-height: 35px;
        }
        .lblReportName
        {
            margin-left: 10px;
            color: #454545;
            vertical-align: middle;    
            font-weight:bold;      
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
            /*display: none;*/
            color: #454545;
            margin-left:44px;
            width:80%;
            /*margin-bottom:20px;*/
        }
        
         .less {
            word-wrap: break-word;
            text-overflow: ellipsis;
            overflow: hidden;
            max-height: 0px;
        }

        .more {
            white-space: normal;
            margin: 0 auto;
            width: 100%;
            height: auto;
        }

        .text-size {
            /*display: block;*/
            margin-right:10px;
            font-size: 14px;
            font-weight: normal;
            text-align: left;
            color: #fb5240 !important;
            cursor: pointer;
            float:right;
        }
    </style>
    <div class="divAlacartMain">
        <asp:HiddenField ID="hdnReportId" runat="server" />
        <asp:HiddenField ID="hdnReportPrice" runat="server" />
        <asp:HiddenField ID="hdnMultipleCheckEnabled" runat="server" />
        <asp:HiddenField ID="hdnMaxVerificationCount" runat="server" />
        <div id="divTooltip" style="display: none; height:20px;" class="alignJustify padding8">
         <span id ="description" style="float:left"></span>                
        </div>
        <div class="divHeaderBorder">
        </div>
        <div>
            <div class="divAlacartReortHeader">
            <div class="floatLeft"> 
                    <asp:CheckBox ID="chkReportName" CssClass="chkreportSelector" runat="server" onClick="selectAlacartReport(this);" />
                    <%--<span title="" class="" runat="server" id="reportTitleSpan" visible="false">You can do individual credit report search at <a href="https://www.annualcreditreport.com/">https://www.annualcreditreport.com/</a></span>--%>
            </div>               
                <div class="floatLeft">
                 <asp:Label ID="lblReportName" runat="server" Text="" CssClass="lblReportName"></asp:Label>
                    <asp:Label ID="lblTurnaroundTime" runat="server" Text="" CssClass=""></asp:Label>
                </div>
                <div class="floatRight" style="min-width: 60px;">
                    <asp:Label ID="lblReportPrice" runat="server" Text="" class="floatRight" CssClass="lblPrice floatRight"></asp:Label>                    
                </div>
                <div class="flotRight">
                    <span id="lblReadMore" onclick="UpgradePackageDescriptionTextWrap(this); return false;" class="text-size">Read more...</span>
                </div>
             
            </div>
            <div>
                <span style="color: red; font-size: 13px;" id="spanIndividualCreditReprotSearch" runat="server"></span><a style="font-size: 13px;" id="linkIndividualCreditReprotSearch" runat="server"></a>
            </div>
            <%--<div class="divExpandCollapsImg">
                <img id="imgExpand" alt="" src="../Images/red_arrow_down.png" width="20" height="20"
                    onclick="expandDetails(this);" runat="server" class="imgExpandBtn cursorPointer display_block"/>
                <img id="imgCollaps" alt="" src="../Images/red_arrow_up.png" width="20" height="20"
                    onclick="collapsDetails(this);" runat="server" class="cursorPointer display_none"/>
            </div>--%>
            </div>
        <div class="divReportDetails alignJustify less" id="reportDetails" runat="server" >           
        </div>
       <%-- <div style='margin-left: 25px; padding: 0px; font-size: 14px; font-family: sans-serif; text-align: justify; max-width: 80%;'>
            <div class='text-size'>Read more...</div>
        </div>--%>
    </div>
