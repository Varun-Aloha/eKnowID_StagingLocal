<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="innerSignUpData.ascx.cs"
    Inherits="eknowID.Controls.innerSignUpData" %>
<%@ Register Src="stateDropdown.ascx" TagName="stateDropdown" TagPrefix="uc1" %>
<script src="../Scripts/UserScripts/CascadingSelectList.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">

    //Date picker
    $(function () {

        $("#txtBDay").datepicker({
            dateFormat: 'mm/dd/yy',
            maxDate: new Date('12/31/2000'),
            yearRange: '1900:2000',
            changeYear:true,
            changeMonth:true
            });

        $("#imgCalenderIcon").click(function () {
            $("#txtBDay").datepicker('show');
        });
    });

    //To set water text 
    $(function () {
        $('#txtFName').watermark('First');        
        $('#txtLName').watermark('Last');
        $('#txtAns').watermark('Answer');

        var Middlecnt = "Middle";
        $('#txtMName').val(Middlecnt).addClass('watermark1');

        $('#txtMName').blur(function () {
            if ($(this).val().length == 0) {
                $('#hdninnerMiddleName').val($(this).val().length);
                $(this).val(Middlecnt).addClass('watermark1');
               
            }
        });
        $('#txtMName').change(function () {
            $('#hdninnerMiddleName').val($(this).val().length);
        });
        $('#txtMName').focus(function () {
            if ($(this).val() == Middlecnt) {
                $(this).val('').removeClass('watermark1');
                $('#txtMName').select();
            }
        });
    });

    $(function () {
        $("#txtIndentificationInner").mask("999-99-9999");
    });

    var enterCount = 0;
    function signUpDatahandle(code) {
        if (enterCount == 0) {
            if (code == 13) {
                if (ValidateInnerSignUp()) {

                    enterCount++;
                }
            }
        }
    }


    $(function () {
        $(".validnnerSingUp").keydown(function (e) {
            if (!allowed) return;
            allowed = false;
            if (e.which == 13) {
                ValidateInnerSignUp();
                e.preventDefault();
                return false;
            }
        });

        $(document).keyup(function (e) {
            allowed = true;
        });
        $(document).focus(function (e) {
            allowed = true;
        });
    });
</script>
<style type="text/css">
    .blackbtn
    {
        background-image: url("../images/black_btn_middle.png");
        background-repeat: repeat-x;
        border: 0 none;
        border-radius: 5px 5px 5px 5px;
        font-weight: bold;
        height: 30px;
        margin: 3px;
    }
</style>
<div class="stretchDiv">
    <div class="floatLeft signUpDescription">
        <div>
        <asp:HiddenField ID="hdninnerMiddleName" runat="server" ClientIDMode="Static" />
            <b style="color: #415d8f; font-size: 25px;">Join eKnowID,</b><b style="color: #415d8f;
                font-size: 18px;">&nbsp;its fast and easy!</b>
            <br />
            <p style="color: #6a6969; font-size: 16px;">
                Sign up now and <b style="color: #5f5e5e; font-size: 20px;">look beyond your surface</b></p>
            <br />
            <div class="singUpDescriptionContent">
                <div class="floatLeft singUpContentImage">
                    <img src="../Images/EKnow_ID_image-(circle).png" alt="" />
                </div>
                <div class="paddingTop30">
                    <b class="faintblack fontsize16">KnowID</b>
                    <br />
                    <p class="pText darkGrey">
                        Instantly identify What's in your Background Check and take proactive measures before
                        releasing outdated or errorneous information with the help on KonwID.
                    </p>
                </div>
            </div>
            <div class="clearBoth">
                <img src="../Images/line_sign_up.png" alt="" width="350px;" />
            </div>
            <div class="singUpDescriptionContent">
                <div class="floatLeft singUpContentImage">
                    <img src="../Images/Checkmate_Circle_img.png" alt="" />
                </div>
                <div class="paddingTop30">
                    <b class="faintblack fontsize16">Checkmate</b>
                    <br />
                    <p class="pText darkGrey">
                        Checkmate helps you to find the best soul mate by allowing you to run a comprehensiv
                        Background check on them.
                    </p>
                </div>
            </div>
            <div class="clearBoth">
                <img src="../Images/line_sign_up.png" alt="" width="350px;" />
            </div>
            <div class="singUpDescriptionContent">
                <div class="floatLeft singUpContentImage">
                    <img src="../Images/nannycheck_circle_img.png" alt="" />
                </div>
                <div class="paddingTop30">
                    <b class="faintblack fontsize16">NannyCheck</b>
                    <br />
                    <p class="pText darkGrey">
                        NannyCheck helps you to find Potential Cregivers, ensuring that your little ones
                        are in safe hands by allowing you to run a Comprehensive Background on them.
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="floatLeft">
        <div style="font-size: 13px; font-weight: bold; height: 13px; padding: 10px; background-image: url(../Images/report_grid_bg_top.png)">
            Please complete the required information below in order to complete the order
        </div>
        <div class="floatLeft signUpForm">
            <br />
            <div class="detailsNameList floatLeft">
                <div class="detailsName">
                    Name
                </div>
                <div class='detailsName'>
                    Email Address
                </div>
                <div class='detailsName'>
                    Confirm Email Address
                </div>
                <div class='detailsName innerPasswordArea'>
                    Password
                </div>
                <div class='detailsName innerPasswordArea'>
                    Confirm Password
                </div>
                <div class='detailsName'>
                    BirthDay
                </div>
                <div class='detailsName'>
                    Gender
                </div>
                <div class='detailsName'>
                    Mobile Number
                </div>
                <div class='detailsName'>
                    Identification
                </div>
             <%--   <div class='detailsName'>
                </div>--%>
                <div class='detailsName'>
                    Secret Question
                </div>
                <div class='detailsName'>
                </div>
                <div class='detailsName'>
                    Address Line 1
                </div>
                <div class='detailsName'>
                    Address Line 2
                </div>
                <div class='detailsName'>
                    City
                </div>
                <div class='detailsName'>
                    State/Province
                </div>
                <div class='detailsName'>
                    County
                </div>
               <%-- <div class='detailsName'>
                    District
                </div>--%>
                <div class='detailsName'>
                    Zip
                </div>
                <div class='detailsName'>
                </div>
            </div>
            <div class='floatSecond' id="InnerSignUpDataContainer">
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtFName" runat="server" MaxLength="20" ClientIDMode="Static" CssClass="width80 required lettersonly charOnly validnnerSingUp" />
                    <asp:TextBox ID="txtMName" runat="server" MaxLength="20" ClientIDMode="Static" CssClass="width80 marginLeft10 lettersonly charOnly validnnerSingUp"/>
                    <asp:TextBox ID="txtLName" runat="server" MaxLength="20" ClientIDMode="Static" CssClass="width80 marginLeft10 required lettersonly charOnly validnnerSingUp"/>
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtEmailAddressInner" CssClass="width260 required email orgEmail validnnerSingUp"
                        runat="server" MaxLength="50" onkeypress="return (event.keyCode!=13);"
                        ClientIDMode="Static" />
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtConfirmEmailAddressInner" CssClass="width260 required email compareEmail validnnerSingUp"
                        equalTo="#txtEmailAddressInner" runat="server"
                        onkeypress="return (event.keyCode!=13);" MaxLength="50" ClientIDMode="Static" />
                </div>
                <div class='detailNameValue innerPasswordArea'>
                    <asp:TextBox ID="txtPasswordInner" CssClass="width260 required validnnerSingUp" runat="server" MaxLength="15"
                        minlength="6" TextMode="Password" oncopy="return false;" onpaste="return false" oncut="return false"
                        onkeypress="return (event.keyCode!=13);" ClientIDMode="Static" />
                </div>
                <div class='detailNameValue innerPasswordArea'>
                    <asp:TextBox ID="txtConfirmPasswordInner" CssClass="width260 required comparePassword validnnerSingUp"
                        equalTo="#txtPasswordInner" minlength="6" runat="server" MaxLength="15" ClientIDMode="Static"
                        TextMode="Password" oncopy="return false;" onpaste="return false;" oncut="return false;"/>
                </div>
                <div class='detailNameValue'>
                    <div class="floatLeft width100">
                        <asp:TextBox ID="txtBDay" MaxLength="10"
                            onkeypress="return (event.keyCode!=13);" CssClass="width73 dateRange date DateFormat validnnerSingUp"
                            runat="server" ClientIDMode="Static" /></div>
                    <div class="floatLeft marginLeft5">
                        <img src="../Images/cal_icon.png" id="imgCalenderIcon" alt="" /></div>
                </div>
                <div class='detailNameValue'>
                    <asp:RadioButton ID="rdobtnMaleInner" runat="server" Text="Male" GroupName="Gender"
                        ClientIDMode="Static" Checked="True" onkeypress="return (event.keyCode!=13);" />
                    <asp:RadioButton ID="rdobtnFemaleInner" runat="server" Text="Female" GroupName="Gender"
                        ClientIDMode="Static" onkeypress="return (event.keyCode!=13);" />
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtMobileNumberInner" CssClass="width260  number digitsOnly validnnerSingUp" runat="server"
                        MaxLength="10" minlength="10" ClientIDMode="Static"/>
                </div>
          <%--      <div class='detailNameValue'>
                    <asp:RadioButton ID="rdobtnSSNInner" runat="server" Text="Social Security Number"
                        GroupName="Identification" ClientIDMode="Static" Checked="True" onkeypress="return (event.keyCode!=13);"/>
                    <asp:RadioButton ID="rdobtnGovermentIDInner" runat="server" Text="Goverment ID #"
                        GroupName="Identification" ClientIDMode="Static" onkeypress="return (event.keyCode!=13);"/>
                </div>--%>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtIndentificationInner" onkeypress="return (event.keyCode!=13);"
                       CssClass="width260 required validnnerSingUp"
                        runat="server" ClientIDMode="Static" MaxLength="30" />
                </div>
                <div class='detailNameValue'>
                    <asp:DropDownList ID="ddlSecretQuestionInner" CssClass="width275 floatLeft  dropdownPager ddlValidation"
                        runat="server" ClientIDMode="Static" />
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtAns" CssClass="width260 required validnnerSingUp" onkeypress="return (event.keyCode!=13);"
                        runat="server" ClientIDMode="Static"
                        MaxLength="100" />
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtAddressLine1Inner" onkeypress="return (event.keyCode!=13);"
                        CssClass="width260 required validnnerSingUp" runat="server" MaxLength="100" ClientIDMode="Static" />
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtAddressLine2Inner" onkeypress="return (event.keyCode!=13);" 
                        CssClass="width260 required validnnerSingUp" runat="server" MaxLength="100" ClientIDMode="Static" />
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtCityInner" CssClass="required LettersWithSpace charSpaceOnly validnnerSingUp" onkeypress="return (event.keyCode!=13);"
                         runat="server" MaxLength="50" ClientIDMode="Static" />
                </div>
                <div class='detailNameValue'>
                    <span id="ddlStateInnersignup" class="displayInlineBlock  width200">
                        <uc1:stateDropdown ID="ddlStateInner" runat="server" ClientIDMode="Static" />
                    </span>
                </div>
                <div class='detailNameValue'>
                    <span class="displayInlineBlock width200">
                        <asp:DropDownList ID="ddlCountyInner" runat="server" ClientIDMode="Static" CssClass="ddlValidation floatLeft width160" />
                    </span>
                </div>
                <%--<div class='detailNameValue'>
                    <span class="displayInlineBlock width200">
                        <asp:DropDownList ID="ddlDistrictInner" runat="server" ClientIDMode="Static" CssClass="ddlValidation floatLeft width160" />
                    </span>
                </div>--%>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtZipInner" onkeypress="return (event.keyCode!=13);"
                        runat="server" MaxLength="5" minlength ="5" CssClass="required zipcode digitsOnly validnnerSingUp" ClientIDMode="Static"
                         />
                </div>
                <div class='detailNameValue'>
                    <asp:CheckBox ID="chkAgreeInner" runat="server" Text="I agree to the EknowID " onkeydown="signUpDatahandle(event.keyCode);" onkeypress="return (event.keyCode!=13);" ClientIDMode="Static" /><a
                        href="../Pages/TermsofUse.aspx" target="_blank" class="lnkColor">Terms & Conditions</a>
                </div>
            </div>
        </div>
        <div class="clearBoth">
        </div>
        <div>
            <input type="button" value="Continue >>" id="imgBtnContinue" class="whiteColor Createbtn blackbtn floatRight"
                onclick="ValidateInnerSignUp();" />
        </div>
    </div>
    <asp:HiddenField ID="hdnAccountTypeInner" Value="1" runat="server" ClientIDMode="Static" />
</div>
