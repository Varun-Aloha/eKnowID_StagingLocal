'use strict'
eknowIdApp.controller("alacartCtrl", function ($scope, $http, $cookieStore, $location, alacartService, logoutService) {

    $scope.init = function () {

        $scope.packageItem = $cookieStore.get("packageDetails");
        if (!$scope.packageItem) {
            $location.path("/Error");
        }

        $scope.listOfReports = [];
        $scope.totalPrice = 0;

        //get report list from database.                
        alacartService.getReportList().then(function (response) {
            $scope.reportLists = response.data;
        });
    };

    $scope.selectReport = function (report) {
        if (report.IsSelected) {
            $scope.listOfReports.push(report);
            $scope.totalPrice += parseFloat(report.Price);
        }
        else {
            var index = $scope.listOfReports.indexOf(report);
            $scope.listOfReports.splice(index, 1);
            $scope.totalPrice -= parseFloat(report.Price);
        }
    };

    $scope.redirectToPayment = function () {

        $cookieStore.put("alacartReportTotal", $scope.totalPrice);
        $cookieStore.put("alacartReportList", $scope.listOfReports);
        
        if (!logoutService.validateUserSession()) {            
            $location.path("/login");
        }

        $location.path("/requester-payment");

    };
    $scope.init();
});