<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
            <li class="active">Account</li>
        </ul>
        <div class="row dashboradlinksres">
            <div class="span3 sidebar">
                <div class="">
                    <h2 class="widget-title">
                        <span>Other Links</span></h2>
                    <div class="sidebar-line">
                        <span></span>
                    </div>
                    <ul class="nav nav-list bs-docs-sidenav">
                        <li><a href="MemberDashboard.aspx">My Profile</a></li>
                        <li><a href="WishList.aspx">Wishlist</a></li>
                        <li><a href="MyOrder.aspx">My Order</a></li>
                        <li class="active"><a href="#!">Change Password</a></li>
                    </ul>
                </div>
            </div>
            <div class="span9 post">
                <div class="row-fluid">
                    <div class="span9">
                        <h2 class="widget-title">
                            <span>Change Password</span></h2>
                        <div class="sidebar-line">
                            <span></span>
                        </div>
                        <div class="register-form">
                            <label>
                                <span class="required">*</span>Old Password</label>
                            <div class="fright error">
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtOldPassword"
                                    Display="Dynamic" ErrorMessage="Enter Old Password" ValidationGroup="reg"></asp:RequiredFieldValidator>
                            </div>
                            <asp:TextBox runat="server" ID="txtOldPassword" CssClass="input-block-level" TextMode="Password" placeholder="Enter Your Older Password That You Want To Change" ></asp:TextBox>
                            <label>
                                <span class="required">*</span>New Password</label>
                            <div class="fright error">
                                <asp:RequiredFieldValidator runat="server" ID="rfv2" ControlToValidate="txtNewPassword"
                                    Display="Dynamic" ErrorMessage="Enter New Password" ValidationGroup="reg"></asp:RequiredFieldValidator>
                              <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value between 6 to 20 Characters." 
                                    ControlToValidate="txtNewPassword"     
                                    ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,20}$" />--%>
                                </div>
                        
                            <asp:TextBox runat="server" ID="txtNewPassword" CssClass="input-block-level" placeholder="Enter The New Password That You Want To Set" TextMode="Password"></asp:TextBox>
                            
                            <label for="inputEmail">
                                <span class="required">*</span>Confirm Password</label>
                            <div class="fright error">
                                <asp:RequiredFieldValidator runat="server" ID="rfv3" ControlToValidate="txtconfPassword"
                                    Display="Dynamic" ErrorMessage="Enter confirm password" ValidationGroup="reg"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cpv" runat="server" Display="Dynamic" ErrorMessage="Password not match"
                                    ControlToCompare="txtNewPassword" ControlToValidate="txtconfPassword" ValidationGroup="reg"></asp:CompareValidator>
                            </div>
                            <asp:TextBox runat="server" ID="txtconfPassword" CssClass="input-block-level" placeholder="Must be Same As The New Password" TextMode="Password"></asp:TextBox>
                            <div class="span3 fright">
                                <asp:Button Text="Change Password" ID="btnRegister" runat="server" CssClass=" btn btn-medium btn-general input-block-level"
                                    ValidationGroup="reg" OnClick="btnRegister_Click" />
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
