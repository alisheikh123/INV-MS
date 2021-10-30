using INV_MS.Models;
using INV_MS.Models.TransportModel;
using INV_MS.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INV_MS.Controllers.TransportControllers
{
    [Authorize]
    public class TransportDetailController : Controller
    {
        private readonly INVContext _context;
        private readonly tblTransportPaymentHistory tblPaymentHistory;
        // GET: TransportDetailController

        public TransportDetailController(INVContext context, tblTransportPaymentHistory _tblPaymentHistory)
        {
            _context = context;
            tblPaymentHistory = _tblPaymentHistory;
        }
       
        public async Task<IActionResult> Index()
        {
            var iNVContext = _context.tblTransportDetail.Include(t => t.TblCompany).Include(x=>x.TblProduct)
                .Include(t=>t.TblVehicle)
                .Include(x=>x.TblDriver);
            return View(await iNVContext.ToListAsync());
        }
        public async Task<IActionResult> AllExpenses()
        {
            var iNVContext = _context.tblExpenses;
            return View(await iNVContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTransportDetail = await _context.tblTransportDetail
                .Include(t => t.TblCompany)
                .Include(t => t.driverId)
                .Include(x => x.vehicleId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTransportDetail == null)
            {
                return NotFound();
            }

            return View(tblTransportDetail);
        }

        // GET: TransportDetailController/Create
        public IActionResult Create()
        {
            ViewData["companyId"] = new SelectList(_context.tblCompany, "CompanyId", "Name");
            ViewData["vehicleId"] = new SelectList(_context.tblVehicle, "Id", "VehicleNo");
            ViewData["driverId"] = new SelectList(_context.tblDriver, "Id", "DriverName");
            ViewData["productId"] = new SelectList(_context.tblProducts, "Id", "ProductName");
            return View();
        }

        // POST: TransportDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,companyId,productId,vehicleId,driverId,FromLocation,ToLocation,dispatchDate,deliveryDate,TotalAmount,TotalAmountReceived,BrokerName,DateofPayment")] tblTransportDetail tblTransport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTransport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["companyId"] = new SelectList(_context.tblCompany, "CompanyId", "Name", tblTransport.companyId);
            ViewData["vehicleId"] = new SelectList(_context.tblVehicle, "Id", "VehicleNo", tblTransport.vehicleId);
            ViewData["driverId"] = new SelectList(_context.tblDriver, "Id", "DriverName", tblTransport.driverId);
            return View(tblTransport);
        }


        public IActionResult TransDetailCreate()
        {
            ViewBag.CompanyList = _context.tblTransportDetail.Include(t => t.TblCompany).Include(t => t.driverId).Include(x => x.vehicleId).ToList();
            return View();
        }
        [HttpPost]
        public JsonResult TransDetailCreate([Bind("Id,companyId,productId,vehicleId,driverId,FromLocation,ToLocation,dispatchDate,deliveryDate,TotalAmount,TotalAmountReceived,BrokerName,DateofPayment")] TransportVM vm)
        {
            tblTransportDetail model = new tblTransportDetail();
            if (ModelState.IsValid)
            {
                model.companyId = vm.companyId;
                model.vehicleId = vm.vehicleId;
                model.driverId = vm.driverId;
                model.productId = vm.productId;
                model.FromLocation = vm.FromLocation;
                model.ToLocation = vm.ToLocation;
                model.TotalAmount = vm.TotalAmount;
                model.BrokerName = vm.BrokerName;
                model.DateofPayment = vm.DateofPayment;
                model.dispatchDate = vm.dispatchDate;
                model.deliveryDate = vm.deliveryDate;
                _context.tblTransportDetail.Add(model);
                _context.SaveChanges();
                return Json("Record Successfully Saved!");

            }
            ViewData["companyId"] = new SelectList(_context.tblTransportDetail, "CompanyId", "Name", vm.companyId);
            ViewData["vehicleId"] = new SelectList(_context.tblVehicle, "Id", "VehicleNo", vm.vehicleId);
            ViewData["driverId"] = new SelectList(_context.tblDriver, "Id", "DriverName", vm.driverId);
          

            return Json("Invalid Record is Exist!");
        }



        // GET: TransportDetailController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTransportDetail = await _context.tblTransportDetail.FindAsync(id);
            if (tblTransportDetail == null)
            {
                return NotFound();
            }
            ViewData["companyId"] = new SelectList(_context.tblCompany, "CompanyId", "Name", tblTransportDetail.companyId);
            ViewData["vehicleId"] = new SelectList(_context.tblVehicle, "Id", "VehicleNo", tblTransportDetail.vehicleId);
            ViewData["driverId"] = new SelectList(_context.tblDriver, "Id", "DriverName", tblTransportDetail.driverId);

            return View(tblTransportDetail);
        }

        // POST: TransportDetailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,companyId,productId,vehicleId,driverId,FromLocation,ToLocation,dispatchDate,deliveryDate,TotalAmount,TotalAmountReceived,BrokerName,DateofPayment")] TransportVM vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vm);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblTransportDetailExists(vm.Id))
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
            ViewData["companyId"] = new SelectList(_context.tblCompany, "CompanyId", "Name", vm.companyId);
            ViewData["vehicleId"] = new SelectList(_context.tblVehicle, "Id", "VehicleNo", vm.vehicleId);
            ViewData["driverId"] = new SelectList(_context.tblDriver, "Id", "DriverName", vm.driverId);
            return View(vm);
        }

        // GET: TransportDetailController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTransportDetail = await _context.tblTransportDetail
                .Include(t => t.TblCompany)
                .Include(t=>t.TblDriver)
                .Include(t=>t.TblVehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblTransportDetail == null)
            {
                return NotFound();
            }

            return View(tblTransportDetail);
        }

        // POST: TransportDetailController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCompanyDetail = await _context.tblTransportDetail.FindAsync(id);
            _context.tblTransportDetail.Remove(tblCompanyDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblTransportDetailExists(int id)
        {
            return _context.tblTransportDetail.Any(e => e.Id == id);
        }




        [HttpGet]
        public ActionResult TranspPaymentDetail(int Id)
        {
            var transpoDetailById = _context.tblTransportDetail.Include(x => x.TblCompany).Include(x=>x.TblProduct)
                    .Include(t => t.TblVehicle)
                    .Include(x => x.TblDriver)
                .Where(x => x.Id == Id).ToList();
            return View(transpoDetailById);
        }
        [HttpPost]
        public ActionResult TranspPaymentDetail(TransportPaymentDTO model)
        {

            if (ModelState.IsValid)
            {
                var tdTotalReceiveable = _context.tblTransportDetail.Find(model.TranspDetailId);

                if (tdTotalReceiveable.TotalAmountReceived == null)
                {
                    tdTotalReceiveable.TotalAmountReceived = model.PaidAmount;
                }
                else
                {

                    tdTotalReceiveable.TotalAmountReceived = tdTotalReceiveable.TotalAmountReceived + model.PaidAmount;
                }


                tblPaymentHistory.companyName = model.companyName;
                tblPaymentHistory.ProductName = model.ProductName;
                tblPaymentHistory.TotalAmount = model.TotalAmount;
                tblPaymentHistory.Dateofdispatch = model.Dateofdispatch;
                tblPaymentHistory.DeliveryDate = model.DeliveryDate;
                tblPaymentHistory.BrokerName = model.BrokerName;
                tblPaymentHistory.dateofpayment = model.dateofpayment;
                tblPaymentHistory.dateofremainpayment = model.dateofremainpayment;
                tblPaymentHistory.Description = model.description;
                tblPaymentHistory.PaidAmount = model.PaidAmount;
                tblPaymentHistory.RemainingAmount = model.RemainingAmount;
               
                tblPaymentHistory.TotalAmountReceived = tblPaymentHistory.TotalAmountReceived + model.PaidAmount;

                _context.tblTransportPaymentHistory.Add(tblPaymentHistory);
                _context.Entry(tdTotalReceiveable).State = EntityState.Modified;
                _context.SaveChanges();
                return Json("Payment Succeefully Added!");



            }
            else
            {

            }
            return View();
        }


        [HttpGet]
        public ActionResult ExpenseDetail(int Id)
        {
            var transpoDetailById = _context.tblTransportDetail
                    .Include(t => t.TblVehicle)
                    .Include(x => x.TblDriver)
                .Where(x => x.Id == Id).ToList();
            return View(transpoDetailById);
        }
        [HttpPost]
        public ActionResult ExpenseDetail(ExpenseDTO model)
        {

            if (ModelState.IsValid)
            {
                
                tblExpenses obj = new tblExpenses();

                obj.TransportId = model.TransportId;
                obj.Description = model.Description;
                obj.CommissionAmount = model.CommissionAmount;
                obj.vehicleNo = model.vehicleNo;
                obj.driverNm = model.driverName;
                obj.TotalAmount = model.TotalAmount;
                obj.DispatchDate = model.DispatchDate;
                obj.DeliveryDate = model.Deliverydate;
                obj.TotalProfit = model.TotalProfit;
                obj.FuelAmount = model.FuelAmount;
                obj.MaintenanceAmount = model.MaintenanceAmount;
                obj.ChallanAmount = model.ChallanAmount;
                obj.DriverFoodAmount = model.DriverFoodAmount;
                obj.ToolTaxAmount = model.ToolTaxAmount;

                _context.tblExpenses.Add(obj);
                //_context.Entry(tdExpenseDetail).State = EntityState.Modified;
                _context.SaveChanges();
                return Json("Expense Succeefully Added!");



            }
            else
            {

            }
            return View();
        }

        
        public async Task<IActionResult> ExpenseDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblExpenseDetail = await _context.tblExpenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblExpenseDetail == null)
            {
                return NotFound();
            }

            return View(tblExpenseDetail);
        }

        
        
       
        public async Task<IActionResult> Remove(int id)
        {
            var tblExp = await _context.tblExpenses.FindAsync(id);
            _context.tblExpenses.Remove(tblExp);
            await _context.SaveChangesAsync();
            return RedirectToAction("AllExpenses", "TransportDetail");
        }
    }
}
