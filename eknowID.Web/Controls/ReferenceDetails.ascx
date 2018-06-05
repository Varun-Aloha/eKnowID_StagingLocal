<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReferenceDetails.ascx.cs"
    Inherits="eknowID.Controls.ReferenceDetails" %>
<script type="text/javascript">
    $(function () {        
    var qty = Number($("[id*=referenceDetailsCount]").val());
        if(1 < qty)
        {
            for(var i=1; i< qty; i++)
            {
                $("[id*=ReferenceInfoContainer]").find("#btnAddRefRow").click();
            }
            $("[id*=ReferenceInfoContainer]").find("[id*=btnRemoveRefControl]").hide();
            $("[id*=ReferenceInfoContainer]").find("#btnAddRefRow").hide();
        }
});
</script>
<div style="height: auto;" class="width100per" id="ReferenceInfoContainer">
    <input id="referenceDetailsCount" type="hidden" value="" runat="server"/>
    <div id="referenceOriginal" class="width100per border1Solid padding21">
        <div class="floatRight removebtn" title="Remove" style="margin: -18px -8px 0px 0px; right: 0px;">
            <img src="../Images/close_20x20.png" alt="" class="remove" style="display: none;
               cursor: pointer;" id="btnRemoveRefControl" onclick="RemoveReferenceControl(this);" /></div>
        <div>
            <h3 class="margin_0px">
                Reference Details</h3>
        </div>
        <div  style="height: auto; overflow-x: auto;">
            <div id="referencetemp">
            </div>
            <div class="clearBoth" style="padding-bottom: 24px">
                <div class="width180 floatLeft clearBoth">
                    Type</div>
                <div class="floatLeft">
                    <asp:RadioButton ID="rdbProfessional_1" runat="server" Checked="true" Text="Professional" GroupName="grpRefType1"
                         ClientIDMode="Static" />
                    <asp:RadioButton ID="rdbPersonal_1"  runat="server" Text="Personal" GroupName="grpRefType1"
                        ClientIDMode="Static" />
                </div>
            </div>
            <div class="clearBoth">
                <div class="width180 floatLeft clearBoth">
                    Name</div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtName_1" runat="server" ClientIDMode="Static" CssClass="width180 required charSpaceOnly validateTab"
                        MaxLength="30"></asp:TextBox><span
                            class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Relationship
                </div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtRelationShip_1" runat="server" ClientIDMode="Static" CssClass="width180 required charSpaceOnly validateTab"
                        MaxLength="30"></asp:TextBox><span
                            class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Mobile Number
                </div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtNumber_1" runat="server" ClientIDMode="Static" CssClass="width180 required number digitsOnly validateTab"
                        MaxLength="10" minlength="10" ></asp:TextBox><span
                            class="red asterisk">*</span>
                </div>
            </div>
            <div class="clearBoth paddingTop5px">
                <div class="width180 floatLeft">
                    Years Known
                </div>
                <div class="floatLeft">
                    <asp:TextBox ID="txtYears_1" runat="server" ClientIDMode="Static" CssClass="width180 number digitsOnly validateTab"
                        MaxLength="3" ></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="hiddenContainer">
            <input type="hidden" class="referenceInfo" id="hdnreferenceInfo_1" />
        </div>
    </div>
    <div id="referenceContainer">
    </div>
    <div class="divAddNewRefRow width100per divBtnAddNewRef marginTop5" >
        <input id="btnAddRefRow" class="addNewRefRow floatRight" type="button" value="+ Add New" onclick="CreateRefControl();" style="margin-right:-51px;"/>
    </div>
</div>
