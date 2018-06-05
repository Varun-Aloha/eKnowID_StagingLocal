<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="eknowID.Pages.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Content/bootstrap.cosmo.css" rel="stylesheet" />


    <style type="text/css">
        .text-center {
            text-align: center;
            font-size: 15px;
        }

        .empty {
            border: 1px solid black;
        }
    </style>


    <script type="text/javascript">
        //prevent back
        $(document).ready(function () {
            function disableBack() { window.history.forward() }

            window.onload = disableBack();
            window.onpageshow = function (evt) { if (evt.persisted) disableBack() }
        });

        function preventBack() {
            window.history.forward();
        }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="section-2" style="margin-top: 90px; padding: 100px; height: 450px; background-color: #fff">
        <div class="row">

            <asp:GridView ID="gridOrdersList" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="Black" GridLines="Vertical" CssClass="grid-cell-padding" OnPageIndexChanging="gridOrdersList_PageIndexChanging" OnRowDataBound="gridOrdersList_RowDataBound" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Width="1173px" Height="60px" ShowFooter="True">
                <HeaderStyle HorizontalAlign="Center" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField ItemStyle-Width="150px" ItemStyle-Height="50px" DataField="FirstName" HeaderText="First Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                        <ItemStyle Width="150px" Height="50px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField ItemStyle-Width="150px" ItemStyle-Height="50px" DataField="LastName" HeaderText="Last Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                        <ItemStyle Width="150px" Height="50px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField ItemStyle-Width="150px" ItemStyle-Height="50px" DataField="Order" HeaderText="Order Number" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                        <ItemStyle Width="150px" Height="50px"></ItemStyle>
                    </asp:BoundField>

                    <asp:TemplateField ItemStyle-Width="150px" ItemStyle-Height="50px" HeaderText="Order Status" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("OrderState") %>' Visible="false"></asp:Label>
                            <asp:HyperLink NavigateUrl="#" runat="server" Target="_blank" ID="hypReport" Visible="false" Text='<%#Eval("URL") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField ItemStyle-Width="150px" ItemStyle-Height="50px" DataField="PurchaseDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Purchase Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                        <ItemStyle Width="150px"></ItemStyle>
                    </asp:BoundField>
                </Columns>

                <EmptyDataRowStyle CssClass="empty" />
                <EmptyDataTemplate>
                    <font class="noOrderExistErrorMSg">There are currently no orders.</font>
                </EmptyDataTemplate>

                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />

                <PagerSettings Mode="Numeric" Position="Bottom" PageButtonCount="10" />

                <PagerStyle BackColor="#6b696b" Font-Size="Large" Height="30px" VerticalAlign="Bottom" HorizontalAlign="Center" />
            </asp:GridView>
        </div>
        <%--<div id="mainContainer" class="container">
            <div class="shadowBox">
                <div class="page-container">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-12" style="margin-top: 15px;">
                                <div class="table-responsive">
                                    <asp:GridView ID="gridOrdersList" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="FirstName" EmptyDataText="There are no data records to display.">
                                        <Columns>
                                            <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="True" SortExpression="FirstName" />
                                            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                            <asp:BoundField DataField="Order" HeaderText="Order Number" SortExpression="Order" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />
                                            <asp:TemplateField ItemStyle-Width="150px" HeaderText="Order Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("OrderState") %>' Visible="false"></asp:Label>
                                                    <asp:HyperLink NavigateUrl="#" runat="server" Target="_blank" ID="hypReport" Visible="false" Text='<%#Eval("URL") %>'></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="PurchaseDate" HeaderText="Purchase Date" DataFormatString="{0:MM/dd/yyyy}" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
    </section>

</asp:Content>
