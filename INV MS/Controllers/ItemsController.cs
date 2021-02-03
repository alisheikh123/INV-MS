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
    public class ItemsController : Controller
    {
        private readonly INVContext db;

        public ItemsController(INVContext context)
        {
            db = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var iNVContext = db.tblItem.Include(t => t.Unit).Include(t => t.category);
            return View(await iNVContext.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItem = await db.tblItem
                .Include(t => t.Unit)
                .Include(t => t.category)
                .FirstOrDefaultAsync(m => m.itemId == id);
            if (tblItem == null)
            {
                return NotFound();
            }

            return View(tblItem);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["UnitId"] = new SelectList(db.tblItemUnit, "unitId", "unitName");
            ViewData["catId"] = new SelectList(db.tblItemcategory, "catId", "catName");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("itemId,catId,UnitId,ItemCode,itemName,purchase_Price,sale_Price")] tblItem tblItem)
        {
            if (ModelState.IsValid)
            {
                db.Add(tblItem);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnitId"] = new SelectList(db.tblItemUnit, "unitId", "unitName", tblItem.UnitId);
            ViewData["catId"] = new SelectList(db.tblItemcategory, "catId", "catName", tblItem.catId);
            return View(tblItem);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItem = await db.tblItem.FindAsync(id);
            if (tblItem == null)
            {
                return NotFound();
            }
            ViewData["UnitId"] = new SelectList(db.tblItemUnit, "unitId", "unitName", tblItem.UnitId);
            ViewData["catId"] = new SelectList(db.tblItemcategory, "catId", "catName", tblItem.catId);
            return View(tblItem);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("itemId,catId,UnitId,ItemCode,itemName,purchase_Price,sale_Price")] tblItem tblItem)
        {
            if (id != tblItem.itemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblItem);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblItemExists(tblItem.itemId))
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
            ViewData["UnitId"] = new SelectList(db.tblItemUnit, "unitId", "unitName", tblItem.UnitId);
            ViewData["catId"] = new SelectList(db.tblItemcategory, "catId", "catName", tblItem.catId);
            return View(tblItem);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblItem = await db.tblItem
                .Include(t => t.Unit)
                .Include(t => t.category)
                .FirstOrDefaultAsync(m => m.itemId == id);
            if (tblItem == null)
            {
                return NotFound();
            }

            return View(tblItem);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblItem = await db.tblItem.FindAsync(id);
            db.tblItem.Remove(tblItem);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblItemExists(int id)
        {
            return db.tblItem.Any(e => e.itemId == id);
        }
    }
}
