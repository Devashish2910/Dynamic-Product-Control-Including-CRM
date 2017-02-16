using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ProductDetail : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    clsAddToCart clsCart;
    clsWishlist clsWishlist;
    public string pid = "";
    Class1 cl = new Class1();
    DataTable dtproduct;
    static string memberid = "";
    string ProductId, CategoryName, SubCategoryName, ProductName, Productdescp, BrandName, SupplierName, Unit, ColourName, SizeName, ProductCode, SupplierProductCode, PackSize, Image, Certification, Description, ShippingDays;
    double ProductCost, ProductWeight, Margin, SalePrice, Tax, SalesPrice_Incl, MRP, Discount, CalDiscount, ShippingCost, FinalSellingPrice, TaxFinalPrice, MinQty, Qty, Price;
    bool IsCOD;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                memberid = Session["Memberid"].ToString();
                pid = Request.QueryString["pid"].ToString();
            }

            if (!IsPostBack)
            {
                BindProductDetail(pid);
            }
        }
        catch
        {
            Response.Redirect("Register.aspx");
        }
    }
    protected void BindProductDetail(string pid)
    {
        dtproduct = new DataTable();
        dtproduct = cl.getdataset("select ProductCategory.CategoryName,ProductSubCategory.SubCategoryName,Brand.BrandName,product.*,(case Productdescp when '' then ProductName else ProductName +'&nbsp;('+Productdescp+')'  end ) as pname, (case Productdescp when '' then '' else '('+Productdescp+')'  end ) as pline2,  Supplier.SupplierName,Unit.Unit,  c.*,c.discount as crmdiscount from  Product inner join ProductCategory on Product.ProductCategoryId=ProductCategory.Id  inner join ProductSubCategory on Product.ProductSubCategoryId=ProductSubCategory.Id  inner join Brand on Product.BrandId=Brand.Id  left join unit on Product.UnitId=Unit.Id inner join crm c on c.productid=Product.id left join Supplier on Product.SupplierId=Supplier.Id   where Product.IsActive=1 and Product.Id='" + pid + "' and c.cusotmerid='" + memberid + "'");
        

        if (dtproduct.Rows.Count > 0)
        {
            rptrProductDetail.DataSource = dtproduct;
            rptrProductDetail.DataBind();
        }
        else
        {
            Response.Redirect("default.aspx");
        }
    }
    protected void rptrProductDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Panel pnl;

        RadioButtonList rdbSize = (RadioButtonList)e.Item.FindControl("rdbSize");
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_AvailableSizeOnId", new SqlParameter("@pid", pid));

        rdbSize.DataSource = dt;
        rdbSize.DataTextField = "SizeName";
        rdbSize.DataValueField = "SizeId";
        rdbSize.DataBind();

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["SizeName"].ToString() == "NA")
                {
                    pnl = new Panel();
                    pnl = (Panel)e.Item.FindControl("pnlSize");
                    pnl.Visible = false;
                    break;
                }
            }
        }

        RadioButtonList rdbColor = (RadioButtonList)e.Item.FindControl("rdbColor");
        DataTable dt1 = new DataTable();
        dt1 = cls.ReturnDataTable("Select_AvailableColorOnId", new SqlParameter("@pid", pid));

        rdbColor.DataSource = dt1;
        rdbColor.DataTextField = "ColourName";
        rdbColor.DataValueField = "ColourID";
        rdbColor.DataBind();

        if (dt1.Rows.Count > 0)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                if (dr["ColourName"].ToString() == "NA")
                {
                    pnl = new Panel();
                    pnl = (Panel)e.Item.FindControl("pnlColour");
                    pnl.Visible = false;
                    break;
                }
            }
        }
    }
    protected void rptrProductDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        bool IsLogin;
        // Add to Cart
        if (e.CommandName == "AddCart")
        {
            RadioButtonList rdbSize = (RadioButtonList)e.Item.FindControl("rdbSize");
            Panel pnlSize = (Panel)e.Item.FindControl("pnlSize");

            if (!pnlSize.Visible)
            {
                SizeName = "NA";
            }
            else if (rdbSize.SelectedIndex > -1)
            {
                SizeName = rdbSize.SelectedItem.Text;
            }
            else
            {
                MsgBox("Please Select Size");
                return;
            }

            RadioButtonList rdbColor = (RadioButtonList)e.Item.FindControl("rdbColor");
            Panel pnlColor = (Panel)e.Item.FindControl("pnlColour");

            if (!pnlColor.Visible)
            {
                ColourName = "NA";
            }
            else if (rdbColor.SelectedIndex > -1)
            {
                ColourName = rdbColor.SelectedItem.Text;
            }
            else
            {
                MsgBox("Please Select Color");
                return;
            }

            TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
            
            Qty = Convert.ToDouble(txtQty.Text);
            
            dtproduct = new DataTable();
            dtproduct = cl.getdataset("select ProductCategory.CategoryName,ProductSubCategory.SubCategoryName,Brand.BrandName,product.*,(case Productdescp when '' then ProductName else ProductName +'&nbsp;('+Productdescp+')'  end ) as pname, (case Productdescp when '' then '' else '('+Productdescp+')'  end ) as pline2,  Supplier.SupplierName,Unit.Unit,  c.*,c.discount as crmdiscount from  Product inner join ProductCategory on Product.ProductCategoryId=ProductCategory.Id  inner join ProductSubCategory on Product.ProductSubCategoryId=ProductSubCategory.Id  inner join Brand on Product.BrandId=Brand.Id  left join unit on Product.UnitId=Unit.Id inner join crm c on c.productid=Product.id left join Supplier on Product.SupplierId=Supplier.Id   where Product.IsActive=1 and Product.Id='" + pid + "' and c.cusotmerid='" + memberid + "'");

            if (dtproduct != null)
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
                    FinalSellingPrice = Convert.ToDouble(dr["netsaleprice"].ToString());
                    TaxFinalPrice = Convert.ToDouble(dr["TaxFinalPrice"].ToString());
                    MinQty = Convert.ToDouble(dr["Quantity"].ToString());
                    ShippingDays = dr["ShippingDays"].ToString();
                    IsCOD = Convert.ToBoolean(dr["IsCOD"]);
                }

                if (Qty < MinQty)
                {
                    MsgBox("Minimum Qty required for order is : " + MinQty);
                    return;
                }

                Price = Qty * FinalSellingPrice;

                clsCart = new clsAddToCart();
                if (clsCart.FindExistItemWithSizeColor(ProductId, SizeName, ColourName))
                {
                    clsCart.UpdateQtyAndPriceWithSizeColor(ProductId, Qty, FinalSellingPrice, SizeName, ColourName);
                }
                else
                {
                    clsCart.AddToCart(ProductId, CategoryName, SubCategoryName, ProductName, Productdescp, BrandName, SupplierName, Unit, ColourName, SizeName, ProductCode, SupplierProductCode, PackSize, ProductCost, ProductWeight, Image, Certification, Description, Margin, SalePrice, Tax, SalesPrice_Incl, MRP, Discount, CalDiscount, ShippingCost, FinalSellingPrice, TaxFinalPrice, Qty, ShippingDays, IsCOD, Price);
                }
                if (Qty > 0)
                {
                    Response.Redirect("Cart.aspx");
                }
                else
                {
                    //Response.Redirect("Cart.aspx");
                    //BindTopCartItems();

                    MsgBox("Please Select Color");
                }
              
            }
            else
            { BindProductDetail(pid); }
        }
        // Add to Wishlist
        else if (e.CommandName == "AddWishlist")
        {
            RadioButtonList rdbSize = (RadioButtonList)e.Item.FindControl("rdbSize");
            Panel pnlSize = (Panel)e.Item.FindControl("pnlSize");

            if (!pnlSize.Visible)
            {
                SizeName = "NA";
            }
            else if (rdbSize.SelectedIndex > -1)
            {
                SizeName = rdbSize.SelectedItem.Text;
            }
            else
            {
                MsgBox("Please Select Size");
                return;
            }

            RadioButtonList rdbColor = (RadioButtonList)e.Item.FindControl("rdbColor");
            Panel pnlColor = (Panel)e.Item.FindControl("pnlColour");

            if (!pnlColor.Visible)
            {
                ColourName = "NA";
            }
            else if (rdbColor.SelectedIndex > -1)
            {
                ColourName = rdbColor.SelectedItem.Text;
            }
            else
            {
                MsgBox("Please Select Color");
                return;
            }

            //TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");

            //if (string.IsNullOrEmpty(txtQty.Text))
            //{
            //    Qty = 0;
            //}
            //else
            //{
            //    Qty = Convert.ToDouble(txtQty.Text);
            //}                     
            dtproduct = new DataTable();
            dtproduct = cl.getdataset("select ProductCategory.CategoryName,ProductSubCategory.SubCategoryName,Brand.BrandName,product.*,(case Productdescp when '' then ProductName else ProductName +'&nbsp;('+Productdescp+')'  end ) as pname, (case Productdescp when '' then '' else '('+Productdescp+')'  end ) as pline2,  Supplier.SupplierName,Unit.Unit,  c.*,c.discount as crmdiscount from  Product inner join ProductCategory on Product.ProductCategoryId=ProductCategory.Id  inner join ProductSubCategory on Product.ProductSubCategoryId=ProductSubCategory.Id  inner join Brand on Product.BrandId=Brand.Id  left join unit on Product.UnitId=Unit.Id inner join crm c on c.productid=Product.id left join Supplier on Product.SupplierId=Supplier.Id   where Product.IsActive=1 and Product.Id='" + pid + "' and c.cusotmerid='" + memberid + "'");

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
                FinalSellingPrice = Convert.ToDouble(dr["netsaleprice"].ToString());
                TaxFinalPrice = Convert.ToDouble(dr["TaxFinalPrice"].ToString());
                MinQty = Convert.ToDouble(dr["Quantity"].ToString());
                ShippingDays = dr["ShippingDays"].ToString();
                IsCOD = Convert.ToBoolean(dr["IsCOD"]);
            }

            Price = MinQty * FinalSellingPrice;

            clsWishlist = new clsWishlist();
            if (clsWishlist.FindExistItemWithSizeColor(ProductId, SizeName, ColourName))
            {
                clsWishlist.UpdateQtyAndPriceWithSizeColor(ProductId, MinQty, FinalSellingPrice, SizeName, ColourName);
            }
            else
            {
                clsWishlist.AddToWishlist(ProductId, CategoryName, SubCategoryName, ProductName, Productdescp, BrandName, SupplierName, Unit, ColourName, SizeName, ProductCode, SupplierProductCode, PackSize, ProductCost, ProductWeight, Image, Certification, Description, Margin, SalePrice, Tax, SalesPrice_Incl, MRP, Discount, CalDiscount, ShippingCost, FinalSellingPrice, TaxFinalPrice, MinQty, ShippingDays, IsCOD, Price);
            }
            IsLogin = CheckUserSession();
            if (!IsLogin)
            {
                Session["CameFrom"] = "Wishlist";
                MessageThenRedirectTo("Please Login to Save Wishlist", "Register");
                return;
            }
            else
            {
                Response.Redirect("WishList.aspx");
            }
        }
        //check pincode
        else if (e.CommandName == "CheckPincode")
        {
            TextBox txtPinCode = (TextBox)e.Item.FindControl("txtPinCode");
            if (txtPinCode != null)
            {
                DataTable dt = new DataTable();
                dt = getStateCityOnPincode(Convert.ToInt64(txtPinCode.Text));
                Panel pnlShippingAvailable = (Panel)e.Item.FindControl("pnlShippingAvailable");
                Panel pnlShippingPin = (Panel)e.Item.FindControl("pnlShippingPin");

                if (dt.Rows.Count > 0)
                {
                    pnlShippingAvailable.Visible = true;
                    pnlShippingPin.Visible = false;
                }
                else
                {
                    pnlShippingAvailable.Visible = false;
                    pnlShippingPin.Visible = true;
                }
            }
        }
    }
    protected bool CheckUserSession()
    {
        if (Session["MemberInfo"] == null)
        {
            return false;
        }
        else
        {
            DataTable dtUser;
            dtUser = new DataTable();
            dtUser = (DataTable)Session["MemberInfo"];
            if (dtUser.Rows[0]["memberId"].ToString() == "0")
            {
                return false;
            }
        }
        return true;
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
    public void MessageThenRedirectTo(string message, string pageName)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            message = message.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(),
                "MessageThenRedirect", "alert('" + message +
                "');window.location='" + pageName + ".aspx';", true);
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
    protected DataTable getStateCityOnPincode(float pincode)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_PinCodeCheckOnId", new SqlParameter("@pincode", pincode));
        return dt;
    }
}