using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_SubCategoryImageMap : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    string scid;
    RectangleHotSpot hotSpot;
    protected void Page_Load(object sender, EventArgs e)
    {
        // lblDeleteMsg.Text = "";
        lblMsg.Text = "";

        if (!IsPostBack)
        {
            if (!Utils.IsLoggedIn())
            {
                Utils.LogOut();
            }
            else
            {
                Label lblFormTitle = (Label)this.Master.FindControl("lblFormTitle");
                lblFormTitle.Text = "Product SubCategory Image Map";

                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    scid = Request.QueryString["id"].ToString();
                    BindProduct(scid);
                    BindSubcategoryDetail(scid);
                    lblSubCatName.Text = ViewState["SubCategoryName"].ToString();

                    mapAreas.HotSpots.Clear();
                    mapAreas.ImageAlign = ImageAlign.Top;
                    mapAreas.ImageUrl = "../" + ViewState["ImageBanner"].ToString();

                    BindHotSpot(scid);
                    BindGrid();
                }
                else
                {
                    Response.Redirect("SubCategory.aspx");
                }
            }
        }
    }
    protected void BindProduct(string scid)
    {
        cls.BindDropDownList_blankValue(ddlProduct, "ProductName", "ID", "bindDropdown", "Product", "where IsActive=1 and ProductSubCategoryId ='" + scid + "' order by ProductName ASC", "Id,ProductName");
    }
    protected void BindSubcategoryDetail(string scid)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_SubcatDetailOnId", new SqlParameter("@id", scid));

        if (dt.Rows.Count > 0)
        {
            ViewState["SubCategoryName"] = dt.Rows[0]["SubCategoryName"];
            ViewState["ImageBanner"] = dt.Rows[0]["ImageBanner"];
        }
        else
        {
            Response.Redirect("SubCategory.aspx");
        }
    }
    protected void BindHotSpot(string scid)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_SubCategoryImageMap", new SqlParameter("@SubCategoryId", scid));

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                hotSpot = new RectangleHotSpot();
                hotSpot.HotSpotMode = HotSpotMode.Inactive;
                hotSpot.Left = Convert.ToInt32(dr["left_co"]);
                hotSpot.Top = Convert.ToInt32(dr["top_co"]);
                hotSpot.Right = Convert.ToInt32(dr["right_co"]);
                hotSpot.Bottom = Convert.ToInt32(dr["bottom_co"]);
                mapAreas.HotSpots.Add(hotSpot);
            }
        }
    }
    protected void BindGrid()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_SubCategoryImageMap", new SqlParameter("@SubCategoryId", Request.QueryString["id"]));

        rptr.DataSource = dt;
        rptr.DataBind();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        cls.ResetFormControlValues(this);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlProduct.SelectedIndex > 0)
        {
            cls.ExecuteDA("InsertSubCategoryImagemap", new SqlParameter("@SubCategoryId", Request.QueryString["id"]),
                                                                     new SqlParameter("@ImageBanner", ViewState["ImageBanner"]),
                                                                     new SqlParameter("@left_co", txtLeft.Text),
                                                                       new SqlParameter("@top_co", txtTop.Text),
                                                                         new SqlParameter("@right_co", txtRight.Text),
                                                                           new SqlParameter("@bottom_co", txtBottom.Text),
                                                                           new SqlParameter("@ProductId", ddlProduct.SelectedValue));

            lblMsg.Text = "Record Inserted Successfully.";
            BindGrid();
            cls.ResetFormControlValues(this);
            BindHotSpot(Request.QueryString["id"]);
        }
        else
        {
            lblMsg.Text = "Please select Product";
        }
    }
    protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteGroup")
        {
            cls.ExecuteDA("DeleteRecord", new SqlParameter("@TblNm", "SubCategoryImageMap"),
                                  new SqlParameter("@strField", "Id"),
                                  new SqlParameter("@strValue", e.CommandArgument.ToString()));
           
            lblMsg.Text = "Record Deleted Sucessfully";
            BindGrid();
            cls.ResetFormControlValues(this);
            mapAreas.HotSpots.Clear();
            BindHotSpot(Request.QueryString["id"]);
        }
    }
}