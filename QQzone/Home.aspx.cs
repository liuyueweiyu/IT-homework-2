using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            myClass myclass = new myClass();
            if (Session["id"] == null)
            {
                Response.Write("<script>alert('请先登录！')</script>");
                Server.Transfer("Login.aspx");
            }
            else
            {
                int id = Convert.ToInt32(Session["id"].ToString());

                DataTable dt = new DataTable();

                int i, count;
                DataTable newdt = new DataTable();
                string sql = "select * from State ";
                newdt = myclass.JudgeIor(sql);

                sql = "select * from Friends where me='" + id + "'";

                dt = myclass.JudgeIor(sql);

                count = dt.Rows.Count;

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    sql = "select * from State where stater='" + Convert.ToInt32(dt.Rows[0][i].ToString()) + "'";
                    dt = myclass.JudgeIor(sql);
                    if (dt.Rows.Count != 0)
                        newdt.Merge(dt);
                }

                DataView dv = new DataView(newdt);

                dv.Sort = "stateid desc";

                dt = dv.ToTable();

                rptState.DataSource = dt;

                rptState.DataBind();
            }
        }
    }

    protected void btnSub_Click(object sender, EventArgs e)
    {
        myClass myclass = new myClass();

        int id = Convert.ToInt32(Session["id"].ToString());
        string state = txtState.Text;
        DateTime now = DateTime.Now;
        if (state.Length == 0)
            Response.Write("<script>alert('输入不能为空！')</script>");
        else
        {
            string name = myclass.RerdName(id);
            string sculpture = myclass.RerdSculpture(id);
            string sql = "insert into State (stater,statetime,statement,statelike,statername,staterscu) values('" + id + "','" + now + "','" + state + "',',','" + name + "','" + sculpture + "')";
            int flag = myclass.DataSQL(sql);
            if (flag == 1)
                Response.Write("<script>alert('发布成功！');location='Home.aspx'</script>");
        }
    }




    protected void rptState_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvw = (DataRowView)e.Item.DataItem;

            int ID = Convert.ToInt32(drvw["stateid"]);

            string sql = "select * from StateComment where _stateid=" + ID + "";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            Repeater rept = (Repeater)e.Item.FindControl("rptComment");

            rept.DataSource = dt;

            rept.DataBind();

        }

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvw = (DataRowView)e.Item.DataItem;

            int ID = Convert.ToInt32(drvw["stateid"]);

            string sql = "select * from State where stateid=" + ID + "";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            if (dt.Rows[0][10].ToString().Length==0)
            {
                LinkButton Log = (LinkButton)e.Item.FindControl("lbtLog");
                Log.Visible = false;
            }
            if (dt.Rows[0][11].ToString().Length==0)
            {
                LinkButton Photo = (LinkButton)e.Item.FindControl("lbtPhoto");
                Photo.Visible = false;
                Image imgPhoto = (Image)e.Item.FindControl("imgPhoto");
                imgPhoto.Visible = false;
            }
        }
    }

    protected void rptState_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        if (e.CommandName == "Anwser")
        {
            int id = Convert.ToInt32(Session["id"].ToString());

            int stateid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select * from State where stateid= '" + stateid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            int staterid = Convert.ToInt32(dt.Rows[0][1].ToString());

            string statername = myclass.RerdName(staterid);

            string name = myclass.RerdName(id);

            DateTime now = DateTime.Now;

            string txt = ((TextBox)e.Item.FindControl("txtAnwserCom")).Text;

            if (txt.Length == 0)
                Response.Write("<script>alert('输入不能为空！')</script>");
            else
            {
                //判断是否要添加到相册/日志
                int flag, stateflag;

                string locks = "上传";

                if (dt.Rows[0][3].ToString().Length != 0)
                {
                    //发表说说不需要同步评论
                    stateflag = 1;
                    sql = "insert into StateComment (_stateid,_stater,_stateowner,_statetime,_statement,_statername,_staterownername) values('" + stateid + "','" + id + "','" + staterid + "','" + now + "','" + txt + "','" + name + "','" + statername + "')";
                    flag = myclass.DataSQL(sql);
                }
                else if (dt.Rows[0][8].ToString().Contains(locks))
                {
                    //上传相册同步评论到相册
                    int photoid = Convert.ToInt32(dt.Rows[0][11].ToString());

                    string sculpture = myclass.RerdSculpture(id);

                    sql = "insert into StateComment (_stateid,_stater,_stateowner,_statetime,_statement,_photoid,_statername,_staterownername) values('" + stateid + "','" + id + "','" + staterid + "','" + now + "','" + txt + "','" + photoid + "','" + name + "','" + statername + "')";

                    flag = myclass.DataSQL(sql);

                    string replyclass = "photo";

                    sql = "insert into Reply (replytime,replyer,replyowner,replytext,replyername,replyownername,replyownerscu,replyerscu,replyclass,classid) values('" + now + "','" + id + "','" + id + "','" + txt + "','" + name + "','" + name + "','" + sculpture + "','" + sculpture + "','" + replyclass + "','" + photoid + "')";

                    stateflag = myclass.DataSQL(sql);
                }
                else
                {
                    //上传相册同步评论到日志
                    int logid = Convert.ToInt32(dt.Rows[0][10].ToString());

                    string sculpture = myclass.RerdSculpture(id);

                    sql = "insert into StateComment (_stateid,_stater,_stateowner,_statetime,_statement,_logid,_statername,_staterownername) values('" + stateid + "','" + id + "','" + staterid + "','" + now + "','" + txt + "','" + logid + "','" + name + "','" + statername + "')";

                    flag = myclass.DataSQL(sql);

                    string replyclass = "log";

                    sql = "insert into Reply (replytime,replyer,replyowner,replytext,replyername,replyownername,replyownerscu,replyerscu,replyclass,classid) values('" + now + "','" + id + "','" + id + "','" + txt + "','" + name + "','" + name + "','" + sculpture + "','" + sculpture + "','" + replyclass + "','" + logid + "')";

                    stateflag = myclass.DataSQL(sql);
                }


                if (flag == 1)
                    Response.Write("<script>alert('回复成功！');location='Home.aspx'</script>");
            }
        }



        if (e.CommandName == "Like")
        {
            int id = Convert.ToInt32(Session["id"].ToString());

            int stateid = Convert.ToInt32(e.CommandArgument.ToString());

            string locks = ',' + Convert.ToString(id) + ',';

            string sql = "select * from State where stateid = '" + stateid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            string like = dt.Rows[0][6].ToString();

            if (like.Contains(locks))
                Response.Write("<script>alert('已经点过赞了哟！');location='Home.aspx'</script>");
            else
            {
                like = dt.Rows[0][6].ToString() + Convert.ToString(id) + ',';

                int count = Convert.ToInt32(dt.Rows[0][7].ToString()) + 1;
               
                sql = "update State set statelike ='" + like + "',statelikecount = '" + count + "' where stateid = '" + stateid + "'";

                int flag = myclass.DataSQL(sql);
                Server.Transfer("Home.aspx");

            }
        }

        if (e.CommandName == "Jump")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='Person/Person.aspx'</script>");
        }

       /* if (e.CommandName == "DetailLog")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
        }

        if (e.CommandName == "DetailPhoto")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
        }*/
    }


    protected void rptComment_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Jump1")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='Person/Person.aspx'</script>");
        }

        if (e.CommandName == "Jump2")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            //Server.Transfer("Person/Person.asxp");
            Response.Write("<script>window.location='Person/Person.aspx'</script>");
        }
    }

    protected void lbtConcel_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Write("<script>alert('注销成功！');location='Login.aspx'</script>");
    }

}