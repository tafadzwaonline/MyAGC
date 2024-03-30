<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="make-payment.aspx.cs" Inherits="MyAGC.student.make_payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="header-icon">
                <i class="pe-7s-note2"></i>
            </div>
            <div class="header-title">

                <h1>Online Payments</h1>
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

                                    <asp:HiddenField ID="txtIsPaid" runat="server" />
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label>FirstName</label>
                                    <asp:TextBox ID="txtFirstName" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label>LastName</label>
                                    <asp:TextBox ID="txtLastName" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmail" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label>Mobile</label>
                                    <asp:TextBox ID="txtMobile" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label>Payment</label>
                                    <asp:DropDownList ID="drpPaymentOption" CssClass="form-control dropdown" AutoPostBack="false" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label>Amount</label>
                                    <asp:TextBox ID="txtAmount" ReadOnly="false" TextMode="Number" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-12 reset-button">
                                    <asp:Button ID="btnSave" runat="server" Text="Submit Payment" OnClientClick="return confirm('Are you sure you want to make online payment?');" OnClick="btnSave_Click" class="btn btn-success" />

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

