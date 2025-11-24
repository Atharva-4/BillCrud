<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemList.aspx.cs"
    Inherits="BillCrud.Pages.Items.ItemList"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid mt-4">

        <div class="card shadow-sm">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">Item List</h4>
            </div>

            <div class="card-body">

                <asp:GridView ID="GridItems" runat="server"
                    AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped"
                    HeaderStyle-CssClass="table-dark"
                    OnRowCommand="GridItems_RowCommand">

                    <Columns>

                        <asp:BoundField DataField="ItemId" HeaderText="ID" />
                        <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                        <asp:BoundField DataField="Price" HeaderText="Price (₹)"
                            DataFormatString="{0:N2}" />

                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server"
                                    CommandName="editItem"
                                    CommandArgument='<%# Eval("ItemId") %>'
                                    CssClass="btn btn-sm btn-warning me-2">
                                    Edit
                                </asp:LinkButton>

                                <asp:LinkButton ID="btnDelete" runat="server"
                                    CommandName="deleteItem"
                                    CommandArgument='<%# Eval("ItemId") %>'
                                    CssClass="btn btn-sm btn-danger"
                                    OnClientClick="return confirm('Are you sure to delete this item?');">
                                    Delete
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

                <a href="ItemAdd.aspx" class="btn btn-primary mt-3">Add New Item</a>

            </div>
        </div>

    </div>

</asp:Content>
