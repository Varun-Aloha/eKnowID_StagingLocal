<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopUp.aspx.cs" Inherits="eknowID.Pages.PopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-1.8.3.min.js" type="text/javascript"></script> 
    <script type="text/javascript" src="../Scripts/bpopUp.js"></script>
    <script type="text/javascript" src="../Scripts/UserScripts/openPopUp.js"></script>    
    <style type="text/css">
    .popup
        {
            display: none;
            background-color: transparent;
            width: 700px;
            height: 700px;
            border-radius: 6px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function checkPage() {


            var iframe = document.getElementById('IFrame1').contentWindow;
            var childText = iframe.document.getElementById('Label1').innerHTML;
            if (childText == "Drugs Verification Details") {

                document.getElementById('IFrame1').width = "645px";
               
            }
            else {
                document.getElementById('IFrame1').width = "600px";
                
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div >
    <input type="button" value="Continue" id="Continue" />
     </div>  
    <div id="Panel1" class="popup" >
    <iframe id="IFrame1" height="700px" width="600px"  src="Tabs.aspx" scrolling="no" frameborder="0"></iframe>
    </div>
    <div id="Panel2" class="popup">
    
    
    </div>
    </form>
</body>
</html>
