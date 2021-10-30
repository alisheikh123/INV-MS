using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models.ViewModel
{
    public class paymentHistoryDTO
    {
        public int companyDetailId { get; set; }
        public string companyName { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountReceived { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime dateoforder { get; set; }
        public DateTime dateofpayment { get; set; }
        public DateTime? dateofremainpayment { get; set; }
    }
}
