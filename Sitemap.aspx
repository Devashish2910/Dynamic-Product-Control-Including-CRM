<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Sitemap.aspx.cs" Inherits="Sitemap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="Default.aspx">Home</a><span class="divider">/</span></li>
            <li class="active">Sitemap</li>
        </ul>
        <div class="row">
            <div class="span12 post">
                <h2 class="page-header">
                    <span>Sitemap</span></h2>
                <div class="sidebar-line">
                    <span></span>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <ul class="bullet_arrow2 categories">
                            <li><a href="Default.aspx">Home</a></li>
                            <li><a href="AboutUs.aspx">About Us</a></li>
                            <li><a href="Register.aspx">Register or Login</a></li>
                            <asp:Repeater runat="server" ID="rptMenuCategory" OnItemDataBound="rptMenuCategory_OnItemDataBound">
                                <ItemTemplate>
                                    <li class="test"><a href="SubCategory.aspx?cid=<%# Eval("Id") %>">
                                        <%# Eval("CategoryName")%></a>
                                        <asp:Label runat="server" ID="lblCatID" Visible="false" Text='<%# Bind("Id") %>'></asp:Label>
                                        <asp:Repeater runat="server" ID="rptMenuSubCategory">
                                            <HeaderTemplate>
                                                <ul>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li><a href="Product.aspx?cid=<%# Eval("ProductCategoryId") %>&scid=<%# Eval("id") %>">
                                                    <%# Eval("SubCategoryName")%></a> </li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </ul>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                            <li><a href="Disclaimer.aspx">Disclaimer</a></li>
                            <li><a href="PrivacyPolicy.aspx">Privacy Policy</a></li>
                            <li><a href="FAQShippingPolicy.aspx">Shipping Policy</a></li>
                            <li><a href="FAQReturnandCancellationPolicy.aspx">Return and Cancellation Policy</a></li>
                            <li><a href="TermsandCondition.aspx">Terms And Conditions</a></li>
                            <li><a href="FAQAccount.aspx">FAQ</a></li>
                            <li><a href="Career.aspx">Careers</a></li>
                            <li><a href="ContactUs.aspx">Contact Us</a></li>
                            <li><a href="Sitemap.aspx">Sitemap</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>
