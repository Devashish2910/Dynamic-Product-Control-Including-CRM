using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_ManageNewsletter : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblDeleteMsg.Text = "";
        lblMsg.Text = "";

        if (!IsPostBack)
        {
            if (!Utils.IsLoggedIn())
            {
                Utils.LogOut();
            }
            else
            {
                Label lblFormTitle = (Label)this.Master.FindControl("lblFormTitle");
                lblFormTitle.Text = "Create Newsletter";
                BindNewsletter();
            }
        }

    }
    public void clearall()
    {
        cls.ResetFormControlValues(this.Page);
        lblId.Text = "";
        txtDescription.Text = "";
    }
    protected void BindNewsletter()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_Newsletter");
        rptr.DataSource = dt;
        rptr.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblId.Text))
        {

            cls.ExecuteDA("Insert_Newsletter", new SqlParameter("@Title", txtTitle.Text),
                                                 new SqlParameter("@Desc", txtDescription.Text));

            clearall();
            lblMsg.Text = "Details inserted successfully.";
            BindNewsletter();

        }
        else
        {


            cls.ExecuteDA("Update_Newsletter", new SqlParameter("@NewsletterID", lblId.Text),
                                        new SqlParameter("@Title", txtTitle.Text),
                                        new SqlParameter("@Desc", txtDescription.Text));

            clearall();
            lblMsg.Text = "Details Updated Successfully";
            BindNewsletter();

        }
    }
    protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditGroup")
        {
            DataSet ds = new DataSet();
            ds = cls.ReturnDataSet("sp_RetriveDataWithField",
                                         new SqlParameter("@Fields", "*"),
                                        new SqlParameter("@TblNm", "Newsletter"),
                                   new SqlParameter("@WhereClause", "FAQ where NewsletterID ='" + e.CommandArgument + "' and IsActive = 1"));
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();
                txtTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["Desc"].ToString();

            }
        }
        if (e.CommandName == "DeleteGroup")
        {
            cls.ExecuteDA("Delete_Newsletter", new SqlParameter("@NewsletterID", e.CommandArgument));
            clearall();
            lblMsg.Text = "Record Deleted Sucessfully";
            BindNewsletter();
        }
    }
}