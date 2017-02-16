<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="UpdateInvoice.aspx.cs" Inherits="Admin_UpdateInvoice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .floatleft
        {
            display: block;
            float: left;
        }
        
        .floatleft50
        {
            display: block;
            float: left;
            width: 50%;
            margin-top: 5px;
        }
        .floatleft33
        {
            display: block;
            float: left;
            width: 33%;
            margin-top: 5px;
        }
        
        .floatright
        {
            display: block;
            float: right;
        }
        
        .width100px
        {
            width: 110px !important;
        }
        
        .margin5
        {
            margin-bottom: 12px;
            margin-left: 0;
            margin-right: 0;
            margin-top: 5px;
            width: 450px;
            color: #666;
        }
    </style>
    <script type="text/javascript">
        $("#form1").validate();
    </script>
    <div class="widget">
        <div class="head">
            <h5 class="iList">
                <div class="floatleft" style="width: 800px;">
                    Order Details</div>
                <div class="floatright">
                    <a href="Orders.aspx">Back to Order</a>
                </div>
            </h5>
        </div>
        <asp:Repeater runat="server" ID="rptOrder">
            <ItemTemplate>
                <div class="rowElem noborder">
                    <div class="floatleft50">
                        <label class="width100px">
                            Order No :</label>
                        <div class="margin5">
                            <asp:Label ID="lblOrderNo" runat="server" Text='<%# Bind("OrderId") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Transaction ID :</label>
                        <div class="margin5">
                            <asp:Label ID="Label14" runat="server" Text='<%# Bind("PaypalId") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft33">
                        <label class="width100px">
                            Order Date :</label>
                        <div class="margin5">
                            <asp:Label ID="lblOrderdate" runat="server" Text='<%# Eval("OrderDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft33">
                        <label>
                            Order Amount :</label>
                        <div class="margin5">
                            INR&nbsp;<asp:Label ID="lblOrderAmt" runat="server" Text='<%# Math.Round(Convert.ToDouble(Eval("OrderAmount"))) %>'></asp:Label>
                            <asp:Label runat="server" ID="lblDisPer" Text='<%# Eval("DiscountPer") %>' Visible="false"></asp:Label>
                            <div class="fix">
                            </div>
                        </div>
                    </div>
                    <div class="floatleft33">
                        <label>
                            Invoice Amount :</label>
                        <div class="margin5">
                            <asp:Label ID="lblInvoiceAmount" runat="server" Text='<%# Math.Round(Convert.ToDouble(Eval("InvoiceAmount"))) %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="rowElem ">
            <div class="floatleft33">
                <label class="width100px">
                    Invoice No :</label>
                <div class="margin5">
                    <asp:Label ID="lblInvoiceNo" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblInvoiceNoMail" runat="server" Text="" Visible="false"></asp:Label>
                    <div class="fix">
                    </div>
                </div>
            </div>
            <div class="floatleft33">
                <label>
                    Invoice Date :<span class="req">*</span></label>
                <div class="margin5">
                    <asp:TextBox ID="txtDate" runat="server" CssClass="datepicker required" Width="250px"></asp:TextBox>
                    <div class="fix">
                    </div>
                </div>
            </div>
            <div class="floatleft33">
                <label>
                    Status :<span class="req">*</span></label>
                <div class="margin5">
                    <asp:DropDownList runat="server" ID="drpStatus" CssClass="required">
                            <asp:ListItem Text="Select Order Status"></asp:ListItem>
                            <asp:ListItem Text="Payment Verification Pending"></asp:ListItem>
                            <asp:ListItem Text="COD Verification Pending"></asp:ListItem>
                            <asp:ListItem Text="Order Under Processing "></asp:ListItem>
                            <asp:ListItem Text="Order Packed"></asp:ListItem>
                            <asp:ListItem Text="Order Shipped"></asp:ListItem>                           
                            <asp:ListItem Text="Order Cancelled"></asp:ListItem>
                            <asp:ListItem Text="Order Completed"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="fix" style="padding-bottom: 10px;">
        </div>
        <div class="fix">
        </div>
    </div>
    <div class="widget">
        <div class="head">
            <h5 class="iList">
                Invoice Generated for Products</h5>
        </div>
        <asp:Repeater runat="server" ID="rptGeneratedProduct">
            <ItemTemplate>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            <strong>
                                <div class="floatleft" style="padding-right: 5px; padding-bottom: 5px;">
                                    <asp:CheckBox runat="server" ID="chk" ToolTip='<%# Eval("ProductId") %>' Checked="true" />
                                </div>
                                &nbsp;Product Name :</strong></label>
                        <div class="margin5">
                            <strong>
                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label></strong>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            <strong>Product Code :</strong></label>
                        <div class="margin5">
                            <strong>
                                <asp:Label ID="lblProductPrice" runat="server" Text='<%# Bind("ProductCode") %>'></asp:Label></strong>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem ">
                    <div class="floatleft50">
                        <label class="width100px">
                            &nbsp;&nbsp;&nbsp; &nbsp;Colour :</label>
                        <div class="margin5">
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ColourName") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Size :</label>
                        <div class="margin5">
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("SizeName") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem ">
                    <div class="floatleft50">
                        <label class="width100px">
                            &nbsp;&nbsp;&nbsp; &nbsp;Quantity :</label>
                        <div class="margin5">
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblProPrice" Text='<%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) %>'
                                Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblTotal" Text=' <%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) * Convert.ToDouble(Eval("Quantity")) %> '
                                Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Shipping Days :</label>
                        <div class="margin5">
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("ShippingDays") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="fix">
        </div>
    </div>
    <div class="widget">
        <div class="head">
            <h5 class="iList">
                Pending Products</h5>
        </div>
        <asp:Repeater runat="server" ID="rptPendingproducts">
            <ItemTemplate>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            <strong>
                                <div class="floatleft" style="padding-right: 5px; padding-bottom: 5px;">
                                    <asp:CheckBox runat="server" ID="chk" ToolTip='<%# Eval("ProductId") %>' />
                                </div>
                                &nbsp;Product Name :</strong></label>
                        <div class="margin5">
                            <strong>
                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label></strong>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            <strong>Product Code :</strong></label>
                        <div class="margin5">
                            <strong>
                                <asp:Label ID="lblProductPrice" runat="server" Text='<%# Bind("ProductCode") %>'></asp:Label></strong>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem ">
                    <div class="floatleft50">
                        <label class="width100px">
                            &nbsp;&nbsp;&nbsp; &nbsp;Colour :</label>
                        <div class="margin5">
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ColourName") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Size :</label>
                        <div class="margin5">
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("SizeName") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem ">
                    <div class="floatleft50">
                        <label class="width100px">
                            &nbsp;&nbsp;&nbsp; &nbsp;Quantity :</label>
                        <div class="margin5">
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblProPrice" Text='<%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) %>'
                                Visible="false"></asp:Label>
                            <asp:Label runat="server" ID="lblTotal" Text=' <%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) * Convert.ToDouble(Eval("Quantity")) %> '
                                Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Shipping Days :</label>
                        <div class="margin5">
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("ShippingDays") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="fix">
        </div>
    </div>
    <div class="widget">
        <div class="head">
            <h5 class="iList">
                Tracking Details</h5>
        </div>
        <div class="rowElem ">
            <div class="floatleft50">
                <label class="width100px">
                    Courier Name :<span class="req">*</span></label>
                <div class="margin5">
                    <asp:DropDownList runat="server" ID="drpCourier">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="floatleft50">
                <label class="width100px">
                    Tracking No :<span class="req">*</span></label>
                <div class="margin5">
                    <asp:TextBox runat="server" ID="txtTrackingNo" Width="300px" CssClass="required"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender runat="server" ID="ftbeTrack" ValidChars="0123456789"
                        TargetControlID="txtTrackingNo" FilterMode="ValidChars">
                    </cc1:FilteredTextBoxExtender>
                </div>
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="rowElem">
            <div class="floatleft">
                <label class="width100px">
                    Other Details :</label>
            </div>
            <div class="floatleft">
                <div class="margin5">
                    <asp:TextBox runat="server" ID="txtOtherDetails" Width="770px" TextMode="MultiLine"
                        Height="100px"></asp:TextBox>
                    <div class="fix">
                    </div>
                </div>
            </div>
        </div>
        <div class="fix">
        </div>
        <div class="submitForm" style="width: 100%; margin-top: 10px; margin-right: 0px;">
            <div style="float: right">
                <asp:Button ID="btnGenerate" runat="server" Text="Update Invoice" CssClass="greyishBtn"
                    OnClick="btnGenerate_Click" />
            </div>
            <div style="float: right; padding-top: 5px; padding-right: 10px;">
            </div>
        </div>
    </div>
    <div class="widget">
        <div class="head">
            <h5 class="iList">
                Shipping Details</h5>
        </div>
        <asp:Repeater runat="server" ID="rptShipping">
            <ItemTemplate>
                <div class="rowElem noborder">
                    <div class="floatleft50">
                        <label class="width100px">
                            Name :</label>
                        <div class="margin5">
                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("SName") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Company :</label>
                        <div class="margin5">
                            <asp:Label ID="lblCompany" runat="server" Text='<%# Bind("SCompany") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft">
                        <label class="width100px">
                            Address :</label>
                        <div class="margin5">
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("SAddress1") %>'></asp:Label>
                        </div>
                    </div>
                    <%-- <div class="floatleft50">
                        <label class="width100px">
                            Address Line 2:</label>
                        <div class="margin5">
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("SAddress2") %>'></asp:Label>
                        </div>
                    </div>--%>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            City :</label>
                        <div class="margin5">
                            <asp:Label ID="lblCity" runat="server" Text='<%# Bind("SCity") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            State :</label>
                        <div class="margin5">
                            <asp:Label ID="lblState" runat="server" Text='<%# Bind("SState") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            Country :</label>
                        <div class="margin5">
                            <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("SCountry") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Zipcode :</label>
                        <div class="margin5">
                            <asp:Label ID="lblZipCode" runat="server" Text='<%# Bind("SZipCode") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            Contact :</label>
                        <div class="margin5">
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("SContact") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Email :</label>
                        <div class="margin5">
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("SEmail") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="fix">
        </div>
    </div>
    <div class="widget">
        <div class="head">
            <h5 class="iList">
                Billing Details</h5>
        </div>
        <asp:Repeater runat="server" ID="rptBill">
            <ItemTemplate>
                <div class="rowElem noborder">
                    <div class="floatleft50">
                        <label class="width100px">
                            Company :</label>
                        <div class="margin5">
                            <asp:Label ID="lblCompany" runat="server" Text='<%# Bind("Company") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Contact :</label>
                        <div class="margin5">
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("Contact") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft">
                        <label class="width100px">
                            Address :</label>
                        <div class="margin5">
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address1") %>'></asp:Label>
                        </div>
                    </div>
                    <%--<div class="floatleft50">
                        <label class="width100px">
                            Address Line 2:</label>
                        <div class="margin5">
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("Address2") %>'></asp:Label>
                        </div>
                    </div>--%>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            City :</label>
                        <div class="margin5">
                            <asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            State :</label>
                        <div class="margin5">
                            <asp:Label ID="lblState" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            Country :</label>
                        <div class="margin5">
                            <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Zipcode :</label>
                        <div class="margin5">
                            <asp:Label ID="lblZipCode" runat="server" Text='<%# Bind("ZipCode") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            TIN No :</label>
                        <div class="margin5">
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <div class="floatleft50">
                            <label class="width100px">
                                CST No :</label>
                            <div class="margin5">
                                <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="fix">
        </div>
    </div>
    <div style="display: none;">
        <asp:Panel runat="server" ID="pnlHeader" BorderWidth="0">
            <table style="width: 600px;" cellspacing="0" cellpadding="0" border="0">
                <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #333333;
                        text-align: center;" height="30px" align="center" valign="top">
                        <b>INVOICE DETAIL</b>
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
                                    <strong>Profoma Order</strong><br />
                                    <a href="http://www.dhitsolutions.com" target="_blank" style="color: #FF4F12; text-decoration: none;">
                                        www.dhitsolutions.org</a><br />
                                    45, Gunatit park,<br />
                                    Gotri Road, Vadodara<br />
                                    Gujarat - 390021<br />
                                    Email&nbsp;&nbsp;: <a href="mailto:mail@dhitsolutions.org" style="color: #FF4F12;
                                        text-decoration: none;">mail@dhitsolutions.org</a><br />
                                    Contact&nbsp;:&nbsp;+91-9722659812<br />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                    font-size: 10px; color: #333333; width: 390px; line-height: 14px;" class="height450">
                                    Shipping Details<br />
                                    <asp:Repeater runat="server" ID="rptrShipping">
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
                                    <asp:Repeater runat="server" ID="rptrBilling">
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
                        <asp:Repeater runat="server" ID="rptOrderDetails" OnItemDataBound="rptOrderDetails_ItemDataBound">
                            <ItemTemplate>
                                <table style="width: 300px; border-collapse: collapse;" border="0.1" cellspacing="0"
                                    cellpadding="5" class="wdth400">
                                    <tr>
                                        <td align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                            font-size: 10px; color: #333333; width: 165px; height: 35px;">
                                            Invoice No<br />
                                            <strong>
                                                <asp:Label runat="server" ID="lblInvNo" Text=' <%# Eval("InvoiceNumber") %>'></asp:Label>
                                            </strong>
                                        </td>
                                        <td align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                            font-size: 10px; color: #333333; width: 165px; height: 35px;">
                                            Invoice Date<br />
                                            <strong>
                                                <%# Eval("InvoiceDate","{0:dd-MM-yyyy}")%></strong>
                                        </td>
                                    </tr>
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
                                            Logistic Partner<br />
                                            <strong><a href="<%# Eval("URL") %>" target="_blank" style="color: #FF4F12; text-decoration: underline;">
                                                <%# Eval("CourierName")%></a></strong>
                                        </td>
                                        <td align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                            font-size: 10px; color: #333333; width: 165px; height: 35px;">
                                            Payment Mode<br />
                                            <strong>
                                                <%# Eval("PaymentMode")%></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                            font-size: 10px; color: #333333; width: 165px; height: 35px;" colspan="2">
                                            Shipping Billing No<br />
                                            <asp:Image ID="imgBarcode" runat="server" /><br />
                                            <asp:Label runat="server" ID="lblTrackNo" Text='<%# Eval("TrackingNumber") %>' Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="middle" style="font-family: Arial, Helvetica, sans-serif;
                                            font-size: 10px; color: #333333; width: 165px; height: 35px;" colspan="2">
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
                <asp:Repeater runat="server" ID="rptrCart" OnItemDataBound="rptrCart_ItemDataBound">
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
                        <asp:Label runat="server" ID="lblCoupon" Text=""></asp:Label>&nbsp;<strong>Discount</strong>
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
                       <%-- Company's PAN : AHHPG0414C<br />
                        Company's TIN : 24190204502<br />
                        Company's CST : 24690204502<br />
                       --%> <asp:Repeater runat="server" ID="rptrCutomerTin">
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
