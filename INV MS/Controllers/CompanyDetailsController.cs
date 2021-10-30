using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INV_MS.Models;
using INV_MS.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace INV_MS.Controllers
{
    [Authorize]
    public class CompanyDetailsController : Controller
    {
        private readonly INVContext db;
        private readonly tblPaymentHistory tblPaymentHistory;

        public CompanyDetailsController(INVContext context, tblPaymentHistory _tblPaymentHistory)
        {
            db = context;
            tblPaymentHistory = _tblPaymentHistory;
        }
      
        public ActionResult List()
        {
        

                var List = db.tblCompanyDetail.Include(t => t.TblCompany).ToList(); 
                return View(List);
            
        }
       
        
        public JsonResult Lists(string values)
        {
            CompanyVM companyVM = new CompanyVM();
            IEnumerable<tblCompanyDetail> modelList = new List<tblCompanyDetail>();

            // On --Select Type Selection--
         
            if (values == "0")
            {
                return Json("Please Select the Type");
            }
            //Payable
            if (values == "1")
            {
                var List = db.tblCompanyDetail.Include(t => t.TblCompany).ToList();
                modelList = List.Select(x => new tblCompanyDetail()
                {
                   // companyId = x.companyId,
                    ProductName = x.ProductName,
                    TotalAmount = x.TotalAmount,
                    //PaidAmount = x.PaidAmount,
                    //RemainingAmount = x.RemainingAmount,
                    dateoforder = x.dateoforder,
                    dateofpayment = x.dateofpayment


                });
                ViewBag.List = List;
                return Json(new { response = modelList });
            }
            //Receivable
            if (values == "2")
            {
                var List = db.tblCompanyDetail.Include(t => t.TblCompany).ToList();
                modelList = List.Select(x => new tblCompanyDetail()
                {
                   // companyId = x.companyId,
                    ProductName = x.ProductName,
                    TotalAmount = x.TotalAmount,
                    //PaidAmount = x.PaidAmount,
                    //RemainingAmount = x.RemainingAmount,
                    dateoforder = x.dateoforder,
                    dateofpayment = x.dateofpayment


                });
                ViewBag.List = List;
                return Json(new { response = modelList });
            }
            return Json("Full");

        }


        public ActionResult TodayPaymentList()
        {

            var currentDateString = DateTime.UtcNow.ToString("yyyy-MM-dd");
            ViewBag.companyList = new SelectList(db.tblCompany.ToList(), "CompanyId", "Name");
            var currentdate = Convert.ToDateTime(currentDateString);
            var List = db.tblCompanyDetail.Include(t => t.TblCompany).Where(x => x.dateofpayment == currentdate).ToList();

            return View(List);

        }

        [HttpPost]
        public IActionResult TodayPaymentList(DateTime fromDate, DateTime toDate)
        {
            var List = db.tblCompanyDetail;
            if (fromDate == toDate)
            {
                var getList = List.Include(t => t.TblCompany).Where(x => x.dateofpayment == fromDate || x.dateoforder == toDate)
                                        .Select(x => new { companyName = x.TblCompany.Name, productName=x.ProductName, totalAmount = x.TotalAmount, dateofOrder=x.dateoforder, dateofPayment = x.dateofpayment }).ToList();

                return Json(getList);
            }
            else {
                var getDoubleFilter = List.Include(t => t.TblCompany).Where(x => x.dateofpayment >= fromDate && x.dateofpayment <= toDate)
                  .Select(x => new { companyName = x.TblCompany.Name, productName = x.ProductName, totalAmount = x.TotalAmount, dateofOrder = x.dateoforder, dateofPayment = x.dateofpayment }).ToList();
                return Json(getDoubleFilter);
            }

            

        }


        [HttpGet]
        public ActionResult PaymentDetail(int Id)
        {
            var compDetailById = db.tblCompanyDetail.Include(x=>x.TblCompany).Where(x => x.Id == Id).ToList();
            return View(compDetailById);
        }
        [HttpPost]
        public ActionResult PaymentDetail(paymentHistoryDTO model)
        {

            if (ModelState.IsValid)
            {
                var cdTotalReceiveable = db.tblCompanyDetail.Find(model.companyDetailId);

                if (cdTotalReceiveable.TotalAmountReceived == null)
                {
                    cdTotalReceiveable.TotalAmountReceived = model.PaidAmount;
                }
                else {

                    cdTotalReceiveable.TotalAmountReceived = cdTotalReceiveable.TotalAmountReceived + model.PaidAmount;
                }
               
                
                tblPaymentHistory.companyName = model.companyName;
                tblPaymentHistory.ProductName = model.ProductName;
                tblPaymentHistory.dateoforder = model.dateoforder;
                tblPaymentHistory.dateofpayment = model.dateofpayment;
                tblPaymentHistory.dateofremainpayment = model.dateofremainpayment;
                tblPaymentHistory.Description = model.Description;
                tblPaymentHistory.PaidAmount = model.PaidAmount;
                tblPaymentHistory.RemainingAmount = model.RemainingAmount;
                tblPaymentHistory.TotalAmount = model.TotalAmount;
                tblPaymentHistory.TotalAmountReceived = tblPaymentHistory.TotalAmountReceived+ model.PaidAmount;
                
                db.tblPaymentHistories.Add(tblPaymentHistory);
                db.Entry(cdTotalReceiveable).State = EntityState.Modified;
                db.SaveChanges();
                return Json("Payment Succeefully Added!");



            }
            else { 
            
            }
            return View();
        }

        // GET: CompanyDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompanyDetail = await db.tblCompanyDetail
                .Include(t => t.TblCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCompanyDetail == null)
            {
                return NotFound();
            }

            return View(tblCompanyDetail);
        }

        // GET: CompanyDetails/Create
        public IActionResult Create()
        {
            ViewData["companyId"] = new SelectList(db.tblCompany, "CompanyId", "CompanyrCode");
            return View();
        }
        public IActionResult Company()
        {
            ViewData["companyId"] = new SelectList(db.tblCompany, "CompanyId", "Name");
            ViewBag.CompanyList = db.tblCompanyDetail.Include(t => t.TblCompany)/*.Where(x=>x.RemainingAmount==0 || x.RemainingAmount!=null)*/.ToList();
            return View();
        }

        public IActionResult CompDetailCreate()
        {
            ViewBag.CompanyList = db.tblCompanyDetail.Include(t => t.TblCompany).ToList();
            return View();
        }
        //,PaidAmount,RemainingAmount,,dateofremainpayment
        [HttpPost]
        public JsonResult CompDetailCreate([Bind("Id,companyId,ProductName,Description,PhoneNo,TotalAmount,dateoforder,dateofpayment")] CompanyVM vm)
        {
            tblCompanyDetail model = new tblCompanyDetail();
            if (ModelState.IsValid)
            {
                    model.companyId = vm.companyId;
                    model.ProductName = vm.ProductName;
                    model.Description = vm.Description;
                    model.PhoneNo = vm.PhoneNo;
                    model.TotalAmount = vm.TotalAmount;
                    model.dateoforder = vm.dateoforder;
                    model.dateofpayment = vm.dateofpayment;
                    db.tblCompanyDetail.Add(model);
                    db.SaveChanges();
                    return Json("Record Successfully Saved!");
                
            }
            ViewData["companyId"] = new SelectList(db.tblCompany, "CompanyId", "CompanyrCode", vm.companyId);

            return Json("Invalid Record is Exist!");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,companyId,ProductName,Description,ArrivalDate,PhoneNo,TotalAmount,dateoforder,dateofpayment")] tblCompanyDetail detail)
        {
            if (ModelState.IsValid)
            {
                db.Add(detail);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["companyId"] = new SelectList(db.tblCompany, "CompanyId", "CompanyrCode", detail.companyId);
            return View(detail);
        }

        // GET: CompanyDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompanyDetail = await db.tblCompanyDetail.FindAsync(id);
            if (tblCompanyDetail == null)
            {
                return NotFound();
            }
            ViewData["companyId"] = new SelectList(db.tblCompany, "CompanyId", "Name", tblCompanyDetail.companyId);
            return View(tblCompanyDetail);
        }


        [HttpPost]
        public ActionResult Edit(int id, [Bind("Id,companyId,ProductName,Description,PhoneNo,TotalAmount,TotalAmountReceived,dateoforder,dateofpayment")] tblCompanyDetail vm)
        {
          
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(vm);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCompanyDetailExists(vm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(List));
            }
            ViewData["companyId"] = new SelectList(db.tblCompany, "CompanyId", "CompanyrCode", vm.companyId);
            return View(vm);
        }

        // GET: CompanyDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompanyDetail = await db.tblCompanyDetail
                .Include(t => t.TblCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCompanyDetail == null)
            {
                return NotFound();
            }

            return View(tblCompanyDetail);
        }

        // POST: CompanyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCompanyDetail = await db.tblCompanyDetail.FindAsync(id);
            db.tblCompanyDetail.Remove(tblCompanyDetail);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool tblCompanyDetailExists(int id)
        {
            return db.tblCompanyDetail.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> getProduct(int companyId) 
        {
            var productofCompanies = db.tblCompanyDetail.Where(x => x.companyId == companyId).Select(x=>new { x.Id,x.ProductName}).ToList();
            return Json(productofCompanies);
        }
    }
}
