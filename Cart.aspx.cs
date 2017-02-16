using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Cart : System.Web.UI.Page
{
    clsAddToCart clsCart;
    Clsconnection cls = new Clsconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCart();
            BindFinalAmt();
            setCoupoCodePanel();
        }
    }
    protected void BindCart()
    {
        clsCart = new clsAddToCart();
        if (clsCart.TotalItems() <= 0)
        {
            ShowMessageThenRedirectTo("Cart is empty", "default");
        }
        rptrCart.DataSource = clsCart.BindCart();
        rptrCart.DataBind();
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
        //TextBox txtCoupon = (TextBox)footer.FindControl("txtCoupon");

        string amount;
        amount = ValidateCoupon(Convert.ToString(Session["CouponCode"]));

        if (e.CommandName == "UpdateCart")
        {
            if (amount == "") // coupon code not applicable
            {
                RemoveDiscountSession();
            }
            clsCart = new clsAddToCart();
            if (txtQty.Text != "")
            {
                if (Convert.ToDouble(txtQty.Text) != 0)
                {
                    clsCart.SetQtyAndPriceWithSizeColor(ProductId, Convert.ToDouble(txtQty.Text), Convert.ToDouble(lblProPrice.Text), lblSize.Text, lblColor.Text);
                }
            }
        }
        else if (e.CommandName == "Remove")
        {
            if (amount == "") // coupon code not applicable
            {
                RemoveDiscountSession();
            }
            clsCart = new clsAddToCart();
            clsCart.RemoveItem(e.Item.ItemIndex);
        }
        BindCart();
        BindFinalAmt();
        BindTopCartItems();
        setCoupoCodePanel();
    }

    protected void btnCheckPinCode_OnClick(Object sender, EventArgs e)
    {

        if (txtPinCode != null)
        {
            DataTable dt = new DataTable();
            dt = getStateCityOnPincode(Convert.ToInt64(txtPinCode.Text));

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

    protected DataTable getStateCityOnPincode(float pincode)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_PinCodeCheckOnId", new SqlParameter("@pincode", pincode));
        return dt;
    }
    protected void lnkCheckout_OnClick(object sender, EventArgs e)
    {
        if (Session["MemberInfo"] != null)
        {
            DataTable dtUser;
            dtUser = new DataTable();
            dtUser = (DataTable)Session["MemberInfo"];
            if (dtUser.Rows[0]["memberId"].ToString() != "0")
            {
                Response.Redirect("Checkout_Shipping.aspx");
            }
            else
            {
                Response.Redirect("Checkout_Login.aspx");
            }
        }
        else
        {
            Response.Redirect("Checkout_Login.aspx");
        }
    }

    protected void setCoupoCodePanel()
    {
        if (Session["Discount"] != null)
        {
            Control footer = rptrCart.Controls[rptrCart.Controls.Count - 1].Controls[0];
            //Panel pnlCoupon = (Panel)footer.FindControl("pnlCoupon");
            //pnlCoupon.Visible = false;
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
        }
        else
        {
            Control footer = rptrCart.Controls[rptrCart.Controls.Count - 1].Controls[0];
            //Panel pnlCoupon = (Panel)footer.FindControl("pnlCoupon");
            //pnlCoupon.Visible = true;
            Panel pnlCouponapplied = (Panel)footer.FindControl("pnlCouponapplied");
            pnlCouponapplied.Visible = false;
        }
    }
    protected void RemoveDiscountSession()
    {
        Session["Discount"] = null;
        Session["CouponCode"] = null;
    }
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

        BillingShippingDetails clsBSD;
        clsBSD = new BillingShippingDetails();
        DataTable dtbilship1 = new DataTable();
        dtbilship1 = clsBSD.BindBillShip();

        if (dtbilship1.Rows.Count > 0)
            email = dtbilship1.Rows[0]["SEmail"].ToString(); // set email
        else
            email = "";
        couponname = CouponName; // set couponname
        try
        {
            amount = cls.ReturnScalerObject("GetDiscountOnCoupon", new SqlParameter("@CouponName", couponname), new SqlParameter("@MemberId", memberid), new SqlParameter("@Email", email), new SqlParameter("@OrderValue", orderval)).ToString();
        }
        catch
        {
            amount = "";
        }
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