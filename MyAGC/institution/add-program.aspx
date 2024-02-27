<%@ Page Title="" Language="C#" MasterPageFile="~/InstistutionMaster.Master" AutoEventWireup="true" CodeBehind="add-program.aspx.cs" Inherits="MyAGC.institution.add_program" %>
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
                                            <div class="table-responsive">

                                            <div class="col-sm-6 form-group">
                                                <label>Faculty</label>
                                                <asp:DropDownList ID="drpFaculty" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                            </div>
                                               <div class="col-sm-6 form-group">
                                                <label> PROGRAMME & PROGRAMME CODE <code>(DEGREE/DIPLOMA/MASTERS/CERTIFICATE/DOCTORAL)</code> </label>
                                                <asp:TextBox ID="txtProgramName" runat="server"   class="form-control"></asp:TextBox>
                                            </div>
                                              <div class="col-sm-6 form-group">
                                                <label>Tuition</label>
                                                <asp:TextBox ID="txtTuition" runat="server" TextMode="Number"  class="form-control"></asp:TextBox>
                                            </div>
                                           
                                            <div class="col-sm-6 form-group">
                                                <label>Duration (years)</label>
                                                <asp:TextBox ID="txtDuration" runat="server" TextMode="Number"  class="form-control"></asp:TextBox>
                                            </div>
                                                <div class="col-sm-6 form-group">
    <label>Program Type</label>
    <asp:DropDownList ID="drpProgramType" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
</div>
                                            <div class="col-sm-6 form-group">
                                                <label>SPECIAL REQUIREMENTS</label>
                                                <asp:TextBox ID="txtRequirements" runat="server" TextMode="MultiLine"  class="form-control"></asp:TextBox>
                                            </div>
      
                                              <div class="col-sm-12 reset-button">
                                                 
                                                 <asp:Button ID="btnSave" runat="server" Text="Save Program" OnClick="btnSave_Click" class="btn btn-success" />
                                                 
                                             </div>
                                            

                                           
                                                                                          <table class="table table-bordered table-hover"  style="width:100%" >
                                                                                                      <tr>

<td colspan="4"><asp:TextBox ID="txtProgram" placeholder="Program name" CssClass="form-control" runat="server"></asp:TextBox></td>
    <%--<td colspan="4"><asp:TextBox ID="txtValue" placeholder="Search Value" CssClass="form-control" runat="server"></asp:TextBox></td>--%>
    
    <td colspan="4">
        <asp:Button ID="btnSearch" CssClass="btn btn-warning" OnClick="btnSearch_Click"  runat="server" Text="Filter Search" />
    </td>
</tr>
                                                                                               <tr>
    <td><code>On mobile,swipe right/left for more info </code></td>
</tr>

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
                          <asp:BoundField DataField="ProgramName" HeaderText="Program Name">
<%--     <ItemStyle HorizontalAlign="Left" Width="100px" />--%>
 </asp:BoundField>
                            <asp:BoundField DataField="Duration" HeaderText="Duration">
                                <ItemStyle HorizontalAlign="Left" Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Tuition" HeaderText="Tuition">
                               <ItemStyle HorizontalAlign="Left" Width="80px" />
                           </asp:BoundField>
                           <asp:BoundField DataField="Requirements" HeaderText="Requirements">
                               
                           </asp:BoundField>
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
