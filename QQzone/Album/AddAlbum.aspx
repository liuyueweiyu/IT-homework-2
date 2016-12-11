<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="AddAlbum.aspx.cs" Inherits="Album_AddAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    相册名称:<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <br />
    <br />
    相册权限:       
        <asp:RadioButtonList ID="rdlAuthority" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem  Selected="True">所有人可见</asp:ListItem>
            <asp:ListItem>仅自己可见</asp:ListItem>
        </asp:RadioButtonList>
    <br />
    <br />
    <asp:Button ID="btnSub" runat="server" OnClick="btnSub_Click" Text="确认添加" />
</asp:Content>

