using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillCrud.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public string BillDate { get; set; }
    }
}
