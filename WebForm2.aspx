<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ImageMVC.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body style="height: 500px">
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Back to Gallery" OnClick="Button1_Click" />
            <br /><br />
            <asp:Image ID="Image1" runat="server" />
            <br /><br/>
             <asp:Button ID="Button2" runat="server" Text="Back to Gallery" OnClick="Button1_Click" />
            <br /><br/>
        </div>
    </form>
</body>
</html>
