using Inventory_Management_Systems.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models
{
    public class tblHIstoryDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryId { get; set; }

        public int CompanyDetailId { get; set; }

        public string ProductName { get; set; }



        public string Description { get; set; }

        public string PhoneNo { get; set; }

        public decimal TotalAmount { get; set; }


        public decimal PaidAmount { get; set; }


        public decimal RemainingAmount { get; set; }


        public DateTime? dateoforder { get; set; }

        public DateTime? dateofpayment { get; set; }

        public DateTime? dateofremainpayment { get; set; }

        public DateTime? CreatedDate { get; set; }
        public int? EditedBy { get; set; }
        public string ReasonofEditing { get; set; }
        public DateTime? DateofEditing { get; set; }

        //Forign Keys
        [ForeignKey("CompanyDetailId")]
        public virtual tblCompany TblCompany { get; set; }
    }
}
