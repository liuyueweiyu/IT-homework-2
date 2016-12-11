<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Friendttuijian.aspx.cs" Inherits="Friendttuijian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            选一个你最感兴趣的吧~
                <asp:RadioButtonList ID="radlHobby" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem>动漫</asp:ListItem>
                    <asp:ListItem>影视剧</asp:ListItem>
                    <asp:ListItem>运动</asp:ListItem>
                    <asp:ListItem>美食</asp:ListItem>
                    <asp:ListItem>书籍</asp:ListItem>
                    <asp:ListItem>电子竞技</asp:ListItem>
                    <asp:ListItem>音乐</asp:ListItem>
                </asp:RadioButtonList>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click"/>
            <hr />
        </div>
    </form>
</body>
</html>
