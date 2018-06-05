'use strict'

eknowIdApp.controller("candidateCtrl", function ($scope, $cookieStore, $location, $rootScope, CandidateService, logoutService) {

    $scope.init = function () {
        $scope.orderId = $cookieStore.get("OrderId");
        if ($scope.orderId == null || $scope.orderId === undefined)
            $location.path("/error");
    };

    $rootScope.$on("$locationChangeStart", function (event, next, current) {
        var nextPath = next.split('#')[1]
        var currentPath = current.split('#')[1];

        if (nextPath != "/Dashboard" && currentPath == "/Candidate")
            event.preventDefault();
    });

    //Get candidate data from candidate model   
    $scope.saveCandidateDetail = function () {

        if (!$scope.candidateForm.$valid) {
            $scope.submitted = true;
            return;
        }
        
        var Users = logoutService.userLoggedInDetails;

        $scope.candidate = {
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            Email: $scope.EmailAddress,
            Description: $scope.CandidateDescription,
            UserId: Users.UserId,
            orderId: $scope.orderId
        };

        //This service is used to store candidate information into candidate table.
        CandidateService.saveData($scope.candidate).then(function (response) {

            if (response.data == null) {
                $location.path("/error");
                return;
            }

            $cookieStore.remove("packageDetails");
            $cookieStore.remove("alacartReportTotal");
            $cookieStore.remove("alacartReportList");

            //remove Orderid id becoze we have success fully receive the requester data.
            $cookieStore.remove("OrderId");

        });
    };

    $scope.init();
});