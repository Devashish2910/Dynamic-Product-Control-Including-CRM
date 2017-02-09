using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SubCategory : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    public string cid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["cid"]))
        {
            Response.Redirect("default.aspx");
        }
        else
        {
            cid = Request.QueryString["cid"].ToString();
        }

        if (!IsPostBack)
        {
            BindSubCategory(cid);
        }
    }
    protected void BindSubCategory(string cid)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_SubCategoryOnCatId", new SqlParameter("@catid", cid));

        if (dt.Rows.Count > 0)
        {
            //binding breadcrumb
            DataTable dttile = new DataTable();
            dttile = dt.DefaultView.ToTable(true, "ProductCategoryId", "CategoryName");
            rptrBreadCrumb.DataSource = dttile;
            rptrBreadCrumb.DataBind();

            DataTable dt1 = new DataTable();

            dt1.Columns.Add("ProductCategoryId1", Type.GetType("System.String"));
            dt1.Columns.Add("id1", Type.GetType("System.String"));
            dt1.Columns.Add("SubCategoryName1", Type.GetType("System.String"));
            dt1.Columns.Add("Image1", Type.GetType("System.String"));

            dt1.Columns.Add("ProductCategoryId2", Type.GetType("System.String"));
            dt1.Columns.Add("id2", Type.GetType("System.String"));
            dt1.Columns.Add("SubCategoryName2", Type.GetType("System.String"));
            dt1.Columns.Add("Image2", Type.GetType("System.String"));

            dt1.Columns.Add("ProductCategoryId3", Type.GetType("System.String"));
            dt1.Columns.Add("id3", Type.GetType("System.String"));
            dt1.Columns.Add("SubCategoryName3", Type.GetType("System.String"));
            dt1.Columns.Add("Image3", Type.GetType("System.String"));

            dt1.Columns.Add("ProductCategoryId4", Type.GetType("System.String"));
            dt1.Columns.Add("id4", Type.GetType("System.String"));
            dt1.Columns.Add("SubCategoryName4", Type.GetType("System.String"));
            dt1.Columns.Add("Image4", Type.GetType("System.String"));

            dt1.Columns.Add("ProductCategoryId5", Type.GetType("System.String"));
            dt1.Columns.Add("id5", Type.GetType("System.String"));
            dt1.Columns.Add("SubCategoryName5", Type.GetType("System.String"));
            dt1.Columns.Add("Image5", Type.GetType("System.String"));

            dt1.Columns.Add("ProductCategoryId6", Type.GetType("System.String"));
            dt1.Columns.Add("id6", Type.GetType("System.String"));
            dt1.Columns.Add("SubCategoryName6", Type.GetType("System.String"));
            dt1.Columns.Add("Image6", Type.GetType("System.String"));


            for (int i = 0; i < dt.Rows.Count; i = i + 6)
            {
                if (i + 1 < dt.Rows.Count)
                {
                    if (i + 2 < dt.Rows.Count)
                    {
                        if (i + 3 < dt.Rows.Count)
                        {
                            if (i + 4 < dt.Rows.Count)
                            {
                                if (i + 5 < dt.Rows.Count)
                                {
                                    dt1.Rows.Add(dt.Rows[i]["ProductCategoryId"].ToString(), dt.Rows[i]["id"].ToString(), dt.Rows[i]["SubCategoryName"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i + 1]["ProductCategoryId"].ToString(), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["SubCategoryName"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 2]["ProductCategoryId"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["SubCategoryName"].ToString(), dt.Rows[i + 2]["Image"].ToString(), dt.Rows[i + 3]["ProductCategoryId"].ToString(), dt.Rows[i + 3]["id"].ToString(), dt.Rows[i + 3]["SubCategoryName"].ToString(), dt.Rows[i + 3]["Image"].ToString(), dt.Rows[i + 4]["ProductCategoryId"].ToString(), dt.Rows[i + 4]["id"].ToString(), dt.Rows[i + 4]["SubCategoryName"].ToString(), dt.Rows[i + 4]["Image"].ToString(), dt.Rows[i + 5]["ProductCategoryId"].ToString(), dt.Rows[i + 5]["id"].ToString(), dt.Rows[i + 5]["SubCategoryName"].ToString(), dt.Rows[i + 5]["Image"].ToString());
                                }
                                else
                                {
                                    dt1.Rows.Add(dt.Rows[i]["ProductCategoryId"].ToString(), dt.Rows[i]["id"].ToString(), dt.Rows[i]["SubCategoryName"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i + 1]["ProductCategoryId"].ToString(), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["SubCategoryName"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 2]["ProductCategoryId"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["SubCategoryName"].ToString(), dt.Rows[i + 2]["Image"].ToString(), dt.Rows[i + 3]["ProductCategoryId"].ToString(), dt.Rows[i + 3]["id"].ToString(), dt.Rows[i + 3]["SubCategoryName"].ToString(), dt.Rows[i + 3]["Image"].ToString(), dt.Rows[i + 4]["ProductCategoryId"].ToString(), dt.Rows[i + 4]["id"].ToString(), dt.Rows[i + 4]["SubCategoryName"].ToString(), dt.Rows[i + 4]["Image"].ToString(), "", "", "", "");
                                }
                            }
                            else
                            {
                                dt1.Rows.Add(dt.Rows[i]["ProductCategoryId"].ToString(), dt.Rows[i]["id"].ToString(), dt.Rows[i]["SubCategoryName"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i + 1]["ProductCategoryId"].ToString(), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["SubCategoryName"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 2]["ProductCategoryId"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["SubCategoryName"].ToString(), dt.Rows[i + 2]["Image"].ToString(), dt.Rows[i + 3]["ProductCategoryId"].ToString(), dt.Rows[i + 3]["id"].ToString(), dt.Rows[i + 3]["SubCategoryName"].ToString(), dt.Rows[i + 3]["Image"].ToString(), "", "", "", "", "", "", "", "");
                            }
                        }
                        else
                        {
                            dt1.Rows.Add(dt.Rows[i]["ProductCategoryId"].ToString(), dt.Rows[i]["id"].ToString(), dt.Rows[i]["SubCategoryName"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i + 1]["ProductCategoryId"].ToString(), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["SubCategoryName"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 2]["ProductCategoryId"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["SubCategoryName"].ToString(), dt.Rows[i + 2]["Image"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "");
                        }
                    }
                    else
                    {
                        dt1.Rows.Add(dt.Rows[i]["ProductCategoryId"].ToString(), dt.Rows[i]["id"].ToString(), dt.Rows[i]["SubCategoryName"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i + 1]["ProductCategoryId"].ToString(), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["SubCategoryName"].ToString(), dt.Rows[i + 1]["Image"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    }
                }
                else
                {
                    dt1.Rows.Add(dt.Rows[i]["ProductCategoryId"].ToString(), dt.Rows[i]["id"].ToString(), dt.Rows[i]["SubCategoryName"].ToString(), dt.Rows[i]["Image"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                }
            }
            rptrSubCategory.DataSource = dt1;
            rptrSubCategory.DataBind();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}