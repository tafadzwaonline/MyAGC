<%@ Page Title="" Language="C#" MasterPageFile="~/InstistutionMaster.Master" AutoEventWireup="true" CodeBehind="TotalProgramReport.aspx.cs" Inherits="MyAGC.institution.TotalProgramReport" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Programs Report</h1>
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
                                           <div class="table-responsive">
                                                                             <div class="col-sm-12 reset-button">
                                 
                                 <asp:Button ID="btnView" runat="server" Text="View Report" OnClick="btnView_Click" class="btn btn-success" />
                                 
                             </div>
                            
                                <div class="col-md-12">


    <div>
        <CR:CrystalReportViewer ID="ProgramsReportViewer" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" HasToggleGroupTreeButton="false" />
    </div>
</div>
</div>
                                            <%--<div class="col-sm-6 form-group">
                                                <label>Start Date</label>
                                                <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"  class="form-control"></asp:TextBox>
                                            </div>
                                           
                                            <div class="col-sm-6 form-group">
                                                <label>End Date</label>
                                                <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Status</label>
                                                <asp:DropDownList ID="drpApplicationStatus" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                            </div>--%>
                                          
      
                                              
                                         </form>
                                     </div>
                                 </div>
                             </div>
                         </div>
                         
                     </section> <!-- /.content -->
                 </div>
    <!-- /.content-wrapper -->
</asp:Content>
