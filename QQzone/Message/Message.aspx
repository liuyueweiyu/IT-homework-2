<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message_Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:TextBox ID="txtMassage" runat="server" TextMode="MultiLine" Height="77px" Width="653px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSub" runat="server" OnClick="btnSub_Click" Text="留言" />

        <br />
        <br />
        <div id="divMain" runat="server" visible="true">
            <asp:Repeater ID="rptMassage" runat="server" OnItemDataBound="rptMassage_ItemDataBound" OnItemCommand="rptMassage_ItemCommand">

                <ItemTemplate>

                    <h2>
                        <img src='<%#"../"+ Eval("ownersculpture") %>' runat="server" width="50" height="50" />
                        <asp:LinkButton ID="lbtPublish" Text='<%# Eval("ownername")%>' runat="server"  CommandName="Jump" CommandArgument='<%#Eval("massageuser") %>'></asp:LinkButton>
                        &nbsp;
                    <%# Eval("publishtime") %></h2>
                    &nbsp;
                    <h1><%# Eval("massagetext") %></h1>
                    <asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("massageid") %>'></asp:LinkButton>
                    <br />

                    <br />


                    <asp:Repeater ID="rptComment" runat="server" OnItemCommand="rptComment_ItemCommand">
                        <ItemTemplate>
                            <h4><%# Eval("_publishtime") %>
                                <asp:LinkButton ID="lbtPublisher" Text='<%# Eval("_massageusername")%>' runat="server" CommandName="Jump1" CommandArgument='<%#Eval("_massageuserid") %>'></asp:LinkButton>
                                回复<asp:LinkButton ID="lbtPublish" Text='<%# Eval("_massageownername")%>' runat="server" CommandName="Jump2" CommandArgument='<%# Eval("_massageownerid") %>'></asp:LinkButton>
                                ：<%#Eval("massagecommendtext") %></h4>
                            <asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("massagecommentid") %>'></asp:LinkButton>
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>



                    <asp:TextBox ID="txtAnwserCom" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="lbt" runat="server" Text="回复" CommandName="Anwser" CommandArgument='<%#Eval("massageid") %>'></asp:LinkButton>
                </ItemTemplate>

            </asp:Repeater>

            &nbsp;
    
        </div>


        <div id="divFr" runat="server" visible="false">
 
            <asp:Repeater ID="rptFr" runat="server" OnItemDataBound="rptFr_ItemDataBound" OnItemCommand="rptFr_ItemCommand">

                <ItemTemplate>

                    <h2>
                        <img src='<%# Eval("ownersculpture") %>' runat="server" width="50" height="50" />
                                               <asp:LinkButton ID="lbtPublish" Text='<%# Eval("ownername")%>' runat="server"  CommandName="Jump" CommandArgument='<%#Eval("massageowner") %>'></asp:LinkButton>
            &nbsp;
                    <%# Eval("publishtime") %></h2>
                    &nbsp;
                    <h1><%# Eval("massagetext") %></h1>
                    <br />

                    <br />
                    <asp:Repeater ID="rptFrC" runat="server" OnItemCommand="rptFrC_ItemCommand">
                        <ItemTemplate>
                            <h4><%# Eval("_publishtime") %>
                                <asp:LinkButton ID="lbtPublisher" Text='<%# Eval("_massageusername")%>' runat="server" CommandName="Jump1" CommandArgument='<%#Eval("_massageuserid") %>'></asp:LinkButton>
                                回复<asp:LinkButton ID="lbtPublish" Text='<%# Eval("_massageownername")%>' runat="server" CommandName="Jump2" CommandArgument='<%# Eval("_massageownerid") %>'></asp:LinkButton>
                                ：<%#Eval("massagecommendtext") %></h4>
                            
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:TextBox ID="txtAnwserComment" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="lbt" runat="server" Text="回复" CommandName="Anwser" CommandArgument='<%#Eval("massageid") %>'></asp:LinkButton>
                </ItemTemplate>

            </asp:Repeater>

            &nbsp;
    
        </div>

    </div>
</asp:Content>

