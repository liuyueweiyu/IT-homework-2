using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Friend_FriendList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["id"].ToString());

        myClass myclass = new myClass();

        DataTable dt = new DataTable();

        string sql;

        sql = "select * from Friends where me='" + id + "'";

        dt = myclass.JudgeIor(sql);

        rptFriend.DataSource = dt;

        rptFriend.DataBind();
    }

    protected void rptFriend_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.CommandName == "Delete")
        {
            int relationid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select from Friends where relationid='" + relationid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            int me =Convert.ToInt32( dt.Rows[0][1].ToString());

            int friend = Convert.ToInt32(dt.Rows[0][2].ToString());
            //双向删除好友关系
            sql = "delete from Friends where me='" + me + "' and friends = '" + friend + "'";

            int flag = myclass.DataSQL(sql);

            sql = "delete from Friends where me='" + friend + "' and friends = '" + me + "'";

            flag = myclass.DataSQL(sql);

            if (flag == 1)
            {
                Response.Write("<script>alert('删除成功！');location='FriendList.aspx'</script>");
            }
        }
        //跳页
        if (e.CommandName == "Jump")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='../Person/Person.aspx'</script>");
        }
    }

    protected void lbtName_Click(object sender, EventArgs e)
    {
        //通过名字查找
        divName.Visible = true;
    }

    protected void lbtNumber_Click(object sender, EventArgs e)
    {
        //通过账号查找
        divNumber.Visible = true;
    }

    protected void btnName_Click(object sender, EventArgs e)
    {
        //传名字值
        Session["name"] = txtName.Text;
        Server.Transfer("Add.aspx");
    }

    protected void btnNumbre_Click(object sender, EventArgs e)
    {
        //传数字值
        Session["number"] = txtNumber.Text;
        Server.Transfer("Add.aspx");
    }
}