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


public partial class Admin_Brand : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
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
                lblFormTitle.Text = "Product Brand SetUp";

                BindBrand();
                imgPhoto.Visible = false;
            }
        }
    }
    public void clearall()
    {
        cls.ResetFormControlValues(this.Page);
        lblId.Text = "";

        imgPhoto.Visible = false;
        lblPhoto2.Text = "";
    }
    private void BindBrand()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "Brand"),
            new SqlParameter("@strWhereClause", "where IsActive=1 order by Id Asc"));

        rptr.DataSource = ds;
        rptr.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string concat = Guid.NewGuid().ToString();
        string strDoc = "";

        if (fupPhoto.HasFile != false)
        {
            string ext = null;
            ext = Path.GetExtension(fupPhoto.PostedFile.FileName).ToLower();
            if ((ext != ".jpg") & (ext != ".jpeg") & (ext != ".gif") & (ext != ".png") & (ext != ".bmp"))
            {
                lblMsg.Text = "Please select jpg or gif or png or bmp  files only";
                fupPhoto.Focus();
                return;
            }

            //''''''Create an image object from the uploaded file
            System.Drawing.Image FrontImage = null;
            FrontImage = System.Drawing.Image.FromStream(fupPhoto.PostedFile.InputStream);
            ///'''''''''''Determine width and height of uploaded image
            double UploadedImageWidth = FrontImage.PhysicalDimension.Width;
            double UploadedImageHeight = FrontImage.PhysicalDimension.Height;
            double isoscalar = 0;
            double newWidth = 0;
            double newHeight = 0;

            isoscalar = Math.Min((200 / UploadedImageWidth), (200 / UploadedImageHeight));
            newWidth = isoscalar * UploadedImageWidth;
            newHeight = isoscalar * UploadedImageHeight;


            int nwidth = 0;
            int wheight = 0;
            nwidth = Convert.ToInt32(newWidth);
            wheight = Convert.ToInt32(newHeight);

            int x = 0;
            int y = 0;
            x = (200 - nwidth) / 2;
            y = (200 - wheight) / 2;

            Bitmap newImage = default(Bitmap);
            newImage = new Bitmap(200, 200);
            newImage.SetResolution(72, 72);
            //web resolution;
            //create a graphics object 
            Graphics gr = default(Graphics);
            gr = Graphics.FromImage(newImage);
            //just in case it's a transparent GIF force the bg to white
            SolidBrush sb = default(SolidBrush);
            sb = new SolidBrush(System.Drawing.Color.Transparent);
            //sb = New SolidBrush(System.Drawing.Color.Transparent)
            gr.FillRectangle(sb, 0, 0, newImage.Width, newImage.Height);
            //Re-draw the image to the specified height and width
            gr.DrawImage(FrontImage, x, y, nwidth, wheight);
            newImage.Save(Server.MapPath("../Brand/") + concat + ext);
            strDoc = "Brand/" + concat + ext;
        }
        else
        {
            if (lblId.Text != "")
            {
                strDoc = ViewState["img"].ToString();
            }
            else if (imgPhoto.ImageUrl != "")
            {
                // lblMsg.Text = "Please Select Image";               
            }
            else
            {
                lblMsg.Text = "Please Select Image";
                return;
            }
        }

        if (string.IsNullOrEmpty(lblId.Text))
        {
            if (cls.CheckExistField("CheckExistField", "Brand", "BrandName", txtbrandname.Text.Trim(), "and IsActive = 1"))
            {
                lblMsg.Text = "This Brand already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Insert_Brand", new SqlParameter("@BrandName", txtbrandname.Text),
                    new SqlParameter("@Image", strDoc),
                    new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Details inserted successfully.";
                BindBrand();
            }
        }
        else
        {
            if (cls.CheckExistField("CheckExistField", "Brand", "BrandName", txtbrandname.Text.Trim(), "and Id <> " + lblId.Text + " and IsActive = 1"))
            {
                lblMsg.Text = "This Brand already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Update_Brand", new SqlParameter("@Id", lblId.Text),
                   new SqlParameter("@BrandName", txtbrandname.Text),
                    new SqlParameter("@Image", strDoc),
                    new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Details updated successfully.";
                BindBrand();
            }
        }
    }
    protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditGroup")
        {
            imgPhoto.Visible = true;
            DataSet ds = new DataSet();
            ds = cls.ReturnDataSet("sp_RetriveDataWithField",
                 new SqlParameter("@Fields", "*"),
                new SqlParameter("@TblNm", "Brand"),
           new SqlParameter("@WhereClause", "Brand where Id ='" + e.CommandArgument + "' and Brand.IsActive = 1"));

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();
                txtbrandname.Text = ds.Tables[0].Rows[0]["BrandName"].ToString();
                imgPhoto.ImageUrl = "../" + ds.Tables[0].Rows[0]["Image"].ToString();
                ViewState["img"] = ds.Tables[0].Rows[0]["Image"].ToString();
            }
        }

        if (e.CommandName == "DeleteGroup")
        {

            if (cls.CheckExistField("CheckExistField", "Product", "BrandId", e.CommandArgument.ToString(), "and IsActive = 1"))
            {
                lblMsg.Text = "This Brand exists in Product. First delete products related to this Brand.";
                return;
            }
            else
            {
                cls.ExecuteDA("DeleteRecord", new SqlParameter("@TblNm", "Brand"),
                                       new SqlParameter("@strField", "Id"),
                                       new SqlParameter("@strValue", e.CommandArgument.ToString()));

                clearall();
                lblMsg.Text = "Product Brand Deleted";
                BindBrand();
            }
        }
    }
}