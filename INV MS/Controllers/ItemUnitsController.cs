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
    public class ItemUnitsController : Controller
    {
        private readonly INVContext db;

        public ItemUnitsController(INVContext context)
        {
            db = context;
        }

        // GET: ItemUnits
        public async Task<IActionResult> Index()
        {
            return View(await db.tblItemUnit.ToListAsync());
        }

        // GET: ItemUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItemUnit = await db.tblItemUnit
                .FirstOrDefaultAsync(m => m.unitId == id);
            if (tblItemUnit == null)
            {
                return NotFound();
            }

            return View(tblItemUnit);
        }

        // GET: ItemUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("unitId,unitName")] tblItemUnit tblItemUnit)
        {
            if (ModelState.IsValid)
            {
                db.Add(tblItemUnit);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblItemUnit);
        }

        // GET: ItemUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItemUnit = await db.tblItemUnit.FindAsync(id);
            if (tblItemUnit == null)
            {
                return NotFound();
            }
            return View(tblItemUnit);
        }

        // POST: ItemUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("unitId,unitName")] tblItemUnit tblItemUnit)
        {
            if (id != tblItemUnit.unitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblItemUnit);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblItemUnitExists(tblItemUnit.unitId))
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
            return View(tblItemUnit);
        }

        // GET: ItemUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItemUnit = await db.tblItemUnit
                .FirstOrDefaultAsync(m => m.unitId == id);
            if (tblItemUnit == null)
            {
                return NotFound();
            }

            return View(tblItemUnit);
        }

        // POST: ItemUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblItemUnit = await db.tblItemUnit.FindAsync(id);
            db.tblItemUnit.Remove(tblItemUnit);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblItemUnitExists(int id)
        {
            return db.tblItemUnit.Any(e => e.unitId == id);
        }
    }
}
