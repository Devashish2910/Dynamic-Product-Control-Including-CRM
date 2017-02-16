using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_InvoiceDetails : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    public static string invoiceid, invoicedispatchid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Utils.IsLoggedIn())
        {
            Utils.LogOut();
        }
        else
        {
            if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null && Request.QueryString["InvID"] != "" && Request.QueryString["InvID"] != null)
            {
                Label lblFormTitle = (Label)this.Master.FindControl("lblFormTitle");
                lblFormTitle.Text = "Invoice Detail";

                invoicedispatchid = Request.QueryString["InvID"].ToString();
                invoiceid = Request.QueryString["ID"].ToString();
                if (!IsPostBack)
                {
                    BindOrder();
                    BindProduct();
                }
            }
            else
            {
                Response.Redirect("Order.aspx");
            }
        }
    }
    protected void BindOrder()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_InvoiceBillShipDetailsFromID", new SqlParameter("@InvoiceId", invoiceid));

        DataTable dt1 = new DataTable();
        dt1 = cls.ReturnDataTable("Select_InvoiceWiseOrderDetailsFromID", new SqlParameter("@InvoiceId", invoiceid),
                                                                                   new SqlParameter("@InvoiceDispatchID", invoicedispatchid));
        rptOrderDetails.DataSource = dt1;
        rptOrderDetails.DataBind();

        rptBilling.DataSource = dt;
        rptBilling.DataBind();

        rptShipping.DataSource = dt;
        rptShipping.DataBind();

        rptrCutomerTin.DataSource = dt;
        rptrCutomerTin.DataBind();

        rptHeader.DataSource = dt;
        rptHeader.DataBind();
    }
    protected void BindProduct()
    {
        DataTable dtprod = new DataTable();
        dtprod = cls.ReturnDataTable("Select_InvoiceDispatchProductDetailsFromID", new SqlParameter("@InvoiceId", invoiceid),
                                                                                   new SqlParameter("@InvoiceDispatchID", invoicedispatchid));
        rptrCart.DataSource = dtprod;
        rptrCart.DataBind();

        if (dtprod.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dtprod.Rows[0]["CouponName"])))
            {
                lblCoupon.Text = "Using Voucher Code (" + dtprod.Rows[0]["CouponName"] + ")";
                lblDisPer.Text = "(" + dtprod.Rows[0]["InvoiceDiscountPer"] + "%)";
                lblDisVal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["InvoiceDiscountAmount"])).ToString();
            }
            else
            {
                lblCoupon.Text = "";
            }

        }
    }
    protected void rptrCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        NumbertoWords num = new NumbertoWords();
        DataTable dtprod = new DataTable();
        dtprod = cls.ReturnDataTable("Select_InvoiceDispatchProductDetailsFromID", new SqlParameter("@InvoiceId", invoiceid),
                                                                                  new SqlParameter("@InvoiceDispatchID", invoicedispatchid));
        lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["InvoiceAmount"])).ToString();
        lblAmountinWords.Text = num.NumberToWords(Convert.ToInt32(lblFinalTotal.Text)) + " only.";
        lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["InvoiceAmount"])).ToString();
    }
    protected void rptOrderDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblTrackNo = (Label)e.Item.FindControl("lblTrackNo");
            Image imgBarcode = (Image)e.Item.FindControl("imgBarcode");
            imgBarcode.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText={1}&Thickness={2}",
                                            lblTrackNo.Text,
                                            1,
                                            1);
        }
    }
}