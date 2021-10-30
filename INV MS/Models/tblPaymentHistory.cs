using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models
{
    public class tblPaymentHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


      
        [Display(Name = "Company Name :")]
        public string companyName { get; set; }

        
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }

        

        //[DataType(DataType.PhoneNumber)]
        //[Display(Name = "Phone No ")]
        //public string PhoneNo { get; set; }

        
        [Display(Name = "Total Amount ")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Total Amount Received ")]
        public decimal TotalAmountReceived { get; set; }

        [Display(Name = "Paid Amount")]
        public decimal PaidAmount { get; set; }

        [Display(Name = "Remaining Balance")]
        public decimal RemainingAmount { get; set; }

        [Display(Name = "Date of Order ")]
        [DataType(DataType.Date)]
        public DateTime dateoforder { get; set; }

        [Display(Name = "Date of payment")]
        [DataType(DataType.Date)]
        public DateTime dateofpayment { get; set; }

        [Display(Name = "Date of Remaing payment")]
        [DataType(DataType.Date)]
        public DateTime? dateofremainpayment { get; set; }


    }
}
