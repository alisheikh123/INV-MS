using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models.ViewModel
{
    public class CompanyVM
    {
     
        public int Id { get; set; }


   
        public int? companyId { get; set; }

        public string ProductName { get; set; }
        public string CompanyNm { get; set; }
        public string CompanyCode { get; set; }



        public string Description { get; set; }


        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

    
        public string PhoneNo { get; set; }

        public int TotalAmount { get; set; }

        public int PaidAmount { get; set; }

        public int RemainingAmount { get; set; }

        [DataType(DataType.Date)]
        public DateTime dateoforder { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateofpayment { get; set; }

        [DataType(DataType.Date)]
        public DateTime dateofremainpayment { get; set; }
    }
}
