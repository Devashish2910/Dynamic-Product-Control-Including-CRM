using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Net.Mail;

public partial class Admin_ViewOrders : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    string invoiceid = "";
    StringBuilder strMailHtml;
   public static DataTable dtprod = new DataTable();
   public static DataTable dtship = new DataTable();
   public static  DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
   {
       if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
       {
           invoiceid = Request.QueryString["ID"].ToString();
           if (!IsPostBack)
           {
               BindOrderDetails();
               BindOrderProducts();
               BindShippingBilling();
           }
           Label lblFormTitle = (Label)this.Master.FindControl("lblFormTitle");
           lblFormTitle.Text = "View Order";
       }
       else
       {
           Response.Redirect("Order.aspx");
       }
    }
    protected void BindOrderDetails()
    {
        
        dt = cls.ReturnDataTable("Select_OrdersDetailsFromOrderId", new SqlParameter("@InvoiceId", invoiceid));
        rptOrder.DataSource = dt;
        rptOrder.DataBind();
        if (dt.Rows.Count > 0)
        {
            //txtTracking.Text = dt.Rows[0]["TrackingDetails"].ToString();
          //  ddlOrderStatus.SelectedValue = dt.Rows[0]["OrderStatus"].ToString();
            //if (dt.Rows[0]["PaymentMode"].ToString() == "Cash On Delivery")
            //{
            //    lblPaid.Visible = false;
            //    chkCOD.Visible = true;
            //    chkCOD.Checked = Convert.ToBoolean(dt.Rows[0]["IsPaid"]);
            //}
            //else
            //{
            //    lblPaid.Visible = true;
            //    chkCOD.Visible = false;
            //}
        }       
        //if (ddlOrderStatus.SelectedValue.ToString() == "Dispatched" || ddlOrderStatus.SelectedValue.ToString() == "Delivered")
        //{
        //    BindDrpCourier();
        //    pnlShip.Visible = true;
        //   // txtTrackingNo.Text = dt.Rows[0]["TrackingNumber"].ToString();
        //    //drpCourier.SelectedValue = dt.Rows[0]["CourierName"].ToString();

        //    //drpCourier.Items.FindByText(dt.Rows[0]["CourierName"].ToString()).Selected=true;

        //   // drpCourier.Items.FindByText("UPS") = true;
        //}
    }

    protected void BindOrderProducts()
    {       
        dtprod = cls.ReturnDataTable("Select_InvoiceProductFromOrderId", new SqlParameter("@InvoiceId", invoiceid));
        rptProduct.DataSource = dtprod;
        rptProduct.DataBind();
    }
    protected void BindShippingBilling()
    {        
        dtship = cls.ReturnDataTable("Select_InvoiceBillingShippingFromOrderId", new SqlParameter("@InvoiceId", invoiceid));
        rptShipping.DataSource = dtship;
        rptShipping.DataBind();

        rptBill.DataSource = dtship;
        rptBill.DataBind();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Orders.aspx");
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
    //protected void ddlOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlOrderStatus.SelectedValue.ToString() == "Dispatched" || ddlOrderStatus.SelectedValue.ToString() == "Delivered")
    //    {
    //        pnlShip.Visible = true;
    //        BindDrpCourier();
    //    }
    //    else
    //    {
    //        pnlShip.Visible = false;
    //    }
    //}
}