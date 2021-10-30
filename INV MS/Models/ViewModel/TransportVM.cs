using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models.ViewModel
{
    public class TransportVM
    {
     
        public int Id { get; set; }
        public int? companyId { get; set; }
        public string CompanyNm { get; set; }
        public string CompanyCode { get; set; }

        public int? productId { get; set; }
        public string ProductNm { get; set; }

        public int? vehicleId { get; set; }
        public string vehicleNm { get; set; }
        public string vehicleNo { get; set; }
        public int? driverId { get; set; }
        public string driverNm { get; set; }
        public string driverCnic { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime dispatchDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public string BrokerName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateofPayment { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountReceived { get; set; }

    }
}
