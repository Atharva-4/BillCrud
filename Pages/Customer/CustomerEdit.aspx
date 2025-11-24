<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs"
    Inherits="BillCrud.Pages.Customer.CustomerEdit"
    MasterPageFile="~/Site.master" %>

<asp:Content ID="CustomerEditContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid mt-4">
        <div class="card shadow-sm">
            <div class="card-header bg-warning text-dark">
                <h4 class="mb-0">Customer Item</h4>
            </div>

        <div class="card-body">

            <!-- Hidden Customer ID -->
            <asp:HiddenField ID="hfCustomerId" runat="server" />

            <!-- NAME -->
            <div class="mb-3">
                <label class="form-label">Name</label>
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
                <asp:TextBox ID="TxtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
            </div>

            <!-- UPDATE BUTTON -->
            <asp:Button ID="btnUpdate" runat="server"
                Text="Update Customer"
                  CssClass="btn btn-warning text-dark"
                OnClick="btnUpdate_Click" />

            <!-- BACK BUTTON -->
            <a href="CustomerList.aspx" class="btn btn-secondary ms-2">
                Back to List
            </a>

        </div>

        </div>
    </div>

</asp:Content>
