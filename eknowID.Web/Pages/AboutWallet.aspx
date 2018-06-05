<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="AboutWallet.aspx.cs" Inherits="eknowID.Pages.AboutWallet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        ol li {
            font-family: 'Helvetica,sans-serif';
            margin-bottom: 10px;
            font-size: 17px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="eknowid-bg">
        <div class="container" style="padding-top: 110px;">
            <div class="row">
                <div class="col-sm-12">
                    <div style="width: 100%; height: 400px; margin-bottom: 25px; padding: 10px; border-radius: 5px; background-color: white; box-shadow: 3px 3px 3px #888888;">
                        <div style="height: 50px; margin-top: 20px; margin-left: 10px;">
                            <h2>About Wallet</h2>
                        </div>

                        <div style="padding: 15px; font-size: 16px;">
                            <ol style="padding: 15px;">
                                <li>No monthly fees - simply buy credits and use them as needed during hiring projects.</li>
                                <li>Credits never expire; save money by buying them in bulk.</li>                                
                                <li>Credits can be used for packages and ala carte purchases.</li>
                                <li>1 Credit = $1</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
