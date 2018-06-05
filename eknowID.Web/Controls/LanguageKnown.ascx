<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LanguageKnown.ascx.cs"
    Inherits="eknowID.Controls.LanguageKnown" %>
<div class="PopUPMainContainer">
    <div>
        <h3>
            Languages Known</h3>
    </div>
    <div style="height: 100px; overflow: auto;">
    <div id="langOriginal" class="borderRadius6 AddNewBorder">
<div class="floatRight removebtn" title="Remove"><img src="../Images/close_20x20.png" alt="" class="remove" style="display:none;cursor:pointer;" id ="btn_1" onclick="RemoveLangControl(this);"/></div>
            <div class="popupDivstyle">
                <div class="floatLeft width180">
                    Add Language</div>
                <div style="float: left">
                    <asp:TextBox ID="txtLanguage_1" runat="server" ClientIDMode="Static" CssClass="width180 LettersWithSpace validateTab"
                        MaxLength="50" /></div>
            </div>
            <div class="hiddenContainer">
                <input type="hidden" class="languagesKnown" id="hdnlanguagesKnownId_1" />
            </div>
            
            <div class="height25px clearBoth">
            </div>
        </div>
        <div id="langContainer">
        </div>      
            <div class="floatRight clearBoth">
            <input id="Button1" class="addRow" type="button" value="+ Add New" style="background-color: #FFFFFF;
                border: medium none;" onclick="CreateLangControl();" />
        </div>
    </div>
</div>
