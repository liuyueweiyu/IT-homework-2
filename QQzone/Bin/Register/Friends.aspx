<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Friends.aspx.cs" Inherits="Friends" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divSome" runat="server">
    <asp:Repeater ID="rptsomeFriend" runat="server" OnItemCommand="rptFriends_ItemCommand">
        <HeaderTemplate>
            <table>
            <tr>
                <tb>头像</tb>
                <tb>账号</tb>
                <tb>昵称</tb>
                <tb>详情</tb>
                <tb>加为好友</tb>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <th><img src='<%#"../"+Eval("sculpture") %>' runat="server" width="30" height="30" /></th>
                <th><%# Eval("id") %></th>
                <th><%# Eval("name") %></th>
                <th><asp:LinkButton ID="toAdd"  runat="server" Text="添加好友" CommandName="Add" CommandArgument='<%#Eval("id") %>'></asp:LinkButton></th>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
        
    </asp:Repeater>
        <br />
        <br />
        <asp:Button ID="btnAll" Text="查看更多好友" OnClick="btnAll_Click" runat="server" />
        <asp:LinkButton ID="tohomepage" Text="进入空间" PostBackUrl="~/Home.aspx" runat="server"></asp:LinkButton>
        
    </div>
        <div id="divAll" runat="server">
                <br />
                <asp:Repeater ID="rptallFriend" runat="server" OnItemCommand="rptFriends_ItemCommand">
        <HeaderTemplate>
            <table>
            <tr>
                <tb>    </tb>
                <tb>账号</tb>
                <tb>昵称</tb>
                <tb>详情</tb>
                <tb>加为好友</tb>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <th><img src='<%#"../"+ Eval("sculpture") %>' runat="server" width="30" height="30" /></th>
                <th><%# Eval("id") %></th>
                <th><%# Eval("name") %></th>
                <th><asp:LinkButton ID="toAdd"  runat="server" Text="添加好友" CommandName="Add" CommandArgument='<%#Eval("id") %>'></asp:LinkButton></th>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
        
    </asp:Repeater>

        </div>
        
    </form>
</body>
</html>
