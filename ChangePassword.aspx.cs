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
    Clsconnection clscon = new Clsconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberInfo"] == null)
        {
            Response.Redirect("Register.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
               
            }
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)Session["MemberInfo"];

        foreach (DataRow dr in dt.Rows)
        {
            ViewState["Email"] = dr["Email"].ToString();

        }
        //Check for valid old password
        object ValidPwd;
        ValidPwd = clscon.ReturnScalerObject("Login_ValidateMemberPassword", new SqlParameter("@Email",ViewState["Email"].ToString()),
            new SqlParameter("@Password", txtOldPassword.Text));

        //Update the new password in DB if old password check is valid
        if (ValidPwd != null)
        {
            clscon.ExecuteDA("Update_UserMemberPassword", new SqlParameter("@Email", ViewState["Email"].ToString()),
                                                 new SqlParameter("@Password", txtconfPassword.Text));

            MsgBox("Password updated successfully");
           
        }
        else
        {
            MsgBox("Enter valid old password.");
        }
    }
    public void MsgBox(string message)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            message = message.Replace("'", "'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "MessageThenRedirect", "alert('" + message + "')", true);
        }
    }
}