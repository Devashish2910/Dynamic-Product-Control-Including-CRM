using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class OrderDetails : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    clsAddToCart clsCart;
    public string invoiceid;

    string ProductId, CategoryName, SubCategoryName, ProductName, Productdescp, BrandName, SupplierName, Unit, ColourName, SizeName, ProductCode, SupplierProductCode, PackSize, Image, Certification, Description, ShippingDays;
    double ProductCost, ProductWeight, Margin, SalePrice, Tax, SalesPrice_Incl, MRP, Discount, CalDiscount, ShippingCost, FinalSellingPrice, TaxFinalPrice, MinQty, Qty, Price;
    bool IsCOD;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["OID"] != "" && Request.QueryString["OID"] != null)
        {
            invoiceid = Request.QueryString["OID"].ToString();
        }
        else
        {
            Response.Redirect("MyOrder.aspx");
        }

        if (!IsPostBack)
        {
            BindOrder();
            BindProduct();
        }
    }
    protected void BindOrder()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_InvoiceBillShipDetailsFromID", new SqlParameter("@InvoiceId", invoiceid));
        if (dt.Rows.Count <= 0)
        {
            Response.Write("<script language='javascript'> { alert('Invalid OrderId') }</script>");
            Response.Redirect("MyOrder.aspx");
        }
        else
        {
            rptOrderDetails.DataSource = dt;
            rptOrderDetails.DataBind();

            rptBilling.DataSource = dt;
            rptBilling.DataBind();

            rptShipping.DataSource = dt;
            rptShipping.DataBind();

            rptrCutomerTin.DataSource = dt;
            rptrCutomerTin.DataBind();
        }
    }
    protected void rptOrderDetails_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //Label lblTrack = (Label)e.Item.FindControl("lblTrack");
        //Label lblTrack1 = (Label)e.Item.FindControl("lblTrack1");
        //if (lblTrack != null)
        //{
        //    if (lblTrack1.Text.ToString() != "")
        //    {
        //        lblTrack.Visible = true;
        //    }
        //    else
        //    {
        //        lblTrack.Visible = false;
        //    }
        //}
    }
    protected void BindProduct()
    {
        DataTable dtprod = new DataTable();
        dtprod = cls.ReturnDataTable("Select_InvoiceProductDetailsFromID", new SqlParameter("@InvoiceId", invoiceid));
        rptrCart.DataSource = dtprod;
        rptrCart.DataBind();
        if (dtprod.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dtprod.Rows[0]["CouponName"])))
            {
                lblCoupon.Text = "Using Voucher Code (" + dtprod.Rows[0]["CouponName"] + ")";
            }
            else
            {
                lblCoupon.Text = "";
            }
            lblDisPer.Text = "(" + dtprod.Rows[0]["DiscountPer"] + "%)";
            lblDisVal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["DiscountAmount"])).ToString();
        }
    }
    protected void rptrCart_OnItemDatabound(object source, RepeaterItemEventArgs e)
    {
        //    Label lblFinalTotal = (Label)footer.FindControl("lblFinalTotal");
        //    Label lblAmountinWords = (Label)footer.FindControl("lblAmountinWords");


        //    if (lblFinalTotal != null)
        //    {
        //        DataTable dtprod = new DataTable();
        //        dtprod = cls.ReturnDataTable("Select_InvoiceProductDetailsFromID", new SqlParameter("@InvoiceId", invoiceid));

        //        lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["OrderAmount"])).ToString();

        //        NumbertoWords num = new NumbertoWords();
        //        lblAmountinWords.Text = num.NumberToWords(Convert.ToInt32(lblFinalTotal.Text)) + " only.";
        //        lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["OrderAmount"])).ToString("N2");
        //    }

        NumbertoWords num = new NumbertoWords();
        DataTable dtprod = new DataTable();
        dtprod = cls.ReturnDataTable("Select_InvoiceProductDetailsFromID", new SqlParameter("@InvoiceId", invoiceid));
        lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["OrderAmount"])).ToString();
        lblAmountinWords.Text = num.NumberToWords(Convert.ToInt32(lblFinalTotal.Text)) + " only.";
        lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["OrderAmount"])).ToString();
    }
    protected void rptrProductDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "AddCart")
        {
            ProductId = e.CommandArgument.ToString();

            DataTable dtproduct;
            dtproduct = new DataTable();
            dtproduct = cls.ReturnDataTable("Select_ProductDetailOnId", new SqlParameter("@pid", ProductId));

            if (dtproduct.Rows.Count <= 0)
            {
                MsgBox("This Product is no longer available.");
                return;
            }
            else
            {
                foreach (DataRow dr in dtproduct.Rows)
                {
                    ProductId = dr["Id"].ToString();
                    CategoryName = dr["CategoryName"].ToString();
                    SubCategoryName = dr["SubCategoryName"].ToString();
                    ProductName = dr["ProductName"].ToString();
                    Productdescp = dr["Productdescp"].ToString();
                    BrandName = dr["BrandName"].ToString();
                    SupplierName = dr["SupplierName"].ToString();
                    Unit = dr["Unit"].ToString();
                    ProductCode = dr["ProductCode"].ToString();
                    SupplierProductCode = dr["SupplierProductCode"].ToString();
                    PackSize = dr["PackSize"].ToString();
                    ProductCost = Convert.ToDouble(dr["ProductCost"].ToString());
                    ProductWeight = Convert.ToDouble(dr["ProductWeight"].ToString());
                    Image = dr["Image"].ToString();
                    Certification = dr["Certification"].ToString();
                    Description = dr["Description"].ToString();
                    Margin = Convert.ToDouble(dr["Margin"].ToString());
                    SalePrice = Convert.ToDouble(dr["SalePrice"].ToString());
                    Tax = Convert.ToDouble(dr["Tax"].ToString());
                    SalesPrice_Incl = Convert.ToDouble(dr["SalesPrice_Incl"].ToString());
                    MRP = Convert.ToDouble(dr["MRP"].ToString());
                    Discount = Convert.ToDouble(dr["Discount"].ToString());
                    CalDiscount = Convert.ToDouble(dr["CalDiscount"].ToString());
                    ShippingCost = Convert.ToDouble(dr["ShippingCost"].ToString());
                    FinalSellingPrice = Convert.ToDouble(dr["FinalSellingPrice"].ToString());
                    TaxFinalPrice = Convert.ToDouble(dr["TaxFinalPrice"].ToString());
                    MinQty = Convert.ToDouble(dr["Quantity"].ToString());
                    ShippingDays = dr["ShippingDays"].ToString();
                    IsCOD = Convert.ToBoolean(dr["IsCOD"]);
                }

                Label lblSize = (Label)e.Item.FindControl("lblSize");
                Label lblColor = (Label)e.Item.FindControl("lblColor");

                SizeName = lblSize.Text;
                ColourName = lblColor.Text;

                Price = MinQty * FinalSellingPrice;

                clsCart = new clsAddToCart();
                if (clsCart.FindExistItemWithSizeColor(ProductId, SizeName, ColourName))
                {
                    clsCart.UpdateQtyAndPriceWithSizeColor(ProductId, MinQty, FinalSellingPrice, SizeName, ColourName);
                }
                else
                {
                    clsCart.AddToCart(ProductId, CategoryName, SubCategoryName, ProductName, Productdescp, BrandName, SupplierName, Unit, ColourName, SizeName, ProductCode, SupplierProductCode, PackSize, ProductCost, ProductWeight, Image, Certification, Description, Margin, SalePrice, Tax, SalesPrice_Incl, MRP, Discount, CalDiscount, ShippingCost, FinalSellingPrice, TaxFinalPrice, MinQty, ShippingDays, IsCOD, Price);
                }
                Response.Redirect("Cart.aspx");
                BindTopCartItems();
            }
        }
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
            ScriptManager.RegisterStartupScript(page, page.GetType(), "Message", "alert('" + message + "')", true);
        }
    }
}