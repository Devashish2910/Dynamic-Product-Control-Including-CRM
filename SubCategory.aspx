<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="SubCategory.aspx.cs" Inherits="SubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <asp:Repeater runat="server" ID="rptrBreadCrumb">
            <ItemTemplate>
                <ul class="breadcrumb">
                    <li><a href="Default.aspx">Home</a><span class="divider">/</span></li>
                    <li class="active"><%# Eval("CategoryName") %></li>
                </ul>
                <div class="row">
                    <div class="span12 post">
                        <h2 class="page-header"><span><%# Eval("CategoryName") %></span></h2>
                        <div class="sidebar-line"><span></span></div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater runat="server" ID="rptrSubCategory">
            <ItemTemplate>
                <div class="row-fluid prodres">
                    <div class="<%#(DataBinder.Eval(Container.DataItem,"id1").ToString()=="") ? "displaynone": "span2"%>">
                        <div class="wdt-product active">
                            <div class="wdt-products-wrapper">
                                <div class="wdt-product active show">
                                    <a href="Product.aspx?cid=<%# Eval("ProductCategoryId1") %>&scid=<%# Eval("id1") %>" title="<%# Eval("SubCategoryName1") %>" >
                                        <img src="<%# Eval("Image1") %>" alt="<%# Eval("SubCategoryName1") %>">
                                    </a>
                                    <div class="txtcenter min-height70 paddlr5"><a class="fntgry" href="Product.aspx?cid=<%# Eval("ProductCategoryId1") %>&scid=<%# Eval("id1") %>" title="<%# Eval("SubCategoryName1") %>"><%# Eval("SubCategoryName1") %></a></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="<%#(DataBinder.Eval(Container.DataItem,"id2").ToString()=="") ? "displaynone": "span2"%>">
                        <div class="wdt-product active">
                            <div class="wdt-products-wrapper">
                                <div class="wdt-product active show">
                                    <a href="Product.aspx?cid=<%# Eval("ProductCategoryId2") %>&scid=<%# Eval("id2") %>" title="<%# Eval("SubCategoryName2") %>">
                                        <img src="<%# Eval("Image2") %>" alt="<%# Eval("SubCategoryName2") %>">
                                    </a>
                                    <div class="txtcenter min-height70 paddlr5"><a class="fntgry" href="Product.aspx?cid=<%# Eval("ProductCategoryId2") %>&scid=<%# Eval("id2") %>" title="<%# Eval("SubCategoryName2") %>"><%# Eval("SubCategoryName2") %></a></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="<%#(DataBinder.Eval(Container.DataItem,"id3").ToString()=="") ? "displaynone": "span2"%>">
                        <div class="wdt-product active">
                            <div class="wdt-products-wrapper">
                                <div class="wdt-product active show">
                                    <a href="Product.aspx?cid=<%# Eval("ProductCategoryId3") %>&scid=<%# Eval("id3") %>" title="<%# Eval("SubCategoryName3") %>">
                                        <img src="<%# Eval("Image3") %>" alt="<%# Eval("SubCategoryName3") %>">
                                    </a>
                                    <div class="txtcenter min-height70 paddlr5"><a class="fntgry" href="Product.aspx?cid=<%# Eval("ProductCategoryId3") %>&scid=<%# Eval("id3") %>" title="<%# Eval("SubCategoryName3") %>"><%# Eval("SubCategoryName3") %></a></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="<%#(DataBinder.Eval(Container.DataItem,"id4").ToString()=="") ? "displaynone": "span2"%>">
                        <div class="wdt-product active">
                            <div class="wdt-products-wrapper">
                                <div class="wdt-product active show">
                                    <a href="Product.aspx?cid=<%# Eval("ProductCategoryId4") %>&scid=<%# Eval("id4") %>" title="<%# Eval("SubCategoryName4") %>">
                                        <img src="<%# Eval("Image4") %>" alt="<%# Eval("SubCategoryName4") %>">
                                    </a>
                                     <div class="txtcenter min-height70 paddlr5"><a class="fntgry" href="Product.aspx?cid=<%# Eval("ProductCategoryId4") %>&scid=<%# Eval("id4") %>" title="<%# Eval("SubCategoryName4") %>"><%# Eval("SubCategoryName4") %></a></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="<%#(DataBinder.Eval(Container.DataItem,"id5").ToString()=="") ? "displaynone": "span2"%>" >
                        <div class="wdt-product active">
                            <div class="wdt-products-wrapper">
                                <div class="wdt-product active show">
                                    <a href="Product.aspx?cid=<%# Eval("ProductCategoryId5") %>&scid=<%# Eval("id5") %>" title="<%# Eval("SubCategoryName5") %>">
                                        <img src="<%# Eval("Image5") %>" alt="<%# Eval("SubCategoryName4") %>">
                                    </a>
                                     <div class="txtcenter min-height70 paddlr5"><a class="fntgry" href="Product.aspx?cid=<%# Eval("ProductCategoryId5") %>&scid=<%# Eval("id5") %>" title="<%# Eval("SubCategoryName5") %>"><%# Eval("SubCategoryName5") %></a></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="<%#(DataBinder.Eval(Container.DataItem,"id6").ToString()=="") ? "displaynone": "span2"%>">
                        <div class="wdt-product active">
                            <div class="wdt-products-wrapper">
                                <div class="wdt-product active show">
                                    <a href="Product.aspx?cid=<%# Eval("ProductCategoryId6") %>&scid=<%# Eval("id6") %>" title="<%# Eval("SubCategoryName6") %>">
                                        <img src="<%# Eval("Image6") %>" alt="<%# Eval("SubCategoryName6") %>">
                                    </a>
                                     <div class="txtcenter min-height70 paddlr5"><a class="fntgry" href="Product.aspx?cid=<%# Eval("ProductCategoryId6") %>&scid=<%# Eval("id6") %>" title="<%# Eval("SubCategoryName6") %>"><%# Eval("SubCategoryName6") %></a></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
                    <!-- end post span -->
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>

