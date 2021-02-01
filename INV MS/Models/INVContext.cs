using Inventory_Management_Systems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Models
{
    public class INVContext:DbContext
    {
        public DbSet<tblItemcategory> tblItemcategory { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=INV.db");
    }
}
