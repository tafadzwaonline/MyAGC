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
                            <ol class="breadcrumb hidden-xs">
                                <li><a href="index.html"><i class="pe-7s-home"></i> Profile Management</a></li>
                                <li class="active">Academic History</li>
                            </ol>
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
                                            
                                            <div class="col-sm-6 form-group">
                                                <label>First Name</label>
                                                <asp:TextBox ID="txtFirstName" runat="server"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Last Name</label>
                                                <asp:TextBox ID="txtLastName" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Email</label>
                                                <asp:TextBox ID="txtEmail" runat="server"  class="form-control"></asp:TextBox>
                                            </div>

                                            <div class="col-sm-6 form-group">
                                                <label>Address</label>
                                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                            </div>
                                            
                                            <div class="col-sm-6 form-group">
                                                <label>Mobile</label>
                                                <asp:TextBox ID="txtMobile" runat="server"  class="form-control"></asp:TextBox>
                                            </div>     
                                            <div class="col-sm-6 form-group">
                                                <label>Date of Birth</label>
                                                <asp:TextBox ID="txtDob" runat="server" TextMode="Date" class="form-control"></asp:TextBox>
                                            </div>
                                            
                                            <div class="col-sm-4 form-group">
                                                <label>Country Of Residence</label>
                                                <asp:DropDownList ID="drpCountry" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                            </div> 
                                            <div class="col-sm-2 form-group">
                                               <label></label>
                                                <a class="btn btn-primary" href="table.html" data-toggle="modal" data-target="#modalAddCountry"> <i class="fa fa-list"></i>  Add Country </a>  
                                            </div> 
                                            <div class="col-sm-6 form-group">
                                             <label>Gender</label><br>
                                                             <div class="form-check">
                                    
                                    <label class="radio-inline">
                                        <asp:RadioButton GroupName="ReverseMode" AutoPostBack="true" ID="rdStudent" runat="server" />

                                        Female</label>
                                    <label class="radio-inline">
                                        <asp:RadioButton GroupName="ReverseMode" AutoPostBack="true" ID="rdInstitution" runat="server" />
                                        Male</label>
                                </div>
                                             </div>
                                             

                                              <div class="col-sm-12 reset-button">
                                                 <asp:Button ID="btnRegister" runat="server" Text="Save" class="btn btn-success" />
                                                  <%--<asp:Button ID="Button1" runat="server" Text=">> Academic History" class="btn btn-warning" />--%>
                                                 <a class="btn btn-warning" href="../student/academic-history">>> Academic History</a>
                                             </div>
                                            
                                            <table style="width:100%" >
                                                <tr>
                                                    <td><code>Next Of Kin Details</code></td>
                                                </tr>
                     <tr>
            <td colspan="2">
                <asp:TextBox ID="txtKinFirstName" placeholder="Next Of Kin First Name" CssClass="form-control" runat="server"></asp:TextBox></td>
            <td colspan="2">
                <asp:TextBox ID="txtKinLastName" placeholder="Next Of Kin Last Name" CssClass="form-control" runat="server"></asp:TextBox>
            </td>
            <td colspan="2"><asp:TextBox ID="txtKinMobile" placeholder="Next Of Kin Mobile" CssClass="form-control" runat="server"></asp:TextBox></td>
            <td colspan="2"></td>
                         <td colspan="2"><asp:TextBox ID="txtKinAddress" placeholder="Next Of Kin Address" CssClass="form-control" runat="server"></asp:TextBox></td>
            <td colspan="2"></td>
                          <td colspan="2"><asp:DropDownList ID="drpRelationType" runat="server" CssClass="form-control dropdown"></asp:DropDownList></td>
            <td colspan="2"></td>
            <td colspan="2"><asp:Button ID="btnSearch" CssClass="btn btn-success" runat="server" Text="Save" />

                
            </td>
<td>
    <br /><br /><br /><br />
</td>
        </tr>
                                                   </table>

                                             
                                               
                                         </form>
                                     </div>
                                 </div>
                             </div>
                         </div>
                         
                     </section> <!-- /.content -->
                 </div>
    <!-- /.content-wrapper -->
</asp:Content>

