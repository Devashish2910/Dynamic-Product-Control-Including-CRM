using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class FAQTermsandCondition : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindTremsNCondition();
            bindfooter();
        }
    }
    public void bindTremsNCondition()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "TermsNConditions"), new SqlParameter("@strWhereClause", "where Id=1"));

        if (ds.Tables[0].Rows.Count > 0)
        {
            ltrtremscondition.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        }
    }
    public void bindfooter()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "Footer"), new SqlParameter("@strWhereClause", "where Id=1"));

        if (ds.Tables[0].Rows.Count > 0)
        {
            ltrFooter.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        }
    }
}