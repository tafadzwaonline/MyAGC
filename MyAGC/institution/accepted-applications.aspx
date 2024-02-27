<%@ Page Title="" Language="C#" MasterPageFile="~/InstistutionMaster.Master" AutoEventWireup="true" CodeBehind="accepted-applications.aspx.cs" Inherits="MyAGC.institution.accepted_applications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Accepted Applications</h1>
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
                                             <asp:HiddenField ID="txtid" runat="server" />
             
                                            <div class="table-responsive">
                                                                                          <table class="table table-bordered table-hover"  style="width:100%" >
                                                                                                                                                 <tr>
    <td><code>On mobile,swipe right/left for more info </code></td>
</tr>

                                    <tr>
                                        <td colspan="12">

                                            <div class="row">
               <div class="col-sm-12">
                   <asp:GridView ID="grdApplications" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdApplications_RowCommand"
                       role="grid" aria-describedby="basicExample_info" 
                       OnPageIndexChanging="grdApplications_PageIndexChanging"
                       AutoGenerateColumns="False" DataKeyNames="ID" Width="100%"
                       AllowPaging="True" AllowSorting="True">
                       <Columns>

                           <asp:BoundField DataField="ID" HeaderText="ApplicationID">
                               <ItemStyle HorizontalAlign="Left" Width="60px" />
                           </asp:BoundField>
                            <asp:BoundField DataField="ApplicantName" HeaderText="ApplicantName">
                               <ItemStyle HorizontalAlign="Left" Width="60px" />
                           </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email">
                               <ItemStyle HorizontalAlign="Left" Width="60px" />
                           </asp:BoundField>
                           <asp:BoundField DataField="Status" HeaderText="Status">
                               <ItemStyle HorizontalAlign="Left" Width="60px" />
                           </asp:BoundField>
                            <asp:BoundField DataField="College" HeaderText="College"></asp:BoundField>
                           <asp:BoundField DataField="ProgramName" HeaderText="ProgramName"></asp:BoundField>
                            
                          
                            <asp:TemplateField HeaderText="View">
                               <ItemTemplate>
                                   <asp:LinkButton ID="btnadd" runat="server" CssClass="btn btn-success" CommandName="SelectItem" CommandArgument='<%#Eval("ID")%>'>
                                                  View Application
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
