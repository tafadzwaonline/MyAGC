<%@ Page Title="" Language="C#" MasterPageFile="~/AgentMaster.Master" AutoEventWireup="true" CodeBehind="student-information.aspx.cs" Inherits="MyAGC.agent.student_information" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Student Aplicant Information</h1>
                            <small></small>
                           <%-- <ol class="breadcrumb hidden-xs">
                                <li><a href="index.html"><i class="pe-7s-home"></i> Profile Management</a></li>
                                <li class="active">Personal Information</li>
                            </ol>--%>
                        </div>
                    </section>
                    <!-- Main content -->
                    <section class="content">
                        <div class="row">
                            <!-- Form controls -->
                            <div class="col-sm-12">
                                <div class="panel panel-bd lobidrag">

        
                                  <%--  <div class="panel-heading">
                                        <div class="btn-group"> 
                                            <a class="btn btn-primary" href="table.html" data-toggle="modal" data-target="#modalSaveDocumentName"> <i class="fa fa-list"></i>  Doctor List </a>  
                                        </div>
                                    </div>--%>
                                    <div class="panel-body">
                                        <form class="col-sm-12" runat="server">
                                            <div class="row">
                   
                    <asp:HiddenField ID="txtID" runat="server" />
                                                <asp:HiddenField ID="txtCollegeID" runat="server" />
                  
                    <asp:HiddenField ID="txtPeriodID" runat="server" />
                    <asp:HiddenField ID="txtProgramID" runat="server" />
                </div>
                           <%--<div class="form-group col-lg-12">
                                <div class="form-check">
                                    <label>Account Type</label><span style="color: red; position: absolute;">*</span><br>
                                    <label class="radio-inline">
                                        <asp:RadioButton GroupName="ReverseMode" AutoPostBack="true" ID="rdStudent" OnCheckedChanged="rdStudent_CheckedChanged"  runat="server" />

                                        New Student</label>
                                    <label class="radio-inline">
                                        <asp:RadioButton GroupName="ReverseMode" AutoPostBack="true" ID="rdExisting" OnCheckedChanged="rdExisting_CheckedChanged" runat="server" />
                                        Existing Student</label>
                                     
                                </div>
                            </div>--%>
                                            <div class="col-sm-6 form-group">
                                                <label>First Name</label>
                                                <asp:TextBox ID="txtFirstName" runat="server"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Last Name</label>
                                                <asp:TextBox ID="txtLastName" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Email</label>
                                                <asp:TextBox ID="txtEmail" runat="server" ReadOnly="false"  class="form-control"></asp:TextBox>
                                            </div>

                                            <div class="col-sm-6 form-group">
                                                <label>Residental Address</label>
                                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                            </div>
                                            
                                            <div class="col-sm-6 form-group">
                                                <label>Mobile</label>
                                                <asp:TextBox ID="txtMobile" runat="server"  class="form-control"></asp:TextBox>
                                            </div>     
                                            <div class="col-sm-6 form-group">
                                                <label>Date of Birth</label>
                                                <asp:TextBox ID="txtDob" runat="server" TextMode="Date" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Identity Document Type</label>
                                                <asp:DropDownList ID="drpIdentityDocument" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                            </div>     
                                            <div class="col-sm-6 form-group">
                                                <label>Identity Number</label>
                                                <asp:TextBox ID="txtIdentityNumber" runat="server"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Country Of Origin</label>
                                                <asp:DropDownList ID="drpCountry" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                            </div> 
                                            
                                            <div class="col-sm-6 form-group">
                                             <label>Gender</label><br>
                                                      <asp:DropDownList ID="DrpGender" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                             </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Race</label>
                                                <asp:DropDownList ID="drpRace" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                            </div> 
                                            
                                            <div class="col-sm-6 form-group">
                                             <label>Religion</label><br>
                                                      <asp:DropDownList ID="drpReligion" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                             </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Title</label>
                                                <asp:DropDownList ID="drpTitle" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                            </div> 
                                            
                                            <div class="col-sm-6 form-group">
                                             <label>Disability</label><br>
                                                      <asp:DropDownList ID="drpDisabilitype" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                             </div>
                                            
                                             
                                            <hr />
                                             <div class="col-sm-6 form-group">
                                                <label>Certificate Type</label>
                                                <asp:DropDownList ID="drpDocumentType" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                            </div>
                                             <div class="col-sm-6 form-group">
                                                <label></label>
                                                <asp:FileUpload ID="fileUpload" runat="server" />
                                            </div>

                                              <div class="col-sm-12 reset-button">
                                                  
                                                  
                                                 <asp:Button ID="Button1" runat="server" Visible="false" Text="Upload Document" OnClick="btnSave_Click" class="btn btn-success" />
                                                  <asp:Button ID="btnSave" runat="server" Text="Save Details" OnClick="btnSave_Click" class="btn btn-success" />
                                                
                                             </div>

                                         </form>
                                     </div>
                                 </div>
                             </div>
                         </div>
                         
                     </section> <!-- /.content -->
                 </div>
    <!-- /.content-wrapper -->
</asp:Content>

