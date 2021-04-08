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
    public class CategoryController : Controller
    {
        private readonly INVContext _context;

        public CategoryController(INVContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblItemcategory.ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItemcategory = await _context.tblItemcategory
                .FirstOrDefaultAsync(m => m.catId == id);
            if (tblItemcategory == null)
            {
                return NotFound();
            }

            return View(tblItemcategory);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("catId,catName,catDesc")] tblItemcategory tblItemcategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblItemcategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblItemcategory);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItemcategory = await _context.tblItemcategory.FindAsync(id);
            if (tblItemcategory == null)
            {
                return NotFound();
            }
            return View(tblItemcategory);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("catId,catName,catDesc")] tblItemcategory tblItemcategory)
        {
            if (id != tblItemcategory.catId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblItemcategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblItemcategoryExists(tblItemcategory.catId))
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
            return View(tblItemcategory);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItemcategory = await _context.tblItemcategory
                .FirstOrDefaultAsync(m => m.catId == id);
            if (tblItemcategory == null)
            {
                return NotFound();
            }

            return View(tblItemcategory);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblItemcategory = await _context.tblItemcategory.FindAsync(id);
            _context.tblItemcategory.Remove(tblItemcategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblItemcategoryExists(int id)
        {
            return _context.tblItemcategory.Any(e => e.catId == id);
        }
    }
}
