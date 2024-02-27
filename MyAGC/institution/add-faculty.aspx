<%@ Page Title="" Language="C#" MasterPageFile="~/InstistutionMaster.Master" AutoEventWireup="true" CodeBehind="add-faculty.aspx.cs" Inherits="MyAGC.institution.add_faculty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Manage Faculty</h1>
                            <small></small>

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
                                           
                                            <div class="table-responsive">
                                           
                                            <div class="col-sm-8 form-group">
                                                <label>Faculty Name</label>
                                                <asp:TextBox ID="txtFacultyName" runat="server"  class="form-control"></asp:TextBox>
                                            </div>
                                             
                                              <div class="col-sm-12 reset-button">
                                                 
                                                 <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-success" />
                                                 
                                             </div>
                                            
                                          
                                            
                                                                                          <table class="table table-bordered table-hover"  style="width:100%" >
                                                                                                                                                 <tr>
    <td><code>On mobile,swipe right/left for more info </code></td>
</tr>

                                    <tr>
                                        <td colspan="12">

                                            <div class="row">
               <div class="col-sm-12">
                   <asp:GridView ID="grdFaculty" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdFaculty_RowCommand"
                       role="grid" aria-describedby="basicExample_info" 
                       OnPageIndexChanging="grdFaculty_PageIndexChanging"
                       AutoGenerateColumns="False" DataKeyNames="ID" Width="100%"
                       AllowPaging="True" AllowSorting="True">
                       <Columns>
                           <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Faculty Name"></asp:BoundField>

                            
                           <asp:TemplateField HeaderText="Remove">
                               <ItemTemplate>
                                   <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure want you want to delete the record?');" CommandName="DeleteItem" CommandArgument='<%#Eval("ID")%>'>
                                                  <i class="fa fa-trash"></i>
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