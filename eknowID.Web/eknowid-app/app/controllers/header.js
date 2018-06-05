'use strict'

eknowIdApp.controller("headerCtrl", function ($scope, $http, $location, $cookieStore, logoutService) {

    $scope.init = function () {

        logoutService.validateUserSession();

        //get eknowid facebook counter and display it at footer page
        $http.get('http://api.facebook.com/restserver.php?method=links.getStats&urls=www.facebook.com/eknowid', null).then(function (response) {
            var xmlResponse = $.parseXML(response.data);
            var $xml = $(xmlResponse);
            var $totalCount = $xml.find("total_count");

            $scope.totalCount = $totalCount.text();
        });
    };

    $scope.redirectToLogin = function () {        
        $location.path("/login");
    };

    $scope.init();
});