<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="application.aspx.cs" Inherits="MyAGC.student.application" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Personal Information</h1>
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
                    <asp:HiddenField ID="txtPeriodID" runat="server" />
                    <asp:HiddenField ID="txtProgramID" runat="server" />
                </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Academic Period</label>
                                                <asp:TextBox ID="txtPeriod" runat="server" ReadOnly="true"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Application Deadline</label>
                                                <asp:TextBox ID="txtApplicationDeadline" ReadOnly="true" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Program</label>
                                                <asp:TextBox ID="txtProgram" ReadOnly="true"  runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                             <div class="col-sm-6 form-group">
                                                <label>Faculty</label>
                                                <asp:TextBox ID="txtFaculty" ReadOnly="true"  runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Citizen</label>
                                               <asp:DropDownList ID="drpCitizenType" CssClass="form-control dropdown" AutoPostBack="true" OnSelectedIndexChanged="drpCitizenType_SelectedIndexChanged"  runat="server"></asp:DropDownList>
                                            </div>
                                            
                                            <div class="col-sm-6 form-group">
                                                <label>Application Fee</label>
                                                <asp:TextBox ID="txtApplicationFee" ReadOnly="true" runat="server"  class="form-control"></asp:TextBox>
                                            </div>
                                             <div class="col-sm-6 form-group">
                                                <label>Application Date</label>
                                                <asp:TextBox ID="txtApplicationDate" runat="server" TextMode="Date"  ReadOnly="true" class="form-control"></asp:TextBox>
                                            </div> 
                                            <div class="col-sm-6 form-group">
                                                <label>Tuition</label>
                                                <asp:TextBox ID="txtTuition" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                            </div> 
                                             <div class="col-sm-6 form-group">
                                                <label>Duration (Years)</label>
                                                <asp:TextBox ID="txtDuration" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Intake</label>
                                                <asp:TextBox ID="txtIntake" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Requirements</label>
                                                <asp:TextBox ID="txtRequirements" runat="server" ReadOnly="true" TextMode="MultiLine"  class="form-control"></asp:TextBox>
                                            </div>
                                          
                                             

                                              <div class="col-sm-12 reset-button">
                                                 <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-success" />
                                                  
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
