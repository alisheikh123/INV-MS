using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models.TransportModel
{
    public class tblExpenses
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public int TransportId { get; set; }

        [Required(ErrorMessage = "*Required Vehicle No ")]
        [Display(Name = "Vehicle No")]
        public string vehicleNo { get; set; }

        [Required(ErrorMessage = "*Required Driver Name ")]
        [Display(Name = "Driver Name")]
        public string driverNm { get; set; }

        [Required(ErrorMessage = "*Required Total Amount")]
        [Display(Name = "Total Amount ")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Dispatch Date ")]
        public DateTime DispatchDate { get; set; }
        [Display(Name = "Delivery Date ")]
        public DateTime DeliveryDate { get; set; }


        [Required(ErrorMessage = "*Required Total Profit Amount")]
        [Display(Name = "Total Profit ")]
        public decimal TotalProfit { get; set; }

     
        [Display(Name = "Fuel Amount ")]
        public decimal FuelAmount { get; set; }

        [Display(Name = "Maintenance Amount ")]
        public decimal MaintenanceAmount { get; set; }

        [Display(Name = "Challan Amount ")]
        public decimal ChallanAmount { get; set; }

        [Display(Name = "Commission Amount ")]
        public decimal CommissionAmount { get; set; }

        [Display(Name = "Driver Food Amount ")]
        public decimal DriverFoodAmount { get; set; }


        [Display(Name = "Tool Tax Amount ")]
        public decimal ToolTaxAmount { get; set; }

        [Display(Name = "Description ")]
        public string Description { get; set; }

       
    }
}
