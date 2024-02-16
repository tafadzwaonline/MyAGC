<%@ Page Title="" Language="C#" MasterPageFile="~/AgentMaster.Master" AutoEventWireup="true" CodeBehind="personal-information.aspx.cs" Inherits="MyAGC.agent.personal_information" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Agent Information</h1>
                            <small></small>
                           <%-- <ol class="breadcrumb hidden-xs">
                                <li><a href="index.html"><i class="pe-7s-home"></i> Profile Management</a></li>
                                <li class="active">Personal Information</li>
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
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                                            <div class="col-sm-6 form-group">
                                                <label>First Name</label>
                                                <asp:TextBox ID="txtFirstName" runat="server"  class="form-control"></asp:TextBox>
                                            </div>
                                             <div class="col-sm-6 form-group">
                                                <label>Last Name</label>
                                                <asp:TextBox ID="txtLastName" runat="server"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Email</label>
                                                <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true"  class="form-control"></asp:TextBox>
                                            </div>

                                            <div class="col-sm-6 form-group">
                                                <label>Residental Address</label>
                                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                            </div>
                                            
                                            <div class="col-sm-6 form-group">
                                                <label>Phone 1</label>
                                                <asp:TextBox ID="txtMobile1" runat="server"  class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Country</label>
                                                <asp:DropDownList ID="drpCountry" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                            </div> 

                                              <div class="col-sm-12 reset-button">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-success" style="width: 100px;" />

                                                  <%--<asp:Button ID="Button1" runat="server" Text=">> Academic History" class="btn btn-warning" />--%>
                                                 
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

