<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="Invoices.aspx.cs" Inherits="Invoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
         <%--   <li><a href="TrackOrder.aspx">Track Order</a> <span class="divider">/</span></li>--%>
            <li class="active">Invoices</li>
        </ul>
        <div class="row">
            <div class="span12 post accinvoiceres">

                <div class="row-fluid">
                    <div class="span12">
                        <h2 class="page-header">Invoice(s) for&nbsp;:&nbsp;<asp:Label runat="server" ID="lblOrderNo"></asp:Label></h2>
                        <div class="sidebar-line">
                            <span></span>
                        </div>
                        <div class="row-fluid borderbox">

                            <div class="clear"></div>
                            <table class="table wishlist table-hover table-bordered ">
                                <thead>
                                    <tr>
                                        <th class="span1">#
                                        </th>
                                        <th class="span3">INVOICE NO
                                        </th>
                                        <th class="span2">DATE OF INVOICE
                                        </th>
                                        <th class="span2">TRACKING NO
                                        </th>
                                        <th class="span2">LOGISTIC PARTNER
                                        </th>
                                        <th class="span2">URL
                                        </th>
                                        <th class="span1">ACTION
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="rptrInvoice">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="image">
                                                    <%#Container.ItemIndex +1 %>
                                                </td>
                                                <td class="product">
                                                    <b>
                                                        <a href='InvoiceDetails.aspx?ID=<%# Eval("InvoiceID") %>&InvID=<%# Eval("InvoiceDispatchId") %>'>
                                                            <%#Eval("InvoiceNumber")%></a>  </b>
                                                    <br />
                                                </td>
                                                <td class="stock">
                                                    <%#Eval("InvoiceDate","{0:dd/MM/yyyy}")%>
                                                </td>
                                                <td class="stock">
                                                    <%#Eval("TrackingNumber")%>
                                                </td>
                                                <td class="price">
                                                    <%#Eval("CourierName")%>
                                                </td>
                                                <td class="price">
                                                    <a href="<%#Eval("URL")%>" target="_blank"><%#Eval("URL")%></a>
                                                </td>
                                                <td class="price">
                                                    <a href='InvoiceDetails.aspx?ID=<%# Eval("InvoiceID") %>&InvID=<%# Eval("InvoiceDispatchId") %>'>View</a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>

                            </table>
                        </div>
                    </div>
                </div>
                <div class="clearfix5"></div>


            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>

