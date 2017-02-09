<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="Default.aspx">Home</a><span class="divider">/</span></li>
            <li class="active">About Us</li>
        </ul>
        <div class="row">
            <div class="span12 post">
                <h2 class="page-header">
                    <span>About Us</span></h2>
                <div class="sidebar-line">
                    <span></span>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <asp:Literal ID="ltrAboutUs" runat="server"></asp:Literal>
                        <p>
                            <asp:Literal ID="ltrFooter" runat="server"></asp:Literal></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>
