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
using System.Web.Services;

public partial class Admin_SubCategory : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    public static double fsalescost, fSalesPriceIncl, fshippingcost, ftaxfinalprice, ffinalcost;
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
                lblFormTitle.Text = "Product Setup";

                BindProduct();
                imgPhoto.Visible = false;
                BindBrand();
                BindSupplier();
                BindUnit();
                BindColour();
                BindSize();
                cls.BindDropDownList_blankValue(ddlCategory, "CategoryName", "Id", "bindDropdown", "ProductCategory", "where IsActive=1  ORDER BY CategoryName", "CategoryName,Id");
                ddlSubCategory.Items.Insert(0, new ListItem("- Select -", ""));
            }
        }
    }
    protected void BindSize()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_ProductSize");
        cblSizeoption.DataSource = dt;
        cblSizeoption.DataTextField = "SizeName";
        cblSizeoption.DataValueField = "SizeID";
        cblSizeoption.DataBind();
    }
    protected void BindColour()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_ProductColour");
        cblColouroption.DataSource = dt;
        cblColouroption.DataTextField = "ColourName";
        cblColouroption.DataValueField = "ColourID";
        cblColouroption.DataBind();
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls.BindDropDownList_blankValue(ddlSubCategory, "SubCategoryName", "ID", "bindDropdown", "ProductSubCategory", "where IsActive=1 and ProductCategoryId ='" + ddlCategory.SelectedValue + "' order by SubCategoryName ASC", "Id,SubCategoryName");
    }
    public void clearall()
    {
        cls.ResetFormControlValues(this.Page);
        lblId.Text = "";
        imgPhoto.ImageUrl = "";
        txtDescription.Text = "";
        txtCertification.Text = "";
        foreach (ListItem li in cblColouroption.Items)
        {
            if (li.Selected)
            {
                li.Selected = false;
            }
        }
        foreach (ListItem li in cblSizeoption.Items)
        {
            if (li.Selected)
            {
                li.Selected = false;
            }
        }
        foreach (ListItem li in rbtCOD.Items)
        {
            if (li.Selected)
            {
                li.Selected = false;
            }
        }
        foreach (ListItem li in rbtNewArriaval.Items)
        {
            if (li.Selected)
            {
                li.Selected = false;
            }
        }
        foreach (ListItem li in RbtSpecialOffer.Items)
        {
            if (li.Selected)
            {
                li.Selected = false;
            }
        }
    }
    private void BindBrand()
    {
        cls.BindDropDownList_blankValue(ddlBrand, "BrandName", "Id", "bindDropdown", "Brand", "where IsActive=1  ORDER BY BrandName", "BrandName,Id");
    }
    private void BindUnit()
    {
        cls.BindDropDownList_blankValue(ddlUnit, "Unit", "Id", "bindDropdown", "Unit", "where IsActive=1  ORDER BY Unit", "Unit,Id");
    }
    private void BindSupplier()
    {
        cls.BindDropDownList_blankValue(ddlsupplier, "SupplierName", "Id", "bindDropdown", "Supplier", "where IsActive=1  ORDER BY SupplierName", "SupplierName,Id");
    }
    private void BindProduct()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("sp_RetriveData", new SqlParameter("@TblNm", "Product"),
           new SqlParameter("@strWhereClause", "where IsActive = 1 Order By Id asc"));
        rptr.DataSource = ds;
        rptr.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (!IsSizeSet())
        {
            MsgBox("Please Select Size");
            return;
        }
        if (!IsColorSet())
        {
            MsgBox("Please Select Color");
            return;
        }

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
            newImage.Save(Server.MapPath("../Product/") + concat + ext);
            strDoc = "Product/" + concat + ext;
        }
        else
        {
            if (lblId.Text != "")
            {
                strDoc = ViewState["img"].ToString();

            }
            else
            {
                lblMsg.Text = "Please Select Image";
                return;
            }
        }
        //checking isarrival or not
        bool isaarival;
        if (rbtNewArriaval.SelectedValue == "1")
        {
            isaarival = true;
        }
        else
        {
            isaarival = false;
        }
        //checking special offer or not
        bool isspecial;
        if (RbtSpecialOffer.SelectedValue == "1")
        {
            isspecial = true;
        }
        else
        {
            isspecial = false;
        }

        //checking ISCOD or not
        bool iscod;
        if (rbtCOD.SelectedValue == "1")
        {
            iscod = true;
        }
        else
        {
            iscod = false;
        }


        double mrp = 0;
        if (txtMRP.Text != "")
        {
            mrp = Convert.ToDouble(txtMRP.Text);
        }

        double mqty = 0;
        if (txtMinOrdrQty.Text != "")
        {
            mqty = Convert.ToDouble(txtMinOrdrQty.Text);
        }
        //calling calucluate price funation if value has been zero to calculate it once again
        double[] result;
        result=CalculateDiscount(txtProductcost.Text, txtmargin.Text, txtsalescost.Text, txtfinalcost.Text, txttax.Text, txtProductweight.Text, txtSalesPriceIncl.Text, txtshippingcost.Text, txtDiscount.Text);

        //assign values to textbox
       // return new[] { salescost, SalesPriceIncl, shippingcost, taxfinalprice, finalcost };
        if (result.Length > 0)
        {
            txtsalescost.Text = result[0].ToString();
            txtSalesPriceIncl.Text = result[1].ToString();
            txtshippingcost.Text = result[2].ToString();
            txttaxfinalprice.Text = result[3].ToString();
            txtfinalcost.Text = result[4].ToString();
        }
       
            if (string.IsNullOrEmpty(lblId.Text))
            {
                if (cls.CheckExistField("CheckExistField", "Product", "ProductName", txtProductname.Text, "and IsActive = 1 and ProductCategoryID ='" + ddlCategory.SelectedValue + "' and ProductSubCategoryID ='" + ddlSubCategory.SelectedValue + "'"))
                {
                    lblMsg.Text = "This product already exists.";
                    return;
                }
                else
                {
                    Int32 pid;
                    pid = (Int32)cls.ReturnScaler("Insert_Product", new SqlParameter("@ProductCategoryId", Convert.ToInt32(ddlCategory.SelectedValue.ToString())),
                                                new SqlParameter("@ProductSubCategoryId", Convert.ToInt32(ddlSubCategory.SelectedValue.ToString())),
                                                new SqlParameter("@SupplierId", Convert.ToInt32(ddlsupplier.SelectedValue.ToString())),
                                                new SqlParameter("@BrandId", Convert.ToInt32(ddlBrand.SelectedValue.ToString())),
                                                new SqlParameter("@ProductName", txtProductname.Text),
                                              new SqlParameter("@Productdescp", txtProductline2.Text),
                                                new SqlParameter("@ProductCode", txtProductCode.Text),
                                                new SqlParameter("@SupplierProductCode", txtSupProductcode.Text),
                                                new SqlParameter("@PackSize", txtpacksize.Text),
                                               new SqlParameter("@ProductCost", Convert.ToDouble(txtProductcost.Text)),
                                               new SqlParameter("@UnitId", Convert.ToInt32(ddlUnit.SelectedValue.ToString())),
                                               new SqlParameter("@ProductWeight", Convert.ToDouble(txtProductweight.Text)),
                                               new SqlParameter("@Image", strDoc),
                                               new SqlParameter("@KeyWords", txtkeywords.Text),
                                               new SqlParameter("@Certification", txtCertification.Text),
                                               new SqlParameter("@Description", txtDescription.Text),
                                               new SqlParameter("@Margin", txtmargin.Text),
                                               new SqlParameter("@SalePrice", Convert.ToDouble(txtsalescost.Text)),
                                               new SqlParameter("@Tax", Convert.ToDouble(txttax.Text)),
                                               new SqlParameter("@SalesPrice_Incl", Convert.ToDouble(txtSalesPriceIncl.Text)),
                                               new SqlParameter("@MRP", mrp),
                                               new SqlParameter("@Discount", Convert.ToDouble(txtDiscount.Text)),
                                               new SqlParameter("@ShippingCost", Convert.ToDouble(txtshippingcost.Text)),
                                               new SqlParameter("@FinalSellingPrice", Convert.ToDouble(txtfinalcost.Text)),
                                               new SqlParameter("@TaxFinalPrice", Convert.ToDouble(txttaxfinalprice.Text)),
                                               new SqlParameter("@Quantity", mqty),
                                               new SqlParameter("@ShippingDays", txtShippngDays.Text),
                                               new SqlParameter("@IsNewArrival", isaarival),
                                               new SqlParameter("@IsSpecialOffer", isspecial),
                                               new SqlParameter("@IsCOD", iscod),
                                               new SqlParameter("@IsActive", 1));

                    //insert into product size and product Colour
                    InsertProdSize(pid);
                    InsertProdColour(pid);

                    clearall();
                    lblMsg.Text = "Details inserted successfully.";
                    BindProduct();
                }
            }
            else
            {
                cls.ExecuteDA("Update_Product", new SqlParameter("@Id", Convert.ToInt32(lblId.Text)),
                                           new SqlParameter("@ProductCategoryId", Convert.ToInt32(ddlCategory.SelectedValue.ToString())),
                                            new SqlParameter("@ProductSubCategoryId", Convert.ToInt32(ddlSubCategory.SelectedValue.ToString())),
                                            new SqlParameter("@SupplierId", Convert.ToInt32(ddlsupplier.SelectedValue.ToString())),
                                            new SqlParameter("@BrandId", Convert.ToInt32(ddlBrand.SelectedValue.ToString())),
                                            new SqlParameter("@ProductName", txtProductname.Text),
                                        new SqlParameter("@Productdescp", txtProductline2.Text),
                                            new SqlParameter("@ProductCode", txtProductCode.Text),
                                            new SqlParameter("@SupplierProductCode", txtSupProductcode.Text),
                                            new SqlParameter("@PackSize", txtpacksize.Text),
                                            new SqlParameter("@ProductCost", Convert.ToDouble(txtProductcost.Text)),
                                               new SqlParameter("@UnitId", Convert.ToInt32(ddlUnit.SelectedValue.ToString())),
                                               new SqlParameter("@ProductWeight", Convert.ToDouble(txtProductweight.Text)),
                                               new SqlParameter("@Image", strDoc),
                                               new SqlParameter("@KeyWords", txtkeywords.Text),
                                               new SqlParameter("@Certification", txtCertification.Text),
                                               new SqlParameter("@Description", txtDescription.Text),
                                               new SqlParameter("@Margin", txtmargin.Text),
                                               new SqlParameter("@SalePrice", Convert.ToDouble(txtsalescost.Text)),
                                               new SqlParameter("@Tax", Convert.ToDouble(txttax.Text)),
                                               new SqlParameter("@SalesPrice_Incl", Convert.ToDouble(txtSalesPriceIncl.Text)),
                                               new SqlParameter("@MRP", mrp),
                                               new SqlParameter("@Discount", Convert.ToDouble(txtDiscount.Text)),
                                               new SqlParameter("@ShippingCost", Convert.ToDouble(txtshippingcost.Text)),
                                               new SqlParameter("@FinalSellingPrice", Convert.ToDouble(txtfinalcost.Text)),
                                               new SqlParameter("@TaxFinalPrice", Convert.ToDouble(txttaxfinalprice.Text)),
                                               new SqlParameter("@Quantity", mqty),
                                               new SqlParameter("@ShippingDays", txtShippngDays.Text),
                                               new SqlParameter("@IsNewArrival", isaarival),
                                               new SqlParameter("@IsSpecialOffer", isspecial),
                                               new SqlParameter("@IsCOD", iscod),
                                           new SqlParameter("@IsActive", 1));

                //Update Product Size nad product Colour
                cls.ExecuteDA("Delete_ProductColour", new SqlParameter("@ProductId", Convert.ToInt32(lblId.Text)));
                InsertProdColour(Convert.ToInt32(lblId.Text));

                cls.ExecuteDA("Delete_ProductSize", new SqlParameter("@ProductId", Convert.ToInt32(lblId.Text)));
                InsertProdSize(Convert.ToInt32(lblId.Text));

                lblMsg.Text = "Details updated successfully.";
                clearall();
                BindProduct();
            }
    }

    protected void InsertProdSize(Int32 pid)
    {
        foreach (ListItem li in cblSizeoption.Items)
        {
            if (li.Selected)
            {
                cls.ExecuteDA("Insert_ProductSize", new SqlParameter("@ProductId", pid),
                                                    new SqlParameter("@SizeId", li.Value),
                                                    new SqlParameter("@IsActive", 1));
            }
        }
    }
    protected void InsertProdColour(Int32 pid)
    {
        foreach (ListItem li in cblColouroption.Items)
        {
            if (li.Selected)
            {
                cls.ExecuteDA("Insert_ProductColour", new SqlParameter("@ProductId", pid),
                                                       new SqlParameter("@ColourId", li.Value),
                                                       new SqlParameter("@IsActive", 1));
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
            string isarrival, isspecial, iscod;
            isarrival = "";
            isspecial = "";
            iscod = "";

            imgPhoto.Visible = true;
            DataSet ds = new DataSet();
            ds = cls.ReturnDataSet("sp_RetriveDataWithField",
                 new SqlParameter("@Fields", "*"),
                new SqlParameter("@TblNm", "Product"),
           new SqlParameter("@WhereClause", "Product where Id ='" + e.CommandArgument + "' and Product.IsActive = 1"));
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblId.Text = e.CommandArgument.ToString();
                ddlCategory.SelectedValue = ds.Tables[0].Rows[0]["ProductCategoryId"].ToString();
                //cls.SetSelctedDropDownListValues(ds.Tables[0].Rows[0]["ProductCategoryid"].ToString(), ddlCategory);
                // cls.SetSelctedDropDownListValues(ds.Tables[0].Rows[0]["ProductSubCategoryId"].ToString(), ddlSubCategory);

                ddlSubCategory.ClearSelection();
                cls.BindDropDownList_blankValue(ddlSubCategory, "SubCategoryName", "ID", "bindDropdown", "ProductSubCategory", "where IsActive=1 and ProductCategoryId ='" + ddlCategory.SelectedValue + "' order by SubCategoryName ASC", "Id,SubCategoryName");
                ddlSubCategory.SelectedValue = ds.Tables[0].Rows[0]["ProductSubCategoryId"].ToString();
                // ddlSubCategory.Items.FindByValue(("ProductSubCategoryID").ToString()).Selected = true;

                ddlsupplier.SelectedValue = ds.Tables[0].Rows[0]["SupplierId"].ToString();
                ddlBrand.SelectedValue = ds.Tables[0].Rows[0]["BrandId"].ToString();
                //cls.SetSelctedDropDownListValues(ds.Tables[0].Rows[0]["SupplierId"].ToString(), ddlsupplier);
                //cls.SetSelctedDropDownListValues(ds.Tables[0].Rows[0]["BrandId"].ToString(), ddlBrand);

                txtProductname.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();
                txtProductline2.Text = ds.Tables[0].Rows[0]["Productdescp"].ToString();

                txtProductCode.Text = ds.Tables[0].Rows[0]["ProductCode"].ToString();
                txtSupProductcode.Text = ds.Tables[0].Rows[0]["SupplierProductCode"].ToString();
                txtpacksize.Text = ds.Tables[0].Rows[0]["PackSize"].ToString();
                //cblSizeoption.Text = ds.Tables[0].Rows[0]["SizeOption"].ToString();

                txtProductcost.Text = ds.Tables[0].Rows[0]["ProductCost"].ToString();
                //cls.SetSelctedDropDownListValues(ds.Tables[0].Rows[0]["UnitId"].ToString(), ddlUnit);
                ddlUnit.SelectedValue = ds.Tables[0].Rows[0]["UnitId"].ToString();
                txtProductweight.Text = ds.Tables[0].Rows[0]["ProductWeight"].ToString();
                imgPhoto.ImageUrl = "../" + ds.Tables[0].Rows[0]["Image"].ToString();
                ViewState["img"] = ds.Tables[0].Rows[0]["Image"].ToString();
                txtkeywords.Text = ds.Tables[0].Rows[0]["KeyWords"].ToString();
                txtCertification.Text = ds.Tables[0].Rows[0]["Certification"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                txtmargin.Text = ds.Tables[0].Rows[0]["Margin"].ToString();

                txtsalescost.Text = ds.Tables[0].Rows[0]["SalePrice"].ToString();
                txttax.Text = ds.Tables[0].Rows[0]["Tax"].ToString();
                txtSalesPriceIncl.Text = ds.Tables[0].Rows[0]["SalesPrice_Incl"].ToString();
                txtMRP.Text = ds.Tables[0].Rows[0]["MRP"].ToString();

                txtDiscount.Text = ds.Tables[0].Rows[0]["Discount"].ToString();
                txtCalDiscount.Text = ds.Tables[0].Rows[0]["CalDiscount"].ToString();

                txtshippingcost.Text = ds.Tables[0].Rows[0]["ShippingCost"].ToString();

                txtfinalcost.Text = ds.Tables[0].Rows[0]["FinalSellingPrice"].ToString();
                txttaxfinalprice.Text = ds.Tables[0].Rows[0]["TaxFinalPrice"].ToString();
                txtMinOrdrQty.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();

                txtShippngDays.Text = ds.Tables[0].Rows[0]["ShippingDays"].ToString();

                isarrival = ds.Tables[0].Rows[0]["IsNewArrival"].ToString();
                isspecial = ds.Tables[0].Rows[0]["IsSpecialOffer"].ToString();
                iscod = ds.Tables[0].Rows[0]["IsCOD"].ToString();

                //ftaxfinalprice = Convert.ToDouble(ds.Tables[0].Rows[0]["TaxFinalPrice"]);
                //fsalescost = Convert.ToDouble(ds.Tables[0].Rows[0]["SalePrice"]);
                //fSalesPriceIncl = Convert.ToDouble(ds.Tables[0].Rows[0]["SalesPrice_Incl"]);
                //fshippingcost = Convert.ToDouble(ds.Tables[0].Rows[0]["ShippingCost"]);
                //ffinalcost = Convert.ToDouble(ds.Tables[0].Rows[0]["FinalSellingPrice"]); 

            }

            //for isnew arriaval
            if (isarrival == "True" || isarrival == "true")
            {
                rbtNewArriaval.SelectedValue = "1";
            }
            else
            {
                rbtNewArriaval.SelectedValue = "0";
            }

            //for is spcial offer
            if (isspecial == "True" || isspecial == "true")
            {
                RbtSpecialOffer.SelectedValue = "1";
            }
            else
            {
                RbtSpecialOffer.SelectedValue = "0";
            }

            //for iscod
            if (iscod == "True" || iscod == "true")
            {
                rbtCOD.SelectedValue = "1";
            }
            else
            {
                rbtCOD.SelectedValue = "0";
            }

            //retrving product colour from db
            DataTable dtcolour = new DataTable();
            dtcolour = cls.ReturnDataTable("Select_ProductColourFromPID", new SqlParameter("@PID", lblId.Text));
            foreach (DataRow dr in dtcolour.Rows)
            {
                foreach (ListItem li in cblColouroption.Items)
                {
                    if (li.Value.ToString() == dr["ColourId"].ToString())
                    {
                        li.Selected = true;
                    }
                }
            }

            DataTable dtSize = new DataTable();
            dtSize = cls.ReturnDataTable("Select_ProductSizeFromPID", new SqlParameter("@PID", lblId.Text));
            foreach (DataRow dr1 in dtSize.Rows)
            {
                foreach (ListItem li in cblSizeoption.Items)
                {
                    if (li.Value.ToString() == dr1["SizeId"].ToString())
                    {
                        li.Selected = true;
                    }
                }
            }
        }
        else if (e.CommandName == "DeleteGroup")
        {
            cls.ExecuteDA("DeleteRecord", new SqlParameter("@TblNm", "Product"),
                                   new SqlParameter("@strField", "Id"),
                                   new SqlParameter("@strValue", e.CommandArgument.ToString()));
            //cls.ExecuteNonQueryBySQLQuery("Update Product set IsActive=0 where Id=" + e.CommandArgument.ToString() + "");
            //cls.ExecuteNonQueryBySQLQuery("Update ProductColour set IsActive=0 where ProductId=" + e.CommandArgument.ToString() + "");
            // cls.ExecuteNonQueryBySQLQuery("Update ProductSize set IsActive=0 where ProductId=" + e.CommandArgument.ToString() + "");

            cls.ExecuteDA("Delete_ProductColour", new SqlParameter("@ProductId", e.CommandArgument.ToString()));

            cls.ExecuteDA("Delete_ProductSize", new SqlParameter("@ProductId", e.CommandArgument.ToString()));
            clearall();
            lblMsg.Text = "Product Deleted";
            BindProduct();
        }
        else if (e.CommandName == "SpYes")
        {
            cls.ExecuteDA("Update_IsSpecial", new SqlParameter("@Id", e.CommandArgument),
                                       new SqlParameter("@IsSpecial", true));
            lblMsg.Text = "Record Updated Successfully..";
            BindProduct();
        }
        else if (e.CommandName == "SpNo")
        {
            cls.ExecuteDA("Update_IsSpecial", new SqlParameter("@Id", e.CommandArgument),
                                       new SqlParameter("@IsSpecial", false));
            lblMsg.Text = "Record Updated Successfully..";
            BindProduct();
        }
        else if (e.CommandName == "NewYes")
        {
            cls.ExecuteDA("Update_IsNewArrival", new SqlParameter("@Id", e.CommandArgument),
                                       new SqlParameter("@IsNew", true));
            lblMsg.Text = "Record Updated Successfully..";
            BindProduct();
        }
        else if (e.CommandName == "NewNo")
        {
            cls.ExecuteDA("Update_IsNewArrival", new SqlParameter("@Id", e.CommandArgument),
                                       new SqlParameter("@IsNew", false));
            lblMsg.Text = "Record Updated Successfully..";
            BindProduct();
        }
        else if (e.CommandName == "CodYes")
        {
            cls.ExecuteDA("Update_IsCOD", new SqlParameter("@Id", e.CommandArgument),
                                       new SqlParameter("@IsCOD", true));
            lblMsg.Text = "Record Updated Successfully..";
            BindProduct();
        }
        else if (e.CommandName == "CodNo")
        {
            cls.ExecuteDA("Update_IsCOD", new SqlParameter("@Id", e.CommandArgument),
                                       new SqlParameter("@IsCOD", false));
            lblMsg.Text = "Record Updated Successfully..";
            BindProduct();
        }
    }
    //protected void txtmargin_TextChanged(object sender, EventArgs e)
    //{
    //    calculateAllCost();
    //}
    //protected void txttax_TextChanged(object sender, EventArgs e)
    //{
    //    calculateAllCost();
    //}
    //protected void txtDiscount_TextChanged(object sender, EventArgs e)
    //{
    //    calculateAllCost();
    //}
    //protected void txtProductcost_TextChanged(object sender, EventArgs e)
    //{
    //    calculateAllCost();
    //}
    //protected void txtsalescost_TextChanged(object sender, EventArgs e)
    //{
    //    calculateAllCost();
    //}
    //protected void calculateAllCost()
    //{
    //    CalculateSaleCost();
    //    CalculateSalesPrice();
    //    //CalculateDiscount();
    //}
    //protected void CalculateSaleCost()
    //{
    //    if (txtProductcost.Text != "" && txtmargin.Text != "")
    //    {
    //        txtsalescost.Text = Math.Round((Convert.ToDouble(txtProductcost.Text)) * ((100) / (100 - (Convert.ToDouble(txtmargin.Text))))).ToString("N0");
    //    }
    //}
    //protected void CalculateSalesPrice()
    //{
    //    if (txtsalescost.Text != "" && txttax.Text != "" && txtProductweight.Text != "")
    //    {
    //        if (Convert.ToDouble(txtsalescost.Text) <= 5000)
    //        {
    //            txtSalesPriceIncl.Text = Math.Round(((Convert.ToDouble(txtsalescost.Text)) * (1 + ((Convert.ToDouble(txttax.Text)) / 100))) + ((((((Convert.ToDouble(txtProductweight.Text)) / 500) * 50)) * Convert.ToDouble(1.25))) + 50).ToString("N0");
    //        }
    //        else
    //        {
    //            txtSalesPriceIncl.Text = Math.Round(((Convert.ToDouble(txtsalescost.Text) * (1 + (Convert.ToDouble(txttax.Text) / 100))) + ((Convert.ToDouble(txtProductweight.Text) / 500) * 50 * Convert.ToDouble(1.25))) + ((Convert.ToDouble(txtsalescost.Text) * (1 + (Convert.ToDouble(txttax.Text) / 100))) * Convert.ToDouble(0.02))).ToString("N0");
    //            //txtSalesPriceIncl.Text = Math.Ceiling((Convert.ToDecimal(txtsalescost.Text)) * (1 + ((Convert.ToDecimal(txttax.Text)) / 100))).ToString("N0");
    //        }
    //    }
    //}
    [WebMethod]
    public static double[] CalculateDiscount(string txtProductcost, string txtmargin, string txtsalescost, string txtfinalcost, string txttax, string txtProductweight, string txtSalesPriceIncl, string txtshippingcost, string txtDiscount)
    {
        double[] result = new double[4];
        double taxfinalprice =1;
        double salescost = 1;
        double SalesPriceIncl = 1;
        double shippingcost = 0;
        double finalcost = 1;

        //calculating sales cost
        if (txtProductcost != "" && txtmargin != "")
        {
            salescost = Math.Round((Convert.ToDouble(txtProductcost)) + ((Convert.ToDouble(txtProductcost)) * (((Convert.ToDouble(txtmargin)) / 100))));
        }
       //calculating Shipping Cost
        if (txtProductweight != "" && txtProductcost != "")
        {
            shippingcost = Math.Round((Convert.ToDouble(txtshippingcost)));
        }

        //calculating sale price
        if (txtsalescost != "" && txttax != "" && txtshippingcost !="")
        {
            if (salescost != 0)
                {
                if (Convert.ToDouble(salescost) <= 5000)
                {
                    SalesPriceIncl = Math.Round((Convert.ToDouble(salescost)) + ((Convert.ToDouble(salescost)) * (((Convert.ToDouble(txttax)) / 100))) + (Convert.ToDouble(txtshippingcost)));
                }
                else
                {
                    SalesPriceIncl = Math.Round((Convert.ToDouble(salescost)) + ((Convert.ToDouble(salescost)) * (((Convert.ToDouble(txttax)) / 100))) + (Convert.ToDouble(txtshippingcost)));
                    //txtSalesPriceIncl.Text = Math.Ceiling((Convert.ToDecimal(txtsalescost.Text)) * (1 + ((Convert.ToDecimal(txttax.Text)) / 100))).ToString("N0");
                }
            }
        }

       
       //calculating final price

        if (txtSalesPriceIncl != "" && txtDiscount != "")
        {
            finalcost = Math.Round((Convert.ToDouble(SalesPriceIncl)) - ((Convert.ToDouble(SalesPriceIncl)) * ((Convert.ToDouble(txtDiscount)) / 100)));
        }

        //calculating total discount in price
        if (finalcost != 0 && txttax != "")
        {
            taxfinalprice = Math.Round((Convert.ToDouble(finalcost)) * ((Convert.ToDouble(txttax)) / 100));
        }  

        //setting variable before return
        ftaxfinalprice = taxfinalprice;
        fsalescost = salescost;
        fSalesPriceIncl = SalesPriceIncl;
        fshippingcost = shippingcost;
        ffinalcost = finalcost;

        return new[] { salescost, SalesPriceIncl, shippingcost, taxfinalprice, finalcost };
    } 

    //protected void cbkCOD_CheckedChanged(object sender, EventArgs e)
    //{
    //    CheckBox chk = (CheckBox)sender;
    //    cls.ExecuteDA("Update_IsCOD", new SqlParameter("@Id", chk.ToolTip),
    //                                    new SqlParameter("@IsCOD", chk.Checked));
    //    lblMsg.Text = "Record Updated Successfully..";
    //    BindProduct();
    //}
    ////protected void cbkSpecial_CheckedChanged(object sender, EventArgs e)
    ////{
    ////    CheckBox chk = (CheckBox)sender;
    ////    cls.ExecuteDA("Update_IsSpecial", new SqlParameter("@Id", chk.ToolTip),
    ////                                    new SqlParameter("@IsSpecial", chk.Checked));
    ////    lblMsg.Text = "Record Updated Successfully..";
    ////    BindProduct();
    ////}
    //protected void cbkNew_CheckedChanged(object sender, EventArgs e)
    //{
    //    CheckBox chk = (CheckBox)sender;
    //    cls.ExecuteDA("Update_IsNewArrival", new SqlParameter("@Id", chk.ToolTip),
    //                                    new SqlParameter("@IsNew", chk.Checked));
    //    lblMsg.Text = "Record Updated Successfully..";
    //    BindProduct();
    //}
    protected bool IsColorSet()
    {
        foreach (ListItem li in cblColouroption.Items)
        {
            if (li.Selected)
            {
                return true;
            }
        }
        return false;
    }
    protected bool IsSizeSet()
    {
        foreach (ListItem li in cblSizeoption.Items)
        {
            if (li.Selected)
            {
                return true;
            }
        }
        return false;
    }
    public void MsgBox(string message)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            message = message.Replace("'", "'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "Message", "alert('" + message + "')", true);
        }
    }
}

