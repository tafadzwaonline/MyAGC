<%@ Page Title="" Language="C#" MasterPageFile="~/InstistutionMaster.Master" AutoEventWireup="true" CodeBehind="application-fee.aspx.cs" Inherits="MyAGC.institution.application_fee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Application Fees</h1>
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
                                             <div class="row">
                    <asp:HiddenField ID="txtID" runat="server" />
                </div>
                                            
                                            
                                           
                                            <div class="col-sm-6 form-group">
                                                <label>Citizen Type</label>
                                                <asp:DropDownList ID="drpCitizenType" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                            </div>
                                      
                                          <div class="col-sm-6 form-group">
                                                <label>Application Amount (USD)</label>
                                                <asp:TextBox ID="txtAmount" runat="server" TextMode="Number" class="form-control"></asp:TextBox>
                                            </div>

                                              <div class="col-sm-12 reset-button">
                                                 
                                                 <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-success" />
                                                 
                                             </div>
                                            
                                          
                                            <div class="table-responsive">
                                                                                          <table class="table table-bordered table-hover"  style="width:100%" >

                                    <tr>
                                        <td colspan="12">

                                            <div class="row">
               <div class="col-sm-12">
                   <asp:GridView ID="grdApplicationFees" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdApplicationFees_RowCommand"
                       role="grid" aria-describedby="basicExample_info" 
                       OnPageIndexChanging="grdApplicationFees_PageIndexChanging"
                       AutoGenerateColumns="False" DataKeyNames="ID" Width="100%"
                       AllowPaging="True" AllowSorting="True">
                       <Columns>
                           <%--<asp:BoundField DataField="SchoolName" HeaderText="School Name"></asp:BoundField>--%>
                         <%--  <asp:BoundField DataField="StartDateMonth" HeaderText="Start Month"></asp:BoundField>
                            <asp:BoundField DataField="StartDateYear" HeaderText="Start Year"></asp:BoundField>
                            <asp:BoundField DataField="EndDateMonth" HeaderText="End Month"></asp:BoundField>
                           <asp:BoundField DataField="EndDateYear" HeaderText="End Year"></asp:BoundField>
                           --%>
                           <asp:BoundField DataField="Name" HeaderText="Citizen Type"></asp:BoundField>
                           <asp:BoundField DataField="Amount" HeaderText="Amount"></asp:BoundField>
                           <%--<asp:BoundField DataField="SchoolLevelName" HeaderText="School Level"></asp:BoundField>
                           <asp:BoundField DataField="ExaminationName" HeaderText="Exam Body"></asp:BoundField>
                           <asp:BoundField DataField="SubjectsPassedNo" HeaderText="Subjects Passed"></asp:BoundField>--%>
                            
                         <%--  <asp:TemplateField HeaderText="Remove">
                               <ItemTemplate>
                                   <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure want you want to delete the record?');" CommandName="DeleteItem" CommandArgument='<%#Eval("ID")%>'>
                                                  <i class="fa fa-trash"></i>
                                   </asp:LinkButton>
                               </ItemTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="Add">
                               <ItemTemplate>
                                   <asp:LinkButton ID="btnadd" runat="server" CssClass="btn btn-success" CommandName="SelectItem" CommandArgument='<%#Eval("ID")%>'>
                                                  Application Fees
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
