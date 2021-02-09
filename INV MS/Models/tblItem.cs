using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models

{
    public class tblItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int itemId { get; set; }


        [Required(ErrorMessage = "*Required Category Name")]
        [Display(Name = "Category Name ")]
        public int catId { get; set; }

        [Required(ErrorMessage = "*Required unit")]
        [Display(Name = "Unit ")]
        public int UnitId { get; set; }

        //[Remote("IsAlreadyExit", "Item", HttpMethod = "POST", ErrorMessage = "ItemCode already exists in database.")]
        [Display(Name = "Item  Code")]
        [Required(ErrorMessage = "*Required Item Code ")]
        public string ItemCode { get; set; }

        [Required(ErrorMessage = "*Required ItemName")]
        [Display(Name = "Item Name ")]

        public string itemName { get; set; }

        
        [Display(Name = "Description")]
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [Required(ErrorMessage = "*Required Purchase Price")]
        [Display(Name = "Purchase Price ")]
        public decimal purchase_Price { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [Required(ErrorMessage = "*Required Sale Price")]
        [Display(Name = "Sale Price ")]
        public decimal sale_Price { get; set; }





        [ForeignKey("catId")]
        public virtual tblItemcategory category { get; set; }

        [ForeignKey("UnitId")]
        public virtual tblItemUnit Unit { get; set; }

    }
}