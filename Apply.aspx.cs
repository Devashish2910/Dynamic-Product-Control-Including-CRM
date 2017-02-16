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

public partial class Apply : System.Web.UI.Page
{
    StringBuilder strMailHtml;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Des"] != null)
        {
            lblDesignation.Text = Request.QueryString["Des"].ToString();
        }
        else
        {
            Response.Redirect("Career.apsx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (FUResume.PostedFile != null
              && FUResume.PostedFile.ContentLength > 0)
        {
            MailAdminInquiry();
            MailUserInquiry();
            ShowMessageThenRedirectTo("Resume submitted successfully", "Career");
        }
        else
        {
            MsgBox("Please Upload Resume");
            return;
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
        strMailHtml.Append("                    <img border='0' colspan='2' src='http://timeoffice.in/images/logo.png' alt='Chiptronics'>");
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
        strMailHtml.Append("                   Application Details");
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
        strMailHtml.Append("                                    <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:" + txtEmailId.Text + "'>");
        strMailHtml.Append("                                        " + txtEmailId.Text + "</a>");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Phone");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    " + txtPhone.Text + "");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-   family: Arial'>");
        strMailHtml.Append("                                    Current Employee");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    " + txtCurrentEmp.Text + "");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Past Employee");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    " + txtPastEmployee.Text + "");
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
        strMailHtml.Append("                    Chiptronics<br>");
        strMailHtml.Append("                    vadodara<br />");
        strMailHtml.Append("                     <u>abc</u> : +91 (0) 265 xxxxxx");
        strMailHtml.Append("                    <br>");
        strMailHtml.Append("                    <u>Email</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:a@abc.com'>");
        strMailHtml.Append("                        info@abc.com</a> <u>Web</u> : <a target='_blank' style='text-decoration: none;");
        strMailHtml.Append("                            color: #ff4f12' href='http://www.abc.com'>www.abc.com</a>");
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
            MailAddress fromadd = new MailAddress("info@abc.com");
            MailAddress repadd = new MailAddress(txtEmailId.Text);
            mailMsg1.From = fromadd;
            mailMsg1.To.Add("info@abc.com");
           
            mailMsg1.ReplyTo = repadd;
            mailMsg1.Bcc.Add("abc@abc.net");
            mailMsg1.Bcc.Add("abc@abc.net");
            mailMsg1.IsBodyHtml = true;
            //'mailMsg1.Priority = MailPriority.High
            mailMsg1.Subject = "companyname - Application for the post of " + Request.QueryString["Des"].ToString();
            mailMsg1.Body = adminmail.ToString();

            //START ATTACHMENT CODE
            if (FUResume.PostedFile != null
               && FUResume.PostedFile.ContentLength > 0)
            {
                //Build an array with the file path, so we can get the file name later.
                string[] strAttachname = FUResume.PostedFile.FileName.Split('\\');

                //Create a new attachment object from the posted data and the file name
                Attachment mailAttach = new Attachment(
                   FUResume.PostedFile.InputStream,  //Data posted from form
                   strAttachname[strAttachname.Length - 1] //Filename (from end of our array)
                );

                //Add the attachment to our mail object
                mailMsg1.Attachments.Add(mailAttach);
            }
            else
            {
                MsgBox("Please Upload Resume");
                return;
            }
            //END ATTACHMENT CODE

            // SmtpClient smtp = new SmtpClient();          
            //smtp.Send(mailMsg1);

            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("abc@abc.com", "23454");
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
        strMailHtml.Append("                    <img border='0' colspan='2' src='http://companyname.in/images/logo.png' alt='Chiptronics'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td style='padding-top: 10px; font-size: 12px; text-decoration: none; font-family: Arial'>");
        strMailHtml.Append("                    Dear " + txtName.Text + ",");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td style='padding-top: 10px; font-size: 12px; text-decoration: none; font-family: Arial'>");
        strMailHtml.Append("                    Thank you for Applying us. We will get back soon.");
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
        strMailHtml.Append("                    companyname<br>");
        strMailHtml.Append("                    address<br />");
        strMailHtml.Append("                    <u>Phone</u> : +91 (0) call no");
        strMailHtml.Append("                    <br>");
        strMailHtml.Append("                    <u>Email</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:info@abc.com'>");
        strMailHtml.Append("                        info@abc.com</a> <u>Web</u> : <a target='_blank' style='text-decoration: none;");
        strMailHtml.Append("                            color: #ff4f12' href='http://www.abc.com'>www.abc.com</a>");
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
            MailAddress fromadd = new MailAddress("abc@companyname.com");
            mailMsg1.From = fromadd;
            mailMsg1.To.Add(txtEmailId.Text);
            mailMsg1.Bcc.Add("a@companyname.com");
            mailMsg1.Bcc.Add("a@company.com");
            mailMsg1.IsBodyHtml = true;
            mailMsg1.Subject = "companyname - Carrer";
            mailMsg1.Body = usermail.ToString();
            // SmtpClient smtp = new SmtpClient();           
            // smtp.Send(mailMsg1);

            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("a@companyname.com", "12345");
           smtp.Send(mailMsg1);
        }
        catch (Exception ex)
        {
            MsgBox(ex.Message);
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