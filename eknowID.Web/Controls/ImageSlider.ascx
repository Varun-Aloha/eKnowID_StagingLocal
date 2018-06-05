<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageSlider.ascx.cs"
    Inherits="eknowID.Controls.ImageSlider" %>
<%@ OutputCache Duration ="3600" Shared="true" VaryByParam="none" %>
<script src="../Scripts/jquery.orbit-1.2.3.min.js" type="text/javascript"></script>
<link href="../Styles/orbit-1.2.3.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(window).load(function () {
        $('#featured').orbit({
            'bullets': true,
            'bulletThumbs': true,
            'bulletThumbLocation': 'orbit/'
        });
       AdjustSliderSize();
    });

 function AdjustSliderSize() {
       var screenwidth = $("#mstrPage").width();
       $("#sliderOuter").css('width', screenwidth);
       $("#sliderOuter").css('overflow', 'hidden'); 
        var sliderwidth = 1800 - screenwidth;        
        if (sliderwidth >= 0) {
            var minusIndex = sliderwidth / 2 * -1;
            $("#featured").css('left', minusIndex);           
        }

         var navControls = screenwidth - 1000;
         if (navControls >= 0) {
             
             $('span.left').css('left', (navControls / 2) + "px");
             $('span.right').css('left', ((navControls / 2) + 959) + "px");

             var bulletListLeft = (navControls / 2 + 20);
             $('.bulletList').attr('style', 'margin-left:' + bulletListLeft+ 'px !important;');
         }
    }
</script>

<!-- http://www.zurb.com/playground/orbit-jquery-image-slider -->
<div id="sliderDiv">
    <div id="sliderOuter" class="margin_left_right_auto">
    <div id="featured" style="height: 385px; width: 100%;">
     <a href="#" onclick="OpenUpoadResume();"><img src="../Images/slider/banner_1_image.png" height="350" alt="EKnowID"/></a>
       <a href="../Pages/GetStarted_UncoverBackground.aspx">  <img src="../Images/slider/banner_2_image.png" height="350" alt="EKnowID"/></a>
        <a href="../Pages/GetStarted_ProtectID.aspx"> <img src="../Images/slider/banner_3_image.png" height="350" alt="EKnowIDs"/></a>      
    </div>
    </div>  
</div>

