using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Album_Photo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id;
        //判断显示用户界面还是好友界面
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

            int albumid = Convert.ToInt32(Request.QueryString["albumid"]);

            string sql = "select * from Photo where album = '" + albumid + "'";

            myClass myclass = new myClass();

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);
            //绑定用户视角repeater
            rptPhoto.DataSource = dt;

            rptPhoto.DataBind();
            //绑定好友视角repeater
            rptFr.DataSource = dt;

            rptFr.DataBind();
        }
    }

    protected void rptPhoto_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        myClass myclass = new myClass();

        //删除照片
        if (e.CommandName == "Delete")
        {
            int photoid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "delete from Photo where photoid='" + photoid + "'";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
            {
                Response.Write("<script>alert('删除成功！')</script>");
                Server.Transfer("Photo.aspx");
            }
        }

        if (e.CommandName == "Interface")
        {
            //修改封面
            int albumid = Convert.ToInt32(Request.QueryString["albumid"]);

            int photoid = Convert.ToInt32(e.CommandArgument.ToString());

            string sql = "select *from Photo where photoid='" + photoid + "'";

            DataTable dt = new DataTable();

            dt = myclass.JudgeIor(sql);

            string path = dt.Rows[0][3].ToString();

            sql = "update Album set interface='" + path + "' where albumid = '" + albumid + "'";

            int flag = myclass.DataSQL(sql);

            if (flag == 1)
            {
                Response.Write("<script>alert('修改成功！')</script>");
                Server.Transfer("Photo.aspx");
            }
        }
    }
    //判断文件是否为图片
    private static bool IsAllowedExtension(FileUpload upfile)
    {
        string strOldFilePath = "";
        string strExtension = "";
        string[] arrExtension = { ".gif", ".jpg", ".bmp", ".png" };
        if (upfile.PostedFile.FileName != string.Empty)
        {
            strOldFilePath = upfile.PostedFile.FileName;//获得文件的完整路径名 
            strExtension = strOldFilePath.Substring(strOldFilePath.LastIndexOf("."));//获得文件的扩展名，如：.jpg 
            for (int i = 0; i < arrExtension.Length; i++)
            {
                if (strExtension.Equals(arrExtension[i]))
                {
                    return true;
                }
            }
        }
        return false;
    }
    //图片上传并将图片重命名
    protected void btnUp_Click(object sender, EventArgs e)
    {
        myClass myclass = new myClass();

        int albumid = Convert.ToInt32(Request.QueryString["albumid"]);

        try
        {
            if (fup.PostedFile.FileName == "")
            {
                lblInfo.Text = "请选择文件！";
            }
            else
            {
                //string filepath = fup.PostedFile.FileName;
                if (!IsAllowedExtension(fup))
                {
                    lblInfo.Text = "上传文件格式不正确！";
                }
                if (IsAllowedExtension(fup) == true)
                {
                    //获取文件名字上传并存储
                    string filepath = fup.PostedFile.FileName;
                    string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath("picture/") + filename;
                    fup.PostedFile.SaveAs(serverpath);
                    //改绝对路径为相对路径
                    serverpath = "picture/" + filename;
                    DateTime now = DateTime.Now;
                    string sql = "insert into Photo (photoname,uptime,path,album)values('" + filename + "','" + now + "','" + serverpath + "','" + albumid + "')";
                    int flag = myclass.DataSQL(sql);
                    //判断相册权限决定是否发布动态到个人中心
                    sql = "select * from Album where albumid = '" + albumid + "'";
                    DataTable dt = new DataTable();
                    dt = myclass.JudgeIor(sql);
                    string compare = "所有人可见";
                    if (string.Compare(compare, dt.Rows[0][4].ToString()) == 0)
                    {

                        sql = "select * from Photo where uptime='" + now + "'and photoname = '" + filename + "'";

                        dt = myclass.JudgeIor(sql);
                        int photoid = Convert.ToInt32(dt.Rows[0][0].ToString());
                        int id = Convert.ToInt32(Session["id"].ToString());
                        string name = myclass.RerdName(id);
                        string sculpture = myclass.RerdSculpture(id);
                        string other = name + "上传了照片" + filename;
                        string state = "insert into State (stater,statetime,other,statelike,statername,staterscu,photos) values('" + id + "','" + now + "','" + other + "',',','" + name + "','" + sculpture + "','" + photoid + "')";
                        int stateflag = myclass.DataSQL(state);

                    }


                    if (flag == 1)
                    {

                        lblInfo.Text = "上传成功！";
                        Server.Transfer("Photo.aspx");
                    }
                    else
                        lblInfo.Text = "上传失败！";
                }
                else
                {
                    lblInfo.Text = "请上传图片！";
                }
            }
        }
        catch (Exception ex)
        {
            lblInfo.Text = "上传发生错误！原因是：" + ex.ToString();
        }
    }
}