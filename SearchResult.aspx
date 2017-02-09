<%@ Page Language="C#" MasterPageFile="~/ClientMaster.master" AutoEventWireup="true"
    CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container make-bg">
        <ul class="breadcrumb">
            <li><a href="Default.aspx">Home</a> <span class="divider">/</span></li>
            <li class="active">Search Result</li>
        </ul>
        <div class="row">
            <div class="span12 post">
                <h2 class="page-header">
                    <span>Search Result for
                        <asp:Label runat="server" ID="lblSearch" CssClass="fontdarkgrey"></asp:Label></span></h2>
                <div class="sidebar-line">
                    <span></span>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <section id="wrap-cat">
                            <header class="wrap-header">
                                <div class="display">
                                    <b>Display:</b>
                                    <%--   <a href="category-list.html" class="list list-icon" data-toggle="tooltip" data-placement="top" data-original-title="View List Style">List View</a>
                                    <a href="category-grid.html" class="grid grid-icon" data-toggle="tooltip" data-placement="top" data-original-title="View Grid Style">Grid View</a>--%>
                                    <asp:LinkButton runat="server" ID="lnkGrid" ToolTip="View Grid Style" CssClass="grid grid-icon" OnClick="lnkGrid_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lnkList" ToolTip="View List Style" CssClass="list list-icon" OnClick="lnkList_Click"></asp:LinkButton>
                                </div>
                                <%--  <div class="color">
                            <b>Color:</b>
                            <select>
                                <option value="blue" selected="selected">Blue</option>
                                <option value="red">Red</option>
                                <option value="green">Green</option>
                                <option value="orange">Orange</option>
                                <option value="magenta">Magenta</option>
                            </select>
                        </div>--%>

                                <div class="limit">
                                    <b>Show:</b>
                                    <asp:DropDownList runat="server" ID="drpPageSize" AutoPostBack="true" OnSelectedIndexChanged="drpPageSize_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="2">12</asp:ListItem>
                                        <asp:ListItem Value="4">24</asp:ListItem>
                                        <asp:ListItem Value="6">36</asp:ListItem>
                                        <asp:ListItem Value="8">48</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="sort">
                                    <b>Sort:</b>
                                    <asp:DropDownList runat="server" ID="drpSort" AutoPostBack="true" OnSelectedIndexChanged="drpSort_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Price (Low &gt; High)</asp:ListItem>
                                        <asp:ListItem Value="2">Price (High &gt; Low)</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="3">Name (A - Z)</asp:ListItem>
                                        <asp:ListItem Value="4">Name (Z - A)</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </header>
                        </section>
                    </div>
                </div>
                <div class="clearfix">
                </div>
                <asp:Repeater runat="server" ID="rptrProduct">
                    <ItemTemplate>
                        <div class="row-fluid prodres">
                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id1").ToString()=="") ? "displaynone": "span2"%>">
                                <div class="wdt-product active">
                                    <div class="wdt-products-wrapper">
                                        <div class="wdt-product active show">
                                            <a href="ProductDetail.aspx?pid=<%# Eval("id1") %>" title="<%# Eval("ProductName11") %>">
                                                <img src="<%# Eval("Image1") %>" alt="<%# Eval("ProductName1") %>">
                                            </a>
                                            <div class="txtcenter">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id1") %>" class="fntgry" title="<%# Eval("ProductName11") %>">
                                                    <%# Eval("ProductCode1") %></a>
                                            </div>
                                            <h4 class="minhght90">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id1") %>" title="<%# Eval("ProductName11") %>">
                                                    <%# Eval("ProductName1") %></a></h4>
                                            <div class="clear">
                                            </div>
                                            <div class="txtcenter">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id1") %>" title="<%# Eval("ProductName11") %>"
                                                    class="fnt16">Rs.<%#  Math.Round(Convert.ToDouble(Eval("FinalSellingPrice1"))) %><span
                                                        class="pack">per pack</span> </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id2").ToString()=="") ? "displaynone": "span2"%>">
                                <div class="wdt-product active">
                                    <div class="wdt-products-wrapper">
                                        <div class="wdt-product active show">
                                            <a href="ProductDetail.aspx?pid=<%# Eval("id2") %>" title="<%# Eval("ProductName22") %>">
                                                <img src="<%# Eval("Image2") %>" alt="<%# Eval("ProductName2") %>">
                                            </a>
                                            <div class="txtcenter">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id2") %>" class="fntgry" title="<%# Eval("ProductName22") %>">
                                                    <%#Eval("ProductCode2") %></a>
                                            </div>
                                            <h4 class="minhght90">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id2") %>" title="<%# Eval("ProductName22") %>">
                                                    <%# Eval("ProductName2") %></a></h4>
                                            <div class="clear">
                                            </div>
                                            <div class="txtcenter">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id2") %>" title="<%# Eval("ProductName22") %>"
                                                    class="fnt16">Rs.<%#  Math.Round(Convert.ToDouble(Eval("FinalSellingPrice2"))) %><span
                                                        class="pack">per pack</span></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id3").ToString()=="") ? "displaynone": "span2"%>">
                                <div class="wdt-product active">
                                    <div class="wdt-products-wrapper">
                                        <div class="wdt-product active show">
                                            <a href="ProductDetail.aspx?pid=<%# Eval("id3") %>" title="<%# Eval("ProductName33") %>">
                                                <img src="<%# Eval("Image3") %>" alt="<%# Eval("ProductName3") %>">
                                            </a>
                                            <div class="txtcenter">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id3") %>" class="fntgry" title="<%# Eval("ProductName33") %>">
                                                    <%#Eval("ProductCode3") %></a>
                                            </div>
                                            <h4 class="minhght90">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id3") %>" title="<%# Eval("ProductName33") %>">
                                                    <%# Eval("ProductName3") %></a></h4>
                                            <div class="clear">
                                            </div>
                                            <div class="txtcenter">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id3") %>" title="<%# Eval("ProductName33") %>"
                                                    class="fnt16">Rs.<%#  Math.Round(Convert.ToDouble(Eval("FinalSellingPrice3"))) %><span
                                                        class="pack">per pack</span></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id4").ToString()=="") ? "displaynone": "span2"%>">
                                <div class="wdt-product active">
                                    <div class="wdt-products-wrapper">
                                        <div class="wdt-product active show">
                                            <a href="ProductDetail.aspx?pid=<%# Eval("id4") %>" title="<%# Eval("ProductName44") %>">
                                                <img src="<%#Eval("Image4") %>" alt="<%# Eval("ProductName4") %>">
                                            </a>
                                            <div class="txtcenter ">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id4") %>" class="fntgry" title="<%# Eval("ProductName44") %>">
                                                    <%# Eval("ProductCode4") %></a>
                                            </div>
                                            <h4 class="minhght90">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id4") %>" title="<%# Eval("ProductName44") %>">
                                                    <%# Eval("ProductName4") %></a></h4>
                                            <div class="clear">
                                            </div>
                                            <div class="txtcenter">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id4") %>" title="<%# Eval("ProductName44") %>"
                                                    class="fnt16">Rs.<%#  Math.Round(Convert.ToDouble(Eval("FinalSellingPrice4"))) %><span
                                                        class="pack">per pack</span></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id5").ToString()=="") ? "displaynone": "span2"%>">
                                <div class="wdt-product active">
                                    <div class="wdt-products-wrapper">
                                        <div class="wdt-product active show">
                                            <a href="ProductDetail.aspx?pid=<%# Eval("id5") %>" title="<%# Eval("ProductName55") %>">
                                                <img src="<%#Eval("Image5") %>" alt="<%# Eval("ProductName5") %>">
                                            </a>
                                            <div class="txtcenter ">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id5") %>" class="fntgry" title="<%# Eval("ProductName55") %>">
                                                    <%# Eval("ProductCode5") %></a>
                                            </div>
                                            <h4 class="minhght90">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id5") %>" title="<%# Eval("ProductName55") %>">
                                                    <%# Eval("ProductName5") %></a></h4>
                                            <div class="clear">
                                            </div>
                                            <div class="txtcenter">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id5") %>" title="<%# Eval("ProductName55") %>"
                                                    class="fnt16">Rs.<%#  Math.Round(Convert.ToDouble(Eval("FinalSellingPrice5"))) %><span
                                                        class="pack">per pack</span></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="<%#(DataBinder.Eval(Container.DataItem,"id6").ToString()=="") ? "displaynone": "span2"%>">
                                <div class="wdt-product active">
                                    <div class="wdt-products-wrapper">
                                        <div class="wdt-product active show">
                                            <a href="ProductDetail.aspx?pid=<%# Eval("id6") %>" title="<%# Eval("ProductName66") %>">
                                                <img src="<%#Eval("Image6") %>" alt="<%# Eval("ProductName6") %>">
                                            </a>
                                            <div class="txtcenter ">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id6") %>" class="fntgry" title="<%# Eval("ProductName66") %>">
                                                    <%# Eval("ProductCode6") %></a>
                                            </div>
                                            <h4 class="minhght90">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id6") %>" title="<%# Eval("ProductName66") %>">
                                                    <%# Eval("ProductName6") %></a></h4>
                                            <div class="clear">
                                            </div>
                                            <div class="txtcenter">
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id6") %>" title="<%# Eval("ProductName66") %>"
                                                    class="fnt16">Rs.<%#  Math.Round(Convert.ToDouble(Eval("FinalSellingPrice6"))) %><span
                                                        class="pack">per pack</span></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater runat="server" ID="rptrProductList">
                    <ItemTemplate>
                        <div class="row-fluid">
                            <div class="span2">
                                <div class="wdt-product active" data-stop="0">
                                    <div class="wdt-products-wrapper">
                                        <div class="wdt-product active show">
                                            <a href="ProductDetail.aspx?pid=<%# Eval("id") %>" title="<%# Eval("ProductName") %>">
                                                <img src="<%# Eval("Image") %>" alt="<%# Eval("pname") %>">
                                            </a>&nbsp;<h4>
                                                <a href="ProductDetail.aspx?pid=<%# Eval("id") %>" title="<%# Eval("ProductName") %>">
                                                    <%# Eval("pname") %></a></h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="span10 grid-desc">
                                <div class="grid-title-header">
                                    <a href="ProductDetail.aspx?pid=<%# Eval("id") %>" title="<%# Eval("ProductName") %>">
                                        <h4>
                                            <%# Eval("pname") %></h4>
                                    </a>
                                </div>
                                <%--  <p>
                            <asp:Literal runat="server" ID="lnkDesc" Text='<%# Eval("Description") %>'></asp:Literal>
                        </p>--%>
                                <div class="">
                                    <a href="ProductDetail.aspx?pid=<%# Eval("id") %>" class="fntgry" title="<%# Eval("ProductName") %>">
                                        <%# Eval("ProductCode") %></a>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="">
                                    <a href="ProductDetail.aspx?pid=<%# Eval("id") %>" title="<%# Eval("ProductName") %>"
                                        class="fnt16">Rs.<%#  Math.Round(Convert.ToDouble(Eval("FinalSellingPrice"))) %><span
                                            class="pack">per pack</span></a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="pagination pagination-left">
                    <ul>
                        <li>
                            <asp:LinkButton ID="lbtnPrevious" runat="server" CausesValidation="false" OnClick="lbtnPrevious_Click">«</asp:LinkButton>
                        </li>
                        <asp:Repeater ID="dlPaging" runat="server" OnItemCommand="dlPaging_ItemCommand" OnItemDataBound="dlPaging_ItemDataBound">
                            <ItemTemplate>
                                <li runat="server" id="liparent">
                                    <asp:LinkButton ID="lnkbtnPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>'
                                        CommandName="Paging" Text='<%# Eval("PageText") %>'></asp:LinkButton>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%--<li class="active"><a href="#">1</a></li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">5</a></li>--%>
                        <li>
                            <asp:LinkButton ID="lbtnNext" runat="server" CausesValidation="false" OnClick="lbtnNext_Click">»</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="Server">
</asp:Content>
