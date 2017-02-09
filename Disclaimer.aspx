<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true" CodeFile="Disclaimer.aspx.cs" Inherits="Disclaimer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="Default.aspx">Home</a><span class="divider">/</span></li>
            <li class="active">Disclaimer</li>
        </ul>
        <div class="row">
            <div class="span12 post">
                <h2 class="page-header"><span>Disclaimer</span></h2>
                <div class="sidebar-line"><span></span></div>
                <div class="row-fluid">
                    <div class="span12">
                        <asp:Literal ID="ltrDisclaimer" runat="server"></asp:Literal>
                        <p><asp:Literal ID="ltrFooter" runat="server"></asp:Literal></p>
                    </div>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" Runat="Server">
</asp:Content>

