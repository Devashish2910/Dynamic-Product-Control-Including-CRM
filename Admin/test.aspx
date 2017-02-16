<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="Admin_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css" title="currentStyle">
        @import "media/header.ccss";
        @import "media/demo_table.css";
        @import "media/TableTools.css";
    </style>
    <script type="text/javascript" charset="utf-8" src="media/jquery.js"></script>
    <script type="text/javascript" charset="utf-8" src="media/jquery.dataTables.js"></script>
    <script type="text/javascript" charset="utf-8" src="media/ZeroClipboard.js"></script>
    <script type="text/javascript" charset="utf-8" src="media/TableTools.js"></script>
    <script type="text/javascript" charset="utf-8">
        $(document).ready(function () {
            $('#Column101').dataTable({
                "sDom": 'T<"clear">lfrtip'
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="table">
            <div class="head">
                <h5 class="iFrames">
                    All Record
                </h5>
            </div>
            <asp:Repeater ID="rptr" runat="server">
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" border="0" id="Column101" class="display">
                        <thead>
                            <tr>
                                <th align="left">
                                    Brand Name
                                </th>
                                <th align="left">
                                    Logo
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
                            <asp:Label ID="lblCategoryName" runat="server" Text='<%#Eval("BrandName")%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" ImageUrl='<%#"../" + Eval("Image") %>'
                                CssClass="img100" />
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
    </div>
    </form>
</body>
</html>
