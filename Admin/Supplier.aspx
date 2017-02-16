<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Supplier.aspx.cs" Inherits="Admin_Supplier" %>
     
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script type="text/javascript">
        $("#form1").validate();
    </script>
    <div class="widget">
        <div class="head">
            <h5 class="iList">
                Add Record</h5>
        </div>
        <div class="rowElem noborder">
            <label>
                Supplier Code:</label>
            <div class="formLeft  searchDrop" style="width: 200px">
                <asp:TextBox ID="txtSuppliercode" runat="server" Width="60%"></asp:TextBox>
            </div>
            <label style="width: 115px;">
                Supplier Name:<span class="req">*</span></label>
            <div class="formLeft  searchDrop" style="width: 330px">
                <asp:TextBox ID="txtsuppliername" runat="server" CssClass="required"  Width="100%"></asp:TextBox>
            </div>
        </div>
        <div class="rowElem">
            <label>
                Address:<span class="req">*</span></label>
            <div class="formLeft  searchDrop" style="width: 660px">
                <asp:TextBox ID="txtsupplieradd" runat="server" CssClass="required" TextMode="MultiLine"
                    Style="width: 100%; margin: 0px; height: 62px;"></asp:TextBox>
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="rowElem">
            <label>
                Contact No:<span class="req">*</span></label>
            <div class="formLeft  searchDrop" style="width: 200px">
                <asp:TextBox ID="txtcontactno" runat="server" CssClass="required" TextMode="SingleLine" placeholder="Contain 10 Digit"
                    Width="60%"  MaxLength="15"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtcontactno"     
                                    ValidationExpression="^[0-9]{10}$" />
                <asp:FilteredTextBoxExtender ID="FTBtxtcontactno" runat="server" TargetControlID="txtcontactno"
                    ValidChars="0123456789">
                </asp:FilteredTextBoxExtender>
                                
            </div>
            <label style="padding-left: 10px; width: 115px;">
                Email:</label>
            <div class="formLeft  searchDrop" style="width: 400px">
                <asp:TextBox ID="txtEmailId" runat="server" CssClass="text" TextMode="SingleLine"
                    Style="width: 80%;" MaxLength="20" placeholder="abc@xyz.com"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtEmailId"     
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
            </div>
        </div>
        <div class="submitForm " style="width: 100%">
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
                <table cellpadding="0" cellspacing="0" border="0" id="Column5" class="display">
                    <thead>
                        <tr>
                            <th align="left">
                                Supplier Code
                            </th>
                            <th align="left">
                                Supplier Name
                            </th>
                            <th align="left">
                                Address
                            </th>
                            <th align="left">
                                Contact No
                            </th>
                            <th align="left">
                                Email ID
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
                        <asp:Label ID="lblSupplierCode" runat="server" Text='<%#Eval("SupplierCode")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSupplierName" runat="server" Text='<%#Eval("SupplierName")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("ContactNo")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                    </td>
                    <%-- <td> <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" ImageUrl='<%#Eval("Image")
    %>' CssClass="img100" /> </td>--%>
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
</asp:Content>
