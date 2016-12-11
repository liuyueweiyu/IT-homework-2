<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Friend_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <asp:Repeater ID="rptAdd" runat="server" OnItemCommand="rptAdd_ItemCommand">
            <HeaderTemplate>
                <table>
                    <th>
                        <td>用户账号</td>
                        <td>用户名称</td>
                        <td>添加好友</td>
                    </th>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td></td>
                    <td><%# Eval("id") %></td>
                    <td><asp:LinkButton Text='<%#Eval("name") %>' runat="server" CommandName="Jump" CommandArgument='<%#Eval("id") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="添加好友" CommandName="Add" CommandArgument='<%#Eval("id") %>' ></asp:LinkButton></td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
                    </asp:Repeater>

</asp:Content>

