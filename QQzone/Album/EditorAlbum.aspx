<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="EditorAlbum.aspx.cs" Inherits="Album_EditorAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <br />
        <br />
        编辑相册
        <br />
        <br />
        相册名：<asp:Label ID="albumname" runat="server"></asp:Label>
        <br />
        <br />
        修改相册名:<asp:TextBox ID="changename" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnName" runat="server" OnClick="btnName_Click" Text="确认修改"/>

        <br />
        <br />

        相册头像：<asp:Image ID="imgSculpture" runat="server" Width="60" Height="60" />
        <br />
        <br />
        <br />
        <asp:FileUpload ID="fup" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnUp" Text="上传图片" runat="server" OnClick="btnUp_Click" />

        <br />
        <br />
        <br />

        设置相册权限
        <asp:RadioButtonList ID="rdlAuthority" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Selected="True">所有人可见</asp:ListItem>
            <asp:ListItem>仅自己可见</asp:ListItem>

        </asp:RadioButtonList>

        &nbsp;

        <asp:Button ID="btnAuthority" runat="server" Text="确认" OnClick="btnAuthority_Click" />
        <br />
        <br />
        <br />
        <asp:LinkButton PostBackUrl="~/Album/Album.aspx" Text="返回上一级" runat="server"></asp:LinkButton>

</asp:Content>

