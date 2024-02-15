<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="view-students.aspx.cs" Inherits="MyAGC.admin.view_students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>View Students</h1>
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
                                                    <td>
                                                        <br />
                                                    </td>
                                                </tr>
           <tr>
       <td colspan="4">
            <asp:DropDownList ID="drpSearchBy" CssClass="form-control dropdown" AutoPostBack="false" runat="server">
                                               <asp:ListItem Value="1" Text="Search By" Selected="True"></asp:ListItem>
                                               <asp:ListItem Value="2" Text="FirstName"></asp:ListItem>
                                               <asp:ListItem Value="3" Text="LastName"></asp:ListItem>
                                               
                                           </asp:DropDownList></td>
   
       <td colspan="4"><asp:TextBox ID="txtValue" placeholder="Search Value" CssClass="form-control" runat="server"></asp:TextBox></td>
       
       <td colspan="4">
           <asp:Button ID="btnSearch" CssClass="btn btn-success" OnClick="btnSearch_Click"  runat="server" Text="Filter Search" />
       </td>
   </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
                                         

                                    <tr>
                                        <td colspan="12">

                                            <div class="row">
               <div class="col-sm-12">
                   <asp:GridView ID="grdAdmin" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdAdmin_RowCommand"
                       role="grid" aria-describedby="basicExample_info" 
                       OnPageIndexChanging="grdAdmin_PageIndexChanging"
                       AutoGenerateColumns="False" DataKeyNames="UserID" Width="100%"
                       AllowPaging="True" AllowSorting="True">
                       <Columns>

                                                      <asp:BoundField DataField="UserID" HeaderText="ID">
                              
                           </asp:BoundField>
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName">
                               
                           </asp:BoundField>
                           <asp:BoundField DataField="LastName" HeaderText="LastName">
                             
                           </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email">
                              
                           </asp:BoundField>
                           <asp:BoundField DataField="Active" HeaderText="Active">
                               
                           </asp:BoundField>
                              <asp:BoundField DataField="Mobile" HeaderText="Mobile">
                              
                           </asp:BoundField>
                          
                            <asp:TemplateField HeaderText="Approve">
                               <ItemTemplate>
                                   <asp:LinkButton ID="btnApprove" runat="server" CssClass="btn btn-success" CommandName="ApproveItem" OnClientClick="return confirm('Are you sure want you want to reset to approve user?');" CommandArgument='<%#Eval("UserID")%>'>
                                                  Approve
                                   </asp:LinkButton>
                               </ItemTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supsend">
                               <ItemTemplate>
                                   <asp:LinkButton ID="btnSuspend" runat="server" CssClass="btn btn-danger" CommandName="SuspendItem" OnClientClick="return confirm('Are you sure want you want to reset to suspend user?');" CommandArgument='<%#Eval("UserID")%>'>
                                                  Suspend
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