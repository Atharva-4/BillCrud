using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillCrud.DAL;
using System.Data;

namespace BillCrud.Pages.Items
{
    public partial class ItemEdit : System.Web.UI.Page
    {
        ItemDAL dal = new ItemDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                LoadItem(id);
            }
        }

        void LoadItem(int id)
        {
            DataTable dt = dal.GetItemById(id);

            if (dt.Rows.Count > 0)
            {
                hfItemId.Value = dt.Rows[0]["ItemId"].ToString();
                txtName.Text = dt.Rows[0]["ItemName"].ToString();
                txtPrice.Text = dt.Rows[0]["Price"].ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hfItemId.Value);

            decimal price = 0;
            decimal.TryParse(txtPrice.Text, out price);

            dal.UpdateItem(id, txtName.Text, price);

            Response.Redirect("ItemList.aspx");
        }
    }
}
