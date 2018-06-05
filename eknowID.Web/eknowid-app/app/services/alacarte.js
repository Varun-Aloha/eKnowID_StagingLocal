eknowIdApp.service("alacartService", function ($http, baseUrlConfig) {

    var reportList = {};

    //Get Alacart report list to display into alacart page
    reportList.getReportList = function () {
        return $http.get(baseUrlConfig.url + "api/Package/GetAlacarteReport");
    }

    return reportList;
});