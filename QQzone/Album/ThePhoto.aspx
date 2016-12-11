<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="ThePhoto.aspx.cs" Inherits="Album_ThePhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <asp:Label ID="lbName" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lbTime" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Image ID="imgPhoto" runat="server" />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" Height="106px" Width="524px"></asp:TextBox>
    <asp:Button ID="btnReply" runat="server" Text="评论" OnClick="btnReply_Click" />
    <br />
    <br />
    <div id="divMe" runat="server" visible="true">
    <asp:Repeater ID="rptPhoto" runat="server" OnItemDataBound="rptPhoto_ItemDataBound" OnItemCommand="rptPhoto_ItemCommand">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>

            <h2>
                <asp:LinkButton ID="lbtPublish" Text='<%# Eval("replyername")%>' runat="server"  CommandName="Jump" CommandArgument='<%#Eval("replyer") %>'></asp:LinkButton>
                &nbsp;
                    <%# Eval("replytime") %></h2>
                &nbsp;
                    <h1><%# Eval("replytext") %></h1>
            <asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("replyid") %>'></asp:LinkButton>
            <br />

            <br />
            <asp:Repeater ID="rptComment" runat="server" OnItemCommand="rptComment_ItemCommand">
                <ItemTemplate>
                    <h4><%# Eval("_replytime") %>
                        <asp:LinkButton ID="lbtPublisher" Text='<%# Eval("_replyername")%>' runat="server"  CommandName="Jump1" CommandArgument='<%#Eval("_replyer") %>'></asp:LinkButton>
                        回复<asp:LinkButton ID="lbtPublish" Text='<%# Eval("_replyownername")%>' runat="server"  CommandName="Jump2" CommandArgument='<%#Eval("_replyowner") %>'></asp:LinkButton>
                        ：<%#Eval("_replytext") %></h4>
                    <asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("_replyid") %>'></asp:LinkButton>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
            <asp:TextBox ID="txtAnwserCom" runat="server"></asp:TextBox>
            <asp:LinkButton ID="lbt" runat="server" Text="回复" CommandName="Anwser" CommandArgument='<%#Eval("replyid") %>'></asp:LinkButton>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater></div>
    <div id="divFr" runat="server" visible="false">
            <asp:Repeater ID="rptFr" runat="server" OnItemDataBound="rptFr_ItemDataBound" OnItemCommand="rptFr_ItemCommand">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>

            <h2>
                <asp:LinkButton ID="lbtPublish" Text='<%# Eval("replyername")%>' runat="server" CommandName="Jump" CommandArgument='<%#Eval("replyer") %>'></asp:LinkButton>
                &nbsp;
                    <%# Eval("replytime") %></h2>
            &nbsp;
                    <h1><%# Eval("replytext") %></h1>
            

            <br />
            <asp:Repeater ID="rptFrC" runat="server" OnItemCommand="rptFrC_ItemCommand">
                <ItemTemplate>
                    <h4><%# Eval("_replytime") %>
                        <asp:LinkButton ID="lbtPublisher" Text='<%# Eval("_replyername")%>' runat="server" CommandName="Jump1" CommandArgument='<%#Eval("_replyer") %>'></asp:LinkButton>
                        回复<asp:LinkButton ID="lbtPublish" Text='<%# Eval("_replyownername")%>' runat="server"  CommandName="Jump2" CommandArgument='<%#Eval("_replyowner") %>'></asp:LinkButton>
                        ：<%#Eval("_replytext") %></h4>
                  
                </ItemTemplate>
            </asp:Repeater>
            <asp:TextBox ID="txtAnwserCom" runat="server"></asp:TextBox>
            <asp:LinkButton ID="lbt" runat="server" Text="回复" CommandName="Anwser" CommandArgument='<%#Eval("replyid") %>'></asp:LinkButton>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
    </div>

</asp:Content>

