<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="acceptance-letters.aspx.cs" Inherits="MyAGC.admin.acceptance_letters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Acceptance Letters</h1>
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
                    <asp:HiddenField ID="txtCollegeID" runat="server" />
                 
                    <asp:HiddenField ID="txtApplicationID" runat="server" />
                                                 <asp:HiddenField ID="txtApplicantID" runat="server" />
                </div>
                                            <div class="table-responsive">
                                                           <table style="width: 100%">

                                                                <tr>
    <td><code>On mobile,swipe right/left for more info </code></td>
</tr>
           <tr>
           <td colspan="12">
               <h4> <strong>Acceptance Letters</strong> </h4>
               <div class="row">
                   <div class="col-sm-12">
                       <asp:GridView ID="grdDocument" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdDocument_RowCommand"
                           role="grid" aria-describedby="basicExample_info"
                           AutoGenerateColumns="False" DataKeyNames="ID" OnPageIndexChanging="grdDocument_PageIndexChanging" Width="100%"
                           AllowPaging="True" AllowSorting="True">
                           <Columns>
                                <asp:BoundField DataField="ApplicantID" HeaderText="ApplicantID"></asp:BoundField>
                               <asp:BoundField DataField="ApplicantEmail" HeaderText="ApplicantEmail"></asp:BoundField>
                               <asp:BoundField DataField="FileName" HeaderText="Acceptance Letter"></asp:BoundField>
                               <asp:BoundField DataField="College" HeaderText="College"></asp:BoundField>
                                <asp:BoundField DataField="ProgramName" HeaderText="ProgramName"></asp:BoundField>
                               <asp:TemplateField HeaderText="Download">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkRecSel" runat="server" ForeColor="green" CssClass="fa fa-download fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName="SelectItem"></asp:LinkButton>
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
