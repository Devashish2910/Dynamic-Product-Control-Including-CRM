using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["keyConn"].ToString());

    public Class1()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void getconnectionstring()
    {
    }

    public void execute(string sql)
    {


        SqlCommand cmd = new SqlCommand(sql, con);


        getconnectionstring();
        con.Open();
        try
        {
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch
        {
            con.Close();

        }


    }

    public String ExecuteScalar(String s)
    {
        try
        {
            con.Open();
            string str = "";
            SqlCommand cmd = new SqlCommand(s, con);
            int count = Convert.ToInt16(cmd.ExecuteScalar());
            //   str = cmd.ExecuteScalar().ToString();
            str = count.ToString();
            return str;

        }
        catch (Exception e)
        {

            return "";
        }
        finally
        {
            con.Close();
        }
    }

    public String getsinglevalue(String s)
    {
        try
        {
            con.Open();
            string str = "";
            SqlCommand cmd = new SqlCommand(s, con);
            str = cmd.ExecuteScalar().ToString();
            //   str = cmd.ExecuteScalar().ToString();

            return str;

        }
        catch (Exception e)
        {

            return "";
        }
        finally
        {
            con.Close();
        }
    }

    public DataTable getdataset(string sql)
    {
        try
        {
            DataTable dt = new DataTable();

            getconnectionstring();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);



            con.Close();
            return dt;
            //return dt.Tables[0];
        }

        catch
        {
            con.Close();
            return null;
        }
    }

    internal System.Data.SqlClient.SqlDataReader readdata(string sql1)
    {
        try
        {

            getconnectionstring();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql1, con);
            SqlDataReader idr = cmd.ExecuteReader();
            return idr;
        }
        catch
        {
            return null;
        }
        finally
        {
            con.Close();
        }

    }
}