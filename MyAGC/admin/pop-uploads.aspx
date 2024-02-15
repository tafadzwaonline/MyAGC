<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="pop-uploads.aspx.cs" Inherits="MyAGC.admin.pop_uploads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Proof Of Payments</h1>
                            <small></small>
                          <%--  <ol class="breadcrumb hidden-xs">
                                <li><a href="index.html"><i class="pe-7s-home"></i> Profile Management</a></li>
                                <li class="active">Document Management</li>
                            </ol>--%>
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
                                                                                          <table class="table table-bordered table-hover"  style="width:100%" >

                                              <tr>
                                                  <td colspan="12">

                                                      <div class="row">
                                                          <div class="col-sm-12">
                                                              <asp:GridView ID="grdDocument" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdDocument_RowCommand"
                                                                  role="grid" aria-describedby="basicExample_info"
                                                                  AutoGenerateColumns="False" DataKeyNames="ID" Width="100%"
                                                                  AllowPaging="True" AllowSorting="True">
                                                                  <Columns>
                                                                      <asp:BoundField DataField="Name" HeaderText="File Name">
                                                                          <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                                      </asp:BoundField>
                                                                      <asp:BoundField DataField="DateUploaded" HeaderText="DateUploaded">
                                                                          <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                      </asp:BoundField>
                                                                       <asp:BoundField DataField="College" HeaderText="College"></asp:BoundField>
                                                                      <asp:BoundField DataField="ProgramName" HeaderText="ProgramName"></asp:BoundField>
                                                                      <asp:TemplateField HeaderText="Download">
                                                                          <ItemTemplate>
                                                                              <asp:LinkButton ID="lnkRecSel" runat="server" ForeColor="green" CssClass="fa fa-download fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName="selectrecord"></asp:LinkButton>
                                                                          </ItemTemplate>
                                                                      </asp:TemplateField>
                                                                   <%--   <asp:TemplateField HeaderText="Remove">
                                                                          <ItemTemplate>
                                                                              <asp:LinkButton ID="lnkRecDel" runat="server" ForeColor="red" OnClientClick="return confirm('Are you sure want you want to delete the document?');" CssClass="fa fa-trash fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName="DeleteItem"></asp:LinkButton>
                                                                          </ItemTemplate>
                                                                      </asp:TemplateField>--%>
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
