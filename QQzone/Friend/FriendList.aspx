<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="FriendList.aspx.cs" Inherits="Friend_FriendList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <br />
            <br />

            添加好友
     
            <br />
    <asp:LinkButton ID="lbtName" runat="server" OnClick="lbtName_Click" Text="按名字查找"></asp:LinkButton>
    &nbsp;
    <asp:LinkButton ID="lbtNumber" runat="server" OnClick="lbtNumber_Click" Text="按账号查找"></asp:LinkButton>
    <div id="divName" runat="server" visible="false">
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Button ID="btnName" runat="server" Text="提交" OnClick="btnName_Click" />
    </div>
    <div id="divNumber" runat="server" visible="false">
        <asp:TextBox ID="txtNumber" runat="server">
        </asp:TextBox>
        <asp:Button ID="btnNumbre" runat="server" Text="提交" OnClick="btnNumbre_Click" />
    </div>
                    <asp:Repeater ID="rptFriend" runat="server" OnItemCommand="rptFriend_ItemCommand">
            <HeaderTemplate>
                <table>
                    <th>
                        <td>好友账号</td>
                        <td>好友名称</td>
                        <td>删除好友</td>
                    </th>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td></td>
                    <td><%# Eval("friends") %></td>
                    <td><asp:LinkButton Text='<%#Eval("friendname") %>' runat="server" CommandName="Jump" CommandArgument='<%#Eval("friends") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("relationid") %>' ></asp:LinkButton></td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
                    </asp:Repeater>
 
</asp:Content>

