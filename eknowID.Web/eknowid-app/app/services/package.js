eknowIdApp.service("packageService", function ($http, baseUrlConfig) {

    var packageList = {};

    packageList.getPackageList = function () {
        return $http.get(baseUrlConfig.url + "api/Package");
    }

    return packageList;
});