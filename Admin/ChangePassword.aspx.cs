using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ChangePassword : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();

    protected void Page_Load(object sender, EventArgs e)
    {
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
                lblFormTitle.Text = "Change Password";
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Check for valid old password
        object ValidPwd;
        ValidPwd = cls.ReturnScalerObject("Login_ValidatePassword", new SqlParameter("@UserName", Utils.CurrentLoggedInUser()), new SqlParameter("@Password", txtOldPwd.Text));

        //Update the new password in DB if old password check is valid
        if (ValidPwd != null)
        {
            cls.ExecuteDA("Update_UserPassword", new SqlParameter("@UserID", Utils.CurrentUser().UserID),
                                                 new SqlParameter("@Password", txtConfirmPwd.Text),
                                                 new SqlParameter("@LastPasswordChangeDate", DateTime.Now));
            lblMsg.Text = "Password changed successfully.";
            txtOldPwd.Text = "";
            txtNewPwd.Text = "";
            txtConfirmPwd.Text = "";
        }
        else
        {
            lblMsg.Text = "Enter valid old password.";
            txtOldPwd.Focus();
        }
    }
    private void clearall()
    {
        txtOldPwd.Text = "";
        txtNewPwd.Text = "";
        txtConfirmPwd.Text = "";
    }
}