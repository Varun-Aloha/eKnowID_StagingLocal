<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RC_ProcessResume.aspx.cs"
    Inherits="eknowID.Pages.RC_ProcessResume" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.8.3.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <%--<script src="http://code.jquery.com/jquery-1.8.3.js" type="text/javascript"></script>--%>
    <%--<script src="http://code.jquery.com/ui/1.9.2/jquery-ui.js" type="text/javascript"></script>--%>
    <script src="../Scripts/bpopUp.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="../Scripts/UserScripts/LinkedInData.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function CloseRUpoadDiv() {
            window.parent.$("#divUploadResume").bPopup().close();
            $("#lblErrorMessage").attr("visible", "false");
        }
        function RedirectToSpellCheck() {
            window.top.location.href = "../Pages/RC_AnalysisSummary.aspx";
         }
        function ReloadPage() {
            //$.cookie('showPopup', 'False');
            $.cookie('showUploadResumeDialog', 'false');
            window.top.location.reload(true);
        }

        function ApplyWithResume() {
            $("#UploadResumeLinkedIn").css("display", "none");
            $("#UploadResumeManually").css("display", "block");
        }

        function ApplyWithLinkedIn() {
            $("#UploadResumeLinkedIn").css("display", "block");
            $("#UploadResumeManually").css("display", "none");
        }

        function validate() {
            var uploadcontrol = document.getElementById('fileUploadResume').value;
            //Regular Expression for fileupload control.
            //            var reg = /^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.doc|.docx|.DOC|.DOCX|.pdf|.PDF|.txt|.TXT|.html|.HTML|.rtf|.RTF)$/;
            var reg = /^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.txt|.TXT)$/;

            var validExtensions = new Array();

            var ext = uploadcontrol.substring(uploadcontrol.lastIndexOf('.') + 1).toLowerCase();
            if (uploadcontrol.length > 0) {
                validExtensions[0] = "doc";
                validExtensions[1] = "DOC";
                validExtensions[2] = "docx";
                validExtensions[3] = "DOCX";
                validExtensions[4] = "pdf";
                validExtensions[5] = "PDF";
                validExtensions[6] = "txt";
                validExtensions[7] = "TXT";
                validExtensions[8] = "rtf";
                validExtensions[9] = "RTF";
                validExtensions[10] = "html";
                validExtensions[11] = "HTML";
                validExtensions[12] = "htm";
                validExtensions[13] = ".html";
                for (var i = 0; i < validExtensions.length; i++) {

                    if (ext == validExtensions[i])
                        return true;

                }
                document.getElementById("divUpload").innerHTML = document.getElementById("divUpload").innerHTML;
                alert("Only .doc, docx, .pdf, .txt, .html, .rtf files are allowed!");
                return false;
            }
            else {

                alert("Please Choose File");
                return false;
            }



            //            if (uploadcontrol.length > 0) {
            //                //Checks with the control value.
            //                if (reg.test(uploadcontrol)) {
            //                    return true;
            //                }
            //                else {
            //                    //If the condition not satisfied shows error message.
            //                    document.getElementById("divUpload").innerHTML = document.getElementById("divUpload").innerHTML;
            //                    alert("Only .doc, docx, .pdf, .txt, .html, .rtf files are allowed!");
            //                    return false;
            //                }
            //            }
            //            else {
            //                alert("Please Choose File");
            //                return false;
            //            }
        } //End of function validate.
    </script>
    <script type="text/javascript">

        var validFilesTypes = ["doc", "docx", "rtf", "pdf", "odt", "txt", "html"];

        function ValidateFile() {
            var file = document.getElementById("<%=fileUploadResume.ClientID%>");


            var path = file.value;

            if (path == "") {
                alert("Please select file. \nFollowing file types are supported :\n\n" + validFilesTypes.join(", "))
                return false;
            }

            var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();

            var isValidFile = false;

            for (var i = 0; i < validFilesTypes.length; i++) {

                if (ext == validFilesTypes[i]) {

                    isValidFile = true;

                    break;

                }

            }

            if (!isValidFile) {

                //            label.style.color = "red";

                //            label.innerHTML = "Invalid File. Please upload a File with" +

                alert("Following file types are supported :\n\n" + validFilesTypes.join(", "));

            }

            return isValidFile;

        }

    </script>

</head>
<body style="overflow: hidden">
    <form id="form1" runat="server">
    <br />
    <div class="clearBoth" id="divUpload">
        <asp:FileUpload ID="fileUploadResume" runat="server" ClientIDMode="Static"/>
    </div>
    <div class="marginTop15">
        <asp:Button ID="btnImportResume" Style="float: right !important;" runat="server" CssClass="floatRight uploadResumeProceed"
            Text="" OnClick="btnImportResume_Click" OnClientClick="return ValidateFile()" />
    </div>
    <br />
    <br />
    <div class="width100per">
        <asp:Label ID="lblErrorMessage" runat="server" Visible="true" ClientIDMode="Static" />
    </div>
    </form>
</body>
</html>
