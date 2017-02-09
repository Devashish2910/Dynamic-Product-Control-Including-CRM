<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Checkout_Login.aspx.cs" Inherits="Checkout_Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        body
        {
            height: auto !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="#">Checkout</a> <span class="divider">/</span></li>
            <%--   <li><a href="#">Account</a> <span class="divider">/</span></li>--%>
            <li class="active">Login</li>
        </ul>
        <div class="row">
            <div class="span12 post loginres">
                <div class="row-fluid loginres">
                    <div class="span9">
                        <div class="row-fluid">
                            <div class="left div_checkout checkout_active">
                                1. Login
                            </div>
                            <div class="left div_checkout checkout_block">
                                2. Shipping Address
                            </div>
                            <div class="left div_checkout checkout_block">
                                3. Order Summary
                            </div>
                            <div class="left div_checkout checkout_block">
                                4. Payment Options
                            </div>
                        </div>
                        <div class="sidebar-line">
                            <span style="background: none !important;"></span>
                        </div>
                        <div class="row-fluid register">
                            <div class="span5 mrgright20">
                                <h2 class="widget-title">
                                    <span>Checkout as Guest</span></h2>
                                <div class="sidebar-line">
                                    <span></span>
                                </div>
                                <div class="register-form">
                                    <label>
                                        <span class="required">*</span>Email</label>
                                    <div class="fright error">
                                        <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="txtEmailR"
                                            Display="Dynamic" ErrorMessage="Enter Email" ValidationGroup="reg"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ID="reg1" ControlToValidate="txtEmailR"
                                            Display="Dynamic" ErrorMessage="Enter Valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ValidationGroup="reg"></asp:RegularExpressionValidator>
                                    </div>
                                    <asp:TextBox runat="server" ID="txtEmailR" CssClass="input-block-level"></asp:TextBox>
                                    <div class="span3 fright regbtnres">
                                        <asp:Button Text="Continue" ID="btnContinue" runat="server" CssClass=" btn btn-medium btn-general input-block-level"
                                            ValidationGroup="reg" OnClick="btnContinue_Click" />
                                    </div>
                                </div>
                            </div>
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
                                            <div class="span3 ">
                                                <asp:Button Text="Login" ID="btnLogin" runat="server" CssClass=" btn btn-medium btn-general input-block-level"
                                                    ValidationGroup="log" OnClick="btnLogin_Click" />
                                            </div>
                                            <div class="span5 padtop3 forgotpwdres">
                                                <asp:LinkButton runat="server" ID="lnkForgotPwd" OnClick="lnkForgotPwd_Click">Forgot Password?</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span12">
                                    <img src="images/or_hline.png" />
                                </div>
                                <div class="clearfix paddbottom3pr">
                                </div>
                                <div class="span12 socialres">
                                    <div class="span6">
                                        <%-- <img src="images/login_fb.png" />--%>
                                        <asp:ImageButton runat="server" ID="btn_fb" OnClick="btn_fb_Click" ImageUrl="~/images/login_fb.png"
                                            CausesValidation="false"   CssClass="fbloginres"/>
                                    </div>
                                    <div class="span6">
                                        <a href="#!" class="gplusloginres">
                                            <img src="images/login_gplus.png" onclick="OpenGoogleLoginPopup();" /></a>
                                        <%--<asp:ImageButton runat="server" ID="btn_gplus" OnClick="btn_gplus_Click" ImageUrl="~/images/login_gplus.png" />--%>
                                    </div>
                                </div>
                                <div class="span12 clearfix padtop10 socialres">
                                    <div class="span6">
                                        <asp:ImageButton runat="server" ID="btn_linkin" OnClick="btn_linkin_Click" ImageUrl="~/images/login_linkedin.png"
                                            CausesValidation="false" CssClass="linloginres"/>
                                    </div>
                                    <div class="span6">
                                        <asp:ImageButton runat="server" ID="btn_twitter" OnClick="btn_twitter_Click" ImageUrl="~/images/login_twitter.png"
                                            CausesValidation="false" CssClass="twitterloginres"/>
                                    </div>
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
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:ModalPopupExtender ID="modalpopup1" runat="server" BackgroundCssClass="popup_popup"
        TargetControlID="lnkForgotPwd" PopupControlID="Panel2" />
    <asp:Panel ID="Panel2" runat="server">
        <table class="popup_container" width="550px">
            <tr>
                <td class="popup_title">
                    Please Enter Registered Email ID
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0px" class="popup_pad10px">
                        <tr>
                            <td align="left" style="height: 55px; padding-left: 10px; width: 290px" valign="bottom">
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email Id" Width="260px"
                                    CssClass="popup_textbox"></asp:TextBox>
                            </td>
                            <td align="left" valign="middle">
                                <asp:Button runat="server" ID="btnForgotPwdSubmit" Text="Submit" CssClass="popup_button"
                                    OnClick="btnForgotPwdSubmit_Click" />
                            </td>
                            <td align="left" valign="middle">
                                <asp:Button ID="btnForgoPwdCancel" runat="server" Text="Cancel" CssClass="popup_button"
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
  <%--  <script type="text/javascript" language="javascript">
        function OpenGoogleLoginPopup() {
            var url = "https://accounts.google.com/o/oauth2/auth?";
            url += "scope=https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email&";
            url += "state=%2Fprofile&"
            url += "redirect_uri=<%=Return_url %>&"
            url += "response_type=token&"
            url += "client_id=<%=Client_ID %>";
            window.location = url;
        }
    </script>
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
    </script>--%>
</asp:Content>
