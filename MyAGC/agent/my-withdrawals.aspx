<%@ Page Title="" Language="C#" MasterPageFile="~/AgentMaster.Master" AutoEventWireup="true" CodeBehind="my-withdrawals.aspx.cs" Inherits="MyAGC.agent.my_withdrawals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>My Withdrawals</h1>
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
                                        <td colspan="12">

                                            <div class="row">

               <div class="col-sm-12">
                   <asp:GridView ID="grdPoints" runat="server" class="table table-bordered dataTable no-footer"
                       role="grid" aria-describedby="basicExample_info" 
                       OnPageIndexChanging="grdPoints_PageIndexChanging"
                       AutoGenerateColumns="False" DataKeyNames="ID" Width="100%"
                       AllowPaging="True" AllowSorting="True" OnRowCommand="grdPoints_RowCommand">
                       <Columns>

                          <asp:BoundField DataField="FullName" HeaderText="FullName">
                               <%--<ItemStyle HorizontalAlign="Left" Width="100px" />--%>
                           </asp:BoundField>
                            <asp:BoundField DataField="CommissionStatus" HeaderText="Withdrawal Status">
                               <%--<ItemStyle HorizontalAlign="Left" Width="100px" />--%>
                           </asp:BoundField>
                           <asp:BoundField DataField="Email" HeaderText="Email">
                               <%--<ItemStyle HorizontalAlign="Left" Width="100px" />--%>
                           </asp:BoundField>
                            <asp:BoundField DataField="Points" HeaderText="Points">
                              <%-- <ItemStyle HorizontalAlign="Left" Width="60px" />--%>
                           </asp:BoundField>
                            <asp:BoundField DataField="DateAdded" HeaderText="DateApplied">
                               <%--<ItemStyle HorizontalAlign="Left" Width="70px" />--%>
                           </asp:BoundField>
                            
                          
                           <%-- <asp:TemplateField HeaderText="View">
                               <ItemTemplate>
                                   <asp:LinkButton ID="btnadd" runat="server" CssClass="btn btn-success" CommandName="SelectItem" CommandArgument='<%#Eval("ID")%>'>
                                                  Approve
                                   </asp:LinkButton>
                               </ItemTemplate>
                           </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="View">
                               <ItemTemplate>
                                   <asp:LinkButton ID="btnReject" runat="server" CssClass="btn btn-danger" CommandName="DeleteItem" CommandArgument='<%#Eval("ID")%>'>
                                                  Reject
                                   </asp:LinkButton>
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
