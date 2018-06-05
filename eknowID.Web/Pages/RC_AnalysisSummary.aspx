<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="RC_AnalysisSummary.aspx.cs" Inherits="eknowID.Pages.RC_AnalysisSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--   <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.5.2.min.js"></script>--%>
    <script src="../Scripts/jquery.spellchecker.js" type="text/javascript"></script>
    <script src="../Scripts/Tooltip/jquery.bt.min.js" type="text/javascript"></script>
    <link href="../Styles/jquery.bt.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        var interval;
        function RedirectToDetailAnalysis() {
            window.location.href = "../Pages/RC_DetailedAnalysis.aspx";
        }

        function expandDetails(controlID, ruleName) {
            var ExpandID = 'img' + ruleName + 'Expand';
            var imgExpandID = controlID.id;
            var imgCollapsID = controlID.id.replace(ExpandID, 'img' + ruleName + 'Collaps');
            var reportDetailID = controlID.id.replace(ExpandID, ruleName + 'Details');
            $("#" + imgExpandID).attr("style", "display:none");
            $("#" + imgCollapsID).attr("style", "display:block");
            $("#" + reportDetailID).slideToggle("medium");
            //spellErrorWordCount();
        }
        function collapsDetails(controlID, ruleName) {
            var imgCollapsID = controlID.id;
            var CollapsID = 'img' + ruleName + 'Collaps';
            var imgExpandID = controlID.id.replace(CollapsID, 'img' + ruleName + 'Expand');
            var reportDetailID = controlID.id.replace(CollapsID, ruleName + 'Details');
            $("#" + imgCollapsID).attr("style", "display:none");
            $("#" + imgExpandID).attr("style", "display:block");
            $("#" + reportDetailID).slideToggle("medium");
        }       

        //Call Spell Checker On Page Loading
        $(document).ready(function (e) {
            OpenProcessingImage();
            interval = window.setInterval("checkSpellError()", 1000);           
        });

        function checkSpellError() {
            $.ajax({
                type: "POST",
                async: false,
                url: "RC_AnalysisSummary.aspx/getSpellErrorCheckData",
                contentType: "application/json; charset=utf-8",
                data: "{}",
                dataType: "json",
                success: function (result) {
                    if (result.d.IsEmployeeDateGap == true) {
                        setEmpDateGap();
                    }
                    if (result.d.SpellErrorCount > 0) {
                        $('.imgSpellError').attr("src", "../Images/fail_icon.png");
                        $('.divSpellErrorMessage').text('There are mistakes in your Resume.');
                        $('.spellError').attr('style', 'display:block !important;');
                        $('.divSpellExpandCollapsImg').attr('style', 'display:block !important;');
                        $('.spellErrorCount').text(result.d.SpellErrorCount + " ");
                        var improvementCount = parseInt($('#lblImprovementCount').text());
                        improvementCount = improvementCount + 1;
                        $('#lblImprovementCount').text(improvementCount);
                        $('.spellErrorList').text(result.d.SpellErrorList);
                    }
                    closeProcessingPopup();
                }
            });           
        }

        //Bind event Show description on down arrow hover
        $(function () {
            $(".imgExpandBtn").hover(function () {
                $('.imgExpandBtn').btOff();
                var description = "Click for description.";
                $("#description").text(description);
            });
        });

        //Show description on down arrow hover
        $(function () {
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
        

        function closeProcessingPopup() {
            CloseProcessingImage();
            clearInterval(interval);
        }

        function setEmpDateGap() {
            var improvementCount = parseInt($('#lblImprovementCount').text());
            improvementCount = improvementCount + 1;
            $('#lblImprovementCount').text(improvementCount);
            $('.imgEmpDt').attr("src", "../Images/fail_icon.png");
            $('.divEmpDtGap').text('There are gaps in your employment dates.');
            $('.divEmpGapDate').attr("style", "display:block !important;");
        }
    </script>
    <style type="text/css">
        .divAnalysisSummary
        {
            border: 1px solid #E3E3E3;
            margin-top: 26px;
            min-height: 240px;
            width: 940px;
        }
        .divAnalysisSummaryHeader
        {
            height: 42px;
            background-image: url(../Images/analysis_summery_grid_bg.png);
            background-repeat: repeat-x;
            color: #454545;
            font-weight: bold;
            font-size: 14px;
        }
        .divSummaryHeader
        {
            width: 373px;
            padding: 10px 0px 10px 20px;
            float: left;
            min-height: 20px;
            float: left;
        }
        .divPassFailHeader
        {
            width: 90px;
            padding: 10px 10px 10px 20px;
            float: left;
            text-align: center;
            height: 22px;
        }
        .divNotesHeader
        {
            width: 407px;
            padding: 10px 0px 10px 20px;
            float: left;
            height: 22px;
        }
        .divSummaryDetailColumn
        {
            color: #454545;
            font-size: 13px;
            font-weight: bold;
            min-height: 20px;
            padding: 10px 0 10px 20px;
            width: 373px;
            float: left;
        }
        .divPassFailSummaryColumn
        {
            float: left;
            height: 20px;
            padding: 8px 10px 10px 20px;
            text-align: center;
            width: 90px;
        }
        .divNotesSummaryColumn
        {
            width: 407px;
            min-height: 40px;
            float: left;
            padding-left: 20px;
        }
        .RC_ContinueBtn
        {
            background-image: url(../Images/continue_blue_btn.png);
        }
        .font_weight_normal
        {
            font-weight: normal !important;
        }
        .width_390px
        {
            width: 390px;
        }
        .spellErrorList
        {
            min-height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="RCAnalysisSummaryContent" ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">
    <asp:HiddenField runat="server" ID="hdnErrorCount" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hdnSpellError" ClientIDMode="Static" />
    <div id="divTooltip" style="display: none;" class="alignJustify padding8 height21">
        <span id="description" class="floatLeft"></span>
    </div>
    <div class="minWidth1000px RC_DetailAnalysisBg">
        <div class="margin_left_right_auto width1000px">
            <asp:HiddenField ID="hdnUserLoggedIn" runat="server" ClientIDMode="Static" />
            <div class="height50">
                <div class="divSelectProfHeading">
                    Your Analysis Summary
                </div>
                <div class="divSelectProfHeading font_weight_normal fontSize_13px">
                    We've finished scanning your resume for 5 most common resume problems. Your results
                    are summarized below. For information on how to fix your resume, click Continue.
                </div>
            </div>
            <div class="margin_left_right_auto RC_DetailAnalysisMainDiv">
                <div class="divSelectProfHeading">
                    <div class="floatLeft">
                        Your resume needs improvement in
                        <asp:Label ID="lblImprovementCount" runat="server" Text="3" ClientIDMode="Static"></asp:Label>
                        key areas</div>
                    <div class="floatRight font_weight_normal fontSize_13px color_454545">
                        <img alt="" src="../Images/pass_icon.png" />
                        <span class="verticalAlign_super marginLeft_3px">Pass</span>
                        <img alt="" src="../Images/fail_icon.png" class="marginLeft5" />
                        <span class="verticalAlign_super marginLeft_3px">Fail</span>
                        <img alt="" src="../Images/review_icon.png" class="marginLeft5" />
                        <span class="verticalAlign_super marginLeft_3px">Review</span>
                    </div>
                </div>
                <div class="divAnalysisSummary">
                    <div class="divAnalysisSummaryHeader">
                        <div class="divSummaryHeader">
                            <span>Summary</span></div>
                        <div class="divPassFailHeader">
                            <span>Pass or Fail</span></div>
                        <div class="divNotesHeader">
                            <span>Notes</span>
                        </div>
                    </div>
                    <div class="minheight_200px">
                        <div class="height100per displayInlineBlock">
                            <div class="divSummaryDetailColumn">
                                1. Spelling Errors, Typos, and Bad Grammar
                            </div>
                            <div class="divPassFailSummaryColumn">
                                <img alt="" runat="server" id="imgSpellGrammerPassFail" src="../Images/pass_icon.png"
                                    class="imgPassFail imgSpellError" />
                            </div>
                            <div class="divNotesSummaryColumn">
                                <div class="marginTop10 height25px">
                                    <div class="floatLeft color_5A5A5A divSpellErrorMessage">
                                        There are no mistakes in your Resume.</div>
                                    <div class="divExpandCollapsImg paddingRight10 floatRight divSpellExpandCollapsImg display_none">
                                        <img id="imgSpellGrammerExpand" alt="" src="../Images/down_arrow.png" width="11"
                                            height="10" onclick="expandDetails(this,'SpellGrammer');" runat="server" class="imgExpandBtn display_block cursor_pointer" />
                                        <img id="imgSpellGrammerCollaps" alt="" src="../Images/up_arrow.png" width="11" height="10"
                                            onclick="collapsDetails(this,'SpellGrammer');" class="display_none cursor_pointer"
                                            runat="server" />
                                    </div>
                                </div>
                                <div class="divReportDetails RC_RuleDescription SpellGrammerDetails" id="SpellGrammerDetails"
                                    runat="server">
                                    <textarea id="text-content" rows="5" cols="25" class="display_none">
                    </textarea>
                                    <div class="spellError width_390px display_none">
                                        Always proofread your resume carefully. Do not count on spell check to catch mistakes
                                        that you may have made during the resume writing process.
                                        <br />
                                        <br />
                                        We found <span class="spellErrorCount"></span>possible mistakes in your resume.
                                        <div class="spellErrorList width_390px boldText">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="height100per displayInlineBlock color_F4F4F4">
                            <div class="divSummaryDetailColumn">
                                2. Contact Information
                            </div>
                            <div class="divPassFailSummaryColumn">
                                <img alt="" src="../Images/review_icon.png" class="imgPassFail" />
                            </div>
                            <div class="divNotesSummaryColumn">
                                <div class="marginTop10 height25px">
                                    <div class="floatLeft color_5A5A5A">
                                        Please Review your contact information.</div>
                                    <div class="divExpandCollapsImg paddingRight10 floatRight">
                                        <img id="imgContactExpand" alt="" src="../Images/down_arrow.png" width="11" height="10"
                                            onclick="expandDetails(this,'Contact');" runat="server" class="imgExpandBtn display_block cursor_pointer" />
                                        <img id="imgContactCollaps" alt="" src="../Images/up_arrow.png" width="11" height="10"
                                            onclick="collapsDetails(this,'Contact');" class="display_none cursor_pointer"
                                            runat="server" />
                                    </div>
                                </div>
                                <div class="divReportDetails RC_RuleDescription text_align_justify" id="ContactDetails"
                                    runat="server">
                                    Always double-check your contact information, especially if it has been updated
                                    recently. If an employer can't contact you using the information on your resume,
                                    they won't bother contacting you at all.
                                </div>
                            </div>
                        </div>
                        <div class="height100per displayInlineBlock">
                            <div class="divSummaryDetailColumn">
                                3. Employment Dates
                            </div>
                            <div class="divPassFailSummaryColumn">
                                <img alt="" src="../Images/pass_icon.png" class="imgEmpDatePassFail imgEmpDt" id="imgEmpDt"
                                    runat="server" />
                            </div>
                            <div class="divNotesSummaryColumn">
                                <div class="marginTop10 height25px">
                                    <div class="floatLeft color_5A5A5A" id="divEmpDtGap" runat="server">
                                        There are no gaps in your employment dates.</div>
                                    <div class="divEmpGapDate display_none">
                                        <div class="divExpandCollapsImg paddingRight10 floatRight">
                                            <img id="imgEmpDateExpand" alt="" src="../Images/down_arrow.png" width="11" height="10"
                                                onclick="expandDetails(this,'EmpDate');" runat="server" class="imgExpandBtn display_block cursor_pointer" />
                                            <img id="imgEmpDateCollaps" alt="" src="../Images/up_arrow.png" width="11" height="10"
                                                onclick="collapsDetails(this,'EmpDate');" class="display_none cursor_pointer"
                                                runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="divReportDetails RC_RuleDescription text_align_justify" id="EmpDateDetails"
                                    runat="server">
                                    You should always include employment dates (months and years) on your resume. Potential
                                    employers need this information to determine your level of experience also to ensure
                                    when they call to verify previous employment.
                                </div>
                            </div>
                        </div>
                        <div class="height100per displayInlineBlock color_F4F4F4">
                            <div class="divSummaryDetailColumn">
                                4. Misalignment with Your Digital Identity
                            </div>
                            <div class="divPassFailSummaryColumn">
                                <img alt="" src="../Images/review_icon.png" class="imgPassFail" />
                            </div>
                            <div class="divNotesSummaryColumn">
                                <div class="marginTop10 height25px">
                                    <div class="floatLeft color_5A5A5A">
                                        Check your online identity.</div>
                                    <div class="divExpandCollapsImg paddingRight10 floatRight">
                                        <img id="imgMisalignmentExpand" alt="" src="../Images/down_arrow.png" width="11"
                                            height="10" onclick="expandDetails(this,'Misalignment');" runat="server" class="imgExpandBtn display_block cursor_pointer" />
                                        <img id="imgMisalignmentCollaps" alt="" src="../Images/up_arrow.png" width="11" height="10"
                                            onclick="collapsDetails(this,'Misalignment');" class="display_none cursor_pointer"
                                            runat="server" />
                                    </div>
                                </div>
                                <div class="divReportDetails RC_RuleDescription text_align_justify" id="MisalignmentDetails"
                                    runat="server">
                                    You will be Googled. In this information age too much information in someone digital
                                    footprint allows recruiters to sift through applicants even before your interview.
                                    Although the blending of personal and professional lives isn't exactly new but the
                                    Internet does make it more easily accessible. Take care with privacy setting. Remove
                                    any photos that might put your reputation in a negative right. Also check to make
                                    sure there is nothing erroneous showing up during the criminal background check.
                                    You will have an opportunity to check that on the next screen.
                                </div>
                            </div>
                        </div>
                        <div class="height100per displayInlineBlock">
                            <div class="divSummaryDetailColumn">
                                5. Employment and Education Verification
                            </div>
                            <div class="divPassFailSummaryColumn">
                                <img alt="" src="../Images/review_icon.png" class="imgPassFail" />
                            </div>
                            <div class="divNotesSummaryColumn">
                                <div class="marginTop10 height25px">
                                    <div class="floatLeft color_5A5A5A">
                                        Verify the Employment & Education information provided.</div>
                                    <div class="divExpandCollapsImg paddingRight10 floatRight">
                                        <img id="imgEmpEduExpand" alt="" src="../Images/down_arrow.png" width="11" height="10"
                                            onclick="expandDetails(this,'EmpEdu');" runat="server" class="imgExpandBtn display_block cursor_pointer" />
                                        <img id="imgEmpEduCollaps" alt="" src="../Images/up_arrow.png" width="11" height="10"
                                            onclick="collapsDetails(this,'EmpEdu');" class="display_none cursor_pointer"
                                            runat="server" />
                                    </div>
                                </div>
                                <div class="divReportDetails RC_RuleDescription text_align_justify" id="EmpEduDetails"
                                    runat="server">
                                    When listing your job experience/job duties on your resume, try to include information
                                    about what you have accomplished. Also make sure your dates, title and experience
                                    are aligned when HR goes to verify. It may sound rote but sometimes incorrect dates
                                    can delay your hiring process during the background screening of your background.
                                    In addition that your education can be verified and that no outstanding fees to
                                    your school are owed to prohibit verification by your potential employer.
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="clearBoth width1000px margin_left_right_auto height_30px paddingTop15">
                <div class="width100per height_30px">
                    <input type="button" id="btnNext" onclick="return RedirectToDetailAnalysis();" class="floatRight RC_ContinueBtn" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
