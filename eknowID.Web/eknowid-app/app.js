
// create the module and name it eknowIdApp
// also include ngRoute for all our routing needs
var eknowIdApp = angular.module('eknowIdApp', ['ngRoute', 'ui.bootstrap', 'ngCookies', 'ngStorage', 'ngAnimate', 'angularUtils.directives.dirPagination', 'ngPayments']);

eknowIdApp.constant("baseUrlConfig", {
    "url": "http://localhost/eknowID.WebApi/"
    //,"port": "80"
})


// configure our routes
eknowIdApp.config(function ($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'eknowid-app/app/views/home.html',
            controller: 'homeCtrl',
        })
        .when('/package', {
            templateUrl: 'eknowid-app/app/views/packages.html',
            controller: 'packageCtrl',
            data: {
                requireLogin: false
            }
        })
        .when('/alaCart', {
            templateUrl: 'eknowid-app/app/views/alacarte.html',
            controller: 'alacartCtrl',
            data: {
                requireLogin: false
            }
        }).
        when('/requester-payment', {
            templateUrl: 'eknowid-app/app/views/requester-payment.html',
            controller: 'paymentCtrl',
            data: {
                requireLogin: true
            }
        }).
        when('/requester-account', {
            templateUrl: 'eknowid-app/app/views/requester-account.html',
            controller: 'requesterAccountCtrl',
            data: {
                requireLogin: false
            }
        }).
        when('/requester-company', {
            templateUrl: 'eknowid-app/app/views/requester-company.html',
            controller: 'requesterAccountCtrl',
            data: {
                requireLogin: false
            }
        }).
        when('/candidate', {
            templateUrl: 'eknowid-app/app/views/candidate.html',
            controller: 'candidateCtrl',
            data: {
                requireLogin: true
            }
        }).
        when('/dashboard', {
            templateUrl: 'eknowid-app/app/views/dashboard.html',
            controller: 'dashboardCtrl',
            data: {
                requireLogin: true
            }
        }).
        when('/applicant-profile', {
            templateUrl: 'eknowid-app/app/views/applicant-Profile.html',
            controller: 'applicantProfileCtrl'
        }).
        when('/login', {
            templateUrl: 'eknowid-app/app/views/requester-login.html',
            controller: 'requesterLoginCtrl'
        }).
        when('/error', {
            templateUrl: 'eknowid-app/app/views/error-page.html'
        }).
        when('/aboutus', {
            templateUrl: 'eknowid-app/app/views/aboutUs.html'
        }).
        when('/contactus', {
            templateUrl: 'eknowid-app/app/views/contactUs.html'
        }).
        when('/enterprise-Solutions', {
            templateUrl: 'eknowid-app/app/views/enterprise-Solutions.html'
        }).
        otherwise({
            redirectTo: '/'
        });
});

