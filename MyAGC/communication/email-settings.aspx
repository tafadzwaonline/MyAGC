<%@ Page Title="" Language="C#" MasterPageFile="~/InstistutionMaster.Master" AutoEventWireup="true" CodeBehind="email-settings.aspx.cs" Inherits="MyAGC.communication.email_settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Email Settings</h1>
                            <small></small>
                         
                        </div>
                    </section>
                    <!-- Main content -->
                    <section class="content">
                        <div class="row">
                            <!-- Form controls -->
                            <div class="col-sm-12">
                                <div class="panel panel-bd lobidrag">
                                    <div class="panel-body">
                                        <form class="col-sm-12" runat="server">
                                            <div class="row">
                    <asp:HiddenField ID="txtCollegeID" runat="server" />
                 
                    <asp:HiddenField ID="txtApplicationID" runat="server" />
                                                 <asp:HiddenField ID="txtApplicantID" runat="server" />
                </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Email Addrress</label>
                                                <asp:TextBox ID="txtEmailAddress" runat="server" ReadOnly="false"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Password</label>
                                                <asp:TextBox ID="txtPassword" ReadOnly="false" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Host</label>
                                                <asp:TextBox ID="txtHost" ReadOnly="false"  runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                             <div class="col-sm-6 form-group">
                                                <label>Port</label>
                                                <asp:TextBox ID="txtPort" ReadOnly="false" TextMode="Number"  runat="server" class="form-control"></asp:TextBox>
                                            </div>

                                              <div class="col-sm-12 reset-button">
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
