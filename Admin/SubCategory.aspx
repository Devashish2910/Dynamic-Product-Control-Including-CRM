<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="SubCategory.aspx.cs" Inherits="Admin_SubCategory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $("#form1").validate();
    </script>
    <div class="widget">
        <div class="head">
            <h5 class="iList">Add Record</h5>
        </div>
        <div class="rowElem noborder">
            <label style="width:140px;">
                Select Category:<span class="req">*</span></label>
            <div class="formLeft">
                <asp:DropDownList ID="ddlCategory" runat="server" Width="202px" CssClass="required">
                </asp:DropDownList>
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="rowElem">
            <label style="width:140px;">
                Sub Category Name:<span class="req">*</span></label>
            <div class="formLeft">
                <asp:TextBox ID="txtSubCategoryName" runat="server" placeholder="Subcategory of the Product" CssClass="required"></asp:TextBox>
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="rowElem">
           <label style="width:140px;">
                Upload Photo <span class="req">*</span><br />
                (W 356 * H 500) :
            </label>
            <div class="formLeft">
                <asp:FileUpload ID="fupPhoto" runat="server" CssClass="fileInput" />
                &nbsp;<asp:Image ID="imgPhoto" runat="server" CssClass="img100" Width="150px" Height="150px" />
                <asp:Label ID="lblPhoto" runat="server" Text="" CssClass="txtError" Visible="true"></asp:Label>
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="rowElem">
            <label style="width:140px;">
                Upload Banner Photo <span class="req">*</span><br />
                (W 1170 * H 150) :
            </label>
            <div class="formLeft">
                <asp:FileUpload ID="fupBannerPhoto" runat="server" CssClass="fileInput" />
                &nbsp;<asp:Image ID="imgBannerPhoto" runat="server" CssClass="img100" Width="150px" Height="150px" />
                <asp:Label ID="lblPhotoBanner" runat="server" Text="" CssClass="txtError" Visible="true"></asp:Label>
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
                <table cellpadding="0" cellspacing="0" border="0" id="Column2" class="display">
                    <thead>
                        <tr>
                            <th align="left">Category Name
                            </th>
                            <th align="left">Sub Category Name
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
                        <asp:Label ID="lblProductCategoryId" runat="server" Text='<%#Eval("CategoryName")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblsubCategoryName" runat="server" Text='<%#Eval("SubCategoryName")%>'></asp:Label>
                    </td>
                    <td class="center">
                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Id") %>'
                            CommandName="EditGroup" Text="Edit" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                        |
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Id") %>'
                            CommandName="DeleteGroup" OnClientClick="javascript:return window.confirm('Are You Sure You Want To Delete?')"
                            Text="Delete"></asp:LinkButton>
                      <%--  |
                        <a href="SubCategoryImageMap.aspx?id=<%# Eval("Id") %>">Image Map</a>--%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
