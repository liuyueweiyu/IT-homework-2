using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Person_Person : System.Web.UI.Page
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
                divScu.Visible = false;
                divEditor.Visible = false;
            }
            else
                id = Convert.ToInt32(Session["id"].ToString());

            string sql = "select * from Log where author= '" + id + "' and draft = '0'";

            DataTable dt = new DataTable();
            //绑定日志数量
            dt = myclass.JudgeIor(sql);

            lbtLog.Text = dt.Rows.Count.ToString() + "篇日志";

            sql = "select * from Album where owner='" + id + "' ";

            dt = myclass.JudgeIor(sql);
            //相册数量
            int i, sum = 0;

            int count = dt.Rows.Count;

            DataTable newdt = new DataTable();

            for (i = 0; i < count; i++)
            {
                sql = "select * from Photo where album='" + Convert.ToInt32(dt.Rows[i][0].ToString()) + "'";
                newdt = myclass.JudgeIor(sql);
                sum = sum + newdt.Rows.Count;
            }

            lbtAlbum.Text = Convert.ToString(sum) + "张照片";
            //留言数量
            sql = "select * from Massage where massageowner ='" + id + "'";
            dt = myclass.JudgeIor(sql);
            lbtMassage.Text = Convert.ToString(dt.Rows.Count) + "条留言";

            //访客记录
            if (Session["friendid"] != null)
            {
                int freindid = Convert.ToInt32(Session["friendid"].ToString());
                int theid = Convert.ToInt32(Session["id"].ToString());
                DateTime now = DateTime.Now;
                string name = myclass.RerdName(id);
                string scu = "../Album" + myclass.RerdSculpture(id);
                sql = "insert into Visitor(visitor,bevisitor,visitetime,visitorname,visitorscu) values('" + theid + "','" + freindid + "','" + now + "','" + name + "','" + scu + "')";
                myclass.DataSQL(sql);
            }

            sql = "select * from UserList where id='" + id + "'";
            dt = myclass.JudgeIor(sql);
            lbID.Text = dt.Rows[0][0].ToString();
            lbName.Text = dt.Rows[0][1].ToString();
            lbSex.Text = dt.Rows[0][3].ToString();
            lbEmail.Text = dt.Rows[0][7].ToString();
            lbPhone.Text = dt.Rows[0][8].ToString();
        }
    }

    protected void btnUp_Click(object sender, EventArgs e)
    {
        myClass myclass = new myClass();

        int id = Convert.ToInt32(Session["id"].ToString());

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
                    string filepath = fup.PostedFile.FileName;
                    string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath("../Album/picture/") + filename;
                    fup.PostedFile.SaveAs(serverpath);
                    serverpath = "Album/picture/" + filename;
                    string sql = "update UserList set sculpture='" + serverpath + "' where id='" + id + "'";
                    int flag=myclass.DataSQL(sql);
                    sql = "update Massage set ownersculpture='" + serverpath + "' where massageowner='" + id + "'";
                    flag = myclass.DataSQL(sql);
                    sql = "update Reply set replyerscu='" + serverpath + "' where replyer='" + id + "'";
                    flag = myclass.DataSQL(sql);
                    sql = "update Reply set replyownerscu='" + serverpath + "' where replyowner='" + id + "'";
                    flag = myclass.DataSQL(sql);
                    sql = "update State set staterscu='" + serverpath + "' where stater='" + id + "'";
                    flag = myclass.DataSQL(sql);
                    if (flag == 1)
                    {

                        lblInfo.Text = "上传成功！";
                        Server.Transfer("Person.aspx");
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
    protected void lbtEditor_Click(object sender, EventArgs e)
    {
        divName.Visible = true;
        divPhone.Visible = true;
        divSex.Visible = true;
        divEmail.Visible = true;
        divEditor.Visible = false;
    }

    protected void btnName_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["id"].ToString());

        string name = txtName.Text;

        if (name.Length == 0)
            Response.Write("<script>alert('输入不能为空！')</script>");
        else
        {
            myClass myclass = new myClass();

            string sql = "update UserList set name='" + name + "' where id='" + id + "'";
            myclass.DataSQL(sql);
            sql = "update Massage set ownername='" + name + "' where massageowner='" + id + "'";
            myclass.DataSQL(sql);
            sql = "update MassageComment set _massageownername='" + name + "' where _massageownerid='" + id + "'";
            myclass.DataSQL(sql);
            sql = "update MassageComment set _massageusername='" + name + "' where _massageuserid='" + id + "'";
            myclass.DataSQL(sql);
            sql = "update Reply set replyername='" + name + "' where replyer='" + id + "'";
            myclass.DataSQL(sql);
            sql = "update Reply set replyownername='" + name + "' where replyowner='" + id + "'";
            myclass.DataSQL(sql);
            sql = "update ReplyComment set _replyername='" + name + "' where _replyer='" + id + "'";
            myclass.DataSQL(sql);
            sql = "update ReplyComment set _replyownername='" + name + "' where _replyowner='" + id + "'";
            myclass.DataSQL(sql);
            sql = "update State set statername='" + name + "' where stater='" + id + "'";
            myclass.DataSQL(sql);
            sql = "update StateComment set _statername='" + name + "' where _stater='" + id + "'";
            myclass.DataSQL(sql);
            sql = "update StateComment set _staterownername='" + name + "' where _stateowner='" + id + "'";
            myclass.DataSQL(sql);
            sql = "update Visitor set visitorname='" + name + "' where visitor='" + id + "'";
            myclass.DataSQL(sql);
            Response.Write("<script>alert('修改成功！');location='Person.aspx'</script>");
        }
    }

    protected void btnSex_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["id"].ToString());

        string sex = rdlSex.SelectedValue;
        myClass myclass = new myClass();

        string sql = "update UserList set sex='" + sex + "' where id='" + id + "'";
        int flag = myclass.DataSQL(sql);
        Response.Write("<script>alert('修改成功！');location='Person.aspx'</script>");
    }

    protected void btnEmai_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["id"].ToString());

        string email = txtEmail.Text;
        myClass myclass = new myClass();

        string sql = "update UserList set email='" + email + "' where id='" + id + "'";
        myclass.DataSQL(sql);
        Response.Write("<script>alert('修改成功！');location='Person.aspx'</script>");
    }

    protected void btnPhone_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Session["id"].ToString());

        string phone = txtPhone.Text;
        myClass myclass = new myClass();

        string sql = "update UserList set phone='" + phone + "' where id='" + id + "'";
        int flag = myclass.DataSQL(sql);
        Response.Write("<script>alert('修改成功！');location='Person.aspx'</script>");
    }
}