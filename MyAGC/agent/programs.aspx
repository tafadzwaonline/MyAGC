<%@ Page Title="" Language="C#" MasterPageFile="~/AgentMaster.Master" AutoEventWireup="true" CodeBehind="programs.aspx.cs" Inherits="MyAGC.agent.programs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Programs</h1>
                            <small></small>
                            <%--<ol class="breadcrumb hidden-xs">
                                <li><a href="index.html"><i class="pe-7s-home"></i> Profile Management</a></li>
                                <li class="active">Academic History</li>
                            </ol>--%>
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
                                           
                                              <asp:HiddenField ID="txtCollegeID" runat="server" />
                                            <asp:HiddenField ID="txtPeriodID" runat="server" />

                                        
                                            
                                               <table style="width:100%" >

                                         <tr>
                                             <td colspan="12">

                                                 <div class="row">
                    <div class="col-sm-12">
                        <asp:GridView ID="grdPrograms" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdPrograms_RowCommand"
                            role="grid" aria-describedby="basicExample_info" 
                            OnPageIndexChanging="grdPrograms_PageIndexChanging"
                            AutoGenerateColumns="False" DataKeyNames="ID" Width="100%"
                            AllowPaging="True" AllowSorting="True">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="ProgramName" HeaderText="Program Name">
                                   
                                </asp:BoundField>
                                
                                <asp:TemplateField HeaderText="Apply">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-success" CommandName="SelectItem" CommandArgument='<%#Eval("ID")%>'>
                                                       Apply Program
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                    </div>
                </div>

                                             </td>
                                         </tr>
       
     </table>
                                         </form>
                                     </div>
                                 </div>
                             </div>
                         </div>
                         
                     </section> <!-- /.content -->
                 </div>
    <!-- /.content-wrapper -->
</asp:Content>
