<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSampleReport.aspx.cs" Inherits="eknowID.Pages.ViewSampleReport" %>
<%@ Register Src="~/Controls/SampleReport1.ascx" TagName="SampleReport1" TagPrefix="SR1" %>
<%@ Register Src="~/Controls/SampleReport2.ascx" TagName="SampleReport2" TagPrefix="SR2" %>
<%@ Register Src="~/Controls/SampleReport3.ascx" TagName="SampleReport3" TagPrefix="SR3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
   
    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <%--<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.0/themes/base/jquery-ui.css" />--%>
  <%--<script src="http://code.jquery.com/jquery-1.8.3.js"></script>--%>
  <%--<script src="http://code.jquery.com/ui/1.10.0/jquery-ui.js"></script>--%>
    <link href="../Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();

            // fix the classes
            $(".tabs-bottom .ui-tabs-nav, .tabs-bottom .ui-tabs-nav > *")
      .removeClass("ui-corner-all ui-corner-top")
      .addClass("ui-corner-bottom");

            // move the nav to the bottom
            $(".tabs-bottom .ui-tabs-nav").appendTo(".tabs-bottom");
        });
  </script>
     <style type="text/css">
  /* force a height so the tabs don't jump as content height changes */
  #tabs .tabs-spacer {  height: 200px; }
  .tabs-bottom .ui-tabs-nav { clear: left; padding: 0 .2em .2em .2em; }
  .tabs-bottom .ui-tabs-nav li { top: auto; bottom: 0; margin: 0 .2em 1px 0; border-bottom: auto; border-top: 0; }
  .tabs-bottom .ui-tabs-nav li.ui-tabs-active { margin-top: -1px; padding-top: 1px; }
  
  .ui-widget-header
  {
     background:none;    
     border:none;
      
  }
  .ui-tabs .ui-tabs-nav li
  {
    border:none;    
   
  }
  .ui-widget
  {
     font:inherit;
         
  }
  
   .ui-tabs-nav li.ui-tabs-active a
    {
        background-image:url(../Images/pegination_selected_img.png);
     }
  
    a
    {
        width:22px;
        height:22px;
        border:none;
        background-repeat:no-repeat;
        margin-left:3px;    
    }
    
    .ui-tabs .ui-tabs-nav li a
    {
      background-image:url(../Images/pegination_normal_img.png);  
      font-weight:bold; 
      /*margin-left: 6px;
      margin-top: 3px;   */
    }
 
  </style>

<!--[if gte IE 8]>
	<style type="text/css">
        .reportGridButtons
       {
          margin-right:10px !important;
       }
    </style>
<![endif]-->

</head>
<body onload="parent.scrolltop()" style="height:auto">
    <form id="form1" runat="server">
    <div style="border:3px solid Gray;
            border-radius:5px;background:White;" class="width100per">
     
         <div id="reportHeader">
            <div class="floatLeft">
                <img src="../Images/site_logo2.png" alt=""/>
            </div>
            <div class="floatRight">
                <span class="boldText" style="color: Maroon">EKnowID</span><br />
                200 S WACKER<br />
                15 TH FLR<br />
                Chicago, IL 60606<br />
                Phone: 312-780-0470 / 888-749-2432<br />
                Fax: 312-276-8989<br />
                
            </div>
            <%--<div class="bClose"></div>--%>
        </div>
        <div class="clearBoth reportTop">
           <center><h2> Background Screening Report on 
            <asp:Label ID="lblFname" runat="server" Text="John" />,
            <asp:Label ID="lblLname" runat="server" Text="Doe" /> March 16,2011</h2></center>
        </div>
        <asp:MultiView ID="mvReports" runat="server" ActiveViewIndex="0">
            <asp:View ID="Report1" runat="server">
            <SR1:SampleReport1 runat="server" ID="SmpleRpt1" />
            </asp:View>
            <asp:View ID="Report2" runat="server">
             <SR2:SampleReport2 runat="server" ID="SmpleRpt2" />
            </asp:View>
            <asp:View ID="Report3" runat="server">
            <SR3:SampleReport3 runat="server" ID="SmpleRpt3" />
            </asp:View>
        </asp:MultiView>

        <div style="height:45px;padding-right:5px;">
        <div class="floatRight reportGridButtons" id="reportGridButtons">
             <div class="floatLeft"><asp:Button ID="btnTab1" CssClass="reportButtonClicked" 
                     runat="server" Text="1" onclick="btnTab1_Click" OnClientClick="parent.page1height();" /></div>
             <div class="floatLeft"><asp:Button ID="btnTab2" CssClass="reportButtonInitial" 
                     runat="server" Text="2" onclick="btnTab2_Click"  OnClientClick="parent.page2height();" /></div>
             <div class="floatLeft"><asp:Button ID="btnTab3" CssClass="reportButtonInitial" 
                     runat="server" Text="3" onclick="btnTab3_Click"  OnClientClick="parent.page3height();" /></div>
       </div>
        </div>

<%-- <div id="tabs" class="tabs-bottom" style="border:none">
  <div id="tabs-1">
     <SR1:SampleReport1 runat="server" ID="SmpleRpt21" />
  </div>
  <div id="tabs-2">
    <SR2:SampleReport2 runat="server" ID="SmpleRpt22" />
  </div>
  <div id="tabs-3">
    <SR3:SampleReport3 runat="server" ID="SmpleRpt23" />
  </div>
  <ul class="floatRight" >
    <li><a href="#tabs-1" >1</a></li>
    <li><a href="#tabs-2">2</a></li>
    <li><a href="#tabs-3">3</a></li>
  </ul>
        </div>--%>
<%-- <div class="clearBoth"></div>--%>
    </div>
    </form>
</body>
</html>
