<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillList.aspx.cs"
    Inherits="BillCrud.Pages.Bills.BillList"
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid mt-4">

        <div class="card shadow-sm">
            <div class="card-header bg-info text-white">
                <h4 class="mb-0">Bills List</h4>
            </div>

            <div class="card-body">

                <asp:GridView ID="GridBills" runat="server"
                    AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped"
                    HeaderStyle-CssClass="table-dark"
                    OnRowCommand="GridBills_RowCommand">

                    <Columns>

                        <asp:BoundField DataField="BillId" HeaderText="Bill ID" />
                        <asp:BoundField DataField="CustomerName" HeaderText="Customer" />
                        <asp:BoundField DataField="BillDate" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}" />
                        <asp:BoundField DataField="TotalAmount" HeaderText="Total (₹)" DataFormatString="{0:N2}" />

                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>

                                <!-- View Button -->
                                <asp:LinkButton ID="btnView" runat="server"
                                    CommandName="viewBill"
                                    CommandArgument='<%# Eval("BillId") %>'
                                    CssClass="btn btn-sm btn-primary me-2">
                                    <i class="fas fa-eye"></i> View
                                </asp:LinkButton>

                                <!-- Delete Button -->
                                <asp:LinkButton ID="btnDelete" runat="server"
                                    CommandName="deleteBill"
                                    CommandArgument='<%# Eval("BillId") %>'
                                    CssClass="btn btn-sm btn-danger"
                                    OnClientClick="return confirm('Delete this bill?');">
                                    <i class="fas fa-trash-alt"></i> Delete
                                </asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

                <a href="BillCreate.aspx" class="btn btn-success mt-3">
                    <i class="fas fa-plus"></i> Create New Bill
                </a>

            </div>
        </div>

    </div>

</asp:Content>
