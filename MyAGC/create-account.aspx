<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create-account.aspx.cs" Inherits="MyAGC.create_account" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>MyAGC</title>

    <!-- Favicon and touch icons -->
    <%--    <link rel="shortcut icon" href="./assets/dist/img/ico/favicon.png" type="image/x-icon">--%>

    <!-- Bootstrap -->
    <link href="./assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Bootstrap rtl -->
    <!--<link href="./assets/bootstrap-rtl/bootstrap-rtl.min.css" rel="stylesheet" type="text/css"/>-->
    <!-- Pe-icon-7-stroke -->
    <link href="./assets/pe-icon-7-stroke/css/pe-icon-7-stroke.css" rel="stylesheet" type="text/css" />
    <!-- style css -->
    <link href="./assets/dist/css/stylehealth.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style rtl -->
    <!--<link href="./assets/dist/css/stylehealth-rtl.css" rel="stylesheet" type="text/css"/>-->
</head>
<body>
    <!-- Content Wrapper -->
    <div class="login-wrapper">
        <%-- <div class="back-link">
            <a href="index.html" class="btn btn-success">Back to Dashboard</a>
        </div>--%>
        <div class="container-center lg">
            <div class="panel panel-bd">
                <div class="panel-heading">
                    <div class="view-header">
                        <div class="header-icon">
                            <i class="pe-7s-unlock"></i>
                        </div>
                        <div class="header-title">
                            <h3>Create Account</h3>
                            <small><strong>Please enter your data to register.</strong></small>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <form id="loginForm" runat="server">

                        <div class="row">
                             <div>
                            <asp:Label ID="lblLoginError" runat="server" Font-Size="Small" Style="font-size: 15px;" ForeColor="Red"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblSuccess" runat="server" Font-Size="Small" Style="font-size: 15px;" ForeColor="green"></asp:Label>
                        </div>
                            <div class="form-group col-lg-12">
                                <div class="form-check">
                                    <label>Account Type</label><span style="color: red; position: absolute;">*</span><br>
                                    <label class="radio-inline">
                                        <asp:RadioButton GroupName="ReverseMode" AutoPostBack="true" ID="rdStudent" OnCheckedChanged="rdStudent_CheckedChanged" runat="server" />

                                        Student</label>
                                    <label class="radio-inline">
                                        <asp:RadioButton GroupName="ReverseMode" AutoPostBack="true" ID="rdInstitution" OnCheckedChanged="rdInstitution_CheckedChanged" runat="server" />
                                        Institution</label>
                                     <label class="radio-inline">
                                        <asp:RadioButton GroupName="ReverseMode" AutoPostBack="true" ID="rdAgent" OnCheckedChanged="rdAgent_CheckedChanged" runat="server" />
                                        Agent</label>
                                     <label class="radio-inline">
    <asp:RadioButton GroupName="ReverseMode" AutoPostBack="true" ID="rdConsultancy" OnCheckedChanged="rdConsultancy_CheckedChanged" runat="server" />
    Consultancy Company</label>
                                </div>
                            </div>
                            <div class="form-group col-lg-6" id="InstitutionName" runat="server" visible="false">
                                <label>Institution Name</label><span style="color: red; position: absolute;">*</span>
                                <asp:TextBox ID="txtInstitutionName" runat="server" placeholder="Institution Name" class="form-control"></asp:TextBox>

                            </div>
                            <div class="form-group col-lg-6" id="InstitutionAddress" runat="server" visible="false">
                                <label>Institution Address</label><span style="color: red; position: absolute; top: -3px; left: 5px;">*</span>
                                <asp:TextBox ID="txtInstitutionAddress" runat="server" TextMode="MultiLine" placeholder="Institution Address" class="form-control"></asp:TextBox>
                            </div>

                                 <div class="form-group col-lg-6" id="AgentFirstName" runat="server" visible="false">
                                <label>Agent FirstName</label><span style="color: red; position: absolute;">*</span>
                                <asp:TextBox ID="txtAgentFirstName" runat="server" placeholder="Agent FirstName" class="form-control"></asp:TextBox>

                            </div>
                            <div class="form-group col-lg-6" id="AgentLastName" runat="server" visible="false">
                                <label>Agent LastName</label><span style="color: red; position: absolute; top: -3px; left: 5px;">*</span>
                                <asp:TextBox ID="txtAgentLastName" runat="server" placeholder="Agent LastName" class="form-control"></asp:TextBox>
                            </div>
                                 <div class="form-group col-lg-6" id="ConsultancyName" runat="server" visible="false">
    <label>Consultancy Name</label><span style="color: red; position: absolute;">*</span>
    <asp:TextBox ID="txtConsultancyName" runat="server" placeholder="Consultancy Name" class="form-control"></asp:TextBox>

</div>
                                                             <div class="form-group col-lg-6" id="ConsultancyAdd" runat="server" visible="false">
    <label>Consultancy Address</label><span style="color: red; position: absolute;">*</span>
    <asp:TextBox ID="txtConsultancyAdd" runat="server" placeholder="Consultancy Address" class="form-control"></asp:TextBox>

</div>

                            <div class="form-group col-lg-6" id="FirstName" runat="server" visible="false">
                                <label>First Name <span style="color: red; position: absolute;">*</span></label>
                                <asp:TextBox ID="txtFirstName" runat="server" placeholder="FirstName" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-6" id="LastName" runat="server" visible="false">
                                <label>Last Name</label><span style="color: red; position: absolute;">*</span>
                                <asp:TextBox ID="txtLastName" runat="server" placeholder="LastName" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-6" id="Emails" runat="server" visible="false">
                                <label>Email Address</label><span style="color: red; position: absolute;">*</span>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email Address" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-6" id="Address" runat="server" visible="false">
                                <label>Address</label><span style="color: red; position: absolute;">*</span>
                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" placeholder="Address" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-6" id="Dob" runat="server" visible="false">
                                <label>Date Of Birth</label><span style="color: red; position: absolute;">*</span>
                                <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-6" id="Phone" runat="server" visible="false">
                                <label>Phone (<code>start with country code eg 260786345112</code>)</label><span style="color: red; position: absolute; top: -3px; left: 5px;">*</span>
                                <asp:TextBox ID="txtPhone" runat="server" placeholder="263786345112" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-6" id="Password1" runat="server" visible="false">
                                <label>Password</label><span style="color: red; position: absolute;">*</span>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-lg-6" id="Password2" runat="server" visible="false">
                                <label>Repeat Password</label><span style="color: red; position: absolute;">*</span>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" placeholder="Repeat Password" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-lg-12" id="tr1" runat="server" visible="false">
                                <p>
                                    <label for='t1'>Please review the following:</label>
                                </p>
                            </div>
                           <%-- <div class="form-group col-lg-12" id="tr2" runat="server" visible="false">
                                <p>
                                    <asp:CheckBox ID="CheckBox0" Checked="true" runat="server"></asp:CheckBox>
                                    <label for='drop-remove'>MyAGC may share my contact information with colleges/universities that i am considering applying to so they may communicate with me prior to the submission of my application(you can change the response late within your account settings).</label>
                                </p>
                            </div>
                            <div class="form-group col-lg-12" id="tr3" runat="server" visible="false">
                                <p>
                                    <asp:CheckBox ID="CheckBox1" Checked="true" runat="server"></asp:CheckBox>
                                    <label for='drop-remove'>MyAGC may communicate with me by email, phone or text message about my account, information relavant to the college admissions process, and my college experince(you can change the response late within your account settings)</label>
                                </p>
                            </div>--%>
                            <div class="form-group col-lg-12" id="tr4" runat="server" visible="false">
                                <p>
                                    <asp:CheckBox ID="CheckBox2" runat="server"></asp:CheckBox>
                                    <label for='drop-remove'>By checking this box, I agree to the terms of Use and Privacy Policy (Unless iam under the age of 18, in which case, I represent that my parent or legal guardian also agress to the terms of Use on my behalf. </label><span style="color: red; position: absolute; top: -3px; left: 5px;">*</span>
                                </p>
                            </div>

                        </div>
                        <div>
                            
                            <asp:Button ID="btnRegister" runat="server" Text="Register" class="btn btn-success" OnClick="btnRegister_Click" />
                            <a class="btn btn-warning" href="./login">Login</a>
                        </div>
                       
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- jQuery -->
    <script src="./assets/plugins/jQuery/jquery-1.12.4.min.js" type="text/javascript"></script>
    <!-- bootstrap js -->
    <script src="./assets/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
