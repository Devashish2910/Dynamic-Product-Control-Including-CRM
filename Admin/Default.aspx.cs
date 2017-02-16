using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class Admin_Default : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    sendmail send = new sendmail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtUsername.Focus();
            Panel1.Visible = false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        Utils.Login(txtUsername.Text, txtPassword.Text);

        if (Utils.CurrentUser().UserID == Guid.Empty)
        {
            lblMsg.Text = "<br>&nbsp;&nbsp;*Invalid Username or Password";
            txtUsername.Focus();
        }
        else
        {
            Session.Add("LoggedInUserName", Utils.CurrentLoggedInUser().ToString());
            Response.Redirect("~/admin/Afterlogin.aspx");
        }
    }

  
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=DEVASHISH-PC\\SQLEXPRESS;Initial Catalog=dhitecommerce;User ID=sa;Password=root");
        string str = "select * from Users where UserName='" + tb1.Text + "'";
        SqlCommand cmd = new SqlCommand(str, con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable Dt = new DataTable();
        sda.Fill(Dt);

        if (Dt.Rows.Count > 0)
        {
            send.send("Reset Password", "Your UserName is" + Dt.Rows[0][1].ToString() + "<br>Password is:" + Dt.Rows[0][2].ToString());
            lbl123.Text = "&nbsp;&nbsp;*Password Has been Sent";
            Panel1.Visible = false;
            
            
        }
        else
        {
            lbl123.Text = "&nbsp;&nbsp;*Invalid Login Id";
            Panel1.Visible = true;
        }

        
        
    }
}