using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Log_Logclassfy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
            Response.Write("<script>alert('请先登录！');location='../Login.aspx'</script>");
        else
        {
            int id = Convert.ToInt32(Session["id"].ToString());;

            int classfyid = Convert.ToInt32(Request.QueryString["classfyid"]);

            myClass myclass = new myClass();

            string sql = "select * from Log where author='" + id + "' and draft = '0' and _classfyid = '" + classfyid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            rptLog.DataSource = dt;

            rptLog.DataBind();

            sql = "select * from LogClass where classfyid = '" + classfyid + "'";

            dt = myclass.JudgeIor(sql);

            lbClass.Text = dt.Rows[0][1].ToString();

            sql = "select * from LogClass where logowner = '" + id + "'";

            dt = myclass.JudgeIor(sql);

            rptClassfy.DataSource = dt;

            rptClassfy.DataBind();
        }
    }

    protected void rptLog_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }


    protected void Unnamed_Click(object sender, EventArgs e)
    {
        divAdd.Visible = true;
    }

    protected void btnSub_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["id"].ToString());
        string classname = txtAdd.Text;
        string sql = "insert into LogClass (logowner,classfyname) values('" + id + "','" + classname + "')";

        myClass myclass = new myClass();

        int flag = myclass.DataSQL(sql);

        if (flag == 1)
            Response.Write("<script>alert('添加成功！')</script>");
        else
            Response.Write("<script>alert('添加失败！')</script>");
        Server.Transfer("Log.aspx");
    }

    protected void lbtEditor_Click(object sender, EventArgs e)
    {
        divEditor.Visible = true;
    }

    protected void btnSub_Click1(object sender, EventArgs e)
    {

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
}