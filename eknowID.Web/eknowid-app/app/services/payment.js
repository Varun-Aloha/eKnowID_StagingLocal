eknowIdApp.service("paymentService", function ($http, baseUrlConfig) {
      
    var paymentDetail = {};

    //This service is used to make payment of requester using selected report price
    paymentDetail.makeRequesterPayment = function (paymentModel) {
        
        return $http.post(baseUrlConfig.url + "api/payment/", paymentModel);
    }
    
    return paymentDetail;
});