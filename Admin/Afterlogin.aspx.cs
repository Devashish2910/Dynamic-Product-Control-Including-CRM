using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_Afterlogin : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    Class1 cl = new Class1();
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
                lblFormTitle.Text = "Dashboard";
                lblName.Text = "Welcome&nbsp;" + Session["LoggedInUserName"] + "..!!";
                //BindSearch();
            }
        }
    }

    //private void BindSearch()
    //{
    //    DataTable ds = new DataTable();
    //    ds=cl.getdataset("select searchtag,COUNT(searchtag) as frequency from Search group by searchtag order by COUNT (searchtag) desc");

    //    GridView1.DataSource = ds;
    //    GridView1.DataBind();
    //}
}