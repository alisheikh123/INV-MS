using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models.ViewModel
{
    public class CompanyVM
    {
     
        public int Id { get; set; }


   
        public int? companyId { get; set; }

        public string ProductName { get; set; }



        public string Description { get; set; }

      
      
        public DateTime ArrivalDate { get; set; }

    
        public string PhoneNo { get; set; }

        public int TotalAmount { get; set; }

        public int PaidAmount { get; set; }

        public int RemainingAmount { get; set; }

        public DateTime dateoforder { get; set; }

        public DateTime dateofpayment { get; set; }

    
        public DateTime dateofremainpayment { get; set; }
    }
}
