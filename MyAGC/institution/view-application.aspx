<%@ Page Title="" Language="C#" MasterPageFile="~/InstistutionMaster.Master" AutoEventWireup="true" CodeBehind="view-application.aspx.cs" Inherits="MyAGC.institution.view_application" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Application Details</h1>
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
                                            <div class="table-responsive">
                                            <div class="row">
                    <asp:HiddenField ID="txtCollegeID" runat="server" />
                   <asp:HiddenField ID="txtPeriodID" runat="server" />
                                                <asp:HiddenField ID="txtProgramID" runat="server" />
                 
                    <asp:HiddenField ID="txtApplicationID" runat="server" />
                                                 <asp:HiddenField ID="txtApplicantID" runat="server" />
                </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Applicant Name</label>
                                                <asp:TextBox ID="txtApplicantName" runat="server" ReadOnly="true"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Applicant Email</label>
                                                <asp:TextBox ID="txtApplicantEmail" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Applicant Address</label>
                                                <asp:TextBox ID="txtApplicantAddress" ReadOnly="true"  runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                             <div class="col-sm-6 form-group">
                                                <label>Applicant DOB</label>
                                                <asp:TextBox ID="txtApplicantDOB" ReadOnly="true" TextMode="Date"  runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                           
                                             <div class="col-sm-6 form-group">
                                                <label>Applicant Identity Document</label>
                                                <asp:TextBox ID="txtApplicantDocumentType" ReadOnly="true"  runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Applicant Identity Number</label>
                                                <asp:TextBox ID="txtApplicantIdentityNumber" ReadOnly="true" runat="server"  class="form-control"></asp:TextBox>
                                            </div>
                                             <div class="col-sm-6 form-group">
                                                <label>Applicant Mobile</label>
                                                <asp:TextBox ID="txtApplicantMobile" runat="server"  ReadOnly="true" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Academic Period</label>
                                                <asp:TextBox ID="txtPeriod" runat="server"  ReadOnly="true" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>College</label>
                                                <asp:TextBox ID="txtCollegeName" runat="server"  ReadOnly="true" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Program</label>
                                                <asp:TextBox ID="txtProgramName" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                            </div> 
                                             <div class="col-sm-6 form-group">
                                                <label>Duration (Years)</label>
                                                <asp:TextBox ID="txtDuration" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Application Status</label>
                                                <asp:TextBox ID="txtApplicationStatus" runat="server" ReadOnly="true"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Requirements</label>
                                                <asp:TextBox ID="txtRequirements" runat="server" ReadOnly="true" TextMode="MultiLine"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group" id="upp" runat="server" visible="false">
                                                <label>Upload Acceptance Letter</label>
                                                <asp:FileUpload ID="fileUpload" runat="server" />
                                            </div>
                                          
                                             <div class="col-sm-12 reset-button" id="ub" runat="server" visible="false">
                                                  
                                                 <asp:Button ID="btnSave" runat="server" Text="Upload Document" OnClick="btnSave_Click" class="btn btn-success" />
                                                
                                             </div>

                                              <div class="col-sm-12 reset-button" id="butt" runat="server" visible="false">
                                                 <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" OnClientClick="return confirm('Are you sure want you want to approve this application?');" class="btn btn-success" />
                                                  <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" OnClientClick="return confirm('Are you sure want you want to reject this application?');" class="btn btn-danger" />
                                                  
                                             </div>
                                            
                                          
                                                         <table style="width: 100%">
                                                              <tr>
    <td><code>On mobile,swipe right/left for more info </code></td>
</tr>
                                                             <tr>
                                                                 <td>
                                                                     <br />
                                                                 </td>
                                                             </tr>
    <tr id="letter" runat="server" visible="false">
    <td colspan="12">
        <h4> <strong>Acceptance Letters</strong> </h4>
        <div class="row">
            <div class="col-sm-12">
                <asp:GridView ID="grdAcceptanceLetter" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdAcceptanceLetter_RowCommand"
                    role="grid" aria-describedby="basicExample_info"
                    AutoGenerateColumns="False" DataKeyNames="ID" Width="100%"
                    AllowPaging="True" AllowSorting="True">
                    <Columns>
                         <asp:BoundField DataField="ApplicantID" HeaderText="ApplicantID"></asp:BoundField>
                        <asp:BoundField DataField="ApplicantEmail" HeaderText="ApplicantEmail"></asp:BoundField>
                        <asp:BoundField DataField="FileName" HeaderText="Acceptance Letter"></asp:BoundField>
                        <asp:BoundField DataField="College" HeaderText="College"></asp:BoundField>
                         <asp:BoundField DataField="ProgramName" HeaderText="ProgramName"></asp:BoundField>
                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRecSel" runat="server" ForeColor="green" CssClass="fa fa-download fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName="selectrecord"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>

            </div>
        </div>

    </td>
</tr>
   <tr id="pop" runat="server" visible="false"> 
         <td colspan="12">
              <h4> <strong>Proof of Payment</strong> </h4>
             <div class="row">
                 <div class="col-sm-12">
                     <asp:GridView ID="grdPop" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdPop_RowCommand"
                         role="grid" aria-describedby="basicExample_info" OnPageIndexChanging="grdPop_PageIndexChanging"
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
                      <asp:TemplateField HeaderText="Reject">
     <ItemTemplate>
         <asp:LinkButton ID="lnkDel" runat="server" ForeColor="red" CssClass="fa fa-trash fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName="deleterecord"></asp:LinkButton>
     </ItemTemplate>
 </asp:TemplateField>
                         </Columns>
                     </asp:GridView>

                 </div>
             </div>

         </td>
     </tr>
    <tr>
        
        <td colspan="12" >
             <h4> <strong>Academic History</strong> </h4>
            <div class="row">
                <div class="col-sm-12">
                    <asp:GridView ID="grdAcademicHistory" runat="server" class="table table-bordered dataTable no-footer"
                        role="grid" aria-describedby="basicExample_info"
                      
                        AutoGenerateColumns="False" DataKeyNames="ID" Width="100%"
                        AllowPaging="True" AllowSorting="True">
                        <Columns>
                            <asp:BoundField DataField="SchoolName" HeaderText="School Name"></asp:BoundField>
                            <asp:BoundField DataField="StartDateMonth" HeaderText="Start Month"></asp:BoundField>
                            <asp:BoundField DataField="StartDateYear" HeaderText="Start Year"></asp:BoundField>
                            <asp:BoundField DataField="EndDateMonth" HeaderText="End Month"></asp:BoundField>
                            <asp:BoundField DataField="EndDateYear" HeaderText="End Year"></asp:BoundField>
                            <asp:BoundField DataField="SchoolLevelName" HeaderText="School Level"></asp:BoundField>
                            <asp:BoundField DataField="ExaminationName" HeaderText="Exam Body"></asp:BoundField>
                            <asp:BoundField DataField="SubjectsPassedNo" HeaderText="Subjects Passed"></asp:BoundField>

                          


                        </Columns>
                    </asp:GridView>

                </div>
            </div>

        </td>
    </tr>

                 <tr>
           <td colspan="12">
               <h4> <strong>Academic Certificates</strong> </h4>
               <div class="row">
                   <div class="col-sm-12">
                       <asp:GridView ID="grdDocument" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdDocument_RowCommand"
                           role="grid" aria-describedby="basicExample_info"
                           AutoGenerateColumns="False" DataKeyNames="ID" Width="100%"
                           AllowPaging="True" AllowSorting="True">
                           <Columns>
                               <asp:BoundField DataField="documentname" HeaderText="Certificate Name"></asp:BoundField>
                               <asp:BoundField DataField="Name" HeaderText="File Name"></asp:BoundField>
                               <asp:BoundField DataField="DateUploaded" HeaderText="DateUploaded" SortExpression="DateUploaded"></asp:BoundField>
                               <asp:TemplateField HeaderText="Download">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkRecSel" runat="server" ForeColor="green" CssClass="fa fa-download fa-2x" CommandArgument='<%#Eval("ID")%>' CommandName="selectrecord"></asp:LinkButton>
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