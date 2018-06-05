eknowIdApp.service("requesterAccountService", function ($http, baseUrlConfig) {

    
    //Get api URL from constant
    var BaseUrl = baseUrlConfig.url;

    var requesterDetail = {};

    //This service is used to make payment of requester using selected report price
    //requesterDetail.SaveRequesterData = function (requesterModel) {
    //    
    //    return $http.post(BaseUrl + "api/requester/", requesterModel);
    //}

    requesterDetail.saveData = function (requesterProfileViewModel) {
        
        return $http.post(baseUrlConfig.url + "api/requesterandcandidate/", requesterProfileViewModel);
    }

    requesterDetail.emailAddressExistsOrNot = function (email) {
        return $http.post(baseUrlConfig.url + "api/requesterandcandidate/" + email);
    }

    return requesterDetail;
});