<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divRad" runat="server" visible="true">
        请输入你的验证码：<br />
        <br />
&nbsp;<asp:TextBox ID="txtRad" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSub" runat="server" OnClick="btnSub_Click" Text="提交" />    </div>

        <div id="divPwd" runat="server" visible="false">
            <br />
            请输入新密码
             
            <br />
            <br />
            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />

            再输入一遍
            <br />
            <br />
            <asp:TextBox ID="txtrePwd" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />

            <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click" Text="提交" />
        </div>




    </form>
</body>
</html>
