<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemEdit.aspx.cs"
    Inherits="BillCrud.Pages.Items.ItemEdit"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid mt-4">

        <div class="card shadow-sm">
            <div class="card-header bg-warning text-dark">
                <h4 class="mb-0">Edit Item</h4>
            </div>

            <div class="card-body">

                <asp:HiddenField ID="hfItemId" runat="server" />

                <div class="mb-3">
                    <label class="form-label">Item Name</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Price (₹)</label>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />
                </div>

                <asp:Button ID="btnUpdate" runat="server" Text="Update Item"
                    CssClass="btn btn-warning text-dark"
                    OnClick="btnUpdate_Click" />

                <a href="ItemList.aspx" class="btn btn-secondary ms-2">Back</a>

            </div>
        </div>

    </div>

</asp:Content>
