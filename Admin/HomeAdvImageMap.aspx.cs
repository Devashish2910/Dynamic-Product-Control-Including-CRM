using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_HomeAdvImageMap : System.Web.UI.Page
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
                lblFormTitle.Text = "Advertisement Image Map";

                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    scid = Request.QueryString["id"].ToString();
                    BindProduct();
                    BindAdvDetail(scid);
                    lblSubCatName.Text = "Add Record";

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
    protected void BindProduct()
    {
        cls.BindDropDownList_blankValue(ddlProduct, "ProductName", "ID", "bindDropdown", "Product", "where IsActive=1 order by ProductName ASC", "Id,ProductName");
    }
    protected void BindAdvDetail(string id)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_HomeAdvDetailOnId", new SqlParameter("@id", id));

        if (dt.Rows.Count > 0)
        {

            ViewState["ImageBanner"] = dt.Rows[0]["Image"];
        }
        else
        {
            Response.Redirect("SubCategory.aspx");
        }
    }
    protected void BindHotSpot(string scid)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_HomeAdvImageMap", new SqlParameter("@AdvId", scid));

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
        dt = cls.ReturnDataTable("Select_HomeAdvImageMap", new SqlParameter("@AdvId", Request.QueryString["id"]));

        rptr.DataSource = dt;
        rptr.DataBind();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        cls.ResetFormControlValues(this);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if (rdbOption.SelectedValue == "0")
        {
            if (ddlProduct.SelectedIndex > 0)
            {
                cls.ExecuteDA("Insert_HomeAddImageMap", new SqlParameter("@AdvId", Request.QueryString["id"]),
                                                                         new SqlParameter("@ImageBanner", ViewState["ImageBanner"]),
                                                                         new SqlParameter("@left_co", txtLeft.Text),
                                                                           new SqlParameter("@top_co", txtTop.Text),
                                                                             new SqlParameter("@right_co", txtRight.Text),
                                                                               new SqlParameter("@bottom_co", txtBottom.Text),
                                                                               new SqlParameter("@ProductId", ddlProduct.SelectedValue),
                                                                               new SqlParameter("@Url", ""));
            }
            else
            {
                lblMsg.Text = "Please select Product";
            }
        }
        else
        {
            cls.ExecuteDA("Insert_HomeAddImageMap", new SqlParameter("@AdvId", Request.QueryString["id"]),
                                                                    new SqlParameter("@ImageBanner", ViewState["ImageBanner"]),
                                                                    new SqlParameter("@left_co", txtLeft.Text),
                                                                      new SqlParameter("@top_co", txtTop.Text),
                                                                        new SqlParameter("@right_co", txtRight.Text),
                                                                          new SqlParameter("@bottom_co", txtBottom.Text),
                                                                          new SqlParameter("@ProductId", "0"),
                                                                          new SqlParameter("@Url", txtUrl.Text));
        }
        lblMsg.Text = "Record Inserted Successfully.";
        BindGrid();
        cls.ResetFormControlValues(this);
        BindHotSpot(Request.QueryString["id"]);

    }
    protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteGroup")
        {
            cls.ExecuteDA("DeleteRecord", new SqlParameter("@TblNm", "HomeAddImageMap"),
                                  new SqlParameter("@strField", "Id"),
                                  new SqlParameter("@strValue", e.CommandArgument.ToString()));

            lblMsg.Text = "Record Deleted Sucessfully";
            BindGrid();
            cls.ResetFormControlValues(this);
            mapAreas.HotSpots.Clear();
            BindHotSpot(Request.QueryString["id"]);
        }
    }
    protected void rdbOption_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbOption.SelectedValue == "0")
        {
            pnlProd.Visible = true;
            pnlOther.Visible = false;
        }
        else
        {
            pnlOther.Visible = true;
            pnlProd.Visible = false;
        }
    }
}