<%@ Page Title="Best Admin" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script type="text/javascript">
     $("#form1").validate({
         rules: {
         ctl00$ContentPlaceHolder1$txtOldPwd: {
                 minlength: 4, // will count space 
                 maxlength: 20
             },
             ctl00$ContentPlaceHolder1$txtNewPwd: {
                 minlength: 4, // will count space 
                 maxlength: 20
             },
             ctl00$ContentPlaceHolder1$txtConfirmPwd: {
                 minlength: 4, // will count space 
                 maxlength: 20,
                 equalTo: "#ContentPlaceHolder1_txtNewPwd"
             }
         }

     });
    </script>

    <div class="widget">
        <div class="head">
            <h5 class="iList">
                Change Password</h5>
        </div>
        <div class="rowElem">
            <label>
                Old Password :<span class="req">*</span></label>
            <div class="formRight">
          
                <asp:TextBox ID="txtOldPwd" placeholder="Enter Your Older Password That You Want To Change" runat="server" CssClass="required" TextMode="Password"></asp:TextBox><br /><br />
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="rowElem">
            <label>
                New Password :<span class="req">*</span></label>
            <div class="formRight">
                <asp:TextBox ID="txtNewPwd" placeholder="Enter Your New Password.Must be between 6 to 20 Characters" TextMode="Password" runat="server" CssClass="required"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"     
                                    ErrorMessage="<br>*Enter the Correct Value between 6 to 20 Characters." 
                                    ControlToValidate="txtNewPwd"     
                                    ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,20}$" />
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="rowElem">
            <label>
                Confirm Password :<span class="req">*</span></label>
            <div class="formRight">
                <asp:TextBox ID="txtConfirmPwd" placeholder="Must Be Same As Your New Password" runat="server" CssClass="required" TextMode="Password"></asp:TextBox><br />
                <div class="fix">
                </div>
            </div>
        </div>
        <div class="submitForm" style="width: 100%">
            <div style="float: right">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="redBtn" 
                    onclick="btnSubmit_Click" />
            </div>
            <div style="float: right; padding-top: 5px; padding-right: 10px;">
                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="txtError"></asp:Label></div>
        </div>
        <div class="fix">
        </div>
    </div>
</asp:Content>

