using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Log_LogEditor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
            Response.Write("<script>alert('请先登录！');location='../Login.aspx'</script>");
        else
        {
            myClass myclass = new myClass();
            int id = Convert.ToInt32(Session["id"].ToString());

            string sql = "select * from UserList where id = '" + id + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);
            lbName.Text = dt.Rows[0][1].ToString();
        }
        {
            if (!IsPostBack)
            {
                int logid = Convert.ToInt32(Session["logtextid"].ToString());

                myClass myclass = new myClass();

                DataTable dt = new DataTable();

                string sql = "select * from Log where logid='" + logid + "'";

                dt = myclass.JudgeIor(sql);

                txtTitle.Text = dt.Rows[0][1].ToString();
                content1.InnerText = dt.Rows[0][2].ToString();

                int _classfyid = Convert.ToInt32(dt.Rows[0][6].ToString());

                int id = Convert.ToInt32(Session["id"].ToString());

                sql = "select * from LogClass where logowner='" + id + "'";

                dt = myclass.JudgeIor(sql);

                dropClass.DataSource = dt;

                dropClass.DataTextField = "classfyname";

                dropClass.DataBind();

            }
        }
    }

    protected void btnSub_Click(object sender, EventArgs e)
    {
        

        int id = Convert.ToInt32(Session["id"].ToString());
        int logid = Convert.ToInt32(Session["logtextid"].ToString());
        string title = txtTitle.Text;
        string content = Request.Form["content1"];
        string classr = dropClass.SelectedValue;
        string power = dropPower.SelectedValue;
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

            if (simplify.Length >= 50)
                simplify = simplify.Substring(0, 50) + "....";

            sql = "update Log set title='" + title + "',logtext='" + content + "',logtime='" + now + "',logpower='" + power + "', _classfyid='" + classid + "' where logid = '" + logid + "'";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
            {
                Response.Write("<script>alert('修改成功！')</script>");
                Server.Transfer("Log.aspx");
            }
            else
            {
                Response.Write("<script>alert('修改失败！')</script>");
                Server.Transfer("LogEditor.aspx");
            }

        }
    }


    protected void lbtCancle_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Write("<script>alert('注销成功！')</script>");
        Server.Transfer("../Login.aspx");
    }
}