<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="MyHistory.aspx.cs" Inherits="History_MyHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:TextBox ID="txtState" runat="server" TextMode="MultiLine" Height="98px" Width="668px"></asp:TextBox>
    <asp:Button ID="btnSub" runat="server" OnClick="btnSub_Click" Text="发表" />
    &nbsp;<br />
    <div id="divMe" runat="server" visible="true">
        <asp:Repeater ID="rptState" runat="server" OnItemDataBound="rptState_ItemDataBound" OnItemCommand="rptState_ItemCommand">
            <HeaderTemplate></HeaderTemplate>
            <ItemTemplate>
                <br />
                <img src='<%#"../" +Eval("staterscu") %>' runat="server" width="60" height="60" />
                <asp:LinkButton ID="lbtPub" Text='<%# Eval("statername")%>' runat="server" CommandName="Jump" CommandArgument='<%#Eval("stater") %>'></asp:LinkButton>
                <%#Eval ("statetime") %>
                <br />
                <h3><%#Eval ("statement") %></h3>
                <h3><%# Eval("other") %></h3>
                <br />
                <asp:LinkButton ID="lbtLog" runat="server" Text="查看详情" Visible="true" PostBackUrl='<%#"Log/LogContent.aspx?logid="+Eval("logs") %>'></asp:LinkButton>
                <asp:LinkButton ID="lbtPhoto" runat="server" Text="查看详情" Visible="true" PostBackUrl='<%#"Album/ThePhoto.aspx?photoid="+Eval("photos") %>'></asp:LinkButton>
                <asp:Image ID="imgPhoto" ImageUrl='<%#Eval("picture") %>' runat="server" Visible="true" />
                <br />
                <br />
                <asp:Repeater ID="rptComment" runat="server" OnItemCommand="rptComment_ItemCommand">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <h4><%# Eval("_statetime") %>
                            <asp:LinkButton ID="lbtPublisher" Text='<%# Eval("_statername")%>' runat="server" CommandName="Jump1" CommandArgument='<%#Eval("_stater") %>'></asp:LinkButton>
                            回复<asp:LinkButton ID="lbtPublish" Text='<%# Eval("_staterownername")%>' runat="server" CommandName="Jump2" CommandArgument='<%#Eval("_stateowner") %>'></asp:LinkButton>
                            :<%# Eval("_statement") %>
                            <br />
                            <asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("_stateid") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>
                <br />
                <asp:TextBox ID="txtAnwserCom" runat="server"></asp:TextBox>
                <asp:LinkButton ID="lbt" runat="server" Text="回复" CommandName="Anwser" CommandArgument='<%#Eval("stateid") %>'></asp:LinkButton>
                <br />
                <asp:Label Text='<%#Eval ("statelikecount")%>' runat="server"></asp:Label>人觉得很赞
                    <asp:LinkButton ID="lbtLike" runat="server" Text="点赞" CommandName="Like" CommandArgument='<%# Eval("stateid") %>'></asp:LinkButton> 
                <asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("stateid") %>'></asp:LinkButton>
                <br />
                <br />
            </ItemTemplate>
            <FooterTemplate></FooterTemplate>
        </asp:Repeater>
    </div>

    <div id="divFr" runat="server" visible="false">
        <asp:Repeater ID="rptFr" runat="server" OnItemDataBound="rptFr_ItemDataBound" OnItemCommand="rptFr_ItemCommand">
            <HeaderTemplate></HeaderTemplate>
            <ItemTemplate>
                <br />
                <img src='<%#"../"+ Eval("staterscu") %>' runat="server" width="60" height="60" />
                <asp:LinkButton ID="lbtPub" Text='<%# Eval("statername")%>' runat="server" CommandName="Jump" CommandArgument='<%#Eval("stater") %>'></asp:LinkButton>
                <%#Eval ("statetime") %>
                <br />
                <h3><%#Eval ("statement") %></h3>
                <h3><%# Eval("other") %></h3>
                <br />
                <asp:LinkButton ID="lbtLog" runat="server" Text="查看详情" Visible="true" PostBackUrl='<%#"Log/LogContent.aspx?logid="+Eval("logs") %>'></asp:LinkButton>
                <asp:LinkButton ID="lbtPhoto" runat="server" Text="查看详情" Visible="true" PostBackUrl='<%#"Album/ThePhoto.aspx?photoid="+Eval("photos") %>'></asp:LinkButton>
                <asp:Image ID="imgPhoto" ImageUrl='<%#"../"+Eval("picture") %>' runat="server" Visible="true" />
                <br />
                <br />
                <asp:Repeater ID="rptCom" runat="server" OnItemCommand="rptCom_ItemCommand">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <h4><%# Eval("_statetime") %>
                            <br />
                            <asp:LinkButton ID="lbtPublisher" Text='<%# Eval("_statername")%>' runat="server" CommandName="Jump1" CommandArgument='<%#Eval("_stater") %>'></asp:LinkButton>
                            回复<asp:LinkButton ID="lbtPublish" Text='<%# Eval("_staterownername")%>' runat="server" CommandName="Jump2" CommandArgument='<%#Eval("_stateowner") %>'></asp:LinkButton>
                            :<%# Eval("_statement") %><br />
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>
                </asp:Repeater>

                <asp:TextBox ID="txtAnwserCom" runat="server"></asp:TextBox>
                <asp:LinkButton ID="lbt" runat="server" Text="回复" CommandName="Anwser" CommandArgument='<%#Eval("stateid") %>'></asp:LinkButton>
                <br />
                <asp:Label Text='<%#Eval ("statelikecount")%>' runat="server"></asp:Label>人觉得很赞
                    <asp:LinkButton ID="lbtLike" runat="server" Text="点赞" CommandName="Like" CommandArgument='<%# Eval("stateid") %>'></asp:LinkButton>

                <br />
                <br />
            </ItemTemplate>
            <FooterTemplate></FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

