eknowIdApp.service("CandidateService", function ($http, baseUrlConfig) {

    var requesterAndCandidateDetail = {};

    //This service is used to save requester and candidate data to DB
    requesterAndCandidateDetail.saveData = function (candidate) {

        return $http.post(baseUrlConfig.url + "api/candidate/", candidate);
    }

    return requesterAndCandidateDetail;
});