<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterSuccess.aspx.cs" Inherits="RegisterSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    注册成功
        
         
        <br />
        <br />
        您的账号为：<asp:Label ID="id" runat="server"></asp:Label>
        <br />
        <br />
        昵称:<asp:Label ID="name" runat="server"></asp:Label>
        <img src="../Album/picture/timg.jpg" height="50" width="50" /> 
        <br />
        <br />
        <asp:LinkButton ID="toHomepage" runat="server" PostBackUrl="~/Home.aspx" Text="进入空间"></asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="toFriends" runat="server" PostBackUrl="~/Register/Friendttuijian.aspx" Text="添加好友"></asp:LinkButton>
    </div>
    </form>
</body>
</html>
