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

public partial class Admin_ManageAdvertisement : System.Web.UI.Page
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
                lblFormTitle.Text = "Manage Advertisement";

                BindAdvertisement();
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
    private void BindAdvertisement()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "ManageAdvertisement"),
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

            isoscalar = Math.Min((550 / UploadedImageWidth), (350 / UploadedImageHeight));
            newWidth = isoscalar * UploadedImageWidth;
            newHeight = isoscalar * UploadedImageHeight;


            int nwidth = 0;
            int wheight = 0;
            nwidth = Convert.ToInt32(newWidth);
            wheight = Convert.ToInt32(newHeight);

            int x = 0;
            int y = 0;
            x = (550 - nwidth) / 2;
            y = (350 - wheight) / 2;

            Bitmap newImage = default(Bitmap);
            newImage = new Bitmap(550, 350);
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
            newImage.Save(Server.MapPath("../Advertisement/") + concat + ext);
            strDoc = "Advertisement/" + concat + ext;
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

                cls.ExecuteDA("Insert_ManageAdvertisement",
                    new SqlParameter("@Image", strDoc),
                    new SqlParameter("@Caption", txtCaption.Text),
                    new SqlParameter("@Url", txtUrl.Text),
                    new SqlParameter("@IsActive", 1));

                clearall();
                lblMsg.Text = "Advertisement Details inserted successfully.";
                BindAdvertisement();

        }
        else
        {

                cls.ExecuteDA("Update_ManageAdvertisement", 
                    new SqlParameter("@Id", lblId.Text),
                    new SqlParameter("@Image", strDoc),
                    new SqlParameter("@Caption", txtCaption.Text),
                    new SqlParameter("@Url", txtUrl.Text),
                    new SqlParameter("@IsActive", 1));

                //update in imagemap table
                cls.ExecuteDA("Update_ImageMapAdv", new SqlParameter("@Id", lblId.Text), new SqlParameter("@url", strDoc));
                clearall();
                lblMsg.Text = "Advertisement Details updated successfully.";
                BindAdvertisement();

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
                new SqlParameter("@TblNm", "ManageAdvertisement"),
           new SqlParameter("@WhereClause", "ManageAdvertisement where Id ='" + e.CommandArgument + "' and ManageAdvertisement.IsActive = 1"));

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();
                imgPhoto.ImageUrl = "../" + ds.Tables[0].Rows[0]["Image"].ToString();
                txtCaption.Text = ds.Tables[0].Rows[0]["Caption"].ToString();
                txtUrl.Text = ds.Tables[0].Rows[0]["Url"].ToString();
                ViewState["img"] = ds.Tables[0].Rows[0]["Image"].ToString();
            }
        }

        if (e.CommandName == "DeleteGroup")
        {
            cls.ExecuteDA("DeleteRecord", 
                                   new SqlParameter("@TblNm", "ManageAdvertisement"),
                                   new SqlParameter("@strField", "Id"),
                                   new SqlParameter("@strValue", e.CommandArgument.ToString()));

            clearall();
            lblMsg.Text = "Advertisement Details Deleted Successfully";
            BindAdvertisement();

            cls.ExecuteNonQueryBySQLQuery("delete from AdvImageMap where AdvId='" + e.CommandArgument.ToString() + "'");
        }
    }
}