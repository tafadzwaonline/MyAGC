<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="MyAGC.admin.payment" %>

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
                                    <asp:HiddenField ID="txtRerefenceID" runat="server" />
                                </div>

                                <div class="col-sm-6 form-group">
                                    <label>First Name</label>
                                    <asp:TextBox ID="txtFirstName" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 form-group">
    <label>Last Name</label>
    <asp:TextBox ID="txtLastName" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
</div>
                                <div class="col-sm-6 form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmail" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>

                                <div class="col-sm-6 form-group">
                                    <label>Currency</label>
                                    <asp:TextBox ID="txtCurrency" runat="server" ReadOnly="true" Text="USD" class="form-control"></asp:TextBox>
                                </div>

                                <div class="col-sm-6 form-group">
                                    <label>Payment Date</label>
                                    <asp:TextBox ID="txtPaymentDate" ReadOnly="true" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label>Payment Reference Number</label>
                                    <asp:TextBox ID="txtReferenceNumber" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
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
                                    <label>Paynow PollUrl</label>
                                    <asp:TextBox ID="txtPollUrl" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 form-group">
    <label>Payment Option</label>
    <asp:TextBox ID="txtPaymentOption" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
</div>

                                <div class="col-sm-6 form-group">
                                    <label>Status</label>
                                    <asp:DropDownList ID="drpStatus" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                </div>

                                 <div class="col-sm-12 reset-button">
     <asp:Button ID="btnSave" runat="server" Text="Update Status" OnClick="btnSave_Click" class="btn btn-success" />

 </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>

        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
</asp:Content>

