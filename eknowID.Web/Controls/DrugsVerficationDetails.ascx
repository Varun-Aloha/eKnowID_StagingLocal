<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DrugsVerficationDetails.ascx.cs"
    Inherits="eknowID.Controls.DrugsVerficationDetails" %>
<div class="PopUPMainContainer" style="padding-top: 15px">
    Once you purchase the selected package, an email would be sent containing the details
    of <span style="color: Green; font-weight: bold">HOW & WHERE</span> the Drug verification
    will be carried out. EknowID request you to follow the instructions given in the
    mail carefully
    <div class="lightgrayBackGround popupDivstyle" style="height: 200px; margin-top: 12px">
        <div class="floatLeft">
            <img src="../Images/drug_img.png" alt="" />
        </div>
        <div class="floatLeft" style="margin-left: 10px; line-height: 24px;">
            <div>
                <b>DRUG TESTING</b></div>
            <div>
                The 5 Panel Drug Test will test for the following Drugs:</div>
            <div>
                -Amphetamines
            </div>
            <div>
                -Cocaine</div>
            <div>
                -Marijuana</div>
            <div>
                -Opiates</div>
            <div>
                -PCP (Phencyclidine)</div>
            <div class="width260">
                <div class="floatLeft paddingLeft4">
                    Purpose of Visit :
                </div>
                <div class="floatLeft paddingLeft15">
                    <asp:DropDownList ID="ddlDrugVerification" runat="server"  ClientIDMode="Static"/>
                </div>
            </div>
        </div>
    </div>
</div>
