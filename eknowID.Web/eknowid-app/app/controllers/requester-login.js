'use strict'

eknowIdApp.controller("requesterLoginCtrl", function ($scope, $http, $location, $window, $cookieStore, requesterAuthenticationService, logoutService) {

    $scope.init = function () {
        if (logoutService.userLoggedInDetails != null) {
            logoutService.logoutUser();
            $location.path("/");
            return;
        };
        //if (logoutService.userLoggedInDetails != null) {
        //    logoutService.logoutUser();
        //    $location.path("/");
        //    return;
        //};
    };

    $scope.authenticateUser = function () {

        if (!$scope.loginForm.$valid) {
            $scope.submitted = true;
            return;
        }

        var successCallBackFuction = function () {
            $scope.errorMessage = "Invalid email or Password!";
            return;
        };

        var isValid = requesterAuthenticationService.authenticateUser($scope.email, $scope.password, successCallBackFuction);

        if (!isValid)
            return;

        if (!$cookieStore.get("packageDetails")) {
            $location.path("/");
            return;
        }

        $location.path("/requester-payment");
    };

    $scope.init();
});