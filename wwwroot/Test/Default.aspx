<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Test_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="加密tUserAccount" OnClick="Button1_Click" />
        </div>
        <div>
            <asp:Button ID="Button2" runat="server" Text="加密tAdmin" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
