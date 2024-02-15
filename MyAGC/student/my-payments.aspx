<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="my-payments.aspx.cs" Inherits="MyAGC.student.my_payments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>My Payments</h1>
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
                                                                                      <table class="table table-bordered table-hover"  style="width:100%" >

                                    <tr>
                                        <td colspan="12">

                                            <div class="row">

               <div class="col-sm-12">
                   <asp:GridView ID="grdPayments" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdPayments_RowCommand"
                       role="grid" aria-describedby="basicExample_info" 
                       OnPageIndexChanging="grdPayments_PageIndexChanging"
                       AutoGenerateColumns="False" DataKeyNames="ID" Width="100%"
                       AllowPaging="True" AllowSorting="True">
                       <Columns>

                         
                            <asp:BoundField DataField="Amount" HeaderText="Fee">
                               <ItemStyle HorizontalAlign="Left" Width="60px" />
                           </asp:BoundField>
                            <asp:BoundField DataField="DateCreated" HeaderText="DatePaid">
                               <%--<ItemStyle HorizontalAlign="Left" Width="70px" />--%>
                           </asp:BoundField>
                           <asp:BoundField DataField="ReferenceNumber" HeaderText="ReferenceNumber">
                              <%-- <ItemStyle HorizontalAlign="Left" Width="60px" />--%>
                           </asp:BoundField>
                            <asp:BoundField DataField="College" HeaderText="College"></asp:BoundField>
                           <asp:BoundField DataField="ProgramName" HeaderText="ProgramName"></asp:BoundField>
                            
                          
                            <asp:TemplateField HeaderText="View">
                               <ItemTemplate>
                                   <asp:LinkButton ID="btnadd" runat="server" CssClass="btn btn-success" CommandName="SelectItem" CommandArgument='<%#Eval("ID")%>'>
                                                  View Payment
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
             <div class="table-responsive">
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
