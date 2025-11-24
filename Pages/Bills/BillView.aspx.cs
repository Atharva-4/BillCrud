using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillCrud.DAL;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace BillCrud.Pages.Bills
{
    public partial class BillView : System.Web.UI.Page
    {
        BillDAL dal = new BillDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int billId = Convert.ToInt32(Request.QueryString["id"]);
                LoadBill(billId);
                LoadBillItems(billId);
            }
        }

        void LoadBill(int billId)
        {
            DataTable dt = dal.GetBill(billId);

            if (dt.Rows.Count > 0)
            {
                lblBillId.Text = dt.Rows[0]["BillId"].ToString();
                lblCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                lblBillDate.Text = Convert.ToDateTime(dt.Rows[0]["BillDate"]).ToString("dd-MM-yyyy");
                lblTotalAmount.Text = dt.Rows[0]["TotalAmount"].ToString();
            }
        }

        void LoadBillItems(int billId)
        {
            GridBillItems.DataSource = dal.GetBillItems(billId);
            GridBillItems.DataBind();
        }
        protected void btnDownloadPDF_Click(object sender, EventArgs e)
        {
            int billId = Convert.ToInt32(Request.QueryString["id"]);

            DataTable bill = dal.GetBill(billId);
            DataTable items = dal.GetBillItems(billId);

            // PDF Document Setup
            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
            MemoryStream ms = new MemoryStream();
            PdfWriter.GetInstance(doc, ms);

            doc.Open();

            // Title: Company Name
            Paragraph title = new Paragraph("LifeRelier\nPune\nPhone: 8605316555",
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            doc.Add(new Paragraph("\n"));

            // Bill Header
            doc.Add(new Paragraph($"Bill ID: {bill.Rows[0]["BillId"]}"));
            doc.Add(new Paragraph($"Customer Name: {bill.Rows[0]["CustomerName"]}"));
            doc.Add(new Paragraph($"Bill Date: {Convert.ToDateTime(bill.Rows[0]["BillDate"]).ToString("dd-MM-yyyy")}"));
            doc.Add(new Paragraph("\n"));

            // Table for items
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 40f, 20f, 20f, 20f });

            // Headers
            table.AddCell("Item");
            table.AddCell("Qty");
            table.AddCell("Price (₹)");
            table.AddCell("Total (₹)");

            // Items Data
            foreach (DataRow row in items.Rows)
            {
                table.AddCell(row["ItemName"].ToString());
                table.AddCell(row["Quantity"].ToString());
                table.AddCell(row["ItemPrice"].ToString());
                table.AddCell(row["Total"].ToString());
            }

            doc.Add(table);
            doc.Add(new Paragraph("\n"));

            // Total
            Paragraph total = new Paragraph($"Total Bill Amount: ₹ {bill.Rows[0]["TotalAmount"]}",
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
            total.Alignment = Element.ALIGN_RIGHT;
            doc.Add(total);

            doc.Close();

            byte[] pdfBytes = ms.ToArray();
            ms.Close();

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Invoice_" + billId + ".pdf");
            Response.BinaryWrite(pdfBytes);
            Response.Flush();
            Response.End();
        }

    }
}
