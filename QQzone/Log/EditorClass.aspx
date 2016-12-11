<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="EditorClass.aspx.cs" Inherits="Log_EditorClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <br />
            <br />
            <asp:Repeater ID="rptClass" runat="server" OnItemCommand="rptClass_ItemCommand">
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>
                    <%#Eval("classfyname") %>
                    <br />
                    修改分类名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                       <asp:LinkButton ID="lbt" runat="server" Text="确认修改" CommandName="Change" CommandArgument='<%#Eval("classfyid") %>'></asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="lbtDelete" runat="server" Text="删除该分类" CommandName="Delete" CommandArgument='<%#Eval("classfyid") %>'></asp:LinkButton>
                    <br />
                </ItemTemplate>
                <FooterTemplate></FooterTemplate>
            </asp:Repeater>
    <div>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="rptClass_ItemCommand">
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>
                    <%#Eval("classfyname") %>
                    <br />
                    修改分类名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                       <asp:LinkButton ID="lbt" runat="server" Text="确认修改" CommandName="Change" CommandArgument='<%#Eval("classfyid") %>'></asp:LinkButton>
                    <br />
                    <asp:LinkButton ID="lbtDelete" runat="server" Text="删除该分类" CommandName="Delete" CommandArgument='<%#Eval("classfyid") %>'></asp:LinkButton>
                    <br />
                </ItemTemplate>
                <FooterTemplate></FooterTemplate>
            </asp:Repeater>
        </div>
</asp:Content>

