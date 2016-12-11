using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Friend_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id;

        string sql;


        if (Session["id"] == null)
            Response.Write("<script>alert('请先登录！');location='../Login.aspx'</script>");
        else
        {
            id = Convert.ToInt32(Session["id"].ToString());

            DataTable dt = new DataTable();

            myClass myclass = new myClass();

            if (Session["name"]==null)
            {
                int number =Convert.ToInt32( Session["number"].ToString());

                sql = "select * from UserList where id like'%" + number + "%'";

                dt = myclass.JudgeIor(sql);
            }
            else
            {
                string name = Session["name"].ToString();

                sql = "select * from UserList where name like'%" + name + "%'";

                dt = myclass.JudgeIor(sql);
            }



            rptAdd.DataSource = dt;

            rptAdd.DataBind();

        }
    }


    protected void rptAdd_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.CommandName == "Add")
        {
            int _id = Convert.ToInt32(e.CommandArgument.ToString());
            int id = Convert.ToInt32(Session["id"].ToString());

            string name = myclass.RerdName(id);
            string _name = myclass.RerdName(_id);

            string sql = "insert into Friends (me,friends,myname,friendname) values('" + id + "','" + _id + "','" + name + "','" + _name + "')";
            string _sql = "insert into Friends (me,friends,myname,friendname) values('" + _id + "','" + id + "','" + _name + "','" + name + "')";

            int flag = myclass.DataSQL(sql);
            int _flag = myclass.DataSQL(_sql);


            if (flag == 1 && _flag == 1)
                Response.Write("<script>alert('添加成功！')</script>");
            else
                Response.Write("<script>alert('添加失败！')</script>");
        }


        if (e.CommandName == "Jump")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='Person/Person.aspx'</script>");
        }
    }
}