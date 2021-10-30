using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models.ViewModel
{
    public class TransportPaymentDTO
    {
        public int TranspDetailId { get; set; }
        public string companyName { get; set; }
        public string ProductName { get; set; }
        public decimal TotalAmount { get; set; }

        public DateTime Dateofdispatch { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string BrokerName { get; set; }
        public DateTime dateofpayment { get; set; }


        public string DriverName { get; set; }
        public string VehicleNo { get; set; }
        public string description { get; set; }
     
        public decimal TotalAmountReceived { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
       
        public DateTime? dateofremainpayment { get; set; }
    }
}
