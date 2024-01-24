<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="reporting.aspx.cs" Inherits="MyAGC.admin.reporting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Reporting</h1>
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
 <ul>
                        <li><a href="../admin/SystemUsersReport ">
                                <b>System Users Report</b>
                            </a></li>
                        <li><a href="../admin/TotalPaymentsReport">
                                <b>Total Payments Report</b>
                            </a></li>
                       
                        
                    </ul>
                                            </div>
                                            
                                   
                                               
                                         </form>
                                     </div>
                                 </div>
                             </div>
                         </div>
                       
                     </section>
                 </div>
    <!-- /.content-wrapper -->
</asp:Content>
