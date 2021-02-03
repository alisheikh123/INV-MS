using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models
{
    public class tblInvoiceDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int invoiceDetailId { get; set; }


        [Required(ErrorMessage = "*Required Invoice ID")]
        [Display(Name = "Invoice ID :")]
        public int invoiceId { get; set; }

        [Required(ErrorMessage = "*Required Item ID")]
        [Display(Name = "Item ID:")]
        public int itemId { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Required(ErrorMessage = "*Required Price ")]
        [Display(Name = "Price :")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "*Required Quantity ")]
        [Display(Name = "Quantity :")]
        public int Quantity { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        [Required(ErrorMessage = "*Required  Amount")]
        [Display(Name = "Amount :")]
        public decimal amount { get; set; }



        /// <summary>
        /// Forign Keys
        /// </summary>

        [ForeignKey("invoiceId")]
        public virtual tblInvoice TblInvoice { get; set; }

        [ForeignKey("itemId")]
        public virtual tblItem TblItem { get; set; }


    }
}