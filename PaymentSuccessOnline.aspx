<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="PaymentSuccessOnline.aspx.cs" Inherits="PaymentSuccessOnline" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel runat="server" ID="pnlSuccess" Visible="false">
        <div class="container make-bg">
            <ul class="breadcrumb">
                <li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
                <li class="active">Payment</li>
            </ul>
            <div class="row">
                <div class="span12 post">
                    <h2 class="page-header">
                        <span>Payment Success</span></h2>
                    <div class="sidebar-line">
                        <span></span>
                    </div>
                    <div class="row-fluid">
                        <p>
                            Thank You
                        </p>
                        <p>
                            Your order has been placed successfully.
                            <br />
                            <br />
                            Order ID&nbsp;:&nbsp;<asp:Label runat="server" ID="lblOredrId" Font-Bold="true"></asp:Label>
                        </p>
                        <a href="Default.aspx" class="btn btn-general">Shop More</a>
                    </div>
                    
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>


