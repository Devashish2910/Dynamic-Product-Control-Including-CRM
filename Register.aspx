<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
    <meta charset="utf-8" />
    <!-- Set the viewport width to device width for mobile -->
    <meta name="viewport" content="user-scalable=no, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <!-- Set meta informations -->
    <title>xyz</title>
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

    <%--<asp:ContentPlaceHolder ID="head" runat="server">
    </asp:ContentPlaceHolder>--%>
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

    <style>
        body
        {
            height: auto !important;
        }
    </style>
</head>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <style>
        body
        {
            height: auto !important;
        }
    </style>
</asp:Content>--%>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="scriptmanager1">
        </asp:ScriptManager>
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
                        <%--<li>
                            <img src="images/free_shipping_icon.png">&nbsp;<a href="FAQShippingPolicy.aspx">FREE Shipping</a></li>
                        <li>
                            <img class="marginleft30px" src="images/return_policy_icon.png">&nbsp;<a href="FAQReturnandCancellationPolicy.aspx">14 DAYS Return Policy</a></li>
                        <li>
                            <img class="marginleft30px" src="images/cod_icon.png">&nbsp;<a href="FAQPayment.aspx">Cash On Delivery Available </a></li>--%>
                        <li>
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <img class="marginleft30px" src="images/phone_icon.png">
                                   <a href="#!">TOLL FREE NO.&nbsp;xxxx xxxx xxx</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="container header-wrap make-bg">
            <div class="row-fluid">
                <div class="span4">
                    <div class="logo">
                        <h1>
                        
                            <a href="Default.aspx"><img src="images/logo_new.jpg" alt=""></a></h1>
                    <br />
                    </div>
                </div>
                              
            </div>
        </div>


    <div>
    <div class="container make-bg">
        
        <div class="row">
            <%--<div class="span12 post">--%>
                <div class="row-fluid register">
                    
                    <div class="span6 brdleft">
                        <h2 class="widget-title">
                            <span>Sign In</span></h2>
                        <div class="sidebar-line">
                            <span></span>
                        </div>
                        <div class="span12">
                            <div class="signin-form">
                                <label>
                                    <span class="required">*</span>Email
                                </label>
                                <div class="fright error">
                                    <asp:RequiredFieldValidator runat="server" ID="rfv4" ControlToValidate="txtEmailL"
                                        Display="Dynamic" ErrorMessage="Enter Email" ValidationGroup="log"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ID="reg2" ControlToValidate="txtEmailL"
                                        Display="Dynamic" ErrorMessage="Enter Valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="log"></asp:RegularExpressionValidator>
                                </div>
                                <asp:TextBox runat="server" ID="txtEmailL" CssClass="input-block-level"></asp:TextBox>
                                <label>
                                    <span class="required">*</span>Password</label>
                                <div class="fright error">
                                    <asp:RequiredFieldValidator runat="server" ID="rfv5" ControlToValidate="txtPasswordL"
                                        Display="Dynamic" ErrorMessage="Enter Password" ValidationGroup="log"></asp:RequiredFieldValidator>
                                </div>
                                <asp:TextBox runat="server" ID="txtPasswordL" CssClass="input-block-level" TextMode="Password"></asp:TextBox>
                                <div class="row-fluid loginbtnres">
                                    <div class="span3">
                                        <asp:Button Text="Login" ID="btnLogin" runat="server" CssClass=" btn btn-medium btn-general input-block-level"
                                            ValidationGroup="log" OnClick="btnLogin_Click" />
                                    </div>
                                    <div class="span3 padtop3 forgotpwdres">
                                        <asp:LinkButton runat="server" ID="lnkForgotPwd" OnClick="lnkForgotPwd_Click">Forgot Password?</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix paddbottom5pr">
                            </div>
                            
                            <div class="clearfix paddbottom3pr">
                            </div>
                            
                            <div class="span12 clearfix padtop10 socialres">
                                
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        
        <asp:ModalPopupExtender ID="modalpopup1" runat="server" BackgroundCssClass="popup_popup "
            TargetControlID="lnkForgotPwd" PopupControlID="Panel2" />
        <asp:Panel ID="Panel2" runat="server">
            <table class="popup_container forgotpwdres pwdmaincontaieres" >
                <tr>
                    <td class="popup_title">
                        Please Enter Registered Email ID
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0px" class="popup_pad10px ">
                            <tr>
                                <td align="left" style="height: 55px; padding-left: 10px;" valign="bottom" class="pwdtdres">
                                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email Id"
                                        CssClass="popup_textbox pwdpopuptxtres"></asp:TextBox>
                                </td>
                                <td align="left" valign="middle">
                                    <asp:Button runat="server" ID="btnForgotPwdSubmit" Text="Submit" CssClass="popup_button pwdpopupbtnres"
                                        OnClick="btnForgotPwdSubmit_Click" />
                                </td>
                                <td align="left" valign="middle">
                                    <asp:Button ID="btnForgoPwdCancel" runat="server" Text="Cancel" CssClass="popup_button pwdpopupbtnres"
                                        CausesValidation="false" OnClick="btnForgoPwdCancel_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="height: 35px; padding-left: 10px;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Email Id"
                                        ControlToValidate="txtEmail" Display="Dynamic" CssClass="errormsg"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Enter Valid Email Id"
                                        ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        Display="Dynamic" CssClass="errormsg"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                </td>
                            </tr>

                           

                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
     </div>
  <%--  <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">--%>
  <div class="container">
            <!-- Start Footer -->
            <footer class="footer-wrapper">
                <div class="row-fluid">
                <div class="span3">
                        <h2 class="widget-title"><span>Reach Us</span></h2>
                        <div class="sidebar-line"><span></span></div>
                        <ul class="contact-details marginbottom0">
                            
                            <li><i class="icon-phone"></i>+91 (0) XXX XXXXXX</li>
                            
                            <li><i class="icon-envelope-alt"></i><a href="mailto:XYZ@YOURCOMPANY.com">XYZ@YOURCOMPANY.com</a></li>
                            
                            <li><i class="icon-map-marker"></i><a href="http://goo.gl/maps/lyoO8" target="_blank">View on Google Maps</a></li>
                        </ul>
                    </div>

                    <div class="span3">
                        <h2 class="widget-title"><span></span></h2>
                        <%--<div class="sidebar-line"><span></span></div>--%>
                        <ul class="contact-details marginbottom0">
                            <asp:Repeater runat="server" ID="rptrCatFooter">
                                <ItemTemplate>
                                    <li><a href="SubCategory.aspx?cid=<%# Eval("Id") %>"><%# Eval("CategoryName")%></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    

                    <div class="span3">
                        <h2 class="widget-title"><span></span></h2>
                       <%-- <div class="sidebar-line"><span></span></div>--%>
                        <%--<ul class="contact-details marginbottom0">
                            <li><a href="Disclaimer.aspx">Disclaimer</a></li>
                            <li><a href="PrivacyPolicy.aspx">Privacy Policy</a></li>
                            <li><a href="FAQShippingPolicy.aspx">Shipping Policy</a></li>
                            <li><a href="FAQReturnandCancellationPolicy.aspx">Return and Cancellation Policy</a></li>
                            <li><a href="TermsandCondition.aspx">Terms And Conditions</a></li>
                        </ul>--%>
                    </div>
                    
                    
                    <%--  <div class="span3">
                        <h2 class="widget-title"><span>Payment Mode</span></h2>
                        <div class="sidebar-line"><span></span></div>
                        <div class="livechat">
                            <img src="images/payment.png" alt="" />
                        </div>
                    </div>--%>
                    <div class="span3">
                        <h2 class="widget-title"><span></span></h2>
                        <%--<div class="sidebar-line"><span></span></div>--%>
                        <%--<div class="row-fluid">
                            <div class="span6">
                                <a title="Like us on Facebook" data-toggle="tooltip" href="#" target="_blank">
                                    <img src="images/follow_fb.png" /></a>
                            </div>
                            <div class="span6">
                                <a title="Follow us on Twitter" data-toggle="tooltip" href="#" target="_blank">
                                    <img src="images/follow_twitter.png" /></a>
                            </div>
                        </div>--%>
                        <%--<div class="clearfix25"></div>--%>
                        <%--<div class="row-fluid">
                            <div class="span6">
                                <a title="Circle us on Google Plus" data-toggle="tooltip" href="#" target="_blank">
                                    <img src="images/follow_gplus.png" /></a>
                            </div>
                            <div class="span6">
                                <a title="Follow us on Linkedin" data-toggle="tooltip" href="#" target="_blank">
                                    <img src="images/follow_in.png" /></a>
                            </div>
                        </div>--%>

                    </div>
                    
                </div>
            </footer>
            <!-- End Footer -->
            <!-- Start Copyright -->
            <div class="copyright">
                <div class="row-fluid">
                    <div class="footer-menu left">
                        <ul class="menu">
                            
                        </ul>
                    </div>
                 <%--   <div class="right padright20" >
                        <p class="color_black">
                            &copy; 2014 <a href="Default.aspx">XYZ</a>. All rights reserved.
                        </p>
                        
                    </div>--%>
                </div>
            </div>
            <!-- End Copyright -->
            <div class="wdttop">
                Scroll To Top
            </div>
        </div>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
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
          <%--<script type="text/javascript" language="javascript">
        function OpenGoogleLoginPopup() {
            var url = "https://accounts.google.com/o/oauth2/auth?";
            url += "scope=https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email&";
            url += "state=%2Fprofile&"
            url += "redirect_uri=<%=Return_url %>&"
            url += "response_type=token&"
            url += "client_id=<%=Client_ID %>";
            window.location = url;
        }
    </script>--%>
    <script type="text/javascript">
        function setBodyContentHeight() {

            document.body.style.height = Math.max(document.documentElement.scrollHeight, document.body.scrollHeight) + "px";
        }
        setBodyContentHeight();
        function ClosePopup() {

            var popup = $find('<%= modalpopup1.ClientID %>');
            if (popup != null) {
                popup.hide();
            }
        }
    </script>
    </form>
</body>
</html>

