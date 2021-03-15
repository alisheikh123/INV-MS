using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INV_MS.Models;
using Inventory_Management_Systems.Models;

namespace INV_MS.Controllers
{
    public class tblCompaniesController : Controller
    {
        private readonly INVContext _context;

        public tblCompaniesController(INVContext context)
        {
            _context = context;
        }

        // GET: tblCompanies
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblCompany.ToListAsync());
        }

        // GET: tblCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompany = await _context.tblCompany
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (tblCompany == null)
            {
                return NotFound();
            }

            return View(tblCompany);
        }

        // GET: tblCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,CompanyrCode,Name,Email,Contact,Address")] tblCompany tblCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCompany);
        }

        // GET: tblCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompany = await _context.tblCompany.FindAsync(id);
            if (tblCompany == null)
            {
                return NotFound();
            }
            return View(tblCompany);
        }

        // POST: tblCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,CompanyrCode,Name,Email,Contact,Address")] tblCompany tblCompany)
        {
            if (id != tblCompany.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCompanyExists(tblCompany.CompanyId))
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
            return View(tblCompany);
        }

        // GET: tblCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompany = await _context.tblCompany
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (tblCompany == null)
            {
                return NotFound();
            }

            return View(tblCompany);
        }

        // POST: tblCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCompany = await _context.tblCompany.FindAsync(id);
            _context.tblCompany.Remove(tblCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCompanyExists(int id)
        {
            return _context.tblCompany.Any(e => e.CompanyId == id);
        }
    }
}
