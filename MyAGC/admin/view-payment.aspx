<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="view-payment.aspx.cs" Inherits="MyAGC.admin.view_payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Payment Details</h1>
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
                    <asp:HiddenField ID="txtPaymentID" runat="server" />
                 
                    
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
                                                <label>Applicant Mobile</label>
                                                <asp:TextBox ID="txtApplicantMobile" runat="server"  ReadOnly="true" class="form-control"></asp:TextBox>
                                            </div>
                                             <div class="col-sm-6 form-group">
                                                <label>Currency</label>
                                                <asp:TextBox ID="txtCurrency" runat="server" ReadOnly="true" Text="USD"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>College Applied</label>
                                                <asp:TextBox ID="txtCollegeApplied" runat="server" ReadOnly="true"  class="form-control"></asp:TextBox>
                                            </div>
                                             <div class="col-sm-6 form-group">
                                                <label>Payment Date</label>
                                                <asp:TextBox ID="txtPaymentDate" ReadOnly="true" TextMode="Date"  runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Payment Reference Number</label>
                                                <asp:TextBox ID="txtReferenceNumber" runat="server"  ReadOnly="true" class="form-control"></asp:TextBox>
                                            </div>
                                            
                                            <div class="col-sm-6 form-group">
                                                <label>Amount Paid</label>
                                                <asp:TextBox ID="txtAmountPaid" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                            </div> 
                                             <div class="col-sm-6 form-group">
                                                <label>Platform</label>
                                                <asp:TextBox ID="txtPlatform" runat="server" ReadOnly="true" Text="PayNow" class="form-control"></asp:TextBox>
                                            </div>
                                           
                                            <div class="col-sm-6 form-group">
                                                <label>Program Applied</label>
                                                <asp:TextBox ID="txtProgramApplied" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                            </div>
                                          <div class="col-sm-6 form-group">
                                                <label>Paynow PollUrl</label>
                                                <asp:TextBox ID="txtPollUrl" runat="server" TextMode="MultiLine"  ReadOnly="true" class="form-control"></asp:TextBox>
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
