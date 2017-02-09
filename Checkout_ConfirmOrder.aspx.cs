using System;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;
public partial class Checkout_ConfirmOrder : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    clsAddToCart clsCart;
    BillingShippingDetails clsBSD;
    StringBuilder strMailHtml;
    double MaxCOD = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMenuCategory();
            BindTopCartItems();
            //lblMinAmt.Text = getCODLimit().ToString("N2");
            BindOrderSummary();
            BindShippingSummary();
        }
        SetLoginPanel();
        setValueForccAvenue();
        btnPay.Attributes.Add("onclick", "noPostBack('t.aspx');");
    }
    protected double getCODLimit()
    {
        MaxCOD = (double)cls.ReturnScaler("Select_CODLimit");
        return MaxCOD;
    }
    protected void BindOrderSummary()
    {
        clsCart = new clsAddToCart();
        lblTotalItems.Text = clsCart.TotalItems().ToString();
        lblTotalAmount.Text = "Rs. " + Math.Round(clsCart.TotalPrice()).ToString();
        lblFinalAmount1.Text = "Rs. " + Math.Round(clsCart.TotalPrice()).ToString();
    }

    protected void BindShippingSummary()
    {
        clsBSD = new BillingShippingDetails();
        rptShipping.DataSource = clsBSD.BindBillShip();
        rptShipping.DataBind();
    }
    protected void BindMenuCategory()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("Select_CategoryForMenu");
        rptMenuCategory.DataSource = ds;
        rptMenuCategory.DataBind();

        rptrCatFooter.DataSource = ds;
        rptrCatFooter.DataBind();
    }
    protected void rptMenuCategory_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Label lblid = (Label)e.Item.FindControl("lblCatID");
        Repeater rptsubcat = (Repeater)e.Item.FindControl("rptMenuSubCategory");

        if (lblid != null)
        {
            DataSet dset = new DataSet();
            dset = cls.ReturnDataSet("Select_SubCategoryForMenu", new SqlParameter("@ID", lblid.Text));
            rptsubcat.DataSource = dset;
            rptsubcat.DataBind();
        }
    }
    protected void BindTopCartItems()
    {
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text != "")
        {
            Response.Redirect("SearchResult.aspx?Srch=" + txtSearch.Text + "");
        }
        else
        {
            MsgBox("Please enter keywords you want to search.");
        }
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
    private void MailAdminInquiry()
    {
        strMailHtml = new StringBuilder();
        string adminmail = "";

        strMailHtml.Append("<html>");
        strMailHtml.Append("<head>");
        strMailHtml.Append("    <title></title>");
        strMailHtml.Append("</head>");
        strMailHtml.Append("<body>");
        strMailHtml.Append("    <table width='100%' border='0' align='left' cellpadding='2' cellspacing='2' style='border: 1px solid #ff4f12;'>");
        strMailHtml.Append("        <tbody>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' height='70' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial; border-bottom: 1px solid #ff4f12'>");
        strMailHtml.Append("                    <img border='0' colspan='2' src='http://timeoffice.in/images/logo.png' alt='timeoffice'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='30' align='left' valign='middle' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial'>");
        strMailHtml.Append("                    Dear Administrator,");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("                <td height='25' align='right' valign='middle' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial'>");
        strMailHtml.Append("                    ");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='30' colspan='2' align='left' valign='middle' s style='font-size: 12px;");
        strMailHtml.Append("                    font-weight: bold; color: #ff4f12; text-decoration: none; font-family: Arial;'>");
        strMailHtml.Append("                   Feedback Details");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>            ");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='' style='font-size: 12px; text-decoration: none; font-family: Arial'>");
        strMailHtml.Append("                    <table width='50%' cellpadding='0' cellspacing='0'>");
        strMailHtml.Append("                  <tbody>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' colspan='' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Name");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    " + txtName.Text + "");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Email");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:" + txtEmail.Text + "'>");
        strMailHtml.Append("                                        " + txtEmail.Text + "</a>");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Category");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    " + drpCategory.SelectedItem.Text + "");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Details");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    " + txtMessage.Text + "");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                        </tbody>");
        strMailHtml.Append("                    </table>");
        strMailHtml.Append("              </td>                ");
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
        strMailHtml.Append("                    Time Office<br>");
        strMailHtml.Append("                    Address - 390001<br />");
        strMailHtml.Append("                     <u>Phone</u> : +91 (0) 225 6789034");
        strMailHtml.Append("                    <br>");
        strMailHtml.Append("                    <u>Email</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:support@timeoffice.in'>");
        strMailHtml.Append("                        support@timeoffice.in</a> <u>Web</u> : <a target='_blank' style='text-decoration: none;");
        strMailHtml.Append("                            color: #ff4f12' href='http://www.timeoffice.in'>www.timeoffice.in</a>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>            ");
        strMailHtml.Append("        </tbody>");
        strMailHtml.Append("    </table>");
        strMailHtml.Append("</body>");
        strMailHtml.Append("</html>");

        adminmail = strMailHtml.ToString();
        try
        {
            MailMessage mailMsg1 = new MailMessage();
            MailAddress fromadd = new MailAddress("support@timeoffice.in");
            MailAddress repadd = new MailAddress(txtEmail.Text);
            mailMsg1.From = fromadd;
            mailMsg1.To.Add("support@timeoffice.in");
            mailMsg1.ReplyTo = repadd;
            mailMsg1.Bcc.Add("a@yourcompany.in");
            mailMsg1.Bcc.Add("b@yourcompany.in");
            mailMsg1.IsBodyHtml = true;
            //'mailMsg1.Priority = MailPriority.High
            mailMsg1.Subject = "Feedback Details - Timeoffice";
            mailMsg1.Body = adminmail.ToString();
            // SmtpClient smtp = new SmtpClient();          
            //smtp.Send(mailMsg1);

            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("support@timeoffice.in", "fadfadf");
            smtp.Send(mailMsg1);
        }
        catch (Exception ex)
        {
            MsgBox(ex.Message);
        }
    }
    private void MailUserInquiry()
    {
        strMailHtml = new StringBuilder();
        string usermail = null;

        strMailHtml.Append("<html'>");
        strMailHtml.Append("<head>");
        strMailHtml.Append("    <title></title>");
        strMailHtml.Append("</head>");
        strMailHtml.Append("<body>");
        strMailHtml.Append("    <table width='100%' border='0' align='left' cellpadding='2' cellspacing='2' style='border: 1px solid #ff4f12;'>");
        strMailHtml.Append("        <tbody>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' height='70' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial; border-bottom: 1px solid #ff4f12'>");
        strMailHtml.Append("                    <img border='0'  src='http://timeoffice.in/images/logo.png' alt='Timeoffice'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td style='padding-top: 10px; font-size: 12px; text-decoration: none; font-family: Arial'>");
        strMailHtml.Append("                    Dear " + txtName.Text + ",");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td style='padding-top: 10px; font-size: 12px; text-decoration: none; font-family: Arial'>");
        strMailHtml.Append("                    Thank you for Feedback us. We will get back soon.");
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
        strMailHtml.Append("                    Timeoffice<br>");
        strMailHtml.Append("                    address-390001<br />");
        strMailHtml.Append("                    <u>Phone</u> : +91 (0) 225 6534432");
        strMailHtml.Append("                    <br>");
        strMailHtml.Append("                    <u>Email</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:support@timeoffice.in'>");
        strMailHtml.Append("                        support@timeoffice.in</a> <u>Web</u> : <a target='_blank' style='text-decoration: none;");
        strMailHtml.Append("                            color: #ff4f12' href='http://www.timeoffice.in'>www.timeoffice.in</a>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("        </tbody>");
        strMailHtml.Append("    </table>");
        strMailHtml.Append("</body>");
        strMailHtml.Append("</html>");


        usermail = strMailHtml.ToString();
        try
        {
            MailMessage mailMsg1 = new MailMessage();
            MailAddress fromadd = new MailAddress("support@timeoffice.in");
            mailMsg1.From = fromadd;
            mailMsg1.To.Add(txtEmail.Text);
            mailMsg1.Bcc.Add("a@abc.in");
            mailMsg1.Bcc.Add("a!abc.in");
            mailMsg1.IsBodyHtml = true;
            mailMsg1.Subject = "Feedback Details - timeoffice";
            mailMsg1.Body = usermail.ToString();
            // SmtpClient smtp = new SmtpClient();           
            // smtp.Send(mailMsg1);

            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("support@timeoffice.in", "reqrqe");
            smtp.Send(mailMsg1);
        }
        catch (Exception ex)
        {
            MsgBox(ex.Message);
        }
    }
    protected void btnFeedbackSubmit_Click(object sender, EventArgs e)
    {
        MailAdminInquiry();
        MailUserInquiry();
        MsgBox("Your feedback has been send successfully");
        clearall();
    }
    public void clearall()
    {
        txtName.Text = "";
        txtEmail.Text = "";
        txtMessage.Text = "";
        drpCategory.SelectedIndex = 0;
    }
    protected void SetLoginPanel()
    {
        if (Session["MemberInfo"] == null)
        {
            pnlLogOff.Visible = true;
            pnlLogin.Visible = false;
        }
        else
        {
            pnlLogin.Visible = true;
            pnlLogOff.Visible = false;

            DataTable dtMember = new DataTable();
            dtMember = (DataTable)Session["MemberInfo"];

            if (dtMember.Rows[0]["Name"].ToString() != "")
            {
                lblUser.Text = "Welcome " + dtMember.Rows[0]["Name"].ToString() + ",";
            }
            else
            {
                pnlLogOff.Visible = true;
                pnlLogin.Visible = false;
            }
        }
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session["MemberInfo"] = null;
        Session["loginusing"] = null;
        SetLoginPanel();
        Response.Redirect("Default.aspx");
    }

    protected void setValueForccAvenue()
    {
        // seting ordersummary

        clsCart = new clsAddToCart();

        order_id.Value = Session["PayOrderId"].ToString();
        amount.Value = clsCart.TotalPrice().ToString();

        // seting bilingshiping info
        clsBSD = new BillingShippingDetails();
        DataTable dtBillingShipping = new DataTable();
        dtBillingShipping = clsBSD.BindBillShip();

        if (dtBillingShipping.Rows.Count > 0)
        {
            //billing_name.Value = dtBillingShipping.Rows[0]["Company"].ToString();
            billing_name.Value = dtBillingShipping.Rows[0]["SName"].ToString();
            billing_address.Value = dtBillingShipping.Rows[0]["Address1"].ToString();
            billing_zip.Value = dtBillingShipping.Rows[0]["Zipcode"].ToString();
            billing_city.Value = dtBillingShipping.Rows[0]["City"].ToString();
            billing_state.Value = dtBillingShipping.Rows[0]["State"].ToString();
            billing_country.Value = dtBillingShipping.Rows[0]["Country"].ToString();
            billing_tel.Value = dtBillingShipping.Rows[0]["Contact"].ToString();
            billing_email.Value = dtBillingShipping.Rows[0]["SEmail"].ToString();

            delivery_name.Value = dtBillingShipping.Rows[0]["SName"].ToString();
            delivery_address.Value = dtBillingShipping.Rows[0]["SAddress1"].ToString();
            delivery_zip.Value = dtBillingShipping.Rows[0]["SZipcode"].ToString();
            delivery_city.Value = dtBillingShipping.Rows[0]["SCity"].ToString();
            delivery_state.Value = dtBillingShipping.Rows[0]["SState"].ToString();
            delivery_country.Value = dtBillingShipping.Rows[0]["SCountry"].ToString();
            delivery_tel.Value = dtBillingShipping.Rows[0]["SContact"].ToString();

            //merchant_param1.Value = dtBillingShipping.Rows[0]["Name"].ToString();
            //merchant_param2.Value = dtBillingShipping.Rows[0]["Email"].ToString();
            merchant_param1.Value = "";
            merchant_param2.Value = "";
        }
    }
}