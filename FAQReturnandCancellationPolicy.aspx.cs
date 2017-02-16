using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class FAQReturnandCancellationPolicy : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindDescription();
            bindCategory();
        }
    }
    public void bindCategory()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("Select_FAQCatName");
        rptrFAQCategories.DataSource = ds;
        rptrFAQCategories.DataBind();

    }
    public void bindDescription()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "FAQ"), new SqlParameter("@strWhereClause", "where CatId=5"));

        rptrfaqdesc.DataSource = ds;
        rptrfaqdesc.DataBind();
    }
}