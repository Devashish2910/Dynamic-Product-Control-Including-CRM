using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


public partial class Admin_Category : System.Web.UI.Page
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
                lblFormTitle.Text = "Product Category Setup";
                BindCategory();
            }
        }
    }
    public void clearall()
    {
        cls.ResetFormControlValues(this.Page);
        lblId.Text = "";
    }
    private void BindCategory()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "ProductCategory"),
           new SqlParameter("@strWhereClause", "where IsActive = 1 Order By Id asc"));
        rptr.DataSource = ds;
        rptr.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblId.Text))
        {
            lblMsg.Text = "You cannot insert new category, please update the category name.";
        }
        else
        {
            if (cls.CheckExistField("CheckExistField", "ProductCategory", "CategoryName", txtCategoryName.Text, "and Id <> " + lblId.Text + " and IsActive = 1"))
            {
                lblMsg.Text = "This Category already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Update_ProductCategory", new SqlParameter("@Id", lblId.Text),
                                                       new SqlParameter("@CategoryName", txtCategoryName.Text),
                                                        new SqlParameter("@IsActive", 1));
                clearall();
                lblMsg.Text = "Details updated successfully.";
                BindCategory();
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
                new SqlParameter("@TblNm", "ProductCategory"),
           new SqlParameter("@WhereClause", "ProductCategory where Id ='" + e.CommandArgument + "' and ProductCategory.IsActive = 1"));
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();
                txtCategoryName.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
            }
        }
    }
}