using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_SizeSetup : System.Web.UI.Page
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
                lblFormTitle.Text = "Product Size Setup";
                BindSizeSetup();
            }
        }
    }
    public void clearall()
    {
        cls.ResetFormControlValues(this.Page);
        lblId.Text = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblId.Text))
        {
            if (cls.CheckExistField("CheckExistField", "SizeSetup", "SizeName", txtSizename.Text, "and IsActive = 1"))
            {
                lblMsg.Text = "This Size Name already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Insert_SizeSetup", new SqlParameter("@SizeName", txtSizename.Text),
                    new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Details inserted successfully.";
                BindSizeSetup();
            }
        }
        else
        {
            if (cls.CheckExistField("CheckExistField", "SizeSetup", "SizeName", txtSizename.Text, "and SizeId <> " + lblId.Text + " and IsActive = 1"))
            {
                lblMsg.Text = "This Size Name already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Update_SizeSetup", new SqlParameter("@SizeId", lblId.Text),
                    new SqlParameter("@SizeName", txtSizename.Text),
                    new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Details Updated Successfully";
                BindSizeSetup();
            }
        }
    }
    void BindSizeSetup()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "SizeSetup"),
           new SqlParameter("@strWhereClause", "where IsActive = 1 Order By SizeId asc"));
        rptr.DataSource = ds;
        rptr.DataBind();
    }
    protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditGroup")
        {
            DataSet ds = new DataSet();
            ds = cls.ReturnDataSet("sp_RetriveDataWithField",
                 new SqlParameter("@Fields", "*"),
                new SqlParameter("@TblNm", "SizeSetup"),
           new SqlParameter("@WhereClause", "SizeSetup where SizeId ='" + e.CommandArgument + "' and SizeSetup.IsActive = 1"));
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();
                txtSizename.Text = ds.Tables[0].Rows[0]["SizeName"].ToString();

            }
        }
        if (e.CommandName == "DeleteGroup")
        {
            if (cls.CheckExistField("CheckExistField", "ProductSize", "SizeId", e.CommandArgument.ToString(), "and IsActive = 1"))
            {
                lblMsg.Text = "This Size exists in Product. First delete products related to this Size.";
                return;
            }
            else
            {
                cls.ExecuteDA("DeleteRecord", new SqlParameter("@TblNm", "SizeSetup"),
                               new SqlParameter("@strField", "SizeId"),
                                 new SqlParameter("@strValue", e.CommandArgument.ToString()));

                clearall();
                lblMsg.Text = "Product Size Deleted";
                BindSizeSetup();
            }
        }
    }
}