using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MyOrder : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    clsWishlist clsWishlist;
    clsAddToCart clsCart;

    string ProductId, CategoryName, SubCategoryName, ProductName, Productdescp, BrandName, SupplierName, Unit, ColourName, SizeName, ProductCode, SupplierProductCode, PackSize, Image, Certification, Description, ShippingDays;
    double ProductCost, ProductWeight, Margin, SalePrice, Tax, SalesPrice_Incl, MRP, Discount, CalDiscount, ShippingCost, FinalSellingPrice, TaxFinalPrice, MinQty, Qty, Price;
    bool IsCOD;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberInfo"] != null)
        {            
            if (!IsPostBack)
            {
                DataTable dtUser = new DataTable();
                dtUser = (DataTable)Session["MemberInfo"];
                if (dtUser.Rows[0]["memberId"].ToString() != "0")
                {
                    BindOrders(Convert.ToInt32(dtUser.Rows[0]["MemberId"]));
                    BindTopCartItems();
                }
                else
                {
                    Response.Redirect("Register.aspx");
                }
            }
        }
        else
        {           
            Response.Redirect("Register.aspx");
        }
    }

    protected void BindOrders(int MemberId)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_AllInvoiceOnMemberId", new SqlParameter("@MemberId", MemberId));
        rptrCart.DataSource = dt;
        rptrCart.DataBind();
    }

    protected void BindTopCartItems()
    {
        Label lblTopNoItems = (Label)this.Page.Master.FindControl("lblTopNoItems");
        Label lblTopTotal = (Label)this.Page.Master.FindControl("lblTopTotal");

        if (Session["Cart"] != null)
        {
            clsCart = new clsAddToCart();
            lblTopNoItems.Text = clsCart.TotalItems().ToString();

            if (clsCart.TotalItems() != 0)
            {
                lblTopTotal.Text = Math.Round(clsCart.TotalPrice()).ToString();
            }
            else
            {
                lblTopTotal.Text = "0";
            }
        }
        else
        {
            lblTopNoItems.Text = "0";
            lblTopTotal.Text = "0";
        }
    }
    public void MsgBox(string message)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            message = message.Replace("'", "'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "MessageThenRedirect", "alert('" + message + "')", true);
        }
    }
}