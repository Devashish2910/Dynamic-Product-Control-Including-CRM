<%@ Page Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Afterlogin.aspx.cs" Inherits="Admin_Afterlogin" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="width: 100%; margin: 100px auto 300px auto; text-align: center;">

        <%--<h1>
           <img src="images/user-role-administrator-icon.png" alt="" />
           <img src="images/user-role-administrator-icon.png" alt="" 
                        style="height: 152px; width: 126px" /></h2>
            

        </h1>--%>
        
        <h1>
        
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                        </h1>

          
          
       <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
        Caption='<table border="1" width="100%" cellpadding="0" cellspacing="0" bgcolor="yellow"><tr><td>Grid Heading</td></tr></table>'
        CaptionAlign="Top">
        <Columns>
        <asp:BoundField HeaderText="SearchTag" DataField="SearchTag" SortExpression="SearchTag" />
        <asp:BoundField HeaderText="Frequence" DataField="Frequency" SortExpression="Frequency" />
        </Columns>
        </asp:GridView>--%>
      
       

    </div>
</asp:Content>
