<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="receipt.aspx.cs"  Inherits="MyAGC.student.receipt" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Receipt</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">

</head>
<body style="margin-top: 20px; background: #98FB98;">
    <form id="DivToPrint" runat="server">
                                    <div class="row">
    <asp:HiddenField ID="txtReferenceID" runat="server" />

</div>
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-lg-8">
                    <div class="card" style="border-radius: 0.25rem; box-shadow: 0 20px 27px 0 rgba(0, 0, 0, 0.05);">
                        <div class="card-body" style="padding: 3rem !important;">
                            <h2>Dear <asp:Label runat="server" ID="lblmemberName"></asp:Label></h2>
                            <p class="fs-sm">This electronic receipt is generated for the online payment made on <strong><asp:Label runat="server" ID="lblDate"></asp:Label></strong></p>
                            <div class="border-top border-gray-200 pt-4 mt-4">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="text-muted mb-2">Reference No.</div>
                                        <strong><asp:Label runat="server" ID="lblPayNowRef"></asp:Label></strong>
                                    </div>
                                    <div class="col-md-6 text-md-end">
                                        <div class="text-muted mb-2">Print Date:</div>
                                        <strong><%= DateTime.Now.ToString("MMM/dd/yy") %></strong>
                                    </div>
                                </div>
                            </div>
                            <div class="border-top border-gray-200 mt-4 py-4">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="text-muted mb-2">Client</div>
                                        <strong><asp:Label runat="server" ID="lblClientName"></asp:Label><asp:Label runat="server" ID="lblLastName"></asp:Label></strong>
                                        <p class="fs-sm"><asp:Label runat="server" ID="lblEmail"></asp:Label></p>
                                    </div>
                                    <div class="col-md-6 text-md-end">
                                        <div class="text-muted mb-2">Payment To</div>
                                        <strong>Achironet Global Consultancy</strong>
                                        <p class="fs-sm">Phone: +260773979011<br /><a href="#!" class="text-purple">Email: support@myagc.online</a></p>
                                    </div>
                                </div>
                            </div>
                            <table class="table border-bottom border-gray-200 mt-3">
                                <thead>
                                    <tr>
                                        <th scope="col" class="fs-sm text-dark text-uppercase-bold-sm px-0">Description</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="px-0"><strong>Payment Option: </strong><asp:Label runat="server" ID="lblPaymentOption"></asp:Label></td>
                                        <%--<td class="text-end px-0">$<asp:Label runat="server" ID="lbl"></asp:Label></td>--%>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="mt-5">
                                <div class="d-flex justify-content-end mt-3">
                                    <h5 class="me-3">Total:</h5>
                                    <h5 class="text-success">$<asp:Label runat="server" ID="lblTotal"></asp:Label></h5>
                                </div>
                            </div>
                            <div class="mt-5">
                                <div class="d-flex justify-content-end mt-3">
                                    <a href="../student/paynow-payments" style="width: 100%; height: 50px" class="btn btn-dark btn-lg card-footer-btn justify-content-center text-uppercase-bold-sm hover-lift-light">Back To Payments</a>
                                    <%--<asp:Button runat="server" ID="btnDownload" OnClick="btnDownload_Click" Height="50" class="btn btn-success btn-lg card-footer-btn text-uppercase-bold-sm hover-lift-light mx-auto d-block" Text="Download" style="width: 520px;" />--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
