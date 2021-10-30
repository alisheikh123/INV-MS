using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models.TransportModel
{
    public class tblDriver
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string DriverName { get; set; }
        public string CNIC { get; set; }
        public string Age { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

    }
}
