<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="CourierMaster.aspx.cs" Inherits="Admin_CourierMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    $("#form1").validate();
    </script>
    <div class="widget">
        <div class="head">
            <h5 class="iList">
                Add Record</h5>
        </div>
          <div class="rowElem">
            <label>
                Courier Name:<span class="req">*</span></label>
            <div class="formRight">
            <asp:TextBox runat="server" ID="txtCourierName" placeholder="Name of the Courier Company" Width="300px"  CssClass="required"></asp:TextBox>
                <div class="fix">
                </div>
            </div>
        </div>
          <div class="rowElem">
            <label>
                URL:<span class="req">*</span></label>
            <div class="formRight">
             <asp:TextBox runat="server" ID="txtUrl" Width="400px"  placeholder="Eg:http://www.ups.com/tracking/tracking.html" CssClass="required"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtUrl"     
                                    ValidationExpression="^(http|https)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$" />
                <div class="fix">
                </div>
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
    <%--<div class="table">
        <div class="head">
            <h5 class="iFrames">
                All Record
            </h5>
        </div>
        <asp:Repeater ID="rptr" runat="server" OnItemCommand="rptr_OnItemCommand">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="0" id="Courier" class="display">
                    <thead>
                        <tr>
                            <th>
                                Sr No
                            </th>
                            <th>
                               Courier Name
                            </th>
                              <th>
                                Url
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
                       <%# Container.ItemIndex +1 %>
                    </td>
                    <td>
                       <asp:Label ID="lbl1" runat="server" Text='<%#Eval("CourierName")%>'></asp:Label>
                    </td>
                     <td>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Url")%>'></asp:Label>
                    </td>
                 
                    <td class="center">
                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ID")%>'
                            CommandName="Edit" CssClass="linkCss" Text="Edit" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                              |
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ID")%>'
                            CommandName="Delete" CssClass="linkCss" OnClientClick="javascript:return window.confirm('Are You Sure You Want To Delete?')"
                            Text="Delete"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>--%>
    <div class="table">
        <div class="head">
            <h5 class="iFrames">
                All Record
            </h5>
        </div>
        <asp:Repeater ID="rptr" runat="server" OnItemCommand="rptr_ItemCommand">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="0" id="Column3" class="display">
                    <thead>
                      <tr>
                            <th>
                                Sr No
                            </th>
                            <th>
                               Courier Name
                            </th>
                              <th>
                                Url
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
                       <%# Container.ItemIndex +1 %>
                    </td>
                    <td>
                       <asp:Label ID="lbl1" runat="server" Text='<%#Eval("CourierName")%>'></asp:Label>
                    </td>
                     <td>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Url")%>'></asp:Label>
                    </td>
                 
                    <td class="center">
                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ID")%>'
                            CommandName="Edit" CssClass="linkCss" Text="Edit" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                              <%--|
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ID")%>'
                            CommandName="Delete" CssClass="linkCss" OnClientClick="javascript:return window.confirm('Are You Sure You Want To Delete?')"
                            Text="Delete"></asp:LinkButton>--%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

