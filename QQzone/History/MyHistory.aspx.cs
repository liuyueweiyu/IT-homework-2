using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class History_MyHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //判断是否登陆
            myClass myclass = new myClass();
            if (Session["id"] == null)
            {
                Response.Write("<script>alert('请先登录！')</script>");
                Server.Transfer("Login.aspx");
            }
            else
            {

                int id;
                //判断进入页面
                if (Session["Friendid"] != null)
                {
                    id = Convert.ToInt32(Session["Friendid"].ToString());
                    divMe.Visible = false;
                    divFr.Visible = true;
                }
                else
                    id = Convert.ToInt32(Session["id"].ToString());

                DataTable dt = new DataTable();
                string sql = "select * from State ";

                sql = "select * from State where stater ='" + id + "'";

                dt = myclass.JudgeIor(sql);
                //新建识图排序
                DataView dv = new DataView(dt);

                dv.Sort = "stateid desc";

                dt = dv.ToTable();
                //绑定用户界面repeater
                rptState.DataSource = dt;

                rptState.DataBind();
                //绑定好友界面repeater
                rptFr.DataSource = dt;

                rptFr.DataBind();
            }
        }
    }



    protected void btnSub_Click(object sender, EventArgs e)
    {
        myClass myclass = new myClass();

        int id = Convert.ToInt32(Session["id"].ToString());
        string state = txtState.Text;
        DateTime now = DateTime.Now;
        //判断空值
        if (state.Length == 0)
            Response.Write("<script>alert('输入不能为空！')</script>");
        else
        {
            //发表说说
            string name = myclass.RerdName(id);
            string sculpture = myclass.RerdSculpture(id);
            string sql = "insert into State (stater,statetime,statement,statelike,statername,staterscu) values('" + id + "','" + now + "','" + state + "',',','" + name + "','" + sculpture + "')";
            int flag = myclass.DataSQL(sql);
            if (flag == 1)
                Response.Write("<script>alert('发布成功！');location='Myhistory.aspx'</script>");
        }
    }



    //内层repeater绑定
    protected void rptState_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        myClass myclass = new myClass();
        //内层repeater绑定
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
        //判断外层repeater中部分控件是否显示
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvw = (DataRowView)e.Item.DataItem;

            int ID = Convert.ToInt32(drvw["stateid"]);

            string sql = "select * from State where stateid=" + ID + "";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);
            //显示图片相关控件
            if (dt.Rows[0][10].ToString().Length == 0)
            {
                LinkButton Log = (LinkButton)e.Item.FindControl("lbtLog");
                Log.Visible = false;
            }
            //显示日志部分控件
            if (dt.Rows[0][11].ToString().Length == 0)
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

        //发表评论
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
                    Response.Write("<script>alert('回复成功！');location='Myhistory.aspx'</script>");
            }
        }


        //点赞
        if (e.CommandName == "Like")
        {
            int id = Convert.ToInt32(Session["id"].ToString());

            int stateid = Convert.ToInt32(e.CommandArgument.ToString());

            string locks = ',' + Convert.ToString(id) + ',';

            string sql = "select * from State where stateid = '" + stateid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);
            
            string like = dt.Rows[0][6].ToString();
            //判断是否重复点赞
            if (like.Contains(locks))
                Response.Write("<script>alert('已经点过赞了哟！');location='Myhistory.aspx'</script>");
            else
            {
                like = dt.Rows[0][6].ToString() + Convert.ToString(id) + ',';

                int count = Convert.ToInt32(dt.Rows[0][7].ToString()) + 1;

                sql = "update State set statelike ='" + like + "',statelikecount = '" + count + "' where stateid = '" + stateid + "'";

                int flag = myclass.DataSQL(sql);
                Server.Transfer("Myhistory.aspx");

            }
        }
        //删除
        if (e.CommandName == "Delete")
        {
            int stateid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select * from State where stateid = '" + stateid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);
            //同步删除照片
            if (dt.Rows[0][10].ToString().Length==0)

            {
                int photoid = Convert.ToInt32(dt.Rows[0][11].ToString());

                sql = "delete from Photo where photoid='" + photoid + "'";

                myclass.DataSQL(sql);
            }
            //同步删除日志
            else
            {
                int logid = Convert.ToInt32(dt.Rows[0][10].ToString());

                sql = "delete from Log where logid='" + logid + "'";

                myclass.DataSQL(sql);
            }
            //删除动态

            sql = "delete from State where stateid='" + stateid + "'";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
                Response.Write("<script>alert('删除成功！');location='Myhistory.aspx'</script>");
        }
        //跳页
        if (e.CommandName == "Jump")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='Person/Person.aspx'</script>");
        }
    }


    protected void rptComment_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();
        //跳页
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
            Response.Write("<script>window.location='Myhistory.aspx'</script>");
        }
        //删除评论
        if (e.CommandName == "Delete")
        {
            int statecommentid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select * from StateComment where statecommentid = '" + statecommentid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);
            
            string time = dt.Rows[0][3].ToString();

            //同步删除照片评论
            if (dt.Rows[0][6].ToString().Length==0)
            {
                int classid = Convert.ToInt32(dt.Rows[0][7].ToString());
                string classfy = "photo";
                sql = "delete from Reply where replytime='" + time + "' and classid ='" + classid + "' and replyclass = '" + classfy + "' ";
                myclass.DataSQL(sql);
            }
            //同步删除日志评论
            else
            {
                    int classid = Convert.ToInt32(dt.Rows[0][6].ToString());
                    string classfy = "log";
                    sql = "delete from Reply where replytime='" + time + "' and classid ='" + classid + "' and replyclass = '" + classfy + "' ";
                    myclass.DataSQL(sql);
              
            }
            //删除评论
            sql = "delete from StateComment where statecommentid='" + statecommentid + "'";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
                Response.Write("<script>alert('删除成功！');location='Myhistory.aspx'</script>");

        }

    }
    
    protected void rptFr_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        myClass myclass = new myClass();
        //绑定内层repeater
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvw = (DataRowView)e.Item.DataItem;

            int ID = Convert.ToInt32(drvw["stateid"]);

            string sql = "select * from StateComment where _stateid=" + ID + "";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            Repeater rept = (Repeater)e.Item.FindControl("rptCom");

            rept.DataSource = dt;

            rept.DataBind();

        }
        //控制repeater控件中部分控件是否显示
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drvw = (DataRowView)e.Item.DataItem;

            int ID = Convert.ToInt32(drvw["stateid"]);

            string sql = "select * from State where stateid=" + ID + "";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);
            //显示相册相关控件
            if (dt.Rows[0][10].ToString().Length == 0)
            {
                LinkButton Log = (LinkButton)e.Item.FindControl("lbtLog");
                Log.Visible = false;
            }
            //显示日志相关控件
            if (dt.Rows[0][11].ToString().Length == 0)
            {
                LinkButton Photo = (LinkButton)e.Item.FindControl("lbtPhoto");
                Photo.Visible = false;
                Image imgPhoto = (Image)e.Item.FindControl("imgPhoto");
                imgPhoto.Visible = false;
            }
        }
    }

    protected void rptFr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();
        //回复
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
                    Response.Write("<script>alert('回复成功！');location='Myhistory.aspx'</script>");
            }
        }


        //点赞
        if (e.CommandName == "Like")
        {
            int id = Convert.ToInt32(Session["id"].ToString());

            int stateid = Convert.ToInt32(e.CommandArgument.ToString());

            string locks = ',' + Convert.ToString(id) + ',';

            string sql = "select * from State where stateid = '" + stateid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            string like = dt.Rows[0][6].ToString();
            //不能重复点赞
            if (like.Contains(locks))
                Response.Write("<script>alert('已经点过赞了哟！');location='Myhistory.aspx'</script>");
            else
            {
                like = dt.Rows[0][6].ToString() + Convert.ToString(id) + ',';

                int count = Convert.ToInt32(dt.Rows[0][7].ToString()) + 1;

                sql = "update State set statelike ='" + like + "',statelikecount = '" + count + "' where stateid = '" + stateid + "'";

                int flag = myclass.DataSQL(sql);
                Server.Transfer("Myhistory.aspx");

            }
        }
        //跳页
        if (e.CommandName == "Jump")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='Myhistory.aspx'</script>");
        }
    }

    protected void rptCom_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //跳页
        if (e.CommandName == "Jump1")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            Response.Write("<script>window.location='Myhistory.aspx'</script>");
        }

        if (e.CommandName == "Jump2")
        {
            int friendid = Convert.ToInt32(e.CommandArgument.ToString());
            Session["Friendid"] = friendid.ToString();
            //Server.Transfer("Person/Person.asxp");
            Response.Write("<script>window.location='Myhistory.aspx'</script>");
        }


    }
}