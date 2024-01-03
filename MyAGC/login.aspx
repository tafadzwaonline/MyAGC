<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MyAGC.login" %>

<!DOCTYPE html>
<html lang="en">


<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>MyAGC</title>

    <!-- Favicon and touch icons -->
    <%--<link rel="shortcut icon" href="./assets/dist/img/ico/favicon.png" type="image/x-icon">--%>
    

    <!-- Bootstrap -->
    <link href="./assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <!-- Bootstrap rtl -->
    <!--<link href="./assets/bootstrap-rtl/bootstrap-rtl.min.css" rel="stylesheet" type="text/css"/>-->
    <!-- Pe-icon-7-stroke -->
    <link href="./assets/pe-icon-7-stroke/css/pe-icon-7-stroke.css" rel="stylesheet" type="text/css"/>
    <!-- style css -->
    <link href="./assets/dist/css/stylehealth.min.css" rel="stylesheet" type="text/css"/>
    <!-- Theme style rtl -->
    <!--<link href="./assets/dist/css/stylehealth-rtl.css" rel="stylesheet" type="text/css"/>-->
</head>
<body>
    <!-- Content Wrapper -->
    <div class="login-wrapper">
       <%-- <div class="back-link">
            <a href="index.html" class="btn btn-success">Back to Dashboard</a>
        </div>--%>
        <div class="container-center">
            <div class="panel panel-bd">
                <div class="panel-heading">
                    <div class="view-header">
                        <div class="header-icon">
                            <i class="pe-7s-unlock"></i>
                        </div>
                        <div class="header-title">
                            <h3>Login</h3>
                            <small><strong>Please enter your credentials to login or</strong> <a href="./create-account" class="text-right f-w-600">create an account</a> to get started.</small>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <form id="loginForm" runat="server">
                        <div class="form-group">
                            <label class="control-label" for="username">Indicates required fields.<span style="color: red; position: absolute;">*</span></label>
                            
                    
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="email">Email<span style="color: red; position: absolute;">*</span></label>
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                    
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="password">Password<span style="color: red; position: absolute;">*</span></label>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                            
                        </div>
                        <div class="forgot-phone text-right float-right">
                                    <a href="./forgot-password" class="text-right f-w-600">Forgot Password?</a>
                                </div>
                        <div style="text-align: center;">
                           <%-- <button class="btn btn-primary btn-block">Login</button>--%>
                            <asp:Button ID="BtnLogin" runat="server" Text="Register" class="btn btn-primary btn-block" OnClick="BtnLogin_Click" />
                            <%--<a class="btn btn-warning" href="./create-account">Register</a>--%>
                        </div>
                        <div class="col-xs-12 text-center">
                                    <asp:Label ID="lblLoginError" runat="server" Font-Size="Small" style="font-size:15px;" ForeColor="Red"></asp:Label>
                                </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <!-- /.content-wrapper -->
    <!-- jQuery -->
    <script src="./assets/plugins/jQuery/jquery-1.12.4.min.js" type="text/javascript"></script>
    <!-- bootstrap js -->
    <script src="./assets/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
</body>


</html>