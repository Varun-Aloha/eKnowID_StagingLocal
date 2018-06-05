<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SampleReport3.ascx.cs" Inherits="eknowID.Controls.SampleReport3" %>
<style type="text/css">
   
    .title
     {
       font-weight:bold;
       width:176px; 
       float:left;   
     }
     
    </style>

<div class="padding15">
       <div class="reportBorder" style="padding:20px">
        <center><h3 class="underline"> Putnam County</h3></center>
        <div class="blueBorder" id="PutnamDataDiv">
           <div class="gridHeaderBg boldText">
          <div style="float:left;margin-left:21px">Offender</div>
          <div style="float:right;margin-right:465px;">Offense</div>
           </div>
           <div class="putnamLeftData">
           <div class="marginTop5"><div class="leftTitleWidth floatLeft boldText">First Name:</div> <asp:Label runat="server" ID="lblFirstName" Text="John,Doe" /> </div>
           <div class="marginTop5"><div class="leftTitleWidth floatLeft boldText">Dob:</div> <asp:Label runat="server" ID="lblDOB" Text="XXXX-04-27" />	 </div>
           <div class="marginTop5"><div class="leftTitleWidth floatLeft boldText">Address:</div><asp:Label runat="server" CssClass="alignRight" ID="lblAddress" Text=" 136 SANT ABARBARA STREET EAST<br />PALATKA, FL 32131-0000" /> </div>
           <div class="clearBoth marginTop5"><div class="leftTitleWidth floatLeft boldText">Provider:</div><asp:Label runat="server" ID="lblProvider" Text="Putnam County" /> </div>
           <div class="marginTop5"><div class="leftTitleWidth floatLeft boldText">State:</div><asp:Label runat="server" ID="lblState" Text="FL" /></div>
           </div>
           

            <div class="putnamRightData">
            <div class="marginTop5"><div class="title">Description:</div><asp:Label runat="server" ID="lblDescription" Text="ISSUING A WORTHLESS CHECK" /></div>
            <div class="marginTop5"><div class="title"> Disposition Description:</div><asp:Label runat="server" ID="lblDispostion" Text="ADJUDICATED GUILTY/DELINQUENT" /></div>
            <div class="marginTop5"><div class="title"> File Date:</div><asp:Label runat="server" ID="lblFileDate" Text="2003-03-10" /></div>
            <div class="marginTop5"><div class="title"> Origin:</div><asp:Label runat="server" ID="lblCrime" Text="Crime" /></div>
            <div class="marginTop5"><div class="title"> Statute Code:</div><asp:Label runat="server" ID="lblStatute" Text="2208" /></div>
            <div class="marginTop5"><div class="title"> Case Number:</div><asp:Label runat="server" ID="lblCaseNo" Text="11103001093YYYA" /></div>
            <div class="marginTop5"><div class="title"> Court Decision Date:</div><asp:Label runat="server" ID="lblCourtDate" Text="2003-06-25" /></div>
            <div class="marginTop5"><div class="title">Prosecution Decision Date:</div><asp:Label runat="server" ID="lblProsecutionDate" Text="2003-03-10" /></div>
            </div>
            </div>

            <div class="marginTop20 clearBoth alignJustify" >
            WARNING: Based on the information provided EKNOWID searched for public records in the sources referenced herein for criminal history information as permitted by federal and state law. 'Record Found' means that our researches found a record(s) in that jurisdication that matched the personal identifiers (i.e., Name, SSN, Date of Birth, Address) listed for the subject in the above abstract.EKNOWID does not guarantee the accuracy or the thuthfulness of the information as to the subject of the investigation, but only that it is accurately copied from public records. Information generated as a result of identity theft, including evidence of criminal activity, may be inaccurately associated with the consumer who is subject of this report. Further investigation into additional jurisdications, or utilization of additional identifying information, may be warranted. Please call for assistance
            </div>
        </div>
      
        <div class="marginTop30px">
         <div class="lnkColor boldText alignJustify">Disclaimer</div>
         <div style="margin-top:10px;">This report is furnished to you pursuant to the Agreement for Service between the parties and in complaince with the Fair Credit Reporting Act. This report is furnished based upon ypu certification that you have a permissible purpose to obtain the report. the information contained herein was obtained in good faith from sources deemed reliable, but the completeness or accuracy is not guaranteed </div>
        </div>
    </div>