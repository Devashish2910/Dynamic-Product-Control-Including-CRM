<%@ Page Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="CRM.aspx.cs" Inherits="CRM" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
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
            <div class="fix">
            </div>
            <label>
                Select Product:<span class="req">*</span></label>
            <div class="formLeft">
                <asp:DropDownList ID="drpProduct" runat="server"  CssClass="required selector"
                    Width="202px" AutoPostBack="True" 
                    onselectedindexchanged="drpProduct_SelectedIndexChanged">
                    <asp:ListItem Selected="True">-Select Product-</asp:ListItem>
                </asp:DropDownList>
                  <div style="width: 65%; text-align: center; padding-top: 10px;">
                   <asp:Label ID="lblprice" runat="server" Text="" CssClass="txtError"></asp:Label>
                </div>
            </div>
            <div class="fix">
            </div>
        </div>
      
        <div class="rowElem noborder">
            <div class="fix">
            </div>
            <label>
                Discount(%):<span class="req">*</span></label>
            <div class="formLeft">
          
            <asp:TextBox ID="chkDiscount" runat="server" CssClass="required selector"
                    Width="70px" AutoPostBack="True" ontextchanged="chkDiscount_TextChanged"></asp:TextBox>
            <%-- <asp:FilteredTextBoxExtender ID="FTBtxtcontactno" runat="server" TargetControlID="chkDiscount"
                    ValidChars="0123456789.">--%>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"  TargetControlID="chkDiscount" ValidChars="0123456789" runat="server"></cc1:FilteredTextBoxExtender>
           
            </div>           
            <div style="width: 45%; text-align: center; padding-top: 10px;">
               <asp:Label ID="lbldiscount" runat="server" Text="" CssClass="txtError"></asp:Label>
               <br /><asp:Label ID="lblsaleprice" runat="server" Text="" CssClass="txtError"></asp:Label>
            </div>
             <div class="fix">
            </div>
        </div>
        
       
    <div class="submitForm" style="width: 100%">
        <div style="float: right">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="redBtn"
                OnClick="btnSubmit_Click" /></div>
        <div style="float: right; padding-top: 5px; padding-right: 10px;">
                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="txtError"></asp:Label></div>
        <div class="fix">
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
        <asp:Repeater ID="rptr" runat="server">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="0" id="Column3" class="display">
                    <thead>
                        <tr>
                            <th align="left">
                                #
                            </th>
                            <th align="left">
                                User Name
                            </th>
                            <th align="left">
                                Email
                            </th>
                            <th align="center"  >
                                <asp:CheckBox runat="server" ID="chkAll" Text="Whom To Be Offered??" OnCheckedChanged="chkAll_OnCheckedChanged" AutoPostBack="true"/>
                                 
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="gradeA">
                    <td>
                        <%# Container.ItemIndex + 1  %>
                    </td>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                    </td>
                    <td>
                     <asp:Label ID="lblEmail"  runat="server" Text=' <%# Eval("Email") %>'></asp:Label>
                       
                        <asp:Label ID="lblMemberId" Visible="false" runat="server" Text='<%#Eval("MemberId")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox runat="server" ID="chk" ToolTip='<%#Eval("MemberId")%>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

