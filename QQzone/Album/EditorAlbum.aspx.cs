using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Album_EditorAlbum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
            Response.Write("<script>alert('请先登录！');location='../Login.aspx'</script>");
        else
        {
            myClass myclass = new myClass();

            int albumid = Convert.ToInt32(Request.QueryString["albumid"]);
            string sql = "select * from Album where albumid='" + albumid + "'";
            DataTable dt = new DataTable();
            dt = myclass.JudgeIor(sql);
            albumname.Text = dt.Rows[0][1].ToString();
            imgSculpture.ImageUrl = dt.Rows[0][2].ToString();
        }
    }

    protected void btnName_Click(object sender, EventArgs e)
    {
        myClass myclass = new myClass();

        int albumid = Convert.ToInt32(Request.QueryString["albumid"]);
        string name = changename.Text;
        if(name.Length==0)
            Response.Write("<script>alert('输入不能为空！')</script>");
        {
            string sql = "update Album set albumname='" + name + "' where albumid='" + albumid + "'";
            int flag = myclass.DataSQL(sql);
            if (flag == 1)
                Response.Write("<script>alert('修改成功！')</script>");
            Server.Transfer("EditorAlbum.aspx");
        }
    }

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

        if (fup.PostedFile.FileName == "")
            Response.Write("<script>alert('请选择文件！')</script>");
        else
        {
            //string filepath = fup.PostedFile.FileName;
            if (!IsAllowedExtension(fup))
                Response.Write("<script>alert('文件类型不正确！')</script>");
            if (IsAllowedExtension(fup) == true)
            {
                string filepath = fup.PostedFile.FileName;
                string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                string serverpath = Server.MapPath("picture/") + filename;
                fup.PostedFile.SaveAs(serverpath);
                serverpath = "picture/" + filename;
                DateTime now = DateTime.Now;
                string sql = "update Album set interface='" + serverpath + "' where albumid='" + albumid + "'";
                int flag = myclass.DataSQL(sql);
                if (flag == 1)
                {
                    Response.Write("<script>alert('修改成功！')</script>");
                    Server.Transfer("EditorAlbum.aspx");
                }
                else
                    Response.Write("<script>alert('修改失败！')</script>");
            }
            else
                Response.Write("<script>alert('请上传图片！')</script>");
        }


    }

    protected void btnAuthority_Click(object sender, EventArgs e)
    {
        myClass myclass = new myClass();

        int albumid = Convert.ToInt32(Request.QueryString["albumid"]);

        string authority = rdlAuthority.SelectedValue;
        string sql = "update Album set authority='" + authority + "'where albumid = '" + albumid + "'";

        int flag = myclass.DataSQL(sql);

        if (flag == 1)
            Response.Write("<script>alert('修改成功！')</script>");
        else
            Response.Write("<script>alert('修改失败！')</script>");

    }
}