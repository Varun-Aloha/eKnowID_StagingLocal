<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="SelectProf_PackageSelection.aspx.cs" Inherits="eknowID.Pages.SelectProf_PackageSelection" %>

<%@ Register Src="~/Controls/SearchByProfHeader.ascx" TagName="SearchByRef" TagPrefix="uc1" %>
<%--<%@ Register Src="~/Controls/IdentityTheftSearchByProfHeader.ascx" TagName="IdentityTheft_SearchByRef"
    TagPrefix="uc2" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!--[if lt IE 9]>
    <script src="../Scripts/Tooltip/jquery.bgiframe.min.js" type="text/javascript"></script>
    <script src="../Scripts/Tooltip/excanvas.js" type="text/javascript"></script>
    <![endif]-->
    <script src="../Scripts/Tooltip/jquery.bt.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery.bt.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">

        function redirectToUpgradePackage() {
            window.location.href = "../Pages/UpgradeReportPackage.aspx";
        }


        function scrolltop() {
            window.scrollTo(0, 0);
        }

        function page1height() {
            if ($.browser.msie && $.browser.version == '8.0') {
                $("#SampleReport").css("height", "1225px");             
            }
            else {
                $("#SampleReport").css("height", "1225px");
            }
        }

        function page2height() {
            if ($.browser.msie && $.browser.version == '8.0') {
                $("#SampleReport").css("height", "1320px");
            }
            else {
                $("#SampleReport").css("height", "1320px");
            }
        }

        function page3height() {
            if ($.browser.msie && $.browser.version == '8.0') {
                $("#SampleReport").css("height", "730px");
            }
            else {
                $("#SampleReport").css("height", "730px");
            }
        }
        $(function () {
            $("table tr td:first-child").click(function () {
                
                $('table tr td:first-child').btOff();

                var description = $(this).find('input[type=hidden]').val();
                $("#description").text(description);
            });
        });


        $(function () {
            $('#divTooltip').hide();
            
            $('table tr td:first-child').bt({
                positions: 'top',
                contentSelector: "$('#divTooltip')", /*hidden div*/
                trigger: ['click'],
                centerPointX: .5,
                spikeLength: 10,
                spikeGirth: 10,
                width: 450,
                padding: 10,
                cornerRadius: 4,
                fill: '#FFF',
                strokeStyle: '#ABABAB',
                strokeWidth: 2
            });
        });

        $(function () {
            if ($.browser.msie && $.browser.version == '8.0') {
                $("#SampleReport").css("height", "1225px");
            }
        });

        function setRequireAdditionalInfo(planName) {
            $.cookie('showUploadResumeDialog', 'true');
            $.cookie('redirectToOrderDetail', 'true');          
            var isUserLoggedIn = $('#hdnUserLoggedIn').val();
            var controlData = "planName:'" + planName + "'";         
            $.ajax({
                type: "POST",
                url: "SelectProf_PackageSelection.aspx/SetAdditionalInfoRequire",
                contentType: "application/json; charset=utf-8",
                data: "{" + controlData + "}",
                async: false,
                dataType: "json",
                success: function (result) {
                    window.location.href = "../Pages/UpgradeReportPackage.aspx";                 
                }
            });
        }
    </script>
    <style type="text/css">
        table
        {
            border: none;
        }
        tr
        {
            border-bottom: 2px solid #DDDDDD !important;
            border-top: 2px solid #DDDDDD !important;
        }
        
        td
        {
            border: none;
            height:20px !important;
        }
        tr:hover
        {
            background-color: #E6E6E6;
        }
        #SampleReport
        {
            display: none;
            height: 1225px;
            width: 1000px;
            background-color: transparent;
            top: 11% !important;
        }
        .continueButton
        {
            background-image:url(../Images/continue_btn_sp.png);
            width:125px;
            height:28px;
        }
        .marginleft15 { margin-left:15px !important; }
           .planBoxShadow
        {
            box-shadow: 1px 0px 4px #8A8A8A;
        }
        .divPlanReportHeading
        {
            width: 971px !important;
        }
        .divReportInclude
        {
             margin-left: 2px !important;
            width: 133px;
        }
        .divContinueBtn
        {
               padding-top: 4px !important;
        }
        .divPlanFooter
        {
              margin-right: 5px;
        }
    </style>
    <!--[if gte IE 8]>
	<style type="text/css">
.divPlanFooter
{
    margin-right:7px !important;
}
</style>
<![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdnRequiredReport" runat="server" />
    <asp:HiddenField ID="hdnBasicPlanID" runat="server" />
    <asp:HiddenField ID="hdnGoldPlanID" runat="server" />
    <asp:HiddenField ID="hdnPlatinumPlanID" runat="server" />
    <asp:HiddenField ID="hdnGoldRequired" runat="server" />
    <asp:HiddenField ID="hdnPlatinumRequired" runat="server" />
    <asp:HiddenField ID="hdnUserLoggedIn" runat="server" ClientIDMode="Static" />
    <div class="divPackageSelectoinBg minWidth1000px">

         <div id="divTooltip" style="display: none; min-height:50px;" class="alignJustify padding8">

         <a href="javascript:void($('table tr td:first-child').btOff());"><img
                src="../Images/close_20x20.png" alt="close" width="12" height="12" class="gmap-close floatRight"
                style="margin-top: -15px; margin-right: -16px;" /></a>
         <span id ="description" style="float:left"></span>
                
        </div>

        <div class="divChoosePlanMain">
            <div>
                <uc1:SearchByRef ID="ucSearchHeader" runat="server" />
                <%--<uc2:IdentityTheft_SearchByRef ID="IdentityTheft_SearchByRef" runat="server" />--%>                
            </div>
            <div style="height: 545px; padding-top: 50px; width: 1000px;">
                <div class="divReportName">
                        <div class="divReportHeaderImgMain">
                            <div class="divPlanHeadingImg">
                            </div>
                        </div>
                        <div class="divReportHeaderMain">
                            <div class="divLeftShadowImg">
                            </div>
                            <div class="divReportHeaderInner " style="width: 210px;">
                             <div class="height39px">
                                <div class="divDollerHeader boldText marginleft10">
                                    $</div>
                                <asp:Label ID="lblBasicPrice" runat="server" Text="Label" CssClass="marginLeft2 floatLeft lblPrice boldText width53"></asp:Label>
                                <div class="divReportInclude marginleft15">
                                    Report Includes</div>
                                    </div>
                                <div class="divContinueBtn">
                                    <input type="button" class="continueButton alacartNextBtn marginleft25" onclick="return setRequireAdditionalInfo('Basic');" />
                                </div>
                            </div>
                            <div class="divLeftShadowImg">
                            </div>
                            <div class="divReportHeaderInner " style="width: 220px;">
                            <div class="height39px">
                                <div class="divDollerHeader boldText marginleft10">
                                    $</div>
                                <asp:Label ID="lblGoldPrice" runat="server" Text="Label" CssClass="marginLeft2 floatLeft lblPrice boldText width53"></asp:Label>
                                <div class="divReportInclude marginleft15">
                                    Report Includes</div>
                                    </div>
                                <div class="divContinueBtn">
                                    <input type="button" class="continueButton alacartNextBtn marginleft25" onclick="return setRequireAdditionalInfo('Gold');" />
                                </div>
                            </div>
                            <div class="divRightShadowImg">
                            </div>
                            <div class="divReportHeaderInner " style="width: 212px;">
                             <div class="height39px">
                                <div class="divDollerHeader boldText marginleft10">
                                    $</div>
                                <asp:Label ID="lblPlatniumPrice" runat="server" Text="Label" CssClass="marginLeft2 floatLeft lblPrice boldText width53"></asp:Label>
                                <div class="divReportInclude marginleft15">
                                    Report Includes</div></div>
                                <div class="divContinueBtn">
                                    <input type="button" class="continueButton alacartNextBtn marginleft25" onclick="return setRequireAdditionalInfo('Platnium');" />
                                </div>
                            </div>
                            <div class="divRightShadowImg">
                            </div>
                        </div>
                    </div>
                <div class="margin_left_right_auto" style="width: 1000px;">
                    <div class="divReportType">
                        <div class="divPlanReportHeading clearBoth floatLeft planBoxShadow" style="border-radius: 5px 0 0 0;">
                            Criminal Searches</div>
                        <div class="divRightShadowImg" style="height: 25px;">
                        </div>
                    </div>
                    <div class="divReportGridOuter">
                        <div class="divReportGridInner">
                            <asp:GridView ID="grvCriminalReports" runat="server" GridLines="Both" ShowHeader="false" CssClass="planBoxShadow"
                                Style="width: 985px;" AutoGenerateColumns="False" ClientIDMode="Static">
                                <AlternatingRowStyle CssClass="alternaterowcolor " />
                                <RowStyle CssClass="grvRowStyle " />
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="240" ItemStyle-Height="35" ItemStyle-CssClass="reportHeaderPadding tableLeftBorder cursorPointer">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("Name") %>' ID="ReportName"/> <asp:Label runat="server" Text='<%# Eval("TurnaroundTime") %>' ID="lblTurnaroundTime"/>
                                            <asp:HiddenField ID ="reportDescription" runat="server" Value='<%# Eval("Description") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="11" ItemStyle-Height="35" ItemStyle-CssClass="leftShadowImage">
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="237" ItemStyle-Height="35" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Image ID="imgBasic" runat="server" ImageUrl="../Images/green_tick19x20.png"
                                                Visible='<%# Eval("Basic") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="11" ItemStyle-Height="35" ItemStyle-CssClass="leftShadowImage">
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="248" ItemStyle-Height="35" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Image ID="imgGold" runat="server" ImageUrl="../Images/green_tick19x20.png" Visible='<%# Eval("Gold") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="11" ItemStyle-Height="35" ItemStyle-CssClass="rightShadowImage">
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="240" ItemStyle-Height="35" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Image ID="imgPlatinum" runat="server" ImageUrl="../Images/green_tick19x20.png"
                                                Visible='<%# Eval("Platinum") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Height="35" ItemStyle-CssClass="rightShadowImage">
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="divReportType">
                        <div class="divPlanReportHeading clearBoth floatLeft planBoxShadow">
                            Verification Searches</div>
                        <div class="divRightShadowImg" style="height: 25px;">
                        </div>
                    </div>
                    <div class="divReportGridOuter">
                        <div class="divReportGridInner">
                            <asp:GridView ID="grvVerificationReports" runat="server" GridLines="Both" ShowHeader="false" CssClass="planBoxShadow"
                                Style="width: 985px;" AutoGenerateColumns="False" ClientIDMode="Static">
                                <AlternatingRowStyle CssClass="alternaterowcolor" />
                                <RowStyle CssClass="grvRowStyle" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="240" ItemStyle-Height="35" ItemStyle-CssClass="reportHeaderPadding tableLeftBorder cursorPointer">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("Name") %>' ID="ReportName" /> <asp:Label runat="server" Text='<%# Eval("TurnaroundTime") %>' ID="lblTurnaroundTime"/>
                                            <asp:HiddenField ID ="reportDescription" runat="server" Value='<%# Eval("Description") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="11" ItemStyle-Height="35" ItemStyle-CssClass="leftShadowImage">
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="237" ItemStyle-Height="35" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Image ID="imgBasic" runat="server" ImageUrl="../Images/green_tick19x20.png"
                                                Visible='<%# Eval("Basic") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="11" ItemStyle-Height="35" ItemStyle-CssClass="leftShadowImage">
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="248" ItemStyle-Height="35" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Image ID="imgGold" runat="server" ImageUrl="../Images/green_tick19x20.png" Visible='<%# Eval("Gold") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="11" ItemStyle-Height="35" ItemStyle-CssClass="rightShadowImage">
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="240" ItemStyle-Height="35" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Image ID="imgPlatinum" runat="server" ImageUrl="../Images/green_tick19x20.png"
                                                Visible='<%# Eval("Platinum") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Height="35" ItemStyle-CssClass="rightShadowImage">
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="divPlanFooter">
                        </div>
                        <div class="width100per clearBoth">
                            <a href="#" class="floatRight" style="text-decoration: none; color: #5383db; padding-right: 18px;"
                                onclick="OpenSampleReport();">View Sample Report</a>
                        </div>
                        <div id="SampleReport">
                            <div class="closeBtnDiv">
                                <a class="bClose"></a>
                            </div>
                            <iframe id="iframeViewReports" src="ViewSampleReport.aspx" frameborder="0" height="100%;"
                                width="100%" scrolling="no" frameborder="0"></iframe>
                        </div>
                    </div>                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>
