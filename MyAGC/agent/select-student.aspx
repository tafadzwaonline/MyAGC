<%@ Page Title="" Language="C#" MasterPageFile="~/AgentMaster.Master" AutoEventWireup="true" CodeBehind="select-student.aspx.cs" Inherits="MyAGC.agent.select_student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Select Applicants </h1>
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
                                             <div class="row">
                   
                    <asp:HiddenField ID="txtID" runat="server" />
                                                <asp:HiddenField ID="txtCollegeID" runat="server" />
                  
                    <asp:HiddenField ID="txtPeriodID" runat="server" />
                    <asp:HiddenField ID="txtProgramID" runat="server" />
                </div>
                                            <div class="table-responsive">
                                                                                          <table class="table table-bordered table-hover"  style="width:100%" >
                                                                                               <tr>
    <td><code>On mobile,swipe right/left for more info </code></td>
</tr>
                                                                                                                                                                                                                                                                                                               <tr>


    <td colspan="4"><asp:TextBox ID="txtSearch" placeholder="FirstName or LastName" CssClass="form-control" runat="server"></asp:TextBox></td>
    
    <td colspan="4">
        <asp:Button ID="btnSearch" CssClass="btn btn-success" OnClick="btnSearch_Click"  runat="server" Text="Filter Search" />
    </td>
</tr>
                                    <tr>
                                        <td colspan="12">

                                            <div class="row">

               <div class="col-sm-12">
                   <asp:GridView ID="grdStudent" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdStudent_RowCommand"
                       role="grid" aria-describedby="basicExample_info" 
                       OnPageIndexChanging="grdStudent_PageIndexChanging"
                       AutoGenerateColumns="False" DataKeyNames="UserID" Width="100%"
                       AllowPaging="True" AllowSorting="True">
                       <Columns>

                         
                            <asp:BoundField DataField="UserID" HeaderText="UserID">
                               <ItemStyle HorizontalAlign="Left" Width="60px" />
                           </asp:BoundField>
                            <asp:BoundField DataField="FullName" HeaderText="FullName">
                               <%--<ItemStyle HorizontalAlign="Left" Width="70px" />--%>
                           </asp:BoundField>
                           <asp:BoundField DataField="Email" HeaderText="Email">
                              <%-- <ItemStyle HorizontalAlign="Left" Width="60px" />--%>
                           </asp:BoundField>
                            <asp:BoundField DataField="IdentityNumber" HeaderText="IdentityNumber"></asp:BoundField>
                           
                            
                          
                            <asp:TemplateField HeaderText="View">
                               <ItemTemplate>
                                   <asp:LinkButton ID="btnadd" runat="server" CssClass="btn btn-success" CommandName="SelectItem" CommandArgument='<%#Eval("UserID")%>'>
                                                  View Student
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

