using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Album_Album : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
            myClass myclass = new myClass();

            string sql = "select * from Album where owner='" + id + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);
            //构建视图排序
            DataView dv = new DataView(dt);

            dv.Sort = "albumid desc";

            dt = dv.ToTable();
            //绑定用户视角repeater
            rptAlbum.DataSource = dt;

            rptAlbum.DataBind();
            //绑定好友视角repeater
            sql = "select * from Album where owner='" + id + "' and authority='所有人可见'";

            dt = myclass.JudgeIor(sql);

            DataView dvx = new DataView(dt);

            dv.Sort = "albumid desc";

            dt = dvx.ToTable();

            rptFr.DataSource = dt;

            rptFr.DataBind();
        }
    }

     protected void rptAlbum_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        //删除相册
        if (e.CommandName == "Delete")
        {
            int albumid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "delete from Album where albumid='" + albumid + "'";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
                Response.Write("<script>alert('删除成功！');location='Album.aspx'</script>");
        }
    }
}
