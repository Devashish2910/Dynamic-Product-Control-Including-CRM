<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="MyOrder.aspx.cs" Inherits="MyOrder" %>

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
                    <h2 class="widget-title">
                        <span>Other Links</span></h2>
                    <div class="sidebar-line">
                        <span></span>
                    </div>
                    <ul class="nav nav-list bs-docs-sidenav">
                        <li><a href="MemberDashboard.aspx">My Profile</a></li>
                        <li><a href="WishList.aspx">Wishlist</a></li>
                        <li class="active"><a href="#!">My Order</a></li>
                        <li><a href="ChangePassword.aspx">Change Password</a></li>
                    </ul>
                </div>
            </div>
            <div class="span9 post accorderres">
                <div class="row-fluid">
                    <div class="span12">
                        <h2 class="page-header">My Order</h2>
                        <div class="sidebar-line">
                            <span></span>
                        </div>
                        <div class="row-fluid">
                            <asp:Repeater runat="server" ID="rptrCart">
                                <HeaderTemplate>
                                    <table class="table wishlist table-hover table-bordered">
                                        <thead>
                                            <tr>
                                                <th class="span1">Sl No
                                                </th>
                                                <th class="span2">ORDER NO
                                                </th>
                                                <th class="span2">ORDER DATE
                                                </th>
                                                <th class="span2">ORDER AMOUNT (Rs.)
                                                </th>
                                                <th class="span2">ORDER STATUS
                                                </th>
                                                <th class="span3">VIEW
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td class="product">
                                            <%# Container.ItemIndex+1 %>
                                        </td>
                                        <td class="product">
                                            <b>
                                                <%# Eval("OrderId")%></b>
                                        </td>
                                        <td class="stock">
                                            <%# Eval("OrderDate","{0:dd MMM yyyy}")%>
                                        </td>
                                        <td class="price">
                                            <b>
                                                <%# Math.Round(Convert.ToDouble(Eval("OrderAmount"))) %>
                                            </b>
                                        </td>
                                        <td class="stock">
                                            <%#Eval ("OrderStatus") %>
                                            <%-- <div class="<%#(DataBinder.Eval(Container.DataItem,"OrderStatus").ToString()=="In Process" || DataBinder.Eval(Container.DataItem,"OrderStatus").ToString()=="Pending") ? "displaynone": ""%>">
                                                <b>Tracking No</b>&nbsp;<%# Eval("TrackingNumber") %><br />
                                                <b>Url</b>&nbsp;<a href="<%# Eval("URL") %>" target="_blank"><%# Eval("CourierName") %></a>
                                            </div>--%>
                                        </td>
                                        <td class="price">
                                            <a href='Invoices.aspx?ID=<%# Eval("InvoiceId") %>'>Dispatch Details</a>&nbsp;|&nbsp;<a href='OrderDetails.aspx?OID=<%# Eval("InvoiceId") %>'>Order Details</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody></table>
                                </FooterTemplate>
                            </asp:Repeater>
                            <div class="right">
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
