<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="ColourSetup.aspx.cs" Inherits="Admin_ColourSetup" %>

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
            <label>
                Colour Name:<span class="req">*</span></label>
            <div class="formLeft">
                <asp:TextBox ID="txtcolourname" runat="server" CssClass="required" Width="30%"></asp:TextBox>
            </div>
            <div class="fix">
            </div>
        </div>
        <div class="rowElem">
            <label>
                Colour Code:<span class="req">*</span></label>
            <div class="formLeft">
                <%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </ajaxToolkit:ToolkitScriptManager>--%>

                <asp:TextBox ID="txtcolourcode" runat="server"
                    Width="200px" placeholder="Code of the Colour."></asp:TextBox>
                  
                <cc1:ColorPickerExtender ID="ColorPickerExtender1" runat="server" TargetControlID="txtcolourcode" />

               <%-- <asp:ColorPickerExtender ID="txtcolourcode_ColorPickerExtender" runat="server" 
                       Enabled="True" TargetControlID="txtcolourcode">
                </asp:ColorPickerExtender>--%>
                 
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
                <table cellpadding="0" cellspacing="0" border="0" id="Column2" class="display">
                    <thead>
                        <tr>
                            <th align="left">
                                Colour Name
                            </th>
                            <th align="left">
                                Colour Code
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
                        <asp:Label ID="lblColourname" runat="server" Text='<%#Eval("ColourName")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblColourcode" runat="server" Text='<%#Eval("ColourCode")%>'></asp:Label>
                    </td>
                    <td class="center">
                        <asp:LinkButton ID="lnkbtnEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ColourId") %>'
                            CommandName="EditGroup" Text="Edit" OnClientClick="javascript:window.scrollTo(150,0);"></asp:LinkButton>
                        |
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ColourId") %>'
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
    <%--<script src="JS/colorpicker.js" type="text/javascript"></script>
    <link href="CSS/colorpicker.css" rel="stylesheet" type="text/css" />--%>
    <script src="js/colorpicker.js" type="text/javascript"></script>
    <link href="css/colorpicker.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        jQuery(document).ready(function () {
            //            // binds form submission and fields to the validation engine
            //            ("#form1").validate();
            jQuery("#form1").validate();


            $('.colorpickerField1').ColorPicker({
                onSubmit: function (hsb, hex, rgb, el) {
                    $(el).val(hex);
                    $(el).ColorPickerHide();
                },
                onBeforeShow: function () {
                    $(this).ColorPickerSetColor(this.value);
                }
            })
.bind('keyup', function () {
    $(this).ColorPickerSetColor(this.value);
});
        });
    
    </script>
</asp:Content>
