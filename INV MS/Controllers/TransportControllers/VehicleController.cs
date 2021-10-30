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
    public class VehicleController : Controller
    {
        private readonly INVContext db;
        // GET: VehicleController

        public VehicleController(INVContext context)
        {
            db = context;
        }
     
        public async Task<IActionResult> Index()
        {
            return View(await db.tblVehicle.ToListAsync());
        }
        // GET: VehicleController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVehicle = await db.tblVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblVehicle == null)
            {
                return NotFound();
            }

            return View(tblVehicle);
        }

        // GET: VehicleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,VehicleNo,OwnerName,ContactNumber")] tblVehicle tblVehicle)
        {
            if (ModelState.IsValid)
            {
                var vehicleCodes = db.tblVehicle.Where(x => x.VehicleNo == tblVehicle.VehicleNo).Select(x => x.VehicleNo).ToList();
                if (vehicleCodes.Count() > 0)
                {
                    return Json("Vehicle Code Already Exist!");
                }
                else
                {
                    db.Add(tblVehicle);
                    await db.SaveChangesAsync();
                    return Redirect("Index");
                    //return Json("Vehicle Record Successfully Added!");
                }
            }
            return View(tblVehicle);
        }

        // GET: VehicleController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblvehicle = await db.tblVehicle.FindAsync(id);
            if (tblvehicle == null)
            {
                return NotFound();
            }
            return View(tblvehicle);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,VehicleNo,OwnerName,ContactNumber")] tblVehicle tblVehicle)
        {
            if (id != tblVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblVehicle);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblVehicleExists(tblVehicle.Id))
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
            return View(tblVehicle);
        }

        // GET: VehicleController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVehicle = await db.tblVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblVehicle == null)
            {
                return NotFound();
            }

            return View(tblVehicle);
        }

        // POST: tblCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblVehicl = await db.tblVehicle.FindAsync(id);
            db.tblVehicle.Remove(tblVehicl);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool tblVehicleExists(int id)
        {
            return db.tblVehicle.Any(e => e.Id == id);
        }
    }
}
