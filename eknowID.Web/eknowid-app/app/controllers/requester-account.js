'use strict'

eknowIdApp.controller("requesterAccountCtrl", function ($scope, $location, $cookieStore, requesterAccountService) {

    $scope.init = function () {
    };

    //check email address is exists or not in database.
    $scope.isUniqueEmail = function () {        
        requesterAccountService.emailAddressExistsOrNot($scope.Email).then(function (response) {        
            $scope.requesterForm.$invalid = response.data;
            $scope.hasExists = response.data;
        });
    };


    $scope.emailKeydown = function () {
        $scope.hasExists = false;
    }

    $scope.requesterSignUp = function () {
        if (!$scope.requesterForm.$valid) {
            $scope.requestersubmitted = true;
            return;
        }

        $scope.requesterModel = {
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            Email: $scope.Email,
            Password: $scope.Password,
            IsRequester: 1,
        };

        $cookieStore.put("requesterModel", $scope.requesterModel);

        $location.path("/requester-company");
    };

    $scope.saveData = function () {
        if (!$scope.requesterCompanyForm.$valid) {
            $scope.submitted = true;
            return;
        }

        $scope.compayModel = {
            Name: $scope.CompanyName,
            CompanyPhone: $scope.CompanyPhone,
            CompanyTaxId: $scope.CompanyTaxId,
            State: $scope.State,
            Description: $scope.Description,
            JobTitle: $scope.JobTitle
        };

        $scope.requesterViewModel = ({
            Requester: $cookieStore.get("requesterModel"),
            Company: $scope.compayModel
        });

        requesterAccountService.saveData($scope.requesterViewModel).then(function (response) {
            if (response.IsError) {
                $location.path("/Error");
                return;
            }

            $cookieStore.put("authenticationData", response.data);
            $location.path("/requester-payment");
        });
    };

    $scope.init();
});