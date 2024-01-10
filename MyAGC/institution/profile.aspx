<%@ Page Title="" Language="C#" MasterPageFile="~/InstistutionMaster.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="MyAGC.institution.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>University Profile</h1>
                            <small></small>
                         <%--   <ol class="breadcrumb hidden-xs">
                                <li><a href="index.html"><i class="pe-7s-home"></i>Student</a></li>
                                <li class="active">My Profile</li>
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
                                            <div class="col-sm-12 form-group">
                                                <label>University Logo</label>
                                                <asp:Image ID="ClientPic" Height="140px" ImageUrl="~/ImageHandler.ashx"  Width="160px" runat="server" />
                                            </div>
                                            <div class="col-sm-6 form-group">
    <label></label>
    <asp:FileUpload ID="fileUpload" runat="server" CssClass="image-upload" />
    <span id="fileTypeError" style="color: red; display: none;">Please select an image file (JPG, PNG, GIF).</span>
</div>
                                            
                                             <div class="col-sm-12 reset-button">
                                                 <asp:Button ID="btnUploadImage" runat="server" Text="Upload Image" class="btn btn-warning m-b-0" OnClick="btnUploadImage_Click" />
                                             </div>

                                            <div class="col-sm-6 form-group">
                                                <label>Password</label>
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"  class="form-control"></asp:TextBox>
                                            </div>
                                            
                                            <div class="col-sm-6 form-group">
                                                <label>Repeat Password</label>
                                                <asp:TextBox ID="txtRepeatPassword" runat="server" TextMode="Password"  class="form-control"></asp:TextBox>
                                            </div>     
                                       
                                             

                                              <div class="col-sm-12 reset-button">
                                                 <asp:Button ID="btnSave" runat="server" Text="Update Password" OnClick="btnSave_Click"  class="btn btn-success" />
                                               
                                             </div>
                                            
                                          

                                            
                                               
                                         </form>
                                     </div>
                                 </div>
                             </div>
                         </div>
                         <script type="text/javascript">
                             $(document).ready(function () {
                                 $(".image-upload").change(function () {
                                     var fileInput = $(this);
                                     var filePath = fileInput.val();
                                     var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif)$/i;

                                     if (!allowedExtensions.exec(filePath)) {
                                         $('#fileTypeError').css('display', 'block');
                                         fileInput.val('');
                                         return false;
                                     } else {
                                         $('#fileTypeError').css('display', 'none');
                                     }
                                 });
                             });
                         </script>
                     </section> <!-- /.content -->
                 </div>
    <!-- /.content-wrapper -->
</asp:Content>
