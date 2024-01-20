<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="personal-info.aspx.cs" Inherits="MyAGC.admin.personal_info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Personal Information</h1>
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
                                           
                                            <div class="col-sm-6 form-group">
                                                <label>First Name</label>
                                                <asp:TextBox ID="txtFirstName" runat="server"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Last Name</label>
                                                <asp:TextBox ID="txtLastName" runat="server"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Email</label>
                                                <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true"  class="form-control"></asp:TextBox>
                                            </div>

                                            <div class="col-sm-6 form-group">
                                                <label>Residental Address</label>
                                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                            </div>
                                            
                                            <div class="col-sm-6 form-group">
                                                <label>Mobile</label>
                                                <asp:TextBox ID="txtMobile" runat="server"  class="form-control"></asp:TextBox>
                                            </div>

                                              <div class="col-sm-12 reset-button">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-success" style="width: 100px;" />
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

