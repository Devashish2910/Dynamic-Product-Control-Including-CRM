<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="TrackOrder.aspx.cs" Inherits="TrackOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .custom .span6
        {
            width: 49.99%;
        }

        .table-bordered th, .table-bordered td
        {
            border-left: 1px solid #ccc;
            border-top: solid 1px #666;
        }

        .table
        {
            margin-bottom: 0px !important;
            width: 100%;
        }

        .table-bordered
        {
            border-top: solid 1px #666;
            border-collapse: collapse;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
            <li class="active">Track Order</li>
        </ul>
        <div class="row dashboradlinksres">
            <div class="span3 sidebar">
                <div class="">
                    <h2 class="widget-title">
                        <span>Track Order</span></h2>
                    <div class="sidebar-line">
                        <span></span>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <label>
                                <span class="required">*</span>Order Number</label>
                            <div class="fright error">
                                <asp:RequiredFieldValidator runat="server" ID="rfv3" ControlToValidate="txtOrderNumber" Display="Dynamic" ErrorMessage="Enter Order Number" ValidationGroup="track"></asp:RequiredFieldValidator>
                                <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtOrderNumber"
                                    ValidChars="0123456789" FilterMode="ValidChars">
                                </asp:FilteredTextBoxExtender>
                            </div>
                            <asp:TextBox runat="server" ID="txtOrderNumber" CssClass="input-block-level"></asp:TextBox>
                            <label>
                                <span class="required">*</span>Email Id</label>
                            <div class="fright error">
                                <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="txtEmailId" Display="Dynamic" ErrorMessage="Enter Email" ValidationGroup="track"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server" ID="reg1" ControlToValidate="txtEmailId" Display="Dynamic" ErrorMessage="Enter Valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="track"></asp:RegularExpressionValidator>
                            </div>
                            <asp:TextBox runat="server" ID="txtEmailId" CssClass="input-block-level" ValidationGroup="carrer"></asp:TextBox>
                            <div class="fright ">
                                <asp:LinkButton ID="btnCheckStatus" runat="server" CssClass="btn btn-general" ValidationGroup="track" OnClick="btnCheckStatus_Click">
                                            <span><i class="icon-search"></i>Check</span>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="span9 post">
                <asp:Panel runat="server" ID="pnlTrack" Visible="false">
                    <div class="row-fluid custom">
                        <div class="span12">
                            <h2 class="page-header">Order Detail</h2>
                            <div class="sidebar-line">
                                <span></span>
                            </div>
                            <div class="row-fluid borderbox accorderdetres">
                                <div class="span6 borderbox_right">
                                    <div class="borderbox_bottom">
                                        <div class="padding_box">
                                            <strong>xyz</strong><br />
                                            <a href="http://www.xyz.com" target="_blank" style="color: #FF4F12; text-decoration: none;">www.xyz.com</a><br />
                                            address<br />
                                            address<br />
                                            address<br />
                                            Email&nbsp;&nbsp;: <a href="mailto:abc@xyz.com">abc@xyz.com</a><br />
                                            Contact&nbsp;: +91 (0) 45217800
                                        </div>
                                    </div>
                                    <div class="clearfix5"></div>
                                    <div class="padding_box">
                                        Shipping Details
                                    </div>
                                    <div class="clear"></div>
                                    <div class="borderbox_bottom">
                                        <div class="padding_box">
                                            <asp:Repeater runat="server" ID="rptShipping">
                                                <ItemTemplate>
                                                    <strong><%#Eval("SName")%></strong><br />
                                                    <%#Eval("SAddress1")%>&nbsp;,&nbsp;<%#Eval("SCity")%><br />
                                                    <%#Eval("SState")%>&nbsp;-&nbsp;<%#Eval("SZipcode")%><br />
                                                    Email&nbsp;&nbsp;: <a href="mailto:<%# Eval("SEmail") %>"><%# Eval("SEmail") %></a><br />
                                                    Contact&nbsp;: <%#Eval("SContact") %>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <div class="clearfix5"></div>
                                    <div class="padding_box">
                                        Billing Details
                                    </div>
                                    <div class="clear"></div>
                                    <div class="padding_box">
                                        <asp:Repeater runat="server" ID="rptBilling">
                                            <ItemTemplate>
                                                <strong><%#Eval("Company")%></strong><br />
                                                <%#Eval("Address1")%>&nbsp;,&nbsp;<%#Eval("City")%><br />
                                                <%#Eval("State")%>&nbsp;-&nbsp;<%#Eval("Zipcode")%><br />
                                                Contact&nbsp;: <%#Eval("Contact") %>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div class="clearfix5"></div>
                                </div>
                                <div class="span6 marginleft0 ">
                                    <asp:Repeater runat="server" ID="rptOrderDetails">
                                        <ItemTemplate>
                                            <div class="row-fluid borderbox_bottom">
                                                <div class="span6">
                                                    <div class="padding_box">
                                                        <div class="span12">
                                                            Order No<br />
                                                            <strong><%# Eval("OrderId") %></strong>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="span6  marginleft0 borderbox_left">
                                                    <div class="padding_box">
                                                        <div class="span12">
                                                            Order Date<br />
                                                            <strong><%# Eval("OrderDate","{0:dd-MM-yyyy}")%></strong>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row-fluid borderbox_bottom">
                                                <div class="span6">
                                                    <div class="padding_box">
                                                        <div class="span12">
                                                            Order Status<br />
                                                            <strong><%# Eval("OrderStatus")%></strong>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="span6 marginleft0 borderbox_left">
                                                    <div class="padding_box">
                                                        <div class="span12">
                                                            Payment Mode<br />
                                                            <strong><%# Eval("PaymentMode")%></strong>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row-fluid borderbox_bottom">
                                                <div class="span12">
                                                    <div class="padding_box">
                                                        <div class="span12" style="text-decoration: underline; height: 45px; text-align: center; padding-top: 10px; }">
                                                            <strong><a href='Invoices.aspx?ID=<%# Eval("InvoiceId") %>'>Dispatch Details</a></strong>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <div style="height: 262px;"></div>
                                </div>
                                <div class="clear"></div>
                                <table class="table wishlist table-hover table-bordered ">
                                    <thead>
                                        <tr>
                                            <th class="span1">Sl No
                                            </th>
                                            <%-- <th class="span1 ">IMAGE
                                            </th>--%>
                                            <th class="span2">PRODUCT NAME
                                            </th>
                                            <th class="span2">CODE
                                            </th>
                                            <th class="span1">DELIVERY<br />
                                                DETAILS
                                            </th>
                                            <th class="span1">QUANTITY<br />(per pack)
                                            </th>
                                            <th class="span2">RATE (Rs.)
                                            </th>                                            
                                            <th class="span1">
                                            </th>
                                            <th class="span2">PRICE (Rs.)
                                            </th>
                                            <%--<th class="span1">Action
                                                    </th>--%>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater runat="server" ID="rptrCart" OnItemDataBound="rptrCart_OnItemDatabound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="stock"><%# Container.ItemIndex+1 %></td>
                                                    <%-- <td class="image">
                                                        <img title="product" alt="product" src='<%# Eval("Image") %>' width="100">
                                                    </td>--%>
                                                    <td class="product">
                                                        <strong>
                                                            <%# Eval("ProductName") %></strong><br /> (<%# Eval("PackSize") %>)
                                                        <br />
                                                        <strong>Size :</strong>
                                                        <asp:Label runat="server" ID="lblSize" Text='<%# Eval("SizeName") %>'></asp:Label>
                                                        <br />
                                                        <strong>Color :</strong>
                                                        <asp:Label runat="server" ID="lblColor" Text='<%# Eval("ColourName") %>'></asp:Label><br />
                                                    <%--    <span class="fnt12px">Inclusive of <%# Eval("Tax") %>%&nbsp;sales tax<br />
                                                            (INR <%# Math.Round(Convert.ToDouble(Eval("TaxFinalPrice"))) %>)</span>--%>
                                                        <%-- Inclusive of 15% sales tax (INR 371)--%>
                                                    </td>
                                                    <td class="product">
                                                        <%# Eval("ProductCode") %>
                                                    </td>
                                                    <td class="stock">
                                                        <%# Eval("ShippingDays") %>&nbsp;Days
                                                    </td>
                                                    <td class="stock">
                                                        <asp:Label runat="server" ID="lblQty" CssClass="price" Text='<%# Eval("Quantity") %>'
                                                            MaxLength="5"></asp:Label>
                                                    </td>
                                                    <td class="price">
                                                        <strong>
                                                            <asp:Label runat="server" ID="lblProPrice" Text='<%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) %>' Visible="false"></asp:Label>
                                                            <%# Math.Round(Convert.ToDouble(Eval("SalesPrice_Incl"))) %>
                                                        </strong>
                                                    </td>
                                                 <%--   <td class="price">
                                                        <%# Eval("unit") %>
                                                    </td>--%>
                                                    <td class="price">
                                                        <%--<%# Eval("Discount") %>--%>
                                                    </td>
                                                    <td class="price">
                                                        <strong>
                                                            <asp:Label runat="server" ID="lblTotal" Text=' <%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) * Convert.ToDouble(Eval("Quantity")) %> '></asp:Label>
                                                        </strong>
                                                    </td>
                                                    <%--  <td class="price">
                                                <asp:LinkButton runat="server" ID="lnkUpdate" CausesValidation="true" ValidationGroup="addcart" ToolTip="Reorder" CommandName="AddCart" CommandArgument='<%# Eval("ProductId") %>'>
                                            <i class="icon-shopping-cart"></i></asp:LinkButton>
                                            </td>--%>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td class="disword" colspan="6" style="text-align: right; padding-right: 10px;">
                                                <asp:Label runat="server" ID="lblCoupon" Text="" Visible="false"></asp:Label>
                                                <strong></strong>
                                            </td>
                                            <td class="total">
                                                <asp:Label runat="server" ID="lblDisPer" Text="" Visible="false"></asp:Label></td>
                                            <td class="price">
                                                <strong>
                                                    <asp:Label runat="server" ID="lblDisVal" Text="" Visible="false"></asp:Label></strong></td>
                                        </tr>
                                        <tr>
                                            <td class="total" colspan="6"><strong>Amount in Words (rupees)&nbsp;:&nbsp;
                                                <asp:Label runat="server" ID="lblAmountinWords"></asp:Label></strong>
                                            </td>
                                            <td class="price">
                                                <strong>Total</strong>
                                            </td>                                           
                                            <td class="price">
                                                <strong><asp:Label runat="server" ID="lblFinalTotal" Text=""></asp:Label></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" class="fnt12px">Company's PAN : 4521452<br />
                                                Company's TIN : 451278963<br />
                                                Company's CST : 451278963<br />
                                                <asp:Repeater runat="server" ID="rptrCutomerTin">
                                                    <ItemTemplate>
                                                        Customer's TIN :  <%# Eval("Name") %><br />
                                                        Customer's CST : <%# Eval("Email") %>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix5"></div>
                    <div class="fnt9px row-fluid text txtcenter">
                        Subject to Vadodara Jurisdiction.<br />
                        This is a Computer Generated Order.
                    </div>
                    <div class="clearfix10"></div>
                    <div class="row">
                        <a href="#!" class="btn btn-general fright" onclick="javascript:window.open('Print.aspx?oid=<%= invoiceid  %>','mywin','height=555,width=850,left=240,top=10,resizable=true;scrollbars=true');return false;">PRINT</a>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>

