

//declare global vairable
var isAdmin = null;

window.addEventListener('resize', changeHeight);

function changeHeight()
{
    if($(".tab-content").length > 0)
    {
        $(".tab-content").css({ "height": "" });        
        var newHeight = $(".tab-content").get(0).clientHeight + "px";
        $(".tab-content").css({ "height": newHeight });
    }
}

$(function () {    

    var currentUrlpath = window.location.pathname.split("/");
    var currentPage = currentUrlpath[currentUrlpath.length - 1];    
    if (currentPage.toLowerCase() !== "index.aspx") {
        $("body").find("footer").hide();
    }
    else
    {
        $("body").find("footer").show();
    }
    if (currentPage === "ApplicantPackages.aspx") {
        $("#packageSelection").addClass("background-color-red");
        $("#lblPackageSelect").addClass("progressbar-current-page");
    }
    else if (currentPage === "ApplicantAlacarte.aspx") {

        $("#reportSelection").addClass("background-color-red");
        $("#packageSelection").addClass("background-color-red");
        $(".packageLine").addClass("progressbar-red-line");
        $("#upgradePackage").addClass("progressbar-current-page");

    }
    else if (currentPage === "RequesterPayment.aspx") {
        $("#reportSelection").addClass("background-color-red");
        $("#packageSelection").addClass("background-color-red");
        $("#paymentSelection").addClass("background-color-red");
        $("#makePayment").addClass("progressbar-current-page");
        $(".packageLine").addClass("progressbar-red-line");
        $(".upgradeLine").addClass("progressbar-red-line");

    }

    //prevent enter character in textbox
    $('.digitsOnly').bind('input', function () {
        var totalCharacterCount = $(this).val();
        var regExp = /^[a-zA-Z]*$/;

        if (isNaN(totalCharacterCount)) {
            $(this).val('');
        }
    });

    $('.charactersOnly').bind('input', function () {
        if ($(this).val().match(/[^a-zA-Z]/g)) {
            this.value = this.value.replace(/[^a-zA-Z]/g, '');
        }
    });

    $("#txtPassword").keyup(function (e) {

        $("#errorPassword").html("");
        $("#lblAuthenticationError").html("");

        if (e.which === 13) validateLoginModal();

        return false;
    });

    $("#txtEmail").keyup(function (e) {
        $("#errorEmail").html("");

        if (e.which === 13) validateLoginModal();
    });

    //Use for forgott password
    $("#txtForgottPwd").keyup(function (e) {
        $("#errorEmail").html("");

        if (e.which === 13) {
            validateForgottPassword();
        }
    });

    //Clear signup error message on keypress
    $("#txtRequestorFirstName").keyup(function (e) {
        $("#errortxtRequestorFirstName").html("");
    });

    $("#txtRequestorLastName").keyup(function (e) {
        $("#errortxtRequestorLastName").html("");
    });

    $("#txtRequestorEmail").keyup(function (e) {
        $("#errortxtRequestorEmail").html("");
    });

    $("#txtRequestorPassword").popover(
	    {
	        html: true,
	        placement: 'right',
	        title: 'Password must meet the following minimum standards(any 4)',
	        trigger: 'focus',
	        content: $("#divPwdPolicies").html()
	    });

    $("#txtRequestorPassword").keyup(function (e) {
        $("#errortxtRequestorPassword").html("");

        $("#chkTermsOfUse").change(function (e) {
            if ($(this).prop("checked") === true) {
                $("#errortxtRequestorTermsOfUser").html("");
            }
        });

        var tmpCount = 0;
        var strPassword = $("#txtRequestorPassword").val();
        var matchLowerCaseChar = /(?=.*[a-z])/;
        var matchUpperCaseChar = /(?=.*[A-Z])/;
        var matchNumber = /(?=.*[0-9])/;
        var matchSpecialChar = /(?=.*[!@#$%^&*])/;

        if (strPassword.match(matchLowerCaseChar)) {
            $("#pwdLowerCaseChar").css({ "background-image": "url(../Images/green_tick.png)", "color": "green" });
            tmpCount++;
        }
        else {
            $("#pwdLowerCaseChar").css({ "background-image": "url(../Images/CorssSign.png)", "color": "red" });
        }
        if (strPassword.match(matchUpperCaseChar)) {
            $("#pwdUpperCaseChar").css({ "background-image": "url(../Images/green_tick.png)", "color": "green" });
            tmpCount++;
        }
        else {
            $("#pwdUpperCaseChar").css({ "background-image": "url(../Images/CorssSign.png)", "color": "red" });
        }
        if (strPassword.match(matchNumber)) {
            $("#pwdNumberChar").css({ "background-image": "url(../Images/green_tick.png)", "color": "green" });
            tmpCount++;
        }
        else {
            $("#pwdNumberChar").css({ "background-image": "url(../Images/CorssSign.png)", "color": "red" });
        }
        if (strPassword.match(matchSpecialChar)) {
            $("#pwdSpecialChar").css({ "background-image": "url(../Images/green_tick.png)", "color": "green" });
            tmpCount++;
        }
        else {
            $("#pwdSpecialChar").css({ "background-image": "url(../Images/CorssSign.png)", "color": "red" });
        }
        if (strPassword.length >= 6) {
            $("#pwdLength").css({ "background-image": "url(../Images/green_tick.png)", "color": "green" });
            tmpCount++;
        }
        else {
            $("#pwdLength").css({ "background-image": "url(../Images/CorssSign.png)", "color": "red" });
        }
        if (tmpCount >= 4) {
            $("#pwdVerificationTitle").css({ "color": "green" });
        }
        else {
            $("#pwdVerificationTitle").css({ "color": "red" });
        }
        if (e.which === 13) validateSignup();
    });

    $("#txtRequestorPassword").focus(function (e) {
        $(this).keyup();
    });

});

function openCompnayProfileModal() {
    $("#ModalCompnayProfile").modal('show');
    return false;
}

function PackageDescriptionTextWrap(Jthis) {
    $(Jthis).closest(".row").find("p").toggleClass("less");
    if ($(Jthis).html() == "Read more...") {
        $(Jthis).html("Read less...");
    }
    else {
        $(Jthis).html("Read more...");
    }
}

function openSignupModal() {  
    grecaptcha.reset();
    $("#chkTermsOfUse").prop("checked", false);
    $("input[type=text] , input[type='password'] , textarea").val("");
    var currentUrlpath = window.location.pathname.split("/");
    var currentPage = currentUrlpath[currentUrlpath.length - 1];
    $("#divPwdPolicies").css({ "color": "red" });
    $("#txtRequestorPassword").keyup();
    $("#headerTitle").html("Sign up now");
    $("#headerDescription").html("Fill in the form below to get instant access.");
    $("#btnRequestorSignup").val("Sign up");
    isAdmin = 2; //Admin

    if (currentPage === "AdminDashboard.aspx") {
        $("#headerTitle").html("Add New User");
        $("#headerDescription").html("");
        $("#btnRequestorSignup").val("Add New User");
        isAdmin = 3; // for normal user
    }

    //Hide modal window
    $("#divloginModal").modal('hide');

    $(".Error").html("");

    //clear field when requestor is open modal dialog    
    

    $("body").css("overflow", "hidden");
    $('#ModalSingup').modal('show');
}

function openForgottPasswordModal() {

    $('#divloginModal').modal('hide');
    $("body").css("overflow", "hidden");

    $(".Error").html("");

    $("#forgottPasswordModal").modal("show");
}

//open login modal popup window
function openLoginModal() {

    //reset control's value for re-open the loginDial
    $("input[type=text] , input[type='password'] , textarea").val("");

    //reset error message from login modal popup
    $(".Error").html("");
    $('#ModalSingup').modal('hide');
    $('#divloginModal').modal('show');
}

//hide login modal window
//hideLoginModal
function hideModalPopupWindow(popupId) {

    $("body").css("overflow", "auto");
    $('#' + popupId).modal('hide');
}

function showModalPopupWindow(popupId) {
    $('#' + popupId).modal('show');
}

function validateLoginModal() {

    //check for empty field
    if ($("#txtEmail").val() === "") {
        $("#errorEmail").html("Please enter your email.");
        return false;
    }

    //check for email validation
    var emailRegx = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if ($("#txtEmail").val() !== null) {
        if (!(emailRegx.test($("#txtEmail").val()))) {
            $("#errorEmail").html("Please enter a valid email address.");
            return false;
        }
    }

    //Password
    if ($("#txtPassword").val() === "") {
        $("#errorPassword").html("Please enter your password.");
        return false;
    }

    //if ($("#txtPassword").val().length <= 6) {
    //    $("#errorPassword").html("Password must be greater than 6 and less than 15 characters.");

    //    return false;
    //}

    validateAuthntication();
}

//check validate user loginCredentials
function validateAuthntication() {

    $(document).keydown(function (e) {
        if (e.keyCode === 27) return false;
    });

    var currentUrlpath = window.location.pathname.split("/");
    var currentPage = currentUrlpath[currentUrlpath.length - 1];

    $("#overlay").show();

    var loginCredentials = {
        email: $("#txtEmail").val(),
        password: $("#txtPassword").val()
    };

    $.ajax({
        type: "POST",
        url: "loginajaxcalls.aspx/AuthenticateUser",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(loginCredentials),
        dataType: "json",
        async: true,
        success: function (result) {
            if (result.d.Success) {                
                if (currentPage === "ApplicantAlacarte.aspx") {
                    if ($('[data-report-name="Credit Report"]:first').is(':checked')) {
                        $('#divloginModal').modal('hide');
                        $("#overlay").hide();
                        location.reload(true);
                        //return;
                    }
                    else {
                        location.href = "../pages/RequesterPayment.aspx";
                    }
                }
                else {
                    location.href = "../pages/Index.aspx";
                }
            }
            else {
                $("#overlay").hide();
                $("#txtPassword").val("");
                $("#lblAuthenticationError").html(result.d.Message);
                if(result.d.TagData === "Account Disabled")
                {
                    hideModalPopupWindow('divloginModal');
                    $("#errorMessage").fadeIn();
                    $("#errorMessage").animate({ top: '90px' }, "slow");

                    $("#ErrorDescription").text(result.d.Message);
                    //$("#linkForgotPassword").hide();
                    //$("#linkSignUp").hide();
                }
            }
        }
    });
}


//Forgott password funcatiolity 
function validateForgottPassword() {

    if ($("#txtForgottPwd").val() === "") {
        $("#lblForgottPwdError").html("Please enter email address.");
        return false;
    }

    //check for email validation
    var emailRegx = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (!(emailRegx.test($("#txtForgottPwd").val()))) {
        $("#lblForgottPwdError").html("Please enter a valid email address.");
        $("#lblForgottPwdError").show();
        return false;
    }

    var email = {
        email: $("#txtForgottPwd").val()
    };
    $("#overlay").show(); // show loader image

    $.ajax({
        type: "POST",
        url: "loginajaxcalls.aspx/ForgotPassword",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(email),
        dataType: "json",
        success: function (result) {

            $("#overlay").hide(); // hide loader

            if (!result.d.Success) {
                $("#lblForgottPwdError").html(result.d.ErrorMsg);
                $("#lblForgottPwdError").show();
            }
            else {
                $("#lblForgottPwdError").html("We have successfully sent mail to your registered email address.");
                $("#lblForgottPwdError").css("color", "#5cb85c");
                $("#lblForgottPwdError").show();

                setTimeout(function () {
                    hideModalPopupWindow("forgottPasswordModal"); // Pass bootstrap modal ID as parameter.
                }, 4000);
            }
        }
    });
}

function validateSignup() {    
    $("#errortxtRequestorEmail").html("");    

    if ($("#txtRequestorFirstName").val() === "") {
        $("#errortxtRequestorFirstName").html("Please enter first name");
        $("#txtRequestorFirstName").focus();
        return false;
    }

    if ($("#txtRequestorLastName").val() === "") {
        $("#errortxtRequestorLastName").html("Please enter last name");
        $("#txtRequestorLastName").focus();
        return false;
    }

    if ($("#txtRequestorEmail").val() === "") {
        $("#errortxtRequestorEmail").html("Please enter email address");
        $("#txtRequestorEmail").focus();
        return false;
    }

    var emailRegx = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (!(emailRegx.test($("#txtRequestorEmail").val()))) {
        $("#errortxtRequestorEmail").html("Please enter a valid email address.");
        $("#txtRequestorEmail").focus();
        return false;
    }

    if ($("#txtRequestorPassword").val() === "") {
        $("#errortxtRequestorPassword").html("Please enter password");
        $("#txtRequestorPassword").focus();
        return false;
    } else {
        var count = 0;
        if ($("#txtRequestorPassword").val().length >= 6)
            count++;

        var strPassword = $("#txtRequestorPassword").val();
        var matchExpressions = ['(?=.*[0-9])', '(?=.*[!@#$%^&*])', '(?=.*[A-Z])', '(?=.*[a-z])'];

        for (var i = 0; i < matchExpressions.length; i++) {
            if (strPassword.match(matchExpressions[i]))
                count++;
        }
        if (count <= 3) {
            $("#errortxtRequestorPassword").html("");
        $("#txtRequestorPassword").focus();
        return false;
    }
    }

    if ($("#chkTermsOfUse").prop("checked") === false)
    {
        $("#errortxtRequestorTermsOfUser").html("Please agree to the Terms of Use & Privacy Policy.");
        $("#chkTermsOfUse").focus();
        return false;
    }

    if (grecaptcha.getResponse() === "") {
        //e.preventDefault();
        $("#errortxtRecaptchaVerification").html("Please verfiy your not a robot, validate recaptcha.");
        $(grecaptcha).focus();
        return false;
    }
    //else
    //{
    //    $("#errortxtRecaptchaVerification").html("");
    //}

    var emailId = { emailID: $("#txtRequestorEmail").val() }

    $("#overlay").show();

    $.ajax({
        type: "POST",
        url: "loginajaxcalls.aspx/CheckIfExist",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(emailId),
        dataType: "json",
        async: false,
        success: function (result) {

            $("#overlay").hide();

            if (result.d.Success) {
                $("#errortxtRequestorEmail").html("Email address already exists");
                return false;
            }
            else {
                SignupNow();
            }
        }
    });
}

function SignupNow() {
    
    var currentUrlpath = window.location.pathname.split("/");
    var currentPage = currentUrlpath[currentUrlpath.length - 1];

    $("#overlay").show();

    var user = {
        FirstName: $("#txtRequestorFirstName").val(),
        MiddleName: "",
        LastName: $("#txtRequestorLastName").val(),
        EmailAddress: $("#txtRequestorEmail").val(),
        Password: $("#txtRequestorPassword").val(),
        UserType: isAdmin
    }

    $.ajax({
        type: "POST",
        url: "loginajaxcalls.aspx/SignupUser",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(user),
        dataType: "json",
        async: false,
        success: function (result) {

            $("#overlay").hide();
            if (!result.d.Success) {
                $("#signupError").html(result.d.Message);
                $("#signupError").show();
                hideModalPopupWindow('ModalSingup');
                $("#errorMessage").fadeIn();
                $("#errorMessage").animate({ top: '90px' }, "slow");
                $("#ErrorDescription").text(result.d.Message);
                return;
            }
            else if (currentPage === "ApplicantAlacarte.aspx") {
                location.href = "../pages/RequesterPayment.aspx";
                return;
            }
            else if (currentPage === "AdminDashboard.aspx") {
                location.href = "../pages/AdminDashboard.aspx";
                return;
            }
            else
                location.reload(true);
        }
    });
}


function validateCompany() {
    
    if ($("#txtCompanyName").val() === "") {
        $("#errortxtCompanyName").html("Please enter company name");
        return false;
    }

    if ($("#txtJobTitle").val() === "") {
        $("#errortxtJobTitle").html("Please enter job title");
        return false;
    }

    if ($("#txtPhoneNo").val() === "") {
        $("#errortxtPhoneNo").html("Please enter phone number");
        return false;
    }

    var phoneRegx = /^([\(]{1}[0-9]{3}[\)]{1}[\.| |\-]{0,1}|^[0-9]{3}[\.|\-| ]?)?[0-9]{3}(\.|\-| )?[0-9]{4}$/;

    if (!(phoneRegx.test($("#txtPhoneNo").val()))) {
        $("#errortxtPhoneNo").html("Please enter a valid phone number");
        $("#txtRequestorEmail").focus();
        return false;
    }

    //if ($("#txtTaxId").val() === "") {
    //    $("#errortxtTaxId").html("Please enter tax id number");
    //    return false;
    //}

    var taxIdRegx = /^[0-9]{9}$/;

    if ($("#txtTaxId").val() !== "" && !(taxIdRegx.test($("#txtTaxId").val()))) {
        $("#errortxtTaxId").html("Please enter a valid tax id number");
        $("#txtRequestorEmail").focus();
        return false;
    }

    $("#overlay").show();



    var companyDetail = {
        Name: $("#txtCompanyName").val(),
        JobTitle: $("#txtJobTitle").val(),
        CompanyPhone: $("#txtPhoneNo").val(),
        CompanyTaxId: $("#txtTaxId").val(),
        Description: $("#txtDescription").val(),
    }

    var companyProfile =
    {
        "company": companyDetail
    };

    var currentUrlpath = window.location.pathname.split("/");
    var currentPage = currentUrlpath[currentUrlpath.length - 1];

    $.ajax({
        type: "POST",
        url: "CompnayProfile.aspx/CreateCompnayProfile",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(companyProfile),
        dataType: "json",
        async: false,
        success: function (result) {
            $("#overlay").hide();

            if (!result.d) {
                $("#compnayMsg").html("Some error occurred while creating company profile, Please try again.");
                $("#compnayMsg").show();
                return false;
            }

            $("#compnayMsg").html("Company profile created successFully!");
            $("#compnayMsg").show();
            setTimeout(function () { $("#ModalCompnayProfile").modal("hide"); }, 3000);

            if (currentPage === "ApplicantAlacarte.aspx") {
                if ($('[data-report-name="Credit Report"]:first').is(':checked')) {
                    $('[data-report-name="Credit Report"]:first').click();
                    setTimeout(function () { $('[data-report-name="Credit Report"]:first').click(); }, 3000);
                }
            }

            return true;
        }
    });
}

function verifyCreditReportCredentialingAuditStatusForCompany()
{
    
}

//Clear signup error message on keypress
$(function () {
    $("#txtCompanyName").keyup(function (e) {
        $("#errortxtCompanyName").html("");
    });

    $("#txtJobTitle").keyup(function (e) {
        $("#errortxtJobTitle").html("");
    });

    $("#txtPhoneNo").keyup(function (e) {
        $("#errortxtPhoneNo").html("");
    });

    $("#txtTaxId").keyup(function (e) {
        $("#errortxtTaxId").html("");
    });
});

//to prevent referesh when user press enter key to login modal popup
$(function () {

    $('#newMstrPage').find("#txtEmail").keypress(function (e) {
        if (e.which === 13) return false; // Enter key = keycode 13
    });

    $('#newMstrPage').find("#txtPassword").keypress(function (e) {
        if (e.which === 13) return false; // Enter key = keycode 13
    });

    $('#newMstrPage').find("#txtForgottPwd").keypress(function (e) {
        if (e.which === 13) return false; // Enter key = keycode 13        
    });

    $('#newMstrPage').find("#txtRequestorPassword").keypress(function (e) {
        if (e.which === 13) return false; // Enter key = keycode 13        
    });
});


//Facebook count function display at bootom

function addCommas(count) {
    var amount = new String(count);
    amount = amount.split("").reverse();

    var output = "";
    for (var i = 0; i <= amount.length - 1; i++) {
        output = amount[i] + output;
        if ((i + 1) % 3 === 0 && (amount.length - 1) !== i) output = ',' + output;
    }
    return output;
}

//clear historys
function ClearHistory(URL) {
    var backlen = history.length;
    history.go(-backlen);
    window.location.href = URL;
}