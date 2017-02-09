<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server" ID="upd" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container make-bg">
                <ul class="breadcrumb">
                    <li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
                    <li class="active">Cart</li>
                </ul>
                <div class="row">
                    <div class="span12 post cartdetailres">
                        <div class="row-fluid ">
                            <div class="span12">
                                <h2 class="page-header">
                                    Cart</h2>
                                <div class="sidebar-line">
                                    <span></span>
                                </div>
                                <asp:Repeater runat="server" ID="rptrCart" OnItemCommand="rptrCart_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table wishlist table-hover table-bordered">
                                            <thead>
                                                <tr>
                                                    <th class="span2">
                                                        IMAGE
                                                    </th>
                                                    <th class="span3">
                                                        PRODUCT NAME
                                                    </th>
                                                    <th class="span2">
                                                        DELIVERY DECRIPTION
                                                    </th>
                                                    <th class="span1">
                                                        QTY<br />
                                                        (per pack)
                                                    </th>
                                                    <th class="span1">
                                                        PRICE (Rs.)
                                                    </th>
                                                    <th class="span1">
                                                        TOTAL (Rs.)
                                                    </th>
                                                    <th class="span1">
                                                        ACTION
                                                    </th>
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
                                                <b>Size : </b>
                                                <asp:Label runat="server" ID="lblSize" Text='<%# Eval("SizeName") %>'></asp:Label>
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
                                                <asp:TextBox runat="server" ID="txtQty" CssClass="price" Text='<%# Eval("Qty") %>'
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
                                            <td class="price">
                                                <asp:LinkButton runat="server" ID="lnkUpdate" CausesValidation="true" ValidationGroup="updatecart"
                                                    ToolTip="Update Quantity" CommandName="UpdateCart" CommandArgument='<%# Eval("ProductId") %>'>
                                            <i class="icon-refresh"></i></asp:LinkButton>
                                                <asp:LinkButton runat="server" ID="lnkRemove" CausesValidation="false" ToolTip="Remove"
                                                    CommandName="Remove" OnClientClick="javascript:return window.confirm('Are You Sure You Want To Delete?')">
                                       <i class="icon-remove"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <td class="total" colspan="4">
                                                </td>
                                                <td class="price">
                                                    <b>Total</b>
                                                </td>
                                                <td class="price">
                                                    <b>
                                                        <asp:Label runat="server" ID="lblFinalTotal"></asp:Label>
                                                    </b>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <asp:Panel runat="server" ID="pnlCouponapplied">
                                                <tr>
                                                    <td colspan="5">
                                                        <i class="icon-ok-sign"></i>
                                                        <asp:Label ID="lblCoupon" runat="server"></asp:Label>&nbsp;Applied Successfully
                                                        <div class="fright padright10px">
                                                            <asp:Label ID="lblDiscountPer" runat="server"></asp:Label></div>
                                                    </td>
                                                    <td class="price">
                                                        <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="total">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="total" colspan="4">
                                                    </td>
                                                    <td class="price">
                                                        <b>Final Total</b>
                                                    </td>
                                                    <td class="price">
                                                        <b>
                                                            <asp:Label runat="server" ID="lblGrandTotal"></asp:Label>
                                                        </b>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                        </tfoot>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <div class="left">
                                    <asp:TextBox placeholder="Enter Pincode" runat="server" ID="txtPinCode" CssClass="txtpinres"
                                        MaxLength="6"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                                        ControlToValidate="txtPinCode" ValidationGroup="pincode" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtPinCode"
                                        ValidChars="0123456789" FilterMode="ValidChars">
                                    </asp:FilteredTextBoxExtender>
                                </div>
                                <div class="left span2">
                                    <asp:LinkButton ID="btnCheckPinCode" runat="server" CssClass="btn btn-general checkpincartres"
                                        OnClick="btnCheckPinCode_OnClick" ValidationGroup="pincode">
                                            <span><i class="icon-search"></i>Check</span>
                                    </asp:LinkButton>
                                </div>
                                <div class="left span5 pinmsgres">
                                    <asp:Panel runat="server" ID="pnlShippingPin" Visible="false">
                                        <i class="icon-remove-sign"></i>Shipping Not Available On this Pincode
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlShippingAvailable" Visible="false">
                                        <i class="icon-ok-sign"></i>Shipping Available On this Pincode
                                    </asp:Panel>
                                </div>
                                <div class="right">
                                    <a href="Default.aspx" class="btn btn-primary btn-general">Continue Shopping</a>
                                    <%--                            <a href="Checkout_Login.aspx" class="btn btn-primary btn-general">Checkout</a>--%>
                                    <asp:LinkButton runat="server" ID="lnkCheckout" CssClass="btn btn-primary btn-general"
                                        OnClick="lnkCheckout_OnClick" Text="Checkout"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>
