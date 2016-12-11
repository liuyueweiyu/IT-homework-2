using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class myClass
{

    string str = @"server=LAPTOP-36VBSINT;Integrated Security=SSPI;database=QQzone;";
    public myClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string RerdName(int id)
    {
        string sql = "select * from UserList where id = '" + id + "'";
        DataTable dt = new DataTable();
        myClass myclass = new myClass();
        dt = myclass.JudgeIor(sql);
        string name = dt.Rows[0][1].ToString();
        return name;
    }

    public string RerdSculpture(int id)
    {
        string sql = "select * from UserList where id = '" + id + "'";
        DataTable dt = new DataTable();
        myClass myclass = new myClass();
        dt = myclass.JudgeIor(sql);
        string sculpture = dt.Rows[0][6].ToString();
        return sculpture;
    }

    public int DataSQL(string sql)         //执行SQL语句
    {
        SqlConnection conn = new SqlConnection(str);
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);

        cmd.ExecuteNonQuery();
        return 1;
        conn.Close();
    }

    public int JudgeAcc(string sql)                                                  //检测账号是否重复
    {
        SqlConnection conn = new SqlConnection(str);
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return (ds.Tables[0].Rows.Count);
        conn.Close();
    }

    public DataTable JudgeIor(string sql)                 //  读出信息
    {
        SqlConnection conn = new SqlConnection(str);
       
        conn.Open();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);

        da.Fill(dt);
        conn.Close();
        return dt;
 
    }



}