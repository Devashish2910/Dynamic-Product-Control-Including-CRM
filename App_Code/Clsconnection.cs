using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Threading;
using System.Globalization;
using Microsoft.VisualBasic;
using System.Data.Sql;

/// <summary>
/// Summary description for Clsconnection
/// </summary>
public class Clsconnection
{
    String strconn;
    SqlConnection sqlconn = new SqlConnection();
    SqlCommand sqlcmd;
    SqlDataReader sqlRdr;
    SqlDataAdapter sqlAdap;
    DataSet ds;
    Boolean blnexist;
    Int64 intScale;
    String strOldCultureName;
    DataTable dt;
	public Clsconnection()
	{


        //strconn = System.Configuration.ConfigurationManager.ConnectionStrings["TotalsaftymartConnectionString"].ConnectionString;
        strconn = System.Configuration.ConfigurationManager.AppSettings["keyConn"].ToString();
        strOldCultureName = CultureInfo.CurrentCulture.Name;

        //
        // TODO: Add constructor logic here
        //
  
	}
    public void OpenConnection()
    {

        if (sqlconn.State == ConnectionState.Open)
        {
            CloseConnection();
        }


        sqlconn = new SqlConnection();
        sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlconn;
        //strconn = ConfigurationSettings.AppSettings("conn")
        sqlconn.ConnectionString = strconn;
        sqlconn.Open();
    }

    //Close Sql Connection
    public void CloseConnection()
    {
        sqlcmd.Dispose();
        sqlconn.Close();
        sqlconn.Dispose();
    }
    public long ReturnScaler(string spName, params SqlParameter[] cmdparam)
    {
        OpenConnection();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = spName;
        sqlcmd.Connection = sqlconn;
        if (System.Convert.IsDBNull(cmdparam) == false)
        {
            SqlParameter parm;
            foreach (SqlParameter parm_loopVariable in cmdparam)
            {
                parm = parm_loopVariable;
                sqlcmd.Parameters.Add(parm);
            }
        }

        intScale = System.Convert.ToInt64(sqlcmd.ExecuteScalar());
        CloseConnection();
        return intScale;
    }
    public DataSet ReturnDataSet(string spName, params SqlParameter[] cmdparam)
    {
        OpenConnection();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = spName;
        sqlcmd.Connection = sqlconn;
        if (System.Convert.IsDBNull(cmdparam) == false)
        {
            SqlParameter parm = null;
            foreach (SqlParameter parm_loopVariable in cmdparam)
            {
                parm = parm_loopVariable;
                sqlcmd.Parameters.Add(parm);
            }
        }
        sqlAdap = new SqlDataAdapter(sqlcmd);
        ds = new DataSet();
        sqlAdap.Fill(ds);
        CloseConnection();
        return ds;

    }
    public object ReturnScalerObject(string spName, params SqlParameter[] cmdparam)
    {
        OpenConnection();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = spName;
        sqlcmd.Connection = sqlconn;
        if (System.Convert.IsDBNull(cmdparam) == false)
        {
            SqlParameter parm;
            foreach (SqlParameter parm_loopVariable in cmdparam)
            {
                parm = parm_loopVariable;
                sqlcmd.Parameters.Add(parm);
            }
        }

        object obj = sqlcmd.ExecuteScalar();
        CloseConnection();
        return obj;
    }
    public void BindDropDownList_blankValue(DropDownList ddlAny, string strTextField, string strValueField, string strSPNm, string strTblNm, string strWhereClause = "", string strField = "")
    {
        int intCount = 0;
        OpenConnection();
        if (!string.IsNullOrEmpty(strField))
        {
            ds = ReturnDataSet(strSPNm, new SqlParameter("@Fields", strField), new SqlParameter("@TblNm", strTblNm), new SqlParameter("@strWhere", strWhereClause));
        }
        else
        {
            ds = ReturnDataSet(strSPNm, new SqlParameter("@TblNm", strTblNm), new SqlParameter("@strWhere", strWhereClause));
        }
        ddlAny.DataSource = ds;
        ddlAny.DataTextField = strTextField;
        ddlAny.DataValueField = strValueField;
        ddlAny.DataBind();

        ddlAny.Items.Insert(0, new ListItem("- Select -", ""));

        intCount = ddlAny.Items.Count;
        CloseConnection();

    }

    public void SetSelctedDropDownListValues(string strValue, DropDownList drpDown)
    {
        if (strValue.Length > 0)
        {
            drpDown.ClearSelection();
            drpDown.Items.FindByValue(strValue).Selected = true;
        }
    }
    public void ExecuteDA(string spName, params SqlParameter[] cmdparam)
    {
        OpenConnection();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = spName;
        sqlcmd.Connection = sqlconn;
        if (System.Convert.IsDBNull(cmdparam) == false)
        {
            SqlParameter parm;
            foreach (SqlParameter parm_loopVariable in cmdparam)
            {
                parm = parm_loopVariable;
                sqlcmd.Parameters.Add(parm);
            }
        }

        sqlAdap = new SqlDataAdapter(sqlcmd);
        ds = new DataSet();
        sqlAdap.Fill(ds);
        ds.AcceptChanges();
        CloseConnection();
    }
    public void ResetFormControlValues(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControlValues(c);
            }
            else
            {
                switch ((c.GetType().ToString()))
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).Text = "";
                        break;
                    case "System.Web.UI.WebControls.CheckBox":
                        ((CheckBox)c).Checked = false;
                        break;
                    case "System.Web.UI.WebControls.RadioButton":
                        ((RadioButton)c).Checked = false;
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        ((DropDownList)c).SelectedIndex = -1;
                        break;
                    case "System.Web.UI.WebControls.CheckBoxList":
                        ((CheckBoxList)c).ClearSelection();
                        break;
                }
            }
        }
    }
    public SqlDataReader ReturnDataReader(string spName, params SqlParameter[] cmdparam)
    {
        OpenConnection();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = spName;
        sqlcmd.Connection = sqlconn;
        if (System.Convert.IsDBNull(cmdparam) == false)
        {
            SqlParameter parm = null;
            foreach (SqlParameter parm_loopVariable in cmdparam)
            {
                parm = parm_loopVariable;
                sqlcmd.Parameters.Add(parm);
            }
        }
        sqlRdr = sqlcmd.ExecuteReader(CommandBehavior.Default);
        return sqlRdr;
    }
    public bool CheckExistField(string strSPNm, string strTblNm, string strField, string strValue, string strAndClause)
    {
        OpenConnection();
        //ds = ReturnDataSet(strSPNm, New SqlParameter("@TblNm", strTblNm), New SqlParameter("@strField", strField), New SqlParameter("@strValue", strValue), New SqlParameter("@strAndCond", strWhereClause))
        //If ds.Tables(0).Rows.Count <> 0 Then
        //    Return True
        //Else
        //    Return False
        //End If
        sqlRdr = ReturnDataReader(strSPNm, new SqlParameter("@TblNm", strTblNm), new SqlParameter("@strField", strField), new SqlParameter("@strValue", strValue), new SqlParameter("@strAndCond", strAndClause));
        if (sqlRdr.Read() == true)
        {
            CloseConnection();
            return true;
        }
        else
        {
            CloseConnection();
            return false;
        }

    }

    public DataTable ReturnDataTable(string spName, params SqlParameter[] cmdparam)
    {
        OpenConnection();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = spName;
        sqlcmd.Connection = sqlconn;
        if (System.Convert.IsDBNull(cmdparam) == false)
        {
            SqlParameter parm = null;
            foreach (SqlParameter parm_loopVariable in cmdparam)
            {
                parm = parm_loopVariable;
                sqlcmd.Parameters.Add(parm);
            }
        }
        sqlAdap = new SqlDataAdapter(sqlcmd);
        dt = new DataTable();
        sqlAdap.Fill(dt);
        CloseConnection();
        return dt;

    }

    public DataTable ReturnDataTable1(string strSql)
    {
        OpenConnection();
        sqlAdap = new SqlDataAdapter(strSql, sqlconn);
        dt = new DataTable();
        //Call OpenConnection()
        var _with1 = sqlcmd;
        _with1.Connection = sqlconn;
        _with1.CommandText = strSql;
        sqlAdap.Fill(dt);
        CloseConnection();
        return dt;

    }
  
    public long ExecuteNonQueryBySQLQuery(string strSQL)
    {
        OpenConnection();
        sqlcmd.CommandType = CommandType.Text;
        sqlcmd.CommandText = strSQL;
        sqlcmd.Connection = sqlconn;
        long intResult = 0;
        intResult = sqlcmd.ExecuteNonQuery();
        CloseConnection();
        return intResult;

    }
    public string FormatDate_IND_US(System.String code)
    {
        string ldate = null;
        string ldate1 = null;
        string ldate2 = null;
        string ldate3 = null;
        ldate = code;
        ldate1 = Mid(ldate, 1, 2);
        ldate2 = Mid(ldate, 4, 2);
        ldate3 = Mid(ldate, 7, 4);
        ldate = ldate2 + "/" + ldate1 + "/" + ldate3;
        return ldate;
    }
    public string FormatDate_US_Ind(System.String code)
    {
        string newDate = null;
        newDate = string.Format("{0:dd-MM-yyyy}", Convert.ToDateTime(code));
        return newDate;
    }
    public static string Mid(string s, int a, int b)
    {
        string temp = s.Substring(a - 1, b);
        return temp;
    }
 }