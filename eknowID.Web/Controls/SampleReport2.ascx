<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SampleReport2.ascx.cs" Inherits="eknowID.Controls.SampleReport2" %>
<style type="text/css">
    .title
     {
       font-weight:bold;
       width:180px; 
       float:left;   
     }
     
        </style>


<div class="padding15">
        <div class="reportBorder" >
            <div class="reportContentBg">
        <div class="floatLeft">
         <div class="floatLeft"><img src="../Images/address_history_img.png" alt="" class="reportImg" /></div>
          <div class="floatLeft boldText lnkColor imgTextMargin">Address History </div></div>
          <div class="floatRight arrowDown"><img src="../Images/arrow_icon_bottom.png" alt="" /></div>
        </div>
            <div class="marginTop15 padding15" >
                <asp:GridView ID="grvAddressHistory" runat="server"  CssClass="blueBorder width100per" GridLines="Horizontal" 
                    AutoGenerateColumns="false">
                <AlternatingRowStyle CssClass="alternaterowcolor blueBorder" />
                <HeaderStyle  CssClass="grvHeaderStyle gridHeaderBg blueBorder " />
                <RowStyle CssClass="grvRowStyle blueBorder"/>
                    <Columns>
                        <asp:BoundField DataField="Sno" ItemStyle-CssClass="grvFirstColumn" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Address"  HeaderText="Address" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="Dates" HeaderText="Dates" HeaderStyle-HorizontalAlign="Left" />
                        <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/report-grid-data.png" />
                    </Columns>
                  
                </asp:GridView>
            </div>
            <div class="padding15">
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
        <div class="reportBorder marginTop30px">
            <div class="reportContentBg">
        <div class="floatLeft">
         <div class="floatLeft"><img src="../Images/nationwide_criminal_img.png" alt="" class="reportImg" /></div>
          <div class="floatLeft boldText lnkColor imgTextMargin">National Criminal Record Check </div></div>
         <div class="floatRight arrowDown"><img src="../Images/arrow_icon_bottom.png" alt="" /></div>
        </div>
            <div class="marginTop15 padding15">
            <div class="floatLeft">
                <div class="marginTop5">
                   <div class="title">Results :</div><asp:Label ID="lblResults" runat="server" Text="Record Found" /></div>
                <div class="marginTop5">
                   <div class="title">Name Searched:</div><asp:Label ID="lblName" runat="server" Text="John, Doe" /></div>
                <div class="marginTop5">
                    <div class="title">Dob Searched:</div><asp:Label ID="lblDob" runat="server" Text="09-09-XXXX" /></div>
                <div class="marginTop5">
                   <div class="title">Jurisdiction:</div><asp:Label ID="lblJurisdication" runat="server" Text="NATIONWIDE" /></div>
                </div> 
                <div class="floatLeft" style="margin-left:100px;">
                <div class="marginTop5">
                    <div class="title">Search Date:</div><asp:Label ID="lblsearchDate" runat="server" Text="03-16-2011 8:23 AM MDT" /></div>
                <div class="marginTop5">
                    <div class="title">Search Scope:</div><asp:Label ID="lblSearchScope" runat="server" Text="N/A" /></div>
                  </div>
            </div>
            <div class="padding15 clearBoth" style="margin-top:70px">
                The search you have selected is a search of our criminal database(s) and may not
                report 100% coverage of all criminal records in all jurisdictions and/or sources.
                Coverage details available upon request
            </div>
          <center> <h3 class="underline">
                Florida Dept of Corrections</h3></center>
            <div  class="blueBorder" id="FloridaDataDiv">
                 <div class="gridHeaderBg boldText" >
                 <div class="floatLeft leftTitle">Offender</div>
                 <div class="floatRight rightTitle">Offense</div>
                 </div>  
                 <%-- <div class="clearBoth">    
                <div class=" floatLeft" style="margin-left:60px">
                    
                    <div class="marginTop5">
                       <div class="title">First Name:</div><asp:Label ID="lblFirstName" runat="server" Text="MESS, HANK" />
                    </div>
                    <div class="marginTop5">
                       <div class="title">DOB:</div> <asp:Label ID="lblBirthdate" runat="server" Text="XXXX-04-27" />
                    </div>
                    <div class="marginTop5">
                       <div class="title">Gender:</div><asp:Label ID="lblGender" runat="server" Text="Male" />
                    </div>
                    <div class="marginTop5">
                       <div class="title">Race:</div><asp:Label ID="lblRace" runat="server" Text="White" />
                    </div>
                    <div class="marginTop5">
                       <div class="title">Height:</div><asp:Label ID="lblHeight" runat="server" Text="5 9"/>
                    </div >
                    <div class="marginTop5">
                       <div class="title">Weight:</div><asp:Label ID="lblWeight" runat="server" Text="165" />
                    </div>
                    <div class="marginTop5">
                       <div class="title">Hair Color:</div><asp:Label ID="lblHairColor" runat="server"  Text="Brown"/></div>
                    <div class="marginTop5">
                       <div class="title">Eye Color:</div><asp:Label ID="lblEyeColor" runat="server" Text="Brown"/>
                    </div>
                    <div class="marginTop5">
                       <div class="title">Provider:</div><asp:Label ID="lblProvider" runat="server" Text="Florida Dept of Corrections"/>
                    </div>
                    <div class="marginTop5">
                       <div class="title">State:</div><asp:Label ID="lblState" runat="server" Text="FL"/>
                    </div>
                </div>
                <div class="floatRight marginRight45">
                    
                        <div class="clearBoth marginTop5 "><div class="title">Desciption:</div><asp:Label ID="lbldesc" runat="server" Text="COCAINE - POSSESSION" /> </div>
                        <div class="clearBoth marginTop5"><div class="title">Offense Date:</div><asp:Label ID="lbloffenseDt" runat="server" Text="2006-03-05" /> </div>
                        <div class="clearBoth marginTop5"><div class="title">Origin:</div><asp:Label ID="lblOrigin1" runat="server" Text="Crime"/></div>
                        <div class="clearBoth marginTop5"><div class="title">Country:</div><asp:Label ID="lblCountry" runat="server" Text="PUTNAM"/> </div>
                        <div class="clearBoth marginTop5"><div class="title">Custody:</div><asp:Label ID="lblCustody" runat="server" Text="Supervision Type: Drug Offender Probation"/> </div>
                        <div class="clearBoth marginTop5"><div class="title">Community Sentense Date:</div><asp:Label ID="lblCsDate" runat="server" Text="2006-11-22"/> </div>
                        <div class="clearBoth marginTop5"><div class="title">In-Custody Date:</div><asp:Label ID="lblInCustDt" runat="server" Text="2006-11-22"/> </div>
                        <div class="clearBoth marginTop5"><div class="title">Community Supervision Length:</div><asp:Label ID="lblCSL" runat="server" Text="Y 18M 0D"/> </div>
                        <div class="clearBoth marginTop5"><div class="title">Classification Status:</div><asp:Label ID="lblCStatus" runat="server" Text="SUSPENSE"/> </div>
                        <div class="clearBoth marginTop5"><div class="title">Current As Of Date:</div><asp:Label ID="lblCaoDt" runat="server" Text="2009-04-01"/> </div>
                        <div class="clearBoth marginTop5"><div class="title">Communtity Case Number:</div><asp:Label ID="lblCCaseNo" runat="server" Text="1110600525"/> </div>
                        <div class="clearBoth marginTop5"><div class="title">Data Type:</div><asp:Label ID="lblDataType" runat="server" Text="1"/> </div>
                        <div class="clearBoth marginTop5"><div class="title">Verified Address:</div><asp:Label ID="lblVerifiedAdd" runat="server" Text="130 ORIE GRIFFIN BLVD PUTNAM COUNT"/> </div>
                        <div class="clearBoth marginTop5"><div class="title">Origin:</div><asp:Label ID="lblOrigin2" runat="server" Text="ARREST"/> </div>
                        <div class="clearBoth marginTop5"><div class="title">Scheduled Termination Date:</div><asp:Label ID="lblSTDate" runat="server" Text="2008-05-21"/> </div>
                        <div class="clearBoth marginTop5"><div class="title">Current Location:</div><asp:Label ID="lblCLocation" runat="server" Text="DAYTONA BEACH"/> </div>
                        

                </div>
                </div>--%>
                 <div class="clearBoth marginTop20 dataContainer">
                  <div class="floatLeft leftDataContainer" >
                     <div class="floatLeft boldText leftTitleWidth">
                         <div>First Name:</div>
                         <div>DOB:</div> 
                         <div>Gender:</div> 
                         <div>Race:</div> 
                         <div>Height:</div>
                         <div>Weight:</div>
                         <div>Hair Color:</div> 
                         <div>Eye Color:</div>
                         <div>Provider:</div>
                         <div>State:</div>        
                     </div>
                     <div class="floatLeft">
                         <div>John, Doe</div>
                         <div>XXXX-04-27</div> 
                         <div>Male</div> 
                         <div>White</div> 
                         <div>5 9</div>
                         <div>165</div>
                         <div>Brown</div> 
                         <div>Brown</div>
                         <div>Florida Dept of Corrections</div>
                         <div>FL</div>        
                     </div>
                  </div>
                 
                  <div class="floatRight rightDataContainer">
                    <div class="floatLeft boldText rightTitleWidth">
                    <div>Description:</div>
                    <div>Offense Date:</div>
                    <div>Origin:</div>
                    <div>Country:</div>
                    <div>Custody:</div>
                    <div>Community Sentense Date:</div>
                    <div>In-Custody Date:</div>
                    <div>Community Supervision Length:</div>
                    <div>Classification Status:</div>
                    <div>Current As Of Date:</div>
                    <div>Communtity Case Number:</div>
                    <div>Data Type:</div>
                    <div>Verified Address:</div>
                    <div>Origin:</div>
                    <div>Scheduled Termination Date:</div>
                    <div>Current Location:</div>
                    </div>
                    <div class="floatLeft">
                    <div>COCAINE - POSSESSION</div>
                    <div>2006-03-05</div>
                    <div>Crime</div>
                    <div>PUTNAM</div>
                    <div>Supervision Type: Drug Offender Probation</div>
                    <div>2006-11-22</div>
                    <div>2006-11-22</div>
                    <div>Y 18M 0D</div>
                    <div>SUSPENSE</div>
                    <div>2009-04-01</div>
                    <div>1110600525</div>
                    <div>1</div>
                    <div>130 ORIE GRIFFIN BLVD PUTNAM COUNT</div>
                    <div>ARREST</div>
                    <div>2008-05-21</div>
                    <div>DAYTONA BEACH</div>
                    </div>
                  </div>
                 
                 </div>
                
            </div>
        </div>
    </div>