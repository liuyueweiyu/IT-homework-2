using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Album_ThePhoto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        myClass myclass = new myClass();



        if (Session["id"] == null)
            Response.Write("<script>alert('请先登录！');location='../Login.aspx'</script>");
        else
        {
            int id;

            if (Session["Friendid"] != null)
            {
                id = Convert.ToInt32(Session["Friendid"].ToString());
                divMe.Visible = false;
                divFr.Visible = true;
            }
            else
                id = Convert.ToInt32(Session["id"].ToString());

            int photoid = Convert.ToInt32(Request.QueryString["photoid"]);

           string sql = "select * from Photo where photoid = '" + photoid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            int albumid = Convert.ToInt32(dt.Rows[0][4].ToString());
            sql = "select * from Album where albumid = '" + albumid + "'";
            dt = myclass.JudgeIor(sql);
            int sample = Convert.ToInt32(dt.Rows[0][3].ToString());
            if(sample!=id)
            {
                divMe.Visible = false;
                divFr.Visible = true;
            }

            if (!IsPostBack)
            {



                sql = "select * from Photo where photoid = '" + photoid + "'";

                //DataTable dt = new DataTable();

                dt = myclass.JudgeIor(sql);

                lbName.Text = dt.Rows[0][1].ToString();

                lbTime.Text = dt.Rows[0][2].ToString();

                imgPhoto.ImageUrl = dt.Rows[0][3].ToString();

                sql = "select * from Reply where classid = '" + photoid + "' and replyclass = 'photo'";

                dt = myclass.JudgeIor(sql);

                DataView dv = new DataView(dt);

                dv.Sort = "replyid desc";

                dt = dv.ToTable();

                rptPhoto.DataSource = dt;

                rptPhoto.DataBind();

                rptFr.DataSource = dt;

                rptFr.DataBind();
            }
        }
    }

    protected void btnReply_Click(object sender, EventArgs e)
    {

        int id = Convert.ToInt32(Session["id"].ToString());
        int friendid;

        if (Session["Friendid"] == null)
            friendid = id;
        else
            friendid = Convert.ToInt32(Session["Friendid"].ToString());

        string reply = txtReply.Text;

        if (reply.Length == 0)
            Response.Write("<script>alert('输入不能为空！')</script>");
        else
        {
            int photoid = Convert.ToInt32(Request.QueryString["photoid"]);

            DateTime now = DateTime.Now;

            myClass myclass = new myClass();

            string replyername = myclass.RerdName(id);
            string replyowenername = myclass.RerdName(friendid);
            string replyerscu = myclass.RerdSculpture(id);
            string replyownerscu = myclass.RerdSculpture(friendid);

            string replyclass = "photo";

            string sql = "insert into Reply (replytime,replyer,replyowner,replytext,replyername,replyownername,replyownerscu,replyerscu,replyclass,classid) values('" + now + "','" + id + "','" + friendid + "','" + reply + "','" + replyername + "','" + replyowenername + "','" + replyerscu + "','" + replyowenername + "','" + replyclass + "','" + photoid + "')";

            int flag = myclass.DataSQL(sql);

            //评论同时添加到个人中心
            DataTable dt = new DataTable();
            sql = "select * from State where photos = '" + photoid + "'";
            dt = myclass.JudgeIor(sql);
            int stateid = Convert.ToInt32(dt.Rows[0][0].ToString());
            sql = "insert into StateComment (_stateid,_stater,_stateowner,_statetime,_statement,_photoid,_statername,_staterownername) values('" + stateid + "','" + id + "','" + friendid + "','" + now + "','" + reply + "','" + photoid + "','" + replyername + "','" + replyowenername + "')";
            int stateflag = myclass.DataSQL(sql);


            if (flag == 1)
            {
                Response.Write("<script>alert('发布成功！')</script>");
                Server.Transfer("ThePhoto.aspx");
            }
        }
    }

    //用户内层repeater绑定
    protected void rptPhoto_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvw = (DataRowView)e.Item.DataItem;

            int ID = Convert.ToInt32(drvw["replyid"]);

            string replyclass = "photo";

            string sql = "select * from ReplyComment where _thereplyid=" + ID + " and _replyclass = '" + replyclass + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            Repeater rept = (Repeater)e.Item.FindControl("rptComment");

            rept.DataSource = dt;

            rept.DataBind();

        }
    }
    //用户外层repeater
    protected void rptPhoto_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.CommandName == "Delete")
        {
            int replyid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select * from Reply where replyid = '" + replyid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            string time = Convert.ToString(dt.Rows[0][1].ToString());

            sql = "delete from Reply where replyid='" + replyid + "'";

            int flag = myclass.DataSQL(sql);

            sql = "delete from StateComment where _statetime = '" + time + "'";

            flag = myclass.DataSQL(sql);

            if (flag == 1)
                Response.Write("<script>alert('删除成功！')</script>");
            Server.Transfer("ThePhoto.aspx");
        }

        if (e.CommandName == "Anwser")
        {
            if (((TextBox)e.Item.FindControl("txtAnwserCom")).Text.Length == 0)
                Response.Write("<script>alert('输入不能为空！')</script>");
            else
            {
                int id = Convert.ToInt32(Session["id"].ToString());

                int replyid = Convert.ToInt32(e.CommandArgument.ToString());

                string sql = "select * from Reply where replyid= '" + replyid + "' and replyclass = 'photo'";

                DataTable dt = new DataTable();

                dt = myclass.JudgeIor(sql);

                int replyownerid = Convert.ToInt32(dt.Rows[0][3].ToString());

                sql = "select * from UserList where id = '" + id + "'";

                dt = myclass.JudgeIor(sql);

                string replyername = dt.Rows[0][1].ToString();

                string replyerscu = dt.Rows[0][6].ToString();

                sql = "select * from UserList where id = '" + replyownerid + "'";

                dt = myclass.JudgeIor(sql);

                string replyownername = dt.Rows[0][1].ToString();

                string replyownerscu = dt.Rows[0][6].ToString();

                DateTime now = DateTime.Now;

                string txt = ((TextBox)e.Item.FindControl("txtAnwserCom")).Text;

                string replyclass = "photo";

                sql = "insert into ReplyComment (_replyowner,_replyer,_replytext,_replytime,_replyername,_replyownername,_replyerscu,_replyownerscu,_replyclass,_thereplyid) values('" + replyownerid + "','" + id + "','" + txt + "','" + now + "','" + replyername + "','" + replyownername + "','" + replyerscu + "','" + replyownerscu + "','" + replyclass + "','" + replyid + "')";

                int flag = myclass.DataSQL(sql);

                if (flag == 1)
                    Response.Write("<script>alert('回复成功！')</script>");
                Server.Transfer("ThePhoto.aspx");
            }


            if (e.CommandName == "Jump")
            {
                int friendid = Convert.ToInt32(e.CommandArgument.ToString());
                Session["Friendid"] = friendid.ToString();
                Response.Write("<script>window.location='../Person/Person.aspx'</script>");
            }
        }
    }

    //用户内层repeater
    protected void rptComment_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.CommandName == "Delete")
        {
            int _replyid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "delete from ReplyComment where _replyid='" + _replyid + "'";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
                Response.Write("<script>alert('删除成功！')</script>");
            Server.Transfer("ThePhoto.aspx");
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
    //好友内层repeater绑定
    protected void rptFr_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvw = (DataRowView)e.Item.DataItem;

            int ID = Convert.ToInt32(drvw["replyid"]);

            string replyclass = "photo";

            string sql = "select * from ReplyComment where _thereplyid=" + ID + " and _replyclass = '" + replyclass + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            Repeater rept = (Repeater)e.Item.FindControl("rptFrC");

            rept.DataSource = dt;

            rept.DataBind();
        }
    }
    //好友外城repeater
    protected void rptFr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.CommandName == "Anwser")
        {
            if (((TextBox)e.Item.FindControl("txtAnwserCom")).Text.Length == 0)
                Response.Write("<script>alert('输入不能为空！')</script>");
            else{
                int id = Convert.ToInt16(Session["id"].ToString());

                int replyid = Convert.ToInt32(e.CommandArgument.ToString());

                string sql = "select * from Reply where replyid= '" + replyid + "' and replyclass = 'photo'";

                DataTable dt = new DataTable();

                dt = myclass.JudgeIor(sql);

                int replyownerid = Convert.ToInt16(dt.Rows[0][3].ToString());

                sql = "select * from UserList where id = '" + id + "'";

                dt = myclass.JudgeIor(sql);

                string replyername = dt.Rows[0][1].ToString();

                string replyerscu = dt.Rows[0][6].ToString();

                sql = "select * from UserList where id = '" + replyownerid + "'";

                dt = myclass.JudgeIor(sql);

                string replyownername = dt.Rows[0][1].ToString();

                string replyownerscu = dt.Rows[0][6].ToString();

                DateTime now = DateTime.Now;

                string txt = ((TextBox)e.Item.FindControl("txtAnwserCom")).Text;

                string replyclass = "photo";

                sql = "insert into ReplyComment (_replyowner,_replyer,_replytext,_replytime,_replyername,_replyownername,_replyerscu,_replyownerscu,_replyclass,_thereplyid) values('" + replyownerid + "','" + id + "','" + txt + "','" + now + "','" + replyername + "','" + replyownername + "','" + replyerscu + "','" + replyownerscu + "','" + replyclass + "','" + replyid + "')";

                int flag = myclass.DataSQL(sql);



                if (flag == 1)
                    Response.Write("<script>alert('回复成功！')</script>");
                Server.Transfer("ThePhoto.aspx");
            }
        }


        if (e.CommandName == "Jump")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='../Person/Person.aspx'</script>");
        }
    }
    //好友内层repeater
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