<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductNew.aspx.cs" Inherits="ProductNew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Best Admin</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" /> 
</head>
<body onload="initSession()">
    <form id="form1" runat="server" class="mainForm">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

            <asp:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>    
               <link href="CSS/main.css" rel="stylesheet" type="text/css" />
    <link href="CSS/AdminStyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../Style/ftb.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JS/jquery.min.js"></script>
    <script type="text/javascript" src="JS/jquery-ui.min.js"></script>
    <script type="text/javascript" src="JS/jquery.wysiwyg.js"></script>
    <script type="text/javascript" src="JS/wysiwyg.image.js"></script>
    <script type="text/javascript" src="JS/wysiwyg.link.js"></script>
    <script type="text/javascript" src="JS/wysiwyg.table.js"></script>
    <script type="text/javascript" src="JS/jquery.dataTables.js"></script>
    <script src="JS/jquery.dataTables.columnFilter.js" type="text/javascript"></script>
    <script type="text/javascript" src="JS/colResizable.min.js"></script>
    <script type="text/javascript" src="JS/forms.js"></script>
    <script type="text/javascript" src="JS/jquery.validationEngine-en.js"></script>
    <script type="text/javascript" src="JS/jquery.validationEngine.js"></script>
    <script type="text/javascript" src="JS/chosen.jquery.min.js"></script>
    <script type="text/javascript" src="JS/calendar.min.js"></script>
    <script type="text/javascript" src="JS/jquery.form.wizard.js"></script>
    <script type="text/javascript" src="JS/jquery.validate.js"></script>
    <script type="text/javascript" src="JS/jquery.collapsible.min.js"></script>
    <script type="text/javascript" src="JS/jquery.ToTop.js"></script>
    <script type="text/javascript" src="JS/jquery.listnav.js"></script>
    <script type="text/javascript" src="JS/custom2.js"></script>
    <script type="text/javascript">

        var sess_pollInterval = 60000;
        var sess_expirationMinutes = 60;
        var sess_warningMinutes = 45;
        var sess_intervalID;
        var sess_lastActivity;

        function initSession() {
            sess_lastActivity = new Date();
            sessSetInterval();
            $(document).bind('keypress.session', function (ed, e) {
                sessKeyPressed(ed, e);
            });
        }

        function sessSetInterval() {
            sess_intervalID = setInterval('sessInterval()', sess_pollInterval);
        }

        function sessClearInterval() {
            clearInterval(sess_intervalID);
        }

        function sessKeyPressed(ed, e) {
            sess_lastActivity = new Date();
        }

        function sessLogOut() {
            window.location.href = 'Default.aspx';
        }

        function sessInterval() {
            var now = new Date();
            //get milliseconds of differneces 
            var diff = now - sess_lastActivity;
            //get minutes between differences
            var diffMins = (diff / 1000 / 60);

            if (diffMins >= sess_warningMinutes) {
                //wran before expiring
                //stop the timer
                sessClearInterval();
                //promt for attention
                var active = confirm('Your session will expire in ' + (sess_expirationMinutes - sess_warningMinutes) +
                    ' minutes (as of ' + now.toTimeString() + '), press OK to remain logged in ' +
                    'or press Cancel to log off.');
                if (active == true) {
                    now = new Date();
                    diff = now - sess_lastActivity;
                    diffMins = (diff / 1000 / 60);

                    if (diffMins > sess_expirationMinutes) {
                        sessLogOut();
                    }
                    else {
                        initSession();
                        sessSetInterval();
                        sess_lastActivity = new Date();
                    }
                }
                else {
                    sessLogOut();
                }
            }
        }
    </script>
    <script type="text/javascript">
        $("#form1").validate();
    </script>


        <!-- Top navigation bar -->
        <div id="topNav">
            <div class="fixed">
                <div class="wrapper">
                    <div class="welcome">
                        <a href="Afterlogin.aspx" title="Dashboard">
                            <img src="images/userPic.png" alt="" /></a>
                        <asp:Label ID="lblUsername" runat="server" ForeColor="#EEEEEE"></asp:Label>
                    </div>
                    <div class="userNav">
                        <ul>
                            <li class="dd1"><a title="">
                                <img src="images/tasks.png" alt="" /><span>Master Setup</span> </a>
                                <ul class="menu_body1">
                                    <li><a href="Supplier.aspx" title="" class="sChangePassword">Supplier SetUp</a>
                                    </li>
                                    <li><a href="Brand.aspx" title="" class="sChangePassword">Brand</a></li>
                                    <li><a href="Unit.aspx" title="" class="sChangePassword">Unit</a></li>
                                    <li><a href="ColourSetup.aspx" title="" class="sChangePassword">Colour</a></li>
                                    <li><a href="SizeSetup.aspx" title="" class="sChangePassword">Size</a></li>
                                    <li><a href="ManageCOD.aspx" title="" class="sChangePassword">Manage COD</a></li>
                                    <li><a href="PincodeChecker.aspx" title="" class="sChangePassword">Pincode Checker</a></li>
                                    <li><a href="ManageUser.aspx" title="" class="sChangePassword">Manage User</a></li>
                                    <li><a href="FAQ.aspx" title="" class="sChangePassword">FAQ</a></li>
                                </ul>
                            </li>
                            <li class="dd2"><a title="">
                                <img src="images/tasks.png" alt="" /><span>Product Setup</span> </a>
                                <ul class="menu_body2">
                                    <li><a href="Category.aspx" title="" class="sChangePassword">Category</a> </li>
                                    <li><a href="SubCategory.aspx" title="" class="sChangePassword">Sub Category</a>
                                    </li>
                                    <li><a href="Products.aspx" title="" class="sChangePassword">Product</a> </li>
                                </ul>
                            </li>
                            <li class="dd3"><a title="">
                                <img src="images/tasks.png" alt="" /><span>CMS</span></a>
                                <ul class="menu_body3">
                                    <li><a href="AboutUs.aspx" title="" class="sChangePassword">About Us</a></li>
                                    <li><a href="ManageAdvertisement.aspx" title="" class="sChangePassword">Advertisement</a></li>
                                    <li><a href="ContactUs.aspx" title="" class="sChangePassword">Contact Us</a></li>
                                    <li><a href="Disclaimer.aspx" title="" class="sChangePassword">Disclaimer</a></li>
                                    <li><a href="HomeDescription.aspx" title="" class="sChangePassword">Home Description</a></li>
                                    <li><a href="Footer.aspx" title="" class="sChangePassword">Manage Footer</a></li>
                                    <li><a href="PrivacyPolicy.aspx" title="" class="sChangePassword">Privacy Policy</a></li>
                                    <li><a href="TermsAndConditions.aspx" title="" class="sChangePassword">Terms and Conditions</a></li>
                                    <%--<li><a href="ReturnPolicy.aspx" title="" class="sChangePassword">Return Policy</a></li>
                                <li><a href="ShippingOptions.aspx" title="" class="sChangePassword">Shipping Options</a></li>
                                <li><a href="ShippingPolicy.aspx" title="" class="sChangePassword">Shipping Policy</a></li>--%>

                                    <%--<li><a href="../sitemanager/MeetUs.aspx" title="" class="sChangePassword">Meet Us</a></li>
                                    <li><a href="../sitemanager/UpcomingConferences.aspx" title="" class="sChangePassword">Upcoming Conferences</a></li>--%>
                                </ul>
                            </li>
                            <li><a title="" href="Orders.aspx">
                                <img src="images/tasks.png" alt=""><span>Orders</span></a></li>
                            <li><a title="" href="ManageCarrer.aspx">
                                <img src="images/tasks.png" alt=""><span>Carrer</span></a></li>
                            <li class="dd5"><a title="">
                                <img src="images/tasks.png" alt=""><span>Newsletter</span></a>
                                <ul class="menu_body5">
                                    <li><a href="ManageNewsletter.aspx" title="" class="sChangePassword">Manage Newsletter </a>
                                    </li>
                                    <li><a href="PublishNewsletter.aspx" title="" class="sChangePassword">Publish Newsletter </a></li>
                                </ul>
                            </li>

                            <li class="dd4"><a title="">
                                <img src="images/settings.png" alt=""><span>Settings</span></a>
                                <ul class="menu_body4">
                                    <li><a href="ChangePassword.aspx" title="" class="sChangePassword">Change Password </a>
                                    </li>
                                    <li></li>
                                </ul>
                            </li>
                            <li><a runat="server" id="aLogout" onserverclick="Logout_Click" title="Logout">
                                <img src="images/logout.png" alt=""><span>Logout</span></a></li>
                        </ul>
                    </div>
                    <div class="fix">
                    </div>
                </div>
            </div>
        </div>
        <!-- Header -->
        <%--<div id="Div1" class="wrapper">
        <div class="logo">
            <a href="Dashboard.aspx" title="">
                <img src="images/devyami_2.png" alt=""></a></div>
        <div class="fix">
        </div>
    </div>--%>
        <div id="header" class="wrapper">
            <div class="logo">
                <a href="Afterlogin.aspx">
                    <img src="images/logo.png" alt=""></a>
            </div>
            <div class="fix">
            </div>
        </div>
        <!-- Main wrapper -->
        <div class="wrapper">
            <!-- Left navigation -->
            <%-- <div class="leftNav">
            <ul id="menu">
              
            </ul>
        </div>--%>
            <!-- Content -->
            <div class="content" id="container" style="width: 980px;">
                <div class="title" style="width: 980px;">
                    <span style="text-align: center;">
                        <h5>
                            <asp:Label ID="lblFormTitle" runat="server"></asp:Label>
                        </h5>
                    </span>
                </div>
                <div>
                    <div class="widget">
                        <div class="head">
                            <h5 class="iList">Add Record
                            </h5>
                        </div>
                        <div class="rowElem noborder">
                            <label style="width: 133px;">
                                Select Category:<span class="req">*</span></label>
                            <div class="formLeft" style="width: 200px">
                                <asp:DropDownList ID="ddlCategory" runat="server" Width="30%" CssClass="required"
                                    OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <label style="padding-left: 88px; width: 200px;">
                                Select SubCategory:<span class="req">*</span></label>
                            <div class="formLeft" style="width: 200px">
                                <asp:DropDownList ID="ddlSubCategory" runat="server" Width="30%" CssClass="required">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="fix"></div>
                        <div class="rowElem noborder">
                            <label style="width: 133px;">
                                Select Supplier:<span class="req">*</span></label>
                            <div class="formLeft" style="width: 200px">
                                <asp:DropDownList ID="ddlsupplier" runat="server" Width="30%" CssClass="required">
                                </asp:DropDownList>
                            </div>
                            <label style="padding-left: 88px; width: 200px;">
                                Select Brand:<span class="req">*</span></label>
                            <div class="formLeft" style="width: 200px">
                                <asp:DropDownList ID="ddlBrand" runat="server" Width="30%" CssClass="required">
                                </asp:DropDownList>
                            </div>
                            <%--<div class="fix">
            </div>--%>
                        </div>
                        <div class="fix"></div>
                        <div class="rowElem noborder">
                            <label>
                                KeyWords:<span class="req">*</span></label>
                            <div class="formLeft" style="width: 200px">
                                <asp:TextBox ID="txtkeywords" runat="server" CssClass="required" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="fix"></div>
                        <div class="rowElem noborder">
                            <label>
                                Upload Photo <span class="req">*</span><br />
                                (W 356 * H 500) :
                            </label>
                            <div class="formLeft" style="width: 200px">
                                <asp:FileUpload ID="fupPhoto" runat="server" CssClass="fileInput" />
                                &nbsp;<asp:Image ID="imgPhoto" runat="server" CssClass="img100" Width="150px" Height="150px" />
                                <asp:Label ID="lblPhoto2" runat="server" Text="" CssClass="txtError" Visible="true"></asp:Label>
                            </div>
                        </div>
                        <div class="fix"></div>
                        <div class="rowElem noborder">
                            <label>
                                Product Name:<span class="req">*</span></label>
                            <div class="formLeft" style="width: 203px">
                                <asp:TextBox ID="txtProductname" runat="server" CssClass="required" Width="100%"></asp:TextBox>
                                <br />
                                <br />
                                <asp:TextBox ID="txtProductline2" runat="server" CssClass="" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="fix"></div>
                        <div class="rowElem noborder">
                            <label>
                                Product Code:<span class="req">*</span></label>
                            <div class="formLeft" style="width: 203px">
                                <asp:TextBox ID="txtProductCode" runat="server" CssClass="required" Width="120px"></asp:TextBox>
                            </div>
                            <label style="padding-left: 88px; width: 203px;">
                                Supplier Product Code:</label>
                            <div class="formLeft" style="width: 200px">
                                <asp:TextBox ID="txtSupProductcode" runat="server" Width="120px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="fix"></div>
                        <div class="rowElem noborder">

                            <label>
                                Minimum Ordering Quantity:
                            </label>
                            <div class="formLeft" style="width: 203px">
                                <asp:TextBox ID="txtMinOrdrQty" runat="server" Width="120px"></asp:TextBox>
                            </div>
                            <label style="padding-left: 88px; width: 203px;">
                                Pack Size:<span class="req">*</span></label>
                            <div class="formLeft" style="width: 200px">
                                <asp:TextBox ID="txtpacksize" runat="server" CssClass="required" Width="120px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="fix"></div>
                        <div class="rowElem noborder">
                            <label>Is COD</label>
                            <div class="formLeft" style="width: 200px">
                                <asp:RadioButtonList ID="rbtCOD" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <label style="padding-left: 88px; width: 203px;">
                                Shipping Days:
                            </label>
                            <div class="formLeft" style="width: 200px">
                                <asp:TextBox ID="txtShippngDays" runat="server" Width="120px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="fix"></div>
                        <div class="rowElem noborder">
                            <label>
                                Is New Arrival:
                            </label>
                            <div class="formLeft" style="width: 156px">
                                <asp:RadioButtonList ID="rbtNewArriaval" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <label style="padding-left: 135px; width: 203px;">
                                Is Special Offer:
                            </label>
                            <div class="formLeft" style="width: 200px">
                                <asp:RadioButtonList ID="RbtSpecialOffer" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="fix">
                        </div>
                        <table>
                            <tr>
                                <td>
                                    <label style="width: 131px; padding: 13px 0px 13px 11px;">
                                        Product Cost:<span class="req">*</span></label>
                                    <div class="formLeft" style="width: 50%">
                                        <asp:TextBox ID="txtProductcost" runat="server" CssClass="required" Width="80%" AutoPostBack="true"
                                            OnTextChanged="txtProductcost_TextChanged"></asp:TextBox>
                                    </div>
                                </td>
                                <td style="width: 265px;">
                                    <label style="width: -1px; padding: 13px 0px 0px 0px;">
                                        Unit:</label>
                                    <div class="formLeft" style="width: 100px;">
                                        <asp:DropDownList ID="ddlUnit" runat="server" Width="200px">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <label style="width: 100px; padding: 5px 0px 0px 0px;">
                                        Product Weight(Gram):<span class="req">*</span>
                                    </label>
                                    <div class="formLeft" style="width: 100px;">
                                        <asp:TextBox ID="txtProductweight" runat="server" CssClass="required" Width="100%"
                                            OnTextChanged="txtmargin_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 600px;" colspan="2">
                                    <label style="width: 131px; padding: 13px 0px 13px 11px;">
                                        Size Option:&nbsp;<span class="req">*</span></label>
                                    <div class="formLeft" style="width: 50%">
                                        <asp:CheckBoxList ID="cblSizeoption" runat="server" RepeatDirection="Horizontal"
                                            RepeatColumns="3">
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                                <td>
                                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                                        Margin(%):<span class="req">*</span>
                                    </label>
                                    <div class="formLeft" style="width: 100px">
                                        <asp:TextBox ID="txtmargin" runat="server" CssClass="required" Width="40%" OnTextChanged="txtmargin_TextChanged"
                                            AutoPostBack="true"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 600px;" colspan="2">
                                    <label style="width: 131px; padding: 13px 0px 13px 11px;">
                                        Colour Option:&nbsp;<span class="req">*</span></label>
                                    <div class="formLeft" style="width: 50%">
                                        <asp:CheckBoxList ID="cblColouroption" runat="server" RepeatDirection="Horizontal"
                                            RepeatColumns="3">
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                                <td>
                                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                                        Sales Price:<span class="req">*</span>
                                    </label>
                                    <div class="formLeft" style="width: 100px">
                                        <asp:TextBox ID="txtsalescost" runat="server" CssClass="required" Width="100%" AutoPostBack="true"
                                            OnTextChanged="txtsalescost_TextChanged"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 400px;"></td>
                                <td></td>
                                <td>
                                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                                        Tax(%):<span class="req">*</span>
                                    </label>
                                    <div class="formLeft" style="width: 100px">
                                        <asp:TextBox ID="txttax" runat="server" CssClass="required" Width="40%" AutoPostBack="true"
                                            OnTextChanged="txttax_TextChanged"></asp:TextBox>
                                        <%-- <label>
                        (Incl Tax)
                    </label>--%>
                                    </div>
                                    <%--<div class="fix">
                    </div>--%>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <label style="width: 100px; padding: 0px 0px 13px 0px;">
                                        SalePrice
                        <br />
                                        (Incl Tax + Shipping):<span class="req">*</span>
                                    </label>
                                    <div class="formLeft" style="width: 100px">
                                        <asp:TextBox ID="txtSalesPriceIncl" runat="server" Width="100%" Enabled="False"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td class="formLeft" style="width: 203px"></td>
                                <td>
                                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                                        MRP:
                                    </label>
                                    <div class="formLeft" style="width: 100px">
                                        <asp:TextBox ID="txtMRP" runat="server" TextMode="SingleLine" Width="100%"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                                        Discount(%):<span class="req">*</span>
                                    </label>
                                    <div class="formLeft" style="width: 100px">
                                        <asp:TextBox ID="txtDiscount" runat="server" CssClass="required" Width="40%" OnTextChanged="txtDiscount_TextChanged"
                                            AutoPostBack="true"></asp:TextBox>
                                        <asp:TextBox ID="txtCalDiscount" runat="server" CssClass="required" Width="66%" Enabled="False"
                                            Visible="false"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                                        Shipping Cost:<span class="req">*</span>
                                    </label>
                                    <div class="formLeft" style="width: 100px">
                                        <asp:TextBox ID="txtshippingcost" runat="server" CssClass="required" Width="100%"
                                            Enabled="false"> </asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <label style="width: 100px; padding: 7px 0px 13px 0px;">
                                        Final Selling Price:<span class="req">*</span>
                                    </label>
                                    <div class="formLeft" style="width: 100px">
                                        <asp:TextBox ID="txtfinalcost" runat="server" CssClass="required" Width="100%" Enabled="False"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                                        Tax on Final Price:
                                    </label>
                                    <div class="formLeft" style="width: 100px">
                                        <asp:TextBox ID="txttaxfinalprice" runat="server" Width="100%" Enabled="False"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                        <div class="fix">
                        </div>
                        <div class="rowElem">
                            <label>
                                Certification:
                            </label>
                            <div class="formLeft" style="width: 800px">
                                <asp:TextBox ID="txtCertification" runat="server" TextMode="MultiLine" Style="margin: 0px; height: 62px;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="fix"></div>
                        <div class="rowElem noborder">
                            <label>
                                Description:</label>
                            <div class="formRight">
                                <ftb:freetextbox id="txtDescription" breakmode="LineBreak" toolbarlayout="Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat;FontFacesMenu,FontSizesMenu,SymbolsMenu;FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;Cut,Copy,Paste,Delete;InsertDate,InsertTime,InsertTable,InsertImageFromGallery"
                                    runat="Server" focus="False" autogeneratetoolbarsfromstring="True" height="300px"
                                    imagegallerypath="../GeneralImages" width="800px" buttonset="OfficeXP" rendermode="NotSet"
                                    updatetoolbar="True" usetoolbarbackgroundimage="True">
                        </ftb:freetextbox>
                                <div class="fix">
                                </div>
                            </div>
                        </div>
                        <div class="fix"></div>
                        <%--<div class="rowElem">
            <label>
                Description:
            </label>
            <div class="widget" style="margin-top: 0px;">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="wysiwyg" Rows="5" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>--%>
                        <div class="fix">
                        </div>

                        <%--<div class="rowElem">
    </div>--%>
                        <div class="submitForm" style="width: 100%">
                            <div style="float: right">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="redBtn" OnClick="btnSubmit_Click" />
                            </div>
                            <div style="float: right; padding-top: 5px; padding-right: 10px;">
                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="txtError"></asp:Label>
                            </div>
                        </div>
                        <div class="fix">
                        </div>
                        <div style="width: 100%; text-align: center; padding-top: 10px;">
                            <asp:Label ID="lblDeleteMsg" runat="server" Text="" CssClass="txtError"></asp:Label>
                        </div>
                        <div class="fix"></div>
                    </div>
                    <div class="table">
                        <div class="head">
                            <h5 class="iFrames">All Record
                            </h5>
                        </div>
                        <asp:Repeater ID="rptr" runat="server" OnItemCommand="rptr_ItemCommand">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0" border="0" id="Column4" class="display">
                                    <thead>
                                        <tr>
                                            <th align="left">Product Name
                                            </th>
                                            <th align="left">Product Code
                                            </th>
                                            <th align="left">Image
                                            </th>
                                            <th align="left">Cost
                                            </th>
                                            <th align="left">Margin
                                            </th>
                                            <th align="left">Price
                                            </th>
                                            <th align="left">Discount
                                            </th>
                                            <th align="left">Final Price
                                            </th>
                                            <th align="left">Is Special
                                            </th>
                                            <th align="left">Is New
                                            </th>
                                            <th align="left">Is COD
                                            </th>
                                            <th>Action
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="gradeA">
                                    <td>
                                        <asp:Label ID="lblProductId" runat="server" Text='<%#Eval("ProductName")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblProductCode" runat="server" Text='<%#Eval("ProductCode")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" ImageUrl='<%# "../"+Eval("Image") %>'
                                            CssClass="img100" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblProductCost" runat="server" Text='<%#Eval("ProductCost")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMargin" runat="server" Text='<%#Eval("Margin")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSalePrice" runat="server" Text='<%#Eval("SalePrice")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFinalSellingPrice" runat="server" Text='<%#Eval("FinalSellingPrice")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox runat="server" ID="cbkSpecial" Checked='<%#Eval("IsSpecialOffer") %>' OnCheckedChanged="cbkSpecial_CheckedChanged" ToolTip='<%# Eval("Id") %>' AutoPostBack="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox runat="server" ID="cbkNew" Checked='<%#Eval("IsNewArrival") %>' OnCheckedChanged="cbkNew_CheckedChanged" ToolTip='<%# Eval("Id") %>' AutoPostBack="true" />
                                    </td>
                                    <td>
                                        <asp:CheckBox runat="server" ID="cbkCOD" Checked='<%#Eval("ISCOD") %>' OnCheckedChanged="cbkCOD_CheckedChanged" ToolTip='<%# Eval("Id") %>' AutoPostBack="true" />
                                    </td>
                                    <td class="center">
                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Id") %>'
                                            CommandName="EditGroup" Text="Edit" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                                        |
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Id") %>'
                            CommandName="DeleteGroup" OnClientClick="javascript:return window.confirm('Are You Sure You Want To Delete?')"
                            Text="Delete"></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="fix">
            </div>
        </div>
        <div id="footer">
            <div class="wrapper">
                <div style="float: left;">
                    <span>&copy; Copyright 2013. All rights reserved. <a href="http://www.dhitsolutions.com"
                        title=""></a></span>
                </div>
                <div style="float: right;">
                    <span>Powered By :<a href="http://www.dhitsolutions.com" title="" target="_blank"> dhitsolutions</a>
                        </span>
                </div>
            </div>
            <tester style="position: absolute; top: -9999px; left: -9999px; width: auto; font-size: 13px; font-family: Arial; font-weight: normal; letter-spacing: normal; white-space: nowrap;"
                id="tags_tag_autosize_tester"></tester>
            <div id="limiterBox" class="limiterBox" style="position: absolute; display: none;">
            </div>
            <a href="#" id="toTop" style="display: none;"><span id="toTopHover"></span>To Top</a>
        </div>

            </ContentTemplate>
                </asp:UpdatePanel>
    </form>
</body>
</html>
