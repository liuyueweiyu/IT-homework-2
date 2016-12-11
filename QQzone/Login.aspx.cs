using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        myClass myclass = new myClass();

        string id = userid.Text;
        string pwd = userpwd.Text;
        if (id.Length == 0 || pwd.Length == 0||id.Length>=12)
            Response.Write("<script>alert('请正确输入用户信息！')</script>");
        else
        {
            pwd = MD5(pwd);
            string sql = "select * from UserList where id='" + id + "'and pwd='" + pwd + "'";
            int count = myclass.JudgeAcc(sql);

            if (Session["CheckCode"] != null)
            {
                string checkcode = Session["CheckCode"].ToString();
                if (TextBox1.Text != checkcode)
                    Response.Write("<script>alert('验证码错误！')</script>");
                else if (count <= 0)
                    Response.Write("<script>alert('登陆错误！')</script>");
                else
                {
                    Response.Write("<script>alert('登陆成功！');location='Home.aspx'</script>");
                    Session["id"] = id;
                }
            }
        }
    }

    private string MD5(string pwd)
    {
        MD5CryptoServiceProvider md5Encrypter = new MD5CryptoServiceProvider();
        byte[] theSrc = Encoding.UTF8.GetBytes(pwd);
        byte[] theResBytes = md5Encrypter.ComputeHash(theSrc);
        string[] theResStrings = BitConverter.ToString(theResBytes).Split('-');
        string Pwd = string.Concat(theResStrings);
        Pwd = Hash(Pwd);
        return Pwd;
    }


    private string Hash(string pwd)
    {

        HashAlgorithm hashEncrypter = new SHA1Managed();
        byte[] theSrc = Encoding.UTF8.GetBytes(pwd);
        byte[] theResBytes = hashEncrypter.ComputeHash(theSrc);
        string[] theResStrings = BitConverter.ToString(theResBytes).Split('-');
        pwd = string.Concat(theResStrings);
        return pwd;
    }

}