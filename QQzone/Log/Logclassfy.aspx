<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="Logclassfy.aspx.cs" Inherits="Log_Logclassfy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
            <asp:LinkButton Text="日志首页" runat="server" PostBackUrl="~/Log/Log.aspx"></asp:LinkButton>
            ——>
        <asp:Label ID="lbClass" runat="server"></asp:Label>
            <br />

            <asp:LinkButton ID="lbnAbstract" runat="server" Text="切换至摘要模式" PostBackUrl="~/Log/Abstract.aspx"></asp:LinkButton>
            &nbsp;
        <asp:LinkButton ID="lbnDraft" runat="server" Text="草稿箱" PostBackUrl="~/Log/Draft.aspx"></asp:LinkButton>
            &nbsp;
        <asp:LinkButton ID="lbnSet" runat="server" Text="设置" PostBackUrl="~/Log/LogSet.aspx"></asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton Text="写日志" runat="server" PostBackUrl="~/Log/Default.aspx"></asp:LinkButton>
            &nbsp;<br />
            <asp:LinkButton ID="lbtEditor" runat="server" OnClick="lbtEditor_Click" Text="编辑分类"></asp:LinkButton>
            <div id="divEditor" runat="server" visible="false">
                重命名分类名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSub_Click1" />
                删除分类：<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" />
            </div>
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
            日志分类
            <asp:LinkButton Text="添加分类" runat="server" OnClick="Unnamed_Click"></asp:LinkButton>
            <div id="divAdd" runat="server" visible="false">
                <br />
                <br />
                分类名称:
                <asp:TextBox ID="txtAdd" runat="server"></asp:TextBox>
                <asp:Button ID="btnSub" runat="server" OnClick="btnSub_Click" Text="添加" />
                <br />
                <br />
            </div>

            <br />
            <asp:Repeater ID="rptClassfy" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton Text='<%# Eval("classfyname") %>' runat="server" PostBackUrl='<%#"LogClassfy.aspx?classfyid="+Eval("classfyid") %>'></asp:LinkButton>
                    <br />
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>

</asp:Content>

