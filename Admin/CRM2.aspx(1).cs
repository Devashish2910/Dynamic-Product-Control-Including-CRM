using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.UI.HtmlControls;

public partial class Admin_CRM2 : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    Class1 cl = new Class1();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblDeleteMsg.Text = "";

        if (!IsPostBack)
        {
            if (!Utils.IsLoggedIn())
            {
                Utils.LogOut();
            }
            else
            {
                Label lblFormTitle = (Label)this.Master.FindControl("lblFormTitle");
                lblFormTitle.Text = "CUSTOMER VISE PRICELIST UPDATE";
                //BindProduct();
                //BindMembers();
                BindData();

            }
        }

    }       
    protected void BindData()
    {
        DataTable ds = new DataTable();
        ds = cl.getdataset("select c.id,c.cusotmerid,c.productid,m.name,p.productname, c.prosaleprice, c.discount, c.disamt, c.netsaleprice from crm c inner join members m on m.memberid=c.cusotmerid inner join product p on p.id=c.productid ");
        
        rptr.DataSource = ds;
        rptr.DataBind();
    }
    protected void drpProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        //clear();
        String saleval = cl.getsinglevalue("select SalesPrice_Incl from product where id='" + txtproduct.Text + "'");
        txtsellingprice.Text = saleval;


    }
    protected void chkDiscount_TextChanged(object sender, EventArgs e)
    {
        String saleval = cl.getsinglevalue("select SalesPrice_Incl from product where id='" + txtproduct.Text + "'");
        if (txtdiscount.Text != "")
        {
            double discount = (Convert.ToDouble(txtsellingprice.Text) * Convert.ToDouble(txtdiscount.Text)) / 100;
            double amt = Convert.ToDouble(txtsellingprice.Text) - discount;
            txtdiscountamount.Text = discount.ToString("N2");
            txtfinalsellingprice.Text = amt.ToString("N2");
        }
    }
    protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditGroup")
        {
            DataTable ds = new DataTable();
            ds = cl.getdataset("select c.id,c.cusotmerid,c.productid,m.name,p.productname, c.prosaleprice, c.discount, c.disamt, c.netsaleprice from crm c inner join members m on m.memberid=c.cusotmerid inner join product p on p.id=c.productid where c.id='" + e.CommandArgument + "'");
            if (ds.Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();
                txtusername.Text = ds.Rows[0]["name"].ToString();
                txtproduct.Text = ds.Rows[0]["productname"].ToString();
                txtsellingprice.Text = (Convert.ToDouble(ds.Rows[0]["prosaleprice"].ToString())).ToString("N2");
                txtdiscount.Text = (Convert.ToDouble(ds.Rows[0]["discount"].ToString())).ToString("N2");
                txtdiscountamount.Text = (Convert.ToDouble(ds.Rows[0]["disamt"].ToString())).ToString("N2");
                txtfinalsellingprice.Text = (Convert.ToDouble(ds.Rows[0]["netsaleprice"].ToString())).ToString("N2");
                lblcustomerid.Text = ds.Rows[0]["cusotmerid"].ToString();
                lblproductid.Text = ds.Rows[0]["productid"].ToString();
            }
        }
        else if (e.CommandName == "DeleteGroup")
        {
            lblId.Text = e.CommandArgument.ToString();
            cl.execute("delete from crm where id='" + lblId.Text + "'");
            lblMsg.Text = "Deleted successfully.";
            BindData();
            clearall();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblId.Text))
        {
            lblMsg.Text = "You can not insert new Record. You can only update a record.";
            return;
        }
        else
        {
            cl.execute("update crm set productid='" + lblproductid.Text + "'  ,[cusotmerid] = '" + lblcustomerid.Text + "',[discount] = '" + txtdiscount.Text + "',[prosaleprice] ='" + txtsellingprice.Text + "',[disamt] = '" + txtdiscountamount.Text + "',[netsaleprice] = '" + txtfinalsellingprice.Text + "' where id='" + lblId.Text + "'");
            
            lblMsg.Text = "Details updated successfully.";
            BindData();
            //BindDescription();
            clearall();
        }

        

    }

    private void clearall()
    {
        txtdiscount.Text = "";
        txtdiscountamount.Text = "";
        txtfinalsellingprice.Text = "";
        txtproduct.Text = "";
        txtsellingprice.Text = "";
        txtusername.Text = "";


    }
  
}