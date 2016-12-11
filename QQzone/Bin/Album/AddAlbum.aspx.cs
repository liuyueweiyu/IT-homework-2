using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Album_AddAlbum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
            Response.Write("<script>alert('请先登录！');location='../Login.aspx'</script>");
    }


    protected void btnSub_Click(object sender, EventArgs e)
    {
        myClass myclass = new myClass();

        int id = Convert.ToInt32(Session["id"].ToString());

        string name = txtName.Text;
        string authority = rdlAuthority.SelectedValue;

        if (name.Length == 0)
            Response.Write("<script>alert('名称不能为空！')</script>");
        else
        {
            string interfaces = "picture/QQ截图20161126121705.png";
            string sql = "insert into Album (albumname,interface,owner,authority) values('" + name + "','" + interfaces + "','" + id + "','" + authority + "')";
            int flag = myclass.DataSQL(sql);
            if (flag == 1)
                Response.Write("<script>alert('添加成功！');location='Album.aspx'</script>");
            else
                Response.Write("<script>alert('添加失败！');location='AddAlbum.aspx'</script>");
        }

    }
}