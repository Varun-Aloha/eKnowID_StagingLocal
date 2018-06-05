<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="RequesterCompany.aspx.cs" Inherits="eknowID.Pages.RequesterCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
       

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="section-2">
        <div class="top-content">
            <div class="inner-bg">
                <div class="container">
                    <div class="row" style="margin-top: -40px;">
                        <div class="col-sm-5 col-sm-offset-3">
                            <div class="form-box">
                                <div class="form-top">
                                    <div class="form-top-left">
                                        <h3>Company Profile</h3>
                                        <p>Fill in the form below create your company profile</p>
                                    </div>
                                </div>
                                <div class="form-bottom">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtCompanyName" runat="server" MaxLength="50" placeholder="Company name..." CssClass="form-control textbox" required></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtJobTitle" runat="server" MaxLength="100" placeholder="Job Title..." CssClass="form-control textbox" required></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtCompanyPhone" runat="server" MaxLength="10" placeholder="Company phone number..." CssClass="form-control textbox digitsOnly" required></asp:TextBox>

                                        <asp:RegularExpressionValidator
                                            ID="regxPhone"
                                            runat="server"
                                            ControlToValidate="txtCompanyPhone"
                                            ValidationExpression="^([\(]{1}[0-9]{3}[\)]{1}[\.| |\-]{0,1}|^[0-9]{3}[\.|\-| ]?)?[0-9]{3}(\.|\-| )?[0-9]{4}$"
                                            Display="Dynamic" ForeColor="#FF3300" Font-Size="Medium"
                                            Text="Enter a valid phone number" />
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtCompanyTaxId" runat="server" placeholder="Company Tax Id..." CssClass="form-control textbox digitsOnly" MaxLength="9" required></asp:TextBox>

                                        <%-- <asp:RegularExpressionValidator
                                            ID="regxSSN"
                                            runat="server"
                                            ControlToValidate="txtCompanyTaxId"
                                            ValidationExpression="\d{3}-\d{2}-\d{4}"
                                            Display="Dynamic" ForeColor="#FF3300" Font-Size="Medium"
                                            Text="Enter Valid Company Tax Id" />--%>
                                    </div>

                                    <div class="form-group">
                                        <asp:TextBox ID="txtCompnyDescription" runat="server" TextMode="MultiLine" Rows="4"
                                            placeholder="Please describe your screening situation - hiring volumne , legal requirements,special needs,etc."
                                            MaxLength="150"
                                            CssClass="form-control resize-none" Style="line-height: none">
                                        </asp:TextBox>
                                    </div>

                                    <asp:Button ID="btnRequesterCompany" runat="server" CssClass="signup-button" Text="Create Company Profile!" OnClick="btnRequesterCompany_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
