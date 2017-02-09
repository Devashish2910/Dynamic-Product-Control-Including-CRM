<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Checkout_Payment.aspx.cs" Inherits="Checkout_Payment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/smart_tab_vertical.css" rel="stylesheet" type="text/css" />    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="#">Checkout</a> <span class="divider">/</span></li>
            <%--   <li><a href="#">Account</a> <span class="divider">/</span></li>--%>
            <li class="active">Payment Options</li>
        </ul>
        <div class="row">
            <div class="span12 post cartcheckoutres">
                <div class="row-fluid">
                    <div class="span9">
                        <div class="row-fluid">
                            <a href="Default.aspx" class="checkout_hover left div_checkout checkout_block">1. Home </a><a href="Checkout_Shipping.aspx" class="checkout_hover left div_checkout checkout_block">2. Shipping Address </a><a href="Checkout_Order.aspx" class="checkout_hover left div_checkout checkout_block">3. Order Summary </a>
                            <div class="left div_checkout checkout_active">
                                4. Payment Options
                            </div>
                        </div>
                        <div class="sidebar-line">
                            <span style="background: none !important;"></span>
                        </div>
                        <div class="row-fluid">
                            <!-- Tabs -->
                            <div id="tabs">
                                <ul>
                                    <li><a href="#tabs-1">Cash On Delivery<br />
                                        <small></small>
                                    </a></li>
                                    <li><a href="#tabs-2">Cheque / Demand Draft<br />
                                        <small></small>
                                    </a></li>
                                    <li><a href="#tabs-3">Deposit in Bank A/C<br />
                                        <small></small>
                                    </a></li>
                                    <li><a href="#tabs-4">Online Payment<br />
                                        <small></small>
                                    </a></li>
                                </ul>
                                <div id="tabs-1">
                                    <h2>Pay using Cash on delivery</h2>
                                    <p>
                                        Pay the cash to our logistic provider when you received the delivery at your doorsteps rather than paying in advance.  Cash on Delivery (COD) charge are applied as a Shipping and Handling.
                                    </p>
                                    <div class="row-fluid">
                                        <div class="fntbold">
                                            Amount Payable on Delivery :&nbsp;<asp:Label runat="server" ID="lblFinalAmount" CssClass="fntmarron"></asp:Label>
                                        </div>
                                        <div class="clearfix5">
                                        </div>
                                        <div>
                                            <b>Verify Order</b><br />
                                            Type the characters you see in this image.<br />
                                            <asp:UpdatePanel ID="UP1" runat="server">
                                                <ContentTemplate>
                                                    <div class="left">
                                                        <asp:Image ID="imgCaptcha" runat="server" />
                                                    </div>
                                                    <div class="left padleft10">
                                                        <asp:ImageButton runat="server" ImageUrl="images/refresh-icon.png" ID="btnRefresh"
                                                            OnClick="btnRefresh_Click" />
                                                    </div>
                                                    <div class="clearfix5">
                                                    </div>
                                                    <asp:TextBox ID="txtCode" runat="server" Wrap="False" Width="180px" CssClass="textbox"></asp:TextBox>
                                                    &nbsp;
                                                <asp:Label runat="server" ID="lblMsg" CssClass="fntmarron"></asp:Label>
                                                    <div class="clearfix5">
                                                    </div>
                                                    <div class="span4 fright margintop10">
                                                        <asp:Button Text="Place Order" ID="btnOrder" runat="server" CssClass=" btn btn-medium btn-general input-block-level btnpalceorderres"
                                                            OnClick="btnOrder_Click" />
                                                        <div class="clearfix25">
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div id="tabs-2">
                                    <h2>Pay using Cheque / Demand Draft</h2>
                                    <p>
                                        You have to send us Cheque / DD in the name of "RNG Performance Materials" for the below mentioned amount.<br />
                                        Note: We will process your order only on the receipt of payment. In case of Cheque, the order will be processed after the cheque clearance.
                                        
                                    </p>
                                    <div class="row-fluid">
                                        <div class="fntbold">
                                            Cheque/Demand Draft Amount :&nbsp;<asp:Label runat="server" ID="lblFinalAmount1" CssClass="fntmarron"></asp:Label>
                                        </div>
                                        <div class="clearfix5">
                                        </div>
                                        <div>
                                            <b>Verify Order</b><br />
                                            Type the characters you see in this image.<br />
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <div class="left">
                                                        <asp:Image ID="imgCaptcha1" runat="server" />
                                                    </div>
                                                    <div class="left padleft10">
                                                        <asp:ImageButton runat="server" ImageUrl="images/refresh-icon.png" ID="btnRefresh1"
                                                            OnClick="btnRefresh1_Click" />
                                                    </div>
                                                    <div class="clearfix5">
                                                    </div>
                                                    <asp:TextBox ID="txtCode1" runat="server" Wrap="False" Width="180px" CssClass="textbox"></asp:TextBox>
                                                    &nbsp;
                                                <asp:Label runat="server" ID="lblMsg1" CssClass="fntmarron"></asp:Label>
                                                    <div class="clearfix5">
                                                    </div>
                                                    <div class="span4 fright margintop10">
                                                        <asp:Button Text="Place Order" ID="btnOrder1" runat="server" CssClass=" btn btn-medium btn-general input-block-level btnpalceorderres"
                                                            OnClick="btnOrder1_Click" />
                                                        <div class="clearfix25">
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div id="tabs-3">
                                    <h2>Pay using Bank Transfer</h2>
                                    <p>
                                        You have to deposit the below amount in our bank account to process the order.<br />
                                        Note: We will process your order only on the receipt of payment to our bank.<br />
                                    </p>
                                    <p>
                                        Bank Details:<br />
                                        Bank Account Name : xxxxx<br />
                                        Bank Name   : xxxxxxx<br />
                                    </p>
                                    <p class="mrgleft10">
                                        Bank Account No.      : xxxxxxxxx<br />
                                        IFSC CODE   : xxxxxxxxx<br />
                                        Swift CODE       : xxxxxxxxx<br />
                                        Bank Address     : xxxxxxxxxx.
                                    </p>

                                    <div class="row-fluid">
                                        <div class="fntbold">
                                            Amount Payable :&nbsp;<asp:Label runat="server" ID="lblFinalAmount2" CssClass="fntmarron"></asp:Label>
                                        </div>
                                        <div class="clearfix5">
                                        </div>
                                        <div>
                                            <b>Verify Order</b><br />
                                            Type the characters you see in this image.<br />
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <div class="left">
                                                        <asp:Image ID="imgCaptcha2" runat="server" />
                                                    </div>
                                                    <div class="left padleft10">
                                                        <asp:ImageButton runat="server" ImageUrl="images/refresh-icon.png" ID="btnRefresh2"
                                                            OnClick="btnRefresh2_Click" />
                                                    </div>
                                                    <div class="clearfix5">
                                                    </div>
                                                    <asp:TextBox ID="txtCode2" runat="server" Wrap="False" Width="180px" CssClass="textbox"></asp:TextBox>
                                                    &nbsp;
                                                <asp:Label runat="server" ID="lblMsg2" CssClass="fntmarron"></asp:Label>
                                                    <div class="clearfix5">
                                                    </div>
                                                    <div class="span4 fright margintop10">
                                                        <asp:Button Text="Place Order" ID="btnOrder2" runat="server" CssClass=" btn btn-medium btn-general input-block-level btnpalceorderres"
                                                            OnClick="btnOrder2_Click" />
                                                        <div class="clearfix25">
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div id="tabs-4">
                                    <h2>Pay using Credit Card / Debit Card / Net Banking</h2>
                                    <p>
                                        <div class="row-fluid">
                                            <div class="fntbold">
                                                Amount Payable :&nbsp;<asp:Label runat="server" ID="lblFinalAmount3" CssClass="fntmarron"></asp:Label>
                                            </div>
                                            <div class="clearfix5">
                                            </div>
                                            <div>
                                                Note: After clicking on the "Pay" button, you will be directed to a secure gateway
                                        for payment. After completing the payment process, you will be redirected back to
                                        timeoffice.com to view details of your order.
                                        *BUT THIS SERVICE IS TEMPORALLY UNAVAILABLE ON THIS SITE.
                                            </div>
                                            <div class="clearfix5">
                                            </div>
                                            <%--<div class="span4 fright margintop10">
                                                <asp:Button Text="Pay Now" ID="btnPay" runat="server"
                                                    CssClass=" btn btn-medium btn-general input-block-level btnpalceorderres"
                                                    OnClick="btnPay_Click" />
                                            </div>--%>
                                            <div class="clearfix5">
                                            </div>
                                            <div class="fntnote span12">
                                                * By placing the order, you have read and agree to timeoffice.com Terms of
                                        Use and Privacy Policy.
                                            </div>
                                        </div>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="span3 padtop10">
                        <h2 class="widget-title">
                            <span>Order Summary</span></h2>
                        <div class="sidebar-line1" style="margin-bottom: 0px !important;">
                            <span></span>
                        </div>
                        <div class=" row-fluid ordersummaryborder">
                            <div class="mrg10px">
                                Items :
                                <asp:Label runat="server" ID="lblTotalItems"></asp:Label>
                                <br />
                                Total:
                                <asp:Label runat="server" ID="lblTotalAmount"></asp:Label>
                            </div>
                        </div>
                        <div class="clearfix margintop20">
                        </div>
                        <span class="span8">
                            <h2 class="widget-title">
                                <span>Shipping Summary</span></h2>
                        </span><span class="span3">
                            <div class="fright">
                                <asp:LinkButton runat="server" ID="lnkChange" OnClick="lnkChange_OnClick">Change</asp:LinkButton>
                            </div>
                        </span>
                        <div class="clearfix">
                        </div>
                        <div class="sidebar-line1 " style="margin-bottom: 0px !important;">
                            <span></span>
                        </div>
                        <div class=" row-fluid ordersummaryborder">
                            <div class="mrg10px">
                                <asp:Repeater runat="server" ID="rptShipping">
                                    <ItemTemplate>
                                        <%#Eval("SName")%><br />
                                        <%#Eval("SAddress1")%><br />
                                        <%#Eval("SCity")%>&nbsp;-&nbsp;
                                        <%#Eval("SZipcode")%><br />
                                        <%#Eval("SState")%>&nbsp;,&nbsp;
                                        <%#Eval("SCountry")%><br />
                                        <%#Eval("SEmail")%>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
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
                                                    <strong>RNG Performance Materials</strong><br />
                                                    <a href="http://www.timeoffice.in" target="_blank" style="color: #FF4F12; text-decoration: none;">
                                                        www.timeoffice.com</a><br />
                                                    address,<br />
                                                    address<br />
                                                    address<br />
                                                    Email&nbsp;&nbsp;: <a href="mailto:suppport@timeoffice.in" style="color: #FF4F12;
                                                        text-decoration: none;">suppport@timeoffice.in</a><br />
                                                    Contact&nbsp;:&nbsp;+91 (0) 265 6540611<br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                                    font-size: 10px; color: #333333; width: 390px; line-height: 14px;" class="height450">
                                                    Shipping Details<br />
                                                    <asp:Repeater runat="server" ID="rptShippingPdf">
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
                                        Company's PAN : xxxxxxxC<br />
                                        Company's TIN : xxxxxxxxxx<br />
                                        Company's CST : xxxxxxxxxx<br />
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
   <%-- <script type="text/javascript" src="js/jquery-1.8.0.min.js"></script>--%>
   <%-- <script type="text/javascript" src="js/jquery.smartTab.js"></script>--%>
   <%-- <script type="text/javascript">
        jQuery(document).ready(function ($) {
            // Smart Tab
            $('#tabs').smartTab({ autoProgress: false, stopOnFocus: true, transitionEffect: 'vSlide' });
        });
    </script>--%>
</asp:Content>
