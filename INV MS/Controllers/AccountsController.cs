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
    public class AccountsController : Controller
    {
        private readonly INVContext db;

        public AccountsController(INVContext context)
        {
            db = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            var iNVContext = db.tblAccount.Include(t => t.TblAccountHead);
            return View(await iNVContext.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAccount = await db.tblAccount
                .Include(t => t.TblAccountHead)
                .FirstOrDefaultAsync(m => m.accountId == id);
            if (tblAccount == null)
            {
                return NotFound();
            }

            return View(tblAccount);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            ViewData["accountHeadId"] = new SelectList(db.tblAccountHead, "accountHeadId", "accountHeadName");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("accountId,accountHeadId,accountCode,accountTitle,PhoneNo,MobileNo,Email,Address")] tblAccount tblAccount)
        {
            if (ModelState.IsValid)
            {
                db.Add(tblAccount);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["accountHeadId"] = new SelectList(db.tblAccountHead, "accountHeadId", "accountHeadName", tblAccount.accountHeadId);
            return View(tblAccount);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAccount = await db.tblAccount.FindAsync(id);
            if (tblAccount == null)
            {
                return NotFound();
            }
            ViewData["accountHeadId"] = new SelectList(db.tblAccountHead, "accountHeadId", "accountHeadName", tblAccount.accountHeadId);
            return View(tblAccount);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("accountId,accountHeadId,accountCode,accountTitle,PhoneNo,MobileNo,Email,Address")] tblAccount tblAccount)
        {
            if (id != tblAccount.accountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblAccount);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblAccountExists(tblAccount.accountId))
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
            ViewData["accountHeadId"] = new SelectList(db.tblAccountHead, "accountHeadId", "accountHeadName", tblAccount.accountHeadId);
            return View(tblAccount);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAccount = await db.tblAccount
                .Include(t => t.TblAccountHead)
                .FirstOrDefaultAsync(m => m.accountId == id);
            if (tblAccount == null)
            {
                return NotFound();
            }

            return View(tblAccount);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAccount = await db.tblAccount.FindAsync(id);
            db.tblAccount.Remove(tblAccount);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblAccountExists(int id)
        {
            return db.tblAccount.Any(e => e.accountId == id);
        }
    }
}
