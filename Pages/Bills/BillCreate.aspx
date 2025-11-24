<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillCreate.aspx.cs"
    Inherits="BillCrud.Pages.Bills.BillCreate"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid mt-4">

        <div class="card shadow-sm">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">Create New Bill</h4>
            </div>

            <div class="card-body">

                <!-- Customer Dropdown -->
                <div class="mb-3">
                    <label class="form-label fw-bold">Select Customer</label>
                    <asp:DropDownList ID="ddlCustomer" runat="server"
                        CssClass="form-select">
                    </asp:DropDownList>
                </div>

                <hr />

                <!-- Add Item Section -->
                <h5 class="fw-bold mb-3">Add Item</h5>

                <div class="row">
                    <div class="col-md-4">
                        <label class="form-label">Item</label>
                        <asp:DropDownList ID="ddlItem" runat="server"
                            CssClass="form-select"></asp:DropDownList>
                    </div>

                    <div class="col-md-3">
                        <label class="form-label">Quantity</label>
                        <asp:TextBox ID="txtQty" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="col-md-2 d-flex align-items-end">
                        <asp:Button ID="btnAddItem" runat="server"
                            Text="Add Item"
                            CssClass="btn btn-success w-100"
                            OnClick="btnAddItem_Click" />
                    </div>
                </div>

                <hr />

                <!-- Grid for Items -->
                <asp:GridView ID="GridBillItems" runat="server"
                    AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped mt-3"
                    HeaderStyle-CssClass="table-dark">

                    <Columns>
                        <asp:BoundField DataField="ItemName" HeaderText="Item" />
                        <asp:BoundField DataField="Quantity" HeaderText="Qty" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        <asp:BoundField DataField="Total" HeaderText="Total" />

                        <asp:TemplateField HeaderText="Remove">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnRemove" runat="server"
                                    CommandName="RemoveItem"
                                    CommandArgument='<%# Container.DataItemIndex %>'
                                    CssClass="btn btn-danger btn-sm">
                                    Delete
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>

                <!-- Total Amount -->
                <div class="mt-3 text-end">
                    <h4>Total Bill: ₹ <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label></h4>
                </div>

                <!-- Save Button -->
                <asp:Button ID="btnSaveBill" runat="server"
                    Text="Save Bill"
                    CssClass="btn btn-primary mt-3"
                    OnClick="btnSaveBill_Click" />

                <a href="BillList.aspx" class="btn btn-secondary mt-3 ms-2">Back</a>

            </div>
        </div>

    </div>

</asp:Content>
