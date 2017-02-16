using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_Supplier : System.Web.UI.Page
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
                lblFormTitle.Text = "Supplier SetUp";

                BindSupplier();
            }          
        }
    }
    public void clearall()
    {
        cls.ResetFormControlValues(this.Page);
        lblId.Text = "";
    }
    private void BindSupplier()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "Supplier"),
           new SqlParameter("@strWhereClause", "where IsActive = 1 Order By Id asc"));

        rptr.DataSource = ds;
        rptr.DataBind();

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblId.Text))
        {
            if (cls.CheckExistField("CheckExistField", "Supplier", "SupplierName", txtsuppliername.Text.Trim(), "and IsActive = 1"))
            {
                lblMsg.Text = "This Supplier already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Insert_Supplier", new SqlParameter("@SupplierCode", txtSuppliercode.Text),
                    new SqlParameter("@SupplierName", txtsuppliername.Text),
                    new SqlParameter("@Address", txtsupplieradd.Text),
                    new SqlParameter("@ContactNo", txtcontactno.Text),
                    new SqlParameter("@Email", txtEmailId.Text),
                    new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Details inserted successfully.";
                BindSupplier();
            }
        }
        else
        {
            if (cls.CheckExistField("CheckExistField", "Supplier", "SupplierName", txtsuppliername.Text.Trim(), "and Id<>" + lblId.Text + "  and IsActive = 1"))
            {
                lblMsg.Text = "This Supplier already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Update_Supplier", new SqlParameter("@Id", lblId.Text),
                    new SqlParameter("@SupplierCode", txtSuppliercode.Text),
                    new SqlParameter("@SupplierName", txtsuppliername.Text),
                    new SqlParameter("@Address", txtsupplieradd.Text),
                    new SqlParameter("@ContactNo", txtcontactno.Text),
                    new SqlParameter("@Email", txtEmailId.Text),
                    new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Details updated successfully.";
                BindSupplier();
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
                new SqlParameter("@TblNm", "Supplier"),
           new SqlParameter("@WhereClause", "Supplier where Id ='" + e.CommandArgument + "' and Supplier.IsActive = 1"));

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();
                txtSuppliercode.Text = ds.Tables[0].Rows[0]["SupplierCode"].ToString();
                txtsuppliername.Text = ds.Tables[0].Rows[0]["SupplierName"].ToString();
                txtsupplieradd.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtcontactno.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                txtEmailId.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            }
        }
        if (e.CommandName == "DeleteGroup")
        {
            if (cls.CheckExistField("CheckExistField", "Product", "SupplierId", e.CommandArgument.ToString(), "and IsActive = 1"))
            {
                lblMsg.Text = "This Supplier exists in Product. First delete products related to this Supplier.";
                return;
            }
            else
            {
                cls.ExecuteDA("DeleteRecord", new SqlParameter("@TblNm", "Supplier"),
                                       new SqlParameter("@strField", "Id"),
                                       new SqlParameter("@strValue", e.CommandArgument.ToString()));

                clearall();
                lblMsg.Text = "Supplier Deleted";
                BindSupplier();
            }
        }
    }
}