using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models
{
    public class tblItemcategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int catId { get; set; }

        [Display(Name = "Category Name ")]
        [Required(ErrorMessage = "*Required Category Name")]
        public string catName { get; set; }

        
        [Display(Name = "Description ")]
        public string catDesc { get; set; }
    }
}