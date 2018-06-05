<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="Alacarte.aspx.cs" Inherits="eknowID.Pages.Alacarte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        jQuery(document).ready(function () {
            var listOfReports = [];
            var list = "";
            var alacarteList = "";
            var reportTotal = 0;
            var planTotal = parseFloat($("#PlanTypeTotal").val());

            jQuery(':button').click(function () {

                list = "";
                alacarteList = "";

                var btnName = $(this).attr("name");
                var dataReport = $(this).attr("data-report");
                var reportPrice = parseFloat($(this).attr("data-price"));

                $(this).closest('.couponCodeBox').find(".close").toggle();
                $(this).closest('.couponCodeBox').find(".lock").toggle();
                $(this).closest('.couponCodeBox').find(".overlay").toggle();

                if (btnName == "btnPick") {
                    listOfReports.push(dataReport);
                    reportTotal += parseFloat(reportPrice.toFixed(2));
                }
                else {
                    var index = listOfReports.indexOf(dataReport);
                    listOfReports.splice(index, 1);
                    reportTotal -= parseFloat(reportPrice.toFixed(2));
                }

                $.each(listOfReports, function (key, value) {
                    list += "<li>" + value + "</li>";
                    alacarteList += value + ";";
                });

                $("#reportList").html(list);
                $("#reportTotal").html(reportTotal.toFixed(2))

                $("#AlacarteList").val(alacarteList);
                $("#AlacarteTotal").val((planTotal + reportTotal).toFixed(2));
            });

            $('.less').each(function () {
                if ($(this)[0].scrollHeight <= 40) {
                    $(this).closest("#divAlacartMain").find(".text-size").hide();
                }
            });
        });

        
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="section-2">
        <div class="container">
            <div class="couponBox">
                <div class="row">

                    <asp:HiddenField ID="AlacarteList" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="AlacarteTotal" runat="server" ClientIDMode="Static" />

                    <div class="col-lg-8 col-md-8 col-sm-6  col-xs-12">
                        <asp:Repeater ID="AlacarteRepeater1" runat="server">
                            <ItemTemplate>
                                <asp:HiddenField ID="PlanTypeTotal" runat="server" ClientIDMode="Static" Value='<%# Eval("Price") %>' />
                                <div class="couponCodeBox" style="color: white; font-size: 15px;">
                                    <div class="couponCodeBoxInner">
                                        <div class="link link1"><%# Eval("Price") %></div>
                                        <div style="margin-top: 10px;">
                                            <%# Eval("Price") %>
                                        </div>
                                    </div>
                                    <input type="button" name="btnPick" class="pricebox"
                                        value='pick for <%# Eval("Price") %>' id='<%# Eval("Id") %>'
                                        data-report='<%# Eval("Name") %>' data-price="<%# Eval("Price") %>" />

                                    <div>
                                        <input type="button" class="close" data-report='<%# Eval("Name") %>' data-price="<%# Eval("Price") %>" />
                                        <span class="lock"></span>
                                        <div class="overlay"></div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <div class="col-lg-4 col-md-4 col-sm-6  col-xs-12">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="order_summary">
                                    <div class="order_summary_title2">
                                        <h4 class="pull-left"><span class="cart"></span><span>Shopping Cart</span></h4>
                                        <div class="pull-right">
                                            <asp:Button runat="server" ID="AlacarteContinue" Text="Continue" CssClass="btn btn-success" OnClick="AlacarteContinue_Click" />
                                        </div>
                                    </div>
                                    <div class="col-xs-12">
                                        <div class="order_summary_desc">
                                            <div class="pull-left">
                                                <h5>
                                                    <asp:Label ID="planName" runat="server"></asp:Label>
                                                    Report </h5>
                                                <p><span class="blue_color">Edit</span></p>
                                            </div>
                                            <div class="pull-right">
                                                <div class="price">
                                                    <asp:Label runat="server" ID="planPrice"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <p>Includes the following</p>
                                        </div>

                                    </div>
                                    <div class="summry_list">
                                        <ul class="list_2">
                                            <asp:Repeater runat="server" ID="packageType">
                                                <ItemTemplate>
                                                    <%--<li><%# Eval("PlanDetails") %></li>--%>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>

                                        <ul class="list_2" id="reportList">
                                        </ul>
                                    </div>
                                    <div class="order_summary_tot">
                                        <div class="col-xs-12">
                                            <div class="pull-left">
                                                <h5>total </h5>
                                            </div>
                                            <div class="pull-right">
                                                <div class="price" id="reportTotal"></div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <p>Account verifacation<span class="col_green"> &lt; < 1 day</span></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
