using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Log_Draft : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //验证登陆
        if (Session["id"] == null)
            Response.Write("<script>alert('请先登录！');location='../Login.aspx'</script>");
        else
        {
            int id = Convert.ToInt32(Session["id"].ToString());

            myClass myclass = new myClass();

            string sql = "select * from Log where author='" + id + "'and draft = '1'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            rptDraft.DataSource = dt;

            rptDraft.DataBind();
        }
    }

    protected void rptDraft_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        //发布日志
        if (e.CommandName == "Submit")
        {
            int logid = Convert.ToInt32(e.CommandArgument.ToString());
            int id = Convert.ToInt32(Session["id"].ToString());
            DataTable dt = new DataTable();
            string sql = "select * from Log where logid ='" + logid + "'";
            dt = myclass.JudgeIor(sql);
            string title = dt.Rows[0][1].ToString();
            string simplify = dt.Rows[0][8].ToString();
            DateTime now = DateTime.Now;
            //判断分类决定是否要同步动态到个人中心
            sql = "select * from Log where logid = '" + logid + "'";
            dt = myclass.JudgeIor(sql);
            string compare = "所有人可见";
            if (string.Compare(compare, dt.Rows[0][5].ToString()) == 0)
            {
                sql = "update Log set draft = '1',logtime='" + now + "' where logid='" + logid + "'";
                int flag = myclass.DataSQL(sql);
                string name = myclass.RerdName(id);
                string sculpture = myclass.RerdSculpture(id);
                string other = name + "发表了日志" + title;
                string state = "insert into State (stater,statetime,other,statelike,statername,staterscu,logs,lable) values('" + id + "','" + now + "','" + other + "',',','" + name + "','" + sculpture + "','" + logid + "','" + simplify + "')";
                int stateflag = myclass.DataSQL(state);
            }

                Response.Write("<script>alert('发布成功！')</script>");
                Server.Transfer("Log.aspx");
        }

    }


}