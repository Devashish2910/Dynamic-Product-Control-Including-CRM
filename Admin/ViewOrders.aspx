<%@ Page Language="C#"  Title="Best Admin" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ViewOrders.aspx.cs" Inherits="Admin_ViewOrders" %>

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
            </ItemTemplate>
        </asp:Repeater>

        <%-- <div class="floatleft50">
                <label class="width100px">
                    Order Status :</label>
                <div class="margin5">
                    <asp:DropDownList ID="ddlOrderStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOrderStatus_SelectedIndexChanged">
                        <asp:ListItem Text="In Process"></asp:ListItem>
                        <asp:ListItem Text="Pending"></asp:ListItem>
                        <asp:ListItem Text="Dispatched"></asp:ListItem>
                        <asp:ListItem Text="Delivered"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>--%>
        <%-- <div class="floatleft50">
                <label class="width100px">
                    Is Paid :</label>
                <div class="margin5">
                    <asp:CheckBox runat="server" ID="chkCOD" Visible="false" AutoPostBack="true" OnCheckedChanged="chkCOD_CheckedChanged" />
                    <asp:Label ID="lblPaid" runat="server" Text="Yes" Visible="true"></asp:Label>
                    <div class="fix">
                    </div>
                </div>
            </div>--%>

        <div>
            <%-- <asp:Panel runat="server" ID="pnlShip" Visible="false">
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            Courier type :</label>
                        <div class="margin5">
                            <asp:DropDownList ID="drpCourier" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Tracking No. :<span class="req">*</span></label>
                        <div class="margin5">
                            <asp:TextBox runat="server" ID="txtTrackingNo" CssClass="required"
                                Width="200px"></asp:TextBox>
                            <div class="fix">
                            </div>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
            </asp:Panel>--%>
        </div>
        <%--<div class="submitForm" style="width: 100%">
            <div style="float: right">
                <asp:Button ID="btnSubmit" runat="server" Text="Update" CssClass="redBtn" OnClick="btnSubmit_Click" /></div>
            <div style="float: right; padding-top: 5px; padding-right: 10px;">
                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="txtError"></asp:Label></div>
        </div>--%>
        <div class="fix" style="padding-bottom: 10px;">
        </div>
        <div class="fix">
        </div>
    </div>
    <div class="widget">
        <div class="head">
            <h5 class="iList">Product Details</h5>
        </div>
        <asp:Repeater runat="server" ID="rptProduct">
            <ItemTemplate>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            <strong>
                                <%# Container.ItemIndex + 1%>. &nbsp;Product Name :</strong></label>
                        <div class="margin5">
                            <strong>
                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label></strong>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            <strong>Product Code :</strong></label>
                        <div class="margin5">
                            <strong>
                                <asp:Label ID="lblProductPrice" runat="server" Text='<%# Bind("ProductCode") %>'></asp:Label></strong>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem ">
                    <div class="floatleft50">
                        <label class="width100px">
                            &nbsp;&nbsp;&nbsp; &nbsp;Category :</label>
                        <div class="margin5">
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Sub Category :</label>
                        <div class="margin5">
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("SubCategoryName") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem ">
                    <div class="floatleft50">
                        <label class="width100px">
                            &nbsp;&nbsp;&nbsp; &nbsp;Brand :</label>
                        <div class="margin5">
                            <asp:Label ID="lblBrand" runat="server" Text='<%# Bind("BrandName") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Supplier :</label>
                        <div class="margin5">
                            <asp:Label ID="lblProductQty" runat="server" Text='<%# Bind("SupplierName") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem ">
                    <div class="floatleft50">
                        <label class="width100px">
                            &nbsp;&nbsp;&nbsp; &nbsp;Colour :</label>
                        <div class="margin5">
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("ColourName") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Size :</label>
                        <div class="margin5">
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("SizeName") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem ">
                    <div class="floatleft50">
                        <label class="width100px">
                            &nbsp;&nbsp;&nbsp; &nbsp;Quantity :</label>
                        <div class="margin5">
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Price :</label>
                        <div class="margin5">
                            INR&nbsp;<asp:Label ID="Label6" runat="server" Text='<%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) %>' ></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem ">
                    <div class="floatleft50">
                       <%-- <label class="width100px">
                            &nbsp;&nbsp;&nbsp; &nbsp;Discount :</label>
                        <div class="margin5">
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Discount") %>'></asp:Label>
                            %
                        </div>--%>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Shipping Days :</label>
                        <div class="margin5">
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("ShippingDays") %>'></asp:Label>&nbsp;Days
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="fix">
        </div>
    </div>
    <div class="widget">
        <div class="head">
            <h5 class="iList">Shipping Details</h5>
        </div>
        <asp:Repeater runat="server" ID="rptShipping">
            <ItemTemplate>
                <div class="rowElem noborder">
                    <div class="floatleft50">
                        <label class="width100px">
                            Name :</label>
                        <div class="margin5">
                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("SName") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Company :</label>
                        <div class="margin5">
                            <asp:Label ID="lblCompany" runat="server" Text='<%# Bind("SCompany") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft">
                        <label class="width100px">
                            Address :</label>
                        <div class="margin5">
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("SAddress1") %>'></asp:Label>
                        </div>
                    </div>
                    <%-- <div class="floatleft50">
                        <label class="width100px">
                            Address Line 2:</label>
                        <div class="margin5">
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("SAddress2") %>'></asp:Label>
                        </div>
                    </div>--%>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            City :</label>
                        <div class="margin5">
                            <asp:Label ID="lblCity" runat="server" Text='<%# Bind("SCity") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            State :</label>
                        <div class="margin5">
                            <asp:Label ID="lblState" runat="server" Text='<%# Bind("SState") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            Country :</label>
                        <div class="margin5">
                            <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("SCountry") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Zipcode :</label>
                        <div class="margin5">
                            <asp:Label ID="lblZipCode" runat="server" Text='<%# Bind("SZipCode") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            Contact :</label>
                        <div class="margin5">
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("SContact") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Email :</label>
                        <div class="margin5">
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("SEmail") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="fix">
        </div>

    </div>
    <div class="widget">
        <div class="head">
            <h5 class="iList">Billing Details</h5>
        </div>
        <asp:Repeater runat="server" ID="rptBill">
            <ItemTemplate>
                <div class="rowElem noborder">
                    <div class="floatleft50">
                        <label class="width100px">
                            Company :</label>
                        <div class="margin5">
                            <asp:Label ID="lblCompany" runat="server" Text='<%# Bind("Company") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Contact :</label>
                        <div class="margin5">
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("Contact") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft">
                        <label class="width100px">
                            Address :</label>
                        <div class="margin5">
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address1") %>'></asp:Label>
                        </div>
                    </div>
                    <%--<div class="floatleft50">
                        <label class="width100px">
                            Address Line 2:</label>
                        <div class="margin5">
                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("Address2") %>'></asp:Label>
                        </div>
                    </div>--%>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            City :</label>
                        <div class="margin5">
                            <asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            State :</label>
                        <div class="margin5">
                            <asp:Label ID="lblState" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            Country :</label>
                        <div class="margin5">
                            <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <label class="width100px">
                            Zipcode :</label>
                        <div class="margin5">
                            <asp:Label ID="lblZipCode" runat="server" Text='<%# Bind("ZipCode") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
                <div class="rowElem">
                    <div class="floatleft50">
                        <label class="width100px">
                            TIN No :</label>
                        <div class="margin5">
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="floatleft50">
                        <div class="floatleft50">
                            <label class="width100px">
                                CST No :</label>
                            <div class="margin5">
                                <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="fix">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <div class="fix">
        </div>
        <%--<div class="submitForm" style="width: 100%">
            <div style="float: right">
                <asp:Button ID="btnBack" runat="server" Text="back" CssClass="greyishBtn" OnClick="btnBack_Click" />
            </div>
            <div style="float: right; padding-top: 5px; padding-right: 10px;">
            </div>
        </div>
        <div class="fix">
        </div>--%>
    </div>

</asp:Content>
