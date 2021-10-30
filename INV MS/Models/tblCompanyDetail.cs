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

        

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone No ")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "*Required Total Amount")]
        [Display(Name = "Total Amount ")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Total Amount Received ")]
        public decimal? TotalAmountReceived { get; set; }

    

        [Display(Name = "Date of Order ")]
        [DataType(DataType.Date)]
        public DateTime dateoforder { get; set; }

        [Display(Name = "Date of payment")]
        [DataType(DataType.Date)]
        public DateTime dateofpayment { get; set; } 

    

    



        [ForeignKey("companyId")]
        public virtual tblCompany TblCompany { get; set; }
    }
}
