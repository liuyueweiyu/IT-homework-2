<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="Log.aspx.cs" Inherits="Log_Log" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <asp:LinkButton ID="lbnAbstract" runat="server" Text="切换至摘要模式" PostBackUrl="~/Log/Abstract.aspx"></asp:LinkButton>
    &nbsp;
    <div id="divMe" runat="server" visible="true">
        <asp:LinkButton ID="lbnDraft" runat="server" Text="草稿箱" PostBackUrl="~/Log/Draft.aspx"></asp:LinkButton>

    <br />
    <br />
    <asp:LinkButton Text="写日志" runat="server" PostBackUrl="~/Log/Default.aspx"></asp:LinkButton>
    &nbsp;<br /></div>
    <asp:Repeater ID="rptLog" runat="server" OnItemCommand="rptLog_ItemCommand">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <h2>
                    <td>
                        <asp:LinkButton Text='<%# Eval("title") %>' PostBackUrl='<%#"LogContent.aspx?logid="+Eval("logid") %>' runat="server"></asp:LinkButton></td>
                </h2>
                <td>发表时间：<%# Eval("logtime") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>
    &nbsp;
        <br />
    <br />
    <br />
    <br />
    日志分类<div id="divMetoo" runat="server" visible="true">
            <asp:LinkButton Text="添加分类" runat="server" OnClick="Unnamed_Click"></asp:LinkButton>
    &nbsp;
            <asp:LinkButton Text="编辑分类" runat="server" PostBackUrl="~/Log/EditorClass.aspx"></asp:LinkButton>
    <div id="divAdd" runat="server" visible="false">
        <br />
        <br />
        分类名称:
                <asp:TextBox ID="txtAdd" runat="server"></asp:TextBox>
        <asp:Button ID="btnSub" runat="server" OnClick="btnSub_Click" Text="添加" />
        <br />
        <br />
    </div>
</div>
    <br /><div id="divRpt" runat="server" visible="true">
    <asp:Repeater ID="rptClassfy" runat="server" OnItemCommand="rptClassfy_ItemCommand" Visible="true">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:LinkButton Text='<%# Eval("classfyname") %>' runat="server" PostBackUrl='<%#"LogClassfy.aspx?classfyid="+Eval("classfyid") %>'></asp:LinkButton>
            <asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("classfyid") %>'></asp:LinkButton></th>
            
            <br />
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
    <br /></div>
    <div id="rptFr1" runat="server" visible="false">
        <asp:Repeater ID="rptFr" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:LinkButton Text='<%# Eval("classfyname") %>' runat="server" PostBackUrl='<%#"LogClassfy.aspx?classfyid="+Eval("classfyid") %>'></asp:LinkButton>

            <br />
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater></div>
</asp:Content>

