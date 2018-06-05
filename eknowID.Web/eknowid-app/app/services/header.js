eknowIdApp.service("logoutService", function ($http, $rootScope, $cookieStore, $sessionStorage, baseUrlConfig) {

    var requesterlogout = {};

    requesterlogout.validateUserSession = function () {
        
        requesterlogout.userLoggedInDetails = $cookieStore.get("requesterLoginStatus");

        $rootScope.loginText = "Login";

        if (requesterlogout.userLoggedInDetails == null || requesterlogout.userLoggedInDetails == undefined) {
            requesterlogout.logoutFromeknowId();  //remove session from eknowId
            return false;
        }

        $http.post('../eknowID.Web/Pages/loginajaxcalls.aspx/IsUserLoggedIntoEknowId', null).then(function (response) {
            if (!response.data.d) {
                $cookieStore.remove("requesterLoginStatus");
                requesterlogout.userLoggedInDetails = null;
                return false;
            }
            $rootScope.loginText = "Logout";
            return response.data.d;
        });
    };

    requesterlogout.logoutFromeknowId = function () {
        $http.post('../eknowID.Web/Pages/loginajaxcalls.aspx/UserIsLogout', null).then(function (response) {
            return false;
        });
    };

    requesterlogout.logoutUser = function () {

        if (requesterlogout.userLoggedInDetails != null) {

            $cookieStore.put("requesterLoginStatus", null);
            requesterlogout.validateUserSession();
        }
    };

    return requesterlogout;
});