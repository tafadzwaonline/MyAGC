<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="manage-withdrawal.aspx.cs" Inherits="MyAGC.admin.manage_withdrawal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Manage Withdrawals</h1>
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
       <td colspan="4">
        
   
       <td colspan="4"><asp:TextBox ID="txtFullName" placeholder="Agent Name" CssClass="form-control" runat="server"></asp:TextBox></td>
         <td colspan="4"><asp:TextBox ID="txtCommissionStatus" placeholder="Payment Status" CssClass="form-control" runat="server"></asp:TextBox></td>
       
      <%-- <td colspan="4">
           <asp:Button ID="btnSearch" CssClass="btn btn-success" OnClick="btnSearch_Click"  runat="server" Text="Filter Search" />
       </td>--%>
   </tr>
                                                                                               <tr>
    <td><code>On mobile,swipe right/left for more info </code></td>
</tr>
                                    <tr>
                                        <td colspan="12">
                                             <div style="overflow-y: scroll;height: 600px; width: 1400px;">
                                            <div class="row">

               <div class="col-sm-12">
                   <asp:GridView ID="grdPoints" runat="server" ClientIDMode="Static" class="table table-bordered dataTable no-footer"
                       role="grid" aria-describedby="basicExample_info" 
                       OnPageIndexChanging="grdPoints_PageIndexChanging"
                       AutoGenerateColumns="False" DataKeyNames="ID" Width="100%"
                       AllowPaging="false" AllowSorting="True" OnSorting="grdPoints_Sorting" OnRowCommand="grdPoints_RowCommand">
                       <Columns>

                          <asp:BoundField DataField="FullName" HeaderText="Agent FullName" SortExpression="FullName">
                               <%--<ItemStyle HorizontalAlign="Left" Width="100px" />--%>
                           </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                               <%--<ItemStyle HorizontalAlign="Left" Width="100px" />--%>
                           </asp:BoundField>
                            <asp:BoundField DataField="CommissionStatus" HeaderText="Withdrawal Status" SortExpression="CommissionStatus">
                               <%--<ItemStyle HorizontalAlign="Left" Width="100px" />--%>
                           </asp:BoundField>
                          
                            <asp:BoundField DataField="Points" HeaderText="Points" SortExpression="Points">
                              <%-- <ItemStyle HorizontalAlign="Left" Width="60px" />--%>
                           </asp:BoundField>
                            <asp:BoundField DataField="DateAdded" HeaderText="DateApplied" SortExpression="DateAdded">
                               <%--<ItemStyle HorizontalAlign="Left" Width="70px" />--%>
                           </asp:BoundField>
                            
                          
                            <asp:TemplateField HeaderText="View">
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
                           </asp:TemplateField>
                       </Columns>
                   </asp:GridView>

               </div>
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


         <script>
    $(document).ready(function () {
        $("#<%=txtFullName.ClientID%>, #<%=txtCommissionStatus.ClientID%>").on("input", function () {
            filterGrid();
        });
    });

    function filterGrid() {
        
        var FullName = $("#<%=txtFullName.ClientID%>").val().toLowerCase();
        var CommissionStatus = $("#<%=txtCommissionStatus.ClientID%>").val().toLowerCase();
   

        $("#grdPoints tr:gt(0)").each(function () {
            var row = $(this);
            var rowData = row.text().toLowerCase();
            var matches = (
                rowData.indexOf(FullName) > -1 &&
                rowData.indexOf(CommissionStatus) > -1
            );

            row.toggle(matches);
        });
    }
         </script>
</asp:Content>

