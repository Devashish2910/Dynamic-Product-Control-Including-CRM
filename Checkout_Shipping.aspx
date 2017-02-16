<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Checkout_Shipping.aspx.cs" Inherits="Checkout_Shipping" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="#">Checkout</a> <span class="divider">/</span></li>
            <%--   <li><a href="#">Account</a> <span class="divider">/</span></li>--%>
            <li class="active">Shipping Address</li>
        </ul>
        <div class="row">
            <div class="span12 post register loginres">
                <div class="row-fluid loginres">
                    <div class="span9">
                        <div class="row-fluid">
                            <a href="Register.aspx" class="checkout_hover left div_checkout checkout_block">1. Home
                            </a>
                            <div class="left div_checkout checkout_active">
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
                        <div class="row-fluid">
                            <div class="span5 mrgright20">
                                <h2 class="widget-title">
                                    <span>Shipping Address</span></h2>
                                <div class="sidebar-line">
                                    <span></span>
                                </div>
                                <asp:UpdatePanel runat="server" ID="upShipping" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="row-fluid">
                                            <label>
                                                <span class="required">*</span>Email</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtEmailS"
                                                    Display="Dynamic" ErrorMessage="Enter Email"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtEmailS"
                                                    Display="Dynamic" ErrorMessage="Enter Valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtEmailS" CssClass="input-block-level"></asp:TextBox>
                                            <label>
                                                <span class="required">*</span>Full Name</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtNameS"
                                                    Display="Dynamic" ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtNameS" CssClass="input-block-level"></asp:TextBox>
                                            <label>
                                                Company Name</label>
                                            <asp:TextBox runat="server" ID="txtCompanyS" CssClass="input-block-level"></asp:TextBox>
                                            <label>
                                                <span class="required">*</span>Mobile Number</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtMobileS"
                                                    Display="Dynamic" ErrorMessage="Enter Mobile no"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtMobileS" CssClass="input-block-level"></asp:TextBox>
                                            <label>
                                                <span class="required">*</span>Address</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="txtAddress1S"
                                                    Display="Dynamic" ErrorMessage="Enter Address"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtAddress1S" CssClass="input-block-level" TextMode="MultiLine"></asp:TextBox>
                                            <%--  <label>
                                                Address 2</label>--%>
                                            <asp:TextBox runat="server" ID="txtAddress2S" CssClass="input-block-level" Visible="false" Text=""></asp:TextBox>
                                            <label>
                                                <span class="required">*</span>Pincode</label>
                                            <div class="fright error">
                                                <asp:Panel runat="server" ID="pnlShippingPin" Visible="false">
                                                    <i class="icon-remove-circle"></i>Shipping Not Available On this Pincode
                                                </asp:Panel>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="txtPincodeS"
                                                    Display="Dynamic" ErrorMessage="Enter Pincode"></asp:RequiredFieldValidator>
                                                <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtPincodeS"
                                                    ValidChars="0123456789" FilterMode="ValidChars">
                                                </asp:FilteredTextBoxExtender>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtPincodeS" CssClass="input-block-level" AutoPostBack="true"
                                                OnTextChanged="txtPincodeS_TextChanged" MaxLength="6"></asp:TextBox>
                                            <label>
                                                <span class="required">*</span>City</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="txtCityS"
                                                    Display="Dynamic" ErrorMessage="Enter City"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtCityS" CssClass="input-block-level" Enabled="false"></asp:TextBox>
                                            <label>
                                                <span class="required">*</span>State</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="txtStateS"
                                                    Display="Dynamic" ErrorMessage="Enter State"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtStateS" CssClass="input-block-level" Enabled="false"></asp:TextBox>
                                            <label>
                                                <span class="required">*</span>Country</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="txtCountryS"
                                                    Display="Dynamic" ErrorMessage="Enter Country"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtCountryS" CssClass="input-block-level" Enabled="false"></asp:TextBox>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="span5 brdleft billres">
                                <asp:UpdatePanel runat="server" ID="upBilling" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <span class="span6">
                                            <h2 class="widget-title">
                                                <span>Billing Address</span></h2>
                                        </span>
                                        <span class="span6">
                                            <div class="fright">
                                                <asp:CheckBox runat="server" ID="chkShipping" AutoPostBack="true" OnCheckedChanged="chkShipping_CheckedChanged" />&nbsp; Same as Shipping                                   
                                            </div>
                                        </span>
                                        <div class="clearfix"></div>
                                        <div class="sidebar-line">
                                            <span></span>
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="row-fluid">
                                            <label>
                                                Company Name</label>
                                            <asp:TextBox runat="server" ID="txtCompanyB" CssClass="input-block-level"></asp:TextBox>
                                            <label>
                                                TIN No</label>
                                            <asp:TextBox runat="server" ID="txtTIN" CssClass="input-block-level"></asp:TextBox>
                                           <%-- <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender2" TargetControlID="txtTin"
                                                ValidChars="0123456789" FilterMode="ValidChars">
                                            </asp:FilteredTextBoxExtender>--%>
                                            <label>
                                                CST No</label>
                                            <asp:TextBox runat="server" ID="txtCST" CssClass="input-block-level"></asp:TextBox>
                                         <%--   <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender4" TargetControlID="txtCST"
                                                ValidChars="0123456789" FilterMode="ValidChars">
                                            </asp:FilteredTextBoxExtender>            --%>                              
                                            <label>
                                                <span class="required">*</span>Mobile Number</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="rfv3" ControlToValidate="txtMobileB"
                                                    Display="Dynamic" ErrorMessage="Enter Mobile no"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtMobileB" CssClass="input-block-level"></asp:TextBox>
                                            <label>
                                                <span class="required">*</span>Address</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="rfv111" ControlToValidate="txtAddress1B"
                                                    Display="Dynamic" ErrorMessage="Enter Address"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtAddress1B" CssClass="input-block-level" TextMode="MultiLine"></asp:TextBox>
                                            <%--  <label>
                                                Address 2</label>--%>
                                            <asp:TextBox runat="server" ID="txtAddress2B" CssClass="input-block-level" Visible="false" Text=""></asp:TextBox>
                                            <label>
                                                <span class="required">*</span>Pincode</label>
                                            <div class="fright error">
                                                <asp:Panel runat="server" ID="pnlBillingPin" Visible="false">
                                                    <i class="icon-remove-circle"></i>Shipping Not Available On this Pincode
                                                </asp:Panel>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvPin" ControlToValidate="txtPincodeB"
                                                    Display="Dynamic" ErrorMessage="Enter Pincode"></asp:RequiredFieldValidator>
                                                <asp:FilteredTextBoxExtender runat="server" ID="ftbe" TargetControlID="txtPincodeB"
                                                    ValidChars="0123456789" FilterMode="ValidChars">
                                                </asp:FilteredTextBoxExtender>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtPincodeB" OnTextChanged="txtPincodeB_TextChanged"
                                                CssClass="input-block-level" AutoPostBack="true" CausesValidation="false" MaxLength="6"></asp:TextBox>
                                            <label>
                                                <span class="required">*</span>City</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtCityB"
                                                    Display="Dynamic" ErrorMessage="Enter City"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtCityB" CssClass="input-block-level" Enabled="false"></asp:TextBox>
                                            <label>
                                                <span class="required">*</span>State</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtStateB"
                                                    Display="Dynamic" ErrorMessage="Enter State"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtStateB" CssClass="input-block-level" Enabled="false"></asp:TextBox>
                                            <label>
                                                <span class="required">*</span>Country</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtCountryB"
                                                    Display="Dynamic" ErrorMessage="Enter Country"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtCountryB" CssClass="input-block-level" Enabled="false"></asp:TextBox>
                                            <div class="span4 fright regbtnres">
                                                <asp:Button Text="Continue" ID="btnConfirm" runat="server" CssClass=" btn btn-medium btn-general input-block-level" OnClick="btnConfirm_Click" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>
