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

public partial class Register : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    BillingShippingDetails clsBSD;
    clsWishlist clsWishlist;
    StringBuilder strMailHtml;
    string ProductId, CategoryName, SubCategoryName, ProductName, Productdescp, BrandName, SupplierName, Unit, ColourName, SizeName, ProductCode, SupplierProductCode, PackSize, Image, Certification, Description, ShippingDays;
    double ProductCost, ProductWeight, Margin, SalePrice, Tax, SalesPrice_Incl, MRP, Discount, CalDiscount, ShippingCost, FinalSellingPrice, TaxFinalPrice, MinQty, Qty, Price;
    bool IsCOD;


    string sname, semail, spassword;

    public string Client_ID = "";
    public string Return_url = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //FaceBookConnect.API_Key = "596977313711470"; // Facebook App Key        
        //FaceBookConnect.API_Secret = "01b86246607dc7a4dc25ca7add60801d";// Facebook Secret App Key

        //LinkedInConnect.APIKey = "75lvz4jzpdmsg9";
        //LinkedInConnect.APISecret = "CbljA0oCqMajJyw7";
        //LinkedInConnect.RedirectUrl = Request.Url.AbsoluteUri.Split('?')[0];

        //     Client_ID = ConfigurationManager.AppSettings["google_clientId"].ToString();
        //     Return_url = ConfigurationManager.AppSettings["google_RedirectUrl"].ToString();

        if (Session["MemberInfo"] != null)
        {
            DataTable dtUser;
            dtUser = new DataTable();
            dtUser = (DataTable)Session["MemberInfo"];
            if (dtUser.Rows[0]["memberId"].ToString() != "0")
            {
                Response.Redirect("Default.aspx");
            }
        }
        if (!IsPostBack)
        {
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
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Binduser("L");

    }
    protected void Binduser(string mode)
    {
        DataTable dtUser = new DataTable();

        if (mode == "L")
        {
            dtUser = cls.ReturnDataTable("Login_MembersLogin", new SqlParameter("@Email", txtEmailL.Text.Trim()), new SqlParameter("@Password", txtPasswordL.Text.Trim()));
            Session["Memberid"] = dtUser.Rows[0]["MemberId"].ToString();
        }
        else
        {
            //dtUser = cls.ReturnDataTable("Login_MembersLogin", new SqlParameter("@Email", txtEmailR.Text.Trim()), new SqlParameter("@Password", txtPasswordR.Text.Trim()));
        }

        if (dtUser.Rows.Count > 0 && Convert.ToInt32(dtUser.Rows[0]["MemberId"])!=0 )
        {
            if (Convert.ToBoolean(dtUser.Rows[0]["IsApproved"]))
            {
                if (mode == "R")
                {
                    //MailAdminRegistration();
                    //MailUserRegistration();
                }
                Session["MemberInfo"] = dtUser;
                BindBillingInfo();
                Session["CameAgain"] = "1";

                BindWishList(Convert.ToInt32(dtUser.Rows[0]["MemberId"]));
                if (Session["CameFrom"] != null)
                {
                    if (Session["CameFrom"].ToString() == "CheckOut_Login")
                    {
                        Response.Redirect("Register.aspx");
                    }
                    else if (Session["CameFrom"].ToString() == "Wishlist")
                    {
                        Response.Redirect("WishList.aspx");
                    }
                }
                Response.Redirect("Default.aspx");
            }
            else
            {
                MsgBox("You are blocked...!!");
                return;
            }
        }
        else
        {
            MsgBox("Invalid Username or Password...!!");
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
            String URI = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + Request.QueryString["access_token"].ToString();

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
        //    Session["RedirectTo"] = "Register.aspx";
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

                Binduser1("L", dt.Rows[0]["Email"].ToString(), dt.Rows[0]["Password"].ToString());
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
            //MailAdminRegistration1(name, email, password);
            //MailUserRegistration1(name, email, password);
            Binduser1("L", email, password);
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

    protected void Binduser1(string mode, string email, string password)
    {
        DataTable dtUser;
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
                //MsgBox("okayyyyyyyy");
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

                Response.Redirect("Default.aspx");
            }
        }
        else
        {
            MsgBox("Invalid EmailId or Password");
            return;
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
            //  SendClientMail(password);
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



}