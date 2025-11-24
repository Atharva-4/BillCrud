using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillCrud.DAL;

namespace BillCrud.Pages.Customer
{
    public partial class CustomerAdd : System.Web.UI.Page
    {
        CustomerDAL dal =new CustomerDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            dal.InsertCustomer(TxtName.Text, TxtPhone.Text, TxtEmail.Text, TxtAddress.Text);
            Response.Redirect("CustomerList.aspx");

        }
    }
}