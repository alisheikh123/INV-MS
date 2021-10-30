using INV_MS.Models;
using INV_MS.Models.TransportModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Controllers.TransportControllers
{
    public class ProductController : Controller
    {
        private readonly INVContext db;
        public ProductController(INVContext context)
        {
            db = context;
        }
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            return View(await db.tblProducts.ToListAsync());
        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblproduct = await db.tblProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblproduct == null)
            {
                return NotFound();
            }

            return View(tblproduct);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind("Id,ProductName,Description")] tblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {

                db.Add(tblProduct);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(tblProduct);
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblproduct = await db.tblProducts.FindAsync(id);
            if (tblproduct == null)
            {
                return NotFound();
            }
            return View(tblproduct);
           
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Description")] tblProduct tblProduct)
        {
            if (id != tblProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblProduct);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblProductExists(tblProduct.Id))
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
            return View(tblProduct);
        }

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblproduct = await db.tblProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblproduct == null)
            {
                return NotFound();
            }

            return View(tblproduct);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProduct = await db.tblProducts.FindAsync(id);
            db.tblProducts.Remove(tblProduct);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool tblProductExists(int id)
        {
            return db.tblProducts.Any(e => e.Id == id);
        }
    }
}
