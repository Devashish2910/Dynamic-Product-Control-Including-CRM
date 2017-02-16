using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;

/// <summary>
/// Summary description for sendmail
/// </summary>
public class sendmail
{
	public sendmail()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void send(String subject, String body)
    {
        SmtpClient client = new SmtpClient();
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.EnableSsl = true;
        client.Host = "smtp.gmail.com";
        client.Port = 25;
        // setup Smtp authentication
        System.Net.NetworkCredential credentials =
       new System.Net.NetworkCredential("dhitsolutions2014@gmail.com", "xyjpuszsmbhlujji");
        client.UseDefaultCredentials = false;
        client.Credentials = credentials;

        MailMessage msg = new MailMessage();
        msg.From = new MailAddress("dhitsolutions2014@gmail.com");
        msg.To.Add(new MailAddress("diptej.thakkar@gmail.com"));
        //msg.To.Add(new MailAddress("zalakpdave@gmail.com"));

        msg.Subject = subject;
        msg.IsBodyHtml = true;
        msg.Body = string.Format(body);

        try
        {
            client.Send(msg);
        }
        catch (Exception ex)
        {

        }

    }
    public void replaytocustomer(String toemail, String subject, String body)
    {
        SmtpClient client = new SmtpClient();
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.EnableSsl = true;
        client.Host = "smtp.gmail.com";
        client.Port = 25;
        // setup Smtp authentication
        System.Net.NetworkCredential credentials =
           new System.Net.NetworkCredential("dhitsolutions2014@gmail.com", "xyjpuszsmbhlujji");
        client.UseDefaultCredentials = false;
        client.Credentials = credentials;

        MailMessage msg = new MailMessage();
        msg.From = new MailAddress("dhitsolutions2014@gmail.com");
        msg.To.Add(new MailAddress(Convert.ToString(toemail)));

        msg.Subject = subject;
        msg.IsBodyHtml = true;
        msg.Body = string.Format(body);
        try
        {
            client.Send(msg);
        }
        catch (Exception ex)
        {
        }

    }
}