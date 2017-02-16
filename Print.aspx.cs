using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Print : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    clsAddToCart clsCart;
    public string invoiceid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["OID"] != "" && Request.QueryString["OID"] != null)
        {
            invoiceid = Request.QueryString["OID"].ToString();
        }
        else
        {
            Response.Redirect("Trackorder.aspx");
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
            Response.Write("<script language='javascript'> { self.close() }</script>");
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
        else
        {
            ShowMessageThenRedirectTo("No Record Found", "TrackOrder");
        }
    }
    protected void rptrCart_OnItemDatabound(object source, RepeaterItemEventArgs e)
    {
        //    Control footer = rptrCart.Controls[rptrCart.Controls.Count - 1].Controls[0];
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
        if (dtprod.Rows.Count > 0)
        {
            lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["OrderAmount"])).ToString();
            lblAmountinWords.Text = num.NumberToWords(Convert.ToInt32(lblFinalTotal.Text)) + " only.";
            lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["OrderAmount"])).ToString();
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