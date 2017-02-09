using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.UI.HtmlControls;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

using System.Collections;
using System.Collections.Specialized;
using CCA.Util;

public partial class PaymentSuccessOnline : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    string trackingid = "";
    clsAddToCart clsCart;
    BillingShippingDetails clsBSD;
    string orderid = "";
    string email = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // getOnlinePaymentValues();
        }
    }

    //protected void getOnlinePaymentValues()
    //{
    //    string workingKey = "13231312123233212323322331";//put in the 32bit alpha numeric key in the quotes provided here
    //    CCACrypto ccaCrypto = new CCACrypto();
    //    string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
    //    NameValueCollection Params = new NameValueCollection();
    //    string[] segments = encResponse.Split('&');
    //    foreach (string seg in segments)
    //    {
    //        string[] parts = seg.Split('=');
    //        if (parts.Length > 0)
    //        {
    //            string Key = parts[0].Trim();
    //            string Value = parts[1].Trim();
    //            Params.Add(Key, Value);
              
    //        }
    //    }

    //    //for (int i = 0; i < Params.Count; i++)
    //    //{
    //    //     Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
    //    //}
      
    //    if (Params[3].ToString() == "Success")
    //    {
    //        // insert into db
    //        orderid = Params[0].ToString();
    //        trackingid = Params[1].ToString();
    //        email = Params[18].ToString();
    //        UpdateIntoDB(trackingid);
    //        lblOredrId.Text = orderid.ToString();
    //        RemoveSession();
    //        BindTopCartItems();
    //        pnlSuccess.Visible = true;
    //    }
    //    else if (Params[3].ToString() == "Aborted")
    //    {
    //        ShowMessageThenRedirectTo("Transaction Aborted", "default");
    //    }
    //    else
    //    {
    //        ShowMessageThenRedirectTo("Transaction Failure", "default");
    //    }
    //}

    //protected void getOnlinePaymentValuesTest()
    //{
       
    //        // insert into db
    //        orderid = "100050";
    //        trackingid = "";
    //        email ="parita@xyz.net";
    //        UpdateIntoDB(trackingid);
    //        lblOredrId.Text = orderid.ToString();
    //        RemoveSession();
    //        BindTopCartItems();
    //        pnlSuccess.Visible = true;
        
    //}

    protected void UpdateIntoDB(string trackid)
    {
        //update invoice master
        cls.ExecuteDA("Update_InvoiceMasterForOnlinePay", new SqlParameter("@OrderId", orderid),
                                                          new SqlParameter("@PaypalId", trackid));

        string filname = Server.MapPath("OrderPdf/" + "TSM_Order_" + orderid + ".pdf");

        Mail(orderid, filname, email);
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
    protected void RemoveSession()
    {
        clsCart = new clsAddToCart();
        clsCart.RemoveFromSession();

        clsBSD = new BillingShippingDetails();
        clsBSD.RemoveFromSession();

        Session.Remove("PayMode");
        Session.Remove("PaypalId");
        Session.Remove("PaySuccess");
        Session.Remove("PayOrderId");
        if (Session["CameFrom"] != null)
        {
            Session.Remove("CameFrom");
        }
        Session.Remove("CameAgain");
        if (Session["Discount"] != null)
        {
            Session.Remove("Discount");
            Session.Remove("CouponCode");
            Session.Remove("DiscountValue");
        }
        if (Session["captcha"] != null)
        {
            Session.Remove("captcha");
        }
        if (Session["captcha1"] != null)
        {
            Session.Remove("captcha1");
        }
        if (Session["captcha2"] != null)
        {
            Session.Remove("captcha2");
        }
        if (Session["RedirectTo"] != null)
        {
            Session.Remove("RedirectTo");
        }
        //Session.Remove("Msg");
    }
    protected void Mail(string orderid, string filename, string email)
    {
        StringBuilder strMailHtml = new StringBuilder();
        strMailHtml.Append("<html>");
        strMailHtml.Append("<head>");
        strMailHtml.Append("    <title></title>");
        strMailHtml.Append("</head>");
        strMailHtml.Append("<body>");
        strMailHtml.Append("    <table width='100%' border='0' align='left' cellpadding='2' cellspacing='2' style='border: 1px solid #ff4f12;'>");
        strMailHtml.Append("        <tbody>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' height='70' align='left' valign='top' style='font-size: 12px; text-decoration: none; font-family: Arial; border-bottom: 1px solid #ff4f12'>");
        strMailHtml.Append("                    <img border='0' src='http://xyz.com/images/logo.png' alt='xyz'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='30' align='left' valign='middle' style='font-size: 12px; font-weight: bold; color: #555555; text-decoration: none; font-family: Arial;'>Dear Customer,");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("                <td height='25' align='right' valign='middle' style='font-size: 12px; text-decoration: none; font-family: Arial'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='' style='font-size: 12px; text-decoration: none; font-family: Arial; line-height: 22px;'>Thank you for your order at <a target='_blank' style='text-decoration: none; color: #ff4f12'");
        strMailHtml.Append("                    href='http://www.xyz.com'>www.xyz.com</a>.<br />");
        strMailHtml.Append("                    Your order number is <span style='font-weight: bold; color: #555555; font-size: 14px;'>" + orderid.ToString() + "</span>.<br />");
        strMailHtml.Append("                    You can track order status by <a target='_blank' style='text-decoration: underline; color: #ff4f12'");
        strMailHtml.Append("                        href='http://www.xyz.com/TrackOrder.aspx'>clicking here</a>.<br />");
        strMailHtml.Append("                    For any order related query, contact us at <a target='_blank' style='text-decoration: none; color: #ff4f12'");
        strMailHtml.Append("                        href='mailto:support@xyz.com'>support@xyz.com</a> or<br />");
        strMailHtml.Append("                    Call us at <span style='font-weight: bold; color: #555555; font-size: 14px;'>1800 200 1619</span>.<br />");
        strMailHtml.Append("                    Your order details have been attached in this email.");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='25' colspan='2' align='left' valign='middle' style='font-size: 12px; font-weight: bold; color: #000000; text-decoration: none; font-family: Arial;'>Regards,");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' style='font-family: Arial; font-size: 11px; color: #000000; text-decoration: none; line-height: 22px; font-weight: bold'>xyz<br>");
        strMailHtml.Append("                    ADDRESS<br />");
        strMailHtml.Append("                    <u>Phone</u> : +DSd4544545412");
        strMailHtml.Append("                    <br>");
        strMailHtml.Append("                    <u>Email</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:support@xyz.com'>support@xyz.com</a> <u>Web</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12'");
        strMailHtml.Append("                        href='http://www.xyz.com'>www.xyz.com</a>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("        </tbody>");
        strMailHtml.Append("    </table>");
        strMailHtml.Append("</body>");
        strMailHtml.Append("</html>");

        String strAdmin = strMailHtml.ToString();

        try
        {
            MailMessage mailMsg = new MailMessage();
            MailAddress fromAdd = new MailAddress("order@xyz.com");
            MailAddress replyto = new MailAddress("order@xyz.com");
            mailMsg.From = fromAdd;
            mailMsg.ReplyTo = replyto;
            mailMsg.To.Add(email);
            mailMsg.Bcc.Add("A@XYZ.COM");
            mailMsg.Bcc.Add("order@xyz.com");
            mailMsg.IsBodyHtml = true;
            mailMsg.Subject = "xyz  Order Number : " + orderid.ToString();

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(filename);
            mailMsg.Attachments.Add(attachment);

            mailMsg.Body = strAdmin;
            // SmtpClient smtp = new SmtpClient();
            // smtp.Send(mailMsg);
            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("order@xyz.com", "ddss22445512");
            smtp.Send(mailMsg);
            attachment.Dispose();
        }
        catch (Exception ex)
        {

        }
        //try
        //{
        //    MailMessage mailMsg = new MailMessage();
        //    MailAddress fromAdd = new MailAddress("order@xyz.com");
        //    mailMsg.From = fromAdd;
        //    MailAddress replyto = new MailAddress(ViewState["ToMail"].ToString());
        //    mailMsg.To.Add("order@xyz.com");        
        //    mailMsg.Bcc.Add("s@xyz.com");
        //    mailMsg.IsBodyHtml = true;
        //    mailMsg.Subject = "xyz Mart Order Number : " + orderid;
        //    mailMsg.Body = strAdmin;
        //    //SmtpClient smtp = new SmtpClient();
        //    //smtp.Send(mailMsg);

        //    SmtpClient smtp = new SmtpClient();
        //    smtp.EnableSsl = true;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = new System.Net.NetworkCredential("order@xyz.com", "jee71237");
        //    smtp.Send(mailMsg);
        //}
        //catch (Exception ex)
        //{

        //}
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