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

        public CompanyDetailsController(INVContext context)
        {
            db = context;
        }
      
        public ActionResult List()
        {
        

                var List = db.tblCompanyDetail.Include(t => t.TblCompany).ToList(); 
                return View(List);
            
        }
        // GET: CompanyDetails
        //public ActionResult List(string value)
        //{ 
        //    CompanyVM companyVM = new CompanyVM();
        //    IEnumerable<tblCompanyDetail> modelList = new List<tblCompanyDetail>();

        //    // On --Select Type Selection--
        //    if (value==null) {

        //       ViewBag.List = null;
        //        return View();

        //    }
        //    if (value=="0") 
        //    {
        //        return Json("Please Select the Type");
        //    }
        //    //Payable
        //    if (value=="1") 
        //    {
        //        var List =  db.tblCompanyDetail.Include(t => t.TblCompany).Where(x => x.RemainingAmount == 0).ToList();
        //        modelList = List.Select(x => new tblCompanyDetail() {
        //            companyId = x.companyId,
        //            ProductName = x.ProductName,
        //            TotalAmount = x.TotalAmount,
        //            PaidAmount = x.PaidAmount,
        //            RemainingAmount = x.RemainingAmount,
        //            dateoforder = x.dateoforder,
        //            dateofpayment = x.dateofpayment

                
        //        });
        //        ViewBag.List = List;
        //        return Json(new { response = modelList }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        //    }
        //    //Receivable
        //    if (value=="2") 
        //    {
        //        var List = db.tblCompanyDetail.Include(t => t.TblCompany).Where(x => x.RemainingAmount != 0).ToList();
        //        modelList = List.Select(x => new tblCompanyDetail()
        //        {
        //            companyId = x.companyId,
        //            ProductName = x.ProductName,
        //            TotalAmount = x.TotalAmount,
        //            PaidAmount = x.PaidAmount,
        //            RemainingAmount = x.RemainingAmount,
        //            dateoforder = x.dateoforder,
        //            dateofpayment = x.dateofpayment


        //        });
        //        ViewBag.List = List;
        //        return Json(new { response = modelList }, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        //    }
        //    return View();
           
        //}
        
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
                var List = db.tblCompanyDetail.Include(t => t.TblCompany).Where(x => x.RemainingAmount == 0).ToList();
                modelList = List.Select(x => new tblCompanyDetail()
                {
                   // companyId = x.companyId,
                    ProductName = x.ProductName,
                    TotalAmount = x.TotalAmount,
                    PaidAmount = x.PaidAmount,
                    RemainingAmount = x.RemainingAmount,
                    dateoforder = x.dateoforder,
                    dateofpayment = x.dateofpayment


                });
                ViewBag.List = List;
                return Json(new { response = modelList });
            }
            //Receivable
            if (values == "2")
            {
                var List = db.tblCompanyDetail.Include(t => t.TblCompany).Where(x => x.RemainingAmount != 0).ToList();
                modelList = List.Select(x => new tblCompanyDetail()
                {
                   // companyId = x.companyId,
                    ProductName = x.ProductName,
                    TotalAmount = x.TotalAmount,
                    PaidAmount = x.PaidAmount,
                    RemainingAmount = x.RemainingAmount,
                    dateoforder = x.dateoforder,
                    dateofpayment = x.dateofpayment


                });
                ViewBag.List = List;
                return Json(new { response = modelList });
            }
            return Json("Full");

        }

        public ActionResult History()
        {
            var CompHistoryList = db.tblHIstoryDetail.ToList();
           // ViewBag.CompHistoryList = CompHistoryList;
            return View(CompHistoryList);
        } 
        [HttpPost]
        public ActionResult History(int Id)
        {
            var CompHistoryList = db.tblHIstoryDetail.Where(x => x.HistoryId == Id).ToList();
           // ViewBag.CompHistoryList = CompHistoryList;
            return View(CompHistoryList);
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
        [HttpPost]
        public JsonResult CompDetailCreate([Bind("Id,companyId,ProductName,Description,PhoneNo,TotalAmount,PaidAmount,RemainingAmount,dateoforder,dateofpayment,dateofremainpayment")] CompanyVM vm)
        {
            tblCompanyDetail model = new tblCompanyDetail();
            tblHIstoryDetail model2 = new tblHIstoryDetail();
            var compDetail = db.tblCompanyDetail;
            if (ModelState.IsValid)
            {
                bool checkphonenumber = compDetail.Where(x => x.PhoneNo.Equals(vm.PhoneNo)).Any();
                if (checkphonenumber == true)
                {
                    Json("Phone Number Already Exist*");
                }
                else if (vm.PaidAmount == 0 || vm.PaidAmount == null)
                {
                    vm.PaidAmount = 0;
                }
                else
                {
                    model.companyId = vm.companyId;
                    model.ProductName = vm.ProductName;
                    model.Description = vm.Description;
                    model.PhoneNo = vm.PhoneNo;
                    model.TotalAmount = vm.TotalAmount;
                    model.PaidAmount = vm.PaidAmount;
                    model.RemainingAmount = vm.RemainingAmount;
                    model.dateoforder = vm.dateoforder;
                    model.dateofpayment = vm.dateofpayment;
                    model.dateofremainpayment = vm.dateofremainpayment;

                    //History Detail
                    model2.CompanyDetailId = vm.companyId.GetValueOrDefault(0);
                    model2.ProductName = vm.ProductName;
                    model2.Description = vm.Description;
                    model2.PhoneNo = vm.PhoneNo;
                    model2.TotalAmount = vm.TotalAmount;
                    model2.firstrecevable = vm.PaidAmount;
                    model2.RemainingAmount = vm.RemainingAmount;
                    model2.dateoforder = vm.dateoforder;
                    model2.dateofpayment = vm.dateofpayment;
                    model2.dateofremainpayment = vm.dateofremainpayment;
                    model2.CreatedDate = DateTime.Now;


                    db.tblCompanyDetail.Add(model);
                    db.tblHIstoryDetail.Add(model2);
                    db.SaveChanges();
                    return Json("Record Successfully Saved!");
                }
            }
            ViewData["companyId"] = new SelectList(db.tblCompany, "CompanyId", "CompanyrCode", vm.companyId);

            return Json("Invalid Record is Exist!");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,companyId,ProductName,Description,ArrivalDate,PhoneNo,TotalAmount,PaidAmount,RemainingAmount,dateoforder,dateofpayment,dateofremainpayment")] tblCompanyDetail detail)
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,companyId,ProductName,Description,ArrivalDate,PhoneNo,TotalAmount,PaidAmount,RemainingAmount,dateoforder,dateofpayment,dateofremainpayment")] CompanyVM vm)
        {
            tblCompanyDetail model = new tblCompanyDetail();
            tblHIstoryDetail model2 = new tblHIstoryDetail();
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    model.companyId = vm.companyId;
                    model.ProductName = vm.ProductName;
                    model.Description = vm.Description;
                    model.PhoneNo = vm.PhoneNo;
                    model.TotalAmount = vm.TotalAmount;
                    model.PaidAmount = vm.PaidAmount;
                    model.RemainingAmount = vm.RemainingAmount;
                    model.dateoforder = vm.dateoforder;
                    model.dateofpayment = vm.dateofpayment;
                    model.dateofremainpayment = vm.dateofremainpayment;

                    //History Detail
                    model2.CompanyDetailId = vm.companyId.GetValueOrDefault(0);
                    model2.ProductName = vm.ProductName;
                    model2.Description = vm.Description;
                    model2.PhoneNo = vm.PhoneNo;
                    model2.TotalAmount = vm.TotalAmount;
                    model2.firstrecevable = vm.PaidAmount;
                    model2.RemainingAmount = vm.RemainingAmount;
                    model2.dateoforder = vm.dateoforder;
                    model2.dateofpayment = vm.dateofpayment;
                    model2.dateofremainpayment = vm.dateofremainpayment;
                    model2.DateofEditing = DateTime.Now;



                   
                    
                    db.tblCompanyDetail.Update(model);
                    db.tblHIstoryDetail.Add(model2);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCompanyDetailExists(model.Id))
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
            ViewData["companyId"] = new SelectList(db.tblCompany, "CompanyId", "CompanyrCode", model.companyId);
            return View(model);
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
            return RedirectToAction(nameof(Index));
        }

        private bool tblCompanyDetailExists(int id)
        {
            return db.tblCompanyDetail.Any(e => e.Id == id);
        }
    }
}
