<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="Photo.aspx.cs" Inherits="Album_Photo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divMe" runat="server" visible="true">
    <asp:LinkButton ID="lbtAlbum" runat="server" PostBackUrl="~/Album/Alum.aspx" Text="相册首页"></asp:LinkButton>
    <br />
    <br />
    <asp:FileUpload ID="fup" runat="server" />
    <br />
    <br />
    <asp:Button ID="btnUp" Text="上传图片" runat="server" OnClick="btnUp_Click" />
    <asp:Label ID="lblInfo" runat="server" ForeColor="Red" Font-Size="13px"></asp:Label>

    <br />
    <br />
    <asp:Repeater ID="rptPhoto" runat="server" OnItemCommand="rptPhoto_ItemCommand">

        <HeaderTemplate>
            <table>
                <tr>
                    <th>图片</th>
                    <th>上传时间</th>
                    <th>删除图片</th>
                    <th>设为封面</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <th>
                    <img src='<%# Eval("path") %>' runat="server" width="100" height="100" /></th>
                <th><%# Eval("uptime") %></th>
                <th>
                    <asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("photoid") %>'></asp:LinkButton></th>
                <th>
                    <asp:LinkButton ID="lbtInterface" runat="server" Text="设为封面" CommandName="Interface" CommandArgument='<%#Eval("photoid") %>'></asp:LinkButton></th>
                <th>
                    <asp:LinkButton ID="lbtThephoto" runat="server" Text="查看大图" PostBackUrl='<%#"ThePhoto.aspx?photoid="+Eval("photoid") %>'></asp:LinkButton>
                </th>
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
                <tr>
                    <th>图片</th>
                    <th>上传时间</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <th>
                    <img src='<%# Eval("path") %>' runat="server" width="100" height="100" /></th>
                <th><%# Eval("uptime") %></th>
                <th>
                    <asp:LinkButton ID="lbtThephoto" runat="server" Text="查看大图" PostBackUrl='<%#"ThePhoto.aspx?photoid="+Eval("photoid") %>'></asp:LinkButton>
                </th>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>

        </FooterTemplate>
    </asp:Repeater>

    </div>
</asp:Content>

