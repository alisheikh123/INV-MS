using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models.TransportModel
{
    public class tblTransportPaymentHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Company Name :")]
        public string companyName { get; set; }

        
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Total Amount ")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Date of Dispatch")]
        [DataType(DataType.Date)]
        public DateTime Dateofdispatch { get; set; }

        [Display(Name = "Delivery Date")]
        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }


        [Display(Name = "Broker Name")]
      
        public string BrokerName { get; set; }

        [Display(Name = "Date of Payment")]
        [DataType(DataType.Date)]
        public DateTime dateofpayment { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        
       

        [Display(Name = "Total Amount Received ")]
        public decimal TotalAmountReceived { get; set; }

        [Display(Name = "Paid Amount")]
        public decimal PaidAmount { get; set; }

        [Display(Name = "Remaining Balance")]
        public decimal RemainingAmount { get; set; }

        [Display(Name = "Date of Remaing payment")]
        [DataType(DataType.Date)]
        public DateTime? dateofremainpayment { get; set; }

     

    }
}
