using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ContactUs : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindContactUs();
        }
    }
    public void bindContactUs()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "ContactUs"), new SqlParameter("@strWhereClause", "where Id=1"));

        if (ds.Tables[0].Rows.Count > 0)
        {
            ltrContactUs.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        }

    }
}