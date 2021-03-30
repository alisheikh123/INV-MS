using Inventory_Management_Systems.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INV_MS.Models;

namespace INV_MS.Models
{
    public class INVContext: IdentityDbContext<ApplicationUser>
    {
        public INVContext(DbContextOptions<INVContext> options)
     : base(options)
        { }
        public DbSet<tblItemcategory> tblItemcategory { get; set; }

        public DbSet<tblAccount> tblAccount { get; set; }

        public DbSet<tblInvoice> tblInvoice { get; set; }
        public DbSet<tblItem> tblItem { get; set; }
        public DbSet<tblItemUnit> tblItemUnit { get; set; }
        public DbSet<tblInvoiceDetail> tblInvoiceDetail { get; set; }
        public DbSet<tblAccountHead> tblAccountHead { get; set; }
        public DbSet<tblCompany> tblCompany { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<tblVoucher> tblVoucher { get; set; }

        public DbSet<tblVoucherDetail> tblVoucherDetail { get; set; }
        public DbSet<tblHIstoryDetail> tblHIstoryDetail { get; set; }

        public DbSet<INV_MS.Models.tblCompanyDetail> tblCompanyDetail { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=INV.db");
      
    }
}
