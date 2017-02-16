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

public partial class CRM : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    Class1 cl = new Class1(); 
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
                lblFormTitle.Text = "CUSTOMER VISE PRICE";
                BindProduct();
                BindMembers();
                drpProduct.Items.Insert(0, new ListItem("- Select -", ""));
               
            }
        }
       
    }   

  protected void BindProduct()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_Product");
        drpProduct.DataSource = dt;
        drpProduct.DataTextField = "ProductName";
        drpProduct.DataValueField = "Id";
        drpProduct.DataBind();
        
       
    }

   protected void BindMembers()
    {
        DataTable dtmembers = new DataTable();
        dtmembers = cls.ReturnDataTable("Select_Members");
        rptr.DataSource = dtmembers;
        rptr.DataBind();
    }

   protected void chkAll_OnCheckedChanged(object sender, EventArgs e)
   {
       CheckBox chkAll = (CheckBox)sender;
       bool flag;
       if (chkAll != null)
       {
           if (chkAll.Checked == true)
           {
               flag = true;
           }
           else
           {
               flag = false;
           }

           foreach (RepeaterItem ri in rptr.Items)
           {
               CheckBox chk = (CheckBox)ri.FindControl("chk");
               if (chk != null)
               {
                   chk.Checked = flag;
               }
           }
       }
   }
   protected void drpProduct_SelectedIndexChanged(object sender, EventArgs e)
   {
       clear();
       String saleval = cl.getsinglevalue("select finalsellingprice from product where id='" + drpProduct.SelectedValue + "'");
       lblprice.Text = "Selling Price: " + saleval;
      
       
   }
   


   private void clear()
   {
       chkDiscount.Text = "";
       lblprice.Text = "";
       lbldiscount.Text = "";
       lblsaleprice.Text = "";
       
      
       
       
       
   }
   protected void chkDiscount_TextChanged(object sender, EventArgs e)
   {
       String saleval = cl.getsinglevalue("select finalsellingprice from product where id='" + drpProduct.SelectedValue + "'");
       if (chkDiscount.Text != "")
       {
           double discount = (Convert.ToDouble(saleval) * Convert.ToDouble(chkDiscount.Text)) / 100;
           double amt = Convert.ToDouble(saleval) - discount;
           lbldiscount.Text = "Discount Amount: " + discount.ToString("N2");
           lblsaleprice.Text = "Net Selling Price: " + amt.ToString("N2");
       }
   }
   protected bool checkMemberSelected()
   {
       bool flag = false;
       foreach (RepeaterItem ri in rptr.Items)
       {
           CheckBox chk = (CheckBox)ri.FindControl("chk");
           if (chk != null)
           {
               if (chk.Checked == true)
               {
                   flag = true;
               }
           }
       }

       return flag;

   }
   protected void btnSubmit_Click(object sender, EventArgs e)
   {
       if (checkMemberSelected())
       {
           lblMsg.Text = "";
          
           //loop through selected members and send mail
           foreach (RepeaterItem ri in rptr.Items)
           {
               CheckBox chk = (CheckBox)ri.FindControl("chk");
               if (chk != null)
               {
                   if (chk.Checked == true)
                   {
                       String saleval = cl.getsinglevalue("select finalsellingprice from product where id='" + drpProduct.SelectedValue + "'");
                       double discount = (Convert.ToDouble(saleval) * Convert.ToDouble(chkDiscount.Text)) / 100;
           double amt = Convert.ToDouble(saleval) - discount;
                       Label lblEmail = (Label)ri.FindControl("lblEmail");
                       Label lblName = (Label)ri.FindControl("lblMemberId");
                       DataTable dt = new DataTable();
                       dt = cl.getdataset("select * from crm where productid='" + drpProduct.SelectedValue + "' and cusotmerid='" + lblName.Text + "'");
                       if (dt.Rows.Count > 0)
                       {
                           cl.execute("UPDATE [dbo].[CRM] SET [productid] = '" + drpProduct.SelectedValue + "',[cusotmerid] = '" + lblName.Text + "',[discount] = '" + chkDiscount.Text + "',[prosaleprice] = '" + saleval + "',[disamt] = '" + discount + "',[netsaleprice] = '" + amt + "' WHERE productid='" + drpProduct.SelectedValue + "' and cusotmerid='" + lblName.Text + "'");
                       }
                       else
                       {
                           cl.execute("INSERT INTO [dbo].[CRM]([productid],[cusotmerid],[discount],[prosaleprice],[disamt],[netsaleprice])VALUES ('" + drpProduct.SelectedValue + "','" + lblName.Text + "','" + chkDiscount.Text + "','" + saleval + "','" + discount + "','" + amt + "')");
                       }
                   }
               }
           }
          
           lblMsg.Text = "Insert successfully.";
           clear();

       }
       else
       {
           lblMsg.Text = "Select Member to publish this offer.";
       }
      
   }
    
}