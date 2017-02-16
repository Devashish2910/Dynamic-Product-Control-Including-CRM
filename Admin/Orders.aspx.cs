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

public partial class Admin_Orders : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    StringBuilder strMailHtml;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Utils.IsLoggedIn())
            {
                Utils.LogOut();
            }
            else
            {
                Label lblFormTitle = (Label)this.Master.FindControl("lblFormTitle");
                lblFormTitle.Text = "Manage Orders";
                BindOrders();
            }
        }
    }
    protected void BindOrders()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_AllOrders");
        rptr.DataSource = dt;
        rptr.DataBind();
    }

    protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            Response.Redirect("ViewOrders.aspx?ID=" + e.CommandArgument.ToString() + "");
        }
        else if (e.CommandName == "GenreateInvoice")
        {
            Response.Redirect("GenerateInvoice.aspx?ID=" + e.CommandArgument.ToString() + "");
        }
        else if (e.CommandName == "ViewInvoice")
        {
            Response.Redirect("Invoices.aspx?ID=" + e.CommandArgument.ToString() + "");
        }
        else if (e.CommandName == "UpdateStatus")
        {
            //update payment status
            string[] temp;
            char split = ',';
            temp = e.CommandArgument.ToString().Split(split);
            int invoiceid = Convert.ToInt32(temp[0]);
            bool status = Convert.ToBoolean(temp[1]);
            if (status == false)
                status = true;
            else
                status = false;

            cls.ExecuteDA("Update_IsPaid", new SqlParameter("@InvoiceId", invoiceid), new SqlParameter("@IsPaid", status));
            BindOrders();
        }
    }

    protected void rptr_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //Label lblStatus = (Label)e.Item.FindControl("lblStatus");
        //DropDownList drpStatus = (DropDownList)e.Item.FindControl("drpStatus");
        //Label lblPaymentMode = (Label)e.Item.FindControl("lblPaymentMode");
        //CheckBox chkCOD = (CheckBox)e.Item.FindControl("chkCOD");

        //if (lblStatus != null)
        //{
        //    drpStatus.SelectedValue = lblStatus.Text;
        //    Label lblPaid = (Label)e.Item.FindControl("lblPaid");
        //    if (lblPaymentMode.Text == "Cash On Delivery")
        //    {
        //        chkCOD.Visible = true;
        //        lblPaid.Visible = false;
        //    }
        //    else
        //    {
        //        lblPaid.Visible = true;
        //        lblPaid.Text = "Yes";
        //    }

        //}
    }
    protected void drpStatus_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList drp = (DropDownList)sender;
        cls.ExecuteDA("Update_OrderStatus", new SqlParameter("@InvoiceId", drp.ToolTip), new SqlParameter("@OrderStatus", drp.SelectedValue));
        BindOrders();
        //MailClientOrderStatus(drp.ToolTip, drp.SelectedValue);
    }
    protected void chkCOD_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        cls.ExecuteDA("Update_IsPaid", new SqlParameter("@InvoiceId", chk.ToolTip), new SqlParameter("@IsPaid", chk.Checked));
        BindOrders();
    }
    protected void MailClientOrderStatus(string invoiceid, string orderstatus)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_OrdersDetailsFromOrderId", new SqlParameter("@InvoiceId", invoiceid));
        DataTable dtship = new DataTable();
        dtship = cls.ReturnDataTable("Select_InvoiceBillingShippingFromOrderId", new SqlParameter("@InvoiceId", invoiceid));

        string content = "";
        strMailHtml = new StringBuilder();
        strMailHtml.Append("﻿<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
        strMailHtml.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
        strMailHtml.Append("<head>");
        strMailHtml.Append("    <title></title>");
        strMailHtml.Append("</head>");
        strMailHtml.Append("<body>");
        strMailHtml.Append("    <table width='600px' border='0' align='left' cellpadding='2' cellspacing='2' style='border: 1px solid #ff4f12;'>");
        strMailHtml.Append("        <tbody>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' height='100' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial; border-bottom: 1px solid #ff4f12'>");
        strMailHtml.Append("                    <img border='0' src='http://dhitsolutions.com/images/logo.png' alt='chiptronics'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='30' align='left' valign='middle' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial'>");
        strMailHtml.Append("                    Dear " + dtship.Rows[0]["SName"].ToString() + ",");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("                <td height='25' align='right' valign='middle' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial'>");
        strMailHtml.Append("                    Date:" + DateTime.Now.ToString("dd MMM yyyy") + "");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' style='font-size: 12px; text-decoration: none; font-family: Arial;");
        strMailHtml.Append("                    padding: 20px; padding-bottom: 20px;'>");
        strMailHtml.Append("                    <table width='300' cellpadding='0' cellspacing='0'>");
        strMailHtml.Append("                        <tbody>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' colspan='' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Order No");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    " + dt.Rows[0]["OrderID"].ToString() + "");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Order Amount");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    <div style='word-wrap: break-word'>");
        strMailHtml.Append("                                        " + dt.Rows[0]["OrderAmount"].ToString() + "</div>");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' colspan='3' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    You order has been " + orderstatus + ".");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                               ");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                        </tbody>");
        strMailHtml.Append("                    </table>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='25' colspan='2' align='left' valign='middle' style='font-size: 12px;");
        strMailHtml.Append("                    font-weight: bold; color: #000000; text-decoration: none; font-family: Arial;'>");
        strMailHtml.Append("                    Regards,");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' style='font-family: Arial; font-size: 11px; color: #000000; text-decoration: none;");
        strMailHtml.Append("                    line-height: 25px; font-weight: bold'>");
        strMailHtml.Append("                    Dhit solutions<br>");
        strMailHtml.Append("                    45, Gunatit park, behind T.B.Hospital, Gotri Road, Vadodara-21<br />");
        strMailHtml.Append("                    <u>Phone</u> : +91-9722659812");
        strMailHtml.Append("                    <br>");
        strMailHtml.Append("                    <u>Email</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:mail@dhitsolutions.org'>");
        strMailHtml.Append("                        mail@dhitsolutions.org</a> <u>Web</u> : <a target='_blank' style='text-decoration: none;");
        strMailHtml.Append("                            color: #ff4f12' href='http://www.dhitsolutions.com'>www.dhitsolutions.com</a>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("        </tbody>");
        strMailHtml.Append("    </table>");
        strMailHtml.Append("</body>");
        strMailHtml.Append("</html>");

        content = strMailHtml.ToString();
        MailClient(content, orderstatus, dtship.Rows[0]["SEmail"].ToString());
    }

    protected void MailClient(string content, string orderstatus, string tomail)
    {
        try
        {
            MailMessage mailMsg = new MailMessage();
            MailAddress fromAdd = new MailAddress("mail@dhitsolutions.org");
            MailAddress replyto = new MailAddress("mail@dhitsolutions.org");
            mailMsg.From = fromAdd;
            mailMsg.ReplyTo = replyto;
            mailMsg.To.Add(tomail);
            mailMsg.Bcc.Add("mail@dhitsolutions.org");
            mailMsg.IsBodyHtml = true;
            mailMsg.Subject = "Greetings from dhitsolutions, Your Order Status : " + orderstatus;
            mailMsg.Body = content;
            // SmtpClient smtp = new SmtpClient();
            // smtp.Send(mailMsg);
            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("mail@dhitsolutions.org", "12345");
            smtp.Send(mailMsg);
        }
        catch (Exception ex)
        {
            //lblMsg.Text = ex.Message;
        }
    }
}