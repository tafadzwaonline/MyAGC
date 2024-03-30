<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="track-parcel.aspx.cs" Inherits="MyAGC.student.track_parcel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>View Parcels</h1>
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
                                            <div class="table-responsive">

                                            
 <table class="table table-bordered table-hover"  style="width:100%" >
                                              
                                                                                                              <tr>
    <td colspan="4">
         <asp:DropDownList ID="drpSearchBy" CssClass="form-control dropdown" AutoPostBack="false" runat="server">
                                            <asp:ListItem Value="1" Text="Search By" Selected="True"></asp:ListItem>
    <%--                                        <asp:ListItem Value="2" Text="Sender FullNames"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Receiver FullNames"></asp:ListItem>--%>
                                            <asp:ListItem Value="4" Text="TrackingID"></asp:ListItem>
                                        </asp:DropDownList></td>

    <td colspan="4"><asp:TextBox ID="txtValue" placeholder="Search Value" CssClass="form-control" runat="server"></asp:TextBox></td>
    
    <td colspan="4">
        <asp:Button ID="btnSearch" CssClass="btn btn-success" OnClick="btnSearch_Click"  runat="server" Text="Filter Search" />
    </td>
</tr>
                                                                                               <tr>
    <td><code>On mobile,swipe right/left for more info </code></td>
</tr>

                                    <tr>
                                        <td colspan="12">

                                            <div class="row">
               <div class="col-sm-12">
                   <asp:GridView ID="grdParcel" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdParcel_RowCommand"
                       role="grid" aria-describedby="basicExample_info" 
                       OnPageIndexChanging="grdParcel_PageIndexChanging"
                       AutoGenerateColumns="False" DataKeyNames="ID" Width="100%"
                       AllowPaging="True" AllowSorting="True">
                       <Columns>
                          <asp:BoundField DataField="TrackingID" HeaderText="TrackingID">

 </asp:BoundField>
                                                    <asp:BoundField DataField="SenderFullNames" HeaderText="Sender">

</asp:BoundField>
                            <asp:BoundField DataField="PackageDetails" HeaderText="Parcel">
                                
                            </asp:BoundField>
                            <asp:BoundField DataField="ReceiverFullNames" HeaderText="Receiver">
                               
                           </asp:BoundField>
                           <asp:BoundField DataField="OriginCountry" HeaderText="OriginCountry">
                               
                           </asp:BoundField>
                            <asp:BoundField DataField="DestinationCountry" HeaderText="DestinationCountry">
     
 </asp:BoundField>
                                                      <asp:BoundField DataField="Status" HeaderText="Status">
    
</asp:BoundField>
                          
                             <asp:TemplateField HeaderText="View">
     <ItemTemplate>
         <asp:LinkButton ID="btnView" runat="server" CssClass="btn btn-primary" CommandName="SelectItem" CommandArgument='<%#Eval("ID")%>'>
                        View Parcel
         </asp:LinkButton>
     </ItemTemplate>
 </asp:TemplateField>
                       </Columns>
                   </asp:GridView>

               </div>
           </div>

                                        </td>
                                    </tr>
  
</table>
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
