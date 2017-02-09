<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="WishList.aspx.cs" Inherits="WishList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
            <li class="active">Account</li>
        </ul>
        <div class="row dashboradlinksres">
            <div class="span3 sidebar">
                <div class="">
                    <h2 class="widget-title"><span>Other Links</span></h2>
                    <div class="sidebar-line"><span></span></div>
                    <ul class="nav nav-list bs-docs-sidenav">
                        <li><a href="MemberDashboard.aspx">My Profile</a></li>
                        <li class="active"><a href="#!">Wishlist</a></li>
                        <li><a href="MyOrder.aspx">My Order</a></li>
                        <li><a href="ChangePassword.aspx">Change Password</a></li>
                    </ul>
                </div>
            </div>
            <div class="span9 post accwishlistres">
                <div class="row-fluid">
                    <div class="span12">
                        <h2 class="page-header">My Wishlist</h2>
                        <div class="sidebar-line"><span></span></div>
                        <div class="row-fluid">
                            <asp:Repeater runat="server" ID="rptrCart" OnItemCommand="rptrCart_ItemCommand">
                                <HeaderTemplate>
                                    <table class="table wishlist table-hover table-bordered">
                                        <thead>
                                            <tr>
                                                <th class="span1"></th>
                                                <th class="span2">IMAGE</th>
                                                <th class="span2">PRODUCT NAME</th>
                                                <th class="span2">DELIVERY DECRIPTION</th>
                                                <th class="span1">QUANTITY (per pack)</th>
                                                <th class="span1">PRICE (Rs.)</th>
                                                <th class="span1">TOTAL (Rs.)</th>
                                                <th class="span1">ACTION</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:CheckBox runat="server" ID="chk" />
                                            <asp:Label runat="server" ID="lblpid" Visible="false" Text='<%# Eval("ProductId") %>'></asp:Label>
                                        </td>
                                        <td class="image">
                                            <img title="product" alt="product" src='<%# Eval("Image") %>' width="100"><br />
                                            <%# Eval("ProductCode") %>
                                        </td>
                                        <td class="product"><b><%# Eval("ProductName") %></b><br />(<%# Eval("PackSize") %>)
                                            <br />
                                            <b>Size :</b><asp:Label runat="server" ID="lblSize" Text='<%# Eval("SizeName") %>'></asp:Label>
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
                                        <td class="stock"><%# Eval("ShippingDays") %>&nbsp;Days</td>
                                        <td class="stock">
                                            <asp:TextBox runat="server" ID="txtQty" CssClass="price" Text='<%# Eval("Qty") %>' MaxLength="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtQty" ValidationGroup="addcart" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:FilteredTextBoxExtender runat="server" ID="ftbe" TargetControlID="txtQty" ValidChars="0123456789" FilterMode="ValidChars"></asp:FilteredTextBoxExtender>
                                        </td>
                                        <td class="price"><b>
                                            <asp:Label runat="server" ID="lblProPrice" Text='<%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) %>'></asp:Label>
                                        </b></td>
                                        <td class="price"><b>
                                            <asp:Label runat="server" ID="lblTotal" Text='<%# Math.Round(Convert.ToDouble(Eval("Price"))) %>'></asp:Label>
                                        </b></td>
                                        <td class="price">
                                            <asp:LinkButton runat="server" ID="lnkUpdate" CausesValidation="true" ValidationGroup="addcart" ToolTip="Add To Cart" CommandName="AddCart" CommandArgument='<%# Eval("ProductId") %>'>
                                            <i class="icon-shopping-cart"></i></asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lnkRemove" CausesValidation="false" ToolTip="Remove" CommandName="Remove" OnClientClick="javascript:return window.confirm('Are You Sure You Want To Delete?')">
                                       <i class="icon-trash"></i></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                            <tfoot>
                                <tr>
                                    <td class="total" colspan="5"></td>
                                    <td class="price">
                                       <b>Total</b>
                                    </td>
                                    <td class="price"><b><asp:Label runat="server" ID="lblFinalTotal"></asp:Label></b> </td>
                                </tr>
                            </tfoot>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                            <div class="fright span3">
                               <asp:Button Text="Add to Cart" ID="btnAddCart" runat="server" CssClass="btn btn-medium btn-general input-block-level span6 btnres" OnClick="btnAddCart_Click" CausesValidation="false" />
                                  <asp:Button Text="Save WishList" ID="btnSaveWishList" runat="server" CssClass="btn btn-medium btn-general input-block-level span6 btnres" OnClick="btnSaveWishList_Click" CausesValidation="false" />
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

