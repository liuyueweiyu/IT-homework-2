<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogContent.aspx.cs" Inherits="Log_LogContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="lbtList" runat="server" Text="日志首页" PostBackUrl="~/Log/Log.aspx"></asp:LinkButton>

            <h2>
                <asp:Label ID="lbTitle" runat="server"></asp:Label></h2>
            <asp:Label ID="lbTime" runat="server"></asp:Label>
            &nbsp;
            <asp:Label ID="lbPower" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lbText" runat="server"></asp:Label>

            <br />
            <br />
            <br />
            <div id="divMe" runat="server" visible="true">
            <asp:LinkButton ID="lbtEditor" runat="server" Text="修改日志" OnClick="lbtEditor_Click"></asp:LinkButton>
            &nbsp;&nbsp;
            <asp:LinkButton ID="lbtDelete" runat="server" OnClick="lbDelete_Click" Text="删除日志"></asp:LinkButton></div>
            <br />
            <br />
            <asp:LinkButton ID="lbtLast" runat="server" OnClick="lbtLast_Click"></asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="lbtForrow" runat="server" OnClick="lbtForrow_Click"></asp:LinkButton>
            <br />
            <br />
            <br />
            <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" Height="106px" Width="524px"></asp:TextBox>
            <asp:Button ID="btnReply" runat="server" Text="评论" OnClick="btnReply_Click" />
            <br />
            <br />
            <div id="divMetoo" runat="server" visible="true">
            <asp:Repeater ID="rptLog" runat="server" OnItemCommand="rptLog_ItemCommand" OnItemDataBound="rptLog_ItemDataBound">
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>

                    <h2>
                        <img src='<%#"../"+ Eval("replyerscu") %>' runat="server" width="20" height="20" />
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
                                <asp:LinkButton ID="lbtPublisher" Text='<%# Eval("_replyername")%>' runat="server" CommandName="Jump1" CommandArgument='<%#Eval("_replyer") %>'></asp:LinkButton>
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
            </asp:Repeater>
          </div>
            <div id="divFr" runat="server" visible="false">
                <asp:Repeater ID="rptFr" runat="server" OnItemCommand="rptFr_ItemCommand" OnItemDataBound="rptFr_ItemDataBound">
                                    <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>

                    <h2>
                        <img src='<%#"../" +Eval("replyerscu") %>' runat="server" width="20" height="20" />
                        <asp:LinkButton ID="lbtPublish" Text='<%# Eval("replyername")%>' runat="server"  CommandName="Jump" CommandArgument='<%#Eval("replyer") %>'></asp:LinkButton>
                        &nbsp;
                    <%# Eval("replytime") %></h2>
                    &nbsp;
                    <h1><%# Eval("replytext") %></h1>

                    <br />

                    <br />
                    <asp:Repeater ID="rptCom" runat="server" OnItemCommand="rptCom_ItemCommand">
                        <ItemTemplate>
                            <h4><%# Eval("_replytime") %>
                                <asp:LinkButton ID="lbtPublisher" Text='<%# Eval("_replyername")%>' runat="server" CommandName="Jump1" CommandArgument='<%#Eval("_replyer") %>'></asp:LinkButton>
                                回复<asp:LinkButton ID="lbtPublish" Text='<%# Eval("_replyownername")%>' runat="server"  CommandName="Jump2" CommandArgument='<%#Eval("_replyowner") %>'></asp:LinkButton>
                                ：<%#Eval("_replytext") %></h4>
                      
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:TextBox ID="txtAnwserCom" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="lbt" runat="server" Text="回复" CommandName="Anwser" CommandArgument='<%#Eval("replyid") %>'></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate></FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
