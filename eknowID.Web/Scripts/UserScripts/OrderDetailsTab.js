var indexval;
var selectedTabTitle = "";
var isValid;
//var LicenseFlag;
//var ReferenceFlag;
//var EmpFlag;
//var EduFlag;

//$(function () {
//    $("#tabs").tabs({
//        select: function (event, ui) {
//            indexval = ui.index;
//            selectedTabTitle = $(ui.tab).text();
//            ChangeTitle(selectedTabTitle);
//            alert(indexval);
//        }
//    });

//    //For First Time set lblPopupHeader Text manully
//    if (indexval == undefined) {
//        $('#lblPopUpHeader').text($('ul.ulList li a:first').text());
//    }

//    //Append span(verticle seprator) to every child of ul but last    
//    $('ul.ulList').children().not(':last-child').append('<img alt="seperator"src="../Images/headerSeprator1.png" class="marginLeft5 marginTop8" />');
//    $('#Container').find('.ui-tabs-selected a').css('color', '#ffffff');
//});


//function ChangeTitle(TabTitle) {  
//  
//    TabTitle = TabTitle.replace(/^\s+|\s+$/g, '');

//    if (TabTitle == 'Professional Experience') {
//        $('#lblPopUpHeader').text('Employment Details');
//        return;
//    }

//    else if (TabTitle == 'Education') {
//        $('#lblPopUpHeader').text('Educational Details');
//        return;
//    }

//    else if (TabTitle == 'License') {
//        $('#lblPopUpHeader').text('License Info');
//        return;
//    }

//    else if (TabTitle == 'Reference Details') {
//        $('#lblPopUpHeader').text('Reference Details');        
//        return;
//    }
//}
//function ChangeProfileTab() {
//    
//    if ($('#mstrPage').valid()) {
//        if (indexval == undefined) {
//            indexval = 0;
//        }
//        var index = indexval + 1;
//        var totalSize = $(".ui-tabs-panel").size();

//        if (index < totalSize) {
//            $("#tabs").tabs('select', index);
//        }
//        else {
//            CheckIfOrderIsValid();
//        }
//    }
//}

//function ShowPopups() {
//        var isDetailPopup = $('#hdnDetailsPopups').val();
//        if (isDetailPopup == "True") {
//            OpenDetailsPopup();
//        }
//        else {
//            var isDrugTest = $('#hdnDrugVerification').val();
//            if (isDrugTest == "True") {
//                DrugsVerficationPopUp();
//            }
//            else {
//                window.location.href = "../Pages/SearchByProf_PaymentInfo.aspx?SelectedTab=Payment";
//            }
//        }
//}


//function OpenDetailsPopup() {
//    $('#requiredDetails').bPopup({
//        appendTo: 'form',
//        follow: [false, false],
//        modalClose: false,
//        opacity: 0.6,
//        positionStyle: 'absolute'     
//    });
//}

//function OpenReadOnlyPopup() {   
//    
//    $("#tabs").tabs('select', 0);

//    //$("#requiredDetails input[type='text']").attr('readonly', true);
//    $("#requiredDetails input[type='text'],textarea").attr('disabled', 'disabled');
//    $("#requiredDetails input:radio").attr('disabled', 'disabled');
//    $("#requiredDetails select").prop('disabled', true);

//    //to check if the license tab is present
//    if ($('#txtNumber').length > 0) {        
//        //Disable license tool tip
//        $("#txtNumber").bt("", {
//            trigger: ['focus', 'blur'],
//            positions: ['right'],
//            fill: 'Gray'
//        });
//    }
//    
//    $("#divBtnContainer").css("display", "none");
//    $("#divMessageContainer").css("display", "none");
//    $("#divEditBtnContainer").css("display", "inline");
//    $("#Contenttext").css("display", "none");
//    $("#ContenttextReadOnly").css("display", "block");
//    $("#lblAdditionalInfo").css("display", "none"); 
//    $("#lblReviewOrder").css("display", "inline");

//    $("#requiredDetails input[type='text']").datepicker('disable'); 
//    $("#requiredDetails input[type='text'],textarea,Select").css("background", "none repeat scroll 0 0 transparent");
//    $("#requiredDetails input[type='text'],textarea,Select").css("border", "0 solid #C0C8D2");
//    $("#requiredDetails input[type='text'],textarea,Select").css("box-shadow", "0 0px 0px rgba(0, 0, 0, 0.08) inset");
//    $("#tabs  img").css("display", "none");
//    $("#tabs input[type='button']").css("display", "none");    

//    OpenDetailsPopup();
//}

//function EditOrderDetails() {

//    //$('#requiredDetails').bPopup().close();
//    $("#tabs").tabs('select', 0);

//    $("#requiredDetails input[type='text'],textarea").removeAttr('disabled');
//    $("#requiredDetails input:radio").removeAttr('disabled');
//    $("#requiredDetails select").prop('disabled', false);

//    $("#requiredDetails input,textarea").attr('readonly', false);
//    $("#requiredDetails select").prop('disabled', false);
//    //$("#requiredDetails input:radio").removeAttr('disabled');
//    
//    //to check if the license tab is present
//    if ($('#txtNumber').length > 0) {    
//        // re-enable lincense tool tip 
//        $('#txtNumber').bt($("#hdnErrorMessage").val(), {
//            trigger: ['focus', 'blur'],
//            positions: ['right'],
//            fill: 'Gray'
//        });
//    }

//    $("#divBtnContainer").css("display", "inline");
//    $("#divMessageContainer").css("display", "block");
//    $("#divEditBtnContainer").css("display", "none");
//    $("#Contenttext").css("display", "block");
//    $("#ContenttextReadOnly").css("display", "none");
//    $("#lblAdditionalInfo").css("display", "inline");
//    $("#lblReviewOrder").css("display", "none");
//     
//    $("#requiredDetails input[type='text']").datepicker('enable');     
//    $("#requiredDetails input[type='text'],textarea,Select").removeAttr("style");   
//    $("#tabs  img").css("display", "inline");
//    $("#tabs input[type='button']").css("display", "inline");

//    OpenDetailsPopup();

//}

//function CloseTab() {
//    $('#requiredDetails').bPopup().close();
//}

function ChangeProfileTab() {
    if (tabIndex == "") {
        tabIndex = 0;
    }  

    var ssnvalidate = true;
    if (tabIndex == 0) {
        ssnvalidate = $("#hdnSSN").valid() && $("#hdnConfirmSSN").valid();       
    }

    if ($('#mstrPage').valid() && ssnvalidate) {

        ShowCheckImage(tabIndex);

        var index = tabIndex + 1;
        var totalSize = $(".ui-tabs-panel").size();
        if (index < totalSize) {
            $("#tabs").tabs('select', index);
        } else {
            CheckIfOrderIsValid();
        }
    }
}

function DrugsVerficationPopUp() {
    $('#DrugsVerficationDiv').bPopup({
        modalClose: false,
        opacity: 0.6,
        positionStyle: 'absolute'
    });
}

function CloseDrugsDiv() {
    $('#DrugsVerficationDiv').bPopup().close();
    window.location.href = "../Pages/SearchByProf_PaymentInfo.aspx";
}

function RedirectToPayment() {    
    window.location.href = "../Pages/SearchByProf_PaymentInfo.aspx";
}
function RedirectToResume() {
    window.location.href = "../Pages/RC_AnalysisSummary.aspx";
}

function ShowCheckImage(tabIndex) {

    if (tabIndex == 0) {
        $("#imgConDetail").removeClass('displayNone');
    }
    else if (tabIndex == 1) {
        $("#imgEmpDetail").removeClass('displayNone');
    }
    else if (tabIndex == 2) {
        $("#imgEduDetail").removeClass('displayNone');
    }
    else if (tabIndex == 3) {
        $("#imgLicDetail").removeClass('displayNone');
    }
    else if (tabIndex == 4) {
        $("#imgRefDetail").removeClass('displayNone');
    }
}