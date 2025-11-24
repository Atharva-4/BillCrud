<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerAdd.aspx.cs"
    Inherits="BillCrud.Pages.Customer.CustomerAdd"
    MasterPageFile="~/Site.master" %>

<asp:Content ID="CustomerAddContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid mt-4">

        <div class="card shadow-sm">

            <!-- Card Header (BLUE LIKE ItemAdd's Green) -->
            <div class="card-header bg-success text-white">
                <h4 class="mb-0">Add New Customer</h4>
            </div>

            <!-- Card Body -->
            <div class="card-body">

                <!-- CUSTOMER NAME -->
                <div class="mb-3">
                    <label class="form-label">Customer Name</label>
                    <asp:TextBox ID="TxtName" runat="server" CssClass="form-control" />
                </div>

                <!-- PHONE -->
                <div class="mb-3">
                    <label class="form-label">Phone</label>
                    <asp:TextBox ID="TxtPhone" runat="server" CssClass="form-control" />
                </div>

                <!-- EMAIL -->
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" />
                </div>

                <!-- ADDRESS -->
                <div class="mb-3">
                    <label class="form-label">Address</label>
                    <asp:TextBox ID="TxtAddress" runat="server" CssClass="form-control"
                        TextMode="MultiLine" Rows="3" />
                </div>

                <!-- SAVE BUTTON -->
                <asp:Button ID="btnSave" runat="server"
                    Text="Save Customer"
                    CssClass="btn btn-primary"
                    OnClick="btnSave_Click" />

                <!-- BACK BUTTON -->
                <a href="CustomerList.aspx" class="btn btn-secondary ms-2">Back</a>

            </div>
        </div>

    </div>

</asp:Content>
