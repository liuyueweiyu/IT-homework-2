<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="Abstract.aspx.cs" Inherits="Log_Abstract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <br />
                <br />
            <asp:LinkButton ID="lbnAbstract" runat="server" Text="切换至列表模式" PostBackUrl="~/Log/Log.aspx"></asp:LinkButton>
            &nbsp;
    <div id="divMe" runat="server" visible="true">
      <asp:LinkButton ID="lbnDraft" runat="server" Text="草稿箱" PostBackUrl="~/Log/Draft.aspx"></asp:LinkButton>

            <br />
            <br />
            <asp:LinkButton Text="写日志" runat="server" PostBackUrl="~/Log/Default.aspx"></asp:LinkButton>
            &nbsp;<br /></div>
            <asp:Repeater ID="rptLog" runat="server" OnItemCommand="rptLog_ItemCommand">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <h2>
                        <asp:LinkButton Text='<%# Eval("title") %>' PostBackUrl='<%#"LogContent.aspx?logid="+Eval("logid") %>' runat="server"></asp:LinkButton>
                    </h2>
                    发表时间：<%# Eval("logtime") %><br />
                    <asp:Label Text='<%# Eval("simplify") %>' runat="server"></asp:Label>
                    <br />
                    <br />
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>

            </asp:Repeater>
    
                        日志分类<div id="divMetoo" runat="server" visible="false">
            <asp:LinkButton Text="添加分类" runat="server" OnClick="Unnamed_Click"></asp:LinkButton>
            <div id="divAdd" runat="server" visible="false">
                <br />
                <br />
                分类名称:
                <asp:TextBox ID="txtAdd" runat="server"></asp:TextBox>
                <asp:Button ID="btnSub" runat="server" OnClick="btnSub_Click" Text="添加"/>
                <br />
                <br />
            </div></div>
        <br />
        <br />
            <asp:Repeater ID="rptClassfy" runat="server" OnItemCommand="rptClassfy_ItemCommand">
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

</asp:Content>
