<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="paynow-payments.aspx.cs" Inherits="MyAGC.student.paynow_payments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>PayNow Online Payments</h1>
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
                                             <div class="table-responsive">                                         <table class="table table-bordered table-hover"  style="width:100%" >
                                                                                                    <tr>
    <td><code>On mobile,swipe right/left for more info </code></td>
</tr>

                                    <tr>
                                        <td colspan="12">

                                            <div class="row">

               <div class="col-sm-12">
                   <asp:GridView ID="grdPayments" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdPayments_RowCommand"
                       role="grid" aria-describedby="basicExample_info" 
                       OnPageIndexChanging="grdPayments_PageIndexChanging"
                       AutoGenerateColumns="False" DataKeyNames="ReferenceNumber" Width="100%"
                       AllowPaging="True" AllowSorting="True">
                       <Columns>

                         <asp:BoundField DataField="ReferenceNumber" HeaderText="ReferenceNumber">
   <%-- <ItemStyle HorizontalAlign="Left" Width="60px" />--%>
</asp:BoundField>
                            <asp:BoundField DataField="Amount" HeaderText="Amount">
                               <ItemStyle HorizontalAlign="Left" Width="60px" />
                           </asp:BoundField>
                            <asp:BoundField DataField="Platform" HeaderText="Platform">
    <ItemStyle HorizontalAlign="Left" Width="60px" />
</asp:BoundField>
                            <asp:BoundField DataField="DateCreated" HeaderText="DatePaid">
                               <%--<ItemStyle HorizontalAlign="Left" Width="70px" />--%>
                           </asp:BoundField>
                           
                            <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
                           <asp:BoundField DataField="PaymentOption" HeaderText="PaymentOption"></asp:BoundField>
                            
                          
                            <asp:TemplateField HeaderText="View">
                               <ItemTemplate>
                                   <asp:LinkButton ID="btnadd" runat="server" CssClass="btn btn-success" CommandName="SelectItem" CommandArgument='<%#Eval("ReferenceNumber")%>'>
                                                  View Receipt
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
