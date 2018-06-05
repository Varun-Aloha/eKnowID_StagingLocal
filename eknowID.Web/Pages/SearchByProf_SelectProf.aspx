<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="SearchByProf_SelectProf.aspx.cs" Inherits="eknowID.Pages.SearchByProf_SelectProf" %>

<%@ Register Src="~/Controls/SearchByProfHeader.ascx" TagName="SearchByRef" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/UploadResume.ascx" TagName="UploadResume" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery.tmpl.min.js" type="text/javascript"></script>
    <script type="text/x-jquery-tmpl" id="tmplReport">
        {{each d}}
            <div class="width100per clearBoth padding-top_33px height_30px">
                <div class="SearchByRef_GreenTick"></div>
                <div class="SearchByRef_ReportNameDiv">
                    <span class="SearchByRef_ReportNameSpan">${ReportName}</span>
                </div>
                <div class="SearchByRef_ReportDescriptDiv">
                    <span class="font-family_Arial floatLeft color_3E3E3E">${Description}</span>
                </div>
            </div>
        {{/each}}
    </script>
    <!--[if lt IE 9]>
    <script src="../Scripts/Tooltip/jquery.bgiframe.min.js" type="text/javascript"></script>
    <script src="../Scripts/Tooltip/excanvas.js" type="text/javascript"></script>   
    <![endif]-->
    <script src="../Scripts/Tooltip/jquery.bt.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery.bt.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function showPackages() {
            $(".divChoosePackage").attr("style", "display:block !important;");
        }
        function hidePackages() {
            $(".divChoosePackage").attr("style", "display:none !important;");
        }
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
                $("#SampleReport").css("height", "1270px");
            }
        }

        function page2height() {
            if ($.browser.msie && $.browser.version == '8.0') {
                $("#SampleReport").css("height", "1320px");
            }
            else {
                $("#SampleReport").css("height", "1370px");
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
            var selectedProfession = $("select" + "#<%=ddlProfession.ClientID%>").val();
            var isUserLoggedIn = $('#hdnUserLoggedIn').val();
            var controlData = "planName:'" + planName + "'";
            controlData = controlData + ",professionId:" + selectedProfession + "";
            $.ajax({
                type: "POST",
                url: "SearchByProf_SelectProf.aspx/SetAdditionalInfoRequire",
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
        table {
            border: none;
        }

        tr {
            border-bottom: 2px solid #DDDDDD !important;
            border-top: 2px solid #DDDDDD !important;
        }

        td {
            border: none;
            height: 20px !important;
        }

        tr:hover {
            background-color: #E6E6E6;
        }

        #SampleReport {
            display: none;
            height: 1225px;
            width: 1000px;
            background-color: transparent;
            top: 11% !important;
        }

        .continueButton {
            background-image: url(../Images/continue_btn_sp.png);
            background-repeat: no-repeat;
            width: 125px;
            height: 28px;
        }

        .marginleft15 {
            margin-left: 15px !important;
        }

        .planBoxShadow {
            box-shadow: 1px 0px 4px #8A8A8A;
        }

        .divPlanReportHeading {
            width: 971px !important;
        }

        .divReportInclude {
            margin-left: 2px !important;
            width: 133px;
        }

        .divContinueBtn {
            padding-top: 4px !important;
        }

        .divPlanFooter {
            margin-right: 8px;
        }

        .divChoosePlanMain {
            height: 50px;
        }
    </style>
    <!--[if gte IE 8]>
	<style type="text/css">
.divPlanFooter
{
    margin-right:8
    
    
    px !important;
}
.boxShadow {filter: progid:DXImageTransform.Microsoft.Shadow(color=#aaaaaa,direction=135,strength=5);}
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
    <asp:HiddenField ID="hdnProfessionId" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdnUserLoggedIn" runat="server" ClientIDMode="Static" />
    <div style="height: auto; min-height: 450px; min-width: 1000px; display: inline-block; width: 100%; background-color: #E7E7E7; padding-bottom: 60px;">
        <div id="divTooltip" style="display: none; min-height: 50px;" class="alignJustify padding8">
            <a href="javascript:void($('table tr td:first-child').btOff());">
                <img src="../Images/close_20x20.png" alt="close" width="12" height="12" class="gmap-close floatRight"
                    style="margin-top: -15px; margin-right: -16px;" /></a> <span id="description" style="float: left"></span>
        </div>
        <div class="stretchDiv">
            <div class="margintop40">
                <uc1:SearchByRef ID="ucSearchHeader" runat="server" />
            </div>
            <div class="SearchByRef_bodyMainDiv paddingBottom15 boxShadowIE8" style="margin-top: 20px;">
                <div class="SearchByRef_bodySubMainDiv">
                    <div class="width100per" style="height: 40px;">
                        <div class="floatLeft">
                            <h2 class="SearchByRef_SelectProfHeading">Select Profession</h2>
                        </div>
                        <div class="floatLeft">
                            <asp:DropDownList ID="ddlProfession" runat="server" CssClass="SearchByRef_SelectProfDropDown"
                                ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddlProfession_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />
                            <asp:Label ID="lblErrorSelectProf" runat="server" ForeColor="Red" Font-Bold="true"
                                Text="Please select profession to continue." Visible="false" />
                        </div>
                    </div>
                    <div class="marginTop8" style="height: 22px;">
                        <span class="font-family_Arial margin_0px color_3E3E3E shortDesc">Whether you are looking
                            for a new job or you want to proactively manage your reputation, we help you in
                            managing your background information. Choose from the list of packages that best
                            fits your needs. </span>
                    </div>
                    <div class="SearchByRef_bodyMainSeperatorDiv">
                    </div>
                    <div class="width100per height25px">
                        <span class="SearchByRef_KnowIDHelpSpan" id="descriptionHeader" runat="server" visible="false">How KnowID can help ?</span>
                    </div>
                    <div class="alignJustify">
                        <span id="ProfessionDescription" class="font-family_Arial margin_0px color_3E3E3E"
                            runat="server"></span>
                    </div>
                    <div class="clearBoth">
                    </div>
                </div>
            </div>
            <div class="divChoosePlanMain divChoosePackage display_none">
                <div style="height: 545px; padding-top: 50px; width: 1000px;">
                    <div class="divReportName">
                        <div class="divReportHeaderImgMain">
                            <div class="divPlanHeadingImg"></div>
                        </div>
                        <div class="divReportHeaderMain">
                            <div class="divLeftShadowImg">
                            </div>
                            <div class="divReportHeaderInner " style="width: 210px;">
                                <div class="height39px">
                                    <div class="divDollerHeader boldText marginleft10">
                                        $
                                    </div>
                                    <asp:Label ID="lblBasicPrice" runat="server" Text="Label" CssClass="marginLeft2 floatLeft lblPrice boldText width53"></asp:Label>
                                    <div class="divReportInclude marginleft15">
                                        Report Includes
                                    </div>
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
                                        $
                                    </div>
                                    <asp:Label ID="lblGoldPrice" runat="server" Text="Label" CssClass="marginLeft2 floatLeft lblPrice boldText width53"></asp:Label>
                                    <div class="divReportInclude marginleft15">
                                        Report Includes
                                    </div>
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
                                        $
                                    </div>
                                    <asp:Label ID="lblPlatniumPrice" runat="server" Text="Label" CssClass="marginLeft2 floatLeft lblPrice boldText width53"></asp:Label>
                                    <div class="divReportInclude marginleft15">
                                        Report Includes
                                    </div>
                                </div>
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
                                Criminal Searches
                            </div>
                        </div>
                        <div class="divReportGridOuter">
                            <div class="divReportGridInner">
                                <asp:GridView ID="grvCriminalReports" runat="server" GridLines="Both" ShowHeader="false"
                                    CssClass="planBoxShadow" Style="width: 985px;" AutoGenerateColumns="False" ClientIDMode="Static">
                                    <AlternatingRowStyle CssClass="alternaterowcolor " />
                                    <RowStyle CssClass="grvRowStyle " />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="240" ItemStyle-Height="35" ItemStyle-CssClass="reportHeaderPadding tableLeftBorder cursorPointer">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("Name") %>' ID="ReportName" />
                                                <asp:Label runat="server" Text='<%# Eval("TurnaroundTime") %>' ID="lblTurnaroundTime" />
                                                <asp:HiddenField ID="reportDescription" runat="server" Value='<%# Eval("Description") %>' />
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
                                Verification Searches
                            </div>
                        </div>
                        <div class="divReportGridOuter">
                            <div class="divReportGridInner">
                                <asp:GridView ID="grvVerificationReports" runat="server" GridLines="Both" ShowHeader="false"
                                    CssClass="planBoxShadow" Style="width: 985px;" AutoGenerateColumns="False" ClientIDMode="Static">
                                    <AlternatingRowStyle CssClass="alternaterowcolor" />
                                    <RowStyle CssClass="grvRowStyle" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="240" ItemStyle-Height="35" ItemStyle-CssClass="reportHeaderPadding tableLeftBorder cursorPointer">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("Name") %>' ID="ReportName" />
                                                <asp:Label runat="server" Text='<%# Eval("TurnaroundTime") %>' ID="lblTurnaroundTime" />
                                                <asp:HiddenField ID="reportDescription" runat="server" Value='<%# Eval("Description") %>' />
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
