using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Configuration;

public partial class Admin_CourierMaster : System.Web.UI.Page
{
    Clsconnection clscon = new Clsconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Utils.IsLoggedIn())
        {
            Utils.LogOut();
        }
        else
        {
            Label lblFormTitle = (Label)this.Master.FindControl("lblFormTitle");
            lblFormTitle.Text = "Courier Type";
            BindData();
        }
    }

    protected void BindData()
    {
        DataTable dt1 = new DataTable();
        dt1 = clscon.ReturnDataTable("Select_CourierMaster");
        rptr.DataSource = dt1;
        rptr.DataBind();
    }
    protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            lblMsg.Text = "";
            DataSet dset = new DataSet();
            dset = clscon.ReturnDataSet("RetriveData", new SqlParameter("TblNm", "CourierMaster"), new SqlParameter("strwhereclause", "where ID = " + e.CommandArgument + " "));
            if (dset.Tables[0].Rows.Count > 0)
            {
                DataRow dRow = null;
                foreach (DataRow dRow_loopVariable in dset.Tables[0].Rows)
                {
                    dRow = dRow_loopVariable;
                    txtCourierName.Text = dRow["CourierName"].ToString();
                    txtUrl.Text = dRow["Url"].ToString();
                    lblId.Text = e.CommandArgument.ToString();
                }
            }
        }
        else if (e.CommandName == "Delete")
        {
            clscon.ExecuteDA("Delete_CourierMaster", new SqlParameter("@ID", e.CommandArgument.ToString()));
            BindData();
            lblMsg.Text = "Record deleted successfully.";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblId.Text))
        {
            if (clscon.CheckExistField("CheckExistField", "CourierMaster", "CourierName", txtCourierName.Text, "and IsActive = 1"))
            {
                lblMsg.Text = "This Courier Name  Already exists.";
                return;
            }
            else
            {
                clscon.ExecuteDA("Insert_CourierMaster", new SqlParameter("@CourierName", txtCourierName.Text),
                new SqlParameter("@Url", txtUrl.Text));

                lblMsg.Text = "Details inserted successfully.";
                BindData();
                clearall();
            }
        }
        else
        {
            if (clscon.CheckExistField("CheckExistField", "CourierMaster", "CourierName", txtCourierName.Text, "and IsActive = 1 and  ID <> '" + lblId.Text + "'"))
            {
                lblMsg.Text = "This Courier Name  Already exists.";
                return;
            }
            else
            {
                clscon.ExecuteDA("Update_CourierMaster", new SqlParameter("@ID", lblId.Text),
                 new SqlParameter("@CourierName", txtCourierName.Text),
                 new SqlParameter("@Url", txtUrl.Text));
                lblMsg.Text = "Details updated successfully.";
                BindData();
                clearall();
            }
        }
    }
    protected void clearall()
    {
        lblId.Text = "";
        txtCourierName.Text = "";
        txtUrl.Text = "";

    }

}
   
   