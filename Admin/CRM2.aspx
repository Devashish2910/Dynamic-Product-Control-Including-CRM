<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="CRM2.aspx.cs" Inherits="Admin_CRM2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
                &nbsp;&nbsp;User Name:</label>
            <div class="formLeft  searchDrop" style="width: 275px">
                <asp:TextBox ID="txtusername" readonly="true" runat="server" Width="100%"></asp:TextBox>
            </div>
            <label style="width: 115px;">
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Product:<span class="req">*</span></label>
            <div class="formLeft  searchDrop" style="width: 300px">
                <asp:TextBox ID="txtproduct" runat="server" readonly="true"  CssClass="required"  Width="100%" 
                    AutoPostBack="True" ontextchanged="drpProduct_SelectedIndexChanged"></asp:TextBox>
            </div>
        </div>

        <div class="rowElem noborder">
            <label>
                &nbsp;&nbsp;Selling Price(₹):<span class="req">*</span></label>
            <div class="formLeft  searchDrop" style="width: 150px">
               <asp:TextBox ID="txtsellingprice" readonly="true" runat="server" CssClass="required"  
                    Width="100%" AutoPostBack="True"></asp:TextBox>               
            </div>
             <label>
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Discount(%):<span class="req">*</span></label>
            <div class="formLeft  searchDrop" style="width: 150px">
                <asp:TextBox ID="txtdiscount" runat="server" CssClass="text" TextMode="SingleLine" 
                    Width="100%"  MaxLength="15" AutoPostBack="True" ontextchanged="chkDiscount_TextChanged"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FTBtxtcontactno" runat="server" TargetControlID="txtdiscount"
                    ValidChars="0123456789.">
                </asp:FilteredTextBoxExtender>                                
            </div>
            <label>
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Discount Amount(₹):</label>
            <div class="formLeft  searchDrop" style="width: 150px">
                <asp:TextBox ID="txtdiscountamount" runat="server" CssClass="text" readonly="true" TextMode="SingleLine"
                    Style="width: 100%;" MaxLength="20" ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtdiscountamount"
                    ValidChars="0123456789.">
                </asp:FilteredTextBoxExtender>
                </div>
        </div>


        <div class="rowElem noborder">
        <label>
               Final Selling Price(₹):</label>
         <div class="formLeft  searchDrop" style="width: 70px">
                <asp:TextBox ID="txtfinalsellingprice" runat="server" readonly="true" CssClass="text" TextMode="SingleLine"
                    Style="width: 150%;" MaxLength="20"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"  TargetControlID="txtfinalsellingprice"
                    ValidChars="0123456789.">
                </asp:FilteredTextBoxExtender>
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
         <asp:Label ID="lblcustomerid"  runat="server" Visible="false" Text=""></asp:Label>
                       <asp:Label ID="lblproductid"  runat="server" Visible="false" Text=""></asp:Label>
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
                                #
                            </th>
                            <th align="left">
                                Client Name
                            </th>
                            <th align="left">
                                Product name
                            </th>
                            <th align="left">
                                Selling Price(₹)
                            </th>
                            <th align="left">
                               Discount(%)                                
                            </th>
                            <th align="left">
                               Discount(₹)
                            </th>
                            <th align="left">
                               Net Sale Price(₹)
                            </th>
                             <th align="left">
                               Action
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
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("name")%>'></asp:Label>
                        <asp:Label ID="lblcustid"  runat="server" Visible="false" Text=' <%# Eval("cusotmerid") %>'></asp:Label>
                    </td>
                    <td>
                     <asp:Label ID="lblproductname"  runat="server" Text=' <%# Eval("productname") %>'></asp:Label>
                        <asp:Label ID="lblproid"  runat="server" Visible="false" Text=' <%# Eval("productid") %>'></asp:Label>
                     <%--<asp:Label ID="lblMemberId" Visible="false" runat="server" Text='<%#Eval("MemberId")%>'></asp:Label>--%>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("prosaleprice")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("discount")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("disamt")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("netsaleprice")%>'></asp:Label>
                    </td>
                     <td class="center">
                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("id") %>'
                            CommandName="EditGroup" Text="Edit" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                        |
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="false" CommandArgument='<%#
                           Bind("id") %>' CommandName="DeleteGroup" OnClientClick="javascript:return window.confirm('Are
                           You Sure You Want To Delete?')" Text="Delete"></asp:LinkButton>
                    </td>
                        
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Content>

