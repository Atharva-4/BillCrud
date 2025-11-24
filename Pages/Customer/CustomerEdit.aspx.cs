using BillCrud.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace BillCrud.Pages.Customer
{
    public partial class CustomerEdit : System.Web.UI.Page
    {
        CustomerDAL dal = new CustomerDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                LoadCustomer(id);
            }
        }

        void LoadCustomer(int id)
        {
            DataTable dt = dal.GetCustomerById(id);

            if (dt.Rows.Count > 0)
            {
                hfCustomerId.Value = dt.Rows[0]["CustomerId"].ToString();
                TxtName.Text = dt.Rows[0]["CustomerName"].ToString();
                TxtPhone.Text = dt.Rows[0]["Phone"].ToString();
                TxtEmail.Text = dt.Rows[0]["Email"].ToString();
                TxtAddress.Text = dt.Rows[0]["Address"].ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hfCustomerId.Value);

            dal.UpdateCustomer(id,
                               TxtName.Text,
                               TxtPhone.Text,
                               TxtEmail.Text,
                               TxtAddress.Text);

            Response.Redirect("CustomerList.aspx");
        }
    }
}

