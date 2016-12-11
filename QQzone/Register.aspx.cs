using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //生成的验证码被保存到session中



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

    protected void btnRegister_Click1(object sender, EventArgs e)
    {
        myClass myclass = new myClass();

        string pwd = NewPwd.Text;
        string repwd = reNewPwd.Text;
        string email = Email.Text;
        string phone = Phone.Text;
        string name = Name.Text;
        string sculpture = "Album/picture/timg.jpg";
        string sex = rdlSex.SelectedValue;
        //string province = 
        if (pwd.Length == 0 || repwd.Length == 0 || email.Length == 0 || phone.Length == 0 || name.Length==0||sex.Length==0)
            Response.Write("<script>alert('输入不能为空！')</script>");
        else { 
        string sql1 = "select * from UserList where phone='" + phone + "'";
        string sql2 = "select * from UserList where email='" + email + "'";
        string sql4 = "select * from UserList where phone='" + phone + "'";
        int count1 = (myclass.JudgeIor(sql1)).Rows.Count;
        int count2 = (myclass.JudgeIor(sql2)).Rows.Count;


        if (Session["CheckCode"] != null)
        {
            string checkcode = Session["CheckCode"].ToString();
                if (TextBox1.Text != checkcode)
                    Response.Write("<script>alert('验证码错误！')</script>");
                else if (String.Compare(pwd, repwd) != 0)
                    Response.Write("<script>alert('前面密码两次错误！')</script>");
                else if (count1 > 0)
                    Response.Write("<script>alert('手机号码已被绑定！')</script>");
                else if (count2 > 0)
                    Response.Write("<script>alert('邮箱已被验证！')</script>");
                else
                {
                    pwd = MD5(pwd);

                    int count = 1, rad = 0;

                    while (count > 0)
                    {
                        Int32 x = 1000000;
                        Random Random = new System.Random();
                        rad = Random.Next(x, x * 10);

                        string sql = "select * from UserList where id = '" + rad + "'";

                        count = myclass.JudgeAcc(sql);
                    }


                    string sql3 = "insert into UserList (id,name,pwd,email,phone,sculpture,sex) values('" + rad + "','" + name + "','" + pwd + "','" + email + "','" + phone + "','" + sculpture + "','" + sex + "')";

                    int flag = myclass.DataSQL(sql3);
                    if (flag != 1)
                        Response.Write("<script>alert('注册失败！')</script>");
                    else
                    {
                        DataTable dt = new DataTable();

                        dt = myclass.JudgeIor(sql4);

                        string id = dt.Rows[0][0].ToString();
                        string sql = "insert into LogClass (classfyname,logowner) values('默认分类','" + id + "')";
                        myclass.DataSQL(sql);
                        Session["id"] = id;
                        Session["name"] = name;

                        Response.Write("<script>alert('注册成功！');location='Register/RegisterSuccess.aspx'</script>");

                    }
                }


            }
        }



    }
}