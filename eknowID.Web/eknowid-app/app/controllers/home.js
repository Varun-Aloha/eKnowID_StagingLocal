'use strict'

eknowIdApp.controller("homeCtrl", function ($scope, $http, $location, $window, $cookieStore, modalService) {

    $scope.init = function () {
        $scope.setHeight();
        $scope.removeCookies();        
    };

    $scope.setHeight = function () {
        $('.topBar').css('height', $window.innerHeight);
    }

    $(window).resize(function () {
        $scope.setHeight();
    });

    $scope.runBackgroundCheck = function () {
        var modalOptions = {
            successCallback: $scope.redirectToPackage
        };

        var customModalOptions = {
            templateUrl: "/eknowID.Web/eknowid-app/app/partials/background-check-modal.html"
        };

        modalService.showModal(customModalOptions, modalOptions);
    }

    $scope.redirectToPackage = function () {
        $location.path("/package");
    };

    $scope.removeCookies = function () {
        $cookieStore.remove('packageDetails');
        $cookieStore.remove("alacartReportTotal");
        $cookieStore.remove("alacartReportList");
        $cookieStore.remove("OrderId");
    };

    $scope.init();
});