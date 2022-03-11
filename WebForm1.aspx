<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ImageMVC.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 111px; margin-bottom: 26px">
            <asp:FileUpload ID="FileUpload1" runat="server" Height="29px" Width="228px" />
            <asp:Button ID="Button1" runat="server" Text="Upload" Width="96px" OnClick="Button1_Click" />
            <asp:Panel ID="Panel1" runat="server" BorderColor="Blue" BorderStyle="Dashed" Width="440px">
            </asp:Panel>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
