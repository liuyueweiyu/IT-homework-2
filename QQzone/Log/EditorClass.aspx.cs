using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Log_EditorClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["id"] == null)
            Response.Write("<script>alert('请先登录！');location='../Login.aspx'</script>");
        else
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Session["id"].ToString());

                string sql = "select * from LogClass where logowner = '" + id + "'";

                myClass myclass = new myClass();

                DataTable dt = new DataTable();

                dt = myclass.JudgeIor(sql);

                rptClass.DataSource = dt;

                rptClass.DataBind();
            }
        }
    }

    protected void rptClass_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();
        //删除分类
        if (e.CommandName == "Delete")
        {
            int classid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select * from LogClass where classfyid = '" + classid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);
            //默认分类不能删
            string campare = "默认分类";

            if (string.Compare(campare, dt.Rows[0][1].ToString()) == 0)
                Response.Write("<script>alert('默认分类不能删除！')</script>");
            else
            {
                sql = "delete from LogClass where classfyid='" + classid + "'";

                int flag = myclass.DataSQL(sql);

                if (flag == 1)
                    Response.Write("<script>alert('删除成功！')</script>");
                Server.Transfer("EditorClass.aspx");
            }
        }
        //编辑分类名称
        if (e.CommandName == "Change")
        {
            int classid = Convert.ToInt32(e.CommandArgument.ToString());

            string txt = ((TextBox)e.Item.FindControl("txtName")).Text;

            string sql = "select * from LogClass where classfyid = '" + classid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);
            //默认分类不能修改
            string campare = "默认分类";

            if (txt.Length == 0)
                Response.Write("<script>alert('输入不能为空！')</script>");
            else if (string.Compare(campare, dt.Rows[0][1].ToString()) == 0)
                Response.Write("<script>alert('默认分类不能修改！')</script>");
            else
            {
                sql = "update LogClass set classfyname='" + txt + "' where classfyid='" + classid + "'";
                int flag = myclass.DataSQL(sql);
                if (flag == 1)
                    Response.Write("<script>alert('修改成功！')</script>");
                Server.Transfer("EditorClass.aspx");
            }
        }
    }

}