using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageOwner : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id;

        if (Session["id"] == null)
            Response.Write("<script>alert('请先登录！');location='../Login.aspx'</script>");
        else
        {

            if (Session["Friendid"] != null)
            {
                id = Convert.ToInt32(Session["Friendid"].ToString());
                divMe.Visible = false;
                divFr.Visible = true;
            }
            else
                id = Convert.ToInt32(Session["id"].ToString());
            if (!IsPostBack)
            {
                myClass myclass = new myClass();


                string sql = "select * from UserList where id = '" + id + "'";

                DataTable dt = new DataTable();

                dt = myclass.JudgeIor(sql);
                scup.ImageUrl = dt.Rows[0][6].ToString();
                lbName.Text = dt.Rows[0][1].ToString();
            }
        }  

    }


    protected void lbtFr_Click(object sender, EventArgs e)
    {
        Session.Remove("Friendid");
        divFr.Visible = false;
        divMe.Visible = true;
        Response.Write("<script>window.location='../Home.aspx'</script>");
    }
}
