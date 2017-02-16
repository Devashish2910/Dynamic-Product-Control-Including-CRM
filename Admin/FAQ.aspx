<%@ Page  Title="Best Admin" ValidateRequest="false" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="FAQ.aspx.cs" Inherits="Admin_FAQ" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../Style/ftb.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $("#form1").validate();
    </script>
    <div class="widget">
        <div class="head">
            <h5 class="iList">
                Add Record
            </h5>
        </div>
        <div class="rowElem noborder">
            <label>
                Category:<span class="req">*</span></label>
            <div class="formLeft">
                <%--<asp:TextBox ID="txtZone" runat="server" CssClass="required" Width="30%"></asp:TextBox>--%>
                <asp:DropDownList ID="drpFAQ" runat="server" Width="200px">
                    <asp:ListItem Selected="True">-Select-</asp:ListItem>
                    <asp:ListItem Value="1" Text="Account">Account</asp:ListItem>
                    <asp:ListItem Value="2" Text="Order">Order</asp:ListItem>
                    <asp:ListItem Value="3" Text="Payment">Payment</asp:ListItem>
                    <asp:ListItem Value="4" Text="Shipping Policy">Shipping Policy</asp:ListItem>
                    <asp:ListItem Value="5" Text="Return and Cancellation Policy">Return and Cancellation Policy</asp:ListItem>                    
                </asp:DropDownList>
            </div>
            <div class="fix">
            </div>
            <label>
                Title:<span class="req">*</span></label>
            <div class="formLeft">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="required" Width="700px"></asp:TextBox>
            </div>
            <div class="fix">
            </div>
            <label>
                Description:<span class="req">*</span></label>
            <div>
               <FTB:FreeTextBox ID="txtDescription" BreakMode="LineBreak" ToolbarLayout="Bold,Italic,Underline,Superscript,Subscript;FontFacesMenu,FontSizesMenu,SymbolsMenu,FontBackColorsMenu|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;Cut,Copy,Paste,Delete;InsertDate,InsertTime,InsertTable"
                    runat="Server" Focus="True" AutoGenerateToolbarsFromString="True" Height="300px"
                    ImageGalleryPath="../GeneralImages" Width="950px" ButtonSet="OfficeXP" RenderMode="NotSet"
                    UpdateToolbar="True" UseToolbarBackGroundImage="True" RemoveServerNameFromUrls="false">
                </FTB:FreeTextBox>
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="submitForm" style="width: 100%">
            <div style="float: right">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="redBtn" OnClick="btnSubmit_Click" /></div>
            <div style="float: right; padding-top: 5px; padding-right: 10px;">
                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="txtError"></asp:Label></div>
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
                <table cellpadding="0" cellspacing="0" border="0" id="Column1" class="display">
                    <thead>
                        <tr>
                            <th align="left">
                                Category
                            </th>
                            <th align="left">
                                Title
                            </th>
                            <th align="left">
                                Description
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
                        <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTitle" runat="server" Text='<%#Eval("Title")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                    </td>
                    <td class="center">
                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Id") %>'
                            CommandName="EditGroup" Text="Edit" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                        |
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Id") %>'
                            CommandName="DeleteGroup" OnClientClick="javascript:return window.confirm('Are You Sure You Want To Delete?')"
                            Text="Delete"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <%--<div class="widget">
        <div class="head">
            <h5 class="iList">
                FAQ
            </h5>
        </div>
        <div class="rowElem noborder">
            <label>
                Category:</label>
            <div class="formLeft">
                <asp:DropDownList ID="drpCategory" runat="server" CssClass="required selector">
                    <asp:ListItem Selected="True">-Select Category -</asp:ListItem>
                    <asp:ListItem>Account</asp:ListItem>
                    <asp:ListItem>Order</asp:ListItem>
                    <asp:ListItem>Payment</asp:ListItem>
                    <asp:ListItem>Shipping Policy</asp:ListItem>
                    <asp:ListItem>Return and Cancellation Policy</asp:ListItem>
                    <asp:ListItem>Terms and Condition</asp:ListItem>
                    <asp:ListItem>Privacy Policy</asp:ListItem>
                </asp:DropDownList>
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="fix">
        </div>
        <label>
            Title:<span class="req">*</span></label>
        <div class="formLeft">
            <asp:TextBox ID="txtTitle" runat="server" CssClass="required" Width="40%" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="fix">
        </div>
        <label>
            Description:<span class="req">*</span></label>
        <div class="formLeft">
            <asp:TextBox ID="txtDescription" runat="server" CssClass="required" Width="40%" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="fix">
        </div>
        <div class="submitForm" style="width: 100%">
            <div style="float: right">
                <asp:Button ID="btnSubmit" runat="server" Text="Update" CssClass="redBtn" /></div>
            <div style="float: right; padding-top: 5px; padding-right: 10px;">
                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="txtError"></asp:Label></div>
        </div>
        <div class="fix">
        </div>
        <div style="width: 100%; text-align: center; padding-top: 10px;">
            <asp:Label ID="lblDeleteMsg" runat="server" Text="" CssClass="txtError"></asp:Label>
        </div>
    </div>--%>
</asp:Content>
