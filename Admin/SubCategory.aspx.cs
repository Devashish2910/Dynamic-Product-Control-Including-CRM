using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


public partial class Admin_SubCategory : System.Web.UI.Page
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
                lblFormTitle.Text = "Product SubCategory Setup";
                bindProductCategory();
                imgPhoto.Visible = false;
                imgBannerPhoto.Visible = false;
                BindProductSubCategory();
            }
        }
    }
    public void clearall()
    {
        cls.ResetFormControlValues(this.Page);
        lblId.Text = "";

        imgPhoto.Visible = false;
        imgBannerPhoto.Visible = false;
        lblPhoto.Text = "";
        lblPhotoBanner.Text = "";
    }
    private void BindProductSubCategory()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("RetriveData_Alias",
            new SqlParameter("@Field", "*"),
            new SqlParameter("@TblNm", "ProductSubCategory inner join ProductCategory on ProductSubCategory.ProductCategoryId=ProductCategory.Id"),
           new SqlParameter("@WhereClause", "where ProductSubCategory.IsActive = 1 Order By CategoryName asc"));
        rptr.DataSource = ds;
        rptr.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string concat = Guid.NewGuid().ToString();
        string strDoc = "";
        string strDoc1 = "";

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

            isoscalar = Math.Min((356 / UploadedImageWidth), (500 / UploadedImageHeight));
            newWidth = isoscalar * UploadedImageWidth;
            newHeight = isoscalar * UploadedImageHeight;

            int nwidth = 0;
            int wheight = 0;
            nwidth = Convert.ToInt32(newWidth);
            wheight = Convert.ToInt32(newHeight);

            int x = 0;
            int y = 0;
            x = (356 - nwidth) / 2;
            y = (500 - wheight) / 2;

            Bitmap newImage = default(Bitmap);
            newImage = new Bitmap(356, 500);
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
            newImage.Save(Server.MapPath("../SubCategory/") + concat + ext);
            strDoc = "SubCategory/" + concat + ext;
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

        if (fupBannerPhoto.HasFile != false)
        {
            string ext = null;
            ext = Path.GetExtension(fupBannerPhoto.PostedFile.FileName).ToLower();
            if ((ext != ".jpg") & (ext != ".jpeg") & (ext != ".gif") & (ext != ".png") & (ext != ".bmp"))
            {
                lblMsg.Text = "Please select jpg or gif or png or bmp  files only";
                fupBannerPhoto.Focus();
                return;
            }

            //''''''Create an image object from the uploaded file
            System.Drawing.Image FrontImage = null;
            FrontImage = System.Drawing.Image.FromStream(fupBannerPhoto.PostedFile.InputStream);
            ///'''''''''''Determine width and height of uploaded image
            double UploadedImageWidth = FrontImage.PhysicalDimension.Width;
            double UploadedImageHeight = FrontImage.PhysicalDimension.Height;
            double isoscalar = 0;
            double newWidth = 0;
            double newHeight = 0;

            isoscalar = Math.Min((1170 / UploadedImageWidth), (150 / UploadedImageHeight));
            newWidth = isoscalar * UploadedImageWidth;
            newHeight = isoscalar * UploadedImageHeight;


            int nwidth = 0;
            int wheight = 0;
            nwidth = Convert.ToInt32(newWidth);
            wheight = Convert.ToInt32(newHeight);

            int x = 0;
            int y = 0;
            x = (1170 - nwidth) / 2;
            y = (150 - wheight) / 2;

            Bitmap newImage = default(Bitmap);
            newImage = new Bitmap(1170, 150);
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
            newImage.Save(Server.MapPath("../SubCategoryBanner/") + concat + ext);
            strDoc1 = "SubCategoryBanner/" + concat + ext;
        }
        else
        {
            if (lblId.Text != "")
            {
                strDoc1 = ViewState["imgBanner"].ToString();
            }
            else if (imgBannerPhoto.ImageUrl != "")
            {
                // lblMsg.Text = "Please Select Image";               
            }
            else
            {
                lblMsg.Text = "Please Select Banner Image";
                return;
            }
        }

        if (string.IsNullOrEmpty(lblId.Text))
        {
            if (cls.CheckExistField("CheckExistField", "ProductSubCategory", "SubCategoryName", txtSubCategoryName.Text, "and IsActive = 1 and ProductCategoryId='" + ddlCategory.SelectedValue + "'"))
            {
                lblMsg.Text = "This SubCategory Name already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Insert_ProductSubCategory", new SqlParameter("@ProductCategoryId", ddlCategory.SelectedValue),
                                                            new SqlParameter("@SubCategoryName", txtSubCategoryName.Text),
                                                             new SqlParameter("@Image", strDoc),
                                                           new SqlParameter("@ImageBanner", strDoc1),
                                                            new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Details inserted successfully.";
                BindProductSubCategory();
            }
        }
        else
        {
            if (cls.CheckExistField("CheckExistField", "ProductSubCategory", "SubCategoryName", txtSubCategoryName.Text, "and IsActive = 1 and ProductCategoryId='" + ddlCategory.SelectedValue + "' and Id <> " + lblId.Text + ""))
            {
                lblMsg.Text = "This SubCategory Name already exists.";
                return;
            }
            else
            {
                cls.ExecuteDA("Update_ProductSubCategory", new SqlParameter("@Id", lblId.Text),
                                                        new SqlParameter("@ProductCategoryId", ddlCategory.SelectedValue),
                                                        new SqlParameter("@SubCategoryName", txtSubCategoryName.Text),
                                                        new SqlParameter("@Image", strDoc),
                                                        new SqlParameter("@ImageBanner", strDoc1),
                                                        new SqlParameter("@IsActive", 1));

                //update in imagemap table
                cls.ExecuteDA("Update_ImageMapSubCategory", new SqlParameter("@Id", lblId.Text), new SqlParameter("@url", strDoc1));

                clearall();
                lblMsg.Text = "Details updated successfully.";
                BindProductSubCategory();
            }
        }
    }
    void bindProductCategory()
    {
        cls.BindDropDownList_blankValue(ddlCategory, "CategoryName", "Id", "bindDropdown", "ProductCategory", "where IsActive=1  ORDER BY CategoryName", "CategoryName,Id");
    }
    protected void rptr_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "EditGroup")
        {
            DataSet ds = new DataSet();
            ds = cls.ReturnDataSet("sp_RetriveDataWithField",
                 new SqlParameter("@Fields", "*"),
                new SqlParameter("@TblNm", "ProductSubCategory"),
           new SqlParameter("@WhereClause", "ProductSubCategory where Id ='" + e.CommandArgument + "' and ProductSubCategory.IsActive = 1"));
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();
                cls.SetSelctedDropDownListValues(ds.Tables[0].Rows[0]["ProductCategoryid"].ToString(), ddlCategory);
                txtSubCategoryName.Text = ds.Tables[0].Rows[0]["SubCategoryName"].ToString();
                imgPhoto.ImageUrl = "../" + ds.Tables[0].Rows[0]["Image"].ToString();
                ViewState["img"] = ds.Tables[0].Rows[0]["Image"].ToString();
                imgBannerPhoto.ImageUrl = "../" + ds.Tables[0].Rows[0]["ImageBanner"].ToString();
                ViewState["imgBanner"] = ds.Tables[0].Rows[0]["ImageBanner"].ToString();

                imgPhoto.Visible = true;
                imgBannerPhoto.Visible = true;
            }
        }
        if (e.CommandName == "DeleteGroup")
        {
            if (cls.CheckExistField("CheckExistField", "Product", "ProductSubCategoryId", e.CommandArgument.ToString(), "and IsActive = 1"))
            {
                lblMsg.Text = "This SubCategory exists in Product. First delete products related to this SubCategory.";
                return;
            }
            else
            {
                cls.ExecuteDA("DeleteRecord", new SqlParameter("@TblNm", "ProductSubCategory"),
                                       new SqlParameter("@strField", "Id"),
                                       new SqlParameter("@strValue", e.CommandArgument.ToString()));
                clearall();
                lblMsg.Text = "Product Sub Category Deleted";
                BindProductSubCategory();

                cls.ExecuteNonQueryBySQLQuery("delete from SubCategoryImageMap where SubCategoryId='"+e.CommandArgument.ToString()+"'");               
            }
        }
    }
}