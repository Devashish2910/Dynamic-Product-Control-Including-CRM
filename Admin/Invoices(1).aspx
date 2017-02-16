<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Invoices.aspx.cs" Inherits="Admin_Invoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .floatleft
        {
            display: block;
            float: left;
        }

        .floatleft50
        {
            display: block;
            float: left;
            width: 50%;
            margin-top: 5px;
        }

        .floatright
        {
            display: block;
            float: right;
        }

        .width100px
        {
            width: 110px !important;
        }

        .margin5
        {
            margin-bottom: 12px;
            margin-left: 0;
            margin-right: 0;
            margin-top: 5px;
            width: 450px;
            color: #666;
        }
    </style>

    <div class="widget">
        <div class="head">
            <h5 class="iList">
                <div class="floatleft" style="width: 800px;">
                    Order Details
                </div>
                <div class="floatright">
                    <a href="Orders.aspx">Back to Order</a>
                </div>
            </h5>
        </div>
        <asp:Repeater runat="server" ID="rptOrder">
            <ItemTemplate>
                <div class="rowElem noborder">
                    <div class="floatleft50">
                        <label class="width100px">
                            Order No :</label>
                        <div class="margin5">
                            <asp:Label ID="lblOrderNo" runat="server" Text='<%# Bind("OrderId") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Transaction ID :</label>
                        <div class="margin5">
                            <asp:Label ID="Label14" runat="server" Text='<%# Bind("PaypalId") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            Order Date :</label>
                        <div class="margin5">
                            <asp:Label ID="lblOrderdate" runat="server" Text='<%# Eval("OrderDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Order Amount :</label>
                        <div class="margin5">
                             INR&nbsp;<asp:Label ID="lblOrderAmt" runat="server" Text='<%# Math.Round(Convert.ToDouble(Eval("OrderAmount"))) %>' ></asp:Label>
                            <div class="fix">
                            </div>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem ">
                    <div class="floatleft50">
                        <label class="width100px">
                            Status :</label>
                        <div class="margin5">
                            <asp:Label runat="server" ID="lblStatus" Text='<%# Eval("OrderStatus") %>'></asp:Label>
                        </div>
                    </div>

                    <div class="fix">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <div class="fix" style="padding-bottom: 10px;">
        </div>
        <div class="fix">
        </div>
    </div>

    <div class="table">
        <div class="head">
            <h5 class="iFrames">All Record
            </h5>
        </div>
        <asp:Repeater ID="rptr" runat="server" OnItemCommand="rptr_ItemCommand">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="0" id="Column7" class="display">
                    <thead>
                        <tr>
                            <th>#
                            </th>

                            <th>Invoice. No
                            </th>
                            <th>Date
                            </th>
                            <th>Tracking No
                            </th>
                            <th>Courier Name
                            </th>
                            <th>Tracking Url
                            </th>
                            <th>Other Details
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
                        <asp:Label ID="lblDisplaySequence" runat="server" Text='<%#Container.ItemIndex +1 %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbInvoiceNO" runat="server" Text='<%#Eval("InvoiceNumber")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("InvoiceDate","{0:dd MMM yyyy}")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("TrackingNumber")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("CourierName")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("URL")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("OtherDetails")%>'></asp:Label>

                    </td>

                    <td class="center">
                        <asp:LinkButton ID="lnkbtnView" runat="server" CausesValidation="false" CommandArgument='<%# Bind("InvoiceDispatchId")%>'
                            CommandName="View" CssClass="linkCss" Text="View" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>&nbsp;|
                         <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("InvoiceDispatchId")%>'
                            CommandName="Edit" CssClass="linkCss" Text="Edit" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                    </td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
