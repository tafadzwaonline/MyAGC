<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="send-communication.aspx.cs" Inherits="MyAGC.admin.send_communication" %>
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
                                            <div class="row">
                    <asp:HiddenField ID="txtCollegeID" runat="server" />
                 
                    <asp:HiddenField ID="txtApplicationID" runat="server" />
                                                 <asp:HiddenField ID="txtID" runat="server" />
                </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Message Type</label>
                                                    <asp:DropDownList ID="drpMessageType" CssClass="form-control dropdown" AutoPostBack="false" runat="server">
                                                    <asp:ListItem Value="1" Text="Select Message Type" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Email"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Sms"></asp:ListItem>
                                                    
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Subject Header</label>
                                                <asp:TextBox ID="txtHeader" ReadOnly="false" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                           
                                             <div class="col-sm-6 form-group">
                                                <label>Date</label>
                                                <asp:TextBox ID="txtDate" ReadOnly="false" TextMode="Date"  runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Select Target</label>
                                                    <asp:DropDownList ID="drpTarget" CssClass="form-control dropdown" AutoPostBack="false" runat="server">
                                                    <asp:ListItem Value="1" Text="Select Target" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Colleges"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Students"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="Agents"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="Consultants"></asp:ListItem>
                                                    
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-6 form-group">
                                                <label>Message Body</label>
                                                <asp:TextBox ID="txtMsgBody" ReadOnly="false" TextMode="MultiLine"  runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                             

                                              <div class="col-sm-12 reset-button" id="butt" runat="server" visible="true">
                                                 <asp:Button ID="btnSave" runat="server" Text="Save BroadCast Message" OnClick="btnSave_Click"  class="btn btn-success" />
                                                  
                                                  
                                             </div>
                                            
                                          
<div class="col-sm-12 form-group">
      <div style="display: flex; justify-content: space-between;">
    <div style="width: 46%;">
        <h5>Unassigned Contacts</h5>
        <asp:ListBox ID="lstUnassigned" Width="100%" runat="server" SelectionMode="Multiple"></asp:ListBox>
    </div>
    <div style="width: 8%; text-align: center;">
        <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Text="&gt;" /><br />
        <asp:Button ID="btnAllAdd" OnClick="btnAllAdd_Click" runat="server" Text="&gt;&gt;" /><br />
        <!-- Add line break for vertical spacing -->
        <asp:Button ID="btnRemove" OnClick="btnRemove_Click" runat="server" Text="&lt;" /><br />
        <asp:Button ID="btnAllRemove" OnClick="btnAllRemove_Click"  runat="server" Text="&lt;&lt;" /><br />
    </div>
    <div style="width: 46%;">
        <h5>Mailing List Contacts</h5>
        <asp:ListBox ID="lstMailingList" Width="100%" SelectionMode="Multiple" runat="server"></asp:ListBox>
    </div>
</div>
    </div>
                                                      
                                               

 <div class="col-sm-12 reset-button" id="Div1" runat="server" visible="true">
                                                 <asp:Button ID="btnSendMessage" runat="server" Text="Send Message" OnClick="btnSendMessage_Click"  class="btn btn-success m-b-0" />
                                                  
                                                  
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
