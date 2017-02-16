<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="PincodeChecker.aspx.cs" Inherits="Admin_PincodeChecker" %>

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
                Add Record
            </h5>
        </div>
        <div class="rowElem noborder">
            <label>
                City:<span class="req">*</span></label>
            <div class="formLeft">
                <asp:TextBox ID="txtCity" runat="server" CssClass="required" Width="40%"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regexpName" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtCity"     
                                    ValidationExpression="^[a-zA-Z]*$" />
            </div>
            <div class="fix">
            </div>
            <label>
                Zone:<span class="req">*</span></label>
            <div class="formLeft">
                <%--<asp:TextBox ID="txtZone" runat="server" CssClass="required" Width="30%"></asp:TextBox>--%>
                <asp:DropDownList ID="drpZone" runat="server" CssClass="required selector" Width="150px">
                    <asp:ListItem Selected="True">-Select Zone -</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                    <asp:ListItem>E</asp:ListItem>
                    <asp:ListItem>W</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                    <asp:ListItem>S</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="fix">
            </div>
            <label>
                District:<span class="req">*</span></label>
            <div class="formLeft">
                <asp:TextBox ID="txtDistrict" runat="server" CssClass="required" Width="40%"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtDistrict"     
                                    ValidationExpression="^[a-zA-Z]*$" />
            </div>
            <div class="fix">
            </div>
            <label>
                Pincode:<span class="req">*</span></label>
            <div class="formLeft">
                <asp:TextBox ID="txtpincode" runat="server" CssClass="required" Width="40%" placeholder="6 Digit Postal Code"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtpincode"     
                                    ValidationExpression="^[0-9]{6}$" />
            </div>
            <div class="fix">
            </div>
            <label>
                IsODA:<span class="req">*</span></label>
            <div class="formLeft">
                <asp:DropDownList ID="drpoda" runat="server" CssClass="required selector" Width="150px">
                    <asp:ListItem Selected="True">-Select ODA -</asp:ListItem>
                    <asp:ListItem>Y</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="TextBox3" runat="server" CssClass="required" Width="30%"></asp:TextBox>--%>
            </div>
            <div class="fix">
            </div>
            <label>
                State Code:<span class="req">*</span></label>
            <div class="formLeft">
                <asp:TextBox ID="txtStateCode" runat="server" CssClass="required" Width="40%" placeholder="Code For a Satae. Eg:GJ,MH"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value." 
                                    ControlToValidate="txtCity"     
                                    ValidationExpression="^[a-zA-Z0-9]{5}$" />
            </div>
            <div class="fix">
            </div>
            <label>
                Is Active:<span class="req">*</span></label>
            <div class="formLeft" style="width: 250px">
                <asp:CheckBox runat="server" ID="chkIsActive" Checked="true" />
                <div class="fix">
                </div>
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
                                City
                            </th>
                            <th align="left">
                                Zone
                            </th>
                            <th align="left">
                                District
                            </th>
                            <th align="left">
                                Pincode
                            </th>
                            <th align="left">
                                IsODA
                            </th>
                            <th align="left">
                                State Code
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
                        <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblZone" runat="server" Text='<%#Eval("Zone")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDistrict" runat="server" Text='<%#Eval("District")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblPinCode" runat="server" Text='<%#Eval("Pincode")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblODA" runat="server" Text='<%#Eval("IsODA")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStateCode" runat="server" Text='<%#Eval("Statecode")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" ID="lnkSpYes" Enabled='<%# !Convert.ToBoolean(Eval("IsActive")) %>'
                            Text="Yes" CommandName="InUseYes" CommandArgument='<%# Eval("Id") %>' Style="text-decoration: underline;"></asp:LinkButton>&nbsp;|&nbsp;
                        <asp:LinkButton runat="server" ID="lnkSpNo" Enabled='<%#Eval("IsActive") %>' Text="No"
                            CommandName="InUseNo" CommandArgument='<%# Eval("Id") %>' Style="text-decoration: underline;"></asp:LinkButton>
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
</asp:Content>
