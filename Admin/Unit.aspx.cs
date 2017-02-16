using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Admin_Unit : System.Web.UI.Page
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
                lblFormTitle.Text = "Product Unit SetUp";
                BindUnit();
            }            
        }
    }
    public void clearall()
    {
        cls.ResetFormControlValues(this.Page);
        lblId.Text = "";
    }
    private void BindUnit()
    {
        DataSet ds = new DataSet();

        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "Unit"),
           new SqlParameter("@strWhereClause", "where IsActive = 1 Order By Id asc"));
        rptr.DataSource = ds;
        rptr.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblId.Text))
        {
            if (cls.CheckExistField("CheckExistField", "Unit", "Unit", txtUnit.Text.Trim(), "and IsActive = 1"))
            {
                lblMsg.Text = "This Unit already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Insert_Unit", new SqlParameter("@Unit", txtUnit.Text),
                                                          new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Details inserted successfully.";
                BindUnit();
            }
        }
        else
        {
            if (cls.CheckExistField("CheckExistField", "Unit", "Unit", txtUnit.Text.Trim(), " and Id <> " + lblId.Text + " and IsActive = 1"))
            {
                lblMsg.Text = "This Unit already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Update_Unit", new SqlParameter("@Id", lblId.Text),
                                                       new SqlParameter("@Unit", txtUnit.Text),
                                                       new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Details updated successfully.";
                BindUnit();
            }
        }
    }
    protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditGroup")
        {
            DataSet ds = new DataSet();
            ds = cls.ReturnDataSet("sp_RetriveDataWithField",
                 new SqlParameter("@Fields", "*"),
                new SqlParameter("@TblNm", "Unit"),
           new SqlParameter("@WhereClause", "Unit where Id ='" + e.CommandArgument + "' and Unit.IsActive = 1"));

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();
                txtUnit.Text = ds.Tables[0].Rows[0]["Unit"].ToString();
            }

        }
        if (e.CommandName == "DeleteGroup")
        {
            if (cls.CheckExistField("CheckExistField", "Product", "UnitId", e.CommandArgument.ToString(), "and IsActive = 1"))
            {
                lblMsg.Text = "This Unit exists in Product. First delete products related to this Unit.";
                return;
            }
            else
            {
                cls.ExecuteDA("DeleteRecord", new SqlParameter("@TblNm", "Unit"),
                                      new SqlParameter("@strField", "Id"),
                                      new SqlParameter("@strValue", e.CommandArgument.ToString()));
                clearall();
                lblMsg.Text = "Product Unit Deleted";
                BindUnit();
            }
        }
    }
}