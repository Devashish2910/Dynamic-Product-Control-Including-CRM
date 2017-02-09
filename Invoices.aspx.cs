using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Invoices : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    public string invoiceid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
        {
            invoiceid = Request.QueryString["ID"].ToString();
        }
        else
        {
            Response.Redirect("TrackOrder.aspx");
        }
        if (!IsPostBack)
        {
            BindOrder();
            BindInvoice();
        }
    }
    protected void BindOrder()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_OrdersDetailsFromOrderId", new SqlParameter("@InvoiceId", invoiceid));
        if (dt.Rows.Count > 0)
        {
            lblOrderNo.Text = dt.Rows[0]["OrderId"].ToString();
        }        
    }
    protected void BindInvoice()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_InvoiceDisptachFromOrderId", new SqlParameter("@InvoiceId", invoiceid));
        if (dt.Rows.Count <= 0)
        {
            ShowMessageThenRedirectTo("No Record Found","TrackOrder");
        }
        rptrInvoice.DataSource = dt;
        rptrInvoice.DataBind();
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