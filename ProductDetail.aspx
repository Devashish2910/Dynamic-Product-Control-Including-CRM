<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .fb-like span
        {
            height: 27px !important;
        }
        
        .fb_iframe_widget
        {
            display: inline-block;
            position: relative;
        }
        
        .fb_iframe_widget span
        {
            text-align: justify;
        }        
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="fb-root">
    </div>
    <script type="text/javascript">
            (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "";
            fjs.parentNode.insertBefore(js, fjs);
        } (document, 'script', 'facebook-jssdk'));</script>
      <%--  <script type="text/javascript">
            function validate() {
                var v = document.getElementById('<%=txtQty.ClientID%>').value;

                if (v == "") 
                {
                    alert('લોડા કેટલી લેવી છે એ તો કેહ?');
                    return false;
                }

            }
        </script>--%>
    <div class="container make-bg">
        <asp:Repeater runat="server" ID="rptrProductDetail" OnItemDataBound="rptrProductDetail_ItemDataBound"
            OnItemCommand="rptrProductDetail_ItemCommand">
            <ItemTemplate>
                <ul class="breadcrumb">
                    <li><a href="Default.aspx">Home</a><span class="divider">/</span></li>
                    <li><a href="SubCategory.aspx?cid=<%# Eval("ProductCategoryId") %>">
                        <%# Eval("CategoryName") %></a><span class="divider">/</span></li>
                    <li><a href="Product.aspx?cid=<%# Eval("ProductCategoryId") %>&scid=<%# Eval("ProductSubCategoryId") %>">
                        <%# Eval("SubCategoryName") %></a><span class="divider">/</span></li>
                    <li class="active">
                        <%# Eval("pname") %></li>
                </ul>
                <div class="row">
                    <div class="span12 post">
                        <h2 class="page-header">
                            <span>
                                <%# Eval("pname") %></h2>
                        <div class="sidebar-line">
                            <span></span>
                        </div>
                        <div class="row-fluid product-info socialres">
                            <div class="span3">
                                <div class="cf">
                                    <span class="productwrap" id="home-deal">
                                        <img src="<%# Eval("Image") %>" class="gloveimg" />
                                        <%-- <div class="<%#(DataBinder.Eval(Container.DataItem,"IsSpecialOffer").ToString()=="False") ? "disnone": "disblock"%>">
                                            <a class="btn btn-general" href="#!">Special Offer</a>
                                        </div>--%>
                                    </span>
                                </div>
                                <div class="clearfix15">
                                </div>
                                <div class="fright">
                                    <!-- FOLLOW US -->
                                    <!-- fb-->
                                    <%--<div class="margintopminus3 left fbres" style="width: 90px;">
                                        <div class="fb-share-button" data-href="http://www.xyz.com/ProductDetail.aspx?pid=<%= pid %>"
                                            data-type="button_count">
                                        </div>
                                    </div>--%>
                                    <!-- fb end-->
                                    <!-- twitter-->
                                  <%--  <div class="left twitterres" style="width: 84px;">
                                        <a href="https://twitter.com/share" class="twitter-share-button" data-via=""
                                            data-url="http://www.xyz.com/ProductDetail.aspx?pid=<%= pid %>">Tweet</a>
                                        <script>                                            !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } } (document, 'script', 'twitter-wjs');</script>
                                    </div>--%>
                                    <!-- twitter end-->
                                    <!-- In-->
                               <%--     <div class="left linkedinres">
                                        <script src="//platform.linkedin.com/in.js" type="text/javascript">
 lang: en_US
                                        </script>
                                        <script type="IN/Share" data-url="http://www.xyz.com/ProductDetail.aspx?pid=<%= pid %>"
                                            data-counter="right" data-showzero="true"></script>
                                    </div>--%>
                                    <!-- In end-->
                                    <!-- FOLLOW US END -->
                                </div>
                            </div>
                            <div class="span9">
                                <div class="span11">
                                    <h2 class="page-header disnone">
                                        <span class="fontblack">
                                            <%# Eval("ProductName") %></span><br />
                                        <span class="fontgrey">
                                            <%#Eval("pline2") %></span>
                                    </h2>
                                    <div class="disnone">
                                        <div class="left">
                                            <img src="images/rating_icon.jpg" />
                                        </div>
                                        <div class="left fontdarkgrey ">
                                            156 Ratings
                                        </div>
                                        <div class="left fontgrey ">
                                            &nbsp;|&nbsp;
                                        </div>
                                        <div class="left fontdarkgrey ">
                                            <a href="#!" class="fontdarkgrey textunderline ">38 Reviews </a>
                                        </div>
                                        <div class="right fontdarkgrey ">
                                            <a href="#!" class="fontdarkgrey "><i class="icon-share-sign"></i>Share this Product
                                            </a>
                                        </div>
                                        <div class="right fontdarkgrey">
                                            &nbsp;|&nbsp;
                                        </div>
                                        <div class="right fontdarkgrey">
                                            <a href="#!" class="fontdarkgrey "><i class="icon-pencil"></i>Write a Review </a>
                                        </div>
                                    </div>
                                    <div class="clearfix5 post-title-prod disnone">
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span11">
                                            <h2 class="fontdarkgrey h2overwrite fnt14px padbtm0">
                                                <div class="left fnt18px">
                                                    Product Code
                                                </div>
                                                <div class="left fnt18px padleft42px">
                                                    <%# Eval("ProductCode") %>
                                                </div>
                                                <div class="left paddingleft52 brandres">
                                                    Brand : &nbsp;
                                                    <%# Eval("BrandName") %>
                                                </div>
                                            </h2>
                                        </div>
                                    </div>
                                    <div class="clearfix post-title-prod">
                                    </div>
                                    <div id="price" class="price <%#(DataBinder.Eval(Container.DataItem,"Discount").ToString()=="0") ? "disnone": "disblock"%>">
                                        <span class="price-old left  fnt22px min-width157 oldpriceres">Rs.&nbsp;<%#  Math.Round(Convert.ToDouble(Eval("prosaleprice")))%></span>
                                        <span class="price-new left  min-width115">Rs.&nbsp;<%#  Math.Round(Convert.ToDouble(Eval("netsaleprice"))) %></span>
                                        <span class="pack left">per pack</span> <span class="dis disres">&nbsp;<%# Eval("crmdiscount")%>%&nbsp;OFF</span>
                                        <div class="clear">
                                        </div>
                                        <span class="price-tax fontgrey">+ Tax</span>&nbsp; <span class="price-tax fontdarkgrey padleft49">
                                            (Free Shipping in India)</span>
                                    </div>
                                    <div id="price1" class="price <%#(DataBinder.Eval(Container.DataItem,"Discount").ToString()=="0") ? "disblock": "disnone"%>">
                                        <span class="price-new min-width155">Rs.&nbsp;<%#  Math.Round(Convert.ToDouble(Eval("netsaleprice")))%></span>&nbsp;<span
                                            class="price-tax">( * Inclusive Tax and Shipping Cost )</span>
                                    </div>
                                    <div class="clearfix5 post-title-prod">
                                    </div>
                                    <asp:Panel runat="server" ID="pnlSize">
                                        <div class="row-fluid widthres">
                                            <div class="span2 post-title-prod fnt14px padbtm0">
                                                 Available Sizes
                                            </div>
                                            <div class="span10 post-title-prod fnt14px padbtm0 padleft40px mrgleft0">
                                                 <asp:RadioButtonList ID="rdbSize" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                                    CssClass="fnt14px fontdarkgrey">
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                      <%--  <h2 class="post-title-prod fnt14px padbtm0">
                                            Available Sizes <span class="padleft55">
                                                <asp:RadioButtonList ID="rdbSize" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                                    CssClass="fnt14px fontdarkgrey">
                                                </asp:RadioButtonList>
                                            </span>
                                        </h2>--%>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlColour">
                                         <div class="row-fluid widthres">
                                            <div class="span2 post-title-prod fnt14px padbtm0">
                                                 Available Colors
                                            </div>
                                            <div class="span10 post-title-prod fnt14px padbtm0 padleft40px mrgleft0">
                                                <asp:RadioButtonList ID="rdbColor" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                                    CssClass="fnt14px fontdarkgrey" >
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                      <%--  <h2 class="post-title-prod fnt14px padbtm0">
                                            Available Colors <span class="padleft47">
                                                <asp:RadioButtonList ID="rdbColor" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                                    CssClass="fnt14px fontdarkgrey">
                                                </asp:RadioButtonList>
                                            </span>
                                        </h2>--%>
                                    </asp:Panel>
                                    <div class="row-fluid widthres">
                                        <div class="span2 post-title-prod fnt14px padbtm0">
                                                Pack Size
                                            </div>
                                            <div class="span10 post-title-prod fnt14px padbtm0 padleft40px mrgleft0">
                                               <span class="clrdarkgreen"><%# Eval("PackSize") %></span>
                                            </div>
                                     <%--   <h2 class="post-title-prod fnt14px padbtm0">
                                            Pack Size<span class="padleft97 clrdarkgreen"><%# Eval("PackSize") %></span></h2>--%>
                                    </div>
                                    <div class="clearfix10">
                                    </div>
                                    <div class="row-fluid cartbtnres">.
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtQty"
                                                ValidationGroup="cart" ErrorMessage="Please Select Quantity" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <div class="left span3">
                                         
                                            <asp:TextBox runat="server" ID="txtQty" MaxLength="5" CssClass="margintop0 qtytxt" placeholder="Enter Qty in No. of Packs"></asp:TextBox>
                                           
                                            <asp:FilteredTextBoxExtender runat="server" ID="ftbe" TargetControlID="txtQty" ValidChars="0123456789"
                                                FilterMode="ValidChars">
                                            </asp:FilteredTextBoxExtender>
                                        </div>
                                        <div  class="left span6 marginleft0">
                                            <asp:LinkButton ID="lnkAddCart" runat="server" CssClass="btn btn-general btnres" ToolTip="Add to Cart"
                                                CausesValidation="true" ValidationGroup="cart" CommandName="AddCart" OnClientClick="return validate()">
                                            <span><i class="icon-shopping-cart"></i>Add to Cart</span>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkAddWishList" runat="server" CssClass="btn btn-general btnres" ToolTip="Add to Wishlist"
                                                CausesValidation="false" CommandName="AddWishlist">
                                            <span><i class=" icon-heart"></i>Add to Wishlist</span>
                                            </asp:LinkButton>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid detailres">
                                    <div class="row-fluid fontdarkgrey">
                                        <div class="span5 borderright linehgt40">
                                            <div class="<%#(DataBinder.Eval(Container.DataItem,"IsCOD").ToString()=="True") ? "disinlineblock linehgt40": "disnone"%>">
                                                <i class="icon-check"></i>Cash On Delivery
                                            </div>
                                            <div class="<%#(DataBinder.Eval(Container.DataItem,"IsCOD").ToString()=="False") ? "disinlineblock linehgt40": "disnone"%>">
                                                <i class="icon-remove"></i>Cash On Delivery
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div class="linehgt40">
                                                <i class="icon-check"></i>Payment by Cheque / Demand draft
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <div class="linehgt40">
                                                <i class="icon-check"></i>Payment by Net banking / Credit / Debit Card
                                            </div>
                                        </div>
                                        <div class="span7">
                                            <div class="lineght30">
                                                <i class="icon-truck"></i>Product will be dispatched in&nbsp;<%# Eval("ShippingDays") %>&nbsp;days
                                            </div>
                                            <div class="clearfix5 post-title-prod">
                                            </div>
                                            <asp:UpdatePanel runat="server" ID="upd" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="span12">
                                                        <div class="paddbottom2pr left">
                                                            <i class="icon-globe"></i>Check your delivery options
                                                        </div>
                                                        <div class="left padleft5px">
                                                            <asp:TextBox placeholder="Enter Pincode" runat="server" ID="txtPinCode" CssClass="pincodetxt"
                                                                MaxLength="6"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
                                                                ControlToValidate="txtPinCode" ValidationGroup="pincode" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                            <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtPinCode"
                                                                ValidChars="0123456789" FilterMode="ValidChars">
                                                            </asp:FilteredTextBoxExtender>
                                                        </div>
                                                        <div class="left padleft5px">
                                                            <asp:LinkButton ID="btnCheckPinCode" runat="server" CssClass="btn btn-general" ValidationGroup="pincode"
                                                                CommandName="CheckPincode">
                                            <span><i class="icon-search"></i>Check</span>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                    <div class="clear">
                                                    </div>
                                                    <div class="left">
                                                        <asp:Panel runat="server" ID="pnlShippingPin" Visible="false">
                                                            <i class="icon-remove-sign"></i>Shipping Not Available On this Pincode
                                                        </asp:Panel>
                                                        <asp:Panel runat="server" ID="pnlShippingAvailable" Visible="false">
                                                            <i class="icon-ok-sign"></i>Shipping Available On this Pincode
                                                        </asp:Panel>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnCheckPinCode" EventName="" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <div class="clearfix5">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix25">
                            </div>
                            <div class="row-fluid">
                                <h4 class="post-title-prod padbtm0">
                                    Description</h4>
                                <div class="fontdarkgrey">
                                    <asp:Literal runat="server" ID="ltrlDesc" Text='  <%# Eval("Description") %>'></asp:Literal>
                                </div>
                                <div class="clearfix20">
                                </div>
                                <h4 class="post-title-prod padbtm0">
                                    Certification</h4>
                                    
                                <div class="fontdarkgrey">
                                    <asp:Literal runat="server" ID="ltrlCertificate" Text=' <%# Eval("Certification") %>'></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- end post span -->
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>
