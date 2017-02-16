<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ManageCarrer.aspx.cs" Inherits="Admin_ManageCarrer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $("#form1").validate();
    </script>
    <div class="widget">
        <div class="head">
            <h5 class="iList">Add Record
            </h5>
        </div>

        <div class="rowElem noborder">
            <label>
                Designation:<span class="req">*</span></label>
            <div class="formLeft" style="width: 400px">
                <asp:TextBox ID="txtDesignation" runat="server" CssClass="required" Width="100%"></asp:TextBox>
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Position:<span class="req">*</span></label>
            <div class="formLeft" style="width: 400px">
                <asp:TextBox ID="txtPosition" runat="server" CssClass="required" Width="100%"></asp:TextBox>
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                No. Of Position:<span class="req">*</span></label>
            <div class="formLeft" style="width: 400px">
                <asp:TextBox ID="txtNoOfPosition" runat="server" CssClass="required" Width="100%"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtNoOfPosition"     
                                    ValidationExpression="^[0-9]*$" />
              
                <div class="fix">
                </div>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtPosition"
                    FilterMode="InvalidChars" InvalidChars="'/\~:">
                </cc1:FilteredTextBoxExtender>
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Location:<span class="req">*</span></label>
            <div class="formLeft" style="width: 400px">
                <asp:TextBox ID="txtLocation" runat="server" CssClass="required" Width="100%"></asp:TextBox>
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Responsibilities:<span class="req">*</span></label>
            <div class="formLeft" style="width: 400px">
                <asp:TextBox ID="txtResponsiblities" runat="server" CssClass="required" TextMode="MultiLine" Width="100%" Height="150px"></asp:TextBox>
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Requirements:<span class="req">*</span></label>
            <div class="formLeft" style="width: 400px">
                <asp:TextBox ID="txtRequirements" runat="server" CssClass="required" TextMode="MultiLine" Width="100%"  Height="150px"></asp:TextBox>
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="submitForm" style="width: 100%">
            <div style="float: right">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="redBtn" OnClick="btnSubmit_OnClick" />
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
                All Record</h5>
        </div>
        <asp:Repeater ID="rptr" runat="server" OnItemCommand="rptr_OnItemCommand">
            <HeaderTemplate>
                 <table cellpadding="0" cellspacing="0" border="0" id="Column1" class="display">
                    <thead>
                        <tr>
                            <th>
                                Designation
                            </th>
                            <th>
                                Position
                            </th>
                            <th>
                                No Of Position
                            </th>
                             <th>
                                Date Posted
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
                        <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPosition" runat="server" Text='<%#Eval("Position")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblNoOfPosition" runat="server" Text='<%#Eval("NoOfPosition")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDatePosted" runat="server" Text='<%#Eval("DatePosted","{0:dd-MM-yyyy}")%>'></asp:Label>
                    </td>
                    <td class="center">
                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("CurrentOpeningID") %>'
                            CommandName="Edit" CssClass="linkCss" Text="Edit" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                        |
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Bind("CurrentOpeningID") %>'
                            CommandName="Delete" CssClass="linkCss" OnClientClick="javascript:return window.confirm('Are You Sure You Want To Delete?');"
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

