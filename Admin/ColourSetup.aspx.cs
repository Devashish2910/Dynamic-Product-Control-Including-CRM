using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Admin_ColourSetup : System.Web.UI.Page
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
                lblFormTitle.Text = "Product Colour Setup";
                BindColourSetup();
            }
        }
    }
    public void clearall()
    {
        cls.ResetFormControlValues(this.Page);
        lblId.Text = "";
    }
    void BindColourSetup()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "ColourSetup"),
           new SqlParameter("@strWhereClause", "where IsActive = 1 Order By ColourId asc"));
        rptr.DataSource = ds;
        rptr.DataBind();

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblId.Text))
        {
            if (cls.CheckExistField("CheckExistField", "ColourSetup", "ColourName", txtcolourname.Text, "and IsActive = 1"))
            {
                lblMsg.Text = "This ColourName already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Insert_ColourSetup", new SqlParameter("@ColourName", txtcolourname.Text),
                    new SqlParameter("@ColourCode", txtcolourcode.Text),
                    new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Details inserted successfully.";
                BindColourSetup();
            }
        }
        else
        {
            if (cls.CheckExistField("CheckExistField", "ColourSetup", "ColourName", txtcolourname.Text, "and ColourId <> " + lblId.Text + " and IsActive = 1"))
            {
                lblMsg.Text = "This ColourName already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Update_ColourSetup", new SqlParameter("@ColourId", lblId.Text),
                    new SqlParameter("@ColourName", txtcolourname.Text),
                    new SqlParameter("@ColourCode", txtcolourcode.Text),
                    new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Details updated successfully.";
                BindColourSetup();
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
                new SqlParameter("@TblNm", "ColourSetup"),
           new SqlParameter("@WhereClause", "ColourSetup where ColourId ='" + e.CommandArgument + "' and ColourSetup.IsActive = 1"));

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();

                txtcolourname.Text = ds.Tables[0].Rows[0]["ColourName"].ToString();
                txtcolourcode.Text = ds.Tables[0].Rows[0]["ColourCode"].ToString();
            }
        }
        if (e.CommandName == "DeleteGroup")
        {
            if (cls.CheckExistField("CheckExistField", "ProductColour", "ColourId", e.CommandArgument.ToString(), "and IsActive = 1"))
            {
                lblMsg.Text = "This Colour exists in Product. First delete products related to this Colour.";
                return;
            }
            else
            {
                cls.ExecuteDA("DeleteRecord", new SqlParameter("@TblNm", "ColourSetup"),
                               new SqlParameter("@strField", "ColourId"),
                                 new SqlParameter("@strValue", e.CommandArgument.ToString()));

                clearall();
                lblMsg.Text = "Product Colour Deleted";
                BindColourSetup();
            }
        }
    }
}