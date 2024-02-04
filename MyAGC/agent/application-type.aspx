<%@ Page Title="" Language="C#" MasterPageFile="~/AgentMaster.Master" AutoEventWireup="true" CodeBehind="application-type.aspx.cs" Inherits="MyAGC.agent.application_type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Apllicant Information</h1>
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
                           <div class="form-group col-lg-12">
                                <div class="form-check">
                                    <label>Account Type</label><span style="color: red; position: absolute;">*</span><br>
                                    <label class="radio-inline">
                                        <asp:RadioButton GroupName="ReverseMode" AutoPostBack="true" ID="rdStudent" OnCheckedChanged="rdStudent_CheckedChanged"  runat="server" />

                                        New Student</label>
                                    <label class="radio-inline">
                                        <asp:RadioButton GroupName="ReverseMode" AutoPostBack="true" ID="rdExisting" OnCheckedChanged="rdExisting_CheckedChanged" runat="server" />
                                        Existing Student</label>
                                     
                                </div>
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
