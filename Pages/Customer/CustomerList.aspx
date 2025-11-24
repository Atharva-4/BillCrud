<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs"
    Inherits="BillCrud.Pages.Customer.CustomerList"
    MasterPageFile="~/Site.master" %>

<asp:Content ID="CustomerListContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid mt-4">

        <div class="card shadow-sm">

            <!-- Card Header -->
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">Customer List</h4>
            </div>

            <!-- Card Body -->
            <div class="card-body">

                <asp:GridView ID="GridCustomers" runat="server"
                    AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped"
                    HeaderStyle-CssClass="table-dark"
                    OnRowCommand="GridCustomers_RowCommand">

                    <Columns>

                        <asp:BoundField DataField="CustomerId" HeaderText="ID" />
                        <asp:BoundField DataField="CustomerName" HeaderText="Name" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />

                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>

                                <asp:LinkButton ID="btnEdit" runat="server"
                                    CommandName="editCustomer"
                                    CommandArgument='<%# Eval("CustomerId") %>'
                                    CssClass="btn btn-sm btn-warning me-2">
                                    Edit
                                </asp:LinkButton>

                                <asp:LinkButton ID="btnDelete" runat="server"
                                    CommandName="deleteCustomer"
                                    CommandArgument='<%# Eval("CustomerId") %>'
                                    CssClass="btn btn-sm btn-danger"
                                    OnClientClick="return confirm('Are you sure to delete this customer?');">
                                    Delete
                                </asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

                <!-- Add Button BELOW table -->
                <a href="CustomerAdd.aspx" class="btn btn-primary mt-3">
                    Add New Customer
                </a>

            </div>
        </div>

    </div>

</asp:Content>
