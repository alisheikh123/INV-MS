using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models.ViewModel
{
    public class ItemVM
    {
        public int itemId { get; set; }
        public int catId { get; set; }
        public string catName { get; set; }
        public string catDescription { get; set; }
        public int UnitId { get; set; }
        public string unitName { get; set; }
        public string ItemCode { get; set; }
        public string itemName { get; set; }
        public string Description { get; set; }
        public decimal purchase_Price { get; set; }
        public decimal sale_Price { get; set; }
    }
}
