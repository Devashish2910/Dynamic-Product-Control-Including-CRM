<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ManageUser.aspx.cs" Inherits="Admin_ManageUser" %>

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
            <br />
            <b><u>PERSONAL INFORMATION</u></b>
            <br />
            <div class="fix">
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Member Name:<span class="req">*</span></label>
            <div class="formLeft" style="width: 400px">
                <asp:TextBox ID="txtMemName" runat="server" CssClass="required" Width="100%" placeholder="Name Of the User"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtMemName"     
                                    ValidationExpression="^[a-zA-Z ]*$" />

            </div>
            <div class="fix">
            </div>
        </div>
        <div class="rowElem noborder">
            <label style="width: 133px;">
                Email:<span class="req">*</span></label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtEmail" runat="server"  placeholder="User's Email" CssClass="required email"
                    ReadOnly="false" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtEmail"     
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
            </div>
            <label style="padding-left: 88px; width: 133px;">
                Password:<span class="req">*</span></label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtPassword" runat="server" Placeholder="Must be in 6-20 Char." CssClass="required"
                    ReadOnly="false"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtPassword"     
                                    ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,20}$" />
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="rowElem">
            <br />
            <b><u>Company INFORMATION</u></b>
            <br />
            <div class="fix">
            </div>
        </div>
        <div class="rowElem noborder">
            <label style="width: 133px;">
                Company Name:</label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtCompany" placeholder="User's Company Name" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtCompany"     
                                    ValidationExpression="^[a-zA-Z0-9 ]*$" />
            </div>
            <label style="padding-left: 88px; width: 133px;">
                Contact:<%--<span class="req">*</span>--%></label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtContact" placeholder="10 Digit Compulsary" runat="server" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtContact"     
                                    ValidationExpression="^[0-9]{10}$" />
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="rowElem noborder">
            <label style="width: 133px;">
                Address:<%--<span class="req">*</span>--%></label>
            <div class="formLeft" style="width: 400px">
                <asp:TextBox ID="txtAddress1" runat="server" TextMode="MultiLine" Height="55"></asp:TextBox>
            </div>
            <%--      <label style="padding-left: 88px; width: 200px;">
                Address2:</label>--%>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtAddress2" runat="server" Visible="false"></asp:TextBox>
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="rowElem noborder">
            <label style="width: 133px;">
                PinCode:</label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtZipCode" placeholder="6 digit Postal Code" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtZipCode"     
                                    ValidationExpression="^[0-9]{6}$" />
            </div>
            <label style="padding-left: 88px; width: 133px;">
                City:</label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtCity"     
                                    ValidationExpression="^[a-zA-Z ]*$" />
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="rowElem noborder">
            <label style="width: 133px;">
                State:</label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtState"     
                                    ValidationExpression="^[a-zA-Z ]*$" />
            </div>
            <label style="padding-left: 88px; width: 133px;">
                Country:</label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtCountry" runat="server" value="India" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="rowElem">
            <br />
            <b><u>BILLING INFORMATION</u></b>
            <br />
            <div class="fix">
            </div>
        </div>
        <div class="rowElem noborder">
            <label style="width: 133px;">
                Company Name:</label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtBCompany" runat="server" placeholder="User's Company Name"></asp:TextBox>
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtBCompany"     
                                    ValidationExpression="^[a-zA-Z0-9 ]*$" />
            </div>
            <label style="padding-left: 88px; width: 133px;">
                Contact:<%--<span class="req">*</span>--%></label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtBContact" runat="server" placeholder="10 Digit Compulsary" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtContact"     
                                    ValidationExpression="^[0-9]{10}$" />
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="rowElem noborder">
            <label style="width: 133px;">
                Address:<%--<span class="req">*</span>--%></label>
            <div class="formLeft" style="width: 400px">
                <asp:TextBox ID="txtBAddress1" runat="server"  TextMode="MultiLine" Height="55"></asp:TextBox>
            </div>
            <%--      <label style="padding-left: 88px; width: 200px;">
                Address2:</label>--%>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtBAddress2" runat="server" Visible="false"></asp:TextBox>
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="rowElem noborder">
            <label style="width: 133px;">
                PinCode:</label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtBZipCode" runat="server" placeholder="6 digit postal code"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtBZipCode"     
                                    ValidationExpression="^[0-9]{6}$" />

            </div>
            <label style="padding-left: 88px; width: 133px;">
                City:</label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtBCity" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtBCity"     
                                    ValidationExpression="^[a-zA-Z ]*$" />
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="rowElem noborder">
            <label style="width: 133px;">
                State:</label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtBState" runat="server"></asp:TextBox>
               
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtBState"     
                                    ValidationExpression="^[a-zA-Z ]*$" />
                                    </div>
           
            <label style="padding-left: 88px; width: 133px;">
                Country:</label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtBCountry" value="India" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="fix">
            </div>
            </div>
        
           <div class="rowElem noborder">
            <label style="width: 133px;">
                TIN No:</label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtTin" ReadOnly="true" runat="server" ></asp:TextBox>
            </div>
            <label style="padding-left: 88px; width: 133px;">
                CST No:</label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtCst" ReadOnly="true" runat="server"></asp:TextBox>
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="fix">
        </div>
        
         <div class="rowElem noborder">
            <label>
                Is Approved:<span class="req">*</span></label>
            <div class="formLeft" style="width: 250px">
                <asp:CheckBox runat="server" ID="chkIsActive"/>                
                <div class="fix">
                *By Unchecking this option,you can block the User from accesing the Web Site
                </div>
            </div>
        </div>
        <div class="submitForm" style="width: 100%">
            <div style="float: right">
                <asp:Button ID="btnSubmit" runat="server" Text="Update" CssClass="redBtn"
                    OnClick="btnSubmit_Click" />
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
            <h5 class="iFrames">All Record
            </h5>
        </div>
        <asp:Repeater ID="rptr" runat="server" OnItemCommand="rptr_ItemCommand">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" border="0" id="Column1" class="display">
                    <thead>
                        <tr>
                            <th align="left">Member Name
                            </th>
                            <th align="left">Email
                            </th>
                            <th align="left">Password
                            </th>
                            <th align="left">Company
                            </th>
                            <th align="left">Contact
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
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEamil" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text='<%#Eval("Password")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblCompany" runat="server" Text='<%#Eval("Company")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblContact" runat="server" Text='<%#Eval("Contact")%>'></asp:Label>
                    </td>
                    <td class="center">
                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("MemberId") %>'
                            CommandName="EditGroup" Text="Edit" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
