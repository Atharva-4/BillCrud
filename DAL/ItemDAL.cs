using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data;
using System.Data.SqlClient;

namespace BillCrud.DAL
{
    public class ItemDAL
    {
        string conStr = @"Data Source=.;Initial Catalog=BillCRUD_DB;Integrated Security=True";

        public DataTable GetAllItems()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetItems", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetItemById(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetItemById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ItemId", id);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void InsertItem(string name, decimal price)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertItem", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ItemName", name);
                cmd.Parameters.AddWithValue("@Price", price);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateItem(int id, string name, decimal price)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateItem", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ItemId", id);
                cmd.Parameters.AddWithValue("@ItemName", name);
                cmd.Parameters.AddWithValue("@Price", price);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteItem(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteItem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ItemId", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
