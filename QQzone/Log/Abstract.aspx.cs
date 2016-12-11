using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Log_Abstract : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql;

        if (Session["id"] == null)
            Response.Write("<script>alert('请先登录！');location='../Login.aspx'</script>");
        else
        {

            int id;

            if (Session["Friendid"] != null)
            {
                id = Convert.ToInt32(Session["Friendid"].ToString());
                divMe.Visible = false;
                divMetoo.Visible = false;
                sql = "select * from Log where author='" + id + "'and draft = '0' and logpower = '所有人可见'";
            }
            else
            {
                id = Convert.ToInt32(Session["id"].ToString());
                sql = "select * from Log where author='" + id + "'and draft = '0'";
            }

            myClass myclass = new myClass();

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            rptLog.DataSource = dt;

            rptLog.DataBind();

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
        int id = Convert.ToInt16(Session["id"].ToString());
        string classname = txtAdd.Text;

        if (classname.Length == 0)
            Response.Write("<script>alert('输入不能为空！')</script>");
        else
        {
            string sql = "insert into LogClass (logowner,classfyname) values('" + id + "','" + classname + "')";

            myClass myclass = new myClass();

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
                Response.Write("<script>alert('添加成功！')</script>");
            else
                Response.Write("<script>alert('添加失败！')</script>");
            Server.Transfer("Abstract.aspx");
        }
    }


    protected void rptClassfy_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.CommandName == "Delete")
        {
            int classfyid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select * from LogClass where classfyid = '" + classfyid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            string campare = "默认分类";

            if (string.Compare(campare, dt.Rows[0][1].ToString()) == 0)
                Response.Write("<script>alert('默认分类不能删除！')</script>");
            else
            {
                sql = "delete from LogClass where classfyid='" + classfyid + "'";

                int flag = myclass.DataSQL(sql);

                if (flag == 1)
                {
                    Response.Write("<script>alert('删除成功！')</script>");
                    Server.Transfer("Abstract.aspx");
                }
            }
        }
    }
}