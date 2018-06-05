var profile = "";

//When a provider is selected:
function login(providername) {

    var hWin = window.open("ProcessPopup.aspx?provider=" + providername, "socialauthlogin", "height=500,width=400,left=750,screenX=750,top=100,screenY=100, scrollbars=yes", true);
    var timerID = setInterval(function () {
        isPopupClosed = (hWin.closed);
        OpenProcessingImage();
        if (isPopupClosed) {
            clearInterval(timerID)
            //make AJAX call to check if user logged in or not. If he did, get friends list and display!           
            PageMethods.IsUserLoggedIn(isUserLoggedInResponse);

        }
    }, 100);
    return false;
}



//SocialAuthUser.IsLoggedIn(provider type) response
function isUserLoggedInResponse(data) {
    if (data == "True") {
        PageMethods.Getprofile(GetFriendsResponse)
    }
    else {
        location.reload();
    }
}



//Profile received from server
function GetFriendsResponse(data) {
    if (data == "error") {
        return;
    }
    profile = data;
    if ($.cookie('showFreeUploadResumeDialog') == "true") {
        window.location.href = "../Pages/RC_AnalysisSummary.aspx";
    }
    else {
        $.cookie('showUploadResumeDialog', 'false');
        window.top.location.reload(true);
    }
}