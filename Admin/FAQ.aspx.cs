using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_FAQ : System.Web.UI.Page
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
                lblFormTitle.Text = "FAQ";
                BindFAQ();
            }
        }
    }
    public void clearall()
    {
        cls.ResetFormControlValues(this.Page);
        lblId.Text = "";
        txtDescription.Text = "";
    }
    void BindFAQ()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "FAQ"),
           new SqlParameter("@strWhereClause", "where IsActive = 1 Order By Id asc"));
        rptr.DataSource = ds;
        rptr.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string pagename = "";
        if (drpFAQ.SelectedItem.ToString() == "Account")
        {
            pagename = "FAQAccount.aspx";
        }
        else if (drpFAQ.SelectedItem.ToString() == "Order")
        {
            pagename = "FAQOrder.aspx";
        }
        else if (drpFAQ.SelectedItem.ToString() == "Payment")
        {
            pagename = "FAQPayment.aspx";
        }
        else if (drpFAQ.SelectedItem.ToString() == "Shipping Policy")
        {
            pagename = "FAQShippingPolicy.aspx";
        }
        else if (drpFAQ.SelectedItem.ToString() == "Return and Cancellation Policy")
        {
            pagename = "FAQReturnandCancellationPolicy.aspx";
        }
        if (pagename != "")
        {
            if (string.IsNullOrEmpty(lblId.Text))
            {

                cls.ExecuteDA("Insert_FAQ", new SqlParameter("@CatId", drpFAQ.SelectedValue),
                    new SqlParameter("@Category", drpFAQ.SelectedItem.ToString()),
                    new SqlParameter("@Title", txtTitle.Text),
                    new SqlParameter("@Description", txtDescription.Text),
                    new SqlParameter("@PageName", pagename),
                    new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Details inserted successfully.";
                BindFAQ();

            }
            else
            {


                cls.ExecuteDA("Update_FAQ", new SqlParameter("@Id", lblId.Text),
                    new SqlParameter("@CatId", drpFAQ.SelectedValue),
                    new SqlParameter("@Category", drpFAQ.SelectedItem.ToString()),
                    new SqlParameter("@Title", txtTitle.Text),
                    new SqlParameter("@Description", txtDescription.Text),
                    new SqlParameter("@PageName", pagename),
                    new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Details Updated Successfully";
                BindFAQ();

            }
        }

        else
        {
            lblMsg.Text = ("Please Select any Category");
        }
    }
    
    protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditGroup")
        {
            DataSet ds = new DataSet();
            ds = cls.ReturnDataSet("sp_RetriveDataWithField",
                 new SqlParameter("@Fields", "*"),
                new SqlParameter("@TblNm", "FAQ"),
           new SqlParameter("@WhereClause", "FAQ where Id ='" + e.CommandArgument + "' and FAQ.IsActive = 1"));
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();               
                drpFAQ.SelectedValue = ds.Tables[0].Rows[0]["CatId"].ToString();
                txtTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();            

            }
        }
        if (e.CommandName == "DeleteGroup")
        {
            cls.ExecuteDA("DeleteRecord", new SqlParameter("@TblNm", "FAQ"),
                           new SqlParameter("@strField", "Id"),
                             new SqlParameter("@strValue", e.CommandArgument.ToString()));

            clearall();
            lblMsg.Text = "FAQ Deleted";
            BindFAQ();
        }
    }
}