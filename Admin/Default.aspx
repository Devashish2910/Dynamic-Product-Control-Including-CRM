<%@ Page  Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Panel</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <link href="CSS/main.css" rel="stylesheet" type="text/css" />
    <link href="CSS/AdminStyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JS/jquery.min.js"></script>
    <script type="text/javascript" src="JS/jquery.validate.js"></script>
    <script type="text/javascript" src="JS/jquery.validationEngine-en.js"></script>
    <script type="text/javascript" src="JS/jquery.validationEngine.js"></script>
</head>
<body class="BodyClass">
    <form id="form" runat="server">
        <div>
            <!-- Top navigation bar -->
        <!--    <div id="topNav">
                <div class="fixed">
                    <div class="wrapper">
                        <div class="backTo">
                            <a href="Default.aspx" title="">
                                <img src="images/mainWebsite.png" alt="" />
                                <span>Main website</span></a>
                        </div>
                        <div class="fix">
                        </div>
                    </div>
                </div>
            </div>--!>
            <!-- Login form area -->
            <div class="loginWrapper" align="left">
                <div class="loginLogo" style="left: 40px">
                    <img src="images/logo_new.jpg" />
                </div>
                <div class="loginPanel" position:"top">
                    <div class="head">
                        <h5 class="iUser">&nbsp;&nbsp;&nbsp;&nbsp;Login To Your Account</h5>
                        <script type="text/javascript">
                            jQuery(document).ready(function () {
                                // binds form submission and fields to the validation engine
                                jQuery("#form").validationEngine();
                            });
                        </script>
                    </div>
                    <div class="mainForm">
                        <div class="loginRow noborder">
                            <label for="req1" 
                                style="font-family: 'Times New Roman', Times, serif; font-size: large; text-decoration: none">
                                Username:</label>
                            <div class="loginInput">
                                <asp:TextBox ID="txtUsername" runat="server" class="validate[required] text-input" BorderWidth="3px" ></asp:TextBox>
                            </div>
                            <div class="fix">
                            </div>
                        </div>
                        <div class="loginRow">
                            <label for="req2" 
                                style="font-family: 'Times New Roman', Times, serif; font-size: large">
                                Password:</label>
                            <div class="loginInput">
                                <asp:TextBox ID="txtPassword" runat="server" class="validate[required] text-input"
                                    TextMode="Password" BackColor="White" BorderWidth="3px" 
                                    EnableTheming="True"></asp:TextBox>
                            </div>
                            <div class="fix">
                            </div>
                        </div>
                        
                        <div class="loginRow">
                       &nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click1">Forgot Password?</asp:LinkButton>

                       
                            <div style="float: right">
                                <asp:Button ID="btnSubmit" runat="server" Text="Log In" CssClass="greyishBtn submitForm"
                                    OnClick="btnSubmit_Click" />
                            </div>
                            <div style="float: right; padding-top: 5px; padding-left: 10px;">
                                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="txtError"></asp:Label>
                            </div>
                            <div class="fix">
                            </div>
                        </div>
                        
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                        
                        <div class="fix">
                        
                            <asp:Panel ID="Panel1" runat="server" Height="86px">
                            <div>
                            <asp:Label ID="Label1" runat="server" Text="Enter Your Login Id (Username) :" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lbl123" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="#CC0000"></asp:Label>
                            <asp:TextBox ID="tb1" placeholder="Enter Your Id which will be verified" 
                                    runat="server"></asp:TextBox>
                            <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click"></asp:Button>
                                                     


                            </div>
                            </asp:Panel>
                             

                        </div>
                        </ContentTemplate>
                         </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <!-- Footer -->
            <div id="footer">
                <div class="wrapper">
                    <div style="float: left;">
                        <span>&copy; Copyright 2014. All rights reserved. <a href="http://www.dhitsolutions.com"
                            title=""></a></span>
                    </div>
                    <div style="float: right;">
                        <span>Powered By :<a href="http://www.dhitsolutions.com" title="" target="_blank">D-HiT Solutions</a>
                            </span>
                    </div>
                </div>
                <div id="limiterBox" class="limiterBox" style="position: absolute; display: none;">
                </div>
                <a href="#" id="toTop" style="display: none;"><span id="toTopHover"></span>To Top</a>
            </div>
        </div>
    </form>
</body>
</html>
