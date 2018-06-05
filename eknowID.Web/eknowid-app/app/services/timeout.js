eknowIdApp.service("timeOutService", function ($http, $cookieStore) {

    var isLive = {};

    isLive.cookiesIsExists = function () {
        if ($cookieStore.get("authenticationData") != null)
            return true
        else
            return false;
    }
    return isLive;
});