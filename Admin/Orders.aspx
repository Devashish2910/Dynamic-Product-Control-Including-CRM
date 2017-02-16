<%@ Page Language="C#"  Title="Best Admin" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Admin_Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <%--   <style type="text/css">
        div.selector
        {
            width: 100px !important;
        }

            div.selector span
            {
                width: 100px !important;
            }

            div.selector select
            {
                width: 112px;
            }
    </style>--%>
    <div class="widget">
        <div class="head">
            <h5 class="iList">Orders
            </h5>
        </div>
    </div>
    <div class="table">
        <div class="head">
            <h5 class="iFrames">All Record
            </h5>
        </div>
        <asp:Repeater ID="rptr" runat="server" OnItemCommand="rptr_ItemCommand" OnItemDataBound="rptr_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="0" id="Column8" class="display">
                    <thead>
                        <tr>
                            <th>#
                            </th>

                            <th>Order.No
                            </th>
                            <th>Name
                            </th>
                            <th>Date
                            </th>
                            <th>Amount
                            </th>
                           <%-- <th>Payment Mode
                            </th>--%>
                            <th>Payment
                            </th>
                            <th>Order Status
                            </th>
                            
                            <th>Orders
                            </th>
                            <th>Invoice
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
                        <asp:Label ID="lblOrderID" runat="server" Text='<%#Eval("OrderId")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("SName")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("OrderDate","{0:dd MMM yyyy}")%>'></asp:Label>
                    </td>
                    <td>Rs.&nbsp;<asp:Label ID="lblOrderAmount" runat="server" Text='<%#Eval("OrderAmount")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPaymentMode" runat="server" Text='<%#Eval("PaymentMode")%>'></asp:Label>
                    </td>
                   <%-- <td>
                        <asp:LinkButton runat="server" ID="lnkPaid" Text='<%#(DataBinder.Eval(Container.DataItem,"IsPaid").ToString().ToLower()=="true") ? "Paid":"Pending" %>' ToolTip='<%#(DataBinder.Eval(Container.DataItem,"IsPaid").ToString().ToLower()=="true") ? "Click to make status as Pending":"Click to make status as Paid" %>' CommandArgument='<%# Eval("InvoiceId")+","+Eval("IsPaid") %>' CommandName="UpdateStatus" CausesValidation="false"></asp:LinkButton>
                        <asp:CheckBox runat="server" ID="chkCOD" Checked='<%#Eval("IsPaid")%>' Visible="false" AutoPostBack="true" OnCheckedChanged="chkCOD_CheckedChanged" ToolTip='<%# Eval("InvoiceId") %>' />
                       
                    </td>--%>
                    <td>
                        <asp:DropDownList runat="server" ID="drpStatus" AutoPostBack="true" value="Select Order Status" OnSelectedIndexChanged="drpStatus_SelectedIndexChanged1" ToolTip='<%# Eval("InvoiceId") %>'>
                            <asp:ListItem Text="Select Order Status"></asp:ListItem>
                            <asp:ListItem Text="Payment Verification Pending"></asp:ListItem>
                            <asp:ListItem Text="COD Verification Pending"></asp:ListItem>
                            <asp:ListItem Text="Order Under Processing "></asp:ListItem>
                            <asp:ListItem Text="Order Packed"></asp:ListItem>
                            <asp:ListItem Text="Order Shipped"></asp:ListItem>                           
                            <asp:ListItem Text="Order Cancelled"></asp:ListItem>
                            <asp:ListItem Text="Order Completed"></asp:ListItem>
                         </asp:DropDownList><br />
                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("OrderStatus")%>'  Font-Bold="True"></asp:Label>
                    </td>
                    

                    <td class="center">
                        <asp:LinkButton ID="lnkbtnView" runat="server" CausesValidation="false" CommandArgument='<%# Bind("InvoiceId")%>'
                            CommandName="View" CssClass="linkCss" Text="View" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>

                        <%--  |
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Bind("InvoiceId")%>'
                            CommandName="Delete" CssClass="linkCss" OnClientClick="javascript:return window.confirm('Are You Sure You Want To Delete?')"
                            Text="Delete"></asp:LinkButton>--%>
                    </td>
                    <td class="center">
                        <asp:LinkButton ID="lnkGenerateInvoice" runat="server" CausesValidation="false" CommandArgument='<%# Bind("InvoiceId")%>'
                            CommandName="GenreateInvoice" CssClass="linkCss" Text="Generate" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                        &nbsp;|&nbsp;
                         <asp:LinkButton ID="lnkViewInvoice" runat="server" CausesValidation="false" CommandArgument='<%# Bind("InvoiceId")%>'
                             CommandName="ViewInvoice" CssClass="linkCss" Text="View" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

