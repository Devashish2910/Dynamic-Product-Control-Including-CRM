<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="Apply.aspx.cs" Inherits="Apply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
            <li><a href="Career.aspx">Career</a> <span class="divider">/</span></li>
            <li class="active">Apply</li>
        </ul>
        <div class="row">
            <div class="span12 post">
                <h2 class="page-header">
                    <span>Apply for
                        <asp:Label runat="server" ID="lblDesignation"></asp:Label></span></h2>
                <div class="sidebar-line">
                    <span></span>
                </div>
                <div class="row-fluid">
                    <div class="span4">
                        <label>
                            <span class="required">*</span>Full Name</label>
                        <div class="fright error">
                            <asp:RequiredFieldValidator runat="server" ID="rfv3" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Enter Name" ValidationGroup="carrer"></asp:RequiredFieldValidator>
                        </div>
                        <asp:TextBox runat="server" ID="txtName" CssClass="input-block-level"></asp:TextBox>
                    </div>
                    <div class="span4">
                        <label>
                            <span class="required">*</span>Email Id</label>
                        <div class="fright error">
                            <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="txtEmailId" Display="Dynamic" ErrorMessage="Enter Email" ValidationGroup="carrer"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ID="reg1" ControlToValidate="txtEmailId" Display="Dynamic" ErrorMessage="Enter Valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="carrer"></asp:RegularExpressionValidator>
                        </div>
                        <asp:TextBox runat="server" ID="txtEmailId" CssClass="input-block-level" ValidationGroup="carrer"></asp:TextBox>
                    </div>
                    <div class="span4">
                        <label>
                            <span class="required">*</span>Phone</label>
                          <div class="fright error">
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="Enter Phone no" ValidationGroup="carrer"></asp:RequiredFieldValidator>
                                </div>
                        <asp:TextBox runat="server" ID="txtPhone" CssClass="input-block-level" ValidationGroup="carrer"></asp:TextBox>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span4">
                        <label>
                            Current Employee</label>
                        <asp:TextBox runat="server" ID="txtCurrentEmp" CssClass="input-block-level" ValidationGroup="carrer"></asp:TextBox>
                    </div>
                    <div class="span4">
                        <label>
                            Past Employee</label>
                        <asp:TextBox runat="server" ID="txtPastEmployee" CssClass="input-block-level" ValidationGroup="carrer"></asp:TextBox>
                    </div>
                    <div class="span4">
                        <label>
                            <span class="required">*</span>Upload Resume</label>
                        <asp:FileUpload ID="FUResume" runat="server" CssClass="textbox" Style="-moz-padding: 0px !important;" />
                    </div>
                </div>
                <div class="span2 fright">
                    <asp:Button Text="Submit" ID="btnSubmit" runat="server" CssClass=" btn btn-medium btn-general input-block-level"
                        ValidationGroup="carrer" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>

