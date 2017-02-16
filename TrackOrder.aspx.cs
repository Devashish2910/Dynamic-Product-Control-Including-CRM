using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class TrackOrder : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    public string invoiceid;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCheckStatus_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_InvoiceBillShipDetailsFromIDForTracking", new SqlParameter("@ID", txtOrderNumber.Text), new SqlParameter("@EmailId", txtEmailId.Text));

        if (dt.Rows.Count > 0)
        {
            rptOrderDetails.DataSource = dt;
            rptOrderDetails.DataBind();


            rptBilling.DataSource = dt;
            rptBilling.DataBind();

            rptShipping.DataSource = dt;
            rptShipping.DataBind();

            rptrCutomerTin.DataSource = dt;
            rptrCutomerTin.DataBind();

            invoiceid = dt.Rows[0]["InvoiceId"].ToString();
            BindProduct(dt.Rows[0]["InvoiceId"].ToString());
            pnlTrack.Visible = true;

            if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CouponName"])))
            {
                lblCoupon.Text = "Using Voucher Code (" + dt.Rows[0]["CouponName"] + ")";
            }
            else
            {
                lblCoupon.Text = "";
            }
            lblDisPer.Text = "(" + dt.Rows[0]["DiscountPer"] + "%)";
            lblDisVal.Text = Math.Round(Convert.ToDouble(dt.Rows[0]["DiscountAmount"])).ToString();
        }
        else
        {
            rptOrderDetails.DataSource = null;
            rptOrderDetails.DataBind();
            pnlTrack.Visible = false;
            MsgBox("Enter valid number or Correct Email Id which used in Shipping Address");
        }
    }

    protected void BindProduct(string invoiceid)
    {
        DataTable dtprod = new DataTable();
        dtprod = cls.ReturnDataTable("Select_InvoiceProductDetailsFromID", new SqlParameter("@InvoiceId", invoiceid));
        rptrCart.DataSource = dtprod;
        rptrCart.DataBind();
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
        lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["OrderAmount"])).ToString();
        lblAmountinWords.Text = num.NumberToWords(Convert.ToInt32(lblFinalTotal.Text)) + " only.";
        lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["OrderAmount"])).ToString();
    }
}