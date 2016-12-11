<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="Album.aspx.cs" Inherits="Album_Album" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divMe" runat="server" visible="true">
        <br />
        <br />
    
        <asp:LinkButton PostBackUrl="~/Album/AddAlbum.aspx" runat="server" Text="添加相册"></asp:LinkButton>
        <br />
        <br />
        <asp:Repeater ID="rptAlbum" runat="server" OnItemCommand="rptAlbum_ItemCommand">
            <HeaderTemplate>
                <table>
                    <th>
                        <td>相册</td>
                        <td>相册名字</td>
                       
                        <td>编辑相册</td>
                        <td>相册权限</td>
                        <td>删除相册</td>
                    </th>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><asp:ImageButton ImageUrl='<%# Eval("interface") %>' PostBackUrl='<%#"Photo.aspx?albumid="+Eval("albumid") %>' runat="server" Width="50" Height="50"/></td>
                    <td><%# Eval("albumname") %></td>
                    <td><asp:LinkButton Text="查看相册" PostBackUrl='<%#"Photo.aspx?albumid="+Eval("albumid") %>' runat="server" ></asp:LinkButton></td>
                    <td><asp:LinkButton PostBackUrl='<%#"EditorAlbum.aspx?albumid="+Eval("albumid") %>' runat="server" Text="编辑相册"></asp:LinkButton></td>
                    <td><%# Eval("authority") %>></td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("albumid") %>' ></asp:LinkButton></td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div id="divFr" runat="server" visible="false">
                <asp:Repeater ID="rptFr" runat="server">
            <HeaderTemplate>
                <table>
                    <th>
                        <td>相册</td>
                        <td>相册名字</td>
                    </th>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><asp:ImageButton ImageUrl='<%# Eval("interface") %>' PostBackUrl='<%#"Photo.aspx?albumid="+Eval("albumid") %>' runat="server" Width="50" Height="50"/></td>
                    <td><%# Eval("albumname") %></td>
                    <td><asp:LinkButton Text="查看相册" PostBackUrl='<%#"Photo.aspx?albumid="+Eval("albumid") %>' runat="server" ></asp:LinkButton></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

