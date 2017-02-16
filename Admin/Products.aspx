<%@ Page  Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Products.aspx.cs" Inherits="Admin_SubCategory" MaintainScrollPositionOnPostback="true" %>


<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <style type="text/css">
       a.aspNetDisabled
        {
            color: #393939 !important;
            text-decoration: none !important;
        }
    </style>
    <script type="text/javascript">
        function Calculate() {

            var txtProductcost = document.getElementById('<%=txtProductcost.ClientID %>').value;
            var txtmargin = document.getElementById('<%=txtmargin.ClientID %>').value;
            var txtsalescost = document.getElementById('<%=txtsalescost.ClientID %>').value;
            var txtfinalcost = document.getElementById('<%=txtfinalcost.ClientID %>').value;
            var txttax = document.getElementById('<%=txttax.ClientID %>').value;
            var txtProductweight = document.getElementById('<%=txtProductweight.ClientID %>').value;
            var txtSalesPriceIncl = document.getElementById('<%=txtSalesPriceIncl.ClientID %>').value;
            var txtshippingcost = document.getElementById('<%=txtshippingcost.ClientID %>').value;
            var txtDiscount = document.getElementById('<%=txtDiscount.ClientID %>').value;

            PageMethods.CalculateDiscount(txtProductcost, txtmargin, txtsalescost, txtfinalcost, txttax, txtProductweight, txtSalesPriceIncl, txtshippingcost, txtDiscount, onSucess, onError);


            function onSucess(result) {
                for (var i in result) {
                    document.getElementById('ContentPlaceHolder1_txtsalescost').value=result[0];
                    //document.getElementById('ContentPlaceHolder1_txtSalesPriceIncl').setAttribute("value", result[1]);
                    document.getElementById('ContentPlaceHolder1_txtSalesPriceIncl').value = result[1];
                    //document.getElementById('ContentPlaceHolder1_txtshippingcost').setAttribute("value", result[2]);
                    document.getElementById('ContentPlaceHolder1_txtshippingcost').value = result[2];
                   // document.getElementById('ContentPlaceHolder1_txttaxfinalprice').setAttribute("value", result[3]);
                    document.getElementById('ContentPlaceHolder1_txttaxfinalprice').value = result[3];
                    //document.getElementById('ContentPlaceHolder1_txtfinalcost').setAttribute("value", result[4]);
                    document.getElementById('ContentPlaceHolder1_txtfinalcost').value = result[4];
                }
              //  alert(result);
                // document.getElementById('ContentPlaceHolder1_txttaxfinalprice').value = taxfinalprice;
            }
            function onError(result) {
                //alert('Something wrong.');
            }
        }
    </script>
    <link href="../Style/ftb.css" rel="stylesheet" type="text/css" />
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
            <label style="width: 133px;">
                Select Category:<span class="req">*</span></label>
            <div class="formLeft" style="width: 200px">
                <asp:DropDownList ID="ddlCategory" runat="server" Width="194px" CssClass="required"
                    OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </div>
            <label style="padding-left: 88px; width: 200px;">
                Select SubCategory:<span class="req">*</span></label>
            <div class="formLeft" style="width: 200px">
                <asp:DropDownList ID="ddlSubCategory" runat="server" Width="194px" CssClass="required">
                </asp:DropDownList>
            </div>
            
            <label style="width: 133px;">
                Select Supplier:<span class="req">*</span></label>
            <div class="formLeft" style="width: 200px">
                <asp:DropDownList ID="ddlsupplier" runat="server" Width="194px" CssClass="required">
                </asp:DropDownList>
            </div>
            <label style="padding-left: 88px; width: 200px;">
                Select Brand:<span class="req">*</span></label>
            <div class="formLeft" style="width: 200px">
                <asp:DropDownList ID="ddlBrand" runat="server" Width="194px" CssClass="required">
                </asp:DropDownList>
            </div>
            <%--<div class="fix">
            </div>--%>
        </div>
        <div class="rowElem noborder">
            <label>
                KeyWords:<span class="req">*</span></label>
            <div class="formLeft" style="width: 700px">
                <asp:TextBox ID="txtkeywords" runat="server" placeholder="A word or set of words by which the product can be Searched(Partition it by ',')" CssClass="required" Width="100%"></asp:TextBox>
                 
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Upload Photo <span class="req">*</span><br />
                (W 356 * H 500) :
            </label>
            <div class="formLeft" style="width: 200px">
                <asp:FileUpload ID="fupPhoto" runat="server" CssClass="fileInput" />
                &nbsp;<asp:Image ID="imgPhoto" runat="server" CssClass="img100" Width="150px" Height="150px" />
                <asp:Label ID="lblPhoto2" runat="server" Text="" CssClass="txtError" Visible="true"></asp:Label>
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Product Name:<span class="req">*</span></label>
            <div class="formLeft" style="width: 250px">
                <asp:TextBox ID="txtProductname" runat="server" CssClass="required" Width="100%"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtProductname"
        ErrorMessage="Enter A Valid Product Name" ValidationExpression="^[a-zA-Z0-9 -]*$"></asp:RegularExpressionValidator>
                <br />
                <br />
                <asp:TextBox ID="txtProductline2" runat="server" CssClass="" Width="100%"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtProductline2"
        ErrorMessage="Enter A Valid Product Name" ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Product Code:<span class="req">*</span></label>
            <div class="formLeft" style="width: 203px">
                <asp:TextBox ID="txtProductCode" runat="server" CssClass="required" Width="120px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtProductCode"
        ErrorMessage="Enter A Valid Product Code" ValidationExpression="^[a-zA-Z0-9 ]*$"></asp:RegularExpressionValidator>
            </div>
            <label style="padding-left: 88px; width: 203px;">
                Supplier Product Code:</label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtSupProductcode" runat="server" Width="120px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtSupProductcode"
        ErrorMessage="Enter A Valid Supplier Product Code" ValidationExpression="^[a-zA-Z0-9 ]*$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Minimum Ordering Quantity:
            </label>
            <div class="formLeft" style="width: 203px">
                <asp:TextBox ID="txtMinOrdrQty" runat="server" Width="50px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtMinOrdrQty"
        ErrorMessage="Enter A Valid Minimum Order Quantity" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
            </div>
            <label style="padding-left: 88px; width: 203px;">
                Pack Size:<span class="req">*</span></label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtpacksize" placeholder="Product in Each Pack" runat="server" CssClass="required" Width="130px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtpacksize"
        ErrorMessage="Enter A Valid Pack Size" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Is COD</label>
            <div class="formLeft" style="width: 200px">
                <asp:RadioButtonList ID="rbtCOD" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <label style="padding-left: 88px; width: 203px;">
                Shipping Days:
            </label>
            <div class="formLeft" style="width: 200px">
                <asp:TextBox ID="txtShippngDays" runat="server" Width="50px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtShippngDays"
        ErrorMessage="Enter A Valid Shipping Days" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Is New Arrival:
            </label>
            <div class="formLeft" style="width: 156px">
                <asp:RadioButtonList ID="rbtNewArriaval" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <label style="padding-left: 135px; width: 203px;">
                Is Special Offer:
            </label>
            <div class="formLeft" style="width: 200px">
                <asp:RadioButtonList ID="RbtSpecialOffer" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="fix">
        </div>
        <table>
     <tr>

        <td>
            <label style="width: -1px; padding: 13px 0px 13px 13px;">
             Unit:</label>
             <div class="formLeft" style="width: 100px;">
             <asp:DropDownList ID="ddlUnit" runat="server" Width="200px">
             </asp:DropDownList>
             </div>
        </td>

       <td></td>
         
        <td>
         <label style="width: 100px; padding: 13px 0px 13px 0px;">
          RAW Cost:<span class="req">*</span></label>
         <div class="formLeft" style="width: 70px">
         <asp:TextBox ID="txtProductcost" runat="server" placeholder="Basic Cost" CssClass="required" Width="100%" OnBlur="Calculate(); return false;"></asp:TextBox>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="txtProductcost"
        ErrorMessage="Enter A Valid Pack Size" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
         </div>
        </td>               
       
     </tr>
            <tr>
               <td></td>
                <td></td>
                <td>
                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                        Product Weight:                      
                    </label>
                    <div class="formLeft" style="width: 84px;">
                        <asp:TextBox ID="txtProductweight" runat="server" placeholder="In Gram" CssClass="required" Width="70%"
                            OnBlur="Calculate(); "></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtProductweight"
        ErrorMessage="Enter A Valid Value" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </div>
                </td>
            </tr>
            <tr>
       <td style="width: 600px;" colspan="2">
                    <label style="width: 131px; padding: 13px 0px 13px 11px;">
                        Size Option:&nbsp;<span class="req">*</span></label>
                    <div class="formLeft" style="width: 50%">
                        <asp:CheckBoxList ID="cblSizeoption" runat="server" RepeatDirection="Horizontal"
                            RepeatColumns="3">
                        </asp:CheckBoxList>
                    </div>
                </td>

                
                <td>
                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                        Shipping Cost:<span class="req">*</span>
                    </label>
                    <div class="formLeft" style="width: 100px">
                        <asp:TextBox ID="txtshippingcost" runat="server" placeholder="Delivery Charges" CssClass="required" Width="109%"> </asp:TextBox>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtshippingcost"
        ErrorMessage="Enter A Valid Values" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </div>
                </td>
                
            </tr>
            <tr>
                <td style="width: 600px;" colspan="2">
                    <label style="width: 131px; padding: 13px 0px 13px 11px;">
                        Colour Option:&nbsp;<span class="req">*</span></label>
                    <div class="formLeft" style="width: 50%">
                        <asp:CheckBoxList ID="cblColouroption" runat="server" RepeatDirection="Horizontal"
                            RepeatColumns="3">
                        </asp:CheckBoxList>
                    </div>
                </td>
                <td>
                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                        Margin(%):<span class="req">*</span>
                    </label>
                    <div class="formLeft" style="width: 100px">
                        <asp:TextBox ID="txtmargin" runat="server" CssClass="required" Width="50%" onBlur="Calculate();"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtmargin"
        ErrorMessage="Enter A Valid Values" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </div>
                </td>
                
                
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                        Product Cost:
                    </label>
                    <div class="formLeft" style="width: 120px">
                        <asp:TextBox ID="txtsalescost" runat="server" placeholder="RAW Cost + Margin" CssClass="required" Width="100%" OnBlur="Calculate(); return false;"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtsalescost"
        ErrorMessage="Enter A Valid Values" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </div>
                </td>
                
            </tr>
            <tr>
                <td style="width: 400px;">
                </td>
                <td>
                </td>
                <td>
                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                        Tax(%):<span class="req">*</span>
                    </label>
                    <div class="formLeft" style="width: 100px">
                        <asp:TextBox ID="txttax" runat="server" CssClass="required" Width="50%" OnBlur="Calculate(); "></asp:TextBox>
                        <%-- <label>
                        (Incl Tax)
                    </label>--%>
                    </div>
                    <%--<div class="fix">
                    </div>--%>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <label style="width: 100px; padding: 0px 0px 13px 0px;">
                      <br />  Market Cost:
                    </label>
                    <div class="formLeft" style="width: 100px">
                        <asp:TextBox ID="txtSalesPriceIncl" runat="server" placeholder="Product Cost+TAX+Shipping" Width="170%" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtSalesPriceIncl"
        ErrorMessage="Enter A Valid Values" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td class="formLeft" style="width: 203px">
                </td>
                <td>
                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                        MRP:
                    </label>
                    <div class="formLeft" style="width: 100px">
                        <asp:TextBox ID="txtMRP" runat="server" TextMode="SingleLine" Width="50%"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                        Discount(%):<span class="req">*</span>
                    </label>
                    <div class="formLeft" style="width: 100px">
                        <asp:TextBox ID="txtDiscount" runat="server" CssClass="required" Width="50%" OnBlur="Calculate(); return false;"></asp:TextBox>
                        <asp:TextBox ID="txtCalDiscount" runat="server" CssClass="required" Width="66%"                            Visible="false"></asp:TextBox>
                    </div>
                </td>
            </tr>
            
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <label style="width: 100px; padding: 7px 0px 13px 0px;">
                        Final Selling Price:<span class="req">*</span>
                    </label>
                    <div class="formLeft" style="width: 100px">
                        <asp:TextBox ID="txtfinalcost" runat="server" CssClass="required" Width="50%" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtfinalcost"
        ErrorMessage="Enter A Valid Values" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <label style="width: 100px; padding: 13px 0px 13px 0px;">
                        Tax on Final Price:
                    </label>
                    <div class="formLeft" style="width: 100px">
                        <asp:TextBox ID="txttaxfinalprice" runat="server" Width="50%"   ></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <div class="fix">
        </div>
        <div class="rowElem">
            <label>
                Certification:
            </label>
            <div>
              <%--  <asp:TextBox ID="txtCertification" runat="server" TextMode="MultiLine" Style="margin: 0px;
                    height: 62px;"></asp:TextBox>--%>
                     <FTB:FreeTextBox ID="txtCertification" BreakMode="LineBreak" ToolbarLayout="Bold,Italic,Underline,Superscript,Subscript;    FontFacesMenu,   FontSizesMenu,  SymbolsMenu ,   FontForeColorsMenu|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;Cut,Copy,Paste,Delete;InsertDate,InsertTime,InsertTable"
                    runat="Server" Focus="False" AutoGenerateToolbarsFromString="True" Height="300px"
                    ImageGalleryPath="../GeneralImages" Width="950px" ButtonSet="OfficeXP" RenderMode="NotSet"
                    UpdateToolbar="True" UseToolbarBackGroundImage="True" RemoveServerNameFromUrls="false">
                </FTB:FreeTextBox>
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="rowElem noborder">
            <label>
                Description:</label>
            <div>
                <FTB:FreeTextBox ID="txtDescription" BreakMode="LineBreak" ToolbarLayout="Bold,Italic,Underline,Superscript,Subscript;FontFacesMenu,FontSizesMenu,SymbolsMenu;FontForeColorsMenu|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;Cut,Copy,Paste,Delete;InsertDate,InsertTime,InsertTable"
                    runat="Server" Focus="False" AutoGenerateToolbarsFromString="True" Height="300px"
                    ImageGalleryPath="../GeneralImages" Width="950px" ButtonSet="OfficeXP" RenderMode="NotSet"
                    UpdateToolbar="True" UseToolbarBackGroundImage="True" RemoveServerNameFromUrls="false">
                </FTB:FreeTextBox>
                <div class="fix">
                </div>
            </div>
        </div>
        <%--<div class="rowElem">
            <label>
                Description:
            </label>
            <div class="widget" style="margin-top: 0px;">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="wysiwyg" Rows="5" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>--%>
        <div class="fix">
        </div>
        <%--<div class="rowElem">
    </div>--%>
        <div class="submitForm" style="width: 100%">
        <br />
            <div style="float: right">
            
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="redBtn" OnClientClick="return Calculate();" OnClick="btnSubmit_Click" />
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
                <table cellpadding="0" cellspacing="0" border="0" id="Column4" class="display">
                    <thead>
                        <tr>
                            <th align="left">
                                Product Name
                            </th>
                            <th align="left">
                                Product Code
                            </th>
                            <%--<th align="left">Image
                            </th>--%>
                            <th align="left">
                                Cost
                            </th>
                            <th align="left">
                                Margin
                            </th>
                            <th align="left">
                                Price
                            </th>
                            <th align="left">
                                Dis
                            </th>
                            <th align="left">
                                Final Price
                            </th>
                            <th align="left">
                                Is Special
                            </th>
                            <th align="left">
                                Is New
                            </th>
                            <th align="left">
                                Is COD
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
                        <asp:Label ID="lblProductId" runat="server" Text='<%#Eval("ProductName")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblProductCode" runat="server" Text='<%#Eval("ProductCode")%>'></asp:Label>
                    </td>
                    <%-- <td>
                        <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" ImageUrl='<%# "../"+Eval("Image") %>'
                            CssClass="img100" />
                    </td>--%>
                    <td>
                        <asp:Label ID="lblProductCost" runat="server" Text='<%# Math.Round(Convert.ToDouble(Eval("ProductCost")))%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblMargin" runat="server" Text='<%#Eval("Margin")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSalePrice" runat="server" Text='<%#  Math.Round(Convert.ToDouble(Eval("SalePrice")))%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblFinalSellingPrice" runat="server" Text='<%# Math.Round(Convert.ToDouble(Eval("FinalSellingPrice")))%>'></asp:Label>
                    </td>
                    <td>
                        <%--<asp:CheckBox runat="server" ID="cbkSpecial" Checked='<%#Eval("IsSpecialOffer") %>'
                            OnCheckedChanged="cbkSpecial_CheckedChanged" ToolTip='<%# Eval("Id") %>' AutoPostBack="true" />--%>
                        <asp:LinkButton runat="server" ID="lnkSpYes" Enabled='<%# !Convert.ToBoolean(Eval("IsSpecialOffer")) %>'
                            Text="Yes" CommandName="SpYes" CommandArgument='<%# Eval("Id") %>' style="text-decoration:underline;"></asp:LinkButton>&nbsp;|&nbsp;
                        <asp:LinkButton runat="server" ID="lnkSpNo" Enabled='<%#Eval("IsSpecialOffer") %>'
                            Text="No" CommandName="SpNo" CommandArgument='<%# Eval("Id") %>' style="text-decoration:underline;"></asp:LinkButton>
                    </td>
                    <td>
                      <%--  <asp:CheckBox runat="server" ID="cbkNew" Checked='<%#Eval("IsNewArrival") %>' OnCheckedChanged="cbkNew_CheckedChanged"
                            ToolTip='<%# Eval("Id") %>' AutoPostBack="true" />--%>
                             <asp:LinkButton runat="server" ID="LinkButton1" Enabled='<%# !Convert.ToBoolean(Eval("IsNewArrival")) %>'
                            Text="Yes" CommandName="NewYes" CommandArgument='<%# Eval("Id") %>' style="text-decoration:underline;"></asp:LinkButton>&nbsp;|&nbsp;
                        <asp:LinkButton runat="server" ID="LinkButton2" Enabled='<%#Eval("IsNewArrival") %>'
                            Text="No" CommandName="NewNo" CommandArgument='<%# Eval("Id") %>' style="text-decoration:underline;"></asp:LinkButton>
                    </td>
                    <td>
                        <%--<asp:CheckBox runat="server" ID="cbkCOD" Checked='<%#Eval("ISCOD") %>' OnCheckedChanged="cbkCOD_CheckedChanged"
                            ToolTip='<%# Eval("Id") %>' AutoPostBack="true" />--%>
                             <asp:LinkButton runat="server" ID="LinkButton3" Enabled='<%# !Convert.ToBoolean(Eval("ISCOD")) %>'
                            Text="Yes" CommandName="CodYes" CommandArgument='<%# Eval("Id") %>' style="text-decoration:underline;"></asp:LinkButton>&nbsp;|&nbsp;
                        <asp:LinkButton runat="server" ID="LinkButton4" Enabled='<%#Eval("ISCOD") %>'
                            Text="No" CommandName="CodNo" CommandArgument='<%# Eval("Id") %>' style="text-decoration:underline;"></asp:LinkButton>
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
