using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;




namespace BillCrud.DAL
{
    public class CustomerDAL
    {
        string conStr = @"Data Source=.;Initial Catalog=BillCRUD_DB;Integrated Security=True";

        // Get all customers
        public DataTable GetAllCustomers()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetCustomers", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Insert customer
        
        public void InsertCustomer(string name, string phone, string email, string address)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerName", name);  // FIXED
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Address", address);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //GetCustomerById
        public DataTable GetCustomerById(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GetCustomerById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@CustomerId", id);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Update customer
        public void UpdateCustomer(int id, string name, string phone, string email, string address)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", id);
                cmd.Parameters.AddWithValue("@CustomerName", name);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Address", address);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



        // Delete customer
        public void DeleteCustomer(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
