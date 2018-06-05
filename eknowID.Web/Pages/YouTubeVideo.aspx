<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true" CodeBehind="YouTubeVideo.aspx.cs" Inherits="eknowID.Pages.YouTubeVideo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="divAboutUsBg minWidth1000px" style="height: 400px;padding:45px 0px 40px 0px;">
<div style="width:640px;height:400px;margin-left:auto;margin-right:auto;">
<iframe id="iframeYoutube" runat="server" width="640" height="400" src="http://www.youtube.com/embed/RP8Xj0oUW4U?feature=player_detailpage&autoplay=1" frameborder="0"></iframe></div>
</div>
</asp:Content>
