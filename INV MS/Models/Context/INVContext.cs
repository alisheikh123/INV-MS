using Inventory_Management_Systems.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INV_MS.Models;
using Microsoft.AspNetCore.Identity;
using INV_MS.Models.TransportModel;

namespace INV_MS.Models
{
    public class INVContext: IdentityDbContext<IdentityUser>
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
        public DbSet<tblPaymentHistory> tblPaymentHistories { get; set; }

        public DbSet<tblVoucherDetail> tblVoucherDetail { get; set; }
        public DbSet<IdentityUser> IdentityUser { get; set; }

        public DbSet<tblCompanyDetail> tblCompanyDetail { get; set; }
        public DbSet<tblTransportPaymentHistory> tblTransportPaymentHistory { get; set; }
        public DbSet<tblDriver> tblDriver { get; set; }
        public DbSet<tblExpenses> tblExpenses { get; set; }
        public DbSet<tblTransportDetail> tblTransportDetail { get; set; }
        public DbSet<tblVehicle> tblVehicle { get; set; }
        public DbSet<tblProduct> tblProducts { get; set; }
     


        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=INV.db");

    }
}
