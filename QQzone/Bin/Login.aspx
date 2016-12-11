<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        //点击切换验证码
        function f_refreshtype()
        {
            var Image1 = document.getElementById("img");
            if (Image1 != null)
            {
                Image1.src = Image1.src + "?";
            }
        } 
    </script>
</head>
<body>
       
    <form id="form1" runat="server">
    <div>
        登陆界面

         
        <br />
        <br />
        账号：<asp:TextBox ID="userid" runat="server"></asp:TextBox>
        <br />
        <br />
        密码：<asp:TextBox ID="userpwd" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        请输入验证码：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <img src="png.aspx" id="img" onclick="f_refreshtype()" />



    </div>
        <p>
        <asp:Button ID="btnLogin" Text="登陆" runat="server" OnClick="btnLogin_Click" />
        &nbsp;
        <asp:Button ID="btnRegister" Text="注册" runat="server" PostBackUrl="~/Register.aspx" />
        &nbsp;
        <asp:Button ID="btnForPwd" Text="忘记密码" runat="server" PostBackUrl="~/ForPwd.aspx" />
        </p>
    </form>
</body>
</html>