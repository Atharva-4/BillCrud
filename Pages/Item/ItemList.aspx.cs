using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillCrud.DAL;


namespace BillCrud.Pages.Items
{
    public partial class ItemList : System.Web.UI.Page
    {
        ItemDAL dal = new ItemDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadItems();
        }

        void LoadItems()
        {
            GridItems.DataSource = dal.GetAllItems();
            GridItems.DataBind();
        }

        protected void GridItems_RowCommand(object sender,
            System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "editItem")
            {
                Response.Redirect("ItemEdit.aspx?id=" + id);
            }
            else if (e.CommandName == "deleteItem")
            {
                dal.DeleteItem(id);
                LoadItems();
            }
        }
    }
}
