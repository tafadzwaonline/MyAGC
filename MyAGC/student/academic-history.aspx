<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="academic-history.aspx.cs" Inherits="MyAGC.student.academic_history" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Academic History</h1>
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

        
                                  <%--  <div class="panel-heading">
                                        <div class="btn-group"> 
                                            <a class="btn btn-primary" href="table.html" data-toggle="modal" data-target="#modalSaveDocumentName"> <i class="fa fa-list"></i>  Doctor List </a>  
                                        </div>
                                    </div>--%>
                                    <div class="panel-body">
                                     
                                        <form class="col-sm-12" runat="server">
                                               <div class="table-responsive">
                                                   <div class="col-sm-6 form-group">
    <label>School Name</label>
    <asp:TextBox ID="txtSchoolName" runat="server"  class="form-control"></asp:TextBox>
</div>
<div class="col-sm-6 form-group">
    <label>School Level</label>
    <asp:DropDownList ID="drpSchoolLevel" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
</div>
<div class="col-sm-6 form-group">
    <label>Start (Month)</label>
    <asp:DropDownList ID="drpStartDateMonth" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
</div>
 <div class="col-sm-6 form-group">
    <label>Start (Year)</label>
    <asp:DropDownList ID="drpStartDateYear" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
</div>
          
<div class="col-sm-6 form-group">
    <label>End (or expected Month) </label>
    <asp:DropDownList ID="drpEndDateMonth" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
</div>     
<div class="col-sm-6 form-group">
    <label>End (Year) </label>
    <asp:DropDownList ID="drpEndDateYear" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
</div>
<div class="col-sm-6 form-group">
    <label>Number Of Subjects Passed</label>
    <asp:TextBox ID="txtSubjectsPassed" runat="server"  class="form-control"></asp:TextBox>
</div>     
<div class="col-sm-6 form-group">
    <label>Examination Body</label>
    <asp:DropDownList ID="drpExaminationBody" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
</div>
<div class="col-sm-6 form-group">
    <label>Activities and societies</label>
    <asp:TextBox ID="txtActivities" runat="server" TextMode="MultiLine" placeholder="Ex: Soccer, Volleyball"  class="form-control"></asp:TextBox>
</div> 

                                        
 

  <div class="col-sm-12 reset-button">
      <a class="btn btn-danger" href="../student/personal-information"><< Personal Information</a>
     <asp:Button ID="btnSave" runat="server" Text="Save Details" OnClick="btnSave_Click" class="btn btn-success" />
      <a class="btn btn-danger" href="../student/search-college"> Apply Program</a>
     <a class="btn btn-warning" href="../student/manage-document">>> Document Management</a>
      
 </div>

                   <table class="table table-bordered table-hover"  style="width:100%" >

       <tr>
           <td colspan="12">

               <div class="row">
                   <div class="col-sm-12">
                       <asp:GridView ID="grdAcademicHistory" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdAcademicHistory_RowCommand"
                           role="grid" aria-describedby="basicExample_info"
                           OnPageIndexChanging="grdAcademicHistory_PageIndexChanging"
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

