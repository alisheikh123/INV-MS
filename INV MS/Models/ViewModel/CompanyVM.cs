using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models.ViewModel
{
    public class CompanyVM
    {
     
        public int Id { get; set; }
        public int? companyId { get; set; }
        public string ProductName { get; set; }
        public string CompanyNm { get; set; }
        public string CompanyCode { get; set; }
        public string Description { get; set; }
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "* please add total amount !")]
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountReceived { get; set; }

        [Required(ErrorMessage ="* Date of Order is Missing !")]
        [DataType(DataType.Date)]
        public DateTime dateoforder { get; set; }

        [Required(ErrorMessage = "* Date of Payment is Missing !")]
        [DataType(DataType.Date)]
        public DateTime dateofpayment { get; set; }
    }
}
