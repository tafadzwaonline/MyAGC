<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="search-college.aspx.cs" Inherits="MyAGC.student.search_college" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
                    <!-- Content Header (Page header) -->
                    <section class="content-header">
                        <div class="header-icon">
                            <i class="pe-7s-note2"></i>
                        </div>
                        <div class="header-title">
                              
                            <h1>Search College</h1>
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
                                               <table style="width:100%" >
                <tr>
            <td colspan="4">
                 <asp:DropDownList ID="drpSearchBy" CssClass="form-control dropdown" AutoPostBack="false" runat="server">
                                                    <asp:ListItem Value="1" Text="Search By" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="College Name"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="City/Location"></asp:ListItem>
                                                    
                                                </asp:DropDownList></td>
        
            <td colspan="4"><asp:TextBox ID="txtValue" placeholder="Search Value" CssClass="form-control" runat="server"></asp:TextBox></td>
            
            <td colspan="4">
                <asp:Button ID="btnSearch" CssClass="btn btn-success" OnClick="btnSearch_Click"  runat="server" Text="Filter Search" />
            </td>
        </tr></table>
                                            
                                               <table style="width:100%" >
<tr>
    <td>
        <br />
    </td>
</tr>
                                         <tr>
                                             <td colspan="12">

                                                 <div class="row">
                    <div class="col-sm-12">
                        <asp:GridView ID="grdCollege" runat="server" class="table table-bordered dataTable no-footer" OnRowCommand="grdCollege_RowCommand"
                            role="grid" aria-describedby="basicExample_info" OnSelectedIndexChanging="grdCollege_SelectedIndexChanging"
                            
                            AutoGenerateColumns="False" DataKeyNames="UserID" Width="100%"
                            AllowPaging="True" AllowSorting="True">
                            <Columns>
                                <asp:BoundField DataField="UserID" HeaderText="ID"></asp:BoundField>
                                 <asp:BoundField DataField="FirstName" HeaderText="College Name"></asp:BoundField>

                                 
                                <asp:TemplateField HeaderText="Apply">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnAdd" runat="server" CssClass="btn btn-success" OnClientClick="return confirm('Are you sure want you want to delete the record?');" CommandName="SelectItem" CommandArgument='<%#Eval("UserID")%>'>
                                                       Apply
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
                                         </form>
                                     </div>
                                 </div>
                             </div>
                         </div>
                         
                     </section> <!-- /.content -->
                 </div>
    <!-- /.content-wrapper -->
</asp:Content>
