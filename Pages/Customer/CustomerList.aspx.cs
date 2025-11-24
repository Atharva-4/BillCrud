using BillCrud.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BillCrud.Pages.Customer
{
    public partial class CustomerList : System.Web.UI.Page
    {
        CustomerDAL dal = new CustomerDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomers();
            }
        }

        void LoadCustomers()
        {
            GridCustomers.DataSource = dal.GetAllCustomers();
            GridCustomers.DataBind();
        }

        protected void GridCustomers_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "editCustomer")
            {
                Response.Redirect("CustomerEdit.aspx?id=" + id);
            }
            else if (e.CommandName == "deleteCustomer")
            {
                dal.DeleteCustomer(id);
                LoadCustomers();
            }
        }
    }
}
