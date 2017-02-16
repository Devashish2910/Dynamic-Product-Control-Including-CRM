using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public partial class Admin_ManageCarrer : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
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
                lblFormTitle.Text = "Manage Carrer";
                BindCurrentOpenings();
            }
        }
    }
    protected void BindCurrentOpenings()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_AllCurrentOpenings");
        rptr.DataSource = dt;
        rptr.DataBind();
    }
    public void clearall()
    {
        cls.ResetFormControlValues(this.Page);
        lblId.Text = "";     
    }
    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblId.Text))
        {
            if (cls.CheckExistField("CheckExistField", "CurrentOpenings", "Designation", txtDesignation.Text, "and IsActive = 1 "))
            {
                lblMsg.Text = "This designation already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Insert_CurrentOpenings", new SqlParameter("@Designation", txtDesignation.Text),
                                                           new SqlParameter("@Position", txtPosition.Text),
                                                           new SqlParameter("@NoOfPosition", txtNoOfPosition.Text),
                                                           new SqlParameter("@Location", txtLocation.Text),
                                                           new SqlParameter("@DatePosted", DateTime.Now),
                                                           new SqlParameter("@Responsibilities", txtResponsiblities.Text),
                                                           new SqlParameter("@Requirements", txtRequirements.Text));

                lblMsg.Text = "Details inserted successfully.";
            }
        }
        else
        {
            if (cls.CheckExistField("CheckExistField", "CurrentOpenings", "Designation", txtDesignation.Text, "and IsActive = 1 and CurrentOpeningID != '" + lblId.Text + "'"))
            {
                lblMsg.Text = "This designation already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Update_CurrentOpenings", new SqlParameter("@CurrentOpeningID", lblId.Text),
                                                           new SqlParameter("@Designation", txtDesignation.Text),
                                                           new SqlParameter("@Position", txtPosition.Text),
                                                           new SqlParameter("@NoOfPosition", txtNoOfPosition.Text),
                                                           new SqlParameter("@Location", txtLocation.Text),
                                                           new SqlParameter("@DatePosted",DateTime.Now),
                                                           new SqlParameter("@Responsibilities", txtResponsiblities.Text),
                                                           new SqlParameter("@Requirements", txtRequirements.Text));

                lblMsg.Text = "Details updated successfully.";

            }
        }
        BindCurrentOpenings();
        clearall();
    }
    protected void rptr_OnItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            lblMsg.Text = "";
            DataSet dset = new DataSet();
            dset = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("TblNm", "CurrentOpenings"), new SqlParameter("strwhereclause", "where CurrentOpeningID = " + e.CommandArgument + " "));
            if (dset.Tables[0].Rows.Count > 0)
            {
                DataRow dRow = null;
                foreach (DataRow dRow_loopVariable in dset.Tables[0].Rows)
                {
                    dRow = dRow_loopVariable;
                    txtDesignation.Text = dRow["Designation"].ToString();
                    txtPosition.Text = dRow["Position"].ToString();
                    txtNoOfPosition.Text = dRow["NoOfPosition"].ToString();
                    txtLocation.Text = dRow["Location"].ToString();
                   // txtDatePosted.Text = dRow["DatePosted"].ToString();
                    txtRequirements.Text = dRow["Requirements"].ToString();
                    txtResponsiblities.Text = dRow["Responsibilities"].ToString();
                    lblId.Text = e.CommandArgument.ToString();

                }
            }
        }
        else if (e.CommandName == "Delete")
        {
            cls.ExecuteDA("Delete_CurrentOpenings", new SqlParameter("@CurrentOpeningID", e.CommandArgument.ToString()));
            BindCurrentOpenings();
            lblMsg.Text = "Record deleted successfully.";
        }
    }
}