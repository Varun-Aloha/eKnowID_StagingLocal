'use strict'

eknowIdApp.controller("paymentCtrl", function ($scope, $cookieStore, $rootScope, $location, paymentService, modalService, timeOutService, logoutService) {

    $scope.init = function () {

        $rootScope.$on("$locationChangeStart", function (event, next, current) {
            var nextPath = next.split('#')[1]
            var currentPath = current.split('#')[1];

            if ($cookieStore.get("OrderId"))
                $location.path("/candidate");
        });

        $scope.years = [];
        $scope.month = [];

        if (!logoutService.validateUserSession()) {
            $location.path("/login");
            return;
        }
        else if (!$cookieStore.get("packageDetails")) {
            $location.path("/");
            return;
        }

        for (var i = 1 ; i <= 12; i++)
            $scope.month[i] = i;

        for (var i = 0 ; i < 5; i++)
            $scope.years[i] = new Date().getFullYear() + i;

        $scope.basicReport = $cookieStore.get("packageDetails");
        $scope.alacartReportList = $cookieStore.get("alacartReportList");
        $scope.alacartReportTotal = $cookieStore.get("alacartReportTotal");
        $scope.requesterUser = logoutService.userLoggedInDetails;
        $scope.totalReport = $scope.basicReport.PlanPrice + $scope.alacartReportTotal;
    }

    //Service calls
    //This serive is use to make payment of requester.
    $scope.savePaymentData = function () {

        if (!($scope.firstChecked && $scope.secondChecked && $scope.thirdChecked)) {

            var modalOptions = {
                closeButtonText: false,
                actionButtonText: 'OK',
                headerText: 'Term and Condition',
                bodyText: "Please accept the term and conditions."
            };

            var customModalOptions = {
                templateUrl: "/eknowid-app/app/partials/modal.html"
            };

            modalService.showModal(customModalOptions, modalOptions);
            return;
        }

        $scope.loading = true;

        $scope.paymentModel = {
            CardType: $scope.creditCard.type,
            CardNumber: $scope.creditCard.number.replace(/\s+/g, ''),
            ExpMonth: $scope.creditCard.month,
            ExpYear: $scope.creditCard.year,
            SecurityCode: $scope.creditCard.cvc,
            OrderTotal: $scope.totalReport,
            ReportList: $scope.alacartReportList,
            UserId: $scope.requesterUser.UserId,
            PlanType: $scope.basicReport.Id
        };

        paymentService.makeRequesterPayment($scope.paymentModel).then(function (response) {

            $scope.loading = false;

            if (response.data.IsError) {
                var modalOptions = {
                    closeButtonText: false,
                    actionButtonText: 'OK',
                    headerText: 'Payment Error',
                    bodyText: response.data.ErrorMessage
                };

                var customModalOptions = {
                    templateUrl: "/eknowid-app/app/partials/modal.html"
                };

                modalService.showModal(customModalOptions, modalOptions);
            }
            else {
                //redirect to Candidate page to fill the data. If requester is pay the payment.
                $cookieStore.put("OrderId", response.data.OrderId);
                $scope.loading = "none";
                $location.path("/candidate");
            }
        });
    }
    $scope.init();
});

