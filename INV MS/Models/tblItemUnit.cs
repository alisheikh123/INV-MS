using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models
{
    public class tblItemUnit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int unitId { get; set; }

        [Display(Name = "Unit Name :")]
        [Required(ErrorMessage = "*Required Unit Name")]
        public string unitName { get; set; }
    }
}