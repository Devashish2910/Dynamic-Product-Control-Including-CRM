using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Net.Mail;
using ASPSnippets.FaceBookAPI;
using System.Web.Script.Serialization;
using ASPSnippets.LinkedInAPI;
using System.Net;
public partial class Checkout_Login : System.Web.UI.Page
{

    Clsconnection cls = new Clsconnection();
    clsAddToCart clsCart ;
    BillingShippingDetails clsBSD;
    clsWishlist clsWishlist;
    StringBuilder strMailHtml;

    string ProductId, CategoryName, SubCategoryName, ProductName, Productdescp, BrandName, SupplierName, Unit, ColourName, SizeName, ProductCode, SupplierProductCode, PackSize, Image, Certification, Description, ShippingDays;
    double ProductCost, ProductWeight, Margin, SalePrice, Tax, SalesPrice_Incl, MRP, Discount, CalDiscount, ShippingCost, FinalSellingPrice, TaxFinalPrice, MinQty, Qty, Price;
    bool IsCOD;
    DataTable dtUser;

    /*
   social Login
   */
    string sname, semail, spassword;

    public string Client_ID = "";
    public string Return_url = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Cart"] != null)
        {
            clsCart = new clsAddToCart();
            if (clsCart.TotalItems() <= 0)
            {
                Response.Redirect("MemberDashboard.aspx");
            }
        }
        FaceBookConnect.API_Key = "fadfadfaadd"; // Facebook App Key        
        FaceBookConnect.API_Secret = "fdafaddffa";// Facebook Secret App Key

        LinkedInConnect.APIKey = "fadfad";
        LinkedInConnect.APISecret = "fadfafafad";
        LinkedInConnect.RedirectUrl = Request.Url.AbsoluteUri.Split('?')[0];

        //Client_ID = ConfigurationManager.AppSettings["google_clientId"].ToString();
        //Return_url = ConfigurationManager.AppSettings["google_RedirectUrl"].ToString();


        if (!IsPostBack)
        {
            BindOrderSummary();
            if (Session["loginusing"] != null)
            {
                if (Session["loginusing"].ToString() == "facebook")
                {
                    fblogin();
                }
                else if (Session["loginusing"].ToString() == "linkedin")
                {
                    linkedinlogin();
                }
                else if (Session["loginusing"].ToString() == "twitter")
                {
                    twitterlogin();
                }
            }
            gpluslogin();
        }
        //if (Session["MemberInfo"] != null)
        //{
        //    Response.Redirect("Checkout_Shipping.aspx");
        //}
    }
    protected void BindOrderSummary()
    {
        clsCart = new clsAddToCart();
        lblTotalItems.Text = clsCart.TotalItems().ToString();
        lblTotalAmount.Text = "Rs. " + Math.Round(clsCart.TotalPrice()).ToString();
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        GenerateColumns();
        dtUser.Rows.Add(0, "", txtEmailR.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 1, 1);
        Session["MemberInfo"] = dtUser;
        BindBillingInfo();
        Response.Redirect("Checkout_Shipping.aspx");
        //if (cls.CheckExistField("CheckExistField", "Members", "Email", txtEmailR.Text.Trim(), "and IsActive = 1"))
        //{
        //    MsgBox("Member Already Registered With this email Id.");
        //    return;
        //}
        //else
        //{
        //    cls.ExecuteDA("Insert_Members", new SqlParameter("@Name", txtName.Text.Trim()),
        //                                                             new SqlParameter("@Email", txtEmailR.Text.Trim()),
        //                                                              new SqlParameter("@Password", txtPasswordR.Text.Trim()),
        //                                                               new SqlParameter("@Company", txtCompany.Text.Trim()),
        //                                                                new SqlParameter("@Contact", txtMobile.Text.Trim()));
        //    Binduser("R");
        //}
    }
    protected void GenerateColumns()
    {
        dtUser = new DataTable();
        dtUser.Columns.Add("MemberId", Type.GetType("System.Int32"));
        dtUser.Columns.Add("Name", Type.GetType("System.String"));
        dtUser.Columns.Add("Email", Type.GetType("System.String"));
        dtUser.Columns.Add("Password", Type.GetType("System.String"));
        dtUser.Columns.Add("Company", Type.GetType("System.String"));
        dtUser.Columns.Add("Contact", Type.GetType("System.String"));
        dtUser.Columns.Add("Address1", Type.GetType("System.String"));
        dtUser.Columns.Add("Address2", Type.GetType("System.String"));
        dtUser.Columns.Add("City", Type.GetType("System.String"));
        dtUser.Columns.Add("State", Type.GetType("System.String"));
        dtUser.Columns.Add("Country", Type.GetType("System.String"));
        dtUser.Columns.Add("ZipCode", Type.GetType("System.String"));
        dtUser.Columns.Add("Tinno", Type.GetType("System.String"));
        dtUser.Columns.Add("Cstno", Type.GetType("System.String"));
        dtUser.Columns.Add("BCompany", Type.GetType("System.String"));
        dtUser.Columns.Add("BContact", Type.GetType("System.String"));
        dtUser.Columns.Add("BAddress1", Type.GetType("System.String"));
        dtUser.Columns.Add("BAddress2", Type.GetType("System.String"));
        dtUser.Columns.Add("BCity", Type.GetType("System.String"));
        dtUser.Columns.Add("BState", Type.GetType("System.String"));
        dtUser.Columns.Add("BCountry", Type.GetType("System.String"));
        dtUser.Columns.Add("BZipCode", Type.GetType("System.String"));
        dtUser.Columns.Add("RegisteredDate", Type.GetType("System.String"));
        dtUser.Columns.Add("CurrentLoginDate", Type.GetType("System.String"));
        dtUser.Columns.Add("LastLoginDate", Type.GetType("System.String"));
        dtUser.Columns.Add("LastPasswordChangeDate", Type.GetType("System.String"));
        dtUser.Columns.Add("IsApproved", Type.GetType("System.Boolean"));
        dtUser.Columns.Add("IsActive", Type.GetType("System.Boolean"));

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Binduser("L", txtEmailL.Text.Trim(), txtPasswordL.Text.Trim());
    }
    protected void Binduser(string mode, string email, string password)
    {

        dtUser = new DataTable();
        if (mode == "L")
        {
            dtUser = cls.ReturnDataTable("Login_MembersLogin", new SqlParameter("@Email", email), new SqlParameter("@Password", password));
        }
        else
        {
            // dtUser = cls.ReturnDataTable("Login_MembersLogin", new SqlParameter("@Email", txtEmailR.Text.Trim()), new SqlParameter("@Password", txtPasswordR.Text.Trim()));
        }

        if (dtUser.Rows.Count > 0)
        {
            if (dtUser.Rows[0]["memberId"].ToString() == "0")
            {
                MsgBox("Invalid EmailId or Password");
                return;
            }
            else
            {
                Session["MemberInfo"] = dtUser;
                BindBillingInfo();
                Session["CameAgain"] = "1";
                BindWishList(Convert.ToInt32(dtUser.Rows[0]["MemberId"]));
                //if (Session["CameFrom"] != null)
                //{
                //    if (Session["CameFrom"].ToString() == "CheckOut")
                //    {
                //        Response.Redirect("CheckOut.aspx");
                //    }
                //    else if (Session["CameFrom"].ToString() == "Wishlist")
                //    {
                //        Response.Redirect("WishList.aspx");
                //    }     
                //}
                Response.Redirect("Checkout_Shipping.aspx");
            }
        }
        else
        {
            MsgBox("Invalid EmailId or Password");
            return;
        }
    }
    protected void BindBillingInfo()
    {
        clsBSD = new BillingShippingDetails();
        DataTable dtBill = new DataTable();
        dtBill = clsBSD.BindBillShip();

        DataTable dtMember = new DataTable();
        dtMember = (DataTable)Session["MemberInfo"];

        if (dtBill.Rows.Count > 0)
        {
            clsBSD.RemoveItem(0);
        }
        foreach (DataRow dr in dtMember.Rows)
        {
            clsBSD.AddToBillShipTable(dr["Tinno"].ToString(), dr["Cstno"].ToString(), dr["BCompany"].ToString(), dr["BContact"].ToString(), dr["BAddress1"].ToString(), dr["BAddress2"].ToString(), dr["BCity"].ToString(), dr["BState"].ToString(), dr["BCountry"].ToString(), dr["BZipcode"].ToString(), dr["Name"].ToString(), dr["Email"].ToString(), dr["Company"].ToString(), dr["Contact"].ToString(), dr["Address1"].ToString(), dr["Address2"].ToString(), dr["City"].ToString(), dr["State"].ToString(), dr["Country"].ToString(), dr["Zipcode"].ToString());
        }
    }
    protected void BindWishList(int MemberId)
    {
        clsWishlist = new clsWishlist();
        DataTable dtWishList = new DataTable();
        dtWishList = cls.ReturnDataTable("Select_WishListOnMemberId", new SqlParameter("@MemberId", MemberId));

        // retrived from wishlist db

        //foreach (DataRow drWishList in dtWishList.Rows)
        //{
        //    ProductId = drWishList["ProductId"].ToString();
        //    CategoryName = drWishList["CategoryName"].ToString();
        //    SubCategoryName = drWishList["SubCategoryName"].ToString();
        //    ProductName = drWishList["ProductName"].ToString();
        //    Productdescp = drWishList["Productdescp"].ToString();
        //    BrandName = drWishList["BrandName"].ToString();
        //    SupplierName = drWishList["SupplierName"].ToString();
        //    Unit = drWishList["Unit"].ToString();
        //    ProductCode = drWishList["ProductCode"].ToString();
        //    SupplierProductCode = drWishList["SupplierProductCode"].ToString();
        //    PackSize = drWishList["PackSize"].ToString();
        //    ProductCost = Convert.ToDouble(drWishList["ProductCost"].ToString());
        //    ProductWeight = Convert.ToDouble(drWishList["ProductWeight"].ToString());
        //    Image = drWishList["Image"].ToString();
        //    Certification = drWishList["Certification"].ToString();
        //    Description = drWishList["Description"].ToString();
        //    Margin = Convert.ToDouble(drWishList["Margin"].ToString());
        //    SalePrice = Convert.ToDouble(drWishList["SalePrice"].ToString());
        //    Tax = Convert.ToDouble(drWishList["Tax"].ToString());
        //    SalesPrice_Incl = Convert.ToDouble(drWishList["SalesPrice_Incl"].ToString());
        //    MRP = Convert.ToDouble(drWishList["MRP"].ToString());
        //    Discount = Convert.ToDouble(drWishList["Discount"].ToString());
        //    CalDiscount = Convert.ToDouble(drWishList["CalDiscount"].ToString());
        //    ShippingCost = Convert.ToDouble(drWishList["ShippingCost"].ToString());
        //    FinalSellingPrice = Convert.ToDouble(drWishList["FinalSellingPrice"].ToString());
        //    TaxFinalPrice = Convert.ToDouble(drWishList["TaxFinalPrice"].ToString());
        //    MinQty = Convert.ToDouble(drWishList["Quantity"].ToString());
        //    ShippingDays = drWishList["ShippingDays"].ToString();
        //    IsCOD = Convert.ToBoolean(drWishList["IsCOD"]);
        //    ColourName = drWishList["ColourName"].ToString();
        //    SizeName = drWishList["SizeName"].ToString();

        //    Price = MinQty * FinalSellingPrice;

        //    if (clsWishlist.FindExistItemWithSizeColor(ProductId, SizeName, ColourName))
        //    {
        //        clsWishlist.UpdateQtyAndPriceWithSizeColor(ProductId, Qty, FinalSellingPrice, SizeName, ColourName);
        //    }
        //    else
        //    {
        //        clsWishlist.AddToWishlist(ProductId, CategoryName, SubCategoryName, ProductName, Productdescp, BrandName, SupplierName, Unit, ColourName, SizeName, ProductCode, SupplierProductCode, PackSize, ProductCost, ProductWeight, Image, Certification, Description, Margin, SalePrice, Tax, SalesPrice_Incl, MRP, Discount, CalDiscount, ShippingCost, FinalSellingPrice, TaxFinalPrice, MinQty, ShippingDays, IsCOD, Price);
        //    }
        //}      

        //retrving from product db

        DataTable dtproduct;
        dtproduct = new DataTable();
        foreach (DataRow drWishList in dtWishList.Rows)
        {
            ProductId = drWishList["ProductId"].ToString();
            ColourName = drWishList["ColourName"].ToString();
            SizeName = drWishList["SizeName"].ToString();

            dtproduct = cls.ReturnDataTable("Select_ProductDetailOnId", new SqlParameter("@pid", ProductId));

            if (dtproduct.Rows.Count <= 0)
            {
                //MsgBox("This Product is no longer available on timeoffice");
                //return;
            }
            else
            {
                foreach (DataRow dr in dtproduct.Rows)
                {
                    ProductId = dr["Id"].ToString();
                    CategoryName = dr["CategoryName"].ToString();
                    SubCategoryName = dr["SubCategoryName"].ToString();
                    ProductName = dr["ProductName"].ToString();
                    Productdescp = dr["Productdescp"].ToString();
                    BrandName = dr["BrandName"].ToString();
                    SupplierName = dr["SupplierName"].ToString();
                    Unit = dr["Unit"].ToString();
                    ProductCode = dr["ProductCode"].ToString();
                    SupplierProductCode = dr["SupplierProductCode"].ToString();
                    PackSize = dr["PackSize"].ToString();
                    ProductCost = Convert.ToDouble(dr["ProductCost"].ToString());
                    ProductWeight = Convert.ToDouble(dr["ProductWeight"].ToString());
                    Image = dr["Image"].ToString();
                    Certification = dr["Certification"].ToString();
                    Description = dr["Description"].ToString();
                    Margin = Convert.ToDouble(dr["Margin"].ToString());
                    SalePrice = Convert.ToDouble(dr["SalePrice"].ToString());
                    Tax = Convert.ToDouble(dr["Tax"].ToString());
                    SalesPrice_Incl = Convert.ToDouble(dr["SalesPrice_Incl"].ToString());
                    MRP = Convert.ToDouble(dr["MRP"].ToString());
                    Discount = Convert.ToDouble(dr["Discount"].ToString());
                    CalDiscount = Convert.ToDouble(dr["CalDiscount"].ToString());
                    ShippingCost = Convert.ToDouble(dr["ShippingCost"].ToString());
                    FinalSellingPrice = Convert.ToDouble(dr["FinalSellingPrice"].ToString());
                    TaxFinalPrice = Convert.ToDouble(dr["TaxFinalPrice"].ToString());
                    MinQty = Convert.ToDouble(dr["Quantity"].ToString());
                    ShippingDays = dr["ShippingDays"].ToString();
                    IsCOD = Convert.ToBoolean(dr["IsCOD"]);
                }
                Price = MinQty * FinalSellingPrice;
                if (clsWishlist.FindExistItemWithSizeColor(ProductId, SizeName, ColourName))
                {
                    clsWishlist.UpdateQtyAndPriceWithSizeColor(ProductId, MinQty, FinalSellingPrice, SizeName, ColourName);
                }
                else
                {
                    clsWishlist.AddToWishlist(ProductId, CategoryName, SubCategoryName, ProductName, Productdescp, BrandName, SupplierName, Unit, ColourName, SizeName, ProductCode, SupplierProductCode, PackSize, ProductCost, ProductWeight, Image, Certification, Description, Margin, SalePrice, Tax, SalesPrice_Incl, MRP, Discount, CalDiscount, ShippingCost, FinalSellingPrice, TaxFinalPrice, MinQty, ShippingDays, IsCOD, Price);
                }
            }
        }
    }

    protected void fblogin()
    {
        try
        {
            if (Request.QueryString["error"] == "access_denied")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('User has denied access.')", true);
                return;
            }
            string code = Request.QueryString["code"];
            if (!string.IsNullOrEmpty(code))
            {
                string data = FaceBookConnect.Fetch(code, "me");

                FBuser faceBookUser = new JavaScriptSerializer().Deserialize<FBuser>(data);
                sname = faceBookUser.UserName;
                semail = faceBookUser.Email;
                spassword = sname;
                CheckUserExists(sname, semail, spassword);
            }
        }
        catch (Exception ee)
        {
        }
    }
    protected void linkedinlogin()
    {
        if (LinkedInConnect.IsAuthorized)
        {
            DataSet ds = LinkedInConnect.Fetch();
            sname = ds.Tables["person"].Rows[0]["first-name"].ToString() + " " + ds.Tables["person"].Rows[0]["last-name"].ToString();
            semail = ds.Tables["person"].Rows[0]["email-address"].ToString();
            spassword = sname;

            //lblHeadline.Text = ds.Tables["person"].Rows[0]["headline"].ToString();
            //lblIndustry.Text = ds.Tables["person"].Rows[0]["industry"].ToString();
            //lblLinkedInId.Text = ds.Tables["person"].Rows[0]["id"].ToString();
            //lblSpecialities.Text = ds.Tables["person"].Rows[0]["specialties"].ToString();
            //lblLocation.Text = ds.Tables["location"].Rows[0]["name"].ToString();
            //imgPicture.ImageUrl = ds.Tables["person"].Rows[0]["picture-url"].ToString();
            // MsgBox(sname);
            CheckUserExists(sname, semail, spassword);
        }
        // MsgBox(sname);
    }
    protected void gpluslogin()
    {
        if (Request.QueryString["access_token"] != null)
        {
            //String URI = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + Request.QueryString["access_token"].ToString();
            String URI="";
            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(URI);
            string b;

            /*I have not used any JSON parser because I do not want to use any extra dll/3rd party dll*/
            using (StreamReader br = new StreamReader(stream))
            {
                b = br.ReadToEnd();
            }

            b = b.Replace("id", "").Replace("email", "");
            b = b.Replace("given_name", "");
            b = b.Replace("family_name", "").Replace("link", "").Replace("picture", "");
            b = b.Replace("gender", "").Replace("locale", "").Replace(":", "");
            b = b.Replace("\"", "").Replace("name", "").Replace("{", "").Replace("}", "");

            /*
                 
            "id": "109124950535374******"
              "email": "usernamil@gmail.com"
              "verified_email": true
              "name": "firstname lastname"
              "given_name": "firstname"
              "family_name": "lastname"
              "link": "https://plus.google.com/10912495053537********"
              "picture": "https://lh3.googleusercontent.com/......./photo.jpg"
              "gender": "male"
              "locale": "en" } 
           */

            Array ar = b.Split(",".ToCharArray());
            for (int p = 0; p < ar.Length; p++)
            {
                ar.SetValue(ar.GetValue(p).ToString().Trim(), p);
            }
            semail = ar.GetValue(1).ToString();
            sname = ar.GetValue(4).ToString() + " " + ar.GetValue(5).ToString();
            spassword = sname;
            //Google_ID = ar.GetValue(0).ToString();     

            CheckUserExists(sname, semail, spassword);
        }
    }
    protected void twitterlogin()
    {
        sname = Session["twname"].ToString();
        semail = Session["twemail"].ToString();
        spassword = sname;
        CheckUserExists(sname, semail, spassword);
    }
    protected void btn_fb_Click(object sender, ImageClickEventArgs e)
    {
        Session["loginusing"] = "facebook";
        FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split('?')[0]);
        //fblogin();
    }
    protected void btn_linkin_Click(object sender, ImageClickEventArgs e)
    {
        Session["loginusing"] = "linkedin";
        LinkedInConnect.Authorize();
    }
    protected void btn_twitter_Click(object sender, ImageClickEventArgs e)
    {
        //OAuthHelper oauthhelper = new OAuthHelper();
        //string requestToken = oauthhelper.GetRequestToken();

        //if (string.IsNullOrEmpty(oauthhelper.oauth_error))
        //{
        //    Session["RedirectTo"] = "Checkout_Login.aspx";
        //    Response.Redirect(oauthhelper.GetAuthorizeUrl(requestToken));
        //}
        //else
        //    MsgBox(oauthhelper.oauth_error);
    }
    protected void CheckUserExists(string name, string email, string password)
    {
        //if exists then login using system
        if (cls.CheckExistField("CheckExistField", "Members", "Email", email, "and IsActive = 1"))
        {
            //get details from db
            DataTable dt = new DataTable();
            dt = cls.ReturnDataTable("Select_MemberDetailsFromEmail", new SqlParameter("@Email", email));
            if (dt.Rows.Count > 0)
            {
                Binduser("L", dt.Rows[0]["Email"].ToString(), dt.Rows[0]["Password"].ToString());
            }
        }
        else
        {
            //does not exits then register to the system
            cls.ExecuteDA("Insert_Members", new SqlParameter("@Name", name),
                                                                     new SqlParameter("@Email", email),
                                                                      new SqlParameter("@Password", password),
                                                                       new SqlParameter("@Company", ""),
                                                                        new SqlParameter("@Contact", ""));
            //insert into DB
            MailAdminRegistration(name, email, password);
            MailUserRegistration(name, email, password);
            Binduser("L", email, password);
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
    private void MailAdminRegistration(string name, string email, string password)
    {
        strMailHtml = new StringBuilder();
        string adminmail = "";
      
        strMailHtml.Append("<html>");
        strMailHtml.Append("<head>");
        strMailHtml.Append("    <title></title>");
        strMailHtml.Append("</head>");
        strMailHtml.Append("<body>");
        strMailHtml.Append("    <table width='100%' border='0' align='left' cellpadding='2' cellspacing='2' style='border: 1px solid #ff4f12;'>");
        strMailHtml.Append("        <tbody>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' height='70' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial; border-bottom: 1px solid #ff4f12'>");
        strMailHtml.Append("                    <img border='0' colspan='2' src='http://timeoffice.in/images/logo.png' alt='timeoffice.in'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='30' align='left' valign='middle' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial'>");
        strMailHtml.Append("                    Dear Administrator,");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("                <td height='25' align='right' valign='middle' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial'>");
        strMailHtml.Append("                    ");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='30' colspan='2' align='left' valign='middle' style='font-size: 12px;");
        strMailHtml.Append("                    text-decoration: none; font-family: Arial'>");
        strMailHtml.Append("                    Registration Details");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='30' colspan='' align='left' valign='middle'  style='font-size: 12px;");
        strMailHtml.Append("                    font-weight: bold; color: #ff4f12; text-decoration: none; font-family: Arial;'>");
        strMailHtml.Append("                    Personal Details");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("                <td height='30' colspan='' align='left' valign='middle' style='font-size: 12px;");
        strMailHtml.Append("                    font-weight: bold; color: #ff4f12; text-decoration: none; font-family: Arial;'>");
        strMailHtml.Append("                    Login Details");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='' style='font-size: 12px; text-decoration: none; font-family: Arial'>");
        strMailHtml.Append("                    <table width='50%' cellpadding='0' cellspacing='0'>");
        strMailHtml.Append("                  <tbody>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' colspan='' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Name");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    " + name + "");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Company");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    <div style='word-wrap: break-word'>");
        strMailHtml.Append("                                        N/A</div>");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Phone");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    N/A");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                        </tbody>");
        strMailHtml.Append("                    </table>");
        strMailHtml.Append("              </td>");
        strMailHtml.Append("                <td colspan='' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial'>");
        strMailHtml.Append("                    <table width='50%' cellpadding='0' cellspacing='0'>");
        strMailHtml.Append("                  <tbody>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Email");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:" + email + "'>");
        strMailHtml.Append("                                        " + email + "</a>");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Password");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    <div style='word-wrap: break-word'>");
        strMailHtml.Append("                                        " + password + "");
        strMailHtml.Append("                                    </div>");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                        </tbody>");
        strMailHtml.Append("                    </table>");
        strMailHtml.Append("              </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='25' colspan='2' align='left' valign='middle' style='font-size: 12px;");
        strMailHtml.Append("                    font-weight: bold; color: #000000; text-decoration: none; font-family: Arial;'>");
        strMailHtml.Append("                    Regards,");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' style='font-family: Arial; font-size: 11px; color: #000000; text-decoration: none;");
        strMailHtml.Append("                    line-height: 25px; font-weight: bold'>");
        strMailHtml.Append("                    timeoffice<br>");
        strMailHtml.Append("                    address<br />");
        strMailHtml.Append("                     <u>Phone</u> : +91 (0) 225 6322234");
        strMailHtml.Append("                    <br>");
        strMailHtml.Append("                    <u>Email</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:support@timeoffice.in'>");
        strMailHtml.Append("                        support@timeoffice.in</a> <u>Web</u> : <a target='_blank' style='text-decoration: none;");
        strMailHtml.Append("                            color: #ff4f12' href='http://www.timeoffice.in'>www.timeoffice.in</a>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>            ");
        strMailHtml.Append("        </tbody>");
        strMailHtml.Append("    </table>");
        strMailHtml.Append("</body>");
        strMailHtml.Append("</html>");

        adminmail = strMailHtml.ToString();
        try
        {
            MailMessage mailMsg1 = new MailMessage();
            MailAddress fromadd = new MailAddress("support@timeoffice.in");
            MailAddress repadd = new MailAddress(email);
            mailMsg1.From = fromadd;
            mailMsg1.To.Add("support@timeoffice.in");
            mailMsg1.ReplyTo = repadd;
            mailMsg1.Bcc.Add("s@timeoffice.net");
            mailMsg1.Bcc.Add("j@timeoffice.net");
            mailMsg1.IsBodyHtml = true;
            mailMsg1.Subject = "Registration Details - timeoffice";
            mailMsg1.Body = adminmail.ToString();
            //   SmtpClient smtp = new SmtpClient("mail.timeoffice.in");           
            // smtp.Send(mailMsg1);

            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("support@timeoffice.in", "jee71237");
            smtp.Send(mailMsg1);           
        }
        catch (Exception ex)
        {
            //lblMsg.Text = ex.Message;
        }
    }
    private void MailUserRegistration(string name, string email, string password)
    {
        strMailHtml = new StringBuilder();
        string usermail = null;
       
        strMailHtml.Append("<html>");
        strMailHtml.Append("<head>");
        strMailHtml.Append("    <title></title>");
        strMailHtml.Append("</head>");
        strMailHtml.Append("<body>");
        strMailHtml.Append("    <table width='600px' border='0' align='left' cellpadding='2' cellspacing='2' style='border: 1px solid #ff4f12;'>");
        strMailHtml.Append("        <tbody>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' height='70' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial; border-bottom: 1px solid #ff4f12'>");
        strMailHtml.Append("                    <img border='0' colspan='2' src='http://timeoffice.in/images/logo.png' alt='timeoffice'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='30' align='left' valign='middle' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial'>");
        strMailHtml.Append("                    Dear " + name + ",");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("                <td height='25' align='right' valign='middle' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial'>");
        strMailHtml.Append("                    ");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='30' colspan='2' align='left' valign='middle' style='font-size: 12px;");
        strMailHtml.Append("                    text-decoration: none; font-family: Arial'>");
        strMailHtml.Append("                    Registration details are as follows");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='30' colspan='' align='left' valign='middle'  style='font-size: 12px;");
        strMailHtml.Append("                    font-weight: bold; color: #ff4f12; text-decoration: none; font-family: Arial;'>");
        strMailHtml.Append("                    Personal Details");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("                <td height='30' colspan='' align='left' valign='middle' style='font-size: 12px;");
        strMailHtml.Append("                    font-weight: bold; color: #ff4f12; text-decoration: none; font-family: Arial;'>");
        strMailHtml.Append("                    Login Details");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='' style='font-size: 12px; text-decoration: none; font-family: Arial'>");
        strMailHtml.Append("                    <table width='50%' cellpadding='0' cellspacing='0'>");
        strMailHtml.Append("                  <tbody>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' colspan='' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Name");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    " + name + "");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Company");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    <div style='word-wrap: break-word'>");
        strMailHtml.Append("                                       N/A</div>");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Phone");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                   N/A");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                        </tbody>");
        strMailHtml.Append("                    </table>");
        strMailHtml.Append("              </td>");
        strMailHtml.Append("                <td colspan='' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial'>");
        strMailHtml.Append("                    <table width='50%' cellpadding='0' cellspacing='0'>");
        strMailHtml.Append("                  <tbody>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Email");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:" + email + "'>");
        strMailHtml.Append("                                        " + email + "</a>");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                            <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Password");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    <div style='word-wrap: break-word'>");
        strMailHtml.Append("                                        " + password + "");
        strMailHtml.Append("                                    </div>");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                        </tbody>");
        strMailHtml.Append("                    </table>");
        strMailHtml.Append("              </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='25' colspan='2' align='left' valign='middle' style='font-size: 12px;");
        strMailHtml.Append("                    font-weight: bold; color: #000000; text-decoration: none; font-family: Arial;'>");
        strMailHtml.Append("                    Regards,");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' style='font-family: Arial; font-size: 11px; color: #000000; text-decoration: none;");
        strMailHtml.Append("                    line-height: 25px; font-weight: bold'>");
        strMailHtml.Append("                    timeoffice<br>");
        strMailHtml.Append("                    address<br />");
        strMailHtml.Append("                     <u>Phone</u> : +91 (0) 225 433334");
        strMailHtml.Append("                    <br>");
        strMailHtml.Append("                    <u>Email</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:support@timeoffice.in'>");
        strMailHtml.Append("                        support@timeoffice.in</a> <u>Web</u> : <a target='_blank' style='text-decoration: none;");
        strMailHtml.Append("                            color: #ff4f12' href='http://www.timeoffice.in'>www.timeoffice.in</a>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>            ");
        strMailHtml.Append("        </tbody>");
        strMailHtml.Append("    </table>");
        strMailHtml.Append("</body>");
        strMailHtml.Append("</html>");

        usermail = strMailHtml.ToString();
        try
        {
            MailMessage mailMsg1 = new MailMessage();
            MailAddress fromadd = new MailAddress("support@timeoffice.in");
            mailMsg1.From = fromadd;
            mailMsg1.To.Add(email);
            mailMsg1.Bcc.Add("s@timeoffice.net");
            mailMsg1.Bcc.Add("j@timeoffice.net");
            mailMsg1.IsBodyHtml = true;
            mailMsg1.Subject = "Registration Details - timeoffice";
            mailMsg1.Body = usermail.ToString();
            // SmtpClient smtp = new SmtpClient("mail.timeoffice.in");       
            //smtp.Send(mailMsg1);

            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("support@timeoffice.in", "43141");
            smtp.Send(mailMsg1);
        }
        catch (Exception ex)
        {
            //lblMsg.Text = ex.Message;
        }
    }

    protected void lnkForgotPwd_Click(object sender, EventArgs e)
    {
        modalpopup1.Show();
    }


    protected void btnForgoPwdCancel_Click(object sender, EventArgs e)
    {
        txtEmail.Text = "";
        modalpopup1.Hide();
    }
    protected void btnForgotPwdSubmit_Click(object sender, EventArgs e)
    {

        //retrieve password from email id
        string password = "";
        DataTable dtforgotpwd = new DataTable();
        dtforgotpwd = cls.ReturnDataTable("Select_MembersPwdFromEmail", new SqlParameter("@Email", txtEmail.Text));
        if (dtforgotpwd.Rows.Count > 0)
        {
            password = dtforgotpwd.Rows[0]["Password"].ToString();

        }
        if (password != "")
        {
            SendClientMail(password);
            modalpopup1.Hide();
            txtEmail.Text = "";
            MsgBox("Password has been sent successfully to your registered email id.");
        }
        else
        {
            MsgBox("Invalid email id.");
            modalpopup1.Show();
        }

    }

    protected void SendClientMail(string pwd)
    {
        strMailHtml = new StringBuilder();
        string clientmailforgotpwd = "";

       
        strMailHtml.Append("<html xmlns='http://www.w3.org/1999/xhtml'>");
        strMailHtml.Append("<head>");
        strMailHtml.Append("    <title></title>");
        strMailHtml.Append("</head>");
        strMailHtml.Append("<body>");
        strMailHtml.Append("    <table width='100%' border='0' align='left' cellpadding='2' cellspacing='2' style='border: 1px solid #ff4f12;'>");
        strMailHtml.Append("        <tbody>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' height='70' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial; border-bottom: 1px solid #ff4f12'>");
        strMailHtml.Append("                    <img border='0' src='http://timeoffice.in/images/logo.png' alt='timeoffice'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='30' align='left' valign='middle' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial'>");
        strMailHtml.Append("                    Dear Customer,");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("                <td height='25' align='right' valign='middle' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                    font-family: Arial'>");
        strMailHtml.Append("                    ");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("              <tr>");
        strMailHtml.Append("            <td colspan='2'  align='left' valign='middle' height='25' style='font-family: Arial; font-size: 12px;  border-top: solid 1px #c1c1c1; border-bottom: solid 1px #c1c1c1;'>");
        strMailHtml.Append("                Your login credentials are as follows");
        strMailHtml.Append("            </td>");
        strMailHtml.Append("        </tr>      ");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' style='font-size: 12px; text-decoration: none; font-family: Arial; padding:10px; padding-bottom:20px;'>");
        strMailHtml.Append("                  <table width='50%' cellpadding='0' cellspacing='0'>");
        strMailHtml.Append("                  <tbody> <tr>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Email");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    <div style='word-wrap: break-word'>");
        strMailHtml.Append("                               <a target='_blank' style='text-decoration: none; color: #ff4f12' href='maito:"+txtEmail.Text+"'>" + txtEmail.Text + "</a></div>");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                           <tr>");
        strMailHtml.Append("                                <td height='25' colspan='' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    Password");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td width='20' height='25' align='center' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    :");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                                <td height='25' align='left' valign='top' style='font-size: 12px; text-decoration: none;");
        strMailHtml.Append("                                    font-family: Arial'>");
        strMailHtml.Append("                                    " + pwd + "");
        strMailHtml.Append("                                </td>");
        strMailHtml.Append("                            </tr>");
        strMailHtml.Append("                        </tbody>");
        strMailHtml.Append("                    </table>");
        strMailHtml.Append("              </td>                ");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='25' colspan='2' align='left' valign='middle' style='font-size: 12px;");
        strMailHtml.Append("                    font-weight: bold; color: #000000; text-decoration: none; font-family: Arial;'>");
        strMailHtml.Append("                    Regards,");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' style='font-family: Arial; font-size: 11px; color: #000000; text-decoration: none;");
        strMailHtml.Append("                    line-height: 25px; font-weight: bold'>");
        strMailHtml.Append("                    timeoffice<br>");
        strMailHtml.Append("                    address<br />");
        strMailHtml.Append("                     <u>Phone</u> : +91 (0) 265 6540611");
        strMailHtml.Append("                    <br>");
        strMailHtml.Append("                    <u>Email</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:support@timeoffice.in'>");
        strMailHtml.Append("                        support@timeoffice.in</a> <u>Web</u> : <a target='_blank' style='text-decoration: none;");
        strMailHtml.Append("                            color: #ff4f12' href='http://www.timeoffice.in'>www.timeoffice.in</a>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>            ");
        strMailHtml.Append("        </tbody>");
        strMailHtml.Append("    </table>");
        strMailHtml.Append("</body>");
        strMailHtml.Append("</html>");

        clientmailforgotpwd = strMailHtml.ToString();
        try
        {
            MailMessage mailMsg1 = new MailMessage();
            MailAddress fromadd = new MailAddress("support@timeoffice.in");
            MailAddress repadd = new MailAddress(txtEmail.Text);
            mailMsg1.From = fromadd;
            mailMsg1.To.Add("support@timeoffice.in");
            mailMsg1.ReplyTo = repadd;
            mailMsg1.Bcc.Add("s@timeoffice.net");
            mailMsg1.IsBodyHtml = true;
            mailMsg1.Subject = "Login Credentials Details - timeoffice";
            mailMsg1.Body = clientmailforgotpwd.ToString();
            //   SmtpClient smtp = new SmtpClient("mail.timeoffice.in");           
            // smtp.Send(mailMsg1);

            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("support@timeoffice.in", "fadadf");
            smtp.Send(mailMsg1);
        }
        catch (Exception ex)
        {
            //lblMsg.Text = ex.Message;
        }
    }
}
