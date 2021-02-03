using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models
{
    public class tblVoucher
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int voucherId { get; set; }


        [Required(ErrorMessage = "*Required Voucher Code")]
        [Display(Name = "Voucher Code :")]
        public string voucherCode { get; set; }

        [Required(ErrorMessage = "*Required Voucher Date:")]
        [Display(Name = "Voucher Date:")]
        public DateTime voucherDate { get; set; }


        [Required(ErrorMessage = "*Required Invoice Id  ")]
        [Display(Name = "Invoice Id :")]
        public int invoiceId { get; set; }

        [Required(ErrorMessage = "*Required Voucher Created By ")]
        [Display(Name = "Voucher Created By :")]
        public int userId { get; set; }



        [Required(ErrorMessage = "*Required  Created Date")]
        [Display(Name = "Created Date :")]
        public DateTime createdDate { get; set; }

        [Required(ErrorMessage = "*Required  Voucher Type")]
        [Display(Name = "Voucher Type :")]
        public string voucher_Type { get; set; }



        //Forign Keys
        [ForeignKey("invoiceId")]
        public virtual tblInvoice TblInvoice { get; set; }

       


    }
}