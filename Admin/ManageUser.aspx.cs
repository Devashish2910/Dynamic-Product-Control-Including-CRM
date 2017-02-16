using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_ManageUser : System.Web.UI.Page
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
                lblFormTitle.Text = "Manage User";
                BindManageUser();
            }
        }
    }
    void BindManageUser()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "Members"),
           new SqlParameter("@strWhereClause", "where IsActive = 1 Order By MemberId asc"));
        rptr.DataSource = ds;
        rptr.DataBind();
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
            if (cls.CheckExistField("CheckExistField", "Members", "Email", txtEmail.Text.Trim(), "and IsActive = 1"))
            {
                lblMsg.Text = "This Member already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Insert_Members",new SqlParameter("@Name", txtMemName.Text),
                     new SqlParameter("@Email", txtEmail.Text),
                     new SqlParameter("@Password", txtPassword.Text),
                     new SqlParameter("@Company", txtCompany.Text),
                      new SqlParameter("@Contact", txtContact.Text),
                      new SqlParameter("@Address1", txtAddress1.Text),
                    new SqlParameter("@Address2", txtAddress2.Text),
                    new SqlParameter("@City", txtCity.Text),
                    new SqlParameter("@State", txtState.Text),
                    new SqlParameter("@Country", txtCountry.Text),
                    new SqlParameter("@ZipCode", txtZipCode.Text),
                     new SqlParameter("@Tinno", txtTin.Text),
                    new SqlParameter("@Cstno", txtCst.Text),
                    new SqlParameter("@BCompany", txtCompany.Text),
                    new SqlParameter("@BContact", txtBContact.Text),
                    new SqlParameter("@BAddress1", txtBAddress1.Text),
                    new SqlParameter("@BAddress2", txtBAddress2.Text),
                    new SqlParameter("@BCity", txtBCity.Text),
                    new SqlParameter("@BState", txtBState.Text),
                    new SqlParameter("@BCountry", txtBCountry.Text),
                    new SqlParameter("@BZipCode", txtBZipCode.Text),
                    new SqlParameter("@IsApproved", chkIsActive.Checked));
                clearall();
                lblMsg.Text = "Details inserted successfully.";
                BindManageUser();
            }
        }
        else
        {
            if (cls.CheckExistField("CheckExistField", "Members", "Email", txtEmail.Text.Trim(), "and MemberId<>" + lblId.Text + "  and IsActive = 1"))
            {
                lblMsg.Text = "This Supplier already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Update_ManageUser", new SqlParameter("@MemberId", lblId.Text),
                     new SqlParameter("@Name", txtMemName.Text),
                     new SqlParameter("@Email", txtEmail.Text),
                     new SqlParameter("@Password", txtPassword.Text),
                     new SqlParameter("@Company", txtCompany.Text),
                      new SqlParameter("@Contact", txtContact.Text),
                      new SqlParameter("@Address1", txtAddress1.Text),
                    new SqlParameter("@Address2", txtAddress2.Text),
                    new SqlParameter("@City", txtCity.Text),
                    new SqlParameter("@State", txtState.Text),
                    new SqlParameter("@Country", txtCountry.Text),
                    new SqlParameter("@ZipCode", txtZipCode.Text),
                     new SqlParameter("@Tinno", txtTin.Text),
                    new SqlParameter("@Cstno", txtCst.Text),
                    new SqlParameter("@BCompany", txtCompany.Text),
                    new SqlParameter("@BContact", txtBContact.Text),
                    new SqlParameter("@BAddress1", txtBAddress1.Text),
                    new SqlParameter("@BAddress2", txtBAddress2.Text),
                    new SqlParameter("@BCity", txtBCity.Text),
                    new SqlParameter("@BState", txtBState.Text),
                    new SqlParameter("@BCountry", txtBCountry.Text),
                    new SqlParameter("@BZipCode", txtBZipCode.Text),
                    new SqlParameter("@IsApproved", chkIsActive.Checked),
                    new SqlParameter("@Flag","A"));
                clearall();
                lblMsg.Text = "Details updated successfully.";
                BindManageUser();
            }
        }
    }
    //protected void btnSubmit_Click(object sender, EventArgs e)
    //{           
    //            cls.ExecuteDA("Update_ManageUser", new SqlParameter("@MemberId", lblId.Text),
    //                 new SqlParameter("@Name", txtMemName.Text),
    //                 new SqlParameter("@Email", txtEmail.Text),
    //                 new SqlParameter("@Password", txtPassword.Text),
    //                 new SqlParameter("@Company", txtCompany.Text),
    //                  new SqlParameter("@Contact", txtContact.Text),
    //                  new SqlParameter("@Address1", txtAddress1.Text),
    //                new SqlParameter("@Address2", txtAddress2.Text),
    //                new SqlParameter("@City", txtCity.Text),
    //                new SqlParameter("@State", txtState.Text),
    //                new SqlParameter("@Country", txtCountry.Text),
    //                new SqlParameter("@ZipCode", txtZipCode.Text),
    //                 new SqlParameter("@Tinno", txtTin.Text),
    //                new SqlParameter("@Cstno", txtCst.Text),
    //                new SqlParameter("@BCompany",   txtCompany.Text),
    //                new SqlParameter("@BContact", txtBContact.Text),
    //                new SqlParameter("@BAddress1", txtBAddress1.Text),
    //                new SqlParameter("@BAddress2", txtBAddress2.Text),
    //                new SqlParameter("@BCity", txtBCity.Text),
    //                new SqlParameter("@BState", txtBState.Text),
    //                new SqlParameter("@BCountry", txtBCountry.Text),
    //                new SqlParameter("@BZipCode", txtBZipCode.Text),
    //                new SqlParameter("@InApproved", chkIsActive.Checked));

    //            clearall();
    //            lblMsg.Text = "Details Updated Successfully";
    //            BindManageUser();                  
    //}
    protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditGroup")
        {
            DataSet ds = new DataSet();
            ds = cls.ReturnDataSet("sp_RetriveDataWithField",
                 new SqlParameter("@Fields", "*"),
                new SqlParameter("@TblNm", "Members"),
           new SqlParameter("@WhereClause", "Members where MemberId ='" + e.CommandArgument + "' and Members.IsActive = 1"));
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();
                txtMemName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                txtCompany.Text = ds.Tables[0].Rows[0]["Company"].ToString();
                txtContact.Text = ds.Tables[0].Rows[0]["Contact"].ToString();
                txtAddress1.Text = ds.Tables[0].Rows[0]["Address1"].ToString();
                txtAddress2.Text = ds.Tables[0].Rows[0]["Address2"].ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                txtCountry.Text = ds.Tables[0].Rows[0]["Country"].ToString();
                txtZipCode.Text = ds.Tables[0].Rows[0]["ZipCode"].ToString();
                txtTin.Text = ds.Tables[0].Rows[0]["Tinno"].ToString();
                txtCst.Text = ds.Tables[0].Rows[0]["Cstno"].ToString();
                txtBCompany.Text = ds.Tables[0].Rows[0]["BCompany"].ToString();
                txtBContact.Text = ds.Tables[0].Rows[0]["BContact"].ToString();
                txtBAddress1.Text = ds.Tables[0].Rows[0]["BAddress1"].ToString();
                txtBAddress2.Text = ds.Tables[0].Rows[0]["BAddress2"].ToString();
                txtBCity.Text = ds.Tables[0].Rows[0]["BCity"].ToString();
                txtBState.Text = ds.Tables[0].Rows[0]["BState"].ToString();
                txtBCountry.Text = ds.Tables[0].Rows[0]["BCountry"].ToString();
                txtBZipCode.Text = ds.Tables[0].Rows[0]["BZipCode"].ToString();
                chkIsActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsApproved"]);

                //if (ds.Tables[0].Rows[0]["IsApproved"].ToString() == "true")
                //{
                //    chkIsActive.Checked = true;
                //    return;
                    
                //}
                //else if (ds.Tables[0].Rows[0]["IsApproved"].ToString() == "false")
                //{
                //    chkIsActive.Checked = false;
                //    return;
                   
                //}
            }
        }
        if (e.CommandName == "DeleteGroup")
        {
            cls.ExecuteDA("DeleteRecord", new SqlParameter("@TblNm", "PincodeChecker"),
                           new SqlParameter("@strField", "Id"),
                             new SqlParameter("@strValue", e.CommandArgument.ToString()));

            clearall();
            lblMsg.Text = "Pincode Checker Deleted";
            BindManageUser();
        }

    }
}