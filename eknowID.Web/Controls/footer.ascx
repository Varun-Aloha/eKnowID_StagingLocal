<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="eknowID.Controls.Footer" %>
<script language="JavaScript" type="text/javascript">
    function setFbCount(count) {
        var likeCount = addCommas(count);
        $('#<%=lblFacebokkLike.ClientID%>').html(likeCount);
    }
    function addCommas(count) {
        var amount = new String(count);
        amount = amount.split("").reverse();

        var output = "";
        for (var i = 0; i <= amount.length - 1; i++) {
            output = amount[i] + output;
            if ((i + 1) % 3 == 0 && (amount.length - 1) !== i) output = ',' + output;
        }
        return output;
    }

    $(document).ready(function () {
        window.onload = function () {
            setTimeout(function () {
                var footerHeight = $(".twitter").innerHeight();

                $("#footerOuter").css("height", footerHeight);
            }, 300);
        };
    });


</script>
<style type="text/css">
    .divFacebookHeading {
        width: 146px !important;
    }

    .divContactInfoHeading {
        width: 100% !important;
    }

    .divServiceKnowID {
        font-size: 10px;
        height: 14px;
        margin-left: 2px;
        margin-top: 20px;
        width: 69px;
    }

    .divContactInfo {
        font-size: 100%;
        height: 73px;
        margin-left: 22px;
        margin-top: -4px;
        padding: 0;
        width: 240px;
    }

    .divLeftDashboard {
        width: 465px;
        padding-right: 10px;
    }

    .divRightDashboard {
        width: 224px !important;
    }

    .divMidDashboard {
        width: 265px !important;
    }
</style>

<div class="width100per">
    <div class="width1000px margin_left_right_auto">
        <div class="marginleft20 divSocialDashboard">
            <div class="floatLeft divLeftDashboard">
                <div class="twitter" id="jstweets">
                    <a class="twitter-timeline" width="300" height="30" data-dnt="true" href="https://twitter.com/eKnowID" data-widget-id="345890537678708738" data-chrome="noheader nofooter noborders transparent" data-show-replies="false" data-tweet-limit="1" style="font-size:15px;font-weight:bold;text-decoration:none;color:#ffffff;">Tweets by @eKnowID</a>
                    <script>
                        !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");
                    </script>
                </div>
            </div>
            <div class="divSocialSeperator marginLeft5">
            </div>
            <div class="floatLeft divRightDashboard">
                <div class="divFacebook floatLeft">
                </div>
                <div class="divSocialHeading floatLeft divFacebookHeading">
                    Join us on Facebook
                </div>
                <div class="divTweets lightGrayForeColor" id="divFacebookLike" style="height: 60px; padding-top: 0; margin-left: 0px;">
                    <center>
                        <asp:Label ID="lblFacebokkLike" ClientIDMode="Static" runat="server" Text="" Style="font: 55px helvetica;"></asp:Label>
                    </center>
                </div>
                <div class="divFansOnFb whiteColor">
                    Fans on Facebook
                </div>
                <div class="divFollowOnTwitter" style="margin: 5px 0px 0px 21px; width: 134px;">
                    <a class="hrefTwitter" style="color: #4A80C0 !important; cursor: pointer;" href='https://www.facebook.com/eknowid' target='_blank'>
                        <img src="../Images/Facebook-Icon.png" />
                    </a>
                </div>
            </div>
            <div class="divSocialSeperator marginLeft5">
            </div>
            <div class="floatLeft divMidDashboard">
                <div class="floatLeft divSocialHeading divContactInfoHeading">
                    <p style="font-size:15px;margin-top:-4px;">CONTACT INFO</p>
                </div>
                <div class="divTweets divYouTubeIframe margin_left_right_auto divContactInfo" style="height: 73px; margin-top: 45px;">
                    <p class="lightGrayForeColor ">
                        We are available always to meet your needs.Please contact our corporate office via
                        phone for further information.
                    </p>
                    <p class="lightGrayForeColor lineHeightDouble">
                        Phone : 1-888 -SIX CHEC (749-2432)<br />
                        Email :<a href="mailto:support@eknowid.com " class="lightGrayForeColor" style="text-decoration: none">
                            support@eknowid.com </a>
                        <br />
                    </p>
                </div>
            </div>
        </div>
    </div>
</div>
