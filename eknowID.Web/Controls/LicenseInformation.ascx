<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LicenseInformation.ascx.cs"
    Inherits="eknowID.Controls.LicenseInformation" %>
<%@ Register Src="stateDropdown.ascx" TagName="stateDropdown" TagPrefix="uc1" %>
<!--[if lt IE 9]>
<script src="../Scripts/Tooltip/jquery.bgiframe.min.js" type="text/javascript"></script>
<script src="../Scripts/Tooltip/excanvas.js" type="text/javascript"></script>
<![endif]-->
<script src="../Scripts/Tooltip/jquery.bt.min.js" type="text/javascript"></script>
<link href="../Styles/jquery.bt.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript">
    $(function () {
        var stateId = $('#ddlStateLicenseInfo select').val();
        var errorMsg = "Please select the state."
        if (stateId != 0) {
            errorMsg = $("#hdnErrorMessage").val();
        }
        $('#txtNumber').bt(errorMsg, {
            trigger: ['focus', 'blur'],
            positions: ['right'],
            fill: 'Gray'
        });
    });
</script>
<div  class="width100per border1Solid padding21" id="LicenseInfoContainer">
    
        <h3 class="margin_0px">
            License Information</h3>

    <div  style="height: 85px;">
        <div class="clearBoth paddingTop5px">
            <div class="width180 floatLeft">
                State/Region
            </div>
            <div class="floatLeft width245" id="ddlStateLicenseInfo">
                <uc1:stateDropdown ID="ddlStateLicense" runat="server" /><span
                            class="red asterisk">*</span>
            </div>
        </div>
        <div class="clearBoth paddingTop5px">
            <div class="width180 floatLeft">
                License Number</div>
            <div class="floatLeft">
                <asp:TextBox ID="txtNumber" runat="server" ClientIDMode="Static" CssClass="width180 required alt-target validateTab"
                    MaxLength="30" title="" onchange="CheckIfValid();"></asp:TextBox><span
                            class="red asterisk">*</span>
            </div>
        </div>
        <div class="clearBoth paddingTop5px">
            <div class="width180 floatLeft">
                License Name
            </div>
            <div class="floatLeft">
                <asp:TextBox ID="txtName" runat="server" ClientIDMode="Static" CssClass="width180 required validateTab"
                    MaxLength="30"></asp:TextBox><span
                            class="red asterisk">*</span>
            </div>
        </div>
        <!--<div class="clearBoth paddingTop5px">
            <div class="width180 floatLeft">
                Licensing Agency
            </div>
            <div class="floatLeft">
                <asp:TextBox ID="txtAgency" runat="server" ClientIDMode="Static"
                    CssClass="width180 required validateTab" MaxLength="30"></asp:TextBox>
                
            </div>
        </div> -->
    </div>
    <input type="hidden" id="hdnRegularExp" runat="server" clientidmode="Static" />
    <input type="hidden" id="hdnIsSSN" runat="server" clientidmode="Static" />
    <input type="hidden" id="hdnIsLoggedIn" runat="server" clientidmode="Static" />
    <input type="hidden" id="hdnSSN" runat="server" clientidmode="Static" />
    <input type="hidden" id="hdnErrorMessage" value="" runat="server" clientidmode="Static" />
</div>
