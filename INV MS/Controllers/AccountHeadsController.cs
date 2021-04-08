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
    public class AccountHeadsController : Controller
    {
        private readonly INVContext db;

        public AccountHeadsController(INVContext context)
        {
            db = context;
        }

        // GET: AccountHeads
        public async Task<IActionResult> Index()
        {
            return View(await db.tblAccountHead.ToListAsync());
        }

        // GET: AccountHeads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAccountHead = await db.tblAccountHead
                .FirstOrDefaultAsync(m => m.accountHeadId == id);
            if (tblAccountHead == null)
            {
                return NotFound();
            }

            return View(tblAccountHead);
        }

        // GET: AccountHeads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountHeads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("accountHeadId,accountHeadName,account_Head_Code")] tblAccountHead tblAccountHead)
        {
            if (ModelState.IsValid)
            {
                db.Add(tblAccountHead);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAccountHead);
        }

        // GET: AccountHeads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAccountHead = await db.tblAccountHead.FindAsync(id);
            if (tblAccountHead == null)
            {
                return NotFound();
            }
            return View(tblAccountHead);
        }

        // POST: AccountHeads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("accountHeadId,accountHeadName,account_Head_Code")] tblAccountHead tblAccountHead)
        {
            if (id != tblAccountHead.accountHeadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblAccountHead);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblAccountHeadExists(tblAccountHead.accountHeadId))
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
            return View(tblAccountHead);
        }

        // GET: AccountHeads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAccountHead = await db.tblAccountHead
                .FirstOrDefaultAsync(m => m.accountHeadId == id);
            if (tblAccountHead == null)
            {
                return NotFound();
            }

            return View(tblAccountHead);
        }

        // POST: AccountHeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAccountHead = await db.tblAccountHead.FindAsync(id);
            db.tblAccountHead.Remove(tblAccountHead);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblAccountHeadExists(int id)
        {
            return db.tblAccountHead.Any(e => e.accountHeadId == id);
        }
    }
}
