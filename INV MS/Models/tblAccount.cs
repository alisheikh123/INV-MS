using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models
{
    public class tblAccount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int accountId { get; set; }


        [Required(ErrorMessage = "*Required Account Head Name")]
        [Display(Name = "Account Head Name :")]
        public int accountHeadId { get; set; }

        [Required(ErrorMessage = "*Required Account Code")]
        [Display(Name = "Account Code:")]
        public int accountCode { get; set; }

        [Display(Name = "Account Title :")]
        [Required(ErrorMessage = "*Required accountTitle ")]
        public string accountTitle { get; set; }

        [DataType(DataType.PhoneNumber)]
     
        [Display(Name = "Phone No :")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "*Required Mobile No")]
        [Display(Name = "Mobile No :")]
        public string MobileNo { get; set; }

        
        [Display(Name = "Email :")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Required Address")]
        [Display(Name = "Address :")]
        public string Address { get; set; }



        [ForeignKey("accountHeadId")]
        public virtual tblAccountHead TblAccountHead { get; set; }
    }
}