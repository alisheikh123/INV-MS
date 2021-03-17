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
    public class tblCompanyDetailsController : Controller
    {
        private readonly INVContext _context;

        public tblCompanyDetailsController(INVContext context)
        {
            _context = context;
        }

        // GET: tblCompanyDetails
        public async Task<IActionResult> Index()
        {
            var iNVContext = _context.tblCompanyDetail.Include(t => t.TblCompany);
            return View(await iNVContext.ToListAsync());
        }

        // GET: tblCompanyDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompanyDetail = await _context.tblCompanyDetail
                .Include(t => t.TblCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCompanyDetail == null)
            {
                return NotFound();
            }

            return View(tblCompanyDetail);
        }

        // GET: tblCompanyDetails/Create
        public IActionResult Create()
        {
            ViewData["companyId"] = new SelectList(_context.tblCompany, "CompanyId", "CompanyrCode");
            return View();
        }

        // POST: tblCompanyDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,companyId,ProductName,Description,ArrivalDate,PhoneNo,TotalAmount,PaidAmount,RemainingAmount,dateoforder,dateofpayment,dateofremainpayment")] tblCompanyDetail companyDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["companyId"] = new SelectList(_context.tblCompany, "CompanyId", "CompanyrCode", companyDetail.companyId);
            return View(companyDetail);
        }

        // GET: tblCompanyDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompanyDetail = await _context.tblCompanyDetail.FindAsync(id);
            if (tblCompanyDetail == null)
            {
                return NotFound();
            }
            ViewData["companyId"] = new SelectList(_context.tblCompany, "CompanyId", "CompanyrCode", tblCompanyDetail.companyId);
            return View(tblCompanyDetail);
        }

        // POST: tblCompanyDetails/Edit/5
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
                    _context.Update(tblCompanyDetail);
                    await _context.SaveChangesAsync();
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
            ViewData["companyId"] = new SelectList(_context.tblCompany, "CompanyId", "CompanyrCode", tblCompanyDetail.companyId);
            return View(tblCompanyDetail);
        }

        // GET: tblCompanyDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompanyDetail = await _context.tblCompanyDetail
                .Include(t => t.TblCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCompanyDetail == null)
            {
                return NotFound();
            }

            return View(tblCompanyDetail);
        }

        // POST: tblCompanyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCompanyDetail = await _context.tblCompanyDetail.FindAsync(id);
            _context.tblCompanyDetail.Remove(tblCompanyDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCompanyDetailExists(int id)
        {
            return _context.tblCompanyDetail.Any(e => e.Id == id);
        }
    }
}
