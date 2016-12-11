using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForPwd : System.Web.UI.Page
{
    /// <summary> 
    /// 发送电子邮件 
    /// </summary> 
    /// <param name="MessageFrom">发件人邮箱地址 </param> 
    /// <param name="MessageTo">收件人邮箱地址 </param> 
    /// <param name="MessageSubject">邮件主题 </param> 
    /// <param name="MessageBody">邮件内容 </param> 
    /// <returns> </returns> 
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public bool Sendemails(string MessageFrom, string MessageTo, string MessageSubject, string MessageBody)
    {
        MailMessage message = new MailMessage();
        MailAddress from = new MailAddress(MessageFrom);
        message.From = from;
        MailAddress messageto = new MailAddress(MessageTo);
        message.To.Add(messageto);              //收件人邮箱地址可以是多个以实现群发 
        message.Subject = MessageSubject;
        message.Body = MessageBody;
        message.IsBodyHtml = true;              //是否为html格式 
        message.Priority = MailPriority.High;   //发送邮件的优先等级

        //指定发送邮件的服务器地址或IP 
        //指定发送邮件端口
        SmtpClient sc = new SmtpClient("smtp.163.com", 25);
        sc.Credentials = new System.Net.NetworkCredential("m18039746604_1@163.com", "18960660325gxy1"); //指定登录服务器的用户名和密码  


        sc.Send(message);       //发送邮件                              
        return true;
    }

    protected void btnSub_Click(object sender, EventArgs e)
    {
        if (txtID.Text.Length == 0 || txtID.Text.Length >= 12)
            Response.Write("<script>alert('请合法输入！')</script>");
        else
        {
            int id = Convert.ToInt32(txtID.Text);
            string sql = "select * from UserList where id = '" + id + "'";
            myClass myclass = new myClass();
            DataTable dt = new DataTable();
            dt = myclass.JudgeIor(sql);
            string email = dt.Rows[0][7].ToString();
            string Massage = "m18039746604_1@163.com";
            Int16 x = 1000;
            Random Random = new System.Random();
            string rad =Convert.ToString( Random.Next(x, x * 10));
            string massage = "您的随机验证码是" + rad + ",收到后请将验证码输于找回页面。";
            bool flag = Sendemails(Massage, email, "找回密码",massage );
            if (flag)
            {
                Response.Write("<script>alert('发送成功！');location='Test.aspx'</script>");
                Session["rad"] = rad;
                Session["id"] = Convert.ToString(id);
            }



        }
    }
}

