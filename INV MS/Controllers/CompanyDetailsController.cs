using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INV_MS.Models;

namespace INV_MS.Controllers
{
    public class CompanyDetailsController : Controller
    {
        private readonly INVContext db;

        public CompanyDetailsController(INVContext context)
        {
            db = context;
        }

        // GET: CompanyDetails
        public async Task<IActionResult> Index()
        {
            var iNVContext = db.tblCompanyDetail.Include(t => t.TblCompany);
            return View(await iNVContext.ToListAsync());
        }

        // GET: CompanyDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompanyDetail = await db.tblCompanyDetail
                .Include(t => t.TblCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCompanyDetail == null)
            {
                return NotFound();
            }

            return View(tblCompanyDetail);
        }

        // GET: CompanyDetails/Create
        public IActionResult Create()
        {
            ViewData["companyId"] = new SelectList(db.tblCompany, "CompanyId", "CompanyrCode");
            return View();
        }
        public IActionResult Company()
        {
            ViewData["companyId"] = new SelectList(db.tblCompany, "CompanyId", "Name");
            return View();
        }

        // POST: CompanyDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,companyId,ProductName,Description,ArrivalDate,PhoneNo,TotalAmount,PaidAmount,RemainingAmount,dateoforder,dateofpayment,dateofremainpayment")] tblCompanyDetail detail)
        {
            if (ModelState.IsValid)
            {
                db.Add(detail);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["companyId"] = new SelectList(db.tblCompany, "CompanyId", "CompanyrCode", detail.companyId);
            return View(detail);
        }

        // GET: CompanyDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompanyDetail = await db.tblCompanyDetail.FindAsync(id);
            if (tblCompanyDetail == null)
            {
                return NotFound();
            }
            ViewData["companyId"] = new SelectList(db.tblCompany, "CompanyId", "CompanyrCode", tblCompanyDetail.companyId);
            return View(tblCompanyDetail);
        }

        // POST: CompanyDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,companyId,ProductName,Description,ArrivalDate,PhoneNo,TotalAmount,PaidAmount,RemainingAmount,dateoforder,dateofpayment,dateofremainpayment")] tblCompanyDetail tblCompanyDetail)
        {
            if (id != tblCompanyDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblCompanyDetail);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCompanyDetailExists(tblCompanyDetail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["companyId"] = new SelectList(db.tblCompany, "CompanyId", "CompanyrCode", tblCompanyDetail.companyId);
            return View(tblCompanyDetail);
        }

        // GET: CompanyDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompanyDetail = await db.tblCompanyDetail
                .Include(t => t.TblCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCompanyDetail == null)
            {
                return NotFound();
            }

            return View(tblCompanyDetail);
        }

        // POST: CompanyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCompanyDetail = await db.tblCompanyDetail.FindAsync(id);
            db.tblCompanyDetail.Remove(tblCompanyDetail);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCompanyDetailExists(int id)
        {
            return db.tblCompanyDetail.Any(e => e.Id == id);
        }
    }
}
