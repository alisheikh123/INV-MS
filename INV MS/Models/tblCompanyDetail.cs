using Inventory_Management_Systems.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models
{
    public class tblCompanyDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "*Required Company Name")]
        [Display(Name = "Company Name :")]
        public int? companyId { get; set; }

        [Required(ErrorMessage = "*Required Product Name")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

    
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Arrival Date")]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone No ")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "*Required Total Amount")]
        [Display(Name = "Total Amount ")]
        public int TotalAmount { get; set; }

        [Required(ErrorMessage = "*Required Paid Amount")]
        [Display(Name = "Paid Amount")]
        public int PaidAmount { get; set; }

        [Display(Name = "Remaining Balance")]
        public int RemainingAmount { get; set; }

        [Display(Name = "Date of Order ")]
        [DataType(DataType.Date)]
        public DateTime dateoforder { get; set; }

        [Display(Name = "Date of payment")]
        [DataType(DataType.Date)]
        public DateTime dateofpayment { get; set; } 

        [Display(Name = "Date of Remaing payment")]
        [DataType(DataType.Date)]
        public DateTime dateofremainpayment { get; set; }

    



        [ForeignKey("companyId")]
        public virtual tblCompany TblCompany { get; set; }
    }
}
