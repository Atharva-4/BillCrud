using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillCrud.Models
{
    public class BillItem
    {
        public int BillItemId { get; set; }
        public int BillId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
