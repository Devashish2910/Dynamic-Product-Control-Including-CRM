<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ManageCoupons.aspx.cs" Inherits="Admin_ManageCoupons" MaintainScrollPositionOnPostback="true"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $("#form1").validate();
    </script>
    <style>
        .mainForm label
        {
            margin-right: 0px;
        }
        a.aspNetDisabled
        {
            color: #393939 !important;
            text-decoration: none !important;
        }
    </style>
    <div class="widget">
        <div class="head">
            <h5 class="iList">
                Add Record</h5>
        </div>
        <div class="rowElem noborder">
            <label>
                Code :<span class="req">*</span></label>
            <div class="formLeft  searchDrop" style="width: 250px">
                <asp:TextBox ID="txtCode" runat="server" Width="100%" CssClass="required"></asp:TextBox>
            </div>
        </div>
        <div class="rowElem">
            <label>
                Choose Criteria :<span class="req">*</span></label>
            <div class="floatleft" style="width: 780px;">
                <div class="formLeft" style="width: 260px;">
                    <asp:CheckBox runat="server" ID="chkCriteriaA" Text="Criteria A" Font-Bold="true" /><br />
                    <asp:RadioButtonList runat="server" ID="rbtCriteriaA">
                        <asp:ListItem Text="Registerd User" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Any User" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="formLeft" style="width: 260px;">
                    <asp:CheckBox runat="server" ID="chkCriteriaB" Text="Criteria B" Font-Bold="true" /><br />
                    <asp:RadioButtonList runat="server" ID="rbtCriteriaB">
                        <asp:ListItem Text="First Purchase" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Any Purchase" Value="4"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="formLeft" style="width: 260px;">
                    <asp:CheckBox runat="server" ID="chkCriteriaC" Text="Criteria C" Font-Bold="true" /><br />
                    <asp:RadioButtonList runat="server" ID="rbtCriteriaC">
                        <asp:ListItem Text="Order Value Over 20,000" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Order Value Over 50,000" Value="6"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Discount(%):<span class="req">*</span></label>
            <div class="formLeft" style="width: 250px">
                <asp:TextBox ID="txtDiscount" runat="server" CssClass="required" Width="100%"></asp:TextBox>
                <asp:FilteredTextBoxExtender runat="server" ID="ftbe" TargetControlID="txtDiscount"
                    ValidChars=".0123456789" FilterMode="ValidChars">
                </asp:FilteredTextBoxExtender>
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Is Active:<span class="req">*</span></label>
            <div class="formLeft" style="width: 250px">
                <asp:CheckBox runat="server" ID="chkIsActive" Checked="true" />
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="submitForm " style="width: 100%">
            <div style="float: right">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="redBtn" OnClick="btnSubmit_Click" />
            </div>
            <div style="float: right; padding-top: 5px; padding-right: 10px;">
                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="txtError"></asp:Label>
            </div>
        </div>
        <div class="fix">
        </div>
    </div>
    <div style="width: 100%; text-align: center; padding-top: 10px;">
        <asp:Label ID="lblDeleteMsg" runat="server" Text="" CssClass="txtError"></asp:Label>
    </div>
    <div class="table">
        <div class="head">
            <h5 class="iFrames">
                All Record
            </h5>
        </div>
        <asp:Repeater ID="rptr" runat="server" OnItemCommand="rptr_ItemCommand">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="0" id="Column5" class="display">
                    <thead>
                        <tr>
                            <th align="left">
                                Coupon Code
                            </th>
                            <th align="left">
                                Criteria A
                            </th>
                            <th align="left">
                                Criteria B
                            </th>
                            <th align="left">
                                Criteria C
                            </th>
                            <th align="left">
                                Discount(%)
                            </th>
                            <th align="left">
                                Is Active
                            </th>
                            <th>
                                Action
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="gradeA">
                    <td>
                        <asp:Label ID="lblCouponName" runat="server" Text='<%#Eval("CouponName")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCriteriaAVal" runat="server" Text='<%#Eval("CriteriaAVal")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCriteriaBVal" runat="server" Text='<%#Eval("CriteriaBVal")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCriteriaCVal" runat="server" Text='<%#Eval("CriteriaCVal")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount")%>'></asp:Label>
                    </td>
                    <td>
                        <%--<asp:CheckBox runat="server" ID="chkIsActive" Checked='<%# Convert.ToBoolean(Eval("InUse")) %>' ToolTip='<%# Eval("Id") %>' AutoPostBack="true" OnCheckedChanged="chkIsActive_CheckedChanged" />--%>
                        <asp:LinkButton runat="server" ID="lnkSpYes" Enabled='<%# !Convert.ToBoolean(Eval("InUse")) %>'
                            Text="Yes" CommandName="InUseYes" CommandArgument='<%# Eval("Id") %>' Style="text-decoration: underline;"></asp:LinkButton>&nbsp;|&nbsp;
                        <asp:LinkButton runat="server" ID="lnkSpNo" Enabled='<%#Eval("InUse") %>' Text="No"
                            CommandName="InUseNo" CommandArgument='<%# Eval("Id") %>' Style="text-decoration: underline;"></asp:LinkButton>
                    </td>
                    <td class="center">
                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Id") %>'
                            CommandName="Edit" Text="Edit" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                        |
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="false" CommandArgument='<%#Bind("Id") %>'
                            CommandName="Delete" OnClientClick="javascript:return window.confirm('Are You Sure You Want To Delete?');"
                            Text="Delete"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
