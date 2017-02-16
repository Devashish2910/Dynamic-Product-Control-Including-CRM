<%@ Page Language="C#"  Title="Best Admin" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="PublishNewsletter.aspx.cs" Inherits="Admin_PublishNewsletter" %>

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
                Select Newsletter:<span class="req">*</span></label>
            <div class="formLeft">
                <asp:DropDownList ID="drpNewsletter" runat="server" CssClass="required selector"
                    Width="205px">
                </asp:DropDownList>
            </div>
            <div class="fix">
            </div>
        </div>
       
    <div class="submitForm" style="width: 100%">
        <div style="float: right">
            <asp:Button ID="btnSubmit" runat="server" Text="Publish Newsletter" CssClass="redBtn"
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
                                Sr No
                            </th>
                            <th align="left">
                                Name
                            </th>
                            <th align="left">
                                Email
                            </th>
                            <th align="center"  >
                                <asp:CheckBox runat="server" ID="chkAll" OnCheckedChanged="chkAll_OnCheckedChanged" AutoPostBack="true"/>
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
