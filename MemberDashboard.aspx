<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="MemberDashboard.aspx.cs" Inherits="MemberDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel runat="server" ID="up" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container make-bg">
                <ul class="breadcrumb">
                    <li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
                    <li class="active">Account</li>
                </ul>
                <div class="row dashboradlinksres">
                    <div class="span3">
                        <div class="">
                            <h2 class="widget-title">
                                <span>Other Links</span></h2>
                            <div class="sidebar-line">
                                <span></span>
                            </div>
                            <ul class="nav nav-list bs-docs-sidenav">
                                <li class="active"><a href="#!">My Profile</a></li>
                                <li><a href="WishList.aspx">Wishlist</a></li>
                                <li><a href="MyOrder.aspx">My Order</a></li>
                                <li><a href="ChangePassword.aspx">Change Password</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="span9">
                        <div class="row-fluid">
                            <div class="span12">
                                <h2 class="widget-title">
                                    <span>Personal Information</span></h2>
                                <div class="sidebar-line">
                                    <span></span>
                                </div>
                                <div class="register-form">
                                    <div class="span6">
                                        <label>
                                            <span class="required">*</span>Full Name</label>
                                        <div class="fright error">
                                            <asp:RequiredFieldValidator runat="server" ID="rfv2" ControlToValidate="txtName"
                                                Display="Dynamic" ErrorMessage="Enter Name" ValidationGroup="reg"></asp:RequiredFieldValidator>
                                        </div>
                                        <asp:TextBox runat="server" ID="txtName" CssClass="input-block-level"></asp:TextBox>
                                    </div>
                                    <div class="span6">
                                        <label>
                                            Email</label>
                                        <asp:TextBox runat="server" ID="txtEmailR" CssClass="input-block-level" ReadOnly="True"></asp:TextBox>


                                        <%-- <div class="span3 fright">
                                <asp:Button Text="Register!" ID="btnRegister" runat="server" CssClass=" btn btn-medium btn-general input-block-level"
                                    ValidationGroup="reg" />
                            </div>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix25">
                            </div>
                            <div class="row-fluid">
                                <div class="span6">
                                    <h2 class="widget-title">
                                        <span>Shipping Information</span></h2>
                                    <div class="sidebar-line">
                                        <span></span>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span6">
                                            <label>
                                                Company Name</label>
                                            <asp:TextBox runat="server" ID="txtCompany" CssClass="input-block-level"></asp:TextBox>
                                        </div>
                                        <div class="span6">
                                            <label for="inputEmail">
                                                <span class="required">*</span>Mobile Number</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="rfv3" ControlToValidate="txtMobile"
                                                    Display="Dynamic" ErrorMessage="Enter Mobile no" ValidationGroup="reg"></asp:RequiredFieldValidator>
                                                <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender2" TargetControlID="txtMobile"
                                                    ValidChars="0123456789" FilterMode="ValidChars">
                                                    </asp:FilteredTextBoxExtender>

                                            </div>
                                            <asp:TextBox runat="server" ID="txtMobile" CssClass="input-block-level"></asp:TextBox>
                                        </div>
                                    </div>
                                    <label>
                                        <span class="required">*</span>Address</label>
                                    <div class="fright error">
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtAddress1"
                                            Display="Dynamic" ErrorMessage="Enter Address" ValidationGroup="reg"></asp:RequiredFieldValidator>
                                    </div>
                                    <asp:TextBox runat="server" ID="txtAddress1" CssClass="input-block-level" TextMode="MultiLine"></asp:TextBox>
                                    <%-- <label>
                                        Address2</label>--%>
                                    <asp:TextBox runat="server" ID="txtAddress2" CssClass="input-block-level" Visible="false" Text=""></asp:TextBox>
                                    <div class="row-fluid">
                                        <div class="span6">
                                            <label>
                                                Pin Code</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtZipCode"
                                                    Display="Dynamic" ErrorMessage="Enter Pincode" ValidationGroup="reg"></asp:RequiredFieldValidator>
                                                <asp:FilteredTextBoxExtender runat="server" ID="ftbe" TargetControlID="txtZipCode"
                                                    ValidChars="0123456789" FilterMode="ValidChars">
                                                </asp:FilteredTextBoxExtender>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtZipCode" CssClass="input-block-level" MaxLength="6" AutoPostBack="true" OnTextChanged="txtZipCode_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="span6">
                                            <label>
                                                City</label>
                                            <asp:TextBox runat="server" ID="txtCity" CssClass="input-block-level" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span6">
                                            <label>
                                                State</label>
                                            <asp:TextBox runat="server" ID="txtState" CssClass="input-block-level" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="span6">
                                            <label>
                                                Country</label>
                                            <asp:TextBox runat="server" ID="txtCountry" CssClass="input-block-level" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="span6">
                                    <span class="span7">
                                        <h2 class="widget-title">
                                            <span>Billing Address</span></h2>
                                    </span><span class="span5">
                                        <div class="fright">
                                            <asp:CheckBox runat="server" ID="chkShipping" AutoPostBack="true" OnCheckedChanged="chkShipping_CheckedChanged" />&nbsp;
                                            Same as Shipping
                                        </div>
                                    </span>
                                    <div class="clearfix">
                                    </div>
                                    <div class="sidebar-line">
                                        <span></span>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span6">
                                            <label>
                                                Company Name</label>
                                            <asp:TextBox runat="server" ID="txtBcompany" CssClass="input-block-level"></asp:TextBox>
                                        </div>
                                        <div class="span6">
                                            <label for="inputEmail">
                                                <span class="required">*</span>Mobile Number</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtBMobile"
                                                    Display="Dynamic" ErrorMessage="Enter Mobile no" ValidationGroup="reg"></asp:RequiredFieldValidator>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtBMobile" CssClass="input-block-level"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="row-fluid">
                                        <div class="span6">
                                            <label>
                                                TIN No</label>
                                            <asp:TextBox runat="server" ID="txtTin" CssClass="input-block-level"></asp:TextBox>
                                        </div>
                                           <div class="span6">
                                            <label>
                                                CST No</label>
                                            <asp:TextBox runat="server" ID="txtCst" CssClass="input-block-level"></asp:TextBox>
                                        </div>
                                    <label>
                                        <span class="required">*</span>Address</label>
                                    <div class="fright error">
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtAddress1"
                                            Display="Dynamic" ErrorMessage="Enter Address" ValidationGroup="reg"></asp:RequiredFieldValidator>
                                    </div>
                                    <asp:TextBox runat="server" ID="txtBAddress1" CssClass="input-block-level" TextMode="MultiLine"></asp:TextBox>
                                    <%--     <label>
                                        Address2</label>--%>
                                    <asp:TextBox runat="server" ID="txtBAddress2" CssClass="input-block-level" Visible="false" Text=""></asp:TextBox>
                                    <div class="row-fluid">
                                        <div class="span6">
                                            <label>
                                                Pin Code</label>
                                            <div class="fright error">
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtBZipCode"
                                                    Display="Dynamic" ErrorMessage="Enter Pincode" ValidationGroup="reg"></asp:RequiredFieldValidator>
                                                <asp:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" TargetControlID="txtBZipCode"
                                                    ValidChars="0123456789" FilterMode="ValidChars">
                                                </asp:FilteredTextBoxExtender>
                                            </div>
                                            <asp:TextBox runat="server" ID="txtBZipCode" CssClass="input-block-level" MaxLength="6" AutoPostBack="true" OnTextChanged="txtBZipCode_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="span6">
                                            <label>
                                                City</label>
                                            <asp:TextBox runat="server" ID="txtBCity" CssClass="input-block-level" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span6">
                                            <label>
                                                State</label>
                                            <asp:TextBox runat="server" ID="txtBState" CssClass="input-block-level" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="span6">
                                            <label>
                                                Country</label>
                                            <asp:TextBox runat="server" ID="txtBCountry" CssClass="input-block-level" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="span3 fright">
                                    <asp:Button Text="Update" ID="btnUpdate" runat="server" CssClass=" btn btn-medium btn-general input-block-level"
                                        ValidationGroup="reg" OnClick="btnUpdate_Click" />
                                </div>
                                <div class="clearfix5"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>
