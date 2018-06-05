'use strict'

eknowIdApp.controller("packageCtrl", function ($scope, $location, $cookieStore, packageService) {

    $scope.init = function () {

        $scope.loading = true;

        $scope.removeCookies();

        packageService.getPackageList().then(function (response) {
            $scope.packages = response.data;
            $scope.loading = false;
        });
    };

    $scope.selectedPackage = function (packageItem) {
        $cookieStore.put('packageDetails', packageItem);
        $location.path("/alaCart");
    };

    $scope.removeCookies = function () {
        $cookieStore.remove("alacartReportTotal");
        $cookieStore.remove("alacartReportList");
    };

    $scope.init();
});