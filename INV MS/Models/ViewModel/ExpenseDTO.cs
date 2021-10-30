using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models.ViewModel
{
    public class ExpenseDTO
    {
      

        public int TransportId { get; set; }
        public string vehicleNo { get; set; }

      
        public string driverName { get; set; }

    
        public decimal TotalAmount { get; set; }
        public DateTime DispatchDate { get; set; }
        public DateTime Deliverydate { get; set; }

   
        public decimal TotalProfit { get; set; }


        public decimal FuelAmount { get; set; }

   
        public decimal MaintenanceAmount { get; set; }
        public decimal CommissionAmount { get; set; }
        public string Description { get; set; }

        public decimal ChallanAmount { get; set; }

       
        public decimal DriverFoodAmount { get; set; }


       
        public decimal ToolTaxAmount { get; set; }
    }
}
