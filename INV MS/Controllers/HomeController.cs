﻿using INV_MS.Models;
using Inventory_Management_Systems.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INVContext db;

       
        public HomeController(ILogger<HomeController> logger, INVContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            var companyCreated = db.tblCompany.Count();
            var totalCompanyCounts = db.tblCompanyDetail.Count();
            var remaingpayment = db.tblCompanyDetail.Where(x => x.RemainingAmount > 0).Select(x=>x.RemainingAmount).Count();
            var totalpayment = db.tblCompanyDetail.Where(x => x.RemainingAmount == 0).Select(x=>x.RemainingAmount).Count();
            ViewBag.CompanyCount = totalCompanyCounts;
            ViewBag.remaingpayment = remaingpayment;
            ViewBag.totalpayment = totalpayment;
            ViewBag.companyCreated = companyCreated;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
