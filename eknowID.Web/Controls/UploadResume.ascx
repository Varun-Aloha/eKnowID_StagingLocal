<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadResume.ascx.cs"
    Inherits="eknowID.Controls.UploadResume" %>
<script type="text/javascript" language="javascript">
    function OpenUploadDiv() {
        $("#divUpload").css("display", "block");
    }
    function CloseUploadDiv() {
        $("#divUploadResume").bPopup().close();
        $("#divUpload").css("display", "none");
    }

    function CloseResumeDialog() {
        $("#divUploadResume").bPopup().close();
        $("#divUpload").css("display", "none");
    }
    $(document).ready(function () {
        var location = window.top.location.toString();
        if ((location.toLowerCase().toString().indexOf("index.aspx") != -1) || (location.toLowerCase().toString().indexOf("getstarted.aspx") != -1)) {
            $('.lnkFillManually').attr("style", "display:none;");
            $('.divPreFill').attr("style", "display:none;");
        }
    });
</script>
<style type="text/css">
.divPreFill
{
    color: #404040;font-size: 13px; height: 15px;
 }
</style>
<div class="width100per heightauto">
    <div class="dialogHeader borderRadiusTopCorners6">
        <b><span style="margin-left: 30px; color:#2a2a2a; font-size:28px;">Select Option to Proceed</span></b>
    </div>
    <div style="text-align: center;">
   
    <div class="divPreFill">We'll pre-fill the form. You decide what to verify.</div>  
        <div class="clearBoth">
            <asp:ImageButton ID="imgBtnConnectLinkedIn" runat="server" CssClass="padding25" ImageUrl="~/Images/import_linkdin_btn.png"
                CausesValidation="False" OnClientClick="return login('LINKEDIN')" />
        </div>
        <div class="clearBoth">
            <img src="../Images/upload_resume_btn.png" onclick="OpenUploadDiv();" alt="" class="cursor_pointer" />
        </div>
        <div class="displayNone" id="divUpload">
            <iframe src="../Pages/RC_ProcessResume.aspx" style="border-width: 0px; height: 125px;
                margin-left: 31px; width: 225PX;" frameBorder="0"></iframe>
        </div>
        <div class="clearBoth marginTop8">      
            <a onclick="CloseUploadDiv();" class="cursorPointer lnkFillManually" style="color: #4a80c0; font-weight: bold;">Fill Manually</a>                  
        </div>
    </div>
     
</div>
