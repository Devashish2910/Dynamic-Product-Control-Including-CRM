using System;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Sitemap : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();  
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMenuCategory();            
        }
    }
    protected void BindMenuCategory()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("Select_CategoryForMenu");
        rptMenuCategory.DataSource = ds;
        rptMenuCategory.DataBind();
    }
    protected void rptMenuCategory_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblid = (Label)e.Item.FindControl("lblCatID");
        Repeater rptsubcat = (Repeater)e.Item.FindControl("rptMenuSubCategory");

        if (lblid != null)
        {
            DataSet dset = new DataSet();
            dset = cls.ReturnDataSet("Select_SubCategoryForMenu", new SqlParameter("@ID", lblid.Text));
            rptsubcat.DataSource = dset;
            rptsubcat.DataBind();
        }
    }
}