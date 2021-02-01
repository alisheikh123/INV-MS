using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models
{
    public class tblAccountHead
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int accountHeadId { get; set; }


        [Required(ErrorMessage = "*Required Account Head Name ")]
        [Display(Name = "Account Head Name :")]
        public string accountHeadName { get; set; }

        [Required(ErrorMessage = "*Required Account Head Code")]
        [Display(Name = "Account Head Code:")]
        public string account_Head_Code { get; set; }
    }
}