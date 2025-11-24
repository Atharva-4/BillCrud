<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemAdd.aspx.cs" 
    Inherits="BillCrud.Pages.Items.ItemAdd"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid mt-4">

        <div class="card shadow-sm">
            <div class="card-header bg-success text-white">
                <h4 class="mb-0">Add New Item</h4>
            </div>

            <div class="card-body">

                <div class="mb-3">
                    <label class="form-label">Item Name</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label class="form-label">Price (₹)</label>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />
                </div>

                <asp:Button ID="btnSave" runat="server" Text="Save Item"
                    CssClass="btn btn-success"
                    OnClick="btnSave_Click" />

                <a href="ItemList.aspx" class="btn btn-secondary ms-2">Back</a>

            </div>
        </div>

    </div>

</asp:Content>
