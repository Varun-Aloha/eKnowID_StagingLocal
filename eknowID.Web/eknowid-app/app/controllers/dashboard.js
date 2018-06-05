'use strict'

eknowIdApp.controller("dashboardCtrl", function ($scope, $cookieStore, $http, dashboardService, modalService) {

    $scope.init = function () {

        $scope.tazWorkStatus = ['In Progress', 'New', 'Pending', 'Failed', 'Completed', 'Message', 'Canceled', 'Applicant Pending', 'Applicant Process', 'Error', 'Ready', 'App Pending'];

        $scope.UserData = $cookieStore.get("authenticationData");
        $scope.itemsPerPage = 5;

        dashboardService.getOrderList($scope.UserData.UserId, $scope.itemsPerPage, 1).then(function (response) {

            $scope.orderList = response.data;
            $scope.totalItem = $scope.orderList.TotalCount;
        });
    };

    $scope.getData = function (newPageNumber) {
        dashboardService.getOrderList($scope.UserData.UserId, $scope.itemsPerPage, newPageNumber).then(function (response) {
            $scope.orderList = response.data;
        });
    };

    //$scope.search = function () {
    //    if ($scope.orderList.Orders.OrderState.indexOf($scope.tazStatusFilter) != -1)
    //        return true;
    //};

    $scope.displayReport = function (order) {

        if (order.OrderState == 10) {
            //redirect to report view and display applicant report.
        }
    };

    $scope.init();
});