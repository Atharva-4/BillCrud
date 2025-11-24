using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillCrud.DAL;

namespace BillCrud.Pages.Items
{
    public partial class ItemAdd : System.Web.UI.Page
    {
        ItemDAL dal = new ItemDAL();

        protected void btnSave_Click(object sender, EventArgs e)
        {
            decimal price = 0;
            decimal.TryParse(txtPrice.Text, out price);

            dal.InsertItem(txtName.Text, price);

            Response.Redirect("ItemList.aspx");
        }
    }
}
