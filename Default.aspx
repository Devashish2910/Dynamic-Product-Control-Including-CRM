<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <div id="layerslider-container-fw">
            <div class="footer-links">
                <div class="row-fluid">
                    <div class="span6">
                        <h2 class="widget-title">
                            <span>Special Offers</span></h2>
                        <div class="sidebar-line">
                            <span></span>
                        </div>
                        <div class="for-womans flexslider flex-direction-nav-on-top">
                            <ul class="slides">
                                <asp:Repeater runat="server" ID="rptSpecialoffer">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id1").ToString()=="") ? "displaynone": "span4"%>">
                                                <div class="wdt-product">
                                                    <div class="wdt-products-wrapper">
                                                        <div class="wdt-product active show">
                                                            <a href="ProductDetail.aspx?pid=<%# Eval("id1") %> " title='<%# Eval("ProductName1") %>'>
                                                                <img id="Img1" src='<%# Eval("Image1") %>' alt="" runat="server" />
                                                                <asp:Label runat="server" ID="lblProductID" Visible="false" Text='<%# Bind("Id1") %>'></asp:Label>
                                                            </a>
                                                            <h4 class="minhght90">
                                                                <div class="txtcenter">
                                                                    <a href="ProductDetail.aspx?pid=<%# Eval("id1") %>" class="fntgry" title="<%# Eval("ProductName11") %>">
                                                                        <%# Eval("Code1") %></a>
                                                                </div>
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id1") %> " title='<%# Eval("ProductName1") %>'>
                                                                    <%# Eval("ProductName1")%><br />
                                                                    <%#(DataBinder.Eval(Container.DataItem, "ProductName11").ToString().Trim() == "") ? "" : "("+DataBinder.Eval(Container.DataItem, "ProductName11")+")"%>
                                                                </a>
                                                            </h4>
                                                            <div class="txtcenter">
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id1") %>" title="<%# Eval("ProductName11") %>"
                                                                    class="fntorg fnt16" style="color: #FF4F12;">Rs.<%#  Eval("Price1") %><span class="pack">per
                                                                        pack</span> </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id2").ToString()=="") ? "displaynone": "span4"%>">
                                                <div class="wdt-product">
                                                    <div class="wdt-products-wrapper">
                                                        <div class="wdt-product active show">
                                                            <a href="ProductDetail.aspx?pid=<%# Eval("id2") %> " title='<%# Eval("ProductName2") %>'>
                                                                <img id="Img2" src='<%# Eval("Image2") %>' alt="" runat="server" />
                                                                <asp:Label runat="server" ID="Label1" Visible="false" Text='<%# Bind("Id2") %>'></asp:Label>
                                                            </a>
                                                            <h4 class="minhght90">
                                                                <div class="txtcenter">
                                                                    <a href="ProductDetail.aspx?pid=<%# Eval("id2") %>" class="fntgry" title="<%# Eval("ProductName22") %>">
                                                                        <%# Eval("Code2") %></a>
                                                                </div>
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id2") %> " title='<%# Eval("ProductName2") %>'>
                                                                    <%# Eval("ProductName2")%><br />
                                                                    <%#(DataBinder.Eval(Container.DataItem, "ProductName22").ToString().Trim() == "") ? "" : "("+DataBinder.Eval(Container.DataItem, "ProductName22")+")"%>
                                                                </a>
                                                            </h4>
                                                            <div class="txtcenter">
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id2") %>" title="<%# Eval("ProductName22") %>"
                                                                    class="fntorg fnt16" style="color: #FF4F12;">Rs.<%#  Eval("Price2") %><span class="pack">per
                                                                        pack</span> </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id3").ToString()=="") ? "displaynone": "span4"%>">
                                                <div class="wdt-product">
                                                    <div class="wdt-products-wrapper">
                                                        <div class="wdt-product active show">
                                                            <a href="ProductDetail.aspx?pid=<%# Eval("id3") %> " title='<%# Eval("ProductName3") %>'>
                                                                <img id="Img3" src='<%# Eval("Image3") %>' alt="" runat="server" />
                                                                <asp:Label runat="server" ID="Label2" Visible="false" Text='<%# Bind("Id3") %>'></asp:Label>
                                                            </a>
                                                            <h4 class="minhght90">
                                                                <div class="txtcenter">
                                                                    <a href="ProductDetail.aspx?pid=<%# Eval("id3") %>" class="fntgry" title="<%# Eval("ProductName33") %>">
                                                                        <%# Eval("Code3") %></a>
                                                                </div>
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id3") %> " title='<%# Eval("ProductName3") %>'>
                                                                    <%# Eval("ProductName3")%><br />
                                                                    <%#(DataBinder.Eval(Container.DataItem, "ProductName33").ToString().Trim() == "") ? "" : "("+DataBinder.Eval(Container.DataItem, "ProductName33")+")"%>
                                                                </a>
                                                            </h4>
                                                            <div class="txtcenter">
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id3") %>" title="<%# Eval("ProductName33") %>"
                                                                    class="fntorg fnt16" style="color: #FF4F12;">Rs.<%#  Eval("Price3") %><span class="pack">per
                                                                        pack</span> </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--<div class="<%#(DataBinder.Eval(Container.DataItem,"id4").ToString()=="") ? "displaynone": "span3"%>">
                                                <div class="wdt-product">
                                                    <div class="wdt-products-wrapper">
                                                        <div class="wdt-product active show">
                                                            <a href="ProductDetail.aspx?pid=<%# Eval("id4") %> " title='<%# Eval("ProductName4") %>'>
                                                                <img id="Img4" src='<%# Eval("Image4") %>' alt="" runat="server" />
                                                                <asp:Label runat="server" ID="Label3" Visible="false" Text='<%# Bind("Id4") %>'></asp:Label>
                                                            </a>
                                                            <h4 class="minhght90">
                                                                <div class="txtcenter">
                                                                    <a href="ProductDetail.aspx?pid=<%# Eval("id4") %>" class="fntgry" title="<%# Eval("ProductName44") %>">
                                                                        <%# Eval("Code4") %></a>
                                                                </div>
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id4") %> " title='<%# Eval("ProductName4") %>'>
                                                                    <%# Eval("ProductName4")%><br />
                                                                    <%# Eval("ProductName44")%>
                                                                </a>
                                                            </h4>
                                                            <div class="txtcenter">
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id4") %>" title="<%# Eval("ProductName44") %>" class="fntorg fnt16" style="color: #FF4F12;">Rs.<%#  Eval("Price4") %><span class="pack">per pack</span>

                                                                </a>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>--%>
                                        </li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="span6">
                        <h2 class="widget-title disnone">
                            <span>Advertisement Flash</span></h2>
                        <div class="widget-title" style="color: #FF3300">
                            ADVERTISEMENT</div>
                        <div class="sidebar-line ">
                            <span></span>
                        </div>
                        <%--<div class="clearfix60"></div>--%>
                        <div id="home-deal" class="row-fluid">
                            <div class="get-pad">
                                <div class="span12 home-deal-wrapper">
                                    <div id="container">
                                        <!--  Outer wrapper for presentation only, this can be anything you like -->
                                        <div id="banner-fade">
                                            <!-- start Basic Jquery Slider -->
                                            <asp:Repeater runat="server" ID="rptrAdd" OnItemDataBound="rptrAdd_OnItemDataBound">
                                                <HeaderTemplate>
                                                    <ul class="bjqs">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <li>
                                                        <asp:Label runat="server" ID="lblId" Visible="false" Text='<%# Bind("Id") %>'></asp:Label>
                                                        <asp:ImageMap ID="mapAreas" runat="server" CssClass="mapHiLight" HotSpotMode="Navigate"
                                                            ImageUrl='<%# Eval("Image") %>'>
                                                        </asp:ImageMap>
                                                    </li>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </ul>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <!-- end Basic jQuery Slider -->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- .span4 -->
                </div>
                <!-- .row -->
            </div>
            <!-- Start Welecome -->
          
            <div class="footer-links1">
                <div class="row-fluid ">
                    <asp:ImageMap ID="mapAreas" runat="server" CssClass="mapHiLight" HotSpotMode="Navigate">
                    </asp:ImageMap>
                </div>
            </div>
            <!-- End Welecome -->
            <div class="footer-links2">
                <!-- Start Carousels -->
                <div class="row-fluid">
                    <div class="span6">
                        <h2 class="widget-title">
                            <span>NEW ARRIVAL</span></h2>
                        <div class="sidebar-line">
                            <span></span>
                        </div>
                        <div class="for-womans flexslider flex-direction-nav-on-top">
                            <ul class="slides">
                                <asp:Repeater runat="server" ID="rptNewArrival">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id1").ToString()=="") ? "displaynone": "span4"%>">
                                                <div class="wdt-product">
                                                    <div class="wdt-products-wrapper">
                                                        <div class="wdt-product active show">
                                                            <span class="sp"><a href="ProductDetail.aspx?pid=<%# Eval("id1") %> " title='<%# Eval("ProductName1") %>'>
                                                                <img id="Img1" src='<%# Eval("Image1") %>' alt="" runat="server" />
                                                            </a>
                                                                <%-- <div class="<%#(DataBinder.Eval(Container.DataItem,"sp1").ToString()=="False") ? "disnone": "disblock"%>">
                                                                <a class="btn btn-general" href="#!">Special Offer</a>
                                                            </div>--%>
                                                            </span>
                                                            <asp:Label runat="server" ID="lblProductID" Visible="false" Text='<%# Bind("Id1") %>'></asp:Label>
                                                            <h4 class="minhght90">
                                                                <div class="txtcenter">
                                                                    <a href="ProductDetail.aspx?pid=<%# Eval("id1") %>" class="fntgry" title="<%# Eval("ProductName11") %>">
                                                                        <%# Eval("Code1") %></a>
                                                                </div>
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id1") %> " title='<%# Eval("ProductName1") %>'>
                                                                    <%# Eval("ProductName1")%><br />
                                                                    <%#(DataBinder.Eval(Container.DataItem, "ProductName11").ToString().Trim() == "") ? "" : "("+DataBinder.Eval(Container.DataItem, "ProductName11")+")"%>
                                                                </a>
                                                            </h4>
                                                            <div class="txtcenter">
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id1") %>" title="<%# Eval("ProductName11") %>"
                                                                    class="fntorg fnt16" style="color: #FF4F12;">Rs.<%#  Eval("Price1") %><span class="pack">per
                                                                        pack</span> </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id2").ToString()=="") ? "displaynone": "span4"%>">
                                                <div class="wdt-product">
                                                    <div class="wdt-products-wrapper">
                                                        <div class="wdt-product active show">
                                                            <span class="sp"><a href="ProductDetail.aspx?pid=<%# Eval("id2") %> " title='<%# Eval("ProductName2") %>'>
                                                                <img id="Img5" src='<%# Eval("Image2") %>' alt="" runat="server" />
                                                            </a>
                                                                <%--  <div class="<%#(DataBinder.Eval(Container.DataItem,"sp2").ToString()=="False") ? "disnone": "disblock"%>">
                                                                <a class="btn btn-general" href="#!">Special Offer</a>
                                                            </div>--%>
                                                            </span>
                                                            <asp:Label runat="server" ID="Label1" Visible="false" Text='<%# Bind("Id2") %>'></asp:Label>
                                                            <h4 class="minhght90">
                                                                <div class="txtcenter">
                                                                    <a href="ProductDetail.aspx?pid=<%# Eval("id2") %>" class="fntgry" title="<%# Eval("ProductName22") %>">
                                                                        <%# Eval("Code2") %></a>
                                                                </div>
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id2") %> " title='<%# Eval("ProductName2") %>'>
                                                                    <%# Eval("ProductName2")%><br />
                                                                    <%#(DataBinder.Eval(Container.DataItem, "ProductName22").ToString().Trim() == "") ? "" : "("+DataBinder.Eval(Container.DataItem, "ProductName22")+")"%></a>
                                                            </h4>
                                                            <div class="txtcenter">
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id2") %>" title="<%# Eval("ProductName22") %>"
                                                                    class="fntorg fnt16" style="color: #FF4F12;">Rs.<%#  Eval("Price2") %><span class="pack">per
                                                                        pack</span> </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id3").ToString()=="") ? "displaynone": "span4"%>">
                                                <div class="wdt-product">
                                                    <div class="wdt-products-wrapper">
                                                        <div class="wdt-product active show">
                                                            <span class="sp"><a href="ProductDetail.aspx?pid=<%# Eval("id3") %> " title='<%# Eval("ProductName3") %>'>
                                                                <img id="Img6" src='<%# Eval("Image3") %>' alt="" runat="server" />
                                                            </a>
                                                                <%-- <div class="<%#(DataBinder.Eval(Container.DataItem,"sp3").ToString()=="False") ? "disnone": "disblock"%>">
                                                                <a class="btn btn-general" href="#!">Special Offer</a>
                                                            </div>--%>
                                                            </span>
                                                            <asp:Label runat="server" ID="Label2" Visible="false" Text='<%# Bind("Id3") %>'></asp:Label>
                                                            <h4 class="minhght90">
                                                                <div class="txtcenter">
                                                                    <a href="ProductDetail.aspx?pid=<%# Eval("id3") %>" class="fntgry" title="<%# Eval("ProductName33") %>">
                                                                        <%# Eval("Code3") %></a>
                                                                </div>
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id3") %> " title='<%# Eval("ProductName3") %>'>
                                                                    <%# Eval("ProductName3")%><br />
                                                                    <%#(DataBinder.Eval(Container.DataItem, "ProductName33").ToString().Trim() == "") ? "" : "("+DataBinder.Eval(Container.DataItem, "ProductName33")+")"%></a>
                                                            </h4>
                                                            <div class="txtcenter">
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id3") %>" title="<%# Eval("ProductName33") %>"
                                                                    class="fntorg fnt16" style="color: #FF4F12;">Rs.<%#  Eval("Price3") %><span class="pack">per
                                                                        pack</span> </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="span6">
                        <h2 class="widget-title">
                            <span>Top Selling Products</span></h2>
                        <div class="sidebar-line">
                            <span></span>
                        </div>
                        <div class="for-mans flexslider flex-direction-nav-on-top">
                            <ul class="slides">
                                <asp:Repeater runat="server" ID="rptrBestSelling">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id1").ToString()=="") ? "displaynone": "span4"%>">
                                                <div class="wdt-product">
                                                    <div class="wdt-products-wrapper">
                                                        <div class="wdt-product active show">
                                                            <span class="sp"><a href="ProductDetail.aspx?pid=<%# Eval("id1") %> " title='<%# Eval("ProductName1") %>'>
                                                                <img id="Img1" src='<%# Eval("Image1") %>' alt="" runat="server" />
                                                            </a>
                                                                <%-- <div class="<%#(DataBinder.Eval(Container.DataItem,"sp1").ToString()=="False") ? "disnone": "disblock"%>">
                                                                <a class="btn btn-general" href="#!">Special Offer</a>
                                                            </div>--%>
                                                            </span>
                                                            <asp:Label runat="server" ID="lblProductID" Visible="false" Text='<%# Bind("Id1") %>'></asp:Label>
                                                            <h4 class="minhght90">
                                                                <div class="txtcenter">
                                                                    <a href="ProductDetail.aspx?pid=<%# Eval("id1") %>" class="fntgry" title="<%# Eval("ProductName11") %>">
                                                                        <%# Eval("Code1") %></a>
                                                                </div>
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id1") %> " title='<%# Eval("ProductName1") %>'>
                                                                    <%# Eval("ProductName1")%><br />
                                                                    <%#(DataBinder.Eval(Container.DataItem, "ProductName11").ToString().Trim() == "") ? "" : "("+DataBinder.Eval(Container.DataItem, "ProductName11")+")"%></a>
                                                            </h4>
                                                            <div class="txtcenter">
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id1") %>" title="<%# Eval("ProductName11") %>"
                                                                    class="fntorg fnt16" style="color: #FF4F12;">Rs.<%#  Eval("Price1") %><span class="pack">per
                                                                        pack</span> </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id2").ToString()=="") ? "displaynone": "span4"%>">
                                                <div class="wdt-product">
                                                    <div class="wdt-products-wrapper">
                                                        <div class="wdt-product active show">
                                                            <span class="sp"><a href="ProductDetail.aspx?pid=<%# Eval("id2") %> " title='<%# Eval("ProductName2") %>'>
                                                                <img id="Img5" src='<%# Eval("Image2") %>' alt="" runat="server" />
                                                            </a>
                                                                <%--<div class="<%#(DataBinder.Eval(Container.DataItem,"sp2").ToString()=="False") ? "disnone": "disblock"%>">
                                                                <a class="btn btn-general" href="#!">Special Offer</a>
                                                            </div>--%>
                                                            </span>
                                                            <asp:Label runat="server" ID="Label1" Visible="false" Text='<%# Bind("Id2") %>'></asp:Label>
                                                            <h4 class="minhght90">
                                                                <div class="txtcenter">
                                                                    <a href="ProductDetail.aspx?pid=<%# Eval("id2") %>" class="fntgry" title="<%# Eval("ProductName22") %>">
                                                                        <%# Eval("Code2") %></a>
                                                                </div>
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id2") %> " title='<%# Eval("ProductName2") %>'>
                                                                    <%# Eval("ProductName2")%><br />
                                                                    <%#(DataBinder.Eval(Container.DataItem, "ProductName22").ToString().Trim() == "") ? "" : "("+DataBinder.Eval(Container.DataItem, "ProductName22")+")"%></a>
                                                            </h4>
                                                            <div class="txtcenter">
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id2") %>" title="<%# Eval("ProductName22") %>"
                                                                    class="fntorg fnt16" style="color: #FF4F12;">Rs.<%#  Eval("Price2") %><span class="pack">per
                                                                        pack</span> </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id3").ToString()=="") ? "displaynone": "span4"%>">
                                                <div class="wdt-product">
                                                    <div class="wdt-products-wrapper">
                                                        <div class="wdt-product active show">
                                                            <span class="sp"><a href="ProductDetail.aspx?pid=<%# Eval("id3") %> " title='<%# Eval("ProductName3") %>'>
                                                                <img id="Img6" src='<%# Eval("Image3") %>' alt="" runat="server" />
                                                            </a>
                                                                <%-- <div class="<%#(DataBinder.Eval(Container.DataItem,"sp3").ToString()=="False") ? "disnone": "disblock"%>">
                                                                <a class="btn btn-general" href="#!">Special Offer</a>
                                                            </div>--%>
                                                            </span>
                                                            <asp:Label runat="server" ID="Label2" Visible="false" Text='<%# Bind("Id3") %>'></asp:Label>
                                                            <h4 class="minhght90">
                                                                <div class="txtcenter">
                                                                    <a href="ProductDetail.aspx?pid=<%# Eval("id3") %>" class="fntgry" title="<%# Eval("ProductName33") %>">
                                                                        <%# Eval("Code3") %></a>
                                                                </div>
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id3") %> " title='<%# Eval("ProductName3") %>'>
                                                                    <%# Eval("ProductName3")%><br />
                                                                    <%#(DataBinder.Eval(Container.DataItem, "ProductName33").ToString().Trim() == "") ? "" : "("+DataBinder.Eval(Container.DataItem, "ProductName33")+")"%></a>
                                                            </h4>
                                                            <div class="txtcenter">
                                                                <a href="ProductDetail.aspx?pid=<%# Eval("id3") %>" title="<%# Eval("ProductName33") %>"
                                                                    class="fntorg fnt16" style="color: #FF4F12;">Rs.<%#  Eval("Price3") %><span class="pack">per
                                                                        pack</span> </a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
                <!-- End Carousels -->
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>
