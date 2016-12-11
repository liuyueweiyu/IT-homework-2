using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Message_Message : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id;

        if (Session["id"] == null)
            Response.Write("<script>alert('请先登录！');location='../Login.aspx'</script>");
        else
        {
            if (!IsPostBack)
            {
                myClass myclass = new myClass();

                if (Session["Friendid"] != null)
                {
                    id = Convert.ToInt32(Session["Friendid"].ToString());
                    divMain.Visible = false;
                    divFr.Visible = true;
                }
                else
                    id = Convert.ToInt32(Session["id"].ToString());


                string sql = "select * from Massage where massageowner = '" + id + "'";

                DataTable dt = myclass.JudgeIor(sql);

                DataView dv = new DataView(dt);

                dv.Sort = "massageid desc";

                dt = dv.ToTable();

                rptMassage.DataSource = dt;

                rptMassage.DataBind();

                rptFr.DataSource = dt;

                rptFr.DataBind();
            }
        }
    }

    protected void btnSub_Click(object sender, EventArgs e)
    {
        int userid;
        myClass myclass = new myClass();
        if (Session["Friendid"] != null)
            userid = Convert.ToInt32(Session["Friendid"].ToString());
        else
            userid= Convert.ToInt32(Session["id"].ToString());
        int id = Convert.ToInt32(Session["id"].ToString());
        string massage = txtMassage.Text;
        DateTime now = DateTime.Now;
        if (massage.Length == 0)
            Response.Write("<script>alert('输入不能为空！')</script>");
        else
        {
            string name = myclass.RerdName(id);

            string sculpture = "../" + myclass.RerdSculpture(userid);

            //string sql = "insert into Massage (massageowner,massageuser,publishtime,massagetext,ownername,ownersculpture) values ('" + id + "','" + userid + "','" + now + "','" + massage + "'.'" + name + "','" + sculpture + "')";
            string sql = "insert into Massage (massageowner,massageuser,publishtime,massagetext,ownername,ownersculpture) values('" + userid + "','" + id + "','" + now + "','" + massage + "','" + name + "','" + sculpture + "')";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
                Response.Write("<script>alert('留言成功！');location='Message.aspx'</script>");
            else
                Response.Write("<script>alert('留言失败！')</script>");
        }
    }

    //用户外层repeater绑定
    protected void rptMassage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvw = (DataRowView)e.Item.DataItem;

            int ID = Convert.ToInt32(drvw["massageid"]);

            string sql = "select * from MassageComment where _massageid=" + ID + "";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            Repeater rept = (Repeater)e.Item.FindControl("rptComment");

            rept.DataSource = dt;

            rept.DataBind();

        }


    }

    //用户外层repeater
    protected void rptMassage_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.CommandName == "Delete")
        {
            int massageid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "delete from Massage where massageid='" + massageid + "'";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
                Response.Write("<script>alert('删除成功！')</script>");
            Server.Transfer("Message.aspx");
        }

        if (e.CommandName == "Anwser")
        {
            int id = Convert.ToInt32(Session["id"].ToString());

            int massageid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select * from Massage where massageid= '" + massageid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            int massageuserid = Convert.ToInt32(dt.Rows[0][3].ToString());

            DateTime now = DateTime.Now;

            string txt = ((TextBox)e.Item.FindControl("txtAnwserCom")).Text;

            //sql = "insert into MassageComment (_massageid,_massageownerid,_massageuserid,massagecommendtext,_publishtime) values('" + massageid + "','" + massageuserid + "','" + id + "','" + txt + "','" + now + "')";
            string massageusername = myclass.RerdName(id);
            string massageownername = myclass.RerdName(massageuserid);
            sql = "insert into MassageComment (_massageid,_massageownerid,_massageuserid,massagecommendtext,_publishtime,_massageownername,_massageusername) values('" + massageid + "','" + massageuserid + "','" + id + "','" + txt + "','" + now + "','" + massageownername + "','" + massageusername + "')";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
                Response.Write("<script>alert('回复成功！')</script>");
            Server.Transfer("Message.aspx");
        }

        if (e.CommandName == "Jump")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='../Person/Person.aspx'</script>");
        }
    }

    //用户内层repeater
    protected void rptComment_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.CommandName == "Delete")
        {
            int massagecommentid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "delete from MassageComment where massagecommentid='" + massagecommentid + "'";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
                Response.Write("<script>alert('删除成功！')</script>");
            Server.Transfer("Message.aspx");
        }
        if (e.CommandName == "Jump1")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='../Person/Person.aspx'</script>");
        }
        if (e.CommandName == "Jump2")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='../Person/Person.aspx'</script>");
        }
    }

    //好友外层repeater绑定
    protected void rptFr_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvw = (DataRowView)e.Item.DataItem;

            int ID = Convert.ToInt32(drvw["massageid"]);

            string sql = "select * from MassageComment where _massageid=" + ID + "";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            Repeater rept = (Repeater)e.Item.FindControl("rptFrC");

            rept.DataSource = dt;

            rept.DataBind();

        }
    }

    //好友外层repeater

    protected void rptFr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.CommandName == "Anwser")
        {
            int id = Convert.ToInt32(Session["id"].ToString());

            int massageid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select * from Massage where massageid= '" + massageid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            int massageuserid = Convert.ToInt32(dt.Rows[0][3].ToString());

            DateTime now = DateTime.Now;
            string txt = ((TextBox)e.Item.FindControl("txtAnwserComment")).Text; 
            string massageusername = myclass.RerdName(id);
            string massageownername = myclass.RerdName(massageuserid);

           

             sql = "insert into MassageComment (_massageid,_massageownerid,_massageuserid,massagecommendtext,_publishtime,_massageownername,_massageusername) values('" + massageid + "','" + massageuserid + "','" + id + "','" + txt + "','" + now + "','" + massageownername + "','" + massageusername + "')";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
                Response.Write("<script>alert('回复成功！')</script>");
            Server.Transfer("Message.aspx");
        }
        if (e.CommandName == "Jump")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='../Person/Person.aspx'</script>");
        }

    }

    //好友repeater
    protected void rptFrC_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Jump1")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='../Person/Person.aspx'</script>");
        }
        if (e.CommandName == "Jump2")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='../Person/Person.aspx'</script>");
        }
    }
}