using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INV_MS.Models;
using Inventory_Management_Systems.Models;
using Microsoft.AspNetCore.Authorization;

namespace INV_MS.Controllers
{
    [Authorize]
    public class tblCompaniesController : Controller
    {
        private readonly INVContext db;

        public tblCompaniesController(INVContext context)
        {
            db = context;
        }

        // GET: tblCompanies
        public async Task<IActionResult> Index()
        {
            return View(await db.tblCompany.ToListAsync());
        }

        // GET: tblCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompany = await db.tblCompany
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
      
        public async Task<IActionResult> Create([Bind("CompanyId,CompanyrCode,Name,Email,Contact,Address")] tblCompany tblCompany)
        {
            if (ModelState.IsValid)
            {
               
                    db.Add(tblCompany);
                    await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(tblCompany);
        }  
        [HttpPost]
      
        public async Task<IActionResult> CreateCompany([Bind("CompanyId,CompanyrCode,Name,Email,Contact,Address")] tblCompany tblCompany)
        {
            if (ModelState.IsValid)
            {
                var companyCodes = db.tblCompany.Where(x => x.CompanyrCode == tblCompany.CompanyrCode).Select(x=>x.CompanyrCode).ToList();
                if (companyCodes.Count() > 0)
                {
                    return Json("Company Code Already Exist!");
                }
                else
                {
                    db.Add(tblCompany);
                    await db.SaveChangesAsync();
                    return Json("Company Record Successfully Added!");
                }
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

            var tblCompany = await db.tblCompany.FindAsync(id);
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
                    db.Update(tblCompany);
                    await db.SaveChangesAsync();
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

            var tblCompany = await db.tblCompany
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
            var tblCompany = await db.tblCompany.FindAsync(id);
            db.tblCompany.Remove(tblCompany);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCompanyExists(int id)
        {
            return db.tblCompany.Any(e => e.CompanyId == id);
        }
    }
}
