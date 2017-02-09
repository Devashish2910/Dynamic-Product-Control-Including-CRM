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

public partial class Checkout_Payment : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    clsAddToCart clsCart;
    BillingShippingDetails clsBSD;
    double MaxCOD = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["MemberInfo"] != null)
        {
            if (HttpContext.Current.Session["Cart"] != null)
            {
                clsCart = new clsAddToCart();
                if (clsCart.TotalItems() <= 0)
                {
                    Response.Redirect("Checkout_Login.aspx");
                }
            }
            if (!IsPostBack)
            {
                BindOrderSummary();
                BindShippingSummary();
                FillCapctha();
                FillCapctha1();
                FillCapctha2();
            }
        }
        else
        {
            HttpContext.Current.Session["CameFrom"] = "CheckOut_Login";
            Response.Redirect("Checkout_Login.aspx");
        }
    }
    protected void BindOrderSummary()
    {
        clsCart = new clsAddToCart();
        lblTotalItems.Text = clsCart.TotalItems().ToString();
        lblTotalAmount.Text = "Rs. " + Math.Round(clsCart.TotalPrice()).ToString();
        lblFinalAmount.Text = "Rs. " + Math.Round(clsCart.TotalPrice()).ToString();
        lblFinalAmount1.Text = "Rs. " + Math.Round(clsCart.TotalPrice()).ToString();
        lblFinalAmount2.Text = "Rs. " + Math.Round(clsCart.TotalPrice()).ToString();
        lblFinalAmount3.Text = "Rs. " + Math.Round(clsCart.TotalPrice()).ToString();
    }

    protected void BindShippingSummary()
    {
        clsBSD = new BillingShippingDetails();
        rptShipping.DataSource = clsBSD.BindBillShip();
        rptShipping.DataBind();
    }
    //# Region Security Code

    void FillCapctha()
    {
        try
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            Session["captcha"] = captcha.ToString();
            imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {
            throw;
        }
    }
    void FillCapctha1()
    {
        try
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            Session["captcha1"] = captcha.ToString();
            imgCaptcha1.ImageUrl = "GenerateCaptcha1.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {
            throw;
        }
    }
    void FillCapctha2()
    {
        try
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            Session["captcha2"] = captcha.ToString();
            imgCaptcha2.ImageUrl = "GenerateCaptcha2.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {
            throw;
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        FillCapctha();
    }
    protected void btnRefresh1_Click(object sender, ImageClickEventArgs e)
    {
        FillCapctha1();
    }
    protected void btnRefresh2_Click(object sender, ImageClickEventArgs e)
    {
        FillCapctha2();
    }
    //#End Region
    protected void btnOrder_Click(object sender, System.EventArgs e)
    {
        clsCart = new clsAddToCart();
        if (Session["captcha"] != null)
        {
            if (Session["captcha"].ToString() != txtCode.Text)
            {
                lblMsg.Text = "Invalid Code";
                FillCapctha();
                txtCode.Text = "";
            }
            else
            {
                //place order
                if (clsCart.CheckIsCod())
                {
                    MaxCOD = (double)cls.ReturnScaler("Select_CODLimit");

                    if (clsCart.TotalPrice() > MaxCOD)
                    {
                        MsgBox("Cash On Delivery not available on your order, as it exceeds max limit of " + MaxCOD);
                        return;
                    }
                    else
                    {
                        //place order and insert into db
                        Session["PaySuccess"] = "1";
                        Session["PayMode"] = "Cash On Delivery";
                        Response.Redirect("PaymentSuccess.aspx");
                    }
                }
                else
                {
                    MsgBox("Cash On Delivery not available on your order, as some of the products in cart not available on Cash On Delivery");
                    return;
                }
            }
        }
        else
        {
            FillCapctha();
        }
    }
    protected void btnOrder1_Click(object sender, EventArgs e)
    {
        if (Session["captcha1"] != null)
        {
            if (Session["captcha1"].ToString() != txtCode1.Text)
            {
                lblMsg1.Text = "Invalid Code";
                FillCapctha1();
                txtCode1.Text = "";
            }
            else
            {
                Session["PaySuccess"] = "1";
                Session["PayMode"] = "Cheque / Demand Draft";
                Response.Redirect("PaymentSuccess.aspx");
            }
        }
        else
        {
            FillCapctha1();
        }
    }
    protected void btnOrder2_Click(object sender, EventArgs e)
    {
        if (Session["captcha2"] != null)
        {
            if (Session["captcha2"].ToString() != txtCode2.Text)
            {
                lblMsg2.Text = "Invalid Code";
                FillCapctha2();
                txtCode2.Text = "";
            }
            else
            {
                Session["PaySuccess"] = "1";
                Session["PayMode"] = "Deposit in Bank A/C";
                Response.Redirect("PaymentSuccess.aspx");
            }
        }
        else
        {
            FillCapctha2();
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
    protected void btnPay_Click(object sender, EventArgs e)
    {
        Session["PaySuccess"] = "0";
        Session["PayMode"] = "Online";
        //Generate order and insert into db
        string orderid = "";
        orderid=InsertIntoDB();
        Session["PayOrderId"] = orderid;
        Response.Redirect("Checkout_ConfirmOrder.aspx");
    }
        
    protected void lnkChange_OnClick(object sender, EventArgs e)
    {
        Session["CameAgain"] = "1";
        Response.Redirect("Checkout_Shipping.aspx");
    }

    //Insert into DB functions
    protected string InsertIntoDB()
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

        bool IsPaid = false;
        bool IsCOD = false;

        double discount = 0;
        double discountValue = 0;

        if (Session["Discount"] != null)
        {
            discount = (double)Session["Discount"];
            discountValue = (double)Session["DiscountValue"];
        }

        //Insert into invoice master
        Int32 invoiceid;
        invoiceid = (Int32)cls.ReturnScaler("Insert_InvoiceMasterForOnlinePay", new SqlParameter("MemberId", Memberid),
                                                               new SqlParameter("@OrderId", orderid),
                                                              new SqlParameter("@ShippingCharges", "0"),
                                                              new SqlParameter("@OrderAmount", clsCart.TotalPrice()),
                                                              new SqlParameter("@OrderQty", clsCart.TotalQty()),
                                                              new SqlParameter("@PaypalId", ""),
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
      //  lblOredrId.Text = orderid.ToString();
        setPdfandMail(invoiceid, orderid);
        return orderid.ToString();
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
        dt = cls.ReturnDataTable("Select_InvoiceBillShipDetailsFromIDForOnline", new SqlParameter("@InvoiceId", invoiceid));

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

            rptShippingPdf.DataSource = dt;
            rptShippingPdf.DataBind();

            rptrCutomerTin.DataSource = dt;
            rptrCutomerTin.DataBind();
        }
    }
    protected void BindProduct(double invoiceid)
    {
        DataTable dtprod = new DataTable();
        dtprod = cls.ReturnDataTable("Select_InvoiceProductDetailsFromIDForOnline", new SqlParameter("@InvoiceId", invoiceid));
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
        dtprod = cls.ReturnDataTable("Select_InvoiceProductDetailsFromIDForOnline", new SqlParameter("@InvoiceId", invoiceid));
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

        writer.PageEvent = new HeaderFooterCheckout(cellLeft);
        htmlparser.Parse(sr);
        pdfDoc.Close();
        pdfDoc.Dispose();
        sr.Close();
        sr.Dispose();
        srheader.Close();
        sr.Dispose();
        writer.Close();
        writer.Dispose();

       // Mail(orderid, filname);
    }

}
public class HeaderFooterCheckout : PdfPageEventHelper
{
    PdfContentByte pdfContent;
    PdfTemplate template;
    protected BaseFont helv;
    BaseFont bf = null;
    PdfPCell cellLeft;

    private float headerhgt = 0;
    public HeaderFooterCheckout(PdfPCell cell)
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