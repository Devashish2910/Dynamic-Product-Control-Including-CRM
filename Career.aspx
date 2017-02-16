<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="Career.aspx.cs" Inherits="Career" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
            <li class="active">Career</li>
        </ul>
        <div class="row">
            <div class="span12post">
                <h2 class="page-header">
                    <span>Career</span></h2>
                <div class="sidebar-line">
                    <span></span>
                </div>
                <div id="accordion2" class="accordion">
                    <asp:Repeater ID="rptrCarrer" runat="server">
                        <ItemTemplate>
                            <div class="accordion-group">
                                <div class="accordion-heading">
                                    <a href="#collapse<%# Container.ItemIndex + 1 %>" data-parent="#accordion<%# Container.ItemIndex + 1 %>" data-toggle="collapse" class="accordion-toggle collapsed min-width1024">
                                        <%--  FAQ
                                        <%# Container.ItemIndex + 1 %>
                                        :--%>
                                        <%# Eval("Designation") %></a>
                                </div>
                                <div class="accordion-body collapse" id="collapse<%# Container.ItemIndex + 1 %>" style="height: 0px;">
                                    <div class="accordion-inner">
                                        <div>
                                            <strong>Position&nbsp;:</strong> <span class="positionname">&nbsp;
                                        <%# Eval("Position") %></span>
                                        </div>
                                        <div class="clearfix5"></div>
                                        <div>
                                            <strong>No. of positions&nbsp;:</strong>&nbsp;
                                    <%# Eval("NoOfPosition") %>
                                        </div>
                                        <div class="clearfix5"></div>
                                        <div>
                                            <strong>Location&nbsp;:</strong>&nbsp;
                                    <%# Eval("Location") %>
                                        </div>
                                        <div class="clearfix5"></div>
                                        <div>
                                            <strong>Date Posted&nbsp;:</strong>&nbsp;<%# Eval("DatePosted","{0:dd/MM/yyyy}")%>
                                        </div>
                                        <div class="clearfix5"></div>
                                        <div>
                                            <strong>Responsibilities&nbsp;:</strong>

                                            <asp:Literal ID="lblResponsibilities" Text='<%# Eval("Responsibilities") != "" ? Eval("Responsibilities").ToString() : "&minus;"%>'
                                                runat="server"></asp:Literal>
                                        </div>
                                        <div class="clearfix5"></div>
                                        <div>
                                            <strong>Requirements&nbsp;:</strong>
                                            <asp:Literal ID="Literal1" Text='<%# Eval("Responsibilities") != "" ? Eval("Requirements").ToString() : "&minus;"%>' runat="server"></asp:Literal>
                                        </div>
                                        <div class="clearfix5"></div>
                                        <div class="right">
                                            <a href='Apply.aspx?Des=<%# Eval("Designation") %>' class="btn btn-primary btn-general span1">Apply</a>
                                        </div>
                                        <div class="clearfix5"></div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>
