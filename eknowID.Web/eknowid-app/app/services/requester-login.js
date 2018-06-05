
eknowIdApp.service("requesterAuthenticationService", function ($http, baseUrlConfig) {

    var authentication = {};

    authentication.authenticateUser = function (email, password, successCallBackFuction) {

        var data = JSON.stringify({
            email: email,
            password: password
        });

        $.ajax({
            url: baseUrlConfig.url + "api/RequesterAndCandidate/" + email + "/" + password,
            type: "POST",
            async: false,
            contentType: "application/x-www-form-urlencoded",
            success: function (response) {
                debugger;
                if (response == null) {
                    successCallBackFuction();

                    return false;
                }

                //save session data into eknowid side.
                $http.post('../eknowID.Web/Pages/loginajaxcalls.aspx/AuthenticateUser', data);

                return true;
            }
        });
    };

    return authentication;
});