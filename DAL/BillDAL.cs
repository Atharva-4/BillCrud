using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace BillCrud.DAL
{
    public class BillDAL
    {
        string conStr = @"Data Source=.;Initial Catalog=BillCRUD_DB;Integrated Security=True";

        // Insert Bill
        public int InsertBill(int customerId, string customerName, decimal totalAmount)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertBill", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.Parameters.AddWithValue("@CustomerName", customerName);
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                SqlParameter outputId = new SqlParameter("@BillId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputId);

                con.Open();
                cmd.ExecuteNonQuery();

                return Convert.ToInt32(outputId.Value);
            }
        }

        // Insert Bill Item
        public void InsertBillItem(int billId, int itemId, string itemName, decimal price, int qty)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertBillItem", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BillId", billId);
                cmd.Parameters.AddWithValue("@ItemId", itemId);
                cmd.Parameters.AddWithValue("@ItemName", itemName);
                cmd.Parameters.AddWithValue("@ItemPrice", price);
                cmd.Parameters.AddWithValue("@Quantity", qty);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Get All Bills
        public DataTable GetBills()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetBills", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Get Single Bill
        public DataTable GetBill(int billId)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetBill", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@BillId", billId);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Get Bill Items
        public DataTable GetBillItems(int billId)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetBillItems", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@BillId", billId);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Delete Bill
        public void DeleteBill(int billId)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteBill", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BillId", billId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
