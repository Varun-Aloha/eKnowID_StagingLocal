<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SampleReport1.ascx.cs" Inherits="eknowID.Controls.SampleReport1" %>
<style type="text/css">
    /*.reportBorder
    {
        border: 1px solid gray;
        border-radius: 5px;
    }*/
    
       
   
    .title
    {
        width: 130px;
        font-weight: bold;
        float: left;
    }
    
   
</style>

<div class="padding15">
    <div class="clearBoth reportBorder">
        <div class="lnkColor boldText reportHeadingbg marginBottom50">
            Report Summary
        </div>
        <div class="padding10">
            <div class="floatLeft paddingLeft10 marginleft20">
                <img src="../Images/report_user_img.png" height="180px" class="width180" alt="" />
            </div>
            <div class="floatLeft basicDetails">
                <div class="clearBoth">
                    <div class="title">
                        First Name:</div>
                    <asp:Label ID="lblFirstName" runat="server" Text="John" /></div>
                <div class="clearBoth">
                    <div class="title">
                        Middle Initial:</div>
                    <asp:Label ID="lblMidNameIni" runat="server" Text="" /></div>
                <div class="clearBoth">
                    <div class="title">
                        Last Name:</div>
                    <asp:Label ID="lblLastName" runat="server" Text="Doe" /></div>
                <div class="clearBoth">
                    <div class="title">
                        Aliases:</div>
                    <asp:Label ID="lblAlias" runat="server" Text="John" /></div>
                <div class="clearBoth">
                    <div class="title">
                        Date of Birth:</div>
                    <asp:Label ID="lblDOB" runat="server" Text="XX-XX-04" /></div>
                <div class="clearBoth">
                    <div class="title">
                        Age:</div>
                    <asp:Label ID="lblAge" runat="server" Text="XX" /></div>
            </div>
            <div class="floatRight lightgrayBackGround" id="fileDetails">
                <div class="floatLeft">
                    <div class="marginTop26">
                        <div class="title">
                            File Number:</div>
                        <asp:Label ID="lblFileNumber" runat="server" Text="12463" /></div>
                    <div class="marginTop20">
                        <div class="title">
                            Report To:</div>
                        <asp:Label ID="lblReportTo" runat="server" CssClass="alignRight" Text="Demo Kentech(Demo)<br />200 S Wacker <br/>Chicago, II 60606<br/>phone :<br /> Fax:"
                            Height="155px" /></div>
                </div>
                <div class="floatLeft marginleft20">
                    <div class="marginTop26">
                        <div class="title">
                            Report Date:</div>
                        <asp:Label ID="lblReportDate" runat="server" Text="03-16-2011" /></div>
                    <div class="marginTop20">
                        <div class="title">
                            Order Date:</div>
                        <asp:Label ID="lblOrderDate" runat="server" Text="02-17-2011" /></div>
                    <div class="marginTop20">
                        <div class="title">
                            Type:</div>
                        <asp:Label ID="lblType" CssClass="alignRight" runat="server" Text="NJ COPS <br /> NATIONWIDE"
                            Font-Underline="False" /></div>
                </div>
            </div>
        </div>
        <div class="clearBoth padding15  marginTop200" >
            <div class="contentColor" style="height: 150px">
                <div class="lnkColor boldText reportHeadingbg reportContentBorder">
                    Report Content</div>
                <div style="margin-top:30px;margin-left:30px">
                    <div class="floatLeft">
                      <div class="floatLeft"><img src="../Images/identity_verification_img.png" alt="" /></div> 
                      <div class="floatLeft boldText imgTextMargin">   Identity Verification </div>
                    </div>
                    <div class="floatLeft marginLeft100" >
                     <div class="floatLeft"><img src="../Images/address_history_img.png" alt="" /></div>
                      <div class="floatLeft boldText imgTextMargin">  Address History </div>
                    </div>
                    <div class="floatLeft marginLeft100">
                       <div class="floatLeft"> <img src="../Images/nationwide_criminal_img.png" alt="" /></div>
                       <div class="floatLeft boldText imgTextMargin"> Nationwide Criminal Check</div>
                    </div>
                </div>
            </div>
            <div class="clearBoth contentBorder contentColor padding15 marginTop20">
                <h3>
                    What is Background Report?</h3>
                <p>
                    In basic Terms , a background check is finding a collection of information on a
                    particular individual. This information is collected from publicly available information
                    and is done within the constriant of the law. Background checks will uncover various
                    facets of information on an individual such as thier legal name,address, workspace
                    and so much more
                </p>
            </div>
        </div>
    </div>
    <div style="margin-top: 50px;" class="reportBorder">
        <div class="reportContentBg">
        <div class="floatLeft">
         <div class="floatLeft"><img src="../Images/identity_verification_img.png" alt="" class="reportImg"/></div>
          <div class="floatLeft boldText lnkColor imgTextMargin">Identity Verification </div></div>
          <div class="floatRight arrowDown"><img src="../Images/arrow_icon_bottom.png" alt="" /></div>
        </div>
        
        <div class="padding15 clearBoth">
            <asp:GridView ID="grvIdentity" runat="server" GridLines="Horizontal" CssClass="blueBorder width100per" AutoGenerateColumns="False"
                ClientIDMode="Static">
                <AlternatingRowStyle CssClass="alternaterowcolor blueBorder" />
                <HeaderStyle CssClass="grvHeaderStyle  gridHeaderBg blueBorder" />
                <RowStyle CssClass="grvRowStyle blueBorder" />
                <Columns>
                    <asp:BoundField DataField="Sno" ItemStyle-CssClass="grvFirstColumn" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="DateofBirth" HeaderText="Date of Birth" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="Age" HeaderText="Age" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="Alias" HeaderText="Alias" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="SSN" HeaderText="SSN" HeaderStyle-HorizontalAlign="Left" />
                    
                </Columns>
            </asp:GridView>
        </div>
        <div class="padding15">
            WARNING: This search may not be used as the basis for an adverse action on an applicant.It
            should only be used to verify or correct an applican't information, or as a tool
            to further research of public records or other verifications
        </div>
    </div>
</div>
