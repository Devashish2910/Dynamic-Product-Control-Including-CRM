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

public partial class Admin_UpdateInvoice : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    public static string invoiceid, invoicedispatchid;
    public static DataTable dtprod = new DataTable();
    public static DataTable dtPendingprod = new DataTable();
    public static DataTable dtship = new DataTable();
    public static DataTable dt = new DataTable();
    public static string orderno, invno;
    public long id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Utils.IsLoggedIn())
        {
            Utils.LogOut();
        }
        else
        {
            if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null && Request.QueryString["InvID"] != "" && Request.QueryString["InvID"] != null)
            {
                Label lblFormTitle = (Label)this.Master.FindControl("lblFormTitle");
                lblFormTitle.Text = "Update Invoice";

                invoicedispatchid = Request.QueryString["InvID"].ToString();
                invoiceid = Request.QueryString["ID"].ToString();
                if (!IsPostBack)
                {
                    BindDrpCourier();
                    BindOrderDetails();
                    BindOrderProducts();
                    BindShippingBilling();
                }
            }
            else
            {
                Response.Redirect("Order.aspx");
            }
        }
    }
    protected void BindOrderDetails()
    {
        dt = cls.ReturnDataTable("Select_InvoiceWiseOrderDetailsFromID", new SqlParameter("@InvoiceId", invoiceid),
                                                                         new SqlParameter("@InvoiceDispatchID", invoicedispatchid));
        rptOrder.DataSource = dt;
        rptOrder.DataBind();
        if (dt.Rows.Count > 0)
        {
            drpStatus.SelectedValue = dt.Rows[0]["OrderStatus"].ToString();
            orderno = dt.Rows[0]["OrderId"].ToString();
            lblInvoiceNo.Text = dt.Rows[0]["InvoiceNumber"].ToString();
            txtDate.Text=cls.FormatDate_US_Ind(dt.Rows[0]["InvoiceDate"].ToString());
            txtTrackingNo.Text = dt.Rows[0]["TrackingNumber"].ToString();
            txtOtherDetails.Text = dt.Rows[0]["OtherDetails"].ToString();
            drpCourier.SelectedValue = dt.Rows[0]["URL"].ToString();
            invno = dt.Rows[0]["InvoiceNo"].ToString();
            lblInvoiceNoMail.Text = "TSM_Invoice_" + orderno + "-" + invno;
        }
    }
    protected void BindOrderProducts()
    {
        dtprod = cls.ReturnDataTable("Select_InvoiceDispatchProductDetailsFromID", new SqlParameter("@InvoiceId", invoiceid),
                                                                                   new SqlParameter("@InvoiceDispatchID", invoicedispatchid));
        rptGeneratedProduct.DataSource = dtprod;
        rptGeneratedProduct.DataBind();

        dtPendingprod = cls.ReturnDataTable("Select_PendingInvoiceProductFromOrderId", new SqlParameter("@InvoiceId", invoiceid));
        rptPendingproducts.DataSource = dtPendingprod;
        rptPendingproducts.DataBind();
    }
    protected void BindShippingBilling()
    {
        dtship = cls.ReturnDataTable("Select_InvoiceBillingShippingFromOrderId", new SqlParameter("@InvoiceId", invoiceid));
        rptShipping.DataSource = dtship;
        rptShipping.DataBind();

        rptBill.DataSource = dtship;
        rptBill.DataBind();
    }
    protected void BindDrpCourier()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_CourierMaster");
        drpCourier.DataSource = dt;
        drpCourier.DataTextField = "CourierName";
        drpCourier.DataValueField = "URL";
        drpCourier.DataBind();
    }
   
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        //checking product selected or not
        if (checkproducts())
        {
            //insert into db

            //update order status in invoice master
            cls.ExecuteDA("Update_InvoiceOrderStatus", new SqlParameter("@InvoiceId", invoiceid),
                                                       new SqlParameter("@OrderStatus", drpStatus.SelectedItem.Text));

            //calculate 

            CalcualtePrices();

            //deelete from dispacth and dispatch detail product

            cls.ExecuteDA("Delete_InvoiceDispatch", new SqlParameter("@InvoiceId", invoiceid),
                                                   new SqlParameter("@InvoiceNo", invno));

            //delete from dispatch product
            cls.ExecuteDA("Delete_InvoiceDispatchProduct", new SqlParameter("@InvoiceId", invoiceid),
                                                          new SqlParameter("@InvoiceDispatchId", invoicedispatchid));

            //insert into invoice dispatch
            
            id = (long)cls.ReturnScaler("Insert_InvoiceDispatch", new SqlParameter("@InvoiceId", Convert.ToInt32(invoiceid)),
                                                                new SqlParameter("@InvoiceNumber", lblInvoiceNo.Text),
                                                                new SqlParameter("@InvoiceNo", invno),
                                                                new SqlParameter("@CourierName", drpCourier.SelectedItem.Text),
                                                                new SqlParameter("@URL", drpCourier.SelectedValue.ToString()),
                                                                new SqlParameter("@TrackingNumber", txtTrackingNo.Text),
                                                                new SqlParameter("@InvoiceDate", cls.FormatDate_IND_US(txtDate.Text)),
                                                                new SqlParameter("@Barcode", txtTrackingNo.Text),
                                                                new SqlParameter("@OtherDetails", txtOtherDetails.Text),
                                                                new SqlParameter("@InvoiceAmount", ViewState["InvoiceAmount"]),
                                                                new SqlParameter("@InvoiceDiscountPer", ViewState["InvoiceDiscountPer"]),
                                                                new SqlParameter("@InvoiceDiscountAmount", ViewState["InvoiceDiscountAmount"]),
                                                                new SqlParameter("@InvoiceOriginalAmount", ViewState["InvoiceOriginalAmount"]));

            //insert into invoice dispatch product for disptached products which are updated
            foreach (RepeaterItem ri in rptGeneratedProduct.Items)
            {
                CheckBox chk = (CheckBox)ri.FindControl("chk");
                if (chk != null)
                {
                    if (chk.Checked == true)
                    {
                        cls.ExecuteDA("Insert_InvoiceDispatchProduct", new SqlParameter("@InvoiceId", invoiceid),
                                                                       new SqlParameter("@InvoiceDispatchId", id),
                                                                       new SqlParameter("@ProductId", chk.ToolTip.ToString()));

                        //update isdispatch in invoice product
                        cls.ExecuteDA("Update_InvoiceProductIsDispatch", new SqlParameter("@InvoiceId", Convert.ToInt32(invoiceid)),
                                                                         new SqlParameter("@ProductId", chk.ToolTip.ToString()),
                                                                         new SqlParameter("@IsDispatched", 1));
                    }
                    else
                    {
                        //update isdispatch in invoice product
                        cls.ExecuteDA("Update_InvoiceProductIsDispatch", new SqlParameter("@InvoiceId", Convert.ToInt32(invoiceid)),
                                                                         new SqlParameter("@ProductId", chk.ToolTip.ToString()),
                                                                         new SqlParameter("@IsDispatched", false));
                    }
                }
            }


            //insert into invoice dispatch product for pending products
            foreach (RepeaterItem ri in rptPendingproducts.Items)
            {
                CheckBox chk = (CheckBox)ri.FindControl("chk");
                if (chk != null)
                {
                    if (chk.Checked == true)
                    {
                        cls.ExecuteDA("Insert_InvoiceDispatchProduct", new SqlParameter("@InvoiceId", invoiceid),
                                               new SqlParameter("@InvoiceDispatchId", id),
                                               new SqlParameter("@ProductId", chk.ToolTip.ToString()));

                        //update isdispatch in invoice product
                        cls.ExecuteDA("Update_InvoiceProductIsDispatch", new SqlParameter("@InvoiceId", Convert.ToInt32(invoiceid)),
                                                                         new SqlParameter("@ProductId", chk.ToolTip.ToString()),
                                                                         new SqlParameter("@IsDispatched", 1));
                    }
                  
                }
            }
            setPdfandMail(id.ToString(), invoiceid);
            Response.Redirect("Orders.aspx");
        }
        else
        {
            MsgBox("Please select product to generate invoice");
        }
    }
    protected bool checkproducts()
    {
        bool flag = false;
        foreach (RepeaterItem ri in rptPendingproducts.Items)
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

        foreach (RepeaterItem ri in rptGeneratedProduct.Items)
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
    protected void CalcualtePrices()
    {
        Label lblDisPer = new Label();
        foreach (RepeaterItem ri1 in rptOrder.Items)
        {
            lblDisPer = (Label)ri1.FindControl("lblDisPer");
        }

        double InvoiceDiscountPer = Convert.ToDouble(lblDisPer.Text);
        double InvoiceAmount = 0;
        double InvoiceDiscountAmount = 0;
        double InvoiceOriginalAmount = 0;

        //for pending products

        foreach (RepeaterItem ri in rptPendingproducts.Items)
        {
            CheckBox chk = (CheckBox)ri.FindControl("chk");
            Label lblTotal = (Label)ri.FindControl("lblTotal");
            if (chk != null)
            {
                if (chk.Checked == true)
                {
                    InvoiceOriginalAmount = InvoiceOriginalAmount + Convert.ToDouble(lblTotal.Text);
                }
            }
        }

        //for genrated products which are updated

        foreach (RepeaterItem ri in rptGeneratedProduct.Items)
        {
            CheckBox chk = (CheckBox)ri.FindControl("chk");
            Label lblTotal = (Label)ri.FindControl("lblTotal");
            if (chk != null)
            {
                if (chk.Checked == true)
                {
                    InvoiceOriginalAmount = InvoiceOriginalAmount + Convert.ToDouble(lblTotal.Text);
                }
            }
        }


        InvoiceDiscountAmount = InvoiceOriginalAmount * (InvoiceDiscountPer / 100);
        InvoiceAmount = InvoiceOriginalAmount - InvoiceDiscountAmount;

        ViewState["InvoiceAmount"] = InvoiceAmount;
        ViewState["InvoiceDiscountPer"] = InvoiceDiscountPer;
        ViewState["InvoiceDiscountAmount"] = InvoiceDiscountAmount;
        ViewState["InvoiceOriginalAmount"] = InvoiceOriginalAmount;
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

    // for pdf creation and mail
    protected void setPdfandMail(string invoicedispatchid, string invoiceid)
    {
        BindOrder(invoicedispatchid, invoiceid);
        BindProduct(invoicedispatchid, invoiceid);
        CreartePdf();
    }
    protected void BindOrder(string invoicedispatchid, string invoiceid)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_InvoiceBillShipDetailsFromID", new SqlParameter("@InvoiceId", invoiceid));


        DataTable dt1 = new DataTable();
        dt1 = cls.ReturnDataTable("Select_InvoiceWiseOrderDetailsFromID", new SqlParameter("@InvoiceId", invoiceid),
                                                                                   new SqlParameter("@InvoiceDispatchID", invoicedispatchid));
        rptOrderDetails.DataSource = dt1;
        rptOrderDetails.DataBind();

        rptrBilling.DataSource = dt;
        rptrBilling.DataBind();

        rptrShipping.DataSource = dt;
        rptrShipping.DataBind();

        if (dt.Rows.Count > 0)
        {
            ViewState["ToMail"] = dt.Rows[0]["SEmail"].ToString();
        }

        rptrCutomerTin.DataSource = dt;
        rptrCutomerTin.DataBind();

        //if (dt1.Rows.Count > 0)
        //{
        //    invoiceno = dt1.Rows[0]["InvoiceNumber"].ToString();
        //}

        //if (dt.Rows.Count > 0 && dt1.Rows.Count > 0)
        //{
        //    lblOrderNo.Text = dt.Rows[0]["OrderID"].ToString() + " ( " + dt1.Rows[0]["InvoiceNumber"].ToString() + " ) ";
        //}

    }
    protected void BindProduct(string invoicedispatchid, string invoiceid)
    {
        DataTable dtprod = new DataTable();
        dtprod = cls.ReturnDataTable("Select_InvoiceDispatchProductDetailsFromID", new SqlParameter("@InvoiceId", invoiceid),
                                                                                   new SqlParameter("@InvoiceDispatchID", invoicedispatchid));
        rptrCart.DataSource = dtprod;
        rptrCart.DataBind();

        if (dtprod.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(dtprod.Rows[0]["CouponName"])))
            {
                lblCoupon.Text = "Using Voucher Code (" + dtprod.Rows[0]["CouponName"] + ")";
                lblDisPer.Text = "(" + dtprod.Rows[0]["InvoiceDiscountPer"] + "%)";
                lblDisVal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["InvoiceDiscountAmount"])).ToString();
            }
            else
            {
                lblCoupon.Text = "";
            }
        }
    }
    protected void rptrCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        NumbertoWords num = new NumbertoWords();
        DataTable dtprod = new DataTable();
        dtprod = cls.ReturnDataTable("Select_InvoiceDispatchProductDetailsFromID", new SqlParameter("@InvoiceId", invoiceid),
                                                                                  new SqlParameter("@InvoiceDispatchID", id));
        lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["InvoiceAmount"])).ToString();
        lblAmountinWords.Text = num.NumberToWords(Convert.ToInt32(lblFinalTotal.Text)) + " only.";
        lblFinalTotal.Text = Math.Round(Convert.ToDouble(dtprod.Rows[0]["InvoiceAmount"])).ToString();
    }
    protected void rptOrderDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblTrackNo = (Label)e.Item.FindControl("lblTrackNo");
            Label lblInvNo = (Label)e.Item.FindControl("lblInvNo");
            System.Web.UI.WebControls.Image imgBarcode = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgBarcode");
            Code39BarCode barcode = new Code39BarCode();
            barcode.BarCodeText = lblTrackNo.Text;
            barcode.BarCodeWeight = BarCodeWeight.Small;


            byte[] filecontent = barcode.Generate();
            string filepath = Server.MapPath("../Admin/InvoicePdf/" + lblInvNo.Text + ".gif");
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

            File.WriteAllBytes(filepath, filecontent);

            imgBarcode.ImageUrl = filepath;

            //imgBarcode.ImageUrl = string.Format("ShowCode39BarCode.ashx?code={0}&ShowText={1}&Thickness={2}",
            //                                lblTrackNo.Text,
            //                                1,
            //                                1);


        }
    }
    protected void CreartePdf()
    {
        string filname = Server.MapPath("../Admin/InvoicePdf/" + lblInvoiceNoMail.Text + ".pdf");

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

        writer.PageEvent = new HeaderFooter2(cellLeft);
        htmlparser.Parse(sr);
        pdfDoc.Close();
        pdfDoc.Dispose();
        sr.Close();
        sr.Dispose();
        srheader.Close();
        sr.Dispose();
        writer.Close();
        writer.Dispose();

        Mail(filname);
    }
    protected void Mail(string filename)
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
        strMailHtml.Append("                    <img border='0' src='http://dhitsolutions.com/images/logo.png' alt='chiptronics'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='30' align='left' valign='middle' style='font-size: 12px; font-weight: bold; color: #555555; text-decoration: none; font-family: Arial;'>Dear Customer,");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("                <td height='25' align='right' valign='middle' style='font-size: 12px; text-decoration: none; font-family: Arial'>");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='' style='font-size: 12px; text-decoration: none; font-family: Arial; line-height: 22px;'>");
        strMailHtml.Append("                  We have dispatched/part dispatched your order number <span style='font-weight: bold; color: #555555; font-size: 14px;'>" + orderno + "</span>.<br />");
        strMailHtml.Append("                    You can track order status by <a target='_blank' style='text-decoration: underline; color: #ff4f12'");
        strMailHtml.Append("                        href='http://www.dhitsolutions.com/TrackOrder.aspx'>clicking here</a>.<br />");
        strMailHtml.Append("                    For any order related query, contact us at <a target='_blank' style='text-decoration: none; color: #ff4f12'");
        strMailHtml.Append("                        href='mailto:mail@dhitsolutions.org'>mail@dhitsolutions.org</a> or<br />");
        strMailHtml.Append("                    Call us at <span style='font-weight: bold; color: #555555; font-size: 14px;'>1800 200 1619</span>.<br />");
        strMailHtml.Append("                    Dispatch details have been attached in this email. Any pending items for your order will be dispatched as and when the same is available.");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td height='25' colspan='2' align='left' valign='middle' style='font-size: 12px; font-weight: bold; color: #000000; text-decoration: none; font-family: Arial;'>Regards,");
        strMailHtml.Append("                </td>");
        strMailHtml.Append("            </tr>");
        strMailHtml.Append("            <tr>");
        strMailHtml.Append("                <td colspan='2' style='font-family: Arial; font-size: 11px; color: #000000; text-decoration: none; line-height: 22px; font-weight: bold'>dhitsolutions<br>");
        strMailHtml.Append("                    302, Pearl, Nautilus, Vasna Road, Vadodara - 390015<br />");
        strMailHtml.Append("                    <u>Phone</u> : +91 (0) 265 6540611");
        strMailHtml.Append("                    <br>");
        strMailHtml.Append("                    <u>Email</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12' href='mailto:mail@dhitsolutions.org'>mail@dhitsolutions.org</a> <u>Web</u> : <a target='_blank' style='text-decoration: none; color: #ff4f12'");
        strMailHtml.Append("                        href='http://www.dhitsolutions.com'>www.dhitsolutions.com</a>");
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
            MailAddress fromAdd = new MailAddress("mail@dhitsolutions.org");
            MailAddress replyto = new MailAddress("mail@dhitsolutions.org");
            mailMsg.From = fromAdd;
            mailMsg.ReplyTo = replyto;
            mailMsg.To.Add(ViewState["ToMail"].ToString());
            mailMsg.Bcc.Add("mail@dhitsolutions.org");
            mailMsg.Bcc.Add("mail@dhitsolutions.org");
            mailMsg.IsBodyHtml = true;
            mailMsg.Subject = "Invoice Number : " + lblInvoiceNo.Text;

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(filename);
            mailMsg.Attachments.Add(attachment);

            mailMsg.Body = strAdmin;
            // SmtpClient smtp = new SmtpClient();
            // smtp.Send(mailMsg);
            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("mail@dhitsolutions.org", "12345");
            smtp.Send(mailMsg);
            attachment.Dispose();
        }
        catch (Exception ex)
        {

        }
        
    }
}
public partial class HeaderFooter2 : PdfPageEventHelper
{
    PdfContentByte pdfContent;
    PdfTemplate template;
    protected BaseFont helv;
    BaseFont bf = null;
    PdfPCell cellLeft;

    private float headerhgt = 0;
    public HeaderFooter2(PdfPCell cell)
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