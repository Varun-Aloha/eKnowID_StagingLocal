
//$(function () {
//    /*-----------For Outer Sign Up ------------------*/
//    $('#ddlStateOutersignup select').change(function () {

//        var stateId = $('#ddlStateOutersignup select').val();

//        if (stateId != 0) {
//            $("#ddlCounty").prop('disabled', false);
//        }
//        else {
//            $("#ddlCounty").prop('disabled', true);
//        }
//        $.ajax({
//            type: "POST",
//            url: "../pages/loginajaxcalls.aspx/GetCountyList",
//            contentType: "application/json; charset=utf-8",
//            data: "{StateId:" + stateId + "}",
//            dataType: "json",
//            success: function (data) {
//                var select = $("#ddlCounty");
//                select.children().remove();
//                if (data.d) {
//                    $(data.d).each(function (index, item) {
//                        select.append($("<option>").val(item.Value).text(item.Text));
//                    });
//                }
//            }
//        });

        //        $.ajax({
        //            type: "POST",
        //            url: "../pages/loginajaxcalls.aspx/GetDistrictList",
        //            contentType: "application/json; charset=utf-8",
        //            data: "{StateId:" + stateId + "}",
        //            dataType: "json",
        //            success: function (data) {
        //                var select = $("#ddlDistrict");
        //                select.children().remove();
        //                if (data.d) {
        //                    $(data.d).each(function (index, item) {
        //                        select.append($("<option>").val(item.Value).text(item.Text));
        //                    });
        //                }
        //            }
        //        });
    //});

    /*-----------For inner Sign Up---------------*/

//    $('#ddlStateInnersignup select').change(function () {

//        var stateId = $('#ddlStateInnersignup select').val();


//        $.ajax({
//            type: "POST",
//            url: "../pages/loginajaxcalls.aspx/GetCountyList",
//            contentType: "application/json; charset=utf-8",
//            data: "{StateId:" + stateId + "}",
//            dataType: "json",
//            success: function (data) {
//                var select = $("#ddlCountyInner");
//                select.children().remove();
//                if (data.d) {
//                    $(data.d).each(function (index, item) {
//                        select.append($("<option>").val(item.Value).text(item.Text));
//                    });
//                }
//            }
//        });

        //        $.ajax({
        //            type: "POST",
        //            url: "../pages/loginajaxcalls.aspx/GetDistrictList",
        //            contentType: "application/json; charset=utf-8",
        //            data: "{StateId:" + stateId + "}",
        //            dataType: "json",
        //            success: function (data) {
        //                var select = $("#ddlDistrictInner");
        //                select.children().remove();
        //                if (data.d) {
        //                    $(data.d).each(function (index, item) {
        //                        select.append($("<option>").val(item.Value).text(item.Text));
        //                    });
        //                }
        //            }
        //        });       
//    });
//});