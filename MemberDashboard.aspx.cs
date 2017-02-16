using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MemberDashboard : System.Web.UI.Page
{
    Clsconnection clscon = new Clsconnection();
    BillingShippingDetails clsBSD;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberInfo"] == null)
        {
            Response.Redirect("Register.aspx");
        }
        else
        {
            DataTable dtUser;
            dtUser = new DataTable();
            dtUser = (DataTable)Session["MemberInfo"];
            if (dtUser.Rows[0]["memberId"].ToString() == "0")
            {
                Response.Redirect("Register.aspx");
            }
            if (!IsPostBack)
            {
                BindMemberInfo();
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtZipCode.Text != "")
        {
            DataTable dt = new DataTable();
            dt = getStateCityOnPincode(Convert.ToInt64(txtZipCode.Text));

            if (dt.Rows.Count <= 0)
            {
                MsgBox("Invalid Pincode in Shipping Address");
                return;
            }
        }
        if (txtBZipCode.Text != "")
        {
            DataTable dt = new DataTable();
            dt = getStateCityOnPincode(Convert.ToInt64(txtBZipCode.Text));

            if (dt.Rows.Count <= 0)
            {
                MsgBox("Invalid Pincode in Billing Address");
                return;
            }
        }

        clscon.ExecuteDA("Update_ManageUser", new SqlParameter("@MemberId", ViewState["MemberId"]),
                    new SqlParameter("@Name", txtName.Text),
                     new SqlParameter("@Email", txtEmailR.Text),
                     new SqlParameter("@password", ""),
                    new SqlParameter("@Company", txtCompany.Text),
                    new SqlParameter("@Contact", txtMobile.Text),
                    new SqlParameter("@Address1", txtAddress1.Text),
                    new SqlParameter("@Address2", txtAddress2.Text),
                    new SqlParameter("@City", txtCity.Text),
                    new SqlParameter("@State", txtState.Text),
                    new SqlParameter("@Country", txtCountry.Text),
                    new SqlParameter("@ZipCode", txtZipCode.Text),
                    new SqlParameter("@Tinno", txtTin.Text),
                    new SqlParameter("@Cstno",   txtCst.Text),
                    new SqlParameter("@BCompany", txtBcompany.Text),
                    new SqlParameter("@BContact", txtBMobile.Text),
                    new SqlParameter("@BAddress1", txtBAddress1.Text),
                    new SqlParameter("@BAddress2", txtBAddress2.Text),
                    new SqlParameter("@BCity", txtBCity.Text),
                    new SqlParameter("@BState", txtBState.Text),
                    new SqlParameter("@BCountry", txtBCountry.Text),
                    new SqlParameter("@BZipCode", txtBZipCode.Text),
                    new SqlParameter("@IsApproved", "1"),
                    new SqlParameter("@Flag", "C"));
        MsgBox("Profile Updated successfully");
        updateMemberInfoSession();
        BindMemberInfo();
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
    protected void BindMemberInfo()
    {

        DataTable dtMember = new DataTable();
        dtMember = (DataTable)Session["MemberInfo"];

        foreach (DataRow dr in dtMember.Rows)
        {
            ViewState["MemberId"] = dr["MemberId"].ToString();
            ViewState["Password"] = dr["Password"].ToString();
            txtEmailR.Text = dr["Email"].ToString();
            txtName.Text = dr["Name"].ToString();
            txtCompany.Text = dr["Company"].ToString();
            txtMobile.Text = dr["Contact"].ToString();
            txtAddress1.Text = dr["Address1"].ToString();
            txtAddress2.Text = dr["Address2"].ToString();
            txtCity.Text = dr["City"].ToString();
            txtState.Text = dr["State"].ToString();
            txtCountry.Text = dr["Country"].ToString();
            txtZipCode.Text = dr["Zipcode"].ToString();
            txtTin.Text = dr["Tinno"].ToString();
            txtCst.Text = dr["Cstno"].ToString();
            txtBcompany.Text = dr["BCompany"].ToString();
            txtBMobile.Text = dr["BContact"].ToString();
            txtBAddress1.Text = dr["BAddress1"].ToString();
            txtBAddress2.Text = dr["BAddress2"].ToString();
            txtBCity.Text = dr["BCity"].ToString();
            txtBState.Text = dr["BState"].ToString();
            txtBCountry.Text = dr["BCountry"].ToString();
            txtBZipCode.Text = dr["BZipcode"].ToString();
        }
    }
    protected void updateMemberInfoSession()
    {
        DataTable dtUser = new DataTable();
        dtUser = clscon.ReturnDataTable("Login_MembersLogin", new SqlParameter("@Email", txtEmailR.Text.Trim()), new SqlParameter("@Password", ViewState["Password"]));
        if (dtUser.Rows.Count > 0)
        {
            if (dtUser.Rows[0]["memberId"].ToString() == "0")
            {
                //MsgBox("Invalid EmailId or Password");
                //return;
            }
            else
            {
                Session["MemberInfo"] = dtUser;
                //Response.Redirect("MemberDashboard.aspx");
            }
        }
        //update billing info 

        clsBSD = new BillingShippingDetails();
        DataTable dtBill = new DataTable();
        dtBill = clsBSD.BindBillShip();

        foreach (DataRow dr in dtUser.Rows)
        {
            if (dtBill.Rows.Count > 0)
            {
                clsBSD.RemoveItem(0);
            }
            clsBSD.AddToBillShipTable(dr["Tinno"].ToString(), dr["Cstno"].ToString(), dr["BCompany"].ToString(), dr["BContact"].ToString(), dr["BAddress1"].ToString(), dr["BAddress2"].ToString(), dr["BCity"].ToString(), dr["BState"].ToString(), dr["BCountry"].ToString(), dr["BZipcode"].ToString(), dr["Name"].ToString(), dr["Email"].ToString(), dr["Company"].ToString(), dr["Contact"].ToString(), dr["Address1"].ToString(), dr["Address2"].ToString(), dr["City"].ToString(), dr["State"].ToString(), dr["Country"].ToString(), dr["Zipcode"].ToString());
        }
    }
    protected void chkShipping_CheckedChanged(object sender, EventArgs e)
    {
        if (chkShipping.Checked == true)
        {
            txtBAddress1.Text = txtAddress1.Text;
            txtBAddress2.Text = txtAddress2.Text;
            txtBCity.Text = txtCity.Text;
            txtBCountry.Text = txtCountry.Text;
            txtBZipCode.Text = txtZipCode.Text;
            txtBState.Text = txtState.Text;
            txtBcompany.Text = txtCompany.Text;
            txtBMobile.Text = txtMobile.Text;
        }
        else
        {
            txtBAddress1.Text = "";
            txtBAddress2.Text = "";
            txtBCity.Text = "";
            txtBCountry.Text = "";
            txtBZipCode.Text = "";
            txtBState.Text = "";
            txtBcompany.Text = "";
            txtBMobile.Text = "";
        }
    }
    protected void txtBZipCode_TextChanged(object sender, EventArgs e)
    {
        if (txtBZipCode.Text != "")
        {
            DataTable dt = new DataTable();
            dt = getStateCityOnPincode(Convert.ToInt64(txtBZipCode.Text));

            if (dt.Rows.Count > 0)
            {
                txtBState.Text = dt.Rows[0]["District"].ToString();
                txtBCity.Text = dt.Rows[0]["City"].ToString();
                txtBCountry.Text = "India";
            }
            else
            {
                txtBState.Text = "";
                txtBCity.Text = "";
                txtBCountry.Text = "";
            }
        }
    }
    protected DataTable getStateCityOnPincode(float pincode)
    {
        DataTable dt = new DataTable();
        dt = clscon.ReturnDataTable("Select_PinCodeCheckOnId", new SqlParameter("@pincode", pincode));
        return dt;
    }
    protected void txtZipCode_TextChanged(object sender, EventArgs e)
    {
        if (txtZipCode.Text != "")
        {
            DataTable dt = new DataTable();
            dt = getStateCityOnPincode(Convert.ToInt64(txtZipCode.Text));

            if (dt.Rows.Count > 0)
            {
                txtState.Text = dt.Rows[0]["District"].ToString();
                txtCity.Text = dt.Rows[0]["City"].ToString();
                txtCountry.Text = "India";
            }
            else
            {
                txtState.Text = "";
                txtCity.Text = "";
                txtCountry.Text = "";
            }
        }
    }
}