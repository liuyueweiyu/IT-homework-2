using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
            Response.Write("<script>alert('请先登录！');location='../Login.aspx'</script>");
        else
        {
            myClass myclass = new myClass();
            int id = Convert.ToInt32(Session["id"].ToString());

            scup.ImageUrl = "../" + myclass.RerdSculpture(id);
            lbName.Text = myclass.RerdName(id);

            string sql = "select * from LogClass where logowner='" + id + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            dropClass.DataSource = dt;

            dropClass.DataTextField = "classfyname";

            dropClass.DataBind();


        }
    }



    protected void btnSub_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["id"].ToString());
        string title = txtTitle.Text;
        string content = Request.Form["content1"];
        if (title.Length == 0 || content.Length == 0)
            Response.Write("<script>alert('输入不能为空！')</script>");
        else
        {
            string classr = dropClass.SelectedValue;
            string power = dropPower.SelectedValue;
            DateTime now = DateTime.Now;

            DataTable dt = new DataTable();
            myClass myclass = new myClass();

            string sql = "select * from LogClass where classfyname='" + classr + "'and logowner ='" + id + "'";

            dt = myclass.JudgeIor(sql);

            string simplify = System.Text.RegularExpressions.Regex.Replace(content, @"<[///!]*?[^<>]*?>", "").Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "").Replace("&nbsp;", "");

            if (simplify.Length >= 50)
                simplify = simplify.Substring(0, 50) + "....";

            int classid = Convert.ToInt32(dt.Rows[0][0].ToString());

            sql = "insert into Log(title,logtext,author,logtime,logpower,_classfyid,simplify) values('" + title + "','" + content + "','" + id + "','" + now + "','" + power + "','" + classid + "','" + simplify + "')";

            int flag = myclass.DataSQL(sql);

            sql = "select * from Log where logtime='" + now + "'and title = '" + title + "'";
            dt = myclass.JudgeIor(sql);
            int logid = Convert.ToInt32(dt.Rows[0][0].ToString());


            sql = "select * from Log where logid = '" + logid + "'";
            dt = myclass.JudgeIor(sql);
            string compare = "所有人可见";
            if (string.Compare(compare, dt.Rows[0][5].ToString()) == 0)
            {
                string name = myclass.RerdName(id);
                string sculpture = myclass.RerdSculpture(id);
                string other = name + "发表了日志" + title;
                string state = "insert into State (stater,statetime,other,statelike,statername,staterscu,logs,lable) values('" + id + "','" + now + "','" + other + "',',','" + name + "','" + sculpture + "','" + logid + "','" + simplify + "')";
                int stateflag = myclass.DataSQL(state);
            }

            if (flag == 1)
            {
                Response.Write("<script>alert('发布成功！')</script>");
                Server.Transfer("Log.aspx");
            }
            else
            {
                Response.Write("<script>alert('发布失败！')</script>");
                Server.Transfer("Default.aspx");
            }
        }

    }


    protected void btnDrafts_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["id"].ToString());
        string title = txtTitle.Text;
        string content = Request.Form["content1"];
        string classr = dropClass.SelectedValue;
        string power = dropPower.SelectedValue;
        int draft = 1;
        
        DateTime now = DateTime.Now;

        DataTable dt = new DataTable();
        myClass myclass = new myClass();

        if (title.Length == 0 || content.Length == 0)
            Response.Write("<script>alert('输入不能为空！')</script>");
        else
        {
            string sql = "select * from LogClass where classfyname='" + classr + "'and logowner ='" + id + "'";

            dt = myclass.JudgeIor(sql);

            int classid = Convert.ToInt32(dt.Rows[0][0].ToString());

            string simplify = System.Text.RegularExpressions.Regex.Replace(content, @"<[///!]*?[^<>]*?>", "").Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "").Replace("&nbsp;", "");

            if (simplify.Length > 50)
                simplify = simplify.Substring(0, 50) + "....";

            sql = "insert into Log(title,logtext,author,logtime,logpower,_classfyid,draft,simplify) values('" + title + "','" + content + "','" + id + "','" + now + "','" + power + "','" + classid + "','" + draft + "','" + simplify + "')";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
            {
                Response.Write("<script>alert('保存成功！')</script>");
                Server.Transfer("Log.aspx");
            }
            else
            {
                Response.Write("<script>alert('保存失败！')</script>");
                Server.Transfer("Default.aspx");
            }
        }
    }

    protected void lbtCancle_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Write("<script>alert('注销成功！')</script>");
        Server.Transfer("Login.aspx");
    }
}
