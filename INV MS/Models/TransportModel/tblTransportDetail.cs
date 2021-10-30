using Inventory_Management_Systems.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models.TransportModel
{
    public class tblTransportDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Required Company Name")]
        [Display(Name = "Company Name")]
        public int? companyId { get; set; } 


        [Display(Name = "Product Name")]
        public int? productId { get; set; }

     

        [Display(Name = "Broker Name")]
        public string BrokerName { get; set; }

        [Required(ErrorMessage = "*Required Vehicle No ")]
        [Display(Name = "Vehicle No")]
        public int? vehicleId { get; set; }

        [Required(ErrorMessage = "*Required Driver Name ")]
        [Display(Name = "Driver Name")]
        public int? driverId { get; set; }

        [Display(Name = "From Location")]
        public string FromLocation { get; set; }

        [Display(Name = "To Location")]
        public string ToLocation { get; set; }

        [Display(Name = "Dispatch Date")]
        public DateTime dispatchDate { get; set; }

        [Display(Name = "Delivery Date")]
        public DateTime deliveryDate { get; set; }

        [Required(ErrorMessage = "*Required Total Amount")]
        [Display(Name = "Total Amount ")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Total Amount Received ")]
        public decimal? TotalAmountReceived { get; set; }

      

        [Display(Name = "DateofPayment")]
        public DateTime DateofPayment { get; set; }




        [ForeignKey("driverId")]
        public virtual tblDriver TblDriver { get; set; }

        [ForeignKey("productId")]
        public virtual tblProduct TblProduct { get; set; }
        [ForeignKey("vehicleId")]
        public virtual tblVehicle TblVehicle { get; set; }
        [ForeignKey("companyId")]
        public virtual tblCompany TblCompany { get; set; }

    }
}
