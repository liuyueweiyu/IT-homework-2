<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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

            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('textarea[name="content"]', {
                    allowFileManager: true
                });
                K('input[name=getHtml]').click(function (e) {
                    alert(editor.html());
                });
               K('input[name=getText]').click(function (e) {
                    alert(editor.text());
                });
                K('input[name=setHtml]').click(function (e) {
                    //设置HTML
                   editor.html('<h3>Hello KindEditor</h3>');
                });
                K('input[name=setText]').click(function (e) {
                    //设置文本
                    editor.text('<h3>Hello KindEditor</h3>');
                });
            });
            //input.value = editor.text();

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

            <asp:Image ID="scup" runat="server" Width="100" Height="100" />
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

                </tr>

                <tr>

                    <td>
                        <textarea id="content1" cols="100" rows="8" style="width: 100%; height: 200px; visibility: hidden;" runat="server"></textarea></td>

                </tr>

                <tr>
                    <td>
                        <%--                        <asp:DropDownList ID="dropPower" runat="server">

                        </asp:DropDownList>
                        --%>
                    </td>
                    <td class="auto-style1">

                        <%--                        <asp:Button ID="btnSub" runat="server" Text="发布日志" OnClick="btnSub_Click" />

                        &nbsp;&nbsp;&nbsp;

                        <asp:Button ID="btnDrafts" runat="server" Text="存为草稿箱" OnClick="btnDrafts_Click" />--%>


                    </td>

                </tr>

            </table>
            <script charset="utf-8" src="editor/kindeditor.js"></script>
            <script charset="utf-8" src="editor/lang/zh_CN.js"></script>
            <script>
                KindEditor.ready(function (K) {
                    K.create('#editor_id', {
                        uploadJson: 'handler/upload_json.ashx',
                        fileManagerJson: 'handler/file_manager_json.ashx',
                        allowFileManager: true
                    });
                });
            </script>

            请选择分类：<asp:DropDownList ID="dropClass" runat="server"></asp:DropDownList>
            <br />
            <br />
            权限：<asp:DropDownList ID="dropPower" runat="server">
                <asp:ListItem Selected="True">所有人可见</asp:ListItem>
                <asp:ListItem>仅自己可见</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSub" runat="server" Text="发布日志" OnClick="btnSub_Click" />

            &nbsp;&nbsp;&nbsp;

            <asp:Button ID="btnDrafts" runat="server" Text="存为草稿箱" OnClick="btnDrafts_Click" />

       <%--<input type="button" name="getHtml" value="取得HTML" />
        <input type="button" name="getText" value="取得文本(包含img,embed)" />
        <br />
        <input type="button" name="setHtml" value="设置HTML" />
        <input type="button" name="setText" value="设置文本" />--%>
      <%--      <asp:Label ID="lb" Text='editor.text()' runat="server"></asp:Label>--%>
        </div>

    </form>

</body>

</html>
