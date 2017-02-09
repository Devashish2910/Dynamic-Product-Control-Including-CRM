using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Checkout_Shipping : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    clsAddToCart clsCart;
    BillingShippingDetails clsBSD;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["MemberInfo"] != null)
        {
            if (HttpContext.Current.Session["Cart"] != null)
            {
                clsCart = new clsAddToCart();
                if (clsCart.TotalItems() <= 0)
                {
                    Response.Redirect("MemberDashBoard.aspx");
                }
            }
            if (!IsPostBack)
            {
                BindShippingInfo();
                BindOrderSummary();
            }
        }
        else
        {
            HttpContext.Current.Session["CameFrom"] = "CheckOut_Login";
            Response.Redirect("Register.aspx");
        }
        pnlShippingPin.Visible = false;
    }
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!IsPostBack)
    //    {
    //        BindShippingInfo();
    //        BindOrderSummary();
    //    }
    //    pnlShippingPin.Visible = false;
    //}
    protected void BindOrderSummary()
    {
        clsCart = new clsAddToCart();
        lblTotalItems.Text = clsCart.TotalItems().ToString();
        lblTotalAmount.Text = "Rs. " + Math.Round(clsCart.TotalPrice()).ToString();
    }
    protected void BindShippingInfo()
    {
        clsBSD = new BillingShippingDetails();

        DataTable dtbilship = new DataTable();
        dtbilship = clsBSD.BindBillShip();

        if (dtbilship.Rows.Count <= 0)
        {
            DataTable dtMember = new DataTable();
            dtMember = (DataTable)Session["MemberInfo"];

            foreach (DataRow dr in dtMember.Rows)
            {
                clsBSD.AddToBillShipTable(dr["Tinno"].ToString(), dr["Cstno"].ToString(), dr["BCompany"].ToString(), dr["BContact"].ToString(), dr["BAddress1"].ToString(), dr["BAddress2"].ToString(), dr["BCity"].ToString(), dr["BState"].ToString(), dr["BCountry"].ToString(), dr["BZipcode"].ToString(), dr["Name"].ToString(), dr["Email"].ToString(), dr["Company"].ToString(), dr["Contact"].ToString(), dr["Address1"].ToString(), dr["Address2"].ToString(), dr["City"].ToString(), dr["State"].ToString(), dr["Country"].ToString(), dr["Zipcode"].ToString());
            }
        }
        foreach (DataRow dr in dtbilship.Rows)
        {
            txtEmailS.Text = dr["SEmail"].ToString();
            txtNameS.Text = dr["SName"].ToString();
            txtCompanyS.Text = dr["SCompany"].ToString();
            txtMobileS.Text = dr["SContact"].ToString();
            txtAddress1S.Text = dr["SAddress1"].ToString();
            txtAddress2S.Text = dr["SAddress2"].ToString();
            txtCityS.Text = dr["SCity"].ToString();
            txtStateS.Text = dr["SState"].ToString();
            txtCountryS.Text = dr["SCountry"].ToString();
            txtPincodeS.Text = dr["SZipcode"].ToString();
            txtEmailS.Text = dr["SEmail"].ToString();

            //if (Session["CameAgain"] != null)
            //{
            txtCompanyB.Text = dr["Company"].ToString();
            txtMobileB.Text = dr["Contact"].ToString();
            txtAddress1B.Text = dr["Address1"].ToString();
            txtAddress2B.Text = dr["Address2"].ToString();
            txtCityB.Text = dr["City"].ToString();
            txtStateB.Text = dr["State"].ToString();
            txtCountryB.Text = dr["Country"].ToString();
            txtPincodeB.Text = dr["Zipcode"].ToString();
            //}
            txtTIN.Text = dr["Name"].ToString();
            txtCST.Text = dr["Email"].ToString();
        }
    }
    protected void chkShipping_CheckedChanged(object sender, EventArgs e)
    {
        if (chkShipping.Checked == true)
        {
            txtAddress1B.Text = txtAddress1S.Text;
            txtAddress2B.Text = txtAddress2S.Text;
            txtCityB.Text = txtCityS.Text;
            txtCompanyB.Text = txtCompanyS.Text;
            txtCountryB.Text = txtCountryS.Text;
            // txtEmailS.Text = txtEmailB.Text;
            txtMobileB.Text = txtMobileS.Text;
            // txtNameS.Text = txtNameB.Text;
            txtPincodeB.Text = txtPincodeS.Text;
            txtStateB.Text = txtStateS.Text;
        }
        else
        {
            txtAddress1B.Text = "";
            txtAddress2B.Text = "";
            txtCityB.Text = "";
            txtCompanyB.Text = "";
            txtCountryB.Text = "";
            // txtEmailS.Text= "";
            txtMobileB.Text = "";
            // txtNameS.Text = "";
            txtPincodeB.Text = "";
            txtStateB.Text = "";
        }
    }
    protected void txtPincodeB_TextChanged(object sender, EventArgs e)
    {
        if (txtPincodeB.Text != "")
        {
            DataTable dt = new DataTable();
            dt = getStateCityOnPincode(Convert.ToInt64(txtPincodeB.Text));

            if (dt.Rows.Count > 0)
            {
                txtStateB.Text = dt.Rows[0]["District"].ToString();
                txtCityB.Text = dt.Rows[0]["City"].ToString();
                txtCountryB.Text = "India";
                pnlBillingPin.Visible = false;
            }
            else
            {
                txtStateB.Text = "";
                txtCityB.Text = "";
                txtCountryB.Text = "";
                pnlBillingPin.Visible = true;
            }
        }
    }
    protected void txtPincodeS_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = getStateCityOnPincode(Convert.ToInt64(txtPincodeS.Text));

        if (dt.Rows.Count > 0)
        {
            txtStateS.Text = dt.Rows[0]["District"].ToString();
            txtCityS.Text = dt.Rows[0]["City"].ToString();
            txtCountryS.Text = "India";
            pnlShippingPin.Visible = false;
        }
        else
        {
            txtStateS.Text = "";
            txtCityS.Text = "";
            txtCountryS.Text = "";
            pnlShippingPin.Visible = true;
        }
    }
    protected DataTable getStateCityOnPincode(float pincode)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_PinCodeCheckOnId", new SqlParameter("@pincode", pincode));
        return dt;
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = getStateCityOnPincode(Convert.ToInt64(txtPincodeS.Text));

        if (dt.Rows.Count <= 0)
        {
            MsgBox("Invalid Pincode in Shipping Address");
            return;
        }

        DataTable dt1 = new DataTable();
        dt1 = getStateCityOnPincode(Convert.ToInt64(txtPincodeB.Text));

        if (dt1.Rows.Count <= 0)
        {
            MsgBox("Invalid Pincode in Billing Address");
            return;
        }

        clsBSD = new BillingShippingDetails();
        DataTable dtBill = new DataTable();
        dtBill = clsBSD.BindBillShip();

        if (dtBill.Rows.Count > 0)
        {
            clsBSD.RemoveItem(0);
        }
        clsBSD.AddToBillShipTable(txtTIN.Text, txtCST.Text, txtCompanyB.Text, txtMobileB.Text, txtAddress1B.Text, txtAddress2B.Text, txtCityB.Text, txtStateB.Text, txtCountryB.Text, txtPincodeB.Text, txtNameS.Text, txtEmailS.Text, txtCompanyS.Text, txtMobileS.Text, txtAddress1S.Text, txtAddress2S.Text, txtCityS.Text, txtStateS.Text, txtCountryS.Text, txtPincodeS.Text);
        Response.Redirect("Checkout_Order.aspx");
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