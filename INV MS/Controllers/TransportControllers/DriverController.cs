using INV_MS.Models;
using INV_MS.Models.TransportModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Controllers.TransportControllers
{

    [Authorize]
    public class DriverController : Controller
    {
        private readonly INVContext db;
        public DriverController(INVContext context)
        {
            db = context;
        }

        // GET: DriverController
        public async Task<IActionResult> Index()
        {
            return View(await db.tblDriver.ToListAsync());
        }

        // GET: DriverController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDriver = await db.tblDriver
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblDriver == null)
            {
                return NotFound();
            }

            return View(tblDriver);
        }

        // GET: DriverController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DriverController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DriverName,CNIC,Age,ContactNumber,Address")] tblDriver tblDriver)
        {
            if (ModelState.IsValid)
            {
                var driverCnic = db.tblDriver.Where(x => x.CNIC == tblDriver.CNIC).Select(x => x.CNIC).ToList();
                if (driverCnic.Count() > 0)
                {
                    return Json("Driver CNIC Already Exist!");
                }
                else
                {
                    db.Add(tblDriver);
                    await db.SaveChangesAsync();
                    return Redirect("Index");
                }
            }
            return View(tblDriver);
        }

        // GET: DriverController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbldriver = await db.tblDriver.FindAsync(id);
            if (tbldriver == null)
            {
                return NotFound();
            }
            return View(tbldriver);
        }

        // POST: DriverController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DriverName,CNIC,Age,ContactNumber,Address")] tblDriver tblDriver)
        {
            if (id != tblDriver.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblDriver);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblDriverExists(tblDriver.Id))
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
            return View(tblDriver);
        }

        // GET: DriverController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDriver = await db.tblDriver
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblDriver == null)
            {
                return NotFound();
            }

            return View(tblDriver);
        }

        // POST: tblCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblDrive = await db.tblDriver.FindAsync(id);
            db.tblDriver.Remove(tblDrive);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool tblDriverExists(int id)
        {
            return db.tblDriver.Any(e => e.Id == id);
        }
    }
}
