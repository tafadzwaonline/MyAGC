<%@ Page Title="" Language="C#" MasterPageFile="~/AgentMaster.Master" AutoEventWireup="true" CodeBehind="withdraw-points.aspx.cs" Inherits="MyAGC.agent.withdraw_points" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Withdraw Points</h1>
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
                                                <label>Agent Name</label>
                                                <asp:TextBox ID="txtAgentName" runat="server" ReadOnly="true"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Agent ID</label>
                                                <asp:TextBox ID="txtAgentID" ReadOnly="true"  runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Current Balance</label>
                                                <asp:TextBox ID="txtCurrentBalance" ReadOnly="true"  runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Withdraw Points</label>
                                                <asp:TextBox ID="txtPoints" ReadOnly="false"  TextMode="Number" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                              <div class="col-sm-12 reset-button">
                                                 <asp:Button ID="btnSave" runat="server" Text="Submit Request" OnClick="btnSave_Click" class="btn btn-success" />
                                                  
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
