<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="DraftContent.aspx.cs" Inherits="Log_DraftContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <asp:LinkButton ID="lbtList" runat="server" Text="日志首页" PostBackUrl="~/Log/Log.aspx"></asp:LinkButton>

            <h2><asp:Label ID="lbTitle" runat="server"></asp:Label></h2>
            <asp:Label ID="lbTime" runat="server"></asp:Label>
            &nbsp;
            <asp:Label ID="lbPower" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lbText" runat="server"></asp:Label>

            <br />
            <br />
            <br />

            <asp:LinkButton ID="lbtEditor" runat="server" Text="修改草稿" OnClick="lbtEditor_Click"></asp:LinkButton>
            &nbsp;&nbsp;
            <asp:LinkButton ID="lbtDelete" runat="server" OnClick="lbDelete_Click" Text="删除草稿"></asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="lbtLast" runat="server" OnClick="lbtLast_Click" Visible="false"></asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="lbtForrow" runat="server" OnClick="lbtForrow_Click" Visible="false"></asp:LinkButton>
</asp:Content>

