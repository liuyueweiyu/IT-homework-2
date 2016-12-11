<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForPwd.aspx.cs" Inherits="ForPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        找回密码<br />
        <br />
        输入账号：
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSub" runat="server" Text="找回密码" OnClick="btnSub_Click" />
    </div>
    </form>
</body>
</html>
