<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdditionalSkills.ascx.cs"
    Inherits="eknowID.Controls.AdditionalSkills" %>
<div class="PopUPMainContainer">
    <div>
        <h3>
            Additional Skills</h3>
    </div>
    <div style="height: 128px; overflow: auto;">
    <div id="skillOriginal" class="borderRadius6 AddNewBorder">
    <div class="floatRight removebtn" title="Remove" ><img src="../Images/close_20x20.png" alt="" class="remove" style="display:none;cursor:pointer;" id ="btn_1" onclick="RemoveSkillControl(this);"/></div>
            <div class="popupDivstyle">
                <div class="floatLeft width180">
                    Add Skills</div>
                <div style="float: left">
                    <asp:TextBox ID="txtSkills_1" runat="server" TextMode="MultiLine" CssClass="required width180" ClientIDMode="Static"
                        MaxLength="100" /></div>
            </div>
            <div class="hiddenContainer">
                <input type="hidden" class="additionalSkill" id="hdnadditionalSkillId_1" />
            </div>
         
            <div class="height25px clearBoth">
            </div>
        </div>
        <div id="skillContainer">
        </div>       
       <div class="clearBoth floatRight">
            <input id="Button1" class="addRow" type="button" value="+ Add New" style="background-color: #FFFFFF;
                border: medium none;" onclick="CreateSkillControl();" />
        </div>
    </div>
</div>
