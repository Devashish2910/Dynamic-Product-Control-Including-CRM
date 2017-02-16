<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="PaymentSuccess.aspx.cs" Inherits="PaymentSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel runat="server" ID="pnlSuccess" Visible="false">
        <div class="container make-bg">
            <ul class="breadcrumb">
                <li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
                <li class="active">Payment</li>
            </ul>
            <div class="row">
                <div class="span12 post">
                    <h2 class="page-header">
                        <span>Payment Success</span></h2>
                    <div class="sidebar-line">
                        <span></span>
                    </div>
                    <div class="row-fluid">
                        <p>
                            Thank You
                        </p>
                        <p>
                            Your order has been placed successfully.
                            <br />
                            <br />
                            Order ID&nbsp;:&nbsp;<asp:Label runat="server" ID="lblOredrId" Font-Bold="true"></asp:Label>
                        </p>
                        <a href="Default.aspx" class="btn btn-general">Shop More</a>
                    </div>
                    <div style="display: none;">
                        <asp:Panel runat="server" ID="pnlHeader" BorderWidth="0">
                            <table style="width: 600px;" cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #333333;
                                        text-align: center;" height="30px" align="center" valign="top">
                                        <b>ORDER DETAIL</b>
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 550px;" border="0.1" cellspacing="0" cellpadding="0" class="wdth550">
                                <tr>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        width: 300px;" class="wdth200">
                                        <table style="width: 300px; border-collapse: collapse;" cellspacing="0" cellpadding="5"
                                            class="wdth200" border="0.1">
                                            <tr>
                                                <td align="left" valign="middle" class="borderright" style="font-family: Arial, Helvetica, sans-serif;
                                                    font-size: 10px; color: #333333; width: 390px; line-height: 14px;">
                                                    <strong>xyz companies</strong><br />
                                                    <a href="http://www.xyz.com" target="_blank" style="color: #FF4F12; text-decoration: none;">
                                                        www.xyz.com</a><br />
                                                    address<br />
                                                    add1<br />
                                                    address<br />
                                                    Email&nbsp;&nbsp;: <a href="mailto:suppport@xyz.com" style="color: #FF4F12;
                                                        text-decoration: none;">suppport@xyz.com</a><br />
                                                    Contact&nbsp;:&nbsp;+91 (0) 452 77885544<br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                    font-size: 10px; color: #333333; width: 390px; line-height: 14px;" class="height450">
                                                    Shipping Details<br />
                                                    <asp:Repeater runat="server" ID="rptShipping">
                                                        <ItemTemplate>
                                                            <strong>
                                                                <%#Eval("SName")%></strong><br />
                                                            <%#Eval("SAddress1")%>&nbsp;,&nbsp;
                                                            <%#Eval("SCity")%><br />
                                                            <%#Eval("SState")%>&nbsp;-&nbsp;
                                                            <%#Eval("SZipcode")%><br />
                                                            Email&nbsp;&nbsp;: <a href="mailto:<%# Eval("SEmail") %>" style="color: #FF4F12;
                                                                text-decoration: none;">
                                                                <%# Eval("SEmail") %></a><br />
                                                            Contact&nbsp;:
                                                            <%#Eval("SContact") %><br />
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                    font-size: 10px; color: #333333; width: 390px; line-height: 14px; height: 200px;">
                                                    Billing Details<br />
                                                    <asp:Repeater runat="server" ID="rptBilling">
                                                        <ItemTemplate>
                                                            <strong>
                                                                <%#Eval("Company")%></strong><br />
                                                            <%#Eval("Address1")%>&nbsp;,&nbsp;
                                                            <%#Eval("City")%><br />
                                                            <%#Eval("State")%>&nbsp;-&nbsp;
                                                            <%#Eval("Zipcode")%><br />
                                                            Contact&nbsp;:
                                                            <%#Eval("Contact") %><br />
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left" valign="top" style="font-family: Arial, Helvetica, sans-serif; font-size: 10px;
                                        color: #333333; height: 35px;" class="wdth400">
                                        <asp:Repeater runat="server" ID="rptOrderDetails">
                                            <ItemTemplate>
                                                <table style="width: 300px; border-collapse: collapse;" border="0.1" cellspacing="0"
                                                    cellpadding="5" class="wdth400">
                                                    <tr>
                                                        <td align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                            font-size: 10px; color: #333333; width: 165px; height: 35px;">
                                                            Order No<br />
                                                            <strong>
                                                                <%# Eval("OrderId") %></strong>
                                                        </td>
                                                        <td align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                            font-size: 10px; color: #333333; width: 165px; height: 35px;">
                                                            Order Date<br />
                                                            <strong>
                                                                <%# Eval("OrderDate","{0:dd-MM-yyyy}")%></strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                            font-size: 10px; color: #333333; width: 165px; height: 35px;">
                                                            Order Status<br />
                                                            <strong>
                                                                <%# Eval("OrderStatus")%></strong>
                                                        </td>
                                                        <td align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                            font-size: 10px; color: #333333; width: 165px; height: 35px;">
                                                            Payment Mode
                                                            <br />
                                                            <strong>
                                                                <%# Eval("PaymentMode")%></strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 541px;" cellspacing="0" cellpadding="2" border="0.1" class="wdth541">
                                <tr>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        width: 20px; height: 35px;" align="center" valign="middle" class="wdth20">
                                        <strong>Sl No</strong>
                                    </td>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        width: 140px; height: 35px;" align="center" valign="middle" class="wdth140">
                                        <strong>Product Name</strong>
                                    </td>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        width: 80px; height: 35px;" align="center" valign="middle" class="wdth100">
                                        <strong>Code</strong>
                                    </td>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        width: 80px; height: 35px;" align="center" valign="middle" class="wdth65">
                                        <strong>Delivery Details</strong>
                                    </td>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        width: 50px; height: 35px;" align="center" valign="middle" class="wdth55">
                                        <strong>Qty<br />
                                            (per pack)</strong>
                                    </td>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        width: 50px; height: 35px;" align="center" valign="middle" class="wdth51">
                                        <strong>Rate<br />
                                            (Rs.)</strong>
                                    </td>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        width: 50px; height: 35px;" align="center" valign="middle" class="wdth40">
                                        <strong>Dis<br />
                                            (%)</strong>
                                    </td>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        width: 80px; height: 35px;" align="center" valign="middle" class="wdth60">
                                        <strong>Price<br />
                                            (Rs.)</strong>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlMail">
                            <table style="width: 541px;" border="0.1" cellspacing="0" cellpadding="2" class="wdth541">
                                <asp:Repeater runat="server" ID="rptrCart">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                                width: 20px;" width="30" height="35" align="center" valign="middle" class="wdth20">
                                                <%# Container.ItemIndex+1 %>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                                width: 140px;" align="center" valign="middle" class="wdth140">
                                                <%# Eval("ProductName") %></b><br />
                                                (<%# Eval("PackSize") %>)
                                                <br />
                                                <b>Size :</b>
                                                <asp:Label runat="server" ID="lblSize" Text='<%# Eval("SizeName") %>'></asp:Label>
                                                <br />
                                                <b>Color :</b>
                                                <asp:Label runat="server" ID="lblColor" Text='<%# Eval("ColourName") %>'></asp:Label><br />
                                                <span style="font-size: 9px;">Inclusive of
                                                    <%# Eval("Tax") %>%&nbsp;sales tax<br />
                                                    (INR
                                                    <%# Math.Round(Convert.ToDouble(Eval("TaxFinalPrice"))) %>)</span>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                                height: 35px; width: 80px;" align="center" valign="middle" class="wdth100">
                                                <%# Eval("ProductCode") %>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                                height: 35px; width: 80px;" align="center" valign="middle" class="wdth65">
                                                <%# Eval("ShippingDays") %>
                                                days
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                                height: 35px; width: 50px;" align="center" valign="middle" class="wdth55">
                                                <asp:Label runat="server" ID="lblQty" CssClass="price" Text='<%# Eval("Quantity") %>'
                                                    MaxLength="5"></asp:Label>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                                height: 35px; width: 50px;" align="center" valign="middle" class="wdth51">
                                                <asp:Label runat="server" ID="lblProPrice" Text='<%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) %>'
                                                    Visible="false"></asp:Label>
                                                <%# Math.Round(Convert.ToDouble(Eval("SalesPrice_Incl"))) %>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                                height: 35px; width: 50px;" align="center" valign="middle" class="wdth40">
                                                <%# Eval("Discount") %>
                                            </td>
                                            <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                                height: 35px; width: 80px;" align="center" valign="middle" class="wdth60">
                                                <asp:Label runat="server" ID="lblTotal" Text=' <%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) * Convert.ToDouble(Eval("Quantity")) %> '></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        padding-right: 15px; height: 35px;" align="right" colspan="6">
                                        <asp:Label runat="server" ID="lblCoupon" Text=""></asp:Label>&nbsp;&nbsp;<strong>Discount</strong>
                                    </td>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        height: 35px;" align="center">
                                        <asp:Label runat="server" ID="lblDisPer" Text="(0%)"></asp:Label>
                                    </td>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        height: 35px;" align="center">
                                        <strong>
                                            <asp:Label runat="server" ID="lblDisVal" Text="0"></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        height: 35px;" colspan="6">
                                        <strong>Amount in Words (rupees)&nbsp;:&nbsp;
                                            <asp:Label runat="server" ID="lblAmountinWords"></asp:Label></strong>
                                    </td>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        height: 35px;" align="center">
                                        <strong>Total</strong>
                                    </td>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        height: 35px;" align="center">
                                        <strong>
                                            <asp:Label runat="server" ID="lblFinalTotal" Text=""></asp:Label></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 10px; color: #333333;
                                        padding-top: 10px; padding-bottom: 10px; line-height: 20px; height: 35px;" colspan="8">
                                        Company's PAN : fadfadfadf<br />
                                        Company's TIN : 44552211445<br />
                                        Company's CST : 45552211445<br />
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
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>
