<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="pay-now.aspx.cs" Inherits="MyAGC.student.pay_now" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>College Information</h1>
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
                    <asp:HiddenField ID="txtPeriodID" runat="server" />
                    <asp:HiddenField ID="txtProgramID" runat="server" />
                </div>
                                           
                                            
                                            <div class="col-sm-6 form-group">
                                                <label>Application Fee</label>
                                                <asp:TextBox ID="txtApplicationFee" ReadOnly="true" runat="server"  class="form-control"></asp:TextBox>
                                            </div>
                                        
                                          
                                             

                                              <div class="col-sm-12 reset-button">
                                                 <asp:Button ID="btnSave" runat="server" Text="Apply" OnClick="btnSave_Click" class="btn btn-success" />
                                                  
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
