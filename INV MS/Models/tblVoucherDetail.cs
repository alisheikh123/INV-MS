using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models
{
    public class tblVoucherDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int voucherdetailId { get; set; }


        [Required(ErrorMessage = "*Required Voucher ID")]
        [Display(Name = "Voucher ID:")]
        public int voucherId { get; set; }

        
        [Display(Name = "Narration:")]
        public string Narration { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Required(ErrorMessage = "*Required Debit Amount ")]
        [Display(Name = "Debit Amount:")]
        public decimal debitAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [Required(ErrorMessage = "*Required Credit Amount ")]
        [Display(Name = "Credit Amount :")]
        public decimal creditAmount { get; set; }



        //Forign Keys
        [ForeignKey("voucherId")]
        public virtual tblVoucher TblVoucher { get; set; }
    }
}