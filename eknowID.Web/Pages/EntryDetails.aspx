<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntryDetails.aspx.cs" Inherits="eknowID.Pages.EntryDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>     
    <script type="text/javascript" src="../Scripts/bpopUp.js"></script>
    <script type="text/javascript" src="../Scripts/UserScripts/openPopUp.js"></script>
     <style type="text/css">
     #Panel1
        {
            display: none;
            background-color:transparent;
            width: 650px;
            height: 700px;
            border-radius: 6px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div >
    <input type="button" value="Continue" id="Continue" />
     </div>  
    
    <div id ="Panel1">
    <iframe height="700px" width="650px" src="Tabs.aspx" scrolling="auto" frameborder="0"></iframe>
    </div>
    </form>
</body>
</html>
