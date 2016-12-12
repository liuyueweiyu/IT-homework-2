using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Log_DraftContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            int id = Convert.ToInt16(Session["id"].ToString());

            myClass myclass = new myClass();

            int logid = Convert.ToInt32(Request.QueryString["logid"]);

            string sql = "select * from Log where logid='" + logid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            lbTitle.Text = dt.Rows[0][1].ToString();

            lbTime.Text = dt.Rows[0][4].ToString();

            lbPower.Text = dt.Rows[0][5].ToString();

            lbText.Text = dt.Rows[0][2].ToString();

            sql = "select top 1 * from Log where author = '" + id + "' and draft = '0' and logid<'" + logid + "' order by logid DESC";

            dt = myclass.JudgeIor(sql);

            if (dt.Rows.Count == 0)
                lbtLast.Text = "";
            else
                lbtLast.Text = "←上一篇：" + dt.Rows[0][1].ToString();

            sql = "select top 1 * from Log where author = '" + id + "' and draft = '0' and logid>'" + logid + "' order by logid ASC";

            dt = myclass.JudgeIor(sql);
            if (dt.Rows.Count == 0)
                lbtForrow.Text = "";
            else
                lbtForrow.Text = dt.Rows[0][1].ToString() + "下一篇→";

        }
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        //删除草稿
        myClass myclass = new myClass();
        int logid = Convert.ToInt32(Request.QueryString["logid"]);
        string sql = "delete from Log where logid='" + logid + "'";

        int flag = myclass.DataSQL(sql);

        if (flag == 1)
        {
            Response.Write("<script>alert('删除成功！')</script>");
            Server.Transfer("Log.aspx");
        }

    }

    protected void lbtEditor_Click(object sender, EventArgs e)
    {
        int logid = Convert.ToInt32(Request.QueryString["logid"]);
        Session["drafttextid"] = logid;
        //Server.Transfer("LogEditor.aspx");
        Response.Write("<script>location='DraftEditor.aspx'</script>");
    }

    protected void lbtLast_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["id"].ToString());
        int logid = Convert.ToInt32(Request.QueryString["logid"]);

        string sql = "select top 1 * from Log where author = '" + id + "' and draft = '0' and logid>'" + logid + "' order by logid ASC";

        DataTable dt = new DataTable();
        myClass myclass = new myClass();
        dt = myclass.JudgeIor(sql);

        Session["pagelogid1"] = dt.Rows[0][0].ToString();
        Server.Transfer("LogContent1.aspx");

    }

    protected void lbtForrow_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["id"].ToString());
        int logid = Convert.ToInt32(Request.QueryString["logid"]);

        string sql = "select top 1 * from Log where author = '" + id + "' and draft = '0' and logid>'" + logid + "' order by logid ASC";

        DataTable dt = new DataTable();
        myClass myclass = new myClass();
        dt = myclass.JudgeIor(sql);

        Session["pagelogid1"] = dt.Rows[0][0].ToString();
        Server.Transfer("LogContent1.aspx");
    }
}