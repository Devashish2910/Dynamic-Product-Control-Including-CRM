using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Checkout_Order : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    clsAddToCart clsCart;
    BillingShippingDetails clsBSD;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["MemberInfo"] != null)
        {
            if (HttpContext.Current.Session["Cart"] != null)
            {
                clsCart = new clsAddToCart();
                if (clsCart.TotalItems() <= 0)
                {
                    Response.Redirect("Checkout_Login.aspx");
                }
            }
            if (!IsPostBack)
            {
                BindCart();
                BindFinalAmt();
                BindOrderSummary();
                BindShippingSummary();
                setCoupoCodePanel();
            }
        }
        else
        {
            HttpContext.Current.Session["CameFrom"] = "CheckOut_Login";
            Response.Redirect("Checkout_Login.aspx");
        }
    }
    protected void BindCart()
    {
        clsCart = new clsAddToCart();       
        rptrCart.DataSource = clsCart.BindCart();
        rptrCart.DataBind();
    }

    protected void BindShippingSummary()
    {
        clsBSD = new BillingShippingDetails();
        rptShipping.DataSource = clsBSD.BindBillShip();
        rptShipping.DataBind();
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
        clsCart = new clsAddToCart();
        lblFinalTotal.Text = Math.Round(clsCart.TotalPriceWithoutDiscount()).ToString();
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
    protected void rptrCart_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string ProductId = e.CommandArgument.ToString();
        Label lblProPrice = (Label)e.Item.FindControl("lblProPrice");
        TextBox txtQty = (TextBox)e.Item.FindControl("txtQty");
        Label lblSize = (Label)e.Item.FindControl("lblSize");
        Label lblColor = (Label)e.Item.FindControl("lblColor");

        Control footer = rptrCart.Controls[rptrCart.Controls.Count - 1].Controls[0];
        TextBox txtCoupon = (TextBox)footer.FindControl("txtCoupon");

        string amount;
        amount = ValidateCoupon(txtCoupon.Text.Trim());

        if (e.CommandName == "UpdateCart")
        {
            if (amount == "") // coupon code not applicable
            {
                RemoveDiscountSession();
            }
            clsCart = new clsAddToCart();
            clsCart.SetQtyAndPriceWithSizeColor(ProductId, Convert.ToDouble(txtQty.Text), Convert.ToDouble(lblProPrice.Text), lblSize.Text, lblColor.Text);
            //BindCart(); 
            //setCoupoCodePanel();
        }
        else if (e.CommandName == "Remove")
        {
            if (amount == "") // coupon code not applicable
            {
                RemoveDiscountSession();
            }

            clsCart = new clsAddToCart();
            clsCart.RemoveItem(e.Item.ItemIndex);
            // BindCart();
            // setCoupoCodePanel();
        }
        else if (e.CommandName == "Coupon")
        {
            if (amount != "")//coupon code applicable
            {
                Session["Discount"] = Convert.ToDouble(amount);
                Session["CouponCode"] = txtCoupon.Text;
            }
            else
            {
                MsgBox("Coupon not Applicable");
                return;
            }
        }
        BindCart();
        BindFinalAmt();
        BindTopCartItems();
        BindOrderSummary();
        setCoupoCodePanel();
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("Checkout_Payment.aspx");
    }

    protected void BindOrderSummary()
    {
        clsCart = new clsAddToCart();
        lblTotalItems.Text = clsCart.TotalItems().ToString();
        lblTotalAmount.Text = "Rs. " + Math.Round(clsCart.TotalPrice()).ToString();
    }

    protected void lnkChange_OnClick(object sender, EventArgs e)
    {
        Session["CameAgain"] = "1";
        Response.Redirect("Checkout_Shipping.aspx");
    }
    protected void setCoupoCodePanel()
    {
        if (Session["Discount"] != null)
        {
            Control footer = rptrCart.Controls[rptrCart.Controls.Count - 1].Controls[0];
            Panel pnlCoupon = (Panel)footer.FindControl("pnlCoupon");
            pnlCoupon.Visible = false;
            Panel pnlCouponapplied = (Panel)footer.FindControl("pnlCouponapplied");
            pnlCouponapplied.Visible = true;

            Label lblGrandTotal = (Label)footer.FindControl("lblGrandTotal");
            Label lblDiscount = (Label)footer.FindControl("lblDiscount");
            Label lblDiscountPer = (Label)footer.FindControl("lblDiscountPer");
            Label lblCoupon = (Label)footer.FindControl("lblCoupon");
            Label lblFinalTotal = (Label)footer.FindControl("lblFinalTotal");

            clsCart = new clsAddToCart();
            lblGrandTotal.Text = Math.Round(clsCart.TotalPrice()).ToString();
            lblCoupon.Text = Session["CouponCode"].ToString();
            lblDiscount.Text = Math.Round((Convert.ToDouble(lblFinalTotal.Text) - Convert.ToDouble(lblGrandTotal.Text))).ToString();
            lblDiscountPer.Text = "(" + Session["Discount"].ToString() + "%)  Discount";
            Session["DiscountValue"] = Convert.ToDouble(lblDiscount.Text);
        }
        else
        {
            Control footer = rptrCart.Controls[rptrCart.Controls.Count - 1].Controls[0];
            Panel pnlCoupon = (Panel)footer.FindControl("pnlCoupon");
            pnlCoupon.Visible = true;
            Panel pnlCouponapplied = (Panel)footer.FindControl("pnlCouponapplied");
            pnlCouponapplied.Visible = false;
        }
    }
    protected void RemoveDiscountSession()
    {
        Session["Discount"] = null;
        Session["CouponCode"] = null;
    }
    //protected int checkCoupon(string CouponName)
    //{
    //    int flag = 1;


    //    int a, b, c;

    //    if (Session["MemberInfo"] != null)
    //    {
    //        a = 1;
    //        DataTable dtUser;
    //        dtUser = new DataTable();
    //        dtUser = (DataTable)Session["MemberInfo"];
    //        if (dtUser.Rows[0]["memberId"].ToString() == "0")
    //        {
    //            a = 2;
    //        }
    //    }
    //    else
    //    {
    //        a = 2;
    //    }

    //    clsBSD = new BillingShippingDetails();
    //    DataTable dtbilship1 = new DataTable();
    //    dtbilship1 = clsBSD.BindBillShip();

    //     if (cls.CheckExistField("CheckExistField", "InvoiceBillingShipping", "ColourName", txtcolourname.Text, "and IsActive = 1"))
    //        {
    //     }



    //    DataTable dt = new DataTable();
    //    dt = cls.ReturnDataTable("Select_CouponOnName", new SqlParameter("@CouponName", CouponName));

    //    if (dt.Rows.Count > 0)
    //    {

    //    }
    //    else
    //    {
    //        flag = 2; // coupon not exist 
    //    }
    //    return flag;    
    //}


    protected string ValidateCoupon(string CouponName)
    {
        string amount = "";
        int memberid;
        double orderval;
        string email;
        string couponname;

        if (Session["MemberInfo"] != null)
        {
            DataTable dtUser;
            dtUser = new DataTable();
            dtUser = (DataTable)Session["MemberInfo"];
            memberid = Convert.ToInt32(dtUser.Rows[0]["memberId"].ToString()); // set memberid
        }
        else
        {
            memberid = 0;
        }

        clsCart = new clsAddToCart();
        orderval = clsCart.TotalPriceWithoutDiscount(); // set ordervalue


        clsBSD = new BillingShippingDetails();
        DataTable dtbilship1 = new DataTable();
        dtbilship1 = clsBSD.BindBillShip();

        email = dtbilship1.Rows[0]["SEmail"].ToString(); // set email
        couponname = CouponName; // set couponname
        amount = cls.ReturnScalerObject("GetDiscountOnCoupon", new SqlParameter("@CouponName", couponname), new SqlParameter("@MemberId", memberid), new SqlParameter("@Email", email), new SqlParameter("@OrderValue", orderval)).ToString();
        return amount;
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
    public void ShowMessageThenRedirectTo(string message, string pageName)
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
}