using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Admin_PincodeChecker : System.Web.UI.Page
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
                lblFormTitle.Text = "Pincode Checker";
                BindPincodeChecker();
            }
        }
    }
    public void clearall()
    {
        cls.ResetFormControlValues(this.Page);
        lblId.Text = "";
    }
    void BindPincodeChecker()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "PincodeChecker"),
           new SqlParameter("@strWhereClause", "Order By Id asc"));
        rptr.DataSource = ds;
        rptr.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblId.Text))
        {
            if (cls.CheckExistField("CheckExistField", "PincodeChecker", "Pincode", txtpincode.Text, ""))
            {
                lblMsg.Text = "This Pincode already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Insert_PincodeChecker", new SqlParameter("@City", txtCity.Text),
                    new SqlParameter("@Zone", drpZone.SelectedValue.ToString()),
                    new SqlParameter("@Pincode", txtpincode.Text),
                    new SqlParameter("@District", txtDistrict.Text),
                    new SqlParameter("@IsODA", drpoda.SelectedValue.ToString()),
                    new SqlParameter("@StateCode", txtStateCode.Text),
                    new SqlParameter("@IsActive", chkIsActive.Checked));

                clearall();
                lblMsg.Text = "Details inserted successfully.";
                BindPincodeChecker();
            }
        }
        else
        {
            if (cls.CheckExistField("CheckExistField", "PincodeChecker", "Pincode", txtpincode.Text, "and Id <> " + lblId.Text + ""))
            {
                lblMsg.Text = "This Pincode already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Update_PincodeChecker", new SqlParameter("@Id", lblId.Text),
                    new SqlParameter("@City", txtCity.Text),
                     new SqlParameter("@Zone", drpZone.SelectedValue.ToString()),
                    new SqlParameter("@Pincode", txtpincode.Text),
                    new SqlParameter("@District", txtDistrict.Text),
                    new SqlParameter("@IsODA", drpoda.SelectedValue.ToString()),
                    new SqlParameter("@StateCode", txtStateCode.Text),
                    new SqlParameter("@IsActive", chkIsActive.Checked));

                clearall();
                lblMsg.Text = "Details Updated Successfully";
                BindPincodeChecker();
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
                new SqlParameter("@TblNm", "PincodeChecker"),
           new SqlParameter("@WhereClause", "PincodeChecker where Id ='" + e.CommandArgument + "' and PincodeChecker.IsActive = 1"));
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                drpZone.Text = ds.Tables[0].Rows[0]["Zone"].ToString();
                txtpincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                drpoda.Text = ds.Tables[0].Rows[0]["IsODA"].ToString();
                txtStateCode.Text = ds.Tables[0].Rows[0]["StateCode"].ToString();
                chkIsActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
            }
        }
        else if (e.CommandName == "DeleteGroup")
        {
            cls.ExecuteDA("delete_PinCodeCheckOnId", new SqlParameter("@Id", e.CommandArgument.ToString()));
            clearall();
            lblMsg.Text = "Pincode Checker Deleted";
            BindPincodeChecker();
        }
        else if (e.CommandName == "InUseYes")
        {
            cls.ExecuteDA("update_PinCodeCheckActive", new SqlParameter("@Id", e.CommandArgument.ToString()), new SqlParameter("@IsActive", true));
            lblMsg.Text = "Details updated successfully";
            BindPincodeChecker();
        }
        else if (e.CommandName == "InUseNo")
        {
            cls.ExecuteDA("update_PinCodeCheckActive", new SqlParameter("@Id", e.CommandArgument.ToString()), new SqlParameter("@IsActive", false));
            lblMsg.Text = "Details updated successfully";
            BindPincodeChecker();
        }
    }
}