<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="parcel.aspx.cs" Inherits="MyAGC.student.parcel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="header-icon">
                <i class="pe-7s-note2"></i>
            </div>
            <div class="header-title">

                <h1>Client Parcel Details</h1>
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
                                <asp:HiddenField ID="txtid" runat="server" />
                                 <div class="col-sm-6 form-group">
     <label>Parcel Details</label>
     <asp:TextBox ID="txtParcelDetails" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
 </div>
                                <div class="col-sm-6 form-group">
                                    <label>Parcel Origin</label>
                                    <asp:DropDownList ID="drpOrigin" CssClass="form-control dropdown" AutoPostBack="false" runat="server" Enabled="false"></asp:DropDownList>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label>Parcel  Destination</label>
                                    <asp:DropDownList ID="drpDestination" CssClass="form-control dropdown" AutoPostBack="false" runat="server" Enabled="false"></asp:DropDownList>
                                </div>
                                                             <div class="col-sm-6 form-group">
    <label>Parcel weight(Kg)</label>
    <asp:TextBox ID="txtweight" runat="server" ReadOnly="true" TextMode="Number" AutoPostBack="true" OnTextChanged="txtweight_TextChanged" class="form-control"></asp:TextBox>
</div>
                                <div class="col-sm-6 form-group">
                                    <label>Amount</label>
                                    <asp:TextBox ID="txtAmount" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label>Sender FullName (<code>Surname Firstname</code>)</label>
                                    <asp:TextBox ID="txtSenderFullName" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                </div>
                                 <div class="col-sm-6 form-group">
     <label>Sender Mobile</label>
     <asp:TextBox ID="txtSenderMobile" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
 </div>
                                <div class="col-sm-6 form-group">
                                    <label>Receiver FullName (<code>Surname Firstname</code>)</label>
                                    <asp:TextBox ID="txtReceiverFullName" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                </div>
                                                                <div class="col-sm-6 form-group">
    <label>Receiver Mobile</label>
    <asp:TextBox ID="txtRecieverMobile" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
</div>
                               

                                <div class="col-sm-6 form-group">
                                    <label>Receiver Residental Address</label>
                                    <asp:TextBox ID="txtReceiverAddress" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                </div>
                                 <div class="col-sm-6 form-group">
     <label>Receiver NationalID</label>
     <asp:TextBox ID="txtReceiverIdentityNumber" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
 </div>
                           
                                  <div class="col-sm-6 form-group">
      <label>MYAGC Sending Officer</label>
      <asp:TextBox ID="txtSenderOfficer" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
  </div>
                                  <div class="col-sm-6 form-group">
      <label>MYAGC Receiving Officer</label>
      <asp:TextBox ID="txtReceivingOfficer" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
  </div>
                                                                <div class="col-sm-6 form-group">
    <label>Sending Code Number</label>
    <asp:TextBox ID="txtSendingCode" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
</div>
                                                                <div class="col-sm-6 form-group">
    <label>Receiving Code Number</label>
    <asp:TextBox ID="txtReceivingCode" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
</div>
                                <div class="col-sm-6 form-group">
                                    <label>Parcel Status</label>
                                    <asp:DropDownList ID="drpStatus" CssClass="form-control dropdown" AutoPostBack="false" runat="server" Enabled="false"></asp:DropDownList>
                                </div>
                                                                                                <div class="col-sm-6 form-group">
    <label>TrackingID</label>
    <asp:TextBox ID="txtTrackingID" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
</div>
                                

                            </form>
                        </div>
                    </div>
                </div>
            </div>

        </section>
    </div>
</asp:Content>