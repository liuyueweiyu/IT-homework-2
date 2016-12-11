<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="Visitor.aspx.cs" Inherits="Visitor_Visitor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br />
    <br />
    <asp:Label ID="lbCountAll" runat="server"></asp:Label>
    &nbsp;&nbsp;
    <asp:Label ID="lbCountTodat" runat="server"></asp:Label>
                    <asp:Repeater ID="rptToday" runat="server" OnItemCommand="rptToday_ItemCommand">
            <HeaderTemplate>
                <table>
                    <th>
                        <td>访问用户名</td>
                       
                        <td>时间</td>
                        <td>删除记录</td>
                    </th>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td></td>
                    <td><%# Eval("visitorname") %></td>
                    <td><%# Eval("visitetime") %></td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("visiid") %>' ></asp:LinkButton></td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
                    </asp:Repeater>
                <asp:Repeater ID="rptHistory" runat="server" OnItemCommand="rptHistory_ItemCommand">
            <HeaderTemplate>
                <table>
                    <th>
                        <td>访问用户名</td>
                       
                        <td>时间</td>
                        <td>删除记录</td>
                    </th>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td></td>
                    <td><%# Eval("visitorname") %></td>
                    <td><%# Eval("visitetime") %></td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("visiid") %>' ></asp:LinkButton></td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
                    </asp:Repeater>
</asp:Content>

