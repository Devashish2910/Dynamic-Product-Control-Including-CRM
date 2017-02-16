<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdvImageMap.aspx.cs" Inherits="Admin_AdvImageMap"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $("#form1").validate();
    </script>
    <script type="text/javascript" src="../ImageMap/jquery.maphilight.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.mapHiLight').maphilight({ stroke: true, fillColor: 'F8FBF8', fillOpacity: 0.2 });
        });
    </script>
    <script type="text/javascript">
        function FindPosition(oElement) {
            if (typeof (oElement.offsetParent) != "undefined") {
                for (var posX = 0, posY = 0; oElement; oElement = oElement.offsetParent) {
                    posX += oElement.offsetLeft;
                    posY += oElement.offsetTop;
                }
                return [posX, posY];
            }
            else {
                return [oElement.x, oElement.y];
            }
        }
        function GetCoordinates(e) {
            var PosX = 0;
            var PosY = 0;
            var ImgPos;
            ImgPos = FindPosition(myImg);
            if (!e) var e = window.event;
            if (e.pageX || e.pageY) {
                PosX = e.pageX;
                PosY = e.pageY;
            }
            else if (e.clientX || e.clientY) {
                PosX = e.clientX + document.body.scrollLeft
                  + document.documentElement.scrollLeft;
                PosY = e.clientY + document.body.scrollTop
                  + document.documentElement.scrollTop;
            }
            PosX = PosX - ImgPos[0];
            PosY = PosY - ImgPos[1];
            var a = document.getElementById("x").innerHTML = PosX;
            var b = document.getElementById("y").innerHTML = PosY;

            document.getElementById("<%=lblleft.ClientID%>").value = a;
            document.getElementById("<%=lbltop.ClientID%>").value = b;
        }
    </script>
    <script type="text/javascript">
        function Coordinate() {
            var a = document.getElementById("x").innerHTML;
            var b = document.getElementById("y").innerHTML;

            if (document.getElementById("<%=txtLeft.ClientID%>").value == "" && document.getElementById("<%=txtTop.ClientID%>").value == "") {
                document.getElementById("<%=txtLeft.ClientID%>").value = a;
                document.getElementById("<%=txtTop.ClientID%>").value = b;
            }
            else {
                document.getElementById("<%=txtRight.ClientID%>").value = a;
                document.getElementById("<%=txtBottom.ClientID%>").value = b;
            }
        }
    </script>
    <div class="widget">
        <div class="head">
            <h5 class="iList">
                <asp:Label runat="server" ID="lblSubCatName"></asp:Label>
            </h5>
        </div>
        <div class="rowElem noborder">
            <div class="formLeft">
                <asp:ImageMap ID="mapAreas" runat="server" BorderStyle="Dotted" BorderColor="BlueViolet"
                    BorderWidth="1px" CssClass="mapHiLight" HotSpotMode="Navigate">
                </asp:ImageMap>
                <script type="text/javascript">
                    var myImg = document.getElementById("<%=mapAreas.ClientID%>");
                    myImg.onmousedown = GetCoordinates;
                </script>
            </div>
            <div class="rowElem noborder">
                <span id="x" style="color: White;"></span><span id="y" style="color: White;"></span>
                <label style="width: 133px;">
                    X Co-Ordinate :
                </label>
                <div class="formLeft" style="width: 220px">
                    <asp:TextBox ID="lblleft" runat="server" Enabled="false" Width="200px"></asp:TextBox>
                </div>
                <label style="width: 133px;">
                    Y Co-Ordinate :
                </label>
                <div class="formLeft" style="width: 220px">
                    <asp:TextBox ID="lbltop" runat="server" Enabled="false" Width="200px"></asp:TextBox>
                </div>
                <div class="formLeft" style="width: 100px">
                    <%--<asp:Button ID="btnConfirm" runat="server" Text="Confirm" CssClass="redBtn" OnClientClick="javascript:Coordinate();" />--%>
                    <input type="button" onclick="Coordinate();" value="Confirm" class="redBtn" />
                </div>
            </div>
            <div class="rowElem noborder">
                <label style="width: 36px;">
                    Left :
                </label>
                <div class="formLeft" style="width: 150px">
                    <asp:TextBox ID="txtLeft" runat="server" Width="110px"></asp:TextBox>
                </div>
                <label style="width: 36px;">
                    Top :
                </label>
                <div class="formLeft" style="width: 150px">
                    <asp:TextBox ID="txtTop" runat="server" Width="110px"></asp:TextBox>
                </div>
                <label style="width: 36px;">
                    Right :
                </label>
                <div class="formLeft" style="width: 150px">
                    <asp:TextBox ID="txtRight" runat="server" Width="110px"></asp:TextBox>
                </div>
                <label style="width: 46px;">
                    Bottom :
                </label>
                <div class="formLeft" style="width: 150px">
                    <asp:TextBox ID="txtBottom" runat="server" Width="110px"></asp:TextBox>
                </div>
            </div>
            <div class="rowElem noborder">
                <label style="width: 133px;">
                    Select Product:<span class="req">*</span></label>
                <div class="formLeft" style="width: 400px">
                    <asp:RadioButtonList runat="server" ID="rdbOption" AutoPostBack="true" OnSelectedIndexChanged="rdbOption_OnSelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">Link to Product</asp:ListItem>
                        <asp:ListItem Value="1">Link to Other Website</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="rowElem noborder">
                <asp:Panel runat="server" ID="pnlProd">
                    <label style="width: 133px;">
                        Select Product:<span class="req">*</span></label>
                    <div class="formLeft" style="width: 400px">
                        <asp:DropDownList ID="ddlProduct" runat="server" Width="300px">
                        </asp:DropDownList>
                    </div>
                </asp:Panel>
                 <asp:Panel runat="server" ID="pnlOther" Visible="false">
                    <label style="width: 133px;">
                        Enter Url:<span class="req">*</span></label>
                    <div class="formLeft" style="width: 400px">
                      <asp:TextBox runat="server" ID="txtUrl" Width="300px"></asp:TextBox>
                    </div>
                </asp:Panel>
                <div class="formLeft" style="width: 200px">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="redBtn" OnClick="btnSubmit_Click" />&nbsp;
                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="redBtn" OnClick="btnReset_Click" />&nbsp;
                    <br />
                    <asp:Label ID="lblMsg" runat="server" Text="" CssClass="txtError"></asp:Label>
                </div>
            </div>
            <div class="fix">
            </div>
        </div>
        <%--<div class="submitForm" style="width: 100%">
            <div style="float: right">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="redBtn" OnClick="btnSubmit_Click" />
            </div>
            <div style="float: right; padding-top: 5px; padding-right: 10px;">
                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="txtError"></asp:Label>
            </div>
        </div>--%>
        <div class="fix">
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
                <table cellpadding="0" cellspacing="0" border="0" id="Column2" class="display">
                    <thead>
                        <tr>
                            <th align="left">
                                Left
                            </th>
                            <th align="left">
                                Top
                            </th>
                            <th align="left">
                                Right
                            </th>
                            <th align="left">
                                Bottom
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
                        <asp:Label ID="lblleft" runat="server" Text='<%# Bind("left_co") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbltop" runat="server" Text='<%# Bind("top_co") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblright" runat="server" Text='<%# Bind("right_co") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblbottom" runat="server" Text='<%# Bind("bottom_co") %>'></asp:Label>
                    </td>
                    <td class="center">
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
