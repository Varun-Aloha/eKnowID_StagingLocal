<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="RequesterCandidate.aspx.cs" Inherits="eknowID.Pages.RequesterCandidate" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .data-header {
            background-color: #d9ecfb !important;
        }

        .border-none {
            border-style: none none none none !important;
        }

        .border-bottom {
            border-bottom: 3px solid white;
        }

        .main-row {
            width: 100%;
            background-color: #f2f2f2;
            height: 56px;
            padding: 0;
            margin: 0 auto;
            color: #000000;
        }

        .main-row-heading {
            font-size: 20px;
            text-align: center;
            font-weight: bold;
            color: #000000;
            padding: 10px;
        }

        .table-header {
            width: 300px;
            padding: 8px;
        }

        .table {
            border-bottom: 0px solid #808080;
            margin-bottom: 0px;
            padding: 0px;
            border-collapse: separate !important;
            border-spacing: 0px;
            font-family: 'Roboto';
        }

            .table > tbody > tr > td {
                padding: 8px;
                line-height: 1.4285;
                vertical-align: top;
                border: none;
            }

        table.table-expandable > tbody > tr > td > table > tbody > tr > th {
            width: 150px;
            padding: 5px;
        }

        table.table-expandable > tbody > tr > td > table > tbody > tr {
            line-height: 25px;
        }

        .GridPager a, .GridPager span {
            line-height: 30px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
            border: none;
            padding: 0px 3px;
        }

        .GridPager a {
            color: #000000;
        }

        .GridPager span {
            color: #fb5240;
            border-bottom: 1px solid #000000;
            text-align: center;
        }
    </style>

    <script type="text/javascript">

        var isEmailExist = false;

        function IsCandidateEmailPresent() {

            var email = {
                email: $("#txtCandiEmail").val()
            };

            $.ajax({
                type: "POST",
                url: "RequesterCandidate.aspx/IsCandidateEmailPresent",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(email),
                async: false,
                success: function (result) {
                    if (result.d) {
                        alert("Candidate email address already exists.");
                        isEmailExist = true;
                        return;
                    }
                    isEmailExist = false;
                    return;
                }
            });
        }

        function isPresentCompnay() {

            var isPresent = false;

            $.ajax({
                type: "POST",
                url: "RequesterCandidate.aspx/IsPresentCompnay",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (result) {
                    isPresent = result.d;
                }
            });

            if (!isPresent) {
                $("#ModalCompnayProfile").modal('show');
                return false;
            }
            else {
                IsCandidateEmailPresent();

                if (isEmailExist) {
                    return false;
                }
                return true;
            }
        }

        function ValidationDetail() {

            if ($("#txtCandiFirstName").val() == "") {
                $("#errorCandidateFirstName").html("Please enter candidate first name.");
                return false;
            }

            if ($("#txtCandiLastName").val() == "") {
                $("#errorCandidateLastName").html("Please enter candidate last name.");
                return false;
            }

            if ($("#txtCandiEmail").val() == "") {
                $("#errorCandidateEmail").html("Please enter candidate email address.");
                return false;
            }

            //check for email validation
            var emailRegx = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

            if ($("#txtCandiEmail").val() != null) {
                if (!(emailRegx.test($("#txtCandiEmail").val()))) {
                    $("#errorCandidateEmail").html("Please enter a valid email address.");
                    return false;
                }
            }

            if ($("#drpCandidate").val() == "") {
                $("#errorCandidatedropdown").html("Please select an item from the list.")
                return false;
            }

            return isPresentCompnay();

            //check wehther candidate email addreess is present or not and return the value.
            //return isEmailExist == true ? false : true;
        }

        $(function () {
            $("#txtCandiFirstName").keyup(function (e) {
                $("#errorCandidateFirstName").html("");
            });

            $("#txtCandiLastName").keyup(function (e) {
                $("#errorCandidateLastName").html("");
            });

            $("#txtCandiEmail").keyup(function (e) {
                $("#errorCandidateEmail").html("");
            });

            $("#txtCandiEmail").keyup(function (e) {
                $("#errorCandidateEmail").html("");
            });

            $('#drpCandidate').change(function () {
                $("#errorCandidatedropdown").html("");
            });
        });

        $(function () {
            $("img").click(function () {

                var id = this.id;

                var imgSrc = $("#" + id).attr("src");

                var imgName = imgSrc.split("/");

                if (imgName[imgName.length - 1] == "black-arrow_down.png") {
                    $("#" + id).attr("src", "../Images/black-arrow_up.png");
                }
                else {
                    $("#" + id).attr("src", "../Images/black-arrow_down.png");
                }
                $("." + id).toggle();
            });
        });

        function showLoader() {
            $(function () {
                $("#overlay").show();
            });
            return true;
        }

        $(function () {
            function disableBack() { window.history.forward() }

            window.onload = disableBack();
            window.onpageshow = function (evt) { if (evt.persisted) disableBack() }
        });

        //prevent back when payment is receive from requester.
        function preventBack() {
            window.history.forward();
        }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <asp:UpdateProgress ID="updProgress"
        AssociatedUpdatePanelID="UpdatePanel1"
        runat="server">
        <ProgressTemplate>

            <style>
                #css1 {
                    position: fixed;
                    width: 100%;
                    max-height: 100%;
                    top: 0%;
                    left: 0%;
                    bottom: 0%;
                    right: 0%;
                    margin: auto;
                    display: block;
                    z-index: 9999;
                    background: rgba(0,0,0,.70);
                }

                .loading {
                    width: 50px;
                    height: 57px;
                    position: fixed;
                    top: 50%;
                    left: 50%;
                    margin: -28px 0 0 -25px;
                }
            </style>


            <div id="css1">
                <img src="../Images/loader.gif" class="loading" />
            </div>

        </ProgressTemplate>
    </asp:UpdateProgress>


    <div class="eknowid-bg">
        <div class="top-content">
            <div class="inner-bg">
                <div class="container">
                    <div class="row" style="margin-top: -40px;">
                        <div class="col-sm-4">
                            <div class="form-box">
                                <div class="form-top">
                                    <div class="form-top-left" style="margin-top: 10px; font-size: 20px; font-weight: bold; text-align: center;">
                                        <p>Fill the applicant information.</p>
                                    </div>
                                </div>
                                <div class="form-bottom">
                                    <div class="form-group">
                                        <label>First Name</label>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtCandiFirstName" runat="server" MaxLength="30" CssClass="form-control textbox charactersOnly text-shadow"></asp:TextBox>
                                        <div id="errorCandidateFirstName" class="Error"></div>
                                    </div>

                                    <div class="form-group">
                                        <label>Last Name</label>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtCandiLastName" runat="server" MaxLength="30" CssClass="form-control textbox charactersOnly"></asp:TextBox>
                                        <span id="errorCandidateLastName" class="Error"></span>
                                    </div>

                                    <div class="form-group">
                                        <label>Email</label>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtCandiEmail" runat="server" TextMode="Email" MaxLength="100" CssClass="form-control textbox">
                                        </asp:TextBox>
                                        <span id="errorCandidateEmail" class="Error"></span>
                                    </div>

                                    <div class="form-group">
                                        <label>Select your permissible purpose</label>
                                    </div>
                                    <div class="form-group">
                                        <asp:DropDownList ID="drpCandidate" runat="server" CssClass="form-control">
                                            <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem>For Employment</asp:ListItem>
                                            <asp:ListItem>For voluntary</asp:ListItem>
                                            <asp:ListItem>For Tenant</asp:ListItem>
                                        </asp:DropDownList>
                                        <span id="errorCandidatedropdown" class="Error"></span>
                                    </div>

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnRequesterCandidate" runat="server" CssClass="signup-button" Text="Run Candidate Check!" OnClientClick="return ValidationDetail();" OnClick="btnRequesterCandidate_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-7" style="margin-top: 100px; background-color: #ffffff; height: 510px; padding: 0px;">

                            <div class="row main-row">
                                <div class="col-sm-12">
                                    <div class="main-row-heading">
                                        Run Check On Existing Applicant
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-12" style="padding-left: 55px; margin-top: 30px;">
                                    <asp:GridView ID="gridExistsApplicant" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" Width="600px" AllowPaging="True" PageSize="8" OnPageIndexChanging="gridExistsApplicant_PageIndexChanging" CellSpacing="2" CssClass="border-none">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table>
                                                        <thead>
                                                            <tr>
                                                                <th class="table-header">First Name</th>
                                                                <th class="table-header">Last Name</th>
                                                            </tr>
                                                        </thead>
                                                    </table>
                                                </HeaderTemplate>

                                                <ItemTemplate>
                                                    <table class="table table-expandable table-striped">
                                                        <tbody>
                                                            <tr style="color: black;" class="data-header">
                                                                <td style="width: 300px;"><%# Eval("FirstName") %></td>
                                                                <td><%# Eval("LastName") %></td>
                                                                <td style="float: right; color: wheat">
                                                                    <img src="../Images/black-arrow_down.png" id='<%# Eval("Id") %>' style="cursor: pointer;" />
                                                                </td>

                                                                <asp:HiddenField ID="hdnFirstName" runat="server" Value='<%# Eval("FirstName") %>' />
                                                                <asp:HiddenField ID="hdnLastName" runat="server" Value='<%# Eval("LastName") %>' />
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" style="padding: 0px; border-style: none none none none;">
                                                                    <table border="0" style="border-bottom: 1px solid white; width: 100%; display: none;" class='<%# Eval("Id") %>'>
                                                                        <tbody style="background-color: #bcddf8; color: black;">
                                                                            <tr>
                                                                                <th style="padding-left: 10px;">Email Address</th>
                                                                                <th style="padding-left: 10px;">Screening Situation</th>
                                                                            </tr>

                                                                            <tr>
                                                                                <td style="padding-left: 10px;"><%# Eval("Email") %></td>
                                                                                <td style="padding-left: 10px;"><%# Eval("Description") %></t>
                                                                                <asp:HiddenField ID="hdnDescription" runat="server" Value='<%# Eval("Description") %>' />
                                                                                    <asp:HiddenField ID="hdnEmail" runat="server" Value='<%# Eval("Email") %>' />
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" style="padding: 10px; border-style: none none none none;">
                                                                                    <asp:LinkButton ID="lnkbtnRunChk" runat="server" CssClass="btn btn1 btn-default btn-applicant" OnClientClick="return showLoader();" OnClick="lnkbtnRunChk_Click">Run Check</asp:LinkButton>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ItemTemplate>

                                            </asp:TemplateField>

                                        </Columns>

                                        <EmptyDataRowStyle CssClass="emptyGrid-border" />
                                        <EmptyDataTemplate>
                                            <font class="emptyGrid">There are no applicants currently.</font>
                                        </EmptyDataTemplate>

                                        <FooterStyle BackColor="#fb5240" ForeColor="#8C4510" CssClass="pull-left" />
                                        <HeaderStyle BackColor="#fb5240" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle ForeColor="Black" BorderStyle="None" BackColor="White" HorizontalAlign="Left" CssClass="csspager GridPager" />
                                        <RowStyle BackColor="#404040" ForeColor="#ffffff" CssClass="border-bottom" />
                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
