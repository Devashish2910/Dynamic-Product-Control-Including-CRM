using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Admin_AdminMaster : System.Web.UI.MasterPage
{
    Clsconnection cls = new Clsconnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {           
            if (!Utils.IsLoggedIn())
            {
                Utils.LogOut();
            }
            else
            {
                lblUsername.Text = "Hello, " + Session["LoggedInUserName"];
               
            }
        }
    }
    protected void Logout_Click(object sender, EventArgs e)
    {
        Session["LoggedInUserName"] = null;
        Utils.LogOut();
    } 
}
