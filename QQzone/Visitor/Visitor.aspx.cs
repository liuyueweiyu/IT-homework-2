using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Visitor_Visitor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
            Response.Write("<script>alert('请先登录！');location='../Login.aspx'</script>");
        else

        {
            int id = Convert.ToInt32(Session["id"].ToString());

            myClass myclass = new myClass();

            DataTable dt = new DataTable();

            string sql;

            sql = "select * from Visitor where bevisitor='" + id + "' and visitor <> '" + id + "'";

            dt = myclass.JudgeIor(sql);

            rptHistory.DataSource = dt;

            rptHistory.DataBind();

            lbCountAll.Text ="历史访问量：" +Convert.ToString(dt.Rows.Count);

            

        }
    }

    protected void rptHistory_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();


        if (e.CommandName == "Delete")
        {
            int visiid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "delete from Visitor where visiid='" + visiid + "'";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
            {
                Response.Write("<script>alert('删除成功！');location='Visitor.aspx'</script>");
            }
        }
    }


    protected void rptToday_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();


        if (e.CommandName == "Delete")
        {
            int visiid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "delete from Visitor where visiid='" + visiid + "'";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
            {
                Response.Write("<script>alert('删除成功！');location='Visitor.aspx'</script>");
            }
        }
    }
}