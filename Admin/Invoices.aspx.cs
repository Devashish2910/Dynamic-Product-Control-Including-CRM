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

public partial class Admin_Invoices : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    string invoiceid = "";
    public static DataTable dt = new DataTable();
    public static DataTable dtinvoice = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!Utils.IsLoggedIn())
        {
            Utils.LogOut();
        }
        else
        {
            Label lblFormTitle = (Label)this.Master.FindControl("lblFormTitle");
            lblFormTitle.Text = "Invoice";
            invoiceid = Request.QueryString["ID"].ToString();
            if (!IsPostBack)
            {
                BindOrderDetails();
                BindInvoiceDetails();
            }
        }
    }
    protected void BindOrderDetails()
    {

        dt = cls.ReturnDataTable("Select_OrdersDetailsFromOrderId", new SqlParameter("@InvoiceId", invoiceid));
        rptOrder.DataSource = dt;
        rptOrder.DataBind();        
    }

    protected void BindInvoiceDetails()
    {
        dtinvoice = cls.ReturnDataTable("Select_InvoiceDisptachFromOrderId", new SqlParameter("@InvoiceId", invoiceid));
        rptr.DataSource = dtinvoice;
        rptr.DataBind();
    }

    protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            Response.Redirect("InvoiceDetails.aspx?ID=" + invoiceid + "&InvID=" + e.CommandArgument.ToString() + "");
        }
        if (e.CommandName == "Edit")
        {
            Response.Redirect("UpdateInvoice.aspx?ID=" + invoiceid + "&InvID=" + e.CommandArgument.ToString() + "");
        }
    }
}