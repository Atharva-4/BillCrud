<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillView.aspx.cs"
    Inherits="BillCrud.Pages.Bills.BillView"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid mt-4">

        <div class="card shadow-sm">
            <div class="card-header bg-secondary text-white">
                <h4 class="mb-0">Bill Details</h4>
            </div>

            <div class="card-body">

                <h5 class="fw-bold">Bill Information</h5>
                <hr />

                <div class="row mb-3">
                    <div class="col-md-4">
                        <label class="fw-bold">Bill ID:</label>
                        <asp:Label ID="lblBillId" runat="server" CssClass="ms-2"></asp:Label>
                    </div>

                    <div class="col-md-4">
                        <label class="fw-bold">Customer Name:</label>
                        <asp:Label ID="lblCustomerName" runat="server" CssClass="ms-2"></asp:Label>
                    </div>

                    <div class="col-md-4">
                        <label class="fw-bold">Bill Date:</label>
                        <asp:Label ID="lblBillDate" runat="server" CssClass="ms-2"></asp:Label>
                    </div>
                </div>

                <h5 class="fw-bold mt-4">Items</h5>
                <hr />

                <asp:GridView ID="GridBillItems" runat="server"
                    AutoGenerateColumns="false"
                    CssClass="table table-bordered table-hover"
                    HeaderStyle-CssClass="table-dark">

                    <Columns>
                        <asp:BoundField DataField="ItemName" HeaderText="Item" />
                        <asp:BoundField DataField="Quantity" HeaderText="Qty" />
                        <asp:BoundField DataField="ItemPrice" HeaderText="Price (₹)" />
                        <asp:BoundField DataField="Total" HeaderText="Total (₹)" />
                    </Columns>

                </asp:GridView>

                <div class="text-end mt-3">
                    <h4>Total Bill Amount: ₹ <asp:Label ID="lblTotalAmount" runat="server" Text="0"></asp:Label></h4>
                </div>

                <a href="BillList.aspx" class="btn btn-secondary mt-3">
                    Back to Bills
                </a>
                <asp:Button ID="btnDownloadPDF" runat="server" Text="Download PDF Invoice"
                        CssClass="btn btn-success mt-3"
                             OnClick="btnDownloadPDF_Click" />

            </div>
        </div>

    </div>

</asp:Content>
