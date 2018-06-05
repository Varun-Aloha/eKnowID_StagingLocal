<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactInfo.ascx.cs"
    Inherits="eknowID.Controls.ContactInfo" %>
<%@ Register Src="~/Controls/stateDropdown.ascx" TagName="stateDropdown" TagPrefix="uc1" %>
<%@ Register src="dob.ascx" tagname="dob" tagprefix="uc1" %>
<style type="text/css">
    .marginBottom20
    {
        margin-bottom: 20px;
    }
    .marginRight10
    {
        margin-right: 10px !important;
    }
</style>
<script type="text/javascript">
    $(document).ready(function () {
        $('#txtCntPassword').pwdMeter({
            minLength: 6,
            displayGeneratePassword: false,
            generatePassText: 'Password Generator',
            generatePassClass: 'GeneratePasswordLink',
            randomPassLength: 15
        });
    });


    $(document).ready(function () {

        $('#txtCntPassword').keypress(function () {
            $("#pwdMeter").css("display", "block");
        });
    });




    window.onload = function (e) {
        $("#pwdMeter").css("display", "none");
    };
    //Date picker
//    $(function () {
//        $("#txtCntDOB").datepicker({
//            dateFormat: 'mm/dd/yy',
//            maxDate: new Date('12/31/1991'),
//            yearRange: '1900:2000',
//            changeYear: true,
//            changeMonth: true
//        });

//        $("#btnCalDOB").click(function () {
//            $("#txtCntDOB").datepicker('show');
//        });
//    });

//    $(function () {
//        $("#txtSecurity1").blur(function () {


//            $("#hdnSSN").val($("#txtSecurity1").val().trim() + $("#txtSecurity2").val().trim() + $("#txtSecurity3").val().trim());
//            $("#hdnSSN").valid();



//        });
//        $("#txtSecurity2").blur(function () {


//            $("#hdnSSN").val($("#txtSecurity1").val().trim() + $("#txtSecurity2").val().trim() + $("#txtSecurity3").val().trim());
//            $("#hdnSSN").valid();


//        });
//        $("#txtSecurity3").blur(function () {


//            $("#hdnSSN").val($("#txtSecurity1").val().trim() + $("#txtSecurity2").val().trim() + $("#txtSecurity3").val().trim());
//            $("#hdnSSN").valid();


//        });

//    });

//    $(function () {
//        $("#txtConfirmSecurity1").blur(function () {


//            $("#hdnConfirmSSN").val($("#txtConfirmSecurity1").val().trim() + $("#txtConfirmSecurity2").val().trim() + $("#txtConfirmSecurity3").val().trim());
//            $("#hdnConfirmSSN").valid();


//        });
//        $("#txtConfirmSecurity2").blur(function () {


//            $("#hdnConfirmSSN").val($("#txtConfirmSecurity1").val().trim() + $("#txtConfirmSecurity2").val().trim() + $("#txtConfirmSecurity3").val().trim());
//            $("#hdnConfirmSSN").valid();


//        });
//        $("#txtConfirmSecurity3").blur(function () {


//            $("#hdnConfirmSSN").val($("#txtConfirmSecurity1").val().trim() + $("#txtConfirmSecurity2").val().trim() + $("#txtConfirmSecurity3").val().trim());
//            $("#hdnConfirmSSN").valid();


//        });
//    });

//    $(function () {
//        $("#txtSecurity1").keyup(function (e) {
//            if (e.which == 9) {
//                return true;
//            }
//            if ($("#txtSecurity1").val().length == 3) {
//                $("#txtSecurity2").focus();
//            }
//        });

//        $("#txtSecurity2").keyup(function (e) {
//            if (e.which == 9) {
//                return true;
//            }
//            if ($("#txtSecurity2").val().length == 2) {
//                $("#txtSecurity3").focus();
//            }
//        });
//    });
//    $(function () {
//        $("#txtConfirmSecurity1").keyup(function (e) {
//            if (e.which == 9) {
//                return true;
//            }
//            if ($("#txtConfirmSecurity1").val().length == 3) {
//                $("#txtConfirmSecurity2").focus();
//            }
//        });

//        $("#txtConfirmSecurity2").keyup(function (e) {
//            if (e.which == 9) {
//                return true;
//            }
//            if ($("#txtConfirmSecurity2").val().length == 2) {
//                $("#txtConfirmSecurity3").focus();
//            }
//        });
//    });
    
</script>
<div class="width100per border1Solid padding21" style="height: 555px;">
    <h3 class="margin_0px">
        Contact Information</h3>
    <div class="main" id="ContactInfoContainer">
        <div class="PersonalDetails">
            <div class="paddingTop5px">
                <div class="floatLeft width200 marginTop5">
                    First Name</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtCntFname" runat="server" CssClass="width200 required charOnly validateTab"
                        MaxLength="20" ClientIDMode="Static" /><span class="red asterisk">*</span></div>
            </div>
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft  width200 marginTop5">
                    Middle Name</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtCntMname" runat="server" CssClass="width200 charOnly validateTab"
                        MaxLength="20" ClientIDMode="Static" /></div>
            </div>
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft  width200 marginTop5">
                    Last Name</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtCntLname" runat="server" CssClass="width200 required charOnly validateTab"
                        MaxLength="20" ClientIDMode="Static" /><span class="red asterisk">*</span></div>
            </div>
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft  width200 marginTop5">
                    Email Address</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtCntEmail" runat="server" CssClass="width200 required email validateTab"
                        MaxLength="50" ClientIDMode="Static" ReadOnly="true" /><span class="red asterisk">*</span></div>
            </div>
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft  width200 marginTop5">
                    Mobile</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtCntMobile" runat="server" CssClass="width200 digitsOnly validateTab"
                        MaxLength="10" minlength="10" ClientIDMode="Static" /></div>
            </div>
           <div runat="server" class="paddingTop5px clearBoth" id="ssnDiv" style="display:none;">
                <div class="floatLeft  width200 marginTop5">
                    Social Security Number
                    <div style="margin-top: 15px;">
                        Confirm Social Security Number</div>
                </div>
                <div class="floatLeft width170">
                    <asp:TextBox ID="txtSecurity11" runat="server" MaxLength="3" Width="30" CssClass="marginRight10 digitsOnly"
                        TextMode="Password" ClientIDMode="Static" /><asp:TextBox ID="txtSecurity12" runat="server"
                            MaxLength="2" Width="20" CssClass="marginRight10 digitsOnly" TextMode="Password"
                            ClientIDMode="Static" /><asp:TextBox ID="txtSecurity13" runat="server" MaxLength="4"
                                Width="40" CssClass="digitsOnly" ClientIDMode="Static" /><%--<span class="red asterisk">*</span>--%>
                    
                    <input type="hidden" id="hdnSSN1" runat="server" clientidmode="Static" minlength="0" />
                    <br />
                    <div style="margin-top: 5px;">
                        <asp:TextBox ID="txtConfirmSecurity11" runat="server" MaxLength="3" Width="30" CssClass="marginRight10 digitsOnly"
                            TextMode="Password" ClientIDMode="Static" /><asp:TextBox ID="txtConfirmSecurity12"
                                runat="server" MaxLength="2" Width="20" CssClass="marginRight10 digitsOnly" TextMode="Password"
                                ClientIDMode="Static" /><asp:TextBox ID="txtConfirmSecurity13" runat="server" MaxLength="4"
                                    Width="40" CssClass="digitsOnly" ClientIDMode="Static" /><%--<span class="red asterisk">*</span>       --%>               
                        <input type="hidden" id="hdnConfirmSSN1" runat="server" clientidmode="Static" minlength="0"/>
                    </div>
                </div>
                <div class="floatLeft">
                    <div style="background-image: url(../Images/lock_icon.png); background-repeat: no-repeat;
                        width: 15px; height: 20px; margin-left: 10px;" class="floatLeft">
                    </div>
                    <div class="floatLeft alignJustify" style="margin-left: 10px; width: 125px;">
                        <%--<p class=" margin_0px">--%>
                        We use the highest level of encryption to secure your personal information.<%--</p>--%>
                    </div>
                </div>
            </div>
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft  width200 marginTop5">
                    Gender</div>
                <div class="floatLeft">
                    <asp:RadioButton ID="rdbCntMale" runat="server" Text="Male" Checked="true" GroupName="rdbGrpGender"
                        ClientIDMode="Static" /><span class="displayInlineBlock" style="width: 15px;"></span>
                    <asp:RadioButton ID="rdbCntFemale" runat="server" Text="Female" GroupName="rdbGrpGender" /></div>
            </div>
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft  width200 marginTop5">
                    Date of Birth</div>
                <div class="floatLeft" id ="dob">
                 <uc1:dob ID="dob1" runat="server" />
                    <%--<asp:TextBox ID="txtCntDOB" runat="server" ClientIDMode="Static" MaxLength="10" CssClass="width80 required dateRange DateFormat" />--%><span
                        class="red asterisk">*</span></div>
                <%--<div class="floatLeft marginLeft5">
                    <img src="../Images/cal_icon.png" id="btnCalDOB" alt="" /></div>--%>
            </div>
        </div>
        <div class="clearBoth" style="height: 40px">
        </div>
        <div class="EmailConfirmation clearBoth">
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft  width200 marginTop5">
                    Password </div>
                <div class="floatLeft password-container">
                    <asp:TextBox ID="txtCntPassword" runat="server" CssClass="width200 required validateTab"
                        TextMode="Password" ClientIDMode="Static" minlength="6" oncopy="return false;"
                        onpaste="return false;" oncut="return false;" MaxLength="15" /><span class="red asterisk">*</span></div>
            </div>
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft  width200 marginTop5">
                    Confirm Password</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtCntConfirmPassword" runat="server" CssClass="width200 required validateTab"
                        equalTo="#txtCntPassword" TextMode="Password" ClientIDMode="Static" minlength="6"
                        oncopy="return false;" onpaste="return false;" oncut="return false;" MaxLength="15" /><span
                            class="red asterisk">*</span></div>
            </div>
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft" style="margin-left: 21px;">
                    <div class="strength-indicator" style="margin-left: 34px; height: 30px;">
                        <div id="pwdMeter" class="neutral" style="display: none;">
                            Very Weak</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="ContactDetails clearBoth">
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft width200 marginTop5">
                    Address Line 1</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtCntAddLine1" runat="server" CssClass="width200 required validateTab"
                        MaxLength="100" ClientIDMode="Static" /><span class="red asterisk">*</span></div>
            </div>
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft clearBoth width200 marginTop5">
                    Address Line 2</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtCntAddLine2" runat="server" CssClass="width200 validateTab" MaxLength="100"
                        ClientIDMode="Static" /></div>
            </div>
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft clearBoth width200 marginTop5">
                    City</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtCntCity" runat="server" CssClass="width145 required charSpaceOnly validateTab"
                        MaxLength="50" ClientIDMode="Static" /><span class="red asterisk">*</span></div>
            </div>
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft clearBoth width200 marginTop5">
                    State/Province</div>
                <div class="floatLeft width200" id="ddlStateContactInfo">
                    <uc1:stateDropdown ID="ddlStateCnt" ClientIDMode="Static" runat="server" />
                    <span class="red asterisk">*</span>
                </div>
            </div>
            <div class="paddingTop5px clearBoth">
                <div class="floatLeft clearBoth width200 marginTop5">
                    Zip</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtCntZip" runat="server" CssClass="width100 required digitsOnly validateTab"
                        MaxLength="5" minlength="5" ClientIDMode="Static" /><span class="red asterisk">*</span></div>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="hdnAccountType" ClientIDMode="Static" Value="0" />
    </div>
</div>
