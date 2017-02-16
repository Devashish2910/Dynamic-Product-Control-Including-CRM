using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public partial class Admin_ManageCoupons : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblDeleteMsg.Text = "";
        txtCode.Focus();

        if (!IsPostBack)
        {
            if (!Utils.IsLoggedIn())
            {
                Utils.LogOut();
            }
            else
            {
                Label lblFormTitle = (Label)this.Master.FindControl("lblFormTitle");
                lblFormTitle.Text = "Manage Coupons";
                BindData();
            }
        }
    }
    protected void BindData()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_Coupon");
        rptr.DataSource = dt;
        rptr.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int flag = 0;
        string crA = "0";
        string crB = "0";
        string crC = "0";

        if (chkCriteriaA.Checked)
        {
            if (rbtCriteriaA.SelectedValue != "")
            {
                crA = rbtCriteriaA.SelectedValue;
                flag = 1;
            }
            else
            {
                lblMsg.Text = "Choose Value in Criteria A";
                return;
            }
        }
        if (chkCriteriaB.Checked)
        {
            if (rbtCriteriaB.SelectedValue != "")
            {
                crB = rbtCriteriaB.SelectedValue;
                flag = 1;
            }
            else
            {
                lblMsg.Text = "Choose Value in Criteria B";
                return;
            }
        }
        if (chkCriteriaC.Checked)
        {
            if (rbtCriteriaC.SelectedValue != "")
            {
                crC = rbtCriteriaC.SelectedValue;
                flag = 1;
            }
            else
            {
                lblMsg.Text = "Choose Value in Criteria C";
                return;
            }
        }

        if (flag <= 0)
        {
            lblMsg.Text = "Choose Criteria";
            return;
        }
        else
        {
            if (string.IsNullOrEmpty(lblId.Text))
            {
                if (cls.CheckExistField("CheckExistField", "Coupon", "CouponName", txtCode.Text, "and IsActive = 1 "))
                {
                    lblMsg.Text = "This coupon code already exists.";
                    return;
                }
                else
                {
                    cls.ExecuteDA("Insert_Coupon", new SqlParameter("@CouponName", txtCode.Text),
                                                               new SqlParameter("@CriteriaA", crA),
                                                               new SqlParameter("@CriteriaB", crB),
                                                               new SqlParameter("@CriteriaC", crC),
                                                               new SqlParameter("@Discount", txtDiscount.Text),
                                                               new SqlParameter("@InUse", chkIsActive.Checked));


                    lblMsg.Text = "Details inserted successfully.";
                }
            }
            else
            {
                if (cls.CheckExistField("CheckExistField", "Coupon", "CouponName", txtCode.Text, "and IsActive = 1 and Id != '" + lblId.Text + "'"))
                {
                    lblMsg.Text = "This coupon code already exists.";
                    return;
                }
                else
                {
                    cls.ExecuteDA("Update_Coupon", new SqlParameter("@Id", lblId.Text),
                                                              new SqlParameter("@CouponName", txtCode.Text),
                                                              new SqlParameter("@CriteriaA", crA),
                                                              new SqlParameter("@CriteriaB", crB),
                                                              new SqlParameter("@CriteriaC", crC),
                                                              new SqlParameter("@Discount", txtDiscount.Text),
                                                              new SqlParameter("@InUse", chkIsActive.Checked));


                    lblMsg.Text = "Details updated successfully.";
                }
            }
            BindData();
            clearall();
        }
    }
    protected void rptr_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            lblMsg.Text = "";
            DataSet dset = new DataSet();
            dset = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("TblNm", "Coupon"), new SqlParameter("strwhereclause", "where ID = " + e.CommandArgument + " "));
            if (dset.Tables[0].Rows.Count > 0)
            {
                DataRow dRow = null;
                foreach (DataRow dRow_loopVariable in dset.Tables[0].Rows)
                {
                    dRow = dRow_loopVariable;
                    txtCode.Text = dRow["CouponName"].ToString();
                    txtDiscount.Text = dRow["Discount"].ToString();

                    if (dRow["CriteriaA"].ToString() == "0")
                    {
                        chkCriteriaA.Checked = false;
                        rbtCriteriaA.SelectedValue = "";
                    }
                    else if (dRow["CriteriaA"].ToString() == "1")
                    {
                        chkCriteriaA.Checked = true;
                        rbtCriteriaA.SelectedValue = "1";
                    }
                    else
                    {
                        chkCriteriaA.Checked = true;
                        rbtCriteriaA.SelectedValue = "2";
                    }

                    if (dRow["CriteriaB"].ToString() == "0")
                    {
                        chkCriteriaB.Checked = false;
                        rbtCriteriaB.SelectedValue = "";
                    }
                    else if (dRow["CriteriaB"].ToString() == "3")
                    {
                        chkCriteriaB.Checked = true;
                        rbtCriteriaB.SelectedValue = "3";
                    }
                    else
                    {
                        chkCriteriaB.Checked = true;
                        rbtCriteriaB.SelectedValue = "4";
                    }

                    if (dRow["CriteriaC"].ToString() == "0")
                    {
                        chkCriteriaC.Checked = false;
                        rbtCriteriaC.SelectedValue = "";
                    }
                    else if (dRow["CriteriaC"].ToString() == "5")
                    {
                        chkCriteriaC.Checked = true;
                        rbtCriteriaC.SelectedValue = "5";
                    }
                    else
                    {
                        chkCriteriaC.Checked = true;
                        rbtCriteriaC.SelectedValue = "6";
                    }

                    chkIsActive.Checked = Convert.ToBoolean(dRow["InUse"]);
                    lblId.Text = e.CommandArgument.ToString();

                }
            }
        }
        else if (e.CommandName == "Delete")
        {
            cls.ExecuteDA("DeleteRecord", new SqlParameter("@TblNm", "Coupon"),
                                       new SqlParameter("@strField", "Id"),
                                       new SqlParameter("@strValue", e.CommandArgument.ToString()));
            BindData();
            lblMsg.Text = "Record deleted successfully.";
        }
        else if (e.CommandName == "InUseYes")
        {
            cls.ExecuteDA("Update_CouponInUse", new SqlParameter("@Id", e.CommandArgument.ToString()), new SqlParameter("@InUse",true ));
            lblMsg.Text = "Record updated successfully";
            BindData();
        }
        else if (e.CommandName == "InUseNo")
        {
            cls.ExecuteDA("Update_CouponInUse", new SqlParameter("@Id",  e.CommandArgument.ToString()), new SqlParameter("@InUse",false));
            lblMsg.Text = "Record updated successfully";
            BindData();
        }
    }
    //protected void chkIsActive_CheckedChanged(object sender, EventArgs e)
    //{
    //    CheckBox chk = (CheckBox)sender;
    //    cls.ExecuteDA("Update_CouponInUse", new SqlParameter("@Id", chk.ToolTip), new SqlParameter("@InUse", chk.Checked));
    //    lblMsg.Text = "Record updated successfully";
    //}
    protected void clearall()
    {
        cls.ResetFormControlValues(this);
        chkCriteriaA.Checked = false;
        chkCriteriaB.Checked = false;
        chkCriteriaC.Checked = false;
        chkIsActive.Checked = true;
        rbtCriteriaA.SelectedIndex = -1;
        rbtCriteriaB.SelectedIndex = -1;
        rbtCriteriaC.SelectedIndex = -1;
        lblId.Text = "";
    }
}