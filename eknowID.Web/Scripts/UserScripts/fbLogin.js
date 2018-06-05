var profile = "";
var Mode = "";
var ProviderName = "";
var allowed = true; //do not delete this variable

//When a provider is selected:
function SocailSiteLogin(providername, mode) {   
   ProviderName = providername;
   Mode = mode;
   OpenProcessingImage();
    var hWin = window.open("ProcessPopup.aspx?provider=" + providername, "socialauthlogin", "height=500,width=400,left=750,screenX=750,top=100,screenY=100, scrollbars=yes", true);
    var timerID = setInterval(function () {

        isPopupClosed = (hWin.closed);
       
        if (isPopupClosed) {
            clearInterval(timerID)
           
            CloseProcessingImage();
            //make AJAX call to check if user logged in or not. If he did, get friends list and display!           
            PageMethods.IsUserLoggedIn(UserLoggedInResponse);
          
        }
    }, 100);
    return false;
}



//SocialAuthUser.IsLoggedIn(provider type) response
function UserLoggedInResponse(data) {
    if (data == "True") {
        PageMethods.Getprofile(GetResponse)
    }
    else {
        //location.reload();
    }
}



//Profile received from server
function GetResponse(data) {
    if (data == "error") {
        return;
    }
    profile = data;
    SocialSiteLogin();    
}

function SocialSiteLogin() {
    if (Mode == "SingInUp") {
        if (ProviderName == "LINKEDIN") {
            var accountRefId = 3;
            var controlData = "FirstName:'" + profile.FirstName + "'";
            controlData = controlData + ",MiddleName:''";
            controlData = controlData + ",LastName:'" + profile.LastName + "'";
            controlData = controlData + ",EmailAddress:'" + profile.Email + "'";
            controlData = controlData + ",accountRefId:" + accountRefId;

            $.ajax({
                cache: false,
                type: "POST",
                url: "loginajaxcalls.aspx/SignupUserWithLinkedIn",
                contentType: "application/json; charset=utf-8",
                data: "{" + controlData + "}",
                dataType: "json",
                success: function (result) {
                    if (result.d.Success != false) {
                        if ($.cookie('redirectToOrderDetail') == "true") {
                            window.location.href = "../Pages/OrderDetail.aspx";
                        }
                        else {
                            location.reload(true);
                        }
                    }
                    else {
                     OpenDialog("User already present with this mailID", function () { });
                    }
                }
            });
        }
    }
}