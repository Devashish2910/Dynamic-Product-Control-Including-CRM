<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ManageAdvertisement.aspx.cs" Inherits="Admin_ManageAdvertisement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $("#form1").validate();
    </script>
    <div class="widget">
        <div class="head">
            <h5 class="iList">Add Record</h5>
        </div>
        <div class="rowElem">
            <label>
                Upload Photo <span class="req">*</span><br />
                (W 550 * H 350) :
            </label>
            <div class="formLeft">
                <asp:FileUpload ID="fupPhoto" runat="server" CssClass="fileInput" />
                &nbsp;<asp:Image ID="imgPhoto" runat="server" CssClass="img100" Width="250px" Height="150px" />
                <asp:Label ID="lblPhoto2" runat="server" Text="" CssClass="txtError" Visible="true"></asp:Label>
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="rowElem noborder" style="display: none">
            <label>
                Caption:<span class="req">*</span></label>
            <div class="formLeft">
                <asp:TextBox ID="txtCaption" runat="server" TextMode="MultiLine" CssClass="required" Width="250px" Text="test"></asp:TextBox>
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="rowElem noborder" style="display: none;">
            <label>
                Url:<span class="req">*</span></label>
            <div class="formLeft">
                <asp:TextBox ID="txtUrl" runat="server" CssClass="required" Width="200px" Text="#"></asp:TextBox>&nbsp;(e.g. http://www.dhitsolutions.com)
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="submitForm" style="width: 100%">
            <div style="float: right">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="redBtn" OnClick="btnSubmit_Click" />
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
                            <th align="left">Logo
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
                        <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" ImageUrl=' <%# "../"+ Eval("Image") %>'
                            CssClass="img100" />
                    </td>
                    <td class="center">
                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Id") %>'
                            CommandName="EditGroup" Text="Edit" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                        |
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Id") %>'
                            CommandName="DeleteGroup" OnClientClick="javascript:return window.confirm('Are You Sure You Want To Delete?')"
                            Text="Delete"></asp:LinkButton>
                           <%--  <a href="AdvImageMap.aspx?id=<%# Eval("Id") %>">Image Map</a>--%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

