using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models.TransportModel
{
    public class tblVehicle
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public string Name { get; set; }
        [Required]
        public string VehicleNo { get; set; }
        public string OwnerName { get; set; }
        public string ContactNumber { get; set; }
    }
}
