using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class WishList : System.Web.UI.Page
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
                DataTable dtUser;
                dtUser = new DataTable();
                dtUser = (DataTable)Session["MemberInfo"];
                if (dtUser.Rows[0]["memberId"].ToString() != "0")
                {
                    BindWishList();
                    BindFinalAmt();
                }
                else
                {
                    Session["CameFrom"] = "Wishlist";
                    Response.Redirect("Register.aspx");
                }
            }
        }
        else
        {
            Session["CameFrom"] = "Wishlist";
            Response.Redirect("Register.aspx");
        }
    }
    protected void BindWishList()
    {
        clsWishlist = new clsWishlist();


        rptrCart.DataSource = clsWishlist.BindWishlist();
        rptrCart.DataBind();

        if (rptrCart.Items.Count <= 0)
        {
            Response.Redirect("MemberDashboard.aspx");
        }
    }
    protected void BindFinalAmt()
    {
        //double ftotal = 0;

        //foreach (RepeaterItem rptitem in dlMail.Items)
        //{
        //    Label lblamt = (Label)rptitem.FindControl("lblfprice");
        //    ftotal = ftotal + Convert.ToDouble(lblamt.Text);
        //}
        Control footer = rptrCart.Controls[rptrCart.Controls.Count - 1].Controls[0];
        Label lblFinalTotal = (Label)footer.FindControl("lblFinalTotal");
        clsWishlist = new clsWishlist();
        lblFinalTotal.Text = Math.Round(clsWishlist.TotalPrice()).ToString();
    }
    protected void btnSaveWishList_Click(object sender, EventArgs e)
    {
        DataTable dtMember = new DataTable();
        dtMember = (DataTable)Session["MemberInfo"];

        //delete from wishlsit

        cls.ExecuteDA("Delete_WishList", new SqlParameter("@MemberId", Convert.ToInt32(dtMember.Rows[0]["MemberId"])));

        //insert into Wishlist

        DataTable dt = new DataTable();
        clsWishlist = new clsWishlist();
        dt = clsWishlist.BindWishlist();
        foreach (DataRow dr in dt.Rows)
        {
            cls.ExecuteDA("Insert_WishList", new SqlParameter("@MemberId", Convert.ToInt32(dtMember.Rows[0]["MemberId"])),
                                                        new SqlParameter("@ProductId", Convert.ToInt32(dr["ProductId"])),
                                                         new SqlParameter("@CategoryName", dr["CategoryName"]),
                                                         new SqlParameter("@SubCategoryName", dr["SubCategoryName"]),
                                                         new SqlParameter("@ProductName", dr["ProductName"]),
                                                         new SqlParameter("@Productdescp", dr["Productdescp"]),
                                                         new SqlParameter("@BrandName", dr["BrandName"]),
                                                         new SqlParameter("@SupplierName", dr["SupplierName"]),
                                                         new SqlParameter("@Unit", dr["Unit"]),
                                                         new SqlParameter("@ColourName", dr["ColourName"]),
                                                         new SqlParameter("@SizeName", dr["SizeName"]),
                                                         new SqlParameter("@ProductCode", dr["ProductCode"]),
                                                         new SqlParameter("@SupplierProductCode", dr["SupplierProductCode"]),
                                                         new SqlParameter("@PackSize", dr["PackSize"]),
                                                         new SqlParameter("@ProductCost", dr["ProductCost"]),
                                                         new SqlParameter("@ProductWeight", dr["ProductWeight"]),
                                                         new SqlParameter("@Image", dr["Image"]),
                                                         new SqlParameter("@Certification", dr["Certification"]),
                                                         new SqlParameter("@Description", dr["Description"]),
                                                         new SqlParameter("@Margin", Convert.ToDouble(dr["Margin"])),
                                                         new SqlParameter("@SalePrice", Convert.ToDouble(dr["SalePrice"])),
                                                         new SqlParameter("@Tax", Convert.ToDouble(dr["Tax"])),
                                                         new SqlParameter("@SalesPrice_Incl", Convert.ToDouble(dr["SalesPrice_Incl"])),
                                                         new SqlParameter("@MRP", Convert.ToDouble(dr["MRP"])),
                                                         new SqlParameter("@Discount", Convert.ToDouble(dr["Discount"])),
                                                         new SqlParameter("@CalDiscount", Convert.ToDouble(dr["CalDiscount"])),
                                                         new SqlParameter("@ShippingCost", Convert.ToDouble(dr["ShippingCost"])),
                                                         new SqlParameter("@FinalSellingPrice", Convert.ToDouble(dr["FinalSellingPrice"])),
                                                         new SqlParameter("@TaxFinalPrice", Convert.ToDouble(dr["TaxFinalPrice"])),
                                                         new SqlParameter("@Quantity", Convert.ToDouble(dr["Qty"])),
                                                         new SqlParameter("@ShippingDays", dr["ShippingDays"]),
                                                         new SqlParameter("@IsCOD", Convert.ToBoolean(dr["IsCOD"])));
        }
        MsgBox("Wishlist Saved Successfully.");
    }
    protected void rptrCart_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "AddCart")
        {
            Label lblSize = (Label)e.Item.FindControl("lblSize");
            Label lblColor = (Label)e.Item.FindControl("lblColor");
            string ProductId = e.CommandArgument.ToString();
            TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
            Qty = Convert.ToDouble(txtQty.Text);

            Addingitemincart(ProductId, lblSize.Text, lblColor.Text, Qty);
            clsWishlist = new clsWishlist();
            clsWishlist.RemoveItem(e.Item.ItemIndex);
            Response.Redirect("Cart.aspx");
        }
        else if (e.CommandName == "Remove")
        {
            clsWishlist = new clsWishlist();
            clsWishlist.RemoveItem(e.Item.ItemIndex);
        }

        BindWishList();
        BindFinalAmt();
        BindTopCartItems();
    }

    protected void Addingitemincart(string ProductId, string size, string color, double quantity)
    {
        DataTable dt = new DataTable();
        clsWishlist = new clsWishlist();
        dt = clsWishlist.BindWishlistOnProductSizeColor(ProductId, size, color);


        foreach (DataRow dr in dt.Rows)
        {
            ProductId = dr["ProductId"].ToString();
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
            MinQty = Convert.ToDouble(dr["Qty"].ToString());
            ShippingDays = dr["ShippingDays"].ToString();
            IsCOD = Convert.ToBoolean(dr["IsCOD"]);
        }

        SizeName = size;
        ColourName = color;

        if (quantity < MinQty)
        {
            MsgBox("Minimum Qty required for order is : " + MinQty);
            return;
        }

        Price = quantity * FinalSellingPrice;

        clsCart = new clsAddToCart();

        if (quantity != 0)
        {
            if (clsCart.FindExistItemWithSizeColor(ProductId, SizeName, ColourName))
            {
                clsCart.UpdateQtyAndPriceWithSizeColor(ProductId, Qty, FinalSellingPrice, SizeName, ColourName);
            }
            else
            {
                clsCart.AddToCart(ProductId, CategoryName, SubCategoryName, ProductName, Productdescp, BrandName, SupplierName, Unit, ColourName, SizeName, ProductCode, SupplierProductCode, PackSize, ProductCost, ProductWeight, Image, Certification, Description, Margin, SalePrice, Tax, SalesPrice_Incl, MRP, Discount, CalDiscount, ShippingCost, FinalSellingPrice, TaxFinalPrice, Qty, ShippingDays, IsCOD, Price);
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
            ScriptManager.RegisterStartupScript(page, page.GetType(), "MessageThenRedirect", "alert('" + message + "')", true);
        }
    }
    protected void btnAddCart_Click(object sender, EventArgs e)
    {
        string removeid = "";
        foreach (RepeaterItem ri in rptrCart.Items)
        {
            CheckBox chk = (CheckBox)ri.FindControl("chk");
            if (chk != null)
            {
                if (chk.Checked)
                {
                    Label lblpid = (Label)ri.FindControl("lblpid");
                    if (lblpid != null)
                    {
                        Label lblSize = (Label)ri.FindControl("lblSize");
                        Label lblColor = (Label)ri.FindControl("lblColor");
                        string ProductId = lblpid.Text.ToString();
                        TextBox txtQty = (TextBox)ri.FindControl("txtQty");
                        Qty = Convert.ToDouble(txtQty.Text);

                        Addingitemincart(ProductId, lblSize.Text, lblColor.Text, Qty);
                        removeid = ri.ItemIndex + "," + removeid;
                        //clsWishlist.RemoveItem(ri.ItemIndex);
                        Response.Redirect("Cart.aspx");

                    }
                }
            }
        }
        if (removeid != "")
        {
            clsWishlist = new clsWishlist();
            removeid = removeid.TrimEnd(',');
            clsWishlist.RemoveMultipleItems(removeid);
            Response.Redirect("Cart.aspx");
        }
        else
        {
            MsgBox("Please select product to add in cart.");
        }
    }
}