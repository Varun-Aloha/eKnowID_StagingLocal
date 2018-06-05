<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="ActivateUserAccount.aspx.cs" Inherits="eknowID.Pages.ActivateUserAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style style="text/css">
        body {
            background: url(../images/header.png) no-repeat fixed;
            background-size: cover;
            background-size: 100% 100%;            
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="middle-content-box topBar">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="inner-content">
                        <h3 style="color:white; margin-right:400px; margin-top:50px" runat="server" id="activation_message">You have successfully activated your eKnowId account</h3>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
