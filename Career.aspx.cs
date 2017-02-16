using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Career : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindCarrer();        
        }
    }
    public void bindCarrer()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "CurrentOpenings"), new SqlParameter("@strWhereClause", "where IsActive=1"));

        rptrCarrer.DataSource = ds;
        rptrCarrer.DataBind();
    }
}