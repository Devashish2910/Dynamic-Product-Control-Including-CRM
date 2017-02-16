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

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

using System.Collections;
using System.Collections.Specialized;
using CCA.Util;

public partial class PaymentSuccess : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    clsAddToCart clsCart;
    BillingShippingDetails clsBSD;
    string trackingid = "";

    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!IsPostBack)
    //    {
    //        if (Session["MemberInfo"] != null)
    //        {
    //            if (Session["Cart"] != null)
    //            {
    //                if (clsCart.TotalItems() <= 0)
    //                {
    //                    Response.Redirect("MemberDashBoard.aspx");
    //                }
    //            }
    //        }
    //        else
    //        {
    //            Response.Redirect("Register.aspx");
    //        }

    //        if (Session["PaySuccess"].Equals("1"))
    //        {
    //            InsertIntoDB();
    //            RemoveSession();
    //            BindTopCartItems();
    //        }
    //    }
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (HttpContext.Current.Session["MemberInfo"] != null)
        //{
        //    if (HttpContext.Current.Session["Cart"] != null)
        //    {
        //        clsCart = new clsAddToCart();
        //        if (clsCart.TotalItems() <= 0)
        //        {
        //            Response.Redirect("Checkout_Login.aspx");
        //        }
        //    }
        //}
        //else
        //{
        //    HttpContext.Current.Session["CameFrom"] = "CheckOut_Login";
        //    Response.Redirect("Checkout_Login.aspx");
        //}


        //if (!IsPostBack)
        //{
        if (Session["PaySuccess"] != null)
        {
            if (Session["PaySuccess"].Equals("1"))
            {
                InsertIntoDB();
                RemoveSession();
                BindTopCartItems();
                pnlSuccess.Visible = true;
            }

        }
        else
        {
            ShowMessageThenRedirectTo("Session Expired", "default");
        }

        //if (Session["PayMode"] != null)
        //{
        //    if (Session["PayMode"].ToString() == "Online")
        //    {
        //        //Response.Write(Session["PayMode"].ToString());
        //        getOnlinePaymentValues();
        //    }
        //}

        //}
    }
    //protected void getOnlinePaymentValues()
    //{
    //    string workingKey = "F6EDD60823178133A01936283D402E0C";//put in the 32bit alpha numeric key in the quotes provided here
    //    CCACrypto ccaCrypto = new CCACrypto();
    //    string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
    //    NameValueCollection Params = new NameValueCollection();
    //    string[] segments = encResponse.Split('&');
    //    foreach (string seg in segments)
    //    {
    //        string[] parts = seg.Split('=');
    //        if (parts.Length > 0)
    //        {
    //            string Key = parts[0].Trim();
    //            string Value = parts[1].Trim();
    //            Params.Add(Key, Value);
    //        }
    //    }
    //    Response.Write(Params[3].ToString());
    //    if (Params[3].ToString() == "Success")
    //    {
    //        // insert into db
    //        trackingid = Params.Keys[1].ToString();
    //        UpdateIntoDB();
    //        RemoveSession();
    //        BindTopCartItems();
    //        pnlSuccess.Visible = true;
    //    }
    //    else if (Params[3].ToString() == "Aborted")
    //    {
    //        ShowMessageThenRedirectTo("Transaction Aborted", "default");
    //    }
    //    else
    //    {
    //        ShowMessageThenRedirectTo("Transaction Failure", "default");
    //    }
    //}

   
    protected void InsertIntoDB()
    {
        clsCart = new clsAddToCart();
        long orderid;
    A:
        orderid = (long)cls.ReturnScaler("Select_MaxOrderID");

        if (cls.CheckExistField("CheckExistField", "InvoiceMaster", "OrderId", orderid.ToString(), " and IsActive=1"))
        {
            goto A;
        }

        long Memberid = 0;
        DataTable dtMember = new DataTable();
        dtMember = (DataTable)Session["MemberInfo"];
        foreach (DataRow dr in dtMember.Rows)
        {
            Memberid = Convert.ToInt64(dr["MemberId"]);
        }

        bool IsPaid = true;
        bool IsCOD = false;

        if (Session["PayMode"].ToString() == "Cash On Delivery")
        {
            IsPaid = false;
            IsCOD = true;
        }
        if (Session["PayMode"].ToString() == "Cheque / Demand Draft" || Session["PayMode"].ToString() == "Deposit in Bank A/C")
        {
            IsPaid = false;
        }

        double discount = 0;
        double discountValue = 0;

        if (Session["Discount"] != null)
        {
            discount = (double)Session["Discount"];
            discountValue = (double)Session["DiscountValue"];
        }

        //Insert into invoice master
        Int32 invoiceid;
        invoiceid = (Int32)cls.ReturnScaler("Insert_InvoiceMaster", new SqlParameter("MemberId", Memberid),
                                                               new SqlParameter("@OrderId", orderid),
                                                              new SqlParameter("@ShippingCharges", "0"),
                                                              new SqlParameter("@OrderAmount", clsCart.TotalPrice()),
                                                              new SqlParameter("@OrderQty", clsCart.TotalQty()),
                                                              new SqlParameter("@PaypalId", trackingid),
                                                              new SqlParameter("@IsPaid", IsPaid),
                                                              new SqlParameter("@IsCOD", IsCOD),
                                                              new SqlParameter("@PaymentMode", Session["PayMode"].ToString()),
                                                              new SqlParameter("@DiscountPer", discount),
                                                              new SqlParameter("@DiscountAmount", discountValue),
                                                              new SqlParameter("@OriginalAmount", clsCart.TotalPriceWithoutDiscount()));


        //Insert into invoice coupon
        if (Session["CouponCode"] != null)
        {
            DataTable dtCoupon = new DataTable();
            dtCoupon = cls.ReturnDataTable("Select_CouponOnName", new SqlParameter("@CouponName", Session["CouponCode"].ToString()));

            if (dtCoupon.Rows.Count > 0)
            {
                cls.ExecuteDA("Insert_InvoiceCoupon", new SqlParameter("@InvoiceId", invoiceid),
                                                    new SqlParameter("@CouponName", dtCoupon.Rows[0]["CouponName"]),
                                                    new SqlParameter("@CriteriaAVal", dtCoupon.Rows[0]["CriteriaAVal"]),
                                                    new SqlParameter("@CriteriaBVal", dtCoupon.Rows[0]["CriteriaBVal"]),
                                                    new SqlParameter("@CriteriaCVal", dtCoupon.Rows[0]["CriteriaCVal"]));
            }
        }


        //insert into invoice product table

        DataTable dt = new DataTable();
        dt = clsCart.BindCart();
        foreach (DataRow dr in dt.Rows)
        {
            cls.ExecuteDA("Insert_InvoiceProduct", new SqlParameter("@InvoiceId", invoiceid),
                                                        new SqlParameter("@ProductId", Convert.ToInt32(dr["ProductId"])),
                                                         new SqlParameter("@CategoryName", dr["CategoryName"]),
                                                         new SqlParameter("@SubCategoryName", dr["SubCategoryName"]),
                                                         new SqlParameter("@ProductName", dr["ProductName"]),
                                                         new SqlParameter("@Productdescp", dr["Productdescp"]),
                                                         new SqlParameter("@BrandName", dr["BrandName"]),
                                                         new SqlParameter("@SupplierName", dr["SupplierName"]),
                                                         new SqlParameter("@Unit", dr["Unit"]),
                                                         new SqlParameter("@ColourName", dr["ColourName"]),
                                                         new SqlParameter("@SizeName", dr["SizeName"]),
                                                         new SqlParameter("@ProductCode", dr["ProductCode"]),
                                                         new SqlParameter("@SupplierProductCode", dr["SupplierProductCode"]),
                                                         new SqlParameter("@PackSize", dr["PackSize"]),
                                                         new SqlParameter("@ProductCost", dr["ProductCost"]),
                                                         new SqlParameter("@ProductWeight", dr["ProductWeight"]),
                                                         new SqlParameter("@Image", dr["Image"]),
                                                         new SqlParameter("@Certification", dr["Certification"]),
                                                         new SqlParameter("@Description", dr["Description"]),
                                                         new SqlParameter("@Margin", Convert.ToDouble(dr["Margin"])),
                                                         new SqlParameter("@SalePrice", Convert.ToDouble(dr["SalePrice"])),
                                                         new SqlParameter("@Tax", Convert.ToDouble(dr["Tax"])),
                                                         new SqlParameter("@SalesPrice_Incl", Convert.ToDouble(dr["SalesPrice_Incl"])),
                                                         new SqlParameter("@MRP", Convert.ToDouble(dr["MRP"])),
                                                         new SqlParameter("@Discount", Convert.ToDouble(dr["Discount"])),
                                                         new SqlParameter("@CalDiscount", Convert.ToDouble(dr["CalDiscount"])),
                                                         new SqlParameter("@ShippingCost", Convert.ToDouble(dr["ShippingCost"])),
                                                         new SqlParameter("@FinalSellingPrice", Convert.ToDouble(dr["FinalSellingPrice"])),
                                                         new SqlParameter("@TaxFinalPrice", Convert.ToDouble(dr["TaxFinalPrice"])),
                                                         new SqlParameter("@Quantity", Convert.ToDouble(dr["Qty"])),
                                                         new SqlParameter("@ShippingDays", dr["ShippingDays"]),
                                                         new SqlParameter("@IsCOD", Convert.ToBoolean(dr["IsCOD"])));
        }

        //inserting into billing and delivery details
        clsBSD = new BillingShippingDetails();
        DataTable dtbilship = new DataTable();
        dtbilship = clsBSD.BindBillShip();

        foreach (DataRow drow in dtbilship.Rows)
        {
            ViewState["ToMail"] = drow["SEmail"];
            cls.ExecuteDA("Insert_InvoiceBillingShipping", new SqlParameter("@InvoiceId", invoiceid),
                                                            new SqlParameter("@Name", drow["Name"]),
                                                             new SqlParameter("@Email", drow["Email"]),
                                                             new SqlParameter("@Company", drow["Company"]),
                                                             new SqlParameter("@Contact", drow["Contact"]),
                                                             new SqlParameter("@Address1", drow["Address1"]),
                                                             new SqlParameter("@Address2", drow["Address2"]),
                                                             new SqlParameter("@City", drow["City"]),
                                                             new SqlParameter("@State", drow["State"]),
                                                             new SqlParameter("@Country", drow["Country"]),
                                                             new SqlParameter("@Zipcode", drow["Zipcode"]),
                                                             new SqlParameter("@SName", drow["SName"]),
                                                             new SqlParameter("@SEmail", drow["SEmail"]),
                                                             new SqlParameter("@SCompany", drow["SCompany"]),
                                                             new SqlParameter("@SContact", drow["SContact"]),
                                                             new SqlParameter("@SAddress1", drow["SAddress1"]),
                                                             new SqlParameter("@SAddress2", drow["SAddress2"]),
                                                             new SqlParameter("@SCity", drow["SCity"]),
                                                             new SqlParameter("@SState", drow["SState"]),
                                                             new SqlParameter("@SCountry", drow["SCountry"]),
                                                             new SqlParameter("@SZipcode", drow["SZipcode"]));

        }

        //  Session["OrderId"] = orderid.ToString();
        lblOredrId.Text = orderid.ToString();
        setPdfandMail(invoiceid, orderid);

    }
    protected void BindTopCartItems()
    {
        Label lblTopNoItems = (Label)this.Page.Master.FindControl("lblTopNoItems");
        Label lblTopTotal = (Label)this.Page.Master.FindControl("lblTopTotal");

        if (Session["Cart"] != null)
        {
            clsCart = new clsAddToCart();
            lblTopNoItems.Text = clsCart.TotalItems().ToString();

            if (clsCart.TotalItems() != 0)
            {
                lblTopTotal.Text = Math.Round(clsCart.TotalPrice()).ToString();
            }
            else
            {
                lblTopTotal.Text = "0";
            }
        }
        else
        {
            lblTopNoItems.Text = "0";
            lblTopTotal.Text = "0";
        }
    }
    protected void RemoveSession()
    {
        clsCart = new clsAddToCart();
        clsCart.RemoveFromSession();

        clsBSD = new BillingShippingDetails();
        clsBSD.RemoveFromSession();

        Session.Remove("PayMode");
        Session.Remove("PaypalId");
        Session.Remove("PaySuccess");
        if (Session["CameFrom"] != null)
        {
            Session.Remove("CameFrom");
        }
        Session.Remove("CameAgain");
        if (Session["Discount"] != null)
        {
            Session.Remove("Discount");
            Session.Remove("CouponCode");
            Session.Remove("DiscountValue");
        }
        if (Session["captcha"] != null)
        {
            Session.Remove("captcha");
        }
        if (Session["captcha1"] != null)
        {
            Session.Remove("captcha1");
        }
        if (Session["captcha2"] != null)
        {
            Session.Remove("captcha2");
        }
        if (Session["RedirectTo"] != null)
        {
            Session.Remove("RedirectTo");
        }
        //Session.Remove("Msg");
    }

    protected void setPdfandMail(double invoiceid, double orderid)
    {
        BindOrder(invoiceid);
        BindProduct(invoiceid);
        BindFooter(invoiceid);
        CreartePdf(invoiceid, orderid);
    }
    protected void BindOrder(double invoiceid)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_InvoiceBillShipDetailsFromID", new SqlParameter("@InvoiceId", invoiceid));

        if (dt.Rows.Count <= 0)
        {
            Response.Write("<script language='javascript'> { alert('Invalid OrderId') }</script>");
            Response.Write("<script language='javascript'> { self.close() }</script>");
        }
        else
        {
            rptOrderDetails.DataSource = dt;
            rptOrderDetails.DataBind();

            rptBilling.DataSource = dt;
            rptBilling.DataBind();

            rptShipping.DataSource = dt;
            rptShipping.DataBind();

            rptrCutomerTin.DataSource = dt;
            rptrCutomerTin.DataBind();
        }
    }
    protected void BindProduct(double invoiceid)
    {
        DataTable dtprod = new DataTable();
        dtprod = cls.ReturnDataTable("Select_InvoiceProductDetailsFromID", new SqlParameter("@InvoiceId", invoiceid));
        rptrCart.DataSource = dtprod;
        rptrCart.DataBind();

        if (dtprod.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dtprod.Rows[0]["CouponName"])))
            {
                lblCoupon.Text = "Using Voucher Code (" + dtprod.Rows[0]["CouponName"] + ")";
            }
            else
            {
                lblCoupon.Text = "";
            }
            lblDisPer.Text = "(" + dtprod.Rows[0]["DiscountPer"] + "%)";
            lblDisVal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["DiscountAmount"])).ToString();
        }
    }
    protected void BindFooter(double invoiceid)
    {
        NumbertoWords num = new NumbertoWords();
        DataTable dtprod = new DataTable();
        dtprod = cls.ReturnDataTable("Select_InvoiceProductDetailsFromID", new SqlParameter("@InvoiceId", invoiceid));
        lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["OrderAmount"])).ToString();
        lblAmountinWords.Text = num.NumberToWords(Convert.ToInt32(lblFinalTotal.Text)) + " only.";
        lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["OrderAmount"])).ToString();
    }
    protected void CreartePdf(double invoiceid, double orderid)
    {
        string filname = Server.MapPath("OrderPdf/" + "TSM_Order_" + orderid + ".pdf");

        if (System.IO.File.Exists(filname))
        {
            System.IO.File.Delete(filname);
        }

        iTextSharp.text.html.simpleparser.StyleSheet styles = new iTextSharp.text.html.simpleparser.StyleSheet();
        styles.LoadStyle("wdth20", "width", "30");
        styles.LoadStyle("wdth80", "width", "80");
        styles.LoadStyle("wdth50", "width", "50");
        styles.LoadStyle("wdth140", "width", "140");
        styles.LoadStyle("wdth100", "width", "100");
        styles.LoadStyle("wdth200", "width", "200");
        styles.LoadStyle("wdth400", "width", "400");
        styles.LoadStyle("wdth51", "width", "51");
        styles.LoadStyle("wdth40", "width", "40");
        styles.LoadStyle("wdth60", "width", "60");
        styles.LoadStyle("wdth65", "width", "65");
        styles.LoadStyle("wdth55", "width", "55");

        styles.LoadStyle("hght200", "height", "200");
        styles.LoadStyle("border-left", "border-left-width", "1");
        styles.LoadStyle("borderright", "BorderWidthRight ", "1f");


        //for header
        StringWriter swheader = new StringWriter();
        HtmlTextWriter hwheader = new HtmlTextWriter(swheader);
        pnlHeader.RenderControl(hwheader);
        StringReader srheader = new StringReader(swheader.ToString());

        PdfPCell cellLeft = new PdfPCell();

        StyleSheet style = new StyleSheet();

        style.LoadStyle("wdth20", "width", "30");
        style.LoadStyle("wdth40", "width", "40");
        style.LoadStyle("wdth60", "width", "60");
        style.LoadStyle("wdth80", "width", "80");
        style.LoadStyle("wdth81", "width", "81");
        style.LoadStyle("wdth100", "width", "100");
        style.LoadStyle("wdth50", "width", "50");
        style.LoadStyle("wdth51", "width", "51");
        style.LoadStyle("wdth140", "width", "140");
        style.LoadStyle("wdth600", "width", "552");
        style.LoadStyle("wdth200", "width", "220");
        style.LoadStyle("wdth400", "width", "331");

        style.LoadStyle("wdth550", "width", "551");
        style.LoadStyle("wdth541", "width", "551");
        style.LoadStyle("wdth65", "width", "65");
        style.LoadStyle("wdth55", "width", "55");

        List<IElement> objects = HTMLWorker.ParseToList(new StringReader(swheader.ToString()), style);  //This transforms your HTML to a list of PDF compatible objects
        for (int k = 0; k < objects.Count; ++k)
        {
            cellLeft.AddElement((IElement)objects[k]);

            //if (k == 1)
            //{
            //    cellLeft.FixedHeight = 500f;
            //    cellLeft.GetMaxHeight();//Add these objects to cell one by one
            //}
        }
        //header ends

        //for content

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        pnlMail.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());


        float topmrg = cellLeft.GetMaxHeight() + 22;
        Document pdfDoc = new Document(PageSize.A4, 22, 22, topmrg, 40);

        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        htmlparser.SetStyleSheet(styles);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(filname, FileMode.Create));
        pdfDoc.Open();

        writer.PageEvent = new HeaderFooter(cellLeft);
        htmlparser.Parse(sr);
        pdfDoc.Close();
        pdfDoc.Dispose();
        sr.Close();
        sr.Dispose();
        srheader.Close();
        sr.Dispose();
        writer.Close();
        writer.Dispose();

        Mail(orderid, filname);
    }
    protected void Mail(double orderid, string filename)
    {
        StringBuilder strMailHtml = new StringBuilder();
        strMailHtml.Append("<html>");
        strMailHtml.Append("<head>");
        strMailHtml.Append("    <title></title>");
        strMailHtml.Append("</head>");
        strMailHtml.Append("<body>");
        strMailHtml.Append("    <table width='100%' border='0' align='left' cellpadding='2' cellspacing='2' style='border: 1px solid #ff4f12;'>");
        strMailHtml.Append("        <tbody>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' height='70' align='left' valign='top' style='font-size: 12px; text-decoration: none; font-family: Arial; border-bottom: 1px solid #ff4f12'>");
        strMailHtml.Append("                    <img border='0' src='http://xyz.com/images/logo.png' alt='xyz'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='30' align='left' valign='middle' style='font-size: 12px; font-weight: bold; color: #555555; text-decoration: none; font-family: Arial;'>Dear Customer,");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("                <td height='25' align='right' valign='middle' style='font-size: 12px; text-decoration: none; font-family: Arial'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='' style='font-size: 12px; text-decoration: none; font-family: Arial; line-height: 22px;'>Thank you for your order at <a target='_blank' style='text-decoration: none; color: #ff4f12'");
        strMailHtml.Append("                    href='http://www.xyz.com'>www.xyz.com</a>.<br />");
        strMailHtml.Append("                    Your order number is <span style='font-weight: bold; color: #555555; font-size: 14px;'>" + orderid + "</span>.<br />");
        strMailHtml.Append("                    You can track order status by <a target='_blank' style='text-decoration: underline; color: #ff4f12'");
        strMailHtml.Append("                        href='http://www.xyz.com/TrackOrder.aspx'>clicking here</a>.<br />");
        strMailHtml.Append("                    For any order related query, contact us at <a target='_blank' style='text-decoration: none; color: #ff4f12'");
        strMailHtml.Append("                        href='mailto:support@xyz.com'>support@xyz.com</a> or<br />");
        strMailHtml.Append("                    Call us at <span style='font-weight: bold; color: #555555; font-size: 14px;'>1800 200 1619</span>.<br />");
        strMailHtml.Append("                    Your order details have been attached in this email.");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='25' colspan='2' align='left' valign='middle' style='font-size: 12px; font-weight: bold; color: #000000; text-decoration: none; font-family: Arial;'>Regards,");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' style='font-family: Arial; font-size: 11px; color: #000000; text-decoration: none; line-height: 22px; font-weight: bold'>xyz<br>");
        strMailHtml.Append("                    address<br />");
        strMailHtml.Append("                    <u>Phone</u> : +d5466554");
        strMailHtml.Append("                    <br>");
        strMailHtml.Append("                    <u>Email</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:support@xyz.com'>support@xyz.com</a> <u>Web</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12'");
        strMailHtml.Append("                        href='http://www.xyz.com'>www.xyz.com</a>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("        </tbody>");
        strMailHtml.Append("    </table>");
        strMailHtml.Append("</body>");
        strMailHtml.Append("</html>");

        String strAdmin = strMailHtml.ToString();
        try
        {
            MailMessage mailMsg = new MailMessage();
            MailAddress fromAdd = new MailAddress("order@xyz.com");
            MailAddress replyto = new MailAddress("order@xyz.com");
            mailMsg.From = fromAdd;
            mailMsg.ReplyTo = replyto;
            mailMsg.To.Add(ViewState["ToMail"].ToString());
            mailMsg.Bcc.Add("mail@dabc.com");
            mailMsg.Bcc.Add("order@xyz.com");
            mailMsg.IsBodyHtml = true;
            mailMsg.Subject = "xyz Order Number : " + orderid;

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(filename);
            mailMsg.Attachments.Add(attachment);

            mailMsg.Body = strAdmin;
            // SmtpClient smtp = new SmtpClient();
            // smtp.Send(mailMsg);
            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("order@xyz.com", "asc4587");
            smtp.Send(mailMsg);
            attachment.Dispose();
        }
        catch (Exception ex)
        {

        }
        //try
        //{
        //    MailMessage mailMsg = new MailMessage();
        //    MailAddress fromAdd = new MailAddress("order@xyz.com");
        //    mailMsg.From = fromAdd;
        //    MailAddress replyto = new MailAddress(ViewState["ToMail"].ToString());
        //    mailMsg.To.Add("order@xyz.com");        
        //    mailMsg.Bcc.Add("mail@abc.xcom");
        //    mailMsg.IsBodyHtml = true;
        //    mailMsg.Subject = "Order Number : " + orderid;
        //    mailMsg.Body = strAdmin;
        //    //SmtpClient smtp = new SmtpClient();
        //    //smtp.Send(mailMsg);

        //    SmtpClient smtp = new SmtpClient();
        //    smtp.EnableSsl = true;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = new System.Net.NetworkCredential("order@xyz.com", "jee71237");
        //    smtp.Send(mailMsg);
        //}
        //catch (Exception ex)
        //{

        //}
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
    public void ShowMessageThenRedirectTo(string message, string pageName)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            message = message.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(),
                "MessageThenRedirect", "alert('" + message +
                "');window.location='" + pageName + ".aspx';", true);
        }
    }
}

public class HeaderFooter : PdfPageEventHelper
{
    PdfContentByte pdfContent;
    PdfTemplate template;
    protected BaseFont helv;
    BaseFont bf = null;
    PdfPCell cellLeft;

    private float headerhgt = 0;
    public HeaderFooter(PdfPCell cell)
    {
        cellLeft = cell;
    }

    public override void OnEndPage(PdfWriter writer, Document doc)
    {

        Paragraph footer = new Paragraph("    Subject to Vadodara Jurisdiction.", FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));
        Paragraph footer1 = new Paragraph("This is a Computer Generated Order.", FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));

        footer.Alignment = Element.ALIGN_CENTER;
        footer1.Alignment = Element.ALIGN_CENTER;

        PdfPTable footerTbl = new PdfPTable(1);

        footerTbl.TotalWidth = 600;
        footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;

        PdfPCell cell = new PdfPCell(footer);
        PdfPCell cell1 = new PdfPCell(footer1);

        cell.Border = 0;
        cell1.Border = 0;
        footerTbl.AddCell(cell);
        footerTbl.AddCell(cell1);
        footerTbl.WriteSelectedRows(0, -1, 240, 30, writer.DirectContent);



        //for header
        PdfPTable headerTbl = new PdfPTable(1);
        headerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
        //headerTbl.SpacingBefore = 500f;
        headerTbl.TotalWidth = 556;
        headerTbl.DefaultCell.Border = Rectangle.NO_BORDER;
        headerTbl.DefaultCell.BorderColor = BaseColor.WHITE;
        cellLeft.Border = 0;
        headerTbl.AddCell(cellLeft);
        headerTbl.WriteSelectedRows(0, -1, 20, doc.PageSize.Height - 5, writer.DirectContent);

    }

    //public float Getheight
    //{
    //    set
    //    {
    //        value = headerhgt;
    //    }
    //    get
    //    {
    //        return headerhgt;
    //    }
    //}

}