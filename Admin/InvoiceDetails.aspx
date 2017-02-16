<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="InvoiceDetails.aspx.cs" Inherits="Admin_InvoiceDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../js/print.js">
    </script>
    <div class="widget">
        <div class="head">
            <asp:Repeater runat="server" ID="rptHeader">
                <ItemTemplate>
                    <h5 class="iList">
                        <div class="floatleft" style="width: 800px;">
                            Invoice for Order No. :
                            <asp:Label runat="server" ID="lblOrderNo" Text='<%# Eval("OrderId") %>'></asp:Label>
                        </div>
                        <div class="floatright">
                            <a href='Invoices.aspx?ID=<%# Eval("InvoiceId") %>'>Back to Invoice</a>
                        </div>
                    </h5>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div style="background-color: white; padding-top: 10px;" align="center">
        <table width="800" cellspacing="0" cellpadding="0">
            <tr>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                    text-align: right" align="right">
                    <a href="#!" style="background-color: #b72709 !important; color: #ffffff !important;
                        border-style: solid; border-width: 1px; cursor: pointer; display: inline-block;
                        margin-bottom: 0; padding: 2px 12px; text-align: center; vertical-align: middle;
                        text-decoration: none;" onclick="return printContent('printArea');">PRINT</a>
                </td>
            </tr>
        </table>
        
        <div id="printArea">
            <table width="800" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 14px; color: #333;
                        text-align: center;" height="30px" align="center" valign="top">
                        <b>INVOICE</b>
                    </td>
                </tr>
            </table>
            <table width="800" cellspacing="0" cellpadding="0" style="border: solid 1px #666;">
                <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;">
                        <table width="800" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="400" style="font-family: Arial, Helvetica, sans-serif; font-size: 12px;
                                    color: #333; border-bottom: solid 1px #666;">
                                    <table width="400" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="35" align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                font-size: 12px; color: #333; border-bottom: solid 1px #666; width: 390px; padding-left: 10px;
                                                border-right: solid 1px #666; line-height: 20px; padding-top: 5px; padding-bottom: 5px;">
                                                <strong>Profoma Invoice</strong><br />
                                                <a href="http://www.dhitsolutions.com" target="_blank" style="color: #FF4F12; text-decoration: none;">
                                                    www.dhitsolutions.com</a><br />
                                                45, Gunatit park,<br />
                                                behnd T.B.Hospital, Gotri Vadodara.<br />
                                                Gujarat - 390021<br />
                                                Email&nbsp;&nbsp;: <a href="mailto:mail@dhitsolutions.org" style="color: #FF4F12;
                                                    text-decoration: none;">mail@dhitsolutions.org</a><br />
                                                Contact&nbsp;: +91 9722659812
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="35" align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                font-size: 12px; color: #333; border-bottom: solid 1px #666; width: 390px; padding-left: 10px;
                                                border-right: solid 1px #666; line-height: 20px; padding-top: 5px; padding-right: 10px;
                                                padding-bottom: 5px;">
                                                Shipping Details<br />
                                                <asp:Repeater runat="server" ID="rptShipping">
                                                    <ItemTemplate>
                                                        <strong>
                                                            <%#Eval("SName")%></strong><br />
                                                        <%#Eval("SAddress1")%>&nbsp;,&nbsp;<%#Eval("SCity")%><br />
                                                        <%#Eval("SState")%>&nbsp;-&nbsp;<%#Eval("SZipcode")%><br />
                                                        Email&nbsp;&nbsp;: <a href="mailto:<%# Eval("SEmail") %>" style="color: #FF4F12;
                                                            text-decoration: none;">
                                                            <%# Eval("SEmail") %></a><br />
                                                        Contact&nbsp;:
                                                        <%#Eval("SContact") %>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="35" align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                font-size: 12px; color: #333; width: 390px; padding-left: 10px; border-right: solid 1px #666;
                                                line-height: 20px; padding-top: 5px; padding-right: 10px; padding-bottom: 5px;">
                                                Billing Details<br />
                                                <asp:Repeater runat="server" ID="rptBilling">
                                                    <ItemTemplate>
                                                        <strong>
                                                            <%#Eval("Company")%></strong><br />
                                                        <%#Eval("Address1")%>&nbsp;,&nbsp;<%#Eval("City")%><br />
                                                        <%#Eval("State")%>&nbsp;-&nbsp;<%#Eval("Zipcode")%><br />
                                                        Contact&nbsp;:
                                                        <%#Eval("Contact") %>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="400" height="35" align="left" valign="top" style="font-family: Arial, Helvetica, sans-serif;
                                    font-size: 12px; color: #333; border-bottom: solid 1px #666;">
                                    <asp:Repeater runat="server" ID="rptOrderDetails" OnItemDataBound="rptOrderDetails_ItemDataBound">
                                        <ItemTemplate>
                                            <table width="400" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="190" height="35" align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                        font-size: 12px; color: #333; border-bottom: solid 1px #666; width: 390px; padding-left: 10px;
                                                        border-right: solid 1px #666;">
                                                        Invoice No<br />
                                                        <strong>
                                                            <%# Eval("InvoiceNumber") %></strong>
                                                    </td>
                                                    <td width="190" height="35" align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                        font-size: 12px; color: #333; border-bottom: solid 1px #666; width: 390px; padding-left: 10px;">
                                                        Invoice Date<br />
                                                        <strong>
                                                            <%# Eval("InvoiceDate","{0:dd-MM-yyyy}")%></strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="190" height="35" align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                        font-size: 12px; color: #333; border-bottom: solid 1px #666; width: 390px; padding-left: 10px;
                                                        border-right: solid 1px #666;">
                                                        Order No<br />
                                                        <strong>
                                                            <%# Eval("OrderId") %></strong>
                                                    </td>
                                                    <td width="190" height="35" align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                        font-size: 12px; color: #333; border-bottom: solid 1px #666; width: 390px; padding-left: 10px;">
                                                        Order Date<br />
                                                        <strong>
                                                            <%# Eval("OrderDate","{0:dd-MM-yyyy}")%></strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="35" align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                        font-size: 12px; color: #333; border-bottom: solid 1px #666; width: 390px; padding-left: 10px;
                                                        border-right: solid 1px #666;">
                                                        Logistic Partner<br />
                                                        <strong><a href="<%# Eval("URL") %>" target="_blank" style="color: #FF4F12; text-decoration: underline;">
                                                            <%# Eval("CourierName")%></a></strong>
                                                    </td>
                                                    <td height="35" align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                        font-size: 12px; color: #333; border-bottom: solid 1px #666; width: 390px; padding-left: 10px;">
                                                        Payment Mode<br />
                                                        <strong>
                                                            <%# Eval("PaymentMode")%></strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="35" align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                        font-size: 12px; color: #333; border-bottom: solid 1px #666; width: 390px; padding-left: 10px;
                                                        padding-bottom: 10px;" colspan="2">
                                                        Shipping Billing No<br />
                                                        <asp:Image ID="imgBarcode" runat="server" /><br />
                                                        <asp:Label runat="server" ID="lblTrackNo" Text='<%# Eval("TrackingNumber") %>' Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="35" align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                        font-size: 12px; color: #333; width: 390px; padding-left: 10px;" colspan="2">
                                                        Other Details<br />
                                                        <strong>
                                                            <%# Eval("OtherDetails") %></strong>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;"
                                    colspan="2">
                                    <%--<table width="800px" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" width="40" height="35" align="center" valign="middle"><strong>Sl No</strong></td>
                                                                
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" width="150" height="35" align="center" valign="middle"><strong>Product Name</strong></td>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" width="80" height="35" align="center" valign="middle"><strong>Code</strong></td>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" width="110" height="35" align="center" valign="middle"><strong>Delivery Details</strong></td>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" width="70" height="35" align="center" valign="middle"><strong>Quantity</strong></td>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" width="60" height="35" align="center" valign="middle"><strong>Rate</strong></td>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" width="50" height="35" align="center" valign="middle"><strong>Per</strong></td>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" width="70" height="35" align="center" valign="middle"><strong>Dis (%)</strong></td>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-bottom: solid 1px #666;" width="80" height="35" align="center" valign="middle"><strong>Price</strong></td>
                                                            </tr>
                                                            <asp:Repeater runat="server" ID="rptrCart" OnItemDataBound="rptrCart_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" width="30" height="35" align="center" valign="middle"><%# Container.ItemIndex+1 %></td>
                                                                       
                                                                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666; padding-left: 5px; padding-right: 5px; padding-top: 5px; padding-bottom: 5px;" height="35" align="center" valign="middle"><b>
                                                                            <%# Eval("ProductName") %></b><br />
                                                                            <br />
                                                                            <b>Size :</b>
                                                                            <asp:Label runat="server" ID="lblSize" Text='<%# Eval("SizeName") %>'></asp:Label>
                                                                            <br />
                                                                            <b>Color :</b>
                                                                            <asp:Label runat="server" ID="lblColor" Text='<%# Eval("ColourName") %>'></asp:Label><br />
                                                                            <span style="font-size: 11px;">Inclusive of <%# Eval("Tax") %>%&nbsp;sales tax (INR <%# Math.Round(Convert.ToDouble(Eval("TaxFinalPrice"))) %>)</span>
                                                                        </td>
                                                                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666; padding-left: 5px; padding-right: 5px;" height="35" align="center" valign="middle"><%# Eval("ProductCode") %></td>
                                                                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center" valign="middle"><%# Eval("ShippingDays") %> days</td>
                                                                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center" valign="middle">
                                                                            <asp:Label runat="server" ID="lblQty" CssClass="price" Text='<%# Eval("Quantity") %>'
                                                                                MaxLength="5"></asp:Label></td>
                                                                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center" valign="middle">
                                                                            <asp:Label runat="server" ID="lblProPrice" Text='<%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) %>' Visible="false"></asp:Label>
                                                                            <%# Math.Round(Convert.ToDouble(Eval("SalesPrice_Incl"))) %></td>
                                                                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center" valign="middle"><%# Eval("unit") %></td>
                                                                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center" valign="middle"><%# Eval("Discount") %></td>
                                                                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-bottom: solid 1px #666;" height="35" align="center" valign="middle">
                                                                            <asp:Label runat="server" ID="lblTotal" Text=' <%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) * Convert.ToDouble(Eval("Quantity")) %> '></asp:Label></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            <tr>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; padding-right: 15px; border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="right" colspan="7">
                                                                    <asp:Label runat="server" ID="lblCoupon" Text=""></asp:Label>&nbsp;<strong>Discount</strong></td>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center">
                                                                    <asp:Label runat="server" ID="lblDisPer" Text="(0%)"></asp:Label></td>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-bottom: solid 1px #666;" height="35" align="center"><strong>
                                                                    <asp:Label runat="server" ID="lblDisVal" Text="0"></asp:Label></strong></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666; padding-left: 10px;" height="35" colspan="7"><strong>Amount in Words (rupees)&nbsp;:&nbsp;
                                                <asp:Label runat="server" ID="lblAmountinWords"></asp:Label></strong></td>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center"><strong>Total</strong></td>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-bottom: solid 1px #666; padding-left: 5px; padding-right: 5px;" height="35" align="center"><strong>
                                                                    <asp:Label runat="server" ID="lblFinalTotal" Text=""></asp:Label>&nbsp;Rs.</strong></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; padding-left: 10px; padding-top: 10px; padding-bottom: 10px; line-height: 20px;" height="35" colspan="9">Company's PAN : AHHPG0414C<br />
                                                                    Company's TIN : 24190204502<br />
                                                                    Company's CST : 24690204502<br />
                                                                    <asp:Repeater runat="server" ID="rptrCutomerTin">
                                                                        <ItemTemplate>
                                                                            Customer's TIN :  <%# Eval("Name") %><br />
                                                                            Customer's CST : <%# Eval("Email") %>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </td>
                                                            </tr>
                                                        </table>--%>
                                    <table width="800px" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                border-right: solid 1px #666; border-bottom: solid 1px #666;" width="40" height="35"
                                                align="center" valign="middle">
                                                <strong>Sl No</strong>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                border-right: solid 1px #666; border-bottom: solid 1px #666;" width="150" height="35"
                                                align="center" valign="middle">
                                                <strong>Product Name</strong>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                border-right: solid 1px #666; border-bottom: solid 1px #666;" width="110" height="35"
                                                align="center" valign="middle">
                                                <strong>Code</strong>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                border-right: solid 1px #666; border-bottom: solid 1px #666;" width="90" height="35"
                                                align="center" valign="middle">
                                                <strong>Delivery Details</strong>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                border-right: solid 1px #666; border-bottom: solid 1px #666;" width="75" height="35"
                                                align="center" valign="middle">
                                                <strong>Qty (per pack)</strong>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                border-right: solid 1px #666; border-bottom: solid 1px #666;" width="70" height="35"
                                                align="center" valign="middle">
                                                <strong>Rate (Rs.)</strong>
                                            </td>
                                            <%--                                                <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" width="50" height="35" align="center" valign="middle"><strong>Per</strong></td>--%>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                border-right: solid 1px #666; border-bottom: solid 1px #666;" width="45" height="35"
                                                align="center" valign="middle">
                                                <strong>Dis (%)</strong>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                border-bottom: solid 1px #666;" width="110" height="35" align="center" valign="middle">
                                                <strong>Price (Rs.)</strong>
                                            </td>
                                        </tr>
                                        <asp:Repeater runat="server" ID="rptrCart" OnItemDataBound="rptrCart_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                        border-right: solid 1px #666; border-bottom: solid 1px #666;" width="30" height="35"
                                                        align="center" valign="middle">
                                                        <%# Container.ItemIndex+1 %>
                                                    </td>
                                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                        border-right: solid 1px #666; border-bottom: solid 1px #666; padding-left: 5px;
                                                        padding-right: 5px; padding-top: 5px; padding-bottom: 5px;" height="35" align="center"
                                                        valign="middle">
                                                        <strong>
                                                            <%# Eval("ProductName") %></strong><br /> (<%# Eval("PackSize") %>)
                                                        <br />
                                                        <strong>Size :</strong>
                                                        <asp:Label runat="server" ID="lblSize" Text='<%# Eval("SizeName") %>'></asp:Label>
                                                        <br />
                                                        <strong>Color :</strong>
                                                        <asp:Label runat="server" ID="lblColor" Text='<%# Eval("ColourName") %>'></asp:Label><br />
                                                        <span style="font-size: 11px;">Inclusive of
                                                            <%# Eval("Tax") %>%&nbsp;sales tax<br />
                                                            (INR
                                                            <%# Math.Round(Convert.ToDouble(Eval("TaxFinalPrice"))) %>)</span>
                                                    </td>
                                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                        border-right: solid 1px #666; border-bottom: solid 1px #666; padding-left: 5px;
                                                        padding-right: 5px;" height="35" align="center" valign="middle">
                                                        <%# Eval("ProductCode") %>
                                                    </td>
                                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                        border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center"
                                                        valign="middle">
                                                        <%# Eval("ShippingDays") %>&nbsp;Days
                                                    </td>
                                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                        border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center"
                                                        valign="middle">
                                                        <asp:Label runat="server" ID="lblQty" CssClass="price" Text='<%# Eval("Quantity") %>'
                                                            MaxLength="5"></asp:Label>
                                                    </td>
                                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                        border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center"
                                                        valign="middle">
                                                        <strong>
                                                            <asp:Label runat="server" ID="lblProPrice" Text='<%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) %>'
                                                                Visible="false"></asp:Label>
                                                            <%# Math.Round(Convert.ToDouble(Eval("SalesPrice_Incl"))) %>
                                                        </strong>
                                                    </td>
                                                    <%--                                                                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333; border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center" valign="middle"><%# Eval("unit") %></td>--%>
                                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                        border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center"
                                                        valign="middle">
                                                        <%# Eval("Discount") %>
                                                    </td>
                                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                        border-bottom: solid 1px #666;" height="35" align="center" valign="middle">
                                                        <strong>
                                                            <asp:Label runat="server" ID="lblTotal" Text=' <%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) * Convert.ToDouble(Eval("Quantity")) %> '></asp:Label>
                                                        </strong>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                padding-right: 15px; border-right: solid 1px #666; border-bottom: solid 1px #666;"
                                                height="35" align="right" colspan="6">
                                                <asp:Label runat="server" ID="lblCoupon" Text=""></asp:Label>&nbsp;<strong>Discount</strong>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center">
                                                <asp:Label runat="server" ID="lblDisPer" Text="(0%)"></asp:Label>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                border-bottom: solid 1px #666;" height="35" align="center">
                                                <strong>
                                                    <asp:Label runat="server" ID="lblDisVal" Text="0"></asp:Label></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                border-right: solid 1px #666; border-bottom: solid 1px #666; padding-left: 10px;"
                                                height="35" colspan="6">
                                                <strong>Amount in Words (rupees)&nbsp;:&nbsp;
                                                    <asp:Label runat="server" ID="lblAmountinWords"></asp:Label></strong>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                border-right: solid 1px #666; border-bottom: solid 1px #666;" height="35" align="center">
                                                <strong>Total</strong>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                border-bottom: solid 1px #666; padding-left: 5px; padding-right: 5px;" height="35"
                                                align="center">
                                                <strong>
                                                    <asp:Label runat="server" ID="lblFinalTotal" Text=""></asp:Label></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; color: #333;
                                                padding-left: 10px; padding-top: 10px; padding-bottom: 10px; line-height: 20px;"
                                                height="35" colspan="8">
                                               <%-- Company's PAN : AHHPG0414C<br />
                                                Company's TIN : 24190204502<br />
                                                Company's CST : 24690204502<br />--%>
                                                <asp:Repeater runat="server" ID="rptrCutomerTin">
                                                    <ItemTemplate>
                                                        Customer's TIN :
                                                        <%# Eval("Name") %><br />
                                                        Customer's CST :
                                                        <%# Eval("Email") %>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <div style="text-align: center; font-size: 11px; font-family: Arial; padding-top: 10px;
                line-height: 20px;">
                Subject to Vadodara Jurisdiction.<br />
                This is a Computer Generated Order.
            </div>
        </div>
    </div>
</asp:Content>
