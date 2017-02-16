<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="FAQPayment.aspx.cs" Inherits="FAQPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="js/jquery.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
            <li class="active">FAQ</li>
        </ul>
        <div class="row">            
            <div class="span3 sidebar">
                <div class="widget">
                    <h2 class="widget-title">
                        <span>FAQ</span></h2>
                    <div class="sidebar-line">
                        <span></span>
                    </div>
                    <ul class="bullet_arrow2 categories">
                        <asp:Repeater runat="server" ID="rptrFAQCategories">
                            <ItemTemplate>
                                <li><a href="<%# Eval("PageName") %>">
                                    <%# Eval("Category") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>                       
                    </ul>
                </div>
            </div>
            <div class="span9 post faqres">
                <h2 class="page-header">
                    <span>Payment</span></h2>
                <div class="sidebar-line">
                    <span></span>
                </div>
                <div id="accordion2" class="accordion">
                    <asp:Repeater ID="rptrfaqdesc" runat="server">
                        <ItemTemplate>
                            <div class="accordion-group">
                                <div class="accordion-heading">
                                    <a href="#collapse<%# Container.ItemIndex + 1 %>" data-toggle="collapse" class="accordion-toggle collapsed">
                                      <%--  FAQ
                                        <%# Container.ItemIndex + 1 %>
                                        :--%>
                                        <%# Eval("Title") %></a>
                                </div>
                                <div class="accordion-body collapse" id="collapse<%# Container.ItemIndex + 1 %>" style="height: 0px;">
                                    <div class="accordion-inner">
                                        <p>
                                            <%# Eval("Description") %>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" Runat="Server">
</asp:Content>

