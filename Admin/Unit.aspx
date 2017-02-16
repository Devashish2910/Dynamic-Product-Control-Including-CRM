<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Unit.aspx.cs" Inherits="Admin_Unit" %>

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
                Unit<span class="req">*</span></label>
            <div class="formLeft">
                <asp:TextBox ID="txtUnit" runat="server" CssClass="required" Width="100px"></asp:TextBox>
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
                                Unit
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
                        <asp:Label ID="lblCategoryName" runat="server" Text='<%#Eval("Unit")%>'></asp:Label>
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
