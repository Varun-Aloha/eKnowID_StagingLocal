eknowIdApp.service("dashboardService", function ($http, baseUrlConfig) {

    var requesterOrderList = {};

    requesterOrderList.getOrderList = function (id, pageSize, pageNumber) {

        return $http.get(baseUrlConfig.url + "api/candidate/" + id + "/" + pageSize + "/" + pageNumber);

    }
    return requesterOrderList;
});