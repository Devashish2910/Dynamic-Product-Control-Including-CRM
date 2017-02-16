<%@ Page  Title="Best Admin" ValidateRequest="false" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="TermsAndConditions.aspx.cs" Inherits="Admin_TermsAndConditions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Style/ftb.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $("#form1").validate({
            rules: {
                ctl00$ContentPlaceHolder1$ddlCategory: "required"
            }

        });
    </script>
    <div class="widget">
        <div class="head">
            <h5 class="iList">
                Terms And Conditions
            </h5>
        </div>
        <div class="rowElem noborder">
            <label>
                Description:
            </label>
           
                <FTB:FreeTextBox ID="txtDescription" BreakMode="LineBreak" ToolbarLayout="Bold,Italic,Underline,Superscript,Subscript;FontFacesMenu,FontSizesMenu,SymbolsMenu,FontBackColorsMenu|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;Cut,Copy,Paste,Delete;InsertDate,InsertTime,InsertTable"
                    runat="Server" Focus="False" AutoGenerateToolbarsFromString="True" Height="300px"
                    ImageGalleryPath="../GeneralImages" Width="950px" ButtonSet="OfficeXP" RenderMode="NotSet"
                    UpdateToolbar="True" UseToolbarBackGroundImage="True" RemoveServerNameFromUrls="false">
                </FTB:FreeTextBox>
                <div class="fix">
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
    <div style="width: 100%; text-align: center; padding-top: 10px;">
        <asp:Label ID="lblDeleteMsg" runat="server" Text="" CssClass="txtError"></asp:Label>
    </div>
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
                                Terms And Conditions
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
                        <asp:Label ID="lblTermsNConditionsid" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                    </td>
                    <%-- <td>
                        <asp:Label ID="lblsubCategoryName" runat="server" Text='<%#Eval("SubCategoryName")%>'></asp:Label>
                    </td>--%>
                    <td class="center">
                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Id") %>'
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
