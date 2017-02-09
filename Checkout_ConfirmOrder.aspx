<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Checkout_ConfirmOrder.aspx.cs"
    Inherits="Checkout_ConfirmOrder" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
   <!-- Set the viewport width to device width for mobile -->
    <meta name="viewport" content="user-scalable=no, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <!-- Set meta informations -->
    <title>XYZ</title>
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- Style Files -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,700,700italic,800"
        rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="css/layerslider.css" type="text/css">
    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="css/media.css">
    <link rel="stylesheet" href="css/flexslider.css">
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" type="text/css" href="menu/style.css">

    <%-- <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.js"></script>--%>
    <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>--%>
    <script src="js/jquery-1.11.0.min.js" type="text/javascript"></script>


    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            var feedbackTab = {
                speed: 300,
                containerWidth: $('.feedback-panel').outerWidth(),
                containerHeight: $('.feedback-panel').outerHeight(),
                tabWidth: $('.feedback-tab').outerWidth(),
                init: function () {
                    $('.feedback-panel').css('height', feedbackTab.containerHeight + 'px');

                    $('a.feedback-tab').click(function (event) {
                        if ($('.feedback-panel').hasClass('open')) {
                            $('.feedback-panel')
                .animate({ right: '-' + feedbackTab.containerWidth }, feedbackTab.speed)
                .removeClass('open');
                        } else {
                            $('.feedback-panel')
                .animate({ right: '0' }, feedbackTab.speed)
                .addClass('open');
                        }
                        //event.preventDefault();
                    });
                }
            };
            feedbackTab.init();
        });
    </script>
    <!--[if IE 7]>
		<link rel="stylesheet" href="css/font-awesome-ie7.min.css">
	<![endif]-->
    <!-- JS Files -->
    <%--  <script>
        document.documentElement.className = document.documentElement.className.replace(/(\s|^)no-js(\s|$)/, '$1js$2');
    </script>--%>
    <!--[if lt IE 9]>
		<script src="js/html5shiv.min.js"></script>
	<![endif]-->
    <!--banner-->
    <link rel="stylesheet" href="css/bjqs.css">
    <!-- some pretty fonts for this demo page - not required for the slider -->
    <link href='http://fonts.googleapis.com/css?family=Source+Code+Pro|Open+Sans:300'
        rel='stylesheet' type='text/css'>
    <!-- demo.css contains additional styles used to set up this demo page - not required for the slider -->
    <link rel="stylesheet" href="css/demo.css">
    <!-- load jQuery and the plugin -->
    <%--  <script src="http://code.jquery.com/jquery-1.7.1.min.js"></script>--%>
    <%--<script type="text/javascript" src="js/jquery-1.8.0.min.js"></script>--%>
    <script type="text/javascript" src="js/jquery.smartTab.js"></script>
    <script type="text/javascript">
        $(function () {
            // Smart Tab
            $('#tabs').smartTab({ autoProgress: false, stopOnFocus: true, transitionEffect: 'vSlide' });
        });
    </script>
    <script src="js/bjqs-1.3.min.js"></script>
    <script class="secret-source">
        jQuery(document).ready(function ($) {
            $('#banner-fade').bjqs({
                height: 350,
                width: 550,
                responsive: true
            });
        });
    </script>
    
   
    <!--Start of Zopim Live Chat Script-->
    <%-- <script type="text/javascript">
        window.$zopim || (function (d, s) {
            var z = $zopim = function (c) { z._.push(c) }, $ = z.s =
            d.createElement(s), e = d.getElementsByTagName(s)[0]; z.set = function (o) {
                z.set.
                _.push(o)
            }; z._ = []; z.set._ = []; $.async = !0; $.setAttribute('charset', 'utf-8');
            $.src = '//v2.zopim.com/?1rF2EF0AdZYmeOHVPwHZ76ewMlZIy8tU'; z.t = +new Date; $.
            type = 'text/javascript'; e.parentNode.insertBefore($, e)
        })(document, 'script');
    </script>--%>
    <!--End of Zopim Live Chat Script-->

     <script language="javascript" type="text/javascript">
         function noPostBack(sNewFormAction) {
             document.forms[0].action = sNewFormAction;
             document.forms[0].__VIEWSTATE.name = 'NOVIEWSTATE';
         }
    </script>
</head>
<body>
    <form runat="server" name="customerData" action="t.aspx">
    <asp:ScriptManager runat="server" ID="scriptmanager1">
    </asp:ScriptManager>
    <div class="feedback-panel">
        <a class="feedback-tab" href="#!"></a>
        <table>
            <tr style="height: 100%; white-space: inherit;">
                <td>
                    <label>
                        <span class="required">*</span>Name</label>
                    <div class="fright error">
                        <asp:RequiredFieldValidator runat="server" ID="rfv2" ControlToValidate="txtName"
                            Display="Dynamic" ErrorMessage="Required" ValidationGroup="fed"></asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>
            <tr style="height: 100%; white-space: inherit;">
                <td>
                    <asp:TextBox runat="server" ID="txtName" CssClass="feedbacktextbox"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 100%; white-space: inherit;">
                <td>
                    <label>
                        <span class="required">*</span>Email</label>
                    <div class="fright error">
                        <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="txtEmail"
                            Display="Dynamic" ErrorMessage="Required" ValidationGroup="fed"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="reg1" ControlToValidate="txtEmail"
                            Display="Dynamic" ErrorMessage="InValid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="fed"></asp:RegularExpressionValidator>
                    </div>
                </td>
            </tr>
            <tr style="height: 100%; white-space: inherit;">
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="feedbacktextbox"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 100%; white-space: inherit;">
                <td>
                    <label>
                        Category</label>
                </td>
            </tr>
            <tr style="height: 100%; white-space: inherit;">
                <td>
                    <asp:DropDownList ID="drpCategory" runat="server" CssClass="feedbackSelect">
                        <asp:ListItem>Like</asp:ListItem>
                        <asp:ListItem>Question</asp:ListItem>
                        <asp:ListItem>Suggestion</asp:ListItem>
                        <asp:ListItem>Problem</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 100%; white-space: inherit;">
                <td>
                    <label>
                        <span class="required">*</span>Message</label>
                    <div class="fright error">
                        <asp:RequiredFieldValidator runat="server" ID="rfv4" ControlToValidate="txtMessage"
                            Display="Dynamic" ErrorMessage="Required" ValidationGroup="fed"></asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>
            <tr style="height: 100%; white-space: inherit;">
                <td>
                    <asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine" CssClass="width"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 100%; white-space: inherit;">
                <td>
                    <asp:Button runat="server" ID="btnFeedbackSubmit" Text="Submit" CssClass=" btn btn-medium btn-general input-block-level"
                        ValidationGroup="fed" OnClick="btnFeedbackSubmit_Click" />
                </td>
            </tr>
        </table>
        <asp:Label runat="server" ID="lblFeedbackMsg"></asp:Label>
    </div>
    <!-- Start Top Bar -->
    <div class="container tophead">
            <div class="row-fluid">
                <div class="left span4">
                    <ul class="social">
                        <li><a target="_blank" href="#" data-toggle="tooltip" data-placement="bottom" title="Like us on Facebook"><i class="icon-facebook"></i></a></li>
                        <li><a target="_blank" href="#" data-toggle="tooltip" data-placement="bottom" title="Follow us on Twitter"><i class="icon-twitter"></i></a></li>
                        <li><a target="_blank" href="#" data-toggle="tooltip" data-placement="bottom" title="Circle us on Google Plus"><i class="icon-google-plus"></i></a></li>
                        <li><a target="_blank" href="#" data-toggle="tooltip" data-placement="bottom" title="Follow us on Linkedin"><i class="icon-linkedin"></i></a></li>
                    </ul>
                </div>
                <div class=" top_header_panel left span8">
                    <ul>
                        <li>
                            <img src="images/free_shipping_icon.png">&nbsp;<a href="FAQShippingPolicy.aspx">FREE Shipping</a></li>
                        <li>
                            <img class="marginleft30px" src="images/return_policy_icon.png">&nbsp;<a href="FAQReturnandCancellationPolicy.aspx">14 DAYS Return Policy</a></li>
                        <li>
                            <img class="marginleft30px" src="images/cod_icon.png">&nbsp;<a href="FAQPayment.aspx">Cash On Delivery Available </a></li>
                        <li>
                            <img class="marginleft30px" src="images/phone_icon.png">
                            <a href="#!">TOLL FREE NO.&nbsp;12345555</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    <!-- END Top Bar -->
    <!-- Start Header Bar -->
     <div class="container header-wrap make-bg">
            <div class="row-fluid">
                <div class="span4">
                    <div class="brand">
                        <h1>
                            <a href="Default.aspx">XYZ</a></h1>
                    </div>
                </div>
                <div class="span5">
                    <div class="row-fluid">
                        <div class=" left margintop15  login">
                            <asp:Panel runat="server" ID="pnlLogOff">
                                <a href="Register.aspx" id="wdt-register">Register&nbsp;&nbsp;<i class="icon-user"></i>or&nbsp;&nbsp;Login&nbsp;&nbsp;<i
                                    class="icon-lock"></i></a>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="pnlLogin">
                                <asp:Label runat="server" ID="lblUser" CssClass="textCapital"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                    runat="server" ID="lnkLogout" OnClick="lnkLogout_Click" CausesValidation="false"><i class="icon-off"></i>Logout</asp:LinkButton>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="clearfix">
                    </div>
                    <div class="row-fluid">
                        <div class="span9 searchtxt">
                            <asp:TextBox runat="server" ID="txtSearch" CssClass="tftextinput " placeholder="Search by keywords, product name or product code"></asp:TextBox>
                        </div>
                        <div class="span3 searchbtn">
                            <asp:Button runat="server" ID="btnSearch" CssClass="tfbutton" Text="Search" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                </div>
                <div class="span3 cartlbl">
                    <div class="cart_bg">
                        <div class="left">
                            <a href="MemberDashboard.aspx">My Account</a>&nbsp;&nbsp;<span class="colorgrern">|</span>&nbsp;&nbsp;
                        <a href="Cart.aspx">View Cart</a>&nbsp;&nbsp;<span class="colorgrern">|</span>&nbsp;&nbsp;
                        <a href="TrackOrder.aspx">Track Order</a>
                        </div>
                        <div class="clearfix5">
                        </div>
                        <div class="left">
                            <a href="Cart.aspx">
                                <img src="images/cart_icon.png" title="View Cart" /></a>
                        </div>
                        <div class="left textgrey">
                            (<asp:Label runat="server" ID="lblTopNoItems" Text="0"></asp:Label>)&nbsp;items<br />
                            Rs.&nbsp;<asp:Label runat="server" ID="lblTopTotal" Text="0"></asp:Label>
                        </div>
                        <div class="right">
                            <a href="Cart.aspx" class="btn btn-small  btn-general width40">Cart</a>
                        </div>
                        <%--    <ul>
                        <li class="dropdown hover cart"><a href="Cart.aspx"><i class="icon-shopping-cart"></i> -
                           
                            <i class="icon-arrow-down"></i></a>
                            
                        </li>--%>
                        <%--       <li class="register"><a href="Register.aspx" id="wdt-register">Register <i class="icon-user"></i>or&nbsp;&nbsp;Login<i class="icon-lock"></i></a></li>--%>
                        <%-- </ul>--%>
                    </div>
                </div>
            </div>
        </div>
    <div class="container make-bg">
        <div class="navbar">
                <div class="container">
                    <div class="navbar-inner">
                        <button class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
                            <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                        </button>
                        <%-- <div class="nav-collapse collapse">
                        <ul class="nav pull-left">--%>

                        <div class="toggleMenu">Categories</div>
                        <ul class="nav1">
                            <li class="home_icon_menu"><a href="Default.aspx"><i class="icon-home home"></i></a></li>
                            <asp:Repeater runat="server" ID="rptMenuCategory" OnItemDataBound="rptMenuCategory_OnItemDataBound">
                                <ItemTemplate>
                                    <li class="test">
                                        <a href="SubCategory.aspx?cid=<%# Eval("Id") %>"><%# Eval("CategoryName")%></a>
                                        <asp:Label runat="server" ID="lblCatID" Visible="false" Text='<%# Bind("Id") %>'></asp:Label>
                                        <asp:Repeater runat="server" ID="rptMenuSubCategory">
                                            <HeaderTemplate>
                                                <ul>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li>
                                                    <a href="Product.aspx?cid=<%# Eval("ProductCategoryId") %>&scid=<%# Eval("id") %>">
                                                        <%# Eval("SubCategoryName")%></a>
                                                </li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </ul>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>

                        <%--<li class="active"><a href="Default.aspx"><i class="icon-home home"></i></a></li>--%>
                        <%-- <asp:Repeater runat="server" ID="asd" OnItemDataBound="rptMenuCategory_OnItemDataBound">
                            <ItemTemplate>
                                <li class="dropdown dropdown-hover"><a class="dropdown-toggle" style="z-index: 99999 !important;"
                                    href="SubCategory.aspx?cid=<%# Eval("Id") %>">
                                    <%# Eval("CategoryName")%><span class="caret"></span></a>


                                    <div class="dropdown-menu span1">
                                        <ul class="mega-menu-links">
                                            </HeaderTemplate>
                                        <itemtemplate>
                                            <li></li>
                                        </itemtemplate>
                                            <footertemplate>
                                        </ul>
                                    </div>
                                    </FooterTemplate>
                                   
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>--%>

                        <%--</ul>--%>

                        <%-- </div>--%>
                    </div>
                </div>
            </div>
    </div>
    <!-- END Header Bar -->
    <!-- Start Site Container -->
    <div>
        <div class="container make-bg">
            <ul class="breadcrumb">
                <li><a href="#">Checkout</a> <span class="divider">/</span></li>
                <%--   <li><a href="#">Account</a> <span class="divider">/</span></li>--%>
                <li class="active">Confirm Order</li>
            </ul>
            <div class="row">
                <div class="span12 post">
                    <div class="row-fluid">
                        <div class="span9">
                            <div class="row-fluid">
                                <div class="checkout_hover left div_checkout checkout_block">
                                    1. Login
                                </div>
                                <div class="checkout_hover left div_checkout checkout_block">
                                    2. Shipping Address
                                </div>
                                <div class="checkout_hover left div_checkout checkout_block">
                                    3. Order Summary
                                </div>
                                <div class="left div_checkout checkout_active">
                                    4. Payment Options
                                </div>
                            </div>
                            <div class="sidebar-line">
                                <span style="background: none !important;"></span>
                            </div>
                            <div class="row-fluid">
                                <div class="span12">
                                    <h2 class="widget-title">
                                        <span>Confirm Your Order</span></h2>
                                    <div class="sidebar-line">
                                        <span></span>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="fntbold">
                                            Amount Payable :&nbsp;<asp:Label runat="server" ID="lblFinalAmount1" CssClass="fntmarron"></asp:Label></div>
                                        <div class="clearfix5">
                                        </div>
                                        <div>
                                            Note: After clicking on the "Pay" button, you will be directed to a secure gateway
                                            for payment. After completing the payment process, you will be redirected back to
                                            XYZ.com to view details of your order.
                                        </div>
                                        <div class="clearfix5">
                                        </div>
                                        <div class="span2 fright margintop10">
                                            <table style="display: none;">
                                                <tr>
                                                    <td>
                                                        Parameter Name:
                                                    </td>
                                                    <td>
                                                        Parameter Value:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        Compulsory information
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Merchant Id
                                                    </td>
                                                    <td>
                                                        <input type="text" name="merchant_id" id="merchant_id" value="27509" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Order Id
                                                    </td>
                                                    <td>
                                                        <input type="text" name="order_id" value="" id="order_id" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Amount
                                                    </td>
                                                    <td>
                                                        <input type="text" name="amount" value="" id="amount" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Currency
                                                    </td>
                                                    <td>
                                                        <input type="text" name="currency" value="INR" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Redirect URL
                                                    </td>
                                                    <td>
                                                        <input type="text" name="redirect_url" value="http://timeoffice.in/PaymentSuccessOnline.aspx" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Cancel URL
                                                    </td>
                                                    <td>
                                                        <input type="text" name="cancel_url" value="http://timeoffice.in/PaymentSuccessOnline.aspx" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        Billing information(optional):
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Billing Name
                                                    </td>
                                                    <td>
                                                        <input type="text" name="billing_name" value="NA" id="billing_name" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Billing Address:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="billing_address" value="NA" id="billing_address" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Billing City:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="billing_city" value="NA" id="billing_city" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Billing State:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="billing_state" value="NA" id="billing_state" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Billing Zip:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="billing_zip" value="NA" id="billing_zip" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Billing Country:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="billing_country" value="NA" id="billing_country" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Billing Tel:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="billing_tel" value="NA" id="billing_tel" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Billing Email:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="billing_email" value="NA" id="billing_email" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        Shipping information(optional):
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Shipping Name
                                                    </td>
                                                    <td>
                                                        <input type="text" name="delivery_name" value="NA" id="delivery_name" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Shipping Address:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="delivery_address" value="NA" id="delivery_address" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        shipping City:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="delivery_city" value="NA" id="delivery_city" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        shipping State:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="delivery_state" value="NA" id="delivery_state" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        shipping Zip:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="delivery_zip" value="NA" id="delivery_zip" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        shipping Country:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="delivery_country" value="NA" id="delivery_country" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Shipping Tel:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="delivery_tel" value="NA" id="delivery_tel" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Merchant Param1
                                                    </td>
                                                    <td>
                                                        <input type="text" name="merchant_param1" value="NA" id="merchant_param1" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Merchant Param2
                                                    </td>
                                                    <td>
                                                        <input type="text" name="merchant_param2" value="NA" id="merchant_param2" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Merchant Param3
                                                    </td>
                                                    <td>
                                                        <input type="text" name="merchant_param3" value="additional Info." />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Merchant Param4
                                                    </td>
                                                    <td>
                                                        <input type="text" name="merchant_param4" value="additional Info." />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Merchant Param5
                                                    </td>
                                                    <td>
                                                        <input type="text" name="merchant_param5" value="additional Info." />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Promo Code
                                                    </td>
                                                    <td>
                                                        <input type="text" name="promo_code" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Customer Id:
                                                    </td>
                                                    <td>
                                                        <input type="text" name="customer_identifier" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <input type="submit" value="Checkout" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Button Text="Pay Now" ID="btnPay" runat="server" CssClass=" btn btn-medium btn-general input-block-level" />
                                        </div>
                                        <div class="clearfix5">
                                        </div>
                                        <div class="fntnote span12">
                                            * By placing the order, you have read and agree to timeoffice.in Terms of
                                            Use and Privacy Policy.</div>
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
                                <%--<div class="fright">
                                    <a href="Checkout_Shipping.aspx">Change</a>
                                </div>--%>
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
                                            <%#Eval("SCity")%>&nbsp;-&nbsp;
                                            <%#Eval("SZipcode")%><br />
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
    </div>
    <!-- End Site Container -->
    <div class="container">
        <!-- Start Footer -->
        <footer class="footer-wrapper">
                <div class="row-fluid">
                    <div class="span3">
                        <h2 class="widget-title"><span>TOP CATEGORIES</span></h2>
                        <div class="sidebar-line"><span></span></div>
                        <ul class="contact-details marginbottom0">
                            <asp:Repeater runat="server" ID="rptrCatFooter">
                                <ItemTemplate>
                                    <li><a href="SubCategory.aspx?cid=<%# Eval("Id") %>"><%# Eval("CategoryName")%></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="span3">
                        <h2 class="widget-title"><span>Shipping Policy</span></h2>
                        <div class="sidebar-line"><span></span></div>
                        <ul class="contact-details marginbottom0">
                            <li><a href="Disclaimer.aspx">Disclaimer</a></li>
                            <li><a href="PrivacyPolicy.aspx">Privacy Policy</a></li>
                            <li><a href="FAQShippingPolicy.aspx">Shipping Policy</a></li>
                            <li><a href="FAQReturnandCancellationPolicy.aspx">Return and Cancellation Policy</a></li>
                            <li><a href="TermsandCondition.aspx">Terms And Conditions</a></li>
                        </ul>
                    </div>
                    <div class="span3">
                        <h2 class="widget-title"><span>Reach Us</span></h2>
                        <div class="sidebar-line"><span></span></div>
                        <ul class="contact-details marginbottom0">
                            <%-- <li><i class="icon-home"></i></li>--%>
                            <li><i class="icon-phone"></i>+91 (0) 223 2233222</li>
                            
                            <li><i class="icon-envelope-alt"></i><a href="mailto:support@timeoffice.in">support@timeoffice.in</a></li>
                          
                            <li><i class="icon-map-marker"></i><a href="#" target="_blank">View on Google Maps</a></li>
                        </ul>
                    </div>
                    <%--  <div class="span3">
                        <h2 class="widget-title"><span>Payment Mode</span></h2>
                        <div class="sidebar-line"><span></span></div>
                        <div class="livechat">
                            <img src="images/payment.png" alt="" />
                        </div>
                    </div>--%>
                    <div class="span3">
                        <h2 class="widget-title"><span>Get Social</span></h2>
                        <div class="sidebar-line"><span></span></div>
                        <div class="row-fluid">
                            <div class="span6">
                                <a title="Like us on Facebook" data-toggle="tooltip" href="#" target="_blank">
                                    <img src="images/follow_fb.png" /></a>
                            </div>
                            <div class="span6">
                                <a title="Follow us on Twitter" data-toggle="tooltip" href="#" target="_blank">
                                    <img src="images/follow_twitter.png" /></a>
                            </div>
                        </div>
                        <div class="clearfix25"></div>
                        <div class="row-fluid">
                            <div class="span6">
                                <a title="Circle us on Google Plus" data-toggle="tooltip" href="#" target="_blank">
                                    <img src="images/follow_gplus.png" /></a>
                            </div>
                            <div class="span6">
                                <a title="Follow us on Linkedin" data-toggle="tooltip" href="#" target="_blank">
                                    <img src="images/follow_in.png" /></a>
                            </div>
                        </div>
                    </div>
                </div>
            </footer>
        <!-- End Footer -->
        <!-- Start Copyright -->
        <div class="copyright">
                <div class="row-fluid">
                    <div class="footer-menu left">
                        <ul class="menu">
                            <li><a href="Default.aspx">Home</a></li>
                            <li><a href="AboutUs.aspx">About Us</a></li>
                            <li><a href="FAQAccount.aspx">FAQ</a></li>
                            <li><a href="Career.aspx">Careers</a></li>
                            <li><a href="Sitemap.aspx">Sitemap</a></li>
                            <li><a href="ContactUs.aspx">Contact Us</a></li>
                        </ul>
                    </div>
                    <div class="right padright20" >
                        <p class="color_black">
                            &copy; 2014 <a href="Default.aspx">xyz</a>. All rights reserved.
                        </p>
                       
                    </div>
                </div>
            </div>
        <!-- End Copyright -->
        <div class="wdttop">
            Scroll To Top</div>
    </div>
     <!-- JS Files -->
        <%--  <script src="js/jquery.js" type="text/javascript"></script>--%>
        <%--<script type="text/javascript" src="js/jquery-1.8.0.min.js"></script>--%>
        <script src="js/jquery-easing-1.3.js" type="text/javascript"></script>
        <%--<script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>--%>
        <script src="js/jquery-transit-modified.js" type="text/javascript"></script>
        <script src="js/layerslider.transitions.js" type="text/javascript"></script>
        <script src="js/layerslider.kreaturamedia.jquery.js" type="text/javascript"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/jquery.flexslider.min.js"></script>
        <%--<script src="js/countdown.js"></script>--%>
        <%--  <script src="js/jflickrfeed.min.js"></script>--%>
        <script src="menu/script.js" type="text/javascript"></script>
        <script src="js/custom.js"></script>
        <!-- Flickr JS -->
        <%--        <script>
            $(document).ready(function () {
                $('.flickr').jflickrfeed({
                    limit: 8,
                    qstrings: { id: '52617155@N08' },
                    itemTemplate: '<li><a href="{{link}}"><img src="{{image_s}}" alt="{{title}}" /></a></li>'
                });
            });
        </script>--%>
        <%--   <script src="js/libs/jquery.secret-source.min.js"></script>
        <script>
            jQuery(function ($) {
                $('.secret-source').secretSource({
                    includeTag: false
                });
            });
        </script>--%>
    </form>
</body>
</html>
