<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageOwner.master" AutoEventWireup="true" CodeFile="Person.aspx.cs" Inherits="Person_Person" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <asp:Image ID="imgSculpture" runat="server" />
    <div id="divScu" runat="server">
    <br />
        修改头像<br />
        <br />
        &nbsp;<asp:FileUpload ID="fup" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnUp" Text="上传图片" runat="server" OnClick="btnUp_Click" />
        <asp:Label ID="lblInfo" runat="server" ForeColor="Red" Font-Size="13px"></asp:Label>
     </div>   
        <asp:LinkButton ID="lbtLog" runat="server" PostBackUrl="~/Log/Log.aspx"></asp:LinkButton>
        <asp:LinkButton ID="lbtAlbum" runat="server" PostBackUrl="~/Album/Album.aspx"></asp:LinkButton>
        <asp:LinkButton ID="lbtMassage" runat="server" PostBackUrl="~/Message/Message.aspx"></asp:LinkButton>
    <br />
    <br />
    个人资料
     
    <br />
    <br />
    账号：<asp:Label ID="lbID" runat="server"></asp:Label>
    <br />
    <br />
    用户名：<asp:Label ID="lbName" runat="server"></asp:Label>
    <br />
    <div id="divName" runat="server" visible="false">
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnName" runat="server" Text="修改" OnClick="btnName_Click" />
    </div>
    <br />
    性别：<asp:Label ID="lbSex" runat="server"></asp:Label>
    <br />
    <div id="divSex" runat="server" visible="false">
        <asp:RadioButtonList ID="rdlSex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem Selected="True">男</asp:ListItem>
            <asp:ListItem>女</asp:ListItem>
        </asp:RadioButtonList>
        &nbsp;
        <asp:Button Text="修改" ID="btnSex" runat="server" OnClick="btnSex_Click" />
    </div>
    <br />

    <div id="divHobby" runat="server" visible="false">
        
    </div>
    <br />
    邮箱：<asp:Label ID="lbEmail" runat="server"></asp:Label>
    <br />
    <div id="divEmail" runat="server" visible="false">
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnEmai" runat="server" Text="修改" OnClick="btnEmai_Click" />
    </div>

    <br />
    电话：<asp:Label ID="lbPhone" runat="server"></asp:Label>
    <div id="divPhone" runat="server" visible="false">
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnPhone" runat="server" Text="修改" OnClick="btnPhone_Click" />
    </div>

    <div id ="divEditor" runat="server" visible="true">
        <asp:LinkButton ID="lbtEditor" runat="server" OnClick="lbtEditor_Click" Text="修改"></asp:LinkButton>
    </div>




&nbsp; 
</asp:Content>

