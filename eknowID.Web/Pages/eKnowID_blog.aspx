<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eKnowID_blog.aspx.cs" Inherits="eknowID.Pages.eKnowID_blog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .blogIfreme
        {
            height: 726px;
            margin-bottom: 0;
            margin-top: -14px;
            padding-bottom: 0;
            width: 100.5%;
        }
        body
        {
            margin: 15px 8px 0;
            height:auto !important;
        }
    </style>
</head>
<body style="overflow:hidden;">
    <form id="form1" runat="server">
    <div>
        <iframe src="http://eknowid.wordpress.com/" width="100%" height="100%" id="iframe1"
            marginheight="0" frameborder="0" class='blogIfreme'></iframe>
    </div>
    </form>
</body>
</html>
