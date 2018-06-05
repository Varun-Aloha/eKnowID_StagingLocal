<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="signUp.ascx.cs" Inherits="eknowID.Controls.SignUp" %>
<%@ Register Src="stateDropdown.ascx" TagName="stateDropdown" TagPrefix="uc1" %>

<%--<script src="../Scripts/UserScripts/CascadingSelectList.js" type="text/javascript"></script>--%>
<script type="text/javascript" language="javascript">
//    $(document).ready(function () {
//        $('#txtPassword').pwdMeter({
//            minLength: 6,
//            displayGeneratePassword: false,
//            generatePassText: 'Password Generator',
//            generatePassClass: 'GeneratePasswordLink',
//            randomPassLength: 15
//        });
//    });


//    $(document).ready(function () {

//        $('#txtPassword').keypress(function () {
//            //document.getElementById('pwdMeter').style.display = "block";
//            $("#pwdMeter").css("display", "block");
//        });
//    });




//    window.onload = function (e) {
//        //document.getElementById('pwdMeter').style.display = "none";
//        $("#pwdMeter").css("display", "none");
//    }
    $(function () {
        $("#txtBirthDay").datepicker({
            dateFormat: 'mm/dd/yy',
            maxDate: new Date('12/31/2000'),
            yearRange: '1900:2000',
            changeYear: true,
            changeMonth: true
            });

        $("#imageIcon").click(function () {
            $("#txtBirthDay").datepicker('show');
        });

        $("#txtBirthDay").change(function () {
            $(this).valid();
        });
    });

    // To set water text
    $(function () {
        $('#txtFirstName').watermark('First');
        //$('#txtMiddleName').watermark('Middle');
        $('#txtLastName').watermark('Last');
        $('#txtAnswer').watermark('Answer');


        var Middle = "Middle";
        $('#txtMiddleName').val(Middle).addClass('watermark1');

        $('#txtMiddleName').blur(function () {
            if ($(this).val().length == 0) {
                $('#hdnMiddleName').val($(this).val().length);
                $(this).val(Middle).addClass('watermark1');
            }

        });
        $('#txtMiddleName').change(function () {
            $('#hdnMiddleName').val($(this).val().length);
        });
        $('#txtMiddleName').focus(function () {
            if ($(this).val() == Middle) {
                $(this).val('').removeClass('watermark1');
                $('#txtMiddleName').select();
            }
        });
    });

    $(function () {
        $("#txtIndentification").mask("999-99-9999");
    });

    function mainSignUphandle(code) {
        if (code == 13) {
            ValidateSignUp();
        }
    }

    $(function () {            
        $(".validateSingUp").keydown(function (e) {
            if (!allowed) return;
            allowed = false;
            if (e.which == 13) {
                ValidateSignUp();
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
    #btnCreateAccount
    {
        background-image: url(../Images/Create_Ac_btn.png);
        background-repeat: no-repeat;
        width: 134px;
        height: 29px;
        border-width: 0px;
        cursor: pointer;
    }
        
   label.error
   {
       display:none !important;
   }
</style>
<!--[if gte IE 8]>
	<style type="text/css">
    .popupPosition
    {
    top:-135px !important;
    }
    </style>
<![endif]-->
<div class="stretchDiv">
    <div class="closeBtnDiv">
        <a class="bClose closebtnSinginSingnUp"></a>
    </div>
    <div class="signUpLogo borderRadiusTopCorners6">
        <b><span class="bigTitle">Sign up</span> or <a href="#" class="lnkColor signInDiv"
            title="SignIn" onclick="SignInDialog();">Sign in</a></b>
    </div>
    <div class="floatLeft signUpDescription">
        <div>
        <asp:HiddenField ID="hdnMiddleName" runat="server" ClientIDMode="Static" />
            <b style="color: #415d8f; font-size: 25px; font-weight: 100;">Join eKnowID,</b><b
                style="color: #415d8f; font-size: 18px;">&nbsp;it's fast and easy !</b>
            <br />
            <p style="color: #6a6969; font-size: 16px;">
                Sign up now and <b style="color: #5f5e5e; font-size: 20px;">look Beyond Your Surface</b></p>
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
        </div>
    </div>
    <div class="floatLeft">
        <div class="floatLeft signUpForm">
            <div class="bubbleInfo" style="width: 235px; height: 44px; float: left;">
                <div>
                    <asp:ImageButton ID="btnSingupFacebook" runat="server" ImageUrl="~/Images/SignUpFacebook.png"
                        class="trigger" ClientIDMode="Static" Width="230" CausesValidation="False" OnClientClick="return login('facebook','SingUp','Outer')" />&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </div>
                <table id="dpop" class="popup popupPosition">
                    <tbody>
                        <tr>
                            <td id="topleft" class="corner">
                            </td>
                            <td class="top">
                            </td>
                            <td id="topright" class="corner">
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                            </td>
                            <td style="padding: 0px; margin: 0px;background-color:white;">
                                <table class="popup-contents">
                                    <tbody>
                                        <tr>
                                            <td>
                                                Sign up using Facebook account and we will port
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                over whatever information we can to simplify your
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                account creation process.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height:2px;">
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Once done, use your Facebook account
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                credentials to sign in to our site!
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td class="right">
                            </td>
                        </tr>
                        <tr>
                            <td class="corner" id="bottomleft">
                            </td>
                            <td class="bottom" style="padding-bottom: 0px !important; padding-top: 0px !important;">
                                <img width="30" height="29" alt="popup tail" src="http://static.jqueryfordesigners.com/demo/images/coda/bubble-tail2.png" />
                            </td>
                            <td id="bottomright" class="corner">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="bubbleInfo marginLeft100" style="float: left; height: 47px; margin-left: 10px;
                width: 240px;">
                <div>
                    <asp:ImageButton ID="btnSingupLinkedIn" runat="server" ImageUrl="~/Images/SignUpLinkedIn.png"
                        class="trigger" Width="230" CausesValidation="False" OnClientClick="return login('LINKEDIN')" />
                </div>               
            </div>
            <br />
            <div id="seprator">
                <span class="horizontalLine"></span><span style="padding-left: 6px; padding-right: 6px;
                    font-weight: bolder;">OR</span><span class="horizontalLine"></span>
            </div>
            <div class="detailsNameList floatLeft">
                <div class="detailsName">
                    <asp:HiddenField ID="hdnAccountType" Value="1" runat="server" ClientIDMode="Static" />
                    Name
                </div>
                <div class='detailsName'>
                    Email Address
                </div>
                <div class='detailsName'>
                    Confirm Email Address
                </div>
                <div class='detailsName passwordArea'>
                    Password
                </div>
                <div class='detailsName passwordArea'>
                    Confirm Password
                </div>     
                 <div class='detailsName'>                  
                </div>         
                <div class='detailsName'>
                    Date of birth
                </div>               
                <div class='detailsName'>
                    Gender
                </div>
                <div class='detailsName'>
                    Mobile Number
                </div>
                <div class='detailsName'>
                   SSN Identification
                </div>          
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
                    Zip
                </div>
                <div class='detailsName'>
                </div>
            </div>
            <div class='floatSecond' id ="inputContainer">
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="20" ClientIDMode="Static"
                        CssClass="width80 required lettersonly charOnly validateSingUp" /><span class="red asterisk">*</span>
                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="width80 marginLeft10 lettersonly charOnly validateSingUp"
                        MaxLength="20" ClientIDMode="Static" />
                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="20" ClientIDMode="Static"
                        CssClass="width80 marginLeft10 required lettersonly charOnly validateSingUp" /><span class="red asterisk">*</span>
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtEmailAddress" CssClass="width260 required email orgEmail validateSingUp" runat="server"
                        MaxLength="50" ClientIDMode="Static" /><span class="red asterisk">*</span>
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtConfirmEmailAddress" CssClass="width260 required email compareEmail validateSingUp"
                        equalTo="#txtEmailAddress" runat="server" MaxLength="50"
                        ClientIDMode="Static" /><span class="red asterisk">*</span>
                </div>
                <div class='detailNameValue passwordArea'>
                    <asp:TextBox ID="txtPassword" CssClass="width260 required validateSingUp" runat="server" minlength="6"
                        MaxLength="15" TextMode="Password"
                        ClientIDMode="Static" oncopy="return false;" onpaste="return false;" oncut="return false;" /><span class="red asterisk">*</span>
                </div>
                <div class='detailNameValue passwordArea'>
                    <asp:TextBox ID="txtConfirmPassword" CssClass="width260 required comparePassword validateSingUp"
                        minlength="6" equalTo="#txtPassword" oncopy="return false;" onpaste="return false;" oncut="return false;"
                        runat="server" MaxLength="15" TextMode="Password" ClientIDMode="Static" /><span class="red asterisk">*</span>
                </div>               
                <div class="detailNameValue">              
                    <div class="strength-indicator" style="height: 30px;">
                        <div id="pwdMeter" class="neutral" style="display: none;">
                        Very Weak</div>
                </div>
            </div>
                <div class='detailNameValue'>
                    <div class="floatLeft" style="width: 100px">
                        <asp:TextBox ID="txtBirthDay" CssClass="width73 required dateRange DateFormat validateSingUp" MaxLength="10"
                            runat="server" ClientIDMode="Static" /><span class="red asterisk">*</span></div>
                    <div class="floatLeft">
                        <img src="../Images/cal_icon.png" id="imageIcon" alt="" /></div>
                </div>
                
                <div class='detailNameValue'>
                    <asp:RadioButton ID="rdobtnMale" runat="server" Text="Male" GroupName="Gender" ClientIDMode="Static"
                        Checked="True" />
                    <asp:RadioButton ID="rdobtnFemale" runat="server" Text="Female" GroupName="Gender"
                        ClientIDMode="Static" />
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtMobileNumber" CssClass="width260 required number digitsOnly validateSingUp" runat="server" MaxLength="10"
                        minlength="10" ClientIDMode="Static" /><span class="red asterisk">*</span>
                </div>
            <%--    <div class='detailNameValue'>
                    <asp:RadioButton ID="rdobtnSSN" runat="server" Text="Social Security Number" GroupName="Identification"
                        ClientIDMode="Static" Checked="True" />
                    <asp:RadioButton ID="rdobtnGovermentID" runat="server" Text="Goverment ID#" GroupName="Identification" />
                </div>--%>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtIndentification" CssClass="width260 required ssn validateSingUp" 
                        onkeypress="return (event.keyCode!=13);" runat="server" ClientIDMode="Static"
                        MaxLength="30" /><span class="red asterisk">*</span>
                </div>
                <div class='detailNameValue'>
                    <asp:DropDownList ID="ddlSecretQuestion" CssClass="width275  dropdownPager floatLeft ddlValidation"
                        runat="server" ClientIDMode="Static">
                    </asp:DropDownList><span class="red asterisk">*</span>
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtAnswer" CssClass="width260 required validateSingUp" runat="server" MaxLength="100"
                        ClientIDMode="Static" onkeypress="return (event.keyCode!=13);" /><span class="red asterisk">*</span>
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtAddressLine1" CssClass="width260 required validateSingUp" 
                        onkeypress="return (event.keyCode!=13);" runat="server" MaxLength="100" ClientIDMode="Static" /><span class="red asterisk">*</span>
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtAddressLine2" CssClass="width260 validateSingUp"
                        onkeypress="return (event.keyCode!=13);" runat="server" MaxLength="100" ClientIDMode="Static" />
                </div>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtCity" runat="server" MaxLength="50" CssClass="required LettersWithSpace charSpaceOnly validateSingUp"
                         onkeypress="return (event.keyCode!=13);"
                        ClientIDMode="Static" /><span class="red asterisk">*</span>
                </div>
                <div class='detailNameValue'>
                    <span id="ddlStateOutersignup" class="displayInlineBlock width200">
                        <uc1:stateDropdown ID="stateDropDown" runat="server" ClientIDMode="Static" /><span class="red asterisk">*</span>
                    </span>
                </div>
            <%--      <div class='detailNameValue'>
                    <span class="displayInlineBlock width200">
                        <asp:DropDownList ID="ddlCounty" runat="server" ClientIDMode="Static" CssClass="ddlValidation floatLeft width160" Enabled="false" /><span class="red asterisk">*</span>
                    </span>
                </div>
              <div class='detailNameValue'>
                    <span class="displayInlineBlock width200">
                        <asp:DropDownList ID="ddlDistrict" runat="server" ClientIDMode="Static" CssClass="ddlValidation floatLeft width160" />
                    </span>
                </div>--%>
                <div class='detailNameValue'>
                    <asp:TextBox ID="txtZip" runat="server" MaxLength="5" minlength ="5" CssClass="required digitsOnly validateSingUp"
                        ClientIDMode="Static" /><span class="red asterisk">*</span>
                </div>
                <div class='detailNameValue'>
                    <asp:CheckBox ID="chkAgree" runat="server" CssClass="validateSingUp" onkeypress="return (event.keyCode!=13);" Text="I agree to the EknowID " ClientIDMode="Static" /><a
                        href="../Pages/TermsofUse.aspx" target="_blank" class="lnkColor">Terms & Conditions</a>
                </div>
            </div>
        </div>
        <div class="clearBoth">
        </div>
        <div>
            <input type="button" id="btnCreateAccount" class="Createbtn" onclick="ValidateSignUp();" />
        </div>
    </div>
    <img src="../Images/sign_up_bottom_white_bg_new.png" alt="" class="signUpBottomImg" />

</div>
