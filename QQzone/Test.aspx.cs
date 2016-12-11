using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSub_Click(object sender, EventArgs e)
    {
        string rad = Session["rad"].ToString();
        string text = txtRad.Text;
        if(String.Compare(rad,text)==0)
        {
            divPwd.Visible = true;
            divRad.Visible = false;
        }
        else
            Response.Write("<script>alert('验证码错误！')</script>");
    }

    protected void btnChange_Click(object sender, EventArgs e)
    {
        string pwd = txtPwd.Text;
        string repwd = txtrePwd.Text;
        if(String.Compare(pwd,repwd)!=0)
            Response.Write("<script>alert('前后两次密码不一样！')</script>");
        else
        {
            int id = Convert.ToInt32(Session["id"].ToString());

            pwd = MD5(pwd);

            string sql = "update UserList set pwd='" + pwd + "' where id='" + id + "'";

            myClass myclass = new myClass();

            int flag = myclass.DataSQL(sql);

            if(flag==1)
                Response.Write("<script>alert('重置成功！');location='Login.aspx'</script>");
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