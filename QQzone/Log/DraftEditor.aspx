<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DraftEditor.aspx.cs" Inherits="Log_DraftEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title></title>

    <link rel="stylesheet" href="/kindeditor-4.1.10/themes/default/default.css" />

    <link rel="stylesheet" href="/kindeditor-4.1.10/plugins/code/prettify.css" />

    <script charset="utf-8" src="/kindeditor-4.1.10/kindeditor.js"></script>

    <script charset="utf-8" src="/kindeditor-4.1.10/lang/zh_CN.js"></script>

    <script charset="utf-8" src="/kindeditor-4.1.10/plugins/code/prettify.js"></script>

    <script>

        KindEditor.ready(function (K) {

            var editor1 = K.create('#content1', {

                cssPath: '/kindeditor-4.1.10/plugins/code/prettify.css',

                uploadJson: '/kindeditor-4.1.10/asp.net/upload_json.ashx',

                fileManagerJson: '/kindeditor-4.1.10/asp.net/file_manager_json.ashx',

                allowFileManager: true,

                afterCreate: function () {

                    var self = this;

                    K.ctrl(document, 13, function () {

                        self.sync();

                        K('form[name=example]')[0].submit();

                    });

                    K.ctrl(self.edit.doc, 13, function () {

                        self.sync();

                        K('form[name=example]')[0].submit();

                    });

                }

            });

            prettyPrint();

        });

    </script>

    <style type="text/css">
        .auto-style1 {
            height: 42px;
        }
    </style>

</head>

<body>

    <form id="form1" runat="server">

        <div>
            <asp:LinkButton Text="好友" runat="server" PostBackUrl="~/Friend/FriendList.aspx"></asp:LinkButton>
            <asp:LinkButton ID="lbtCancle" runat="server" OnClick="lbtCancle_Click" Text="注销"></asp:LinkButton>
            <br />
            <br />
            &nbsp;
           <asp:Label ID="lbName" runat="server"></asp:Label>
            &nbsp;
            <br />
            <br />
            &nbsp;<asp:LinkButton ID="toPerson" Text="个人档" runat="server" PostBackUrl="~/Person/Person.aspx"></asp:LinkButton>
            &nbsp;
        <asp:LinkButton ID="toAlbum" Text="相册" runat="server" PostBackUrl="~/Album/Album.aspx"></asp:LinkButton>
            &nbsp;
        <asp:LinkButton ID="toLog" Text="日志" runat="server" PostBackUrl="~/Log/Log.aspx"></asp:LinkButton>
            &nbsp;
        <asp:LinkButton ID="toMessage" Text="留言板" runat="server" PostBackUrl="~/Message/Message.aspx"></asp:LinkButton>
            &nbsp;
        <asp:LinkButton ID="toMyhistory" Text="过往动态" runat="server" PostBackUrl="~/History/Myhistory.aspx"></asp:LinkButton>
                        <br />
                        <br />
            标题<br />
            <br />
            &nbsp;<asp:TextBox ID="txtTitle" runat="server" Style="margin-left: 0px" Width="912px"></asp:TextBox>

            <br />
            <br />

            <table style="width: 931px; height: 271px;">

                <tr>

                    <td>编辑文本</td>

                    <td>
                        <textarea id="content1" cols="100" rows="8" style="width: 100%; height: 200px; visibility: hidden;" runat="server"></textarea></td>

                    <td class="auto-style1">

                    </td>

                </tr>

            </table>

            请选择分类：<asp:DropDownList ID="dropClass" runat="server"></asp:DropDownList>
            <br />
            <br />
            权限：<asp:DropDownList ID="dropPower" runat="server">
                <asp:ListItem Selected="True">所有人可见</asp:ListItem>
                <asp:ListItem>仅自己可见</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSub" runat="server" Text="修改草稿" OnClick="btnSub_Click1" />

            &nbsp;&nbsp;&nbsp;

            <asp:Button ID="btnPub" runat="server" Text="发布" OnClick="btnPub_Click" />

    </div>
    </form>
</body>
</html>

