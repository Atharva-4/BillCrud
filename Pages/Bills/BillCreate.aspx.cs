using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BillCrud.DAL;

using System.Data;


namespace BillCrud.Pages.Bills
{
    public partial class BillCreate : System.Web.UI.Page
    {
        CustomerDAL customerDal = new CustomerDAL();
        ItemDAL itemDal = new ItemDAL();
        BillDAL billDal = new BillDAL();  // we will create this next

        DataTable dtBillItems;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomers();
                LoadItems();
                CreateBillItemsTable();
            }
        }

        void LoadCustomers()
        {
            ddlCustomer.DataSource = customerDal.GetAllCustomers();
            ddlCustomer.DataTextField = "CustomerName";
            ddlCustomer.DataValueField = "CustomerId";
            ddlCustomer.DataBind();
        }

        void LoadItems()
        {
            ddlItem.DataSource = itemDal.GetAllItems();
            ddlItem.DataTextField = "ItemName";
            ddlItem.DataValueField = "ItemId";
            ddlItem.DataBind();
        }

        void CreateBillItemsTable()
        {
            dtBillItems = new DataTable();
            dtBillItems.Columns.Add("ItemId");
            dtBillItems.Columns.Add("ItemName");
            dtBillItems.Columns.Add("Price");
            dtBillItems.Columns.Add("Quantity");
            dtBillItems.Columns.Add("Total");

            ViewState["BillItems"] = dtBillItems;
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            dtBillItems = ViewState["BillItems"] as DataTable;

            int itemId = int.Parse(ddlItem.SelectedValue);
            string itemName = ddlItem.SelectedItem.Text;
            decimal price = Convert.ToDecimal(itemDal.GetItemById(itemId).Rows[0]["Price"]);
            int qty = int.Parse(txtQty.Text);
            decimal total = price * qty;

            dtBillItems.Rows.Add(itemId, itemName, price, qty, total);
            ViewState["BillItems"] = dtBillItems;

            GridBillItems.DataSource = dtBillItems;
            GridBillItems.DataBind();

            UpdateTotalAmount();
        }

        void UpdateTotalAmount()
        {
            dtBillItems = ViewState["BillItems"] as DataTable;

            decimal total = 0;
            foreach (DataRow row in dtBillItems.Rows)
            {
                total += Convert.ToDecimal(row["Total"]);
            }

            lblTotal.Text = total.ToString();
        }

        protected void btnSaveBill_Click(object sender, EventArgs e)
        {
            dtBillItems = ViewState["BillItems"] as DataTable;

            int custId = int.Parse(ddlCustomer.SelectedValue);
            string custName = ddlCustomer.SelectedItem.Text;
            decimal total = Convert.ToDecimal(lblTotal.Text);

            // Insert bill
            int billId = billDal.InsertBill(custId, custName, total);

            // Insert each bill item
            foreach (DataRow row in dtBillItems.Rows)
            {
                billDal.InsertBillItem(
                    billId,
                    int.Parse(row["ItemId"].ToString()),
                    row["ItemName"].ToString(),
                    Convert.ToDecimal(row["Price"]),
                    int.Parse(row["Quantity"].ToString())
                );
            }

            Response.Redirect("BillList.aspx");
        }
    }
}
