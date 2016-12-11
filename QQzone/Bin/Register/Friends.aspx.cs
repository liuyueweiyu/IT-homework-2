using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Friends : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Session["id"].ToString();


        string hobby = Session["hobby"].ToString();

        string sql1 = "select * from UserList where hobby ='" + hobby + "' and id <> '" + id + "'";

        myClass myclass = new myClass();

        DataTable dt = new DataTable();

        dt = myclass.JudgeIor(sql1);

        rptsomeFriend.DataSource = dt;

        rptsomeFriend.DataBind();

        string sql2 = "select * from UserList where id <> '" + id + "'";

        dt = myclass.JudgeIor(sql2);

        rptallFriend.DataSource = dt;

        rptallFriend.DataBind();

        if(!IsPostBack)
        {
            divSome.Visible = true;
            divAll.Visible = false;

        }

    }

    protected void rptFriends_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        int id = Convert.ToInt32(Session["id"].ToString());

        if (e.CommandName == "Add")
        {
             int _id = Convert.ToInt32(e.CommandArgument.ToString());

            string sql1 = "select * from Friends where  me='" + id + "' and friends = '" + _id + "'";
            int count = myclass.JudgeAcc(sql1);

            if (count > 0)
                Response.Write("<script>alert('好友已存在！')</script>");
            else
            {
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

        }
    }

    protected void btnAll_Click(object sender, EventArgs e)
    {
        divSome.Visible = true;
        divAll.Visible = true;
    }
}