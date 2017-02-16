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

public partial class Admin_PublishNewsletter : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblDeleteMsg.Text = "";

        if (!IsPostBack)
        {
            if (!Utils.IsLoggedIn())
            {
                Utils.LogOut();
            }
            else
            {
                Label lblFormTitle = (Label)this.Master.FindControl("lblFormTitle");
                lblFormTitle.Text = "Publish Newsletter";
                BindNewsletter();
                BindMembers();
            }
        }

    }

    protected void BindNewsletter()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_Newsletter");
        drpNewsletter.DataSource = dt;
        drpNewsletter.DataTextField = "Title";
        drpNewsletter.DataValueField = "NewsletterID";
        drpNewsletter.DataBind();

    }

    protected void BindMembers()
    {
        DataTable dtmembers = new DataTable();
        dtmembers = cls.ReturnDataTable("Select_Members");
        rptr.DataSource = dtmembers;
        rptr.DataBind();
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (checkMemberSelected())
        {
            lblMsg.Text = "";
            //publish newsletter
            string title = "";
            string content = "";
            //getting content from DB
            DataTable dtcontent = new DataTable();
            dtcontent = cls.ReturnDataTable("Select_NewsletterfromID", new SqlParameter("@ID", Convert.ToInt32(drpNewsletter.SelectedValue)));
            if (dtcontent.Rows.Count > 0)
            {
                title = dtcontent.Rows[0]["Title"].ToString();
                content = dtcontent.Rows[0]["Desc"].ToString();
            }

            //loop through selected members and send mail
            foreach (RepeaterItem ri in rptr.Items)
            {
                CheckBox chk = (CheckBox)ri.FindControl("chk");
                if (chk != null)
                {
                    if (chk.Checked == true)
                    {
                        Label lblEmail = (Label)ri.FindControl("lblEmail");
                        Label lblName = (Label)ri.FindControl("lblName");
                        MailNewsletter(title,content, lblName.Text, lblEmail.Text);
                    }
                }
            }
            lblMsg.Text = "Newsletter sent successfully.";

        }
        else
        {
            lblMsg.Text = "Select Member to publish newsletter";
        }
    }

    protected void chkAll_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)sender;
        bool flag;
        if (chkAll != null)
        {
            if (chkAll.Checked == true)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            foreach (RepeaterItem ri in rptr.Items)
            {
                CheckBox chk = (CheckBox)ri.FindControl("chk");
                if (chk != null)
                {
                    chk.Checked = flag;
                }
            }
        }
    }

    protected bool checkMemberSelected()
    {
        bool flag = false;
        foreach (RepeaterItem ri in rptr.Items)
        {
            CheckBox chk = (CheckBox)ri.FindControl("chk");
            if (chk != null)
            {
                if (chk.Checked == true)
                {
                    flag = true;
                }
            }
        }

        return flag;

    }

    protected void MailNewsletter(string title,string content, string name, string email)
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
        strMailHtml.Append("                <td colspan='2' height='70' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial; border-bottom: 1px solid #ff4f12'>");
        strMailHtml.Append("                    <img border='0' src='http://dhitsolutions/images/logo.png' alt='chiptronics'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");       
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' style='font-size: 12px; text-decoration: none; font-family: Arial; padding:20px; padding-bottom:20px;'>");
        strMailHtml.Append("                   "+ content.ToString() +"");
        strMailHtml.Append("              </td>                ");
        strMailHtml.Append("            </tr>");     
        strMailHtml.Append("        </tbody>");
        strMailHtml.Append("    </table>");
        strMailHtml.Append("</body>");
        strMailHtml.Append("</html>");


        String strAdmin = strMailHtml.ToString();
        try
        {
            MailMessage mailMsg = new MailMessage();
            MailAddress fromAdd = new MailAddress("mail@dhitsolutions.org");
            MailAddress replyto = new MailAddress("mail@dhitsolutions.org");
            mailMsg.From = fromAdd;
            mailMsg.ReplyTo = replyto;
            mailMsg.To.Add(email);
            mailMsg.Bcc.Add("mail@dhitsolutions.org");
            mailMsg.IsBodyHtml = true;
            mailMsg.Subject = title;
            mailMsg.Body = strAdmin;
            //SmtpClient smtp = new SmtpClient();
            // smtp.Send(mailMsg);

            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("mail@dhitsolutions.org", "12345");
            smtp.Send(mailMsg);   
        }
        catch (Exception ex)
        {

        }
    }
}