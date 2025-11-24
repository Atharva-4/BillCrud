using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillCrud.DAL;

namespace BillCrud.Pages.Bills
{
    public partial class BillList : System.Web.UI.Page
    {
        BillDAL dal = new BillDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadBills();
        }

        void LoadBills()
        {
            GridBills.DataSource = dal.GetBills();
            GridBills.DataBind();
        }

        protected void GridBills_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int billId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "viewBill")
            {
                Response.Redirect("BillView.aspx?id=" + billId);
            }
            else if (e.CommandName == "deleteBill")
            {
                dal.DeleteBill(billId);
                LoadBills();
            }
        }
    }
}
