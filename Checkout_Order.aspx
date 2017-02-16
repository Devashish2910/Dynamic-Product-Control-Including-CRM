<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Checkout_Order.aspx.cs" Inherits="Checkout_Order" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="#">Checkout</a> <span class="divider">/</span></li>
            <%--   <li><a href="#">Account</a> <span class="divider">/</span></li>--%>
            <li class="active">Order Summary</li>
        </ul>
        <div class="row">
            <div class="span12 post cartcheckoutres">
                <div class="row-fluid">
                    <div class="span9">
                        <div class="row-fluid">
                            <a href="Register.aspx" class="checkout_hover left div_checkout checkout_block">1. Home </a><a href="Checkout_Shipping.aspx" class="checkout_hover left div_checkout checkout_block">2. Shipping Address </a>
                            <div class="left div_checkout checkout_active">
                                3. Order Summary
                            </div>
                            <div class="left div_checkout checkout_block">
                                4. Payment Options
                            </div>
                        </div>
                        <div class="sidebar-line">
                            <span style="background: none !important;"></span>
                        </div>
                        <div class="row-fluid cartres">
                            <div class="span11 mrgright20">
                                <h2 class="widget-title">
                                    <span>Order Summary</span></h2>
                                <div class="sidebar-line">
                                    <span></span>
                                </div>
                                <div class="row-fluid paymentorderes">
                                    <asp:Repeater runat="server" ID="rptrCart" OnItemCommand="rptrCart_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table wishlist table-hover table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th class="span2">IMAGE
                                                        </th>
                                                        <th class="span3">PRODUCT NAME
                                                        </th>
                                                        <th class="span1">DELIVERY DESCRIPTION
                                                        </th>
                                                        <th class="span2">QTY<br /> (per pack)
                                                        </th>
                                                        <th class="span1">PRICE (Rs.)
                                                        </th>
                                                        <th class="span1">TOTAL (Rs.)
                                                        </th>
                                                      <%--  <th class="span1">ACTION
                                                        </th>--%>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td class="image">
                                                    <img title="product" alt="product" src='<%# Eval("Image") %>' width="100"><br />
                                                    <%# Eval("ProductCode") %>
                                                </td>
                                                <td class="product">
                                                  <b>
                                                    <%# Eval("ProductName") %></b><br />
                                                    (<%# Eval("PackSize") %>)
                                                <br />
                                                    <b>Size : </b><asp:Label runat="server" ID="lblSize" Text='<%# Eval("SizeName") %>'></asp:Label>
                                                    <br />
                                                    <b>Color :</b>
                                                    <asp:Label runat="server" ID="lblColor" Text='<%# Eval("ColourName") %>'></asp:Label><br />
                                                    <div class="<%#(DataBinder.Eval(Container.DataItem,"IsCOD").ToString()=="False") ? "disblock": "disnone"%>">
                                                        <i class="icon-remove-circle"></i>Cash On Delivery
                                                    </div>
                                                    <div class="<%#(DataBinder.Eval(Container.DataItem,"IsCOD").ToString()=="True") ? "disblock": "disnone"%>">
                                                        <i class="icon-ok-circle"></i>Cash On Delivery
                                                    </div>
                                                </td>
                                                <td class="stock">
                                                    <%# Eval("ShippingDays") %>&nbsp;Days
                                                </td>
                                                <td class="stock">
                                                    <asp:TextBox runat="server" Enabled="false" ID="txtQty" CssClass="price" Text='<%# Eval("Qty") %>'
                                                        MaxLength="5"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                                                        ControlToValidate="txtQty" ValidationGroup="updatecart" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    <asp:FilteredTextBoxExtender runat="server" ID="ftbe" TargetControlID="txtQty" ValidChars="0123456789"
                                                        FilterMode="ValidChars">
                                                    </asp:FilteredTextBoxExtender>
                                                </td>
                                                <td class="price">
                                                    <b>
                                                        <asp:Label runat="server" ID="lblProPrice" Text='<%#  Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) %>'></asp:Label>
                                                    </b>
                                                </td>
                                                <td class="price">
                                                    <b>
                                                        <asp:Label runat="server" ID="lblTotal" Text='<%#  Math.Round(Convert.ToDouble(Eval("Price"))) %>'></asp:Label>
                                                    </b>
                                                </td>
                                                <%--<td class="price">
                                                    <asp:LinkButton runat="server" ID="lnkUpdate" CausesValidation="true" ValidationGroup="updatecart"
                                                        ToolTip="Update Quantity" CommandName="UpdateCart" CommandArgument='<%# Eval("ProductId") %>'>
                                            <i class="icon-refresh"></i></asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="lnkRemove" CausesValidation="false" ToolTip="Remove"
                                                        CommandName="Remove" OnClientClick="javascript:return window.confirm('Are You Sure You Want To Delete?')">
                                       <i class="icon-remove"></i></asp:LinkButton>
                                                </td>--%>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <td class="total" colspan="4"></td>
                                                    <td class="price">
                                                        <b>Total</b>
                                                    </td>
                                                    <td class="price">
                                                        <b>
                                                            <asp:Label runat="server" ID="lblFinalTotal"></asp:Label>
                                                        </b>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <asp:Panel runat="server" ID="pnlCoupon" >
                                                    <tr>
                                                        <%--<td colspan="5">
                                                            <asp:TextBox runat="server" ID="txtCoupon" placeholder="Enter your coupon code here" CssClass="span4 marginbottom0 ctxtres"></asp:TextBox>
                                                            <asp:Button Text="Apply Coupon" runat="server" ID="btnApplyCoupon" CssClass="btn btn-medium btn-general span3 cbtnres" CommandName="Coupon" />
                                                        </td>--%>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </asp:Panel>
                                                <asp:Panel runat="server" ID="pnlCouponapplied" >
                                                    <tr>
                                                        <td colspan="5">
                                                            <i class="icon-ok-sign"></i>
                                                            <asp:Label ID="lblCoupon" runat="server"></asp:Label>&nbsp;Applied Successfully 
                                                            <div class="fright padright10px">
                                                                <asp:Label ID="lblDiscountPer" runat="server"></asp:Label>
                                                            </div>
                                                        </td>
                                                        <td class="price">
                                                            <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="total"></td>
                                                    </tr>
                                                    <tr>

                                                        <td class="price" colspan="5">
                                                            <div class="fright padright10px">
                                                                <b>Final Total</b>
                                                            </div>
                                                        </td>
                                                        <td class="price">
                                                            <b>
                                                                <asp:Label runat="server" ID="lblGrandTotal"></asp:Label>
                                                            </b>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </asp:Panel>
                                            </tfoot>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <div class="clearfix15"></div>
                                    <%-- <div class="row-fluid">
                                        <asp:Panel runat="server" ID="pnlCoupon" CssClass="fleft span5">
                                            <asp:TextBox runat="server" ID="txtCoupon" placeholder="Enter your coupon code here" CssClass="span7 marginbottom0"></asp:TextBox>
                                            <asp:Button Text="Apply Coupon" runat="server" ID="btnApplyCoupon" CssClass="btn btn-medium btn-general span5" />
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="pnlSuccess" CssClass="fleft span6">
                                            <i class="icon-ok-sign"></i>
                                            <asp:Label runat="server" Text="TSM01"></asp:Label>&nbsp;Applied Successfully
                                            &nbsp;
                                            <asp:Label ID="lblSaveRs" runat="server" Text="100"></asp:Label>&nbsp;Save Rupees
                                        </asp:Panel>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="row-fluid">

                                        <i class="icon-remove-sign"></i>
                                        <asp:Label ID="lblMsg" runat="server" Text="Invalid"></asp:Label>

                                    </div>
                                    <div class="clearfix"></div>--%>
                                    <div class="span3 fright margintop10 proceedpaymentres">
                                        <asp:Button Text="Proceed to Payment" ID="btnContinue" runat="server" CssClass=" btn btn-medium btn-general input-block-level" OnClick="btnContinue_Click" />
                                    </div>
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
                                        <%#Eval("SCity")%>&nbsp;-&nbsp; <%#Eval("SZipcode")%><br />
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>
