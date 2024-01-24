<%@ Page Title="" Language="C#" MasterPageFile="~/InstistutionMaster.Master" AutoEventWireup="true" CodeBehind="reporting.aspx.cs" Inherits="MyAGC.institution.reporting" %>
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
                        <li><a href="../institution/ApplicationsReport">
                                <b>Applications Report</b>
                            </a></li>
                        <li><a href="../institution/TotalProgramReport">
                                <b>Total Programs Report</b>
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
