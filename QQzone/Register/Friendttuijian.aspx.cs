using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Friendttuijian : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string hobby = radlHobby.SelectedValue;
        int id = Convert.ToInt32(Session["id"].ToString());
        string sql = "update UserList set hobby = '" + hobby + "' where id='" + id + "'";
        myClass myclass = new myClass();
        myclass.DataSQL(sql);
        Session["hobby"] = hobby;
        Server.Transfer("Friends.aspx");
    }
}