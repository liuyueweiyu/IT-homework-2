<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="Draft.aspx.cs" Inherits="Log_Draft" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                    <br />
                    <br />
                    日志首页<br />


                    <br />


        <asp:LinkButton ID="lbnDraft" runat="server" Text="草稿箱" PostBackUrl="~/Log/Draft.aspx"></asp:LinkButton>
            &nbsp;
            <br />
            <br />
            <asp:LinkButton Text="写日志" runat="server" PostBackUrl="~/Log/Default.aspx"></asp:LinkButton>
            &nbsp;<br />
            <asp:Repeater ID="rptDraft" runat="server" OnItemCommand="rptDraft_ItemCommand">
                <HeaderTemplate>

                </HeaderTemplate>
                <ItemTemplate>
                   
                        <h2>
                           
                                <asp:LinkButton Text='<%# Eval("title") %>' PostBackUrl='<%#"DraftContent.aspx?logid="+Eval("logid") %>' runat="server"></asp:LinkButton>
                        </h2>
                        发表时间：<%# Eval("logtime") %><asp:LinkButton runat="server" Text="发表" CommandName="Submit" CommandArgument='<%#Eval("logid") %>'></asp:LinkButton>
                    &nbsp&nbsp<asp:LinkButton PostBackUrl='<%#"DraftEditor.aspx?logid="+Eval("logid") %>' runat="server" Text="编辑"></asp:LinkButton>

                </ItemTemplate>

                <FooterTemplate>

                </FooterTemplate>
               
            </asp:Repeater>

</asp:Content>

