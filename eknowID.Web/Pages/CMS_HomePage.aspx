<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="CMS_HomePage.aspx.cs" Inherits="eknowID.Pages.CMS_HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
    function SetPreviewContent() {
    setHomePageContent(true);
}
function UpdateContent() {
    setHomePageContent(false);
}

function ClearContent() {
    $.ajax({
        type: "POST",
        url: "CMS_HomePage.aspx/ClearPreviewHomePageContent",
        contentType: "application/json; charset=utf-8",
        data: "{}",
        dataType: "json",
        success: function (result) {
            window.location.href = "../Pages/index.aspx";
        }
    });
}

    function setHomePageContent(previewFlag) {
        var TestimonialsContent = $("#<%=txtTestimonialsContent.ClientID%>").val();
        TestimonialsContent = TestimonialsContent.replace(/\'/g, '¤');
        var TestimonialsSignName = $("#<%=txtTestimonialsSignatureName.ClientID%>").val();
        TestimonialsSignName = TestimonialsSignName.replace(/\'/g, '¤');
        var TestimonialsSignComapnyName = $("#<%=txtTestimonialsSignCompanyName.ClientID%>").val();
        TestimonialsSignComapnyName = TestimonialsSignComapnyName.replace(/\'/g, '¤');
        var BlogHeader = $("#<%=txtBlogHeader.ClientID%>").val();
        BlogHeader = BlogHeader.replace(/\'/g, '¤');
        var BlogContent = $("#<%=txtBlogContent.ClientID%>").val();
        BlogContent = BlogContent.replace(/\'/g, '¤');
        var YouTubeSRC = $("#<%=txtYouTubeSRC.ClientID%>").val();
        YouTubeSRC = YouTubeSRC.replace(/\'/g, '¤');

        var controlData = "TestimonialsContent:'" + TestimonialsContent + "'";
        controlData = controlData + ",TestimonialsSignName:'" + TestimonialsSignName + "'";
        controlData = controlData + ",TestimonialsSignComapnyName:'" + TestimonialsSignComapnyName + "'";
        controlData = controlData + ",BlogHeader:'" + BlogHeader + "'";
        controlData = controlData + ",BlogContent:'" + BlogContent + "'";
        controlData = controlData + ",YouTubeSRC:'" + YouTubeSRC + "'";
        controlData = controlData + ",TestimonialsImage:'" + $("#<%=hdnTestimonialsImg.ClientID%>").val() + "'";
         controlData = controlData + ",previewFlag:'" + previewFlag + "'";
        $.ajax({
            type: "POST",
            url: "CMS_HomePage.aspx/SetPreviewHomePageContent",
            contentType: "application/json; charset=utf-8",
            data: "{" + controlData + "}",
            dataType: "json",
            success: function (result) {
                if (result.d == true) {
                    window.location.href = "../Pages/index.aspx";
                }
            }
        });
    }

    function textboxMultilineMaxNumber(txt, maxLen) {
        try {
            if (txt.value.length > (maxLen - 1)) return false;
        } catch (e) {
        }
    }

    </script>
    <style type="text/css">
        .fieldName
        {
            width: 235px;
            height: 50px;
            padding-top: 35px;
        }
        .Height_120
        {
            height: 120px;
        }
        .Width_520
        {
            width: 520px;
        }
        .grayBackground
        {
            padding: 30px 0px;
        }
        .divWhyEknowMain
        {
            height: 525px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdnTestimonialsImg" runat="server" />
    <div class="minWidth1000px grayBackground">
        <div class="width1000px margin_left_right_auto minheight_200px padding30 divWhyEknowMain">
            <div class="color_3E3E3E boldText clearBoth Height_120">
                <div class="width50 floatLeft fieldName">
                    Testimonials Content:</div>
                <div class="width150 floatLeft">
                    <asp:TextBox ID="txtTestimonialsContent" runat="server" Height="100" Width="520"
                        TextMode="MultiLine" onkeypress="return textboxMultilineMaxNumber(this,350);"
                        CssClass="Width_520"></asp:TextBox></div>
            </div>
            <div class="color_3E3E3E boldText clearBoth">
                <div class="width50 floatLeft fieldName" style="padding-top: 5px; height: 35px;">
                    Testimonials Signature Name:</div>
                <div class="width150 floatLeft">
                    <asp:TextBox ID="txtTestimonialsSignatureName" runat="server" MaxLength="30" CssClass="Width_520"></asp:TextBox></div>
            </div>
            <div class="color_3E3E3E boldText clearBoth">
                <div class="width50 floatLeft fieldName" style="padding-top: 5px; height: 35px;">
                    Testimonials Signature Company Name:</div>
                <div class="width150 floatLeft">
                    <asp:TextBox ID="txtTestimonialsSignCompanyName" runat="server" MaxLength="350" CssClass="Width_520"></asp:TextBox></div>
            </div>
            <div class="color_3E3E3E boldText clearBoth">
                <div class="width50 floatLeft fieldName" style="padding-top: 5px; height: 35px;">
                    Testimonials Image(75×75):</div>
                <div class="Width_520 floatLeft">
                    <asp:UpdatePanel ID="FileUploadUpdatePanel" runat="server" UpdateMode="conditional">
                        <ContentTemplate>
                            <asp:FileUpload ID="imgUpload" runat="server" />
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" /><br />
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnUpload" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="color_3E3E3E boldText clearBoth ">
                <div class="width50 floatLeft fieldName" style="padding-top: 5px; height: 35px;">
                    Blog Header:</div>
                <div class="width150 floatLeft">
                    <asp:TextBox ID="txtBlogHeader" runat="server" MaxLength="350" CssClass="Width_520"></asp:TextBox></div>
            </div>
            <div class="color_3E3E3E boldText clearBoth Height_120">
                <div class="width50 floatLeft fieldName">
                    Blog Content:</div>
                <div class="width150 floatLeft">
                    <asp:TextBox ID="txtBlogContent" runat="server" Height="100" Width="520" TextMode="MultiLine"
                        onkeypress="return textboxMultilineMaxNumber(this,350);" CssClass="Width_520"></asp:TextBox></div>
            </div>
            <div class="color_3E3E3E boldText clearBoth ">
                <div class="width50 floatLeft fieldName" style="padding-top: 5px; height: 35px;">
                    Youtube Video URL(src):</div>
                <div class="width150 floatLeft">
                    <asp:TextBox ID="txtYouTubeSRC" runat="server" MaxLength="350" CssClass="Width_520"></asp:TextBox></div>
            </div>
             <div class="color_3E3E3E boldText clearBoth ">
                <div class="floatLeft fieldName" style="padding-top: 5px; height: 35px;width:100%;">
                   For Youtube link - navigate to YouTube -> Load video -> on the video, right click and select 'Copy Embed code' option -> from the embed code, copy and paste 'src' attribute value (value in double quotes after 'src' - eg: src="http://www.youtube.com/embed/uahePlmsteE?feature=player_detailpage" 

</div>
               </div>
          
            <div class="clearBoth padding10 margin_left_right_auto height50 width208">
                <div class="floatLeft">
                    <input type="button" class="blackBtnMiddle whiteColor" value="Preview" onclick="SetPreviewContent();" />
                </div>
                <div class="floatLeft">
                    <input type="button" class="blackBtnMiddle whiteColor" value="Update" onclick="UpdateContent();" />
                </div>
                <div class="floatLeft">
                    <input type="button" class="blackBtnMiddle whiteColor" value="Cancel" onclick="ClearContent();" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
